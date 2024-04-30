using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelContoller : Singleton<LevelContoller>,IObserver
{
    private bool endLineReached = false;
    private bool endTimeReached = false;
    [SerializeField] private float initialTime;
    private float timeRemaining; 
    [SerializeField] private TextMeshProUGUI currentTimeDisplay;
    [SerializeField] private TextMeshProUGUI laptTimeDisplay;
    [SerializeField] private Subject endPoint;
    [SerializeField] private Subject health;
    [SerializeField] private Subject raceClient;
    private float level1Time = 0, level2Time = 0, level3Time = 0;
    private bool raceStarted = false;

    public void OnNotify()
    {
        Debug.Log(raceStarted);
        if(raceStarted == true){
            SetEndLineReachedAndSwitch();
        }
        else{
            raceStarted = true;
        }
    }

    void OnSceneLoad(Scene scene, LoadSceneMode mode) {
        //re-find Subjects and add self as observer after scene switch
        if(endPoint == null){
            endPoint = FindObjectOfType<EndPointReached>();
            endPoint.AddObserver(this);
        }
        if(health == null){
            health = FindObjectOfType<Health>();
            health.AddObserver(this);
        }
        if(raceClient == null){
            raceClient = FindObjectOfType<RaceClient>();
            raceClient.AddObserver(this);
        }

        laptTimeDisplay.text = String.Format("Level 1 Time: {0:00}:{1:00}", level1Time/60, level1Time%60);
        laptTimeDisplay.text += String.Format("\nLevel 2 Time: {0:00}:{1:00}", level2Time/60, level2Time%60);
        laptTimeDisplay.text += String.Format("\nLevel 3 Time: {0:00}:{1:00}", level3Time/60, level3Time%60);

        //reset starting parameters
        raceStarted = false;
        timeRemaining = initialTime;
        DisplayTime();
    }
    private void OnEnable()
    {
        endPoint.AddObserver(this);
        SceneManager.sceneLoaded += OnSceneLoad;
        health.AddObserver(this);
        raceClient.AddObserver(this);
    }

    private void OnDisable()
    {
        endPoint.RemoveObserver(this);
        SceneManager.sceneLoaded -= OnSceneLoad;
        health.RemoveObserver(this);
        raceClient.RemoveObserver(this);
    }

    private void Update()
    {
        if(raceStarted == true){
            if (timeRemaining > 0)
            {

                timeRemaining -= Time.deltaTime;

                DisplayTime();
            }
            else
            {
                Debug.Log("Time has run out!");
                SetEndTimeReachedAndSwitch();
            }
        }
    }

    private void OnGUI() {
        if(raceStarted == false){
            GUILayout.BeginArea(new Rect(25, 50, 200, 20));
            GUILayout.Button("Press TAB to start the race!");
            GUILayout.EndArea();
        }
    }

    void DisplayTime()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);


        currentTimeDisplay.text = String.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
            Debug.Log("Wrapped around to the first scene!");
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
    public void SetEndTimeReachedAndSwitch()
    {
        endTimeReached = true;
        currentTimeDisplay.text = "Time ended";
        LoadNextScene();

        Debug.Log("You have been taken to the next level");
    }

    public void SetEndLineReachedAndSwitch()
    {
        endLineReached = true;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        switch(currentSceneIndex){
            case 0: level1Time = initialTime - timeRemaining; break;
            case 1: level2Time = initialTime - timeRemaining; break;
            case 2: level3Time = initialTime - timeRemaining; break;
            default: break;
        }
        Invoke("LoadNextScene", 3f);
        Debug.Log("You have been taken to the next level");
    }
}
