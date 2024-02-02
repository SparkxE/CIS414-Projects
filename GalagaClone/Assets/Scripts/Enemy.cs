using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Enemy : SpawnStrategy
    {
        public GameObject enemyPrefab;
        public Enemy() { }
        public void Spawn(Transform origin)
        {
            
            Instantiate(enemyPrefab, origin.position, origin.rotation);
        }

     
     
        private void Instantiate(GameObject enemyPrefab, Vector3 position, Quaternion rotation)
        {
           
        }
    }
}
