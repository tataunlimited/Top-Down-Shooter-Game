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
            if(Handler.HealthComponent.IsDead)
                Handler.StateMachine.Death();
            else if (Actions.IsMoving)
            {
                Handler.StateMachine.Run();
                Debug.Log("IsMoving");
            }
            Debug.Log("IDLE UPDATE");

        }
    }
}