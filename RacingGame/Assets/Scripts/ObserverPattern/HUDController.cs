using PolyStang;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class HUDController : Observer
{
    private bool isWarpOn = false;
    private float carHealth;
    private PlayerController playerController;

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(50, 50, 100, 200));

        GUILayout.BeginHorizontal("Box");
        GUILayout.Label("car Health: " + carHealth);
        GUILayout.EndHorizontal();


        if (isWarpOn)
        {


            GUILayout.BeginHorizontal("Box");
            GUILayout.Label("Wrap speed activated ");
            GUILayout.EndHorizontal();
        }

        if (carHealth < 20)
        {
            GUILayout.BeginHorizontal("Box");
            GUILayout.Label("Warning shields failing ");
            GUILayout.EndHorizontal();
        }
        if (carHealth < 10)
        {
            GUILayout.BeginHorizontal("Box");
            GUILayout.Label("EJECT EJECT EJECT ");
            GUILayout.EndHorizontal();
        }
    }


    public override void Notify(Subject aSubject)
    {
        if (!playerController)
        {
            playerController = aSubject.GetComponent<PlayerController>();
        }

        if (playerController != null)
        {
            isWarpOn = playerController.IsWarpOn;

            carHealth = playerController.CarHealth;
        }
    }
}
