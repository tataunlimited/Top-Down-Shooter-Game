using System;
using UnityEngine;

namespace GameCore.Gun
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Transform bulletSpawnPoint;
        [SerializeField] private Bullet bulletPrefab;
        public bool CanShoot { get; private set; }

        public GunData Data { get; set; }

        private float _coolDownRemaining;

        private void Update()
        {
            if (_coolDownRemaining <= 0)
                CanShoot = true;
            else
            {
                CanShoot = false;
                _coolDownRemaining -= Time.deltaTime;
            }
        }

        public void Shoot()
        {
            if(!CanShoot)
                return;
            _coolDownRemaining = Data.FireRate;
            SpawnBullet();
        }

        private void SpawnBullet()
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.Data = Data.BulletData;
        }
    }

    [Serializable]
    public class GunData
    {
        public BulletData BulletData;
        public float FireRate;
    }
}
