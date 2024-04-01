using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController : Subject
{
    private float userHealth = 100;
    private bool isWalking = false;
    private HUDController hudController;
    private CameraController cameraController;
    private bool isHit = false;

    public float UserHealth
    {
        get { return userHealth; } 
    }
    public bool IsWalking
    {
        get { return isWalking; }
    }

    public bool IsHit
    {
        get { return isHit; }
        set { isHit = value; }

    }

    private void Awake()
    {
        hudController = gameObject.AddComponent<HUDController>();
        cameraController = FindObjectOfType<CameraController>();

        // gameObject.AddComponent<CameraController>;//we might have to find the camera and then find it 
    }

    private void Start()
    {
        StartWalking();
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

    private void StartWalking()
    {
        isWalking = true;
        NotifyObservers();
    }



    public void TakeDamage(float amoutOfDamage)
    {
        userHealth = userHealth - amoutOfDamage;

        NotifyObservers();

        if (userHealth < 0)
        {
            Destroy(gameObject);
        }
    }
}
