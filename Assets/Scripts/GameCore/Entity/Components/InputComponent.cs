using UnityEngine;

namespace GameCore.Entity.Components
{
    public abstract class InputComponent : MonoBehaviour, IEntityComponent
    {
        public BaseEntity BaseEntity { get; set; }
        public abstract void UpdateInput();
        public abstract Vector3 GetMovementDirection();
        public abstract bool ShouldShoot();
    }
}