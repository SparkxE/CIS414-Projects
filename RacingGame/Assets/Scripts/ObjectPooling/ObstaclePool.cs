using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObstaclePool : MonoBehaviour
{
    [SerializeField] private int maxPoolSize = 10;
    [SerializeField] private int stackDefaultCapacity = 10;
    [SerializeField] private GameObject[] obstaclePrefabs;

    private IObjectPool<Obstacle> _pool;
    public IObjectPool<Obstacle> Pool{
        get
        {
            if (_pool == null)
            {
                _pool = new ObjectPool<Obstacle>(
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

    private Obstacle CreatePooledItem()
    {
        GameObject go = GameObject.Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length-1)]);
        Obstacle obstacle = go.AddComponent<Obstacle>();
        obstacle.Pool = Pool;

        return obstacle;
    }

    private void OnTakeFromPool(Obstacle obstacle)
    {
        obstacle.gameObject.SetActive(true);
    }

    private void OnReturnedToPool(Obstacle obstacle)
    {
        obstacle.gameObject.SetActive(false);
    }

    private void OnDestroyPoolObject(Obstacle obstacle)
    {
        Destroy(obstacle.gameObject);
    }
}
