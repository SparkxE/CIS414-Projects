using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : Observer
{
    private bool isHit;
    private float userHealth;
    private UserController userController;

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(50, 200, 100, 200));

        GUILayout.BeginHorizontal("Box");
        GUILayout.Label("User Health: " + userHealth);
        GUILayout.EndHorizontal();


        if(userHealth < 20)
        {
            GUILayout.BeginHorizontal("Box");
            GUILayout.Label("You have poor health ");
            GUILayout.EndHorizontal();
        }
        if(userHealth < 10)
        {
            GUILayout.BeginHorizontal("Box");
            GUILayout.Label(" You have no health");
            GUILayout.EndHorizontal();
        }
        GUILayout.EndArea();
    }


    public override void Notify(Subject aSubject)
    {
        if (!userController)
        {
            userController = aSubject.GetComponent<UserController>();
        }

        if (userController != null)
        {

            isHit = userController.IsHit;
            userHealth = userController.UserHealth;
        }
    }

}
