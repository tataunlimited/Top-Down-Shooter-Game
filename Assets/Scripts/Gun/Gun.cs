using System;
using UnityEngine;

namespace Gun
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Transform bulletSpawnPoint;
        [SerializeField] private Bullet bulletPrefab;
        public GunData Data { get; set; }

        private float _coolDownRemaining;
        private bool _canShoot;

        private void Update()
        {
            if (_coolDownRemaining <= 0)
                _canShoot = true;
            else
            {
                _canShoot = false;
                _coolDownRemaining -= Time.deltaTime;
            }
        }

        public void Shoot()
        {
            if(!_canShoot)
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
