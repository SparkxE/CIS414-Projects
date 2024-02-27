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
    private float shootingSpeed = 1.0f;
    public GameObject projectilePrefab;

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
        
        if (CanShoot())
        {
        
            GameObject projectilePrefab = Resources.Load<GameObject>("ProjectilePrefab"); 
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

           
            ProjectileController projectileController = projectile.GetComponent<ProjectileController>();
            if (projectileController != null)
            {
                projectileController.SetSpeed(shootingSpeed);
            }

            Debug.Log("Player is shooting at speed: " + shootingSpeed);
        }
        else
        {
            Debug.Log("Cannot shoot right now. Cooldown active or other condition not met.");
        }
    }

   
    private bool CanShoot()
    {
       
        return true;
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
