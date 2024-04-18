using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : Singleton<DataManager>
{
    private DateTime sessionStartTime;
    private DateTime sessionEndTime;
    private TimeSpan durationLimit = TimeSpan.FromMinutes(3);


    void Start()
    {
        sessionStartTime = DateTime.Now;
        Debug.Log("Game Session start time: " + sessionStartTime);
        StartCoroutine(CheckSceneDuration());
    }
    private void OnApplicationQuit()
    {
        sessionEndTime = DateTime.Now;
        TimeSpan sessionDuration = sessionEndTime.Subtract(sessionStartTime);
        Debug.Log("Game Session end time: " + sessionEndTime);
        Debug.Log("Game Session duration: " + sessionDuration);
    }
    private IEnumerator CheckSceneDuration()
    {
        yield return new WaitForSeconds((float)durationLimit.TotalSeconds);
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
            Debug.Log(" Wraped around to the first scene and the game came to an end ! ");// Wrap around to the first scene if at the end
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    private void OnGUI()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        if (GUILayout.Button("Next Scene"))
        {
            LoadNextScene();
        }
    }
}
