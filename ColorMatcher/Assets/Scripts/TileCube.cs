using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class TileCube : MonoBehaviour
{
    public IObjectPool<TileCube> Pool{get; set; }

    public void ReturnToPool(){
        Pool.Release(this);
    }
}
