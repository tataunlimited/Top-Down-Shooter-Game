using System;
using GameCore.Gun;
using UnityEngine;

namespace GameCore.Entity.Components
{
    public class AttackComponent: MonoBehaviour, IEntityComponent
    {
        [SerializeField] private Transform gunParent;
        public BaseEntity BaseEntity { get; set; }
        private BaseGun _selectedGun;

        private void Start()
        {
           SpawnGun();
        }

        private void SpawnGun()
        {
            if(_selectedGun != null)
                Destroy(_selectedGun.gameObject);
            _selectedGun = Instantiate(BaseEntity.Data.Gun, gunParent);
        }

        public bool CanShoot()
        {
            return _selectedGun!= null && _selectedGun.CanShoot;
        }
        
        public void Shoot()
        {
            _selectedGun.Shoot();
        }
    }
}