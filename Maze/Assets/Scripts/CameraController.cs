using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Observer
{
    private bool isHit = false;
    private Vector3 initialPosition;
    private float shakeMagnitude = 0.1f;
    private UserController userController;


    private void OnEnable()
    {
        initialPosition = gameObject.transform.localPosition;
        
    }

    private void Update()
    {

        if (isHit)
        {
            gameObject.transform.localPosition = initialPosition + (Random.insideUnitSphere * shakeMagnitude);
        }
        else
        {
            gameObject.transform.localPosition = initialPosition;
        }

    }

    public override void Notify(Subject aSubject)
    {
        if (!userController)
        {
            userController = GetComponent<UserController>();
        }

        if (userController)
        {
            isHit = userController.IsHit;

          
            if (isHit)
            {
                userController.TakeDamage(10); 
            }
        }
    }
}


