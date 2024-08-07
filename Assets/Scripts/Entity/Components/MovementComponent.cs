using UnityEngine;

namespace Entity.Components
{
    public class MovementComponent: IEntityComponent
    {
        public BaseEntity BaseEntity { get; set; }
        
        public Vector3 Direction { get; set; }
        
        public void Move()
        {
            BaseEntity.transform.position += BaseEntity.transform.forward * (BaseEntity.Data.Speed * Time.deltaTime);
            BaseEntity.transform.rotation = Quaternion.LookRotation(BaseEntity.transform.forward);
        }
    }
}