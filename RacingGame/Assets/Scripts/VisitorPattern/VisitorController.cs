using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorController : MonoBehaviour
{
    public PowerUp enginePowerUp;
    public VisitorCarController visitorcarController;

    private bool isBoostOnCooldown = false;
    private float boostCooldownDuration = 6.0f;
    private float lastBoostTime = 0.0f;

    public void Start()
    {
        visitorcarController = FindAnyObjectByType<VisitorCarController>();
    }

    private void Update()
    {
       
        if (isBoostOnCooldown && Time.time - lastBoostTime >= boostCooldownDuration)
        {
            isBoostOnCooldown = false;
        }
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(25, 0, 200, 20));

      
        if (!isBoostOnCooldown && GUILayout.Button("PowerUp Engine"))
        {
    
            visitorcarController.Accept(enginePowerUp);

            isBoostOnCooldown = true;
            lastBoostTime = Time.time;
        }

        GUILayout.EndArea();
    }
}
