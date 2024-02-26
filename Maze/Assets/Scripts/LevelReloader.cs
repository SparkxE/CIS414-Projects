using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReloader : Singleton<LevelReloader>
{
    private void OnGUI()
    {
        if (GUILayout.Button("New Maze"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        GUI.color = Color.white;
    }
}
