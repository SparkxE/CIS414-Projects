using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelContoller : Singleton<LevelContoller>
{
    private bool endLineReached = false;
    private bool endTimeReached = false;
    private DateTime sessionStartTime;
    private DateTime sessionEndTime;
    [SerializeField] private float timeRemaining = 120; // Change to 1 minute
    [SerializeField] public TextMeshProUGUI textMeshPro;


    public void Start()
    {
        textMeshPro = FindAnyObjectByType<TextMeshProUGUI>();
        sessionStartTime = DateTime.Now;
     
        // Invoke the switch to end scene function after 2 minutes
        Invoke(nameof(SetEndTimeReachedAndSwitch), timeRemaining);
    }

    private void Update()
    {
       


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

    void DisplayTime()
    {


        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);


        textMeshPro.text = String.Format("Remaining Time : {0:00}:{1:00}", minutes, seconds);
    
    }
    private void OnApplicationQuit()
    {
        sessionEndTime = DateTime.Now;
        TimeSpan timeDifference = sessionEndTime.Subtract(sessionStartTime);
        Debug.Log("Game Session start time: " + DateTime.Now);
        Debug.Log("Game Session lasted: " + timeDifference);

    }


    private void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
            Debug.Log(" Wraped around to the first scene and the game came to an end ! ");
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
    public void SetEndTimeReachedAndSwitch()
    {

        endTimeReached = true;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        this.textMeshPro.text = "Time ended";
        LoadNextScene();

        Debug.Log("You have been taken to the next level");
    }

    public void SetEndLineReachedAndSwitch()
    {
        endLineReached = true;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        LoadNextScene();
        this.textMeshPro.text = "Time ended";

        Debug.Log("You have been taken to the next level");
    }

 

}
