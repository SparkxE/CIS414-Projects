using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDoDamage
{
    void DoDamage(int damage, Collision collider);
}
