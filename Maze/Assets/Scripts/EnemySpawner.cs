using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private EnemyObjectPool pool;
    // Start is called before the first frame update
    void Start()
    {
        pool = gameObject.GetComponent<EnemyObjectPool>();
        pool.SpawnEnemies();
    }
}
