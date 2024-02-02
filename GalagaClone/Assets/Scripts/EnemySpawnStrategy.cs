using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnStrategy : MonoBehaviour
{
    [SerializeField] private int spawnRate = 100;
    [SerializeField] private int maxEnemyCount = 10;
    [SerializeField] private GameObject enemyPrefab;
    private int currentEnemyCount = 0;
    private int randomSpawn;


    // Update is called once per frame
    void FixedUpdate()
    {
        randomSpawn = Random.Range(0, spawnRate + 1);
        if(maxEnemyCount > currentEnemyCount && randomSpawn == spawnRate){
            SpawnEnemy();
            currentEnemyCount++;
        }
        int randomX = Random.Range(0,2);
        if(randomX == 0){
            transform.position = new Vector3(Random.Range(-10f, 0), 0, Random.Range(5f, 10f));
        }
        else{
            transform.position = new Vector3(Random.Range(0, 10f), 0, Random.Range(5f, 10f));
        }
    }

    private void SpawnEnemy(){
        Instantiate(enemyPrefab, gameObject.transform.position, gameObject.transform.rotation);
    }
}
