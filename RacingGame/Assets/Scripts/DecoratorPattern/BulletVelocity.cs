using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletVelocity : Missile
{
    public float speed = 13f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * speed;
    }

    void Update(){
        rb.AddForce(transform.up * speed);
    }
}
