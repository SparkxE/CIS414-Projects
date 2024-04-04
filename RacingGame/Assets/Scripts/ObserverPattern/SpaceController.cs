using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceController : MonoBehaviour
{
    private ObserverCarController observerCarController;
    void Start()
    {
        observerCarController = FindObjectOfType<ObserverCarController>();
    }

    void OnGUI()
    {

        GUILayout.BeginArea(new Rect(25, 25, 200, 20));
        if (GUILayout.Button("ToggleWarp Engines"))
        {
            if (observerCarController)
            {
                observerCarController.ToggleWarpSpeed();
            }
        }


        GUILayout.EndArea();
    }
}
