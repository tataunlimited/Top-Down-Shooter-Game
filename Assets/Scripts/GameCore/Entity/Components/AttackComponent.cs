using UnityEngine;

namespace GameCore.Entity.Components
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