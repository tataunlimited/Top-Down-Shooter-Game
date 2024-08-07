using GameCore.Entity;
using UnityEngine;

namespace GameCore.FSM.States
{
    public class Run : BaseState
    {
        public Run(BaseEntity handler, global::GameCore.FSM.BaseStateMachine baseStateMachine) : base(handler,
            baseStateMachine)
        {
        }

        public override void OnEnter()
        {
        }

        public override void OnExit()
        {
        }

        public override void OnUpdate()
        {
            if (Handler.HealthComponent.IsDead)
            {
                Handler.StateMachine.Death();
                return;
            }
            if (!Actions.IsMoving)
            {
                Handler.StateMachine.Idle();
            }
            else
            {
                Handler.MoveComponent.Move();
            }

            if (Actions.ShouldShoot)
            {
                Handler.AttackComponent.Shoot();
            }

        }
    }
}