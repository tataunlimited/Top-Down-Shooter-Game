using UnityEngine;

namespace GameCore.Entity.Components
{
    public class MovementComponent: MonoBehaviour, IEntityComponent
    {
        public BaseEntity BaseEntity { get; set; }
        
        public Vector3 Direction { get; set; }
        
        public void Move()
        {
            Direction = BaseEntity.InputComponent.GetMovementDirection();
            if (!(Direction.magnitude > 0)) return;
            BaseEntity.transform.position += Direction * (BaseEntity.Data.Speed * Time.deltaTime);
            BaseEntity.transform.rotation = Quaternion.LookRotation(Direction);

        }
    }
}