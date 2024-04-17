using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceStartState : MonoBehaviour, IRaceState
{
    private RaceController raceController;
    private PlayerController playerController;

    public void Handle(RaceController controller){
        if(!raceController){
            this.raceController = controller;
        }

        playerController = FindObjectOfType<PlayerController>();
        playerController.enabled = true;

        //other commands for starting race go here (if any)
    }

    // // Update is called once per frame
    // void Update()
    // {
    //     //insert time keeping here? 
    //     //anything that would use the Update function for managing the race
    // }
}