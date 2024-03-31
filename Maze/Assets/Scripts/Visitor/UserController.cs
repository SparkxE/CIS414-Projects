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
    private float playerSpeed = 5.0f;
    public float shootingSpeed = 5.0f;
    public float duration = 6.0f;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;


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

    public float PlayerSpeed
    {
        get { return playerSpeed; }
    }


    private void Awake()
    {
        hudController = gameObject.AddComponent<HUDController>();
        cameraController = FindObjectOfType<CameraController>();
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

    public void TakeDamage(float amountOfDamage)
    {

        userHealth = userHealth - amountOfDamage;

        NotifyObservers();

        if (userHealth < 0)
        {
            Destroy(gameObject);
        }
    }





    public void AcceptVisitor(PlayerVisitor visitor)
    {
        visitor.Visit(this);
    }

    
    public void ApplySpeedBoost(float boostAmount)
    {
        playerSpeed += boostAmount;
    }




    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (bulletPrefab != null && bulletSpawnPoint != null)
            {
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

                // Use transform.forward to get the forward direction of the player
                bulletRb.velocity = transform.forward * shootingSpeed;

                Destroy(bullet, duration);
            }
            else
            {
                Debug.LogError("Bullet prefab or bullet spawn point is not assigned.");
            }
        }
    }







    public void AcceptShootingVisitor(ShootingVisitor visitor)
    {
        visitor.Visit(this);
    }


    public void ApplyShootingSpeedBoost(float boostAmount)
    {
     
        shootingSpeed += boostAmount;
    }

}
