using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : Subject, IObserver
{
    
    public float health=100f;
    [SerializeField] private Subject playerController;
    [SerializeField] private GameObject car;
    [SerializeField] Image healthBarFill;

    private void OnEnable()
    {
        playerController.AddObserver(this);
    
    }

    private void OnDisable()
    {
        playerController.RemoveObserver(this);
    }
    private void UpdateHealthBar()
    {
        healthBarFill.fillAmount = health / 50;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("your health is " + health);
        UpdateHealthBar(); 
    }
    public void OnNotify() {
        TakeDamage(10);
       
        if (health > 0)
        {
            Debug.Log("Keep playing");
        }
        else
        {

            Vector3 carGround = gameObject.transform.position - new Vector3(0, 0.25f, 0);
            if(car.GetComponent<Rigidbody>() == null){
                car.AddComponent<Rigidbody>();
            }
            Rigidbody carBody = car.GetComponent<Rigidbody>();
            carBody.AddExplosionForce(10, carGround, 2);
            NotifyObservers();
        }
    }
   
}
