using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorController : MonoBehaviour
{
    public PowerUp enginePowerUp;

    private VisitorCarController visitorCarController;


    void Start()
    {
        visitorCarController = gameObject.AddComponent<VisitorCarController>();
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(25, 0, 200, 20));

        if (GUILayout.Button("PowerUp Engine"))
        {
            visitorCarController.Accept(enginePowerUp);
        }

        GUILayout.EndArea();

    }
}
