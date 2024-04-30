using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceClient : Subject
{
    private RaceController raceController;
    private bool raceStarted = false;
   

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<RaceController>();
        this.raceController = (RaceController)FindObjectOfType(typeof(RaceController));
    }

    void Update(){
        if(Input.GetKey(KeyCode.Tab) && raceStarted == false){
            raceController.StartRace();
            raceStarted = true;
            Debug.Log("oof");
            NotifyObservers();
        }
    }
}
