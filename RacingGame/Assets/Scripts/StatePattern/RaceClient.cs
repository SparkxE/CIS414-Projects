using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceClient : MonoBehaviour
{
    private RaceController raceController;
   

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<RaceController>();
        this.raceController = (RaceController)FindObjectOfType(typeof(RaceController));
    }

    void OnGUI() {
        //GUI Layout information goes here


        GUILayout.BeginArea(new Rect(25, 25, 200, 20));
        if (GUILayout.Button("Start Race")){
            raceController.StartRace();
        }
        GUILayout.EndArea();

        GUILayout.BeginArea(new Rect(25, 50, 200, 20));
        if (GUILayout.Button("Stop Race")){
            raceController.StopRace();
        }

        GUILayout.EndArea();
    }
}
