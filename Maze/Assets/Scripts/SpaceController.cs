using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceController : MonoBehaviour
{
    private UserController userController;
    void Start()
    {
        userController = FindObjectOfType<UserController>();
    }

    void OnGUI()
    {
        if (GUILayout.Button("Take Damage"))
        {
            if (userController)
            {
                userController.TakeDamage(11);
            }
        }

        
    }
}
