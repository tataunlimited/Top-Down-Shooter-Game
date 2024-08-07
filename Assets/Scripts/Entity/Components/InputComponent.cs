using UnityEngine;

namespace Entity.Components
{
    public abstract class InputComponent : MonoBehaviour, IEntityComponent
    {
        public BaseEntity BaseEntity { get; set; }
        public abstract void ProcessInput();
        public abstract Vector3 GetMovementDirection();
        public abstract bool ShouldShoot();
    }
}