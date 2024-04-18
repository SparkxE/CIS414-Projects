using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientDecorator : MonoBehaviour
{
    private CarWeapon carWeapon;
    private bool isWeaponDecorated = false;

    void Start()
    {
        carWeapon = (CarWeapon)FindObjectOfType(typeof(CarWeapon));
    }

    void FixedUpdate(){
        if(isWeaponDecorated == true && Input.GetKey(KeyCode.Space)){
            carWeapon.Reset();
            isWeaponDecorated = false;
            Debug.Log("Weapon Fired");
        }
    }

    private void OnTriggerEnter(Collider other){
        if(isWeaponDecorated == false && other.gameObject.CompareTag("WeaponPickup")){
            carWeapon.Decorate();
            isWeaponDecorated = true;
            Debug.Log("Weapon Picked Up");
        }
    }
}
