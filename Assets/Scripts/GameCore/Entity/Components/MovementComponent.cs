using System;
using UnityEngine;

namespace GameCore.Entity.Components
{
    public class MovementComponent: MonoBehaviour, IEntityComponent
    {
        [SerializeField] private LayerMask obstacleLayer;
        public BaseEntity BaseEntity { get; set; }
        private Vector3 Direction { get; set; }
        
        public void Move()
        {
            Direction = BaseEntity.InputComponent.GetMovementDirection();
            if (!CanMoveForward()) return;
            BaseEntity.transform.position += Direction * (BaseEntity.Data.Speed * Time.deltaTime);
            BaseEntity.transform.rotation = Quaternion.LookRotation(Direction);

        }

        private bool CanMoveForward()
        {
            if (Direction.magnitude <= 0)
                return false;
            var ray = new Ray(transform.position, Direction);
            return !Physics.Raycast(ray, 1,obstacleLayer);
        }

    }
}