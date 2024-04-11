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
        if(GUILayout.Button("Start Race")){
            raceController.StartRace();
        }
        if(GUILayout.Button("Stop Race")){
            raceController.StopRace();
        }
    }
}
