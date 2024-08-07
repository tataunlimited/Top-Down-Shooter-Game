using UnityEngine;

namespace Entity.Components
{
    public class AttackComponent: MonoBehaviour, IEntityComponent
    {
        public BaseEntity BaseEntity { get; set; }
        
        
        
        public void Shoot()
        {
            Debug.Log("Shooting");
        }
    }
}