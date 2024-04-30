using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorController : MonoBehaviour
{
    public PowerUp enginePowerUp;
    private VisitorCarController visitorcarController;

    private bool isBoostOnCooldown = false;
    private float boostCooldownDuration = 6.0f;
    private float lastBoostTime = 0.0f;

    public void Start()
    {
        visitorcarController = FindObjectOfType<VisitorCarController>();
    }

    private void Update()
    {
        if (isBoostOnCooldown && Time.time - lastBoostTime >= boostCooldownDuration)
        {
            isBoostOnCooldown = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected");
        if (other.gameObject.CompareTag("BoostArea"))
        {
            Debug.Log("BoostArea detected");
            // Apply the boost effect
            visitorcarController.Accept(enginePowerUp);

            // Set the boost on cooldown
            isBoostOnCooldown = true;
            lastBoostTime = Time.time;
        }
    }
}
