using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Observer
{

    private bool isWarpOn = false;
    private Vector3 initialPosition;
    private float shakeMagnitude = 0.1f;
    private ObserverCarController observerCarController;


    private void OnEnable()
    {
        initialPosition = gameObject.transform.localPosition;

    }

    private void Update()
    {

        if (isWarpOn == true)
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
        if (!observerCarController)
        {
            observerCarController = gameObject.GetComponent<ObserverCarController>();
        }


        if (observerCarController)
        {
            isWarpOn = observerCarController.IsWarpOn;
        }

    }
}
