using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    private TileObjectPool pool;

    // Start is called before the first frame update
    void Start()
    {
        pool = gameObject.GetComponent<TileObjectPool>();
        pool.SpawnTiles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
