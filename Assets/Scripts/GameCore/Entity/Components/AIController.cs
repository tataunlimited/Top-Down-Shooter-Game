using UnityEngine;

namespace GameCore.Entity.Components
{
    public class AIController : MonoBehaviour, IEntityComponent
    {
        [SerializeField] private float attackRange = 5;
        [SerializeField] private float stopDistance = 3;
        public BaseEntity BaseEntity { get; set; }
        private PlayerEntity _target;
        private EnemyInputComponent _inputComponent;
        
        private void Start()
        {
            _inputComponent = (EnemyInputComponent)BaseEntity.InputComponent;
            FindTarget();
        }
        
        
        private void Update()
        {
            if (_target== null)
            {
                return;
            }
            if (BaseEntity.HealthComponent.IsDead) return;
            
            _inputComponent.TargetPosition = _target.transform.position;
            if(TargetInAttackRange())
                _inputComponent.CanShoot = true;
            _inputComponent.CanMove = !TargetInStopDistance();
                
        }

        private bool TargetInAttackRange()
        {
            return Vector3.Distance(BaseEntity.transform.position, _target.transform.position) <= attackRange;
        }
        private bool TargetInStopDistance()
        {
            return Vector3.Distance(BaseEntity.transform.position, _target.transform.position) <= stopDistance;
        }

        private void FindTarget()
        {
            _target = FindObjectOfType<PlayerEntity>();
        }
    }
}
