using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject bulletPrefab;
    public float moveSpeed = 5f;
    public float duration = 2.0f;

    void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal");

      
        transform.Translate(Vector2.right * hInput * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Fire1"))
        {

            GameObject bullet =Instantiate(bulletPrefab, transform.position, Quaternion.identity);

          
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

            bulletRb.velocity = transform.forward * moveSpeed;

            Destroy(bullet, duration);
        }
    }
}
