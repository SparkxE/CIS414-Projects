using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverCarController : Subject
{
    private float carHealth = 100.0f;
    private HUDController hudController;
    private CameraController cameraController;
    private bool isEngineOn = false;

    public bool IsWarpOn
    {
        get; private set;
    }

    public float CarHealth
    {
        get; private set;
    }


    private void Awake()
    {    // we may have to change it later 
        hudController = gameObject.AddComponent<HUDController>();
        cameraController = FindObjectOfType<CameraController>();

        // gameObject.AddComponent<CameraController>;//we might have to find the camera and then find it 
    }

    private void Start()
    {
        StartEngine();
    }


    private void OnEnable()
    {
        if (hudController)
        {

            Attach(hudController);
        }

        if (cameraController)
        {

            Attach(cameraController);
        }


    }


    private void OnDisable()
    {
        if (hudController)
        {

            Detach(hudController);
        }

        if (cameraController)
        {

            Detach(cameraController);
        }


    }


    private void StartEngine()
    {
        isEngineOn = true;
        NotifyObservers();
    }

    public void ToggleWarpSpeed()
    {
        if (isEngineOn)
        {

            IsWarpOn = !IsWarpOn;
        }
        NotifyObservers();
    }

    public void TakeDamage(float amoutOfDamage)
    {
        carHealth = carHealth - amoutOfDamage;
        IsWarpOn = false;
        NotifyObservers();

        if (carHealth < 0)
        {
            Destroy(gameObject);
        }
    }

  


}
