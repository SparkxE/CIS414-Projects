using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Observer
{

    private bool isWarpOn = false;
    private Vector3 initialPosition;
    private float shakeMagnitude = 0.1f;
    private PlayerController playerController;


    private void OnEnable()
    {
        initialPosition = gameObject.transform.localPosition;

    }

    private void Update()
    {

        if (!isWarpOn)
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
        if (!playerController)
        {
            playerController = playerController.GetComponent<PlayerController>();
        }


        if (playerController)
        {
            isWarpOn = playerController.IsWarpOn;
        }

    }
}
