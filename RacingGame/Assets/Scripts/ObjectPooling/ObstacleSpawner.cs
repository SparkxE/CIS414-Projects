using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private ObstaclePool pool;

    // Start is called before the first frame update
    void Start()
    {
        pool = gameObject.GetComponent<ObstaclePool>();
        pool.SpawnObstacles();
    }
}
