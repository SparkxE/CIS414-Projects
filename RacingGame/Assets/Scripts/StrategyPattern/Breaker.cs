using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaker : IDoDamage
{
    public void DoDamage(int damage, Collider other){
        if(other.gameObject.tag == "Obstacle"){
            GameObject.Destroy(other.gameObject);
        }
        else{
            other.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
