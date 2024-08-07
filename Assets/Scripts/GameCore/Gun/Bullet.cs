using System;
using GameCore.Entity;
using UnityEngine;

namespace GameCore.Gun
{
    public class Bullet : MonoBehaviour
    {
        public BulletData Data { get; set; }

        private void Start()
        {
            Destroy(gameObject, Data.Range / Data.Speed);
        }

        private void Update()
        {
            transform.position += transform.forward * (Data.Speed * Time.deltaTime);
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IDamageable>(out var damageable)) 
                damageable.ReceiveDamage(Data.Damage);
            Destroy(gameObject);
            
        }
    }

    [Serializable]
    public class BulletData
    {
        public float Damage;
        public float Speed;
        public float Range;
    }
}
