using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyObjectPool : MonoBehaviour
{
    public int maxPoolSize = 10;
    public int stackDefaultCapacity = 10;

    public GameObject enemyPrefab;
    private IObjectPool<EnemyCube> _pool;
    public IObjectPool<EnemyCube> Pool{
        get{
            if(_pool == null){
                _pool = new ObjectPool<EnemyCube>(
                    CreatePooledItem,
                    OnTakeFromPool,
                    OnReturnedToPool,
                    OnDestroyPoolObject,
                    true,
                    stackDefaultCapacity,
                    maxPoolSize
                );
            }
            return _pool;
        }
    }

    private EnemyCube CreatePooledItem(){
        GameObject go = GameObject.Instantiate(enemyPrefab);
        EnemyCube enemyCube = go.AddComponent<EnemyCube>();
        enemyCube.Pool = Pool;

        return enemyCube;
    }

    private void OnTakeFromPool(EnemyCube enemyCube){
        enemyCube.gameObject.SetActive(true);
    }

    private void OnReturnedToPool(EnemyCube enemyCube){
        enemyCube.gameObject.SetActive(false);
    }

    private void OnDestroyPoolObject(EnemyCube enemyCube){
        Destroy(enemyCube.gameObject);
    }

    public void SpawnEnemies(){
        // int amount
        int xPos = -3;
        int zPos = 1;
        for (int i = 0; i < stackDefaultCapacity; i++)
        {
            var enemy = Pool.Get();

            enemy.name = "enemy" + (i + 1);
            // enemy.name = "enemy";
            if (i % 4 == 0 && i > 0)
            {
                zPos -= 2;
                xPos = -3;
            }
            enemy.transform.position = new Vector3(xPos, 0, zPos);
            xPos += 2;
        }
    }
}
