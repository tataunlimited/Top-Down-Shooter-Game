using GameCore.Entity;
using UnityEngine;

namespace GameCore.FSM.States
{
    public class Idle : BaseState
    {
        public Idle(BaseEntity handler, BaseStateMachine baseStateMachine) : base(handler, baseStateMachine)
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
            if (Actions.IsMoving)
            {
                Handler.StateMachine.Run();
            }

            if (Actions.ShouldShoot)
            {
                Handler.AttackComponent.Shoot();
            }

        }
    }
}