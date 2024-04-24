using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class RaceController : MonoBehaviour 
{
    private IRaceState startState, stopState, endState;
    private RaceStateContext raceStateContext;
    private bool endLineReached = false;
    private bool endTimeReached = false;
    private DateTime sessionStartTime;
    private DateTime sessionEndTime;
    private float timeRemaining = 120; // Change to 1 minute
    public TextMeshPro textMeshPro;

    public void StartRace(){
        this.raceStateContext.Transition(this.startState);
    }

    public void StopRace(){
        this.raceStateContext.Transition(this.stopState);
    }

    // Start is called before the first frame update
    void Start()
    {
        this.raceStateContext = gameObject.AddComponent<RaceStateContext>();
        
        this.startState = gameObject.AddComponent<RaceStartState>();
        this.stopState = gameObject.AddComponent<RaceStopState>();
        this.endState = gameObject.AddComponent<RaceEndState>();

        sessionStartTime = DateTime.Now;
        this.raceStateContext.Transition(stopState);
        // Invoke the switch to end scene function after 2 minutes
        Invoke(nameof(SetEndTimeReachedAndSwitch), 10);

     

    }
   
    private void Update()
    {

    


        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            Debug.Log("Time has run out!");
            SetEndTimeReachedAndSwitch();


        }
    }

    void DisplayTime(float timeToDisplay)
    {
      

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

      //  textMeshPro.text = string.Format("{0:00}:{1:00}", minutes, seconds);
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

        Debug.Log("You have been taken to the next level");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered!"); 

        if (other.CompareTag("EndPoint"))
        {
            Debug.Log("End point reached!"); 

            SetEndLineReachedAndSwitch();

            Debug.Log("You have reached the end of the current level ");
        }
    }



}
