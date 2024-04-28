using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointReached : Subject
{
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered!");

        if (other.CompareTag("Player"))
        {
            Debug.Log("End point reached!");


          NotifyObservers();

            Debug.Log("You have reached the end of the current level ");
        }
    }
}
