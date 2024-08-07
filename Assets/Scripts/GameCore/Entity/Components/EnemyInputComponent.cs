using UnityEngine;

namespace GameCore.Entity.Components
{
    public class EnemyInputComponent : InputComponent
    {
        public bool CanShoot { get; set; }
        public bool CanMove { get; set; }
        public Vector3 TargetPosition { get; set; }
        

        public override void UpdateInput()
        {
            // Do nothing
        }

        public override Vector3 GetMovementDirection()
        {
            return !CanMove ? Vector3.zero : (TargetPosition - transform.position).normalized;
        }

        public override bool ShouldShoot()
        {
            return CanShoot;
        }
    }
}
