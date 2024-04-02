using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private float speed = 5.0f;
    public float life = 3;
    
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    private void Awake()
    {
        Destroy(gameObject, life);
    }
   // void Update()
    //{
        
      //  transform.Translate(Vector3.forward * speed * Time.deltaTime);
    //}

 
    void OnTriggerEnter(Collider other)
    {
        
        Destroy(gameObject);
    }
}
