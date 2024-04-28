using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceEndState : MonoBehaviour, IRaceState
{
    private RaceController raceController;
    private PlayerController playerController;

    public void Handle(RaceController controller)
    {
        if (!raceController)
        {
            this.raceController = controller;
        }

        playerController = FindObjectOfType<PlayerController>();
        playerController.enabled = false;
       
    }
}