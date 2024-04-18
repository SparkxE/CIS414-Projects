using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashEffectFactory : Factory, IObserver
{
    [SerializeField] private CrashEffect crashPrefab;
    [SerializeField] private Subject playerSubject;

    private void OnEnable() {
        playerSubject.AddObserver(this);
    }

    private void OnDisable() {
        playerSubject.RemoveObserver(this);
    }

    public override IEffect GetEffect(Vector3 position)
    {
        GameObject instance = Instantiate(crashPrefab.gameObject, position, Quaternion.identity);
        CrashEffect newCrash = instance.GetComponent<CrashEffect>();

        newCrash.Initialize();

        instance.name = newCrash.EffectName;
        Debug.Log(instance.name + " is being created");
        return newCrash;
    }

    public void OnNotify(){
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GetEffect(player.transform.position);
    }



}
