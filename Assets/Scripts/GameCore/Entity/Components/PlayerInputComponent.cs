using UnityEngine;

namespace GameCore.Entity.Components
{
    public class PlayerInputComponent : InputComponent
    {
        private Vector3 _movement = Vector3.zero;
        private bool _shouldShoot;
        public override void UpdateInput()
        {
            _movement.x = Input.GetAxisRaw("Horizontal");
            _movement.z = Input.GetAxisRaw("Vertical");
            _shouldShoot = Input.GetMouseButtonDown(0);
        }

        public override Vector3 GetMovementDirection()
        {
            return _movement;
        }

        public override bool ShouldShoot()
        {
            return _shouldShoot;
        }
        
    }
}
