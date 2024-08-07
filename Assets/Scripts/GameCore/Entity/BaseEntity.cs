using System;
using Data;
using GameCore.Entity.Components;
using GameCore.FSM;
using Services;
using UnityEngine;

namespace GameCore.Entity
{
    
    public class BaseEntity : MonoBehaviour, IDamageable
    {
        [SerializeField] private EntityData data;
        public EntityData Data => data;
        public InputComponent InputComponent => _inputComponent;
        public BaseStateMachine StateMachine => _stateMachine;
        public HealthComponent HealthComponent => _healthComponent;
        public MovementComponent MoveComponent => _movementComponent;
        public AttackComponent AttackComponent => _attackComponent;

        private HealthComponent _healthComponent;
        private AttackComponent _attackComponent;
        private MovementComponent _movementComponent;
        private InputComponent _inputComponent;
        private BaseStateMachine _stateMachine;
        private GameManager _gameManager;

        private void Awake()
        {
            Initialize(); 
            _gameManager = GameManager.Instance;
            AddListeners();
        }

        private void OnDestroy()
        {
            RemoveListeners();
        }

        private void AddListeners()
        {
            _healthComponent.OnDeath += OnDeath;
        }

        private void OnDeath()
        { 
            _gameManager.GameOver(this is EnemyEntity);
        }

        private void RemoveListeners()
        {
            _healthComponent.OnDeath -= OnDeath;
        }
        
        private void Update()
        {
            _inputComponent.UpdateInput();
            _stateMachine.UpdateState();
        }

        private void Initialize()
        {
            CacheComponents();
            _stateMachine.Initialize(this);
            _stateMachine.Idle();
        }

        protected virtual void CacheComponents()
        {
            CacheComponent(ref _healthComponent);
            CacheComponent(ref _attackComponent);
            CacheComponent(ref _movementComponent);
            CacheComponent(ref _inputComponent);
            CacheComponent(ref _stateMachine);
        }

        protected void CacheComponent<T>(ref T component)
        {
            component = GetComponent<T>() ?? GetComponentInChildren<T>();
            if (component is IEntityComponent entityComponent)
            {
                entityComponent.BaseEntity = this;
            }
        }

        public void ReceiveDamage(float damage)
        {
            _healthComponent.ChangeHealth(damage);
        }

        public void Shoot()
        {
            _attackComponent.Shoot();
        }
    }
}