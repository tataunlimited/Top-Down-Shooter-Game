using Entity;

namespace FSM.States
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
        }
    }
}