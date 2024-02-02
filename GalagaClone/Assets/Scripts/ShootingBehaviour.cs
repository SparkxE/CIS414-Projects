using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class ShootingBehaviour 
    {
        IShootable shootbehaviour;

        public ShootingBehaviour():this(new RapidShooting())
        { 
        
        }

        public ShootingBehaviour(IShootable shootbehaviour)
        {
            this.shootbehaviour = shootbehaviour;
        }

        public void SetShootingBehaviour(IShootable value)
        { this.shootbehaviour = value; }

        public void shoot(Transform origin)
        {
             shootbehaviour.Shoot(origin);
        }
    }
}
