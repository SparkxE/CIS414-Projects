using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnStrategy : MonoBehaviour
{
    SpawnStrategy spawner;  // SpawnStrategy instance to get method for spawning enemy objects
    [SerializeField] private int spawnRate = 1;
    [SerializeField] private int maxEnemyCount = 10;
    private int currentEnemyCount = 0;
    private int randomSpawn;


    // Update is called once per frame
    void Update()
    {
        randomSpawn = Random.Range(0, spawnRate + 1);
        if(maxEnemyCount > currentEnemyCount && randomSpawn == spawnRate){
            SpawnEnemy();
            currentEnemyCount++;
        }
        int randomX = Random.Range(0,2);
        if(randomX == 0){
            transform.position = new Vector3(Random.Range(-10f, 0), 0, Random.Range(4, 7));
        }
        else{
            transform.position = new Vector2(Random.Range(0, 10f), Random.Range(4, 7));
        }
    }

    private void SpawnEnemy(){
        spawner.Spawn(gameObject.transform);
    }
}
