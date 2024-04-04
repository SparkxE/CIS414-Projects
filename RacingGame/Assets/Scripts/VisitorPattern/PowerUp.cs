using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUp")]
public class PowerUp : ScriptableObject,IVisitor
{

    public string powerupName;
    public string powerUpDescription;
    public GameObject powerUpPrefab;
 

    [Tooltip("Increese Engine Speed")]
    [Range(0.0f, 10.0f)]
    public float boostEngine;


    public void Visit(CarEngine carEngine)
    {
        float aboost = carEngine.boost += boostEngine;
    }
}
