using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Factory : MonoBehaviour
{
    public abstract IEffect GetEffect(Vector3 position);

    public string GetLog(IEffect effect){
        string message = "Factory: played effect " + effect.EffectName;
        return message;
    }
}
