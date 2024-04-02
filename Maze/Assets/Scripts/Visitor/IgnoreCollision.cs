using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{

    public GameObject player;

    void Start()
    {
        // Ignore collision between the bullet and the player
        if (player != null)
        {
            Collider bulletCollider = GetComponent<Collider>();
            Collider playerCollider = player.GetComponent<Collider>();

            if (bulletCollider != null && playerCollider != null)
            {
                Physics.IgnoreCollision(bulletCollider, playerCollider);
            }
            else
            {
                Debug.LogWarning("Bullet collider or player collider is missing.");
            }
        }
        else
        {
            Debug.LogWarning("Player reference is not set in IgnoreCollision script.");
        }
    }
}
