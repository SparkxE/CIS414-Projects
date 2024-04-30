using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : WeaponBase
{
    public Missile(){
        damage = 20;
        damageType = new Breaker();
    }

    private void OnTriggerEnter(Collider other) {
        damageType.DoDamage(damage, other);
        Destroy(gameObject);
    }
}
