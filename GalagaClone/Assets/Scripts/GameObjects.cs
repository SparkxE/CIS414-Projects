using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameObjects 
    {
        
        SpawnStrategy spawnBehaviour;
        public GameObjects():this(new Bullet())
        { 
        
        }
        public GameObjects(SpawnStrategy spawnStrat)
        {
            this.spawnBehaviour = spawnStrat;
        }

        public SpawnStrategy SpawnBehaviour
        {
            set { this.spawnBehaviour = value; }
        }

        public void Spawn(Transform origin)
        {
             spawnBehaviour.Spawn(origin);
        }
    }
}
