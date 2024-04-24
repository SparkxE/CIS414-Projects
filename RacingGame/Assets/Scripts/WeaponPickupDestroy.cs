using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickupDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        Destroy(gameObject);
    }
}
