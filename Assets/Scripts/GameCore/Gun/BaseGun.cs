using System;
using Data;
using UnityEngine;

namespace GameCore.Gun
{
    public class BaseGun : MonoBehaviour
    {
        [SerializeField] private Transform bulletSpawnPoint;
        [SerializeField] private GunData data;
        public bool CanShoot { get; private set; }
        
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
            _coolDownRemaining = data.FireRate;
            SpawnBullet();
        }

        private void SpawnBullet()
        {
            var bullet = Instantiate(data.BulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.Data = data.BulletData;
        }
    }
    
}
