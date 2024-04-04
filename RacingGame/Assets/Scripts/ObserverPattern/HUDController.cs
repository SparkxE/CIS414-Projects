using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : Observer
{
    private bool isWarpOn = false;
    private float carHealth;
    private ObserverCarController observerCarController;

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(25, 50, 200, 20)); 

        GUILayout.BeginHorizontal("Box");
        GUILayout.Label("Car Health: " + observerCarController.CarHealth);
        GUILayout.EndHorizontal();


        if (isWarpOn)
        {


            GUILayout.BeginHorizontal("Box");
            GUILayout.Label("Wrap speed activated ");
            GUILayout.EndHorizontal();
        }

     

        GUILayout.EndArea();
    }


    public override void Notify(Subject aSubject)
    {
        if (!observerCarController)
        {
            observerCarController = aSubject.GetComponent<ObserverCarController>();
        }

        if (observerCarController != null)
        {
            isWarpOn = observerCarController.IsWarpOn;

            carHealth = observerCarController.CarHealth;
        }
    }
}
