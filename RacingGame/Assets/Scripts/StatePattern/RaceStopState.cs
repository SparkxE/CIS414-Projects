using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceStopState : MonoBehaviour, IRaceState
{
    private RaceController raceController;

    public void Handle(RaceController controller){
        if(!raceController){
            this.raceController = controller;
        }

        //commands for stopping the race go here
    }
}
