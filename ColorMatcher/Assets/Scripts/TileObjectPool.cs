using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class TileObjectPool : MonoBehaviour
{
    public int maxPoolSize = 8;
    public int stackDefaultCapacity = 8;

    public GameObject tilePrefab;

    private IObjectPool<TileCube> _pool;

    public IObjectPool<TileCube> Pool
    {
        get
        {
            if (_pool == null)
            {
                _pool = new ObjectPool<TileCube>(
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

    private TileCube CreatePooledItem()
    {
        GameObject go = GameObject.Instantiate(tilePrefab);
        TileCube tileCube = go.AddComponent<TileCube>();
        tileCube.Pool = Pool;

        return tileCube;
    }

    private void OnTakeFromPool(TileCube tileCube)
    {
        tileCube.gameObject.SetActive(true);
    }

    private void OnReturnedToPool(TileCube tileCube)
    {
        tileCube.gameObject.SetActive(false);
    }

    private void OnDestroyPoolObject(TileCube tileCube)
    {
        Destroy(tileCube.gameObject);
    }

    public void SpawnTiles()
    {
        // int amount
        int xPos = -3;
        int zPos = 1;
        for (int i = 0; i < stackDefaultCapacity; i++)
        {
            var tile = Pool.Get();

            tile.name = "Tile" + (i + 1);
            // tile.name = "Tile";
            if (i % 4 == 0 && i > 0)
            {
                zPos -= 2;
                xPos = -3;
            }
            tile.transform.position = new Vector3(xPos, 0, zPos);
            xPos += 2;
        }
    }
}
