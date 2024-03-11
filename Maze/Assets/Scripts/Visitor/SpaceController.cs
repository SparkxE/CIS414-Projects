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
    private void Update()
    {
        userController.Shoot();
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
        if (GUILayout.Button("Apply Speed Boost"))
        {
            if (userController)
            {
               
                SpeedBoostVisitor speedBoostVisitor = new SpeedBoostVisitor(2.0f); 
                userController.AcceptVisitor(speedBoostVisitor);
            }
        }

     

        if (GUILayout.Button("Apply Shooting Speed Boost"))
        {
            if (userController)
            {
                ShootingSpeedBoostVisitor shootingSpeedBoostVisitor = new ShootingSpeedBoostVisitor(2.0f); 
                userController.AcceptShootingVisitor(shootingSpeedBoostVisitor);
            }
        }


    }
}
