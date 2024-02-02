using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Bullet : MonoBehaviour, SpawnStrategy
    {
        public GameObject bulletPrefab;
        public float slowSpeed = 3f;
        public float fastSpeed = 6f;

        public Bullet() { }
        public void RapidShoot( Transform origin)
        {
            bulletPrefab.transform.Translate(Vector2.up * Time.deltaTime * fastSpeed);
        }
        public void SlowShoot(Transform origin)
        {
            bulletPrefab.transform.Translate(Vector2.up * Time.deltaTime * slowSpeed);
        }
       // void Update()
       // {
          //  transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);
       // }

        public void Spawn(Transform origin)
        {
        
            UnityEngine.Object.Instantiate(bulletPrefab, origin.position, origin.rotation);
        }

       
       
    }
}
