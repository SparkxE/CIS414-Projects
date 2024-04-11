using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceStartState : MonoBehaviour, IRaceState
{
    private RaceController raceController;
    public void Handle(RaceController controller){
        if(!raceController){
            this.raceController = controller;
        }

        //insert code for starting the race here
    }

    // Update is called once per frame
    void Update()
    {
        //insert time keeping here? 
        //anything that would use the Update function for managing the race
    }
}
