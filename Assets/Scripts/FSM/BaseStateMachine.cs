using System;
using System.Collections.Generic;
using Entity;
using FSM.States;
using UnityEngine;

namespace FSM
{
    public class BaseStateMachine : MonoBehaviour
    {
        private readonly Dictionary<EnumState, BaseState> _register = new();
        private EnumState _currentStateEnum = EnumState.None;
        private Idle IdleState { get; set; }
        private Attack AttackState { get; set; }
        private Run RunState { get; set; }
        private Death DeathState { get; set; }
        public bool IsInitialized { get; private set; }
        private BaseState Current => (_currentStateEnum < 0) ? null : _register[_currentStateEnum];

        private void Awake()
        {
            IsInitialized = false;
            _currentStateEnum = EnumState.None;
        }

        private void RegisterState(EnumState stateEnum, BaseState state)
        {
            if (state == null)
                throw new ArgumentNullException(nameof(state));

            _register.Add(stateEnum, state);
        }

        private void PushState(EnumState nextStateEnum)
        {
            if (!_register.ContainsKey(nextStateEnum))
                throw new ArgumentException("State " + nextStateEnum + " not registered yet.");

            if (_currentStateEnum != EnumState.None)
                Current?.OnExit();
            _currentStateEnum = nextStateEnum;
            Current?.OnEnter();
        }

        public void Initialize(BaseEntity handler = null)
        {
            IdleState = new Idle(handler, this);
            AttackState = new Attack(handler, this);
            RunState = new Run(handler, this);
            DeathState = new Death(handler, this);
            RegisterState(EnumState.Idle, IdleState);
            RegisterState(EnumState.Attack, AttackState);
            RegisterState(EnumState.Death, DeathState);
            RegisterState(EnumState.Run, RunState);
            IsInitialized = true;
        }


        public void UpdateState()
        {
            Current?.OnUpdate();
        }

        public bool IsCurrent<T>() where T : BaseState => Current?.GetType() == typeof(T);


        public void Clear()
        {
            foreach (var state in _register.Values)
                state.OnClear();
            _register.Clear();
            _currentStateEnum = EnumState.None;
        }

        public void Idle() => PushState(EnumState.Idle);
        public void Attack() => PushState(EnumState.Attack);
        public void Run() => PushState(EnumState.Run);
        public void Death() => PushState(EnumState.Death);
    }

    public enum EnumState
    {
        None,
        Idle,
        Run,
        Attack,
        Death
    }
}