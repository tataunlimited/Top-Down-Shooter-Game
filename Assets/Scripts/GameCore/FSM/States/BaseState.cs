using GameCore.Entity;
using GameCore.Entity.Components;

namespace GameCore.FSM.States
{
    public abstract class BaseState
    {
        protected EntityActions Actions; 
        protected BaseEntity Handler { get; }
        protected BaseStateMachine BaseStateMachine { get; }
        public bool IsInitialized { get; }
        
        protected BaseState(BaseEntity handler, BaseStateMachine baseStateMachine)
        {
            BaseStateMachine = baseStateMachine;
            Handler = handler;
            IsInitialized = true;
            Actions = new EntityActions(handler);
        }


        public abstract void OnEnter();
        public abstract void OnExit();
        public abstract void OnUpdate();
        public virtual void OnClear() { }
        
        protected class EntityActions
        {
            
            private InputComponent _input;
            private BaseEntity _baseEntity;
            
            public EntityActions(BaseEntity baseEntity)
            {
                _baseEntity = baseEntity;
                _input = baseEntity.InputComponent;
            }
            public bool ShouldShoot => _input is not null && _input.ShouldShoot();
            public bool IsMoving => _input is not null && _input.GetMovementDirection().sqrMagnitude > 0;
        }
    }
}




