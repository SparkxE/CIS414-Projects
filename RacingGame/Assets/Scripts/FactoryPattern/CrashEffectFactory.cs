using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashEffectFactory : Factory
{
    [SerializeField] private CrashEffect crashPrefab;

    public override IEffect GetEffect(Vector3 position)
    {
        GameObject instance = Instantiate(crashPrefab.gameObject, position, Quaternion.identity);
        CrashEffect newCrash = instance.GetComponent<CrashEffect>();

        newCrash.Initialize();

        instance.name = newCrash.EffectName;
        Debug.Log(instance.name + " is being created");
        return newCrash;
    }
}
