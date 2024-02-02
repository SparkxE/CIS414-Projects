﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class RapidShooting : IShootable
    {
        public float moveSpeed= 5f;
        public GameObject bulletObject;

    
        public void Shoot(Transform origin)
        {
            bulletObject.transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);
        }
    }
}
