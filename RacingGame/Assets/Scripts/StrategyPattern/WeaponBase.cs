using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public int damage = 0; 
    public IDoDamage damageType;
    public new Collider collider;

    public void TryDoDamage(){
        damageType?.DoDamage(damage, collider);
    }
}
