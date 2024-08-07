using System;
using UnityEngine;

namespace Entity.Components
{
    public class HealthComponent: MonoBehaviour, IEntityComponent
    {
        public BaseEntity BaseEntity { get; set; }
        public float Health { get; private set; }
        public float MaxHealth { get; private set; }
        public bool IsDead { get; private set; }

        public float HealthPercentage => Health / MaxHealth;


        public event Action OnDeath;
        public event Action<HealthComponent> OnHealthChanged;

        public void Start()
        {
            MaxHealth = Health = BaseEntity.Data.Health;
            OnHealthChanged?.Invoke(this);
        }
        
        public void ChangeHealth(float damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                Health = 0;
                Die();
            }
            OnHealthChanged?.Invoke(this);

        }
        
        private void Die()
        {
            IsDead = true;
            OnDeath?.Invoke();
        }
    }
}