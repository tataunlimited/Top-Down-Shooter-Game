using System;
using Services.UI.EntityBars;
using UnityEngine;

namespace GameCore.Entity.Components
{
    public class HealthComponent: MonoBehaviour, IEntityComponent
    {
        [SerializeField] private EntityInfoUI entityInfoUI;
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
            entityInfoUI.Init(BaseEntity.Data.Name);

        }
        
        public void ChangeHealth(float damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                Health = 0;
                Die();
            }
            entityInfoUI.UpdateHealth(HealthPercentage);
            OnHealthChanged?.Invoke(this);

        }
        
        private void Die()
        {
            IsDead = true;
            OnDeath?.Invoke();
        }
    }
}