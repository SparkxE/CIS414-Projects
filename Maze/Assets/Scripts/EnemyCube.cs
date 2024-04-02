using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyCube : MonoBehaviour
{
    public IObjectPool<EnemyCube> Pool{get; set; }

    public void ReturnToPool(){
        Pool.Release(this);
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            ReturnToPool();
        }
    }
}
