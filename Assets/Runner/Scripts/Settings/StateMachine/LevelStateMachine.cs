using System;
using System.Collections.Generic;

namespace Runner.Settings.StateMachine
{
    public class LevelStateMachine
    {
        private Dictionary<Type, LevelState> _states = new Dictionary<Type, LevelState>();
        private LevelState _currentState;

        public void Update()
        {
            _currentState?.Update();
        }

        public void AddState(LevelState state)
        {
            _states.Add(state.GetType(), state);
        }

        public void SetState<T>() where T : LevelState
        {
            var type = typeof(T);

            if (_currentState != null && _currentState.GetType() == type)
            {
                return;
            }

            if (_states.TryGetValue(type, out var newState))
            {
                _currentState?.Exit();
                _currentState = newState;
                _currentState.Enter();
            }
        }
    }
}

