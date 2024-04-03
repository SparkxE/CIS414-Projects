using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Obstacle : MonoBehaviour
{
    public IObjectPool<Obstacle> Pool{get; set;}

    public void ReturnToPool(){
        Pool.Release(this);
    }

    
}
