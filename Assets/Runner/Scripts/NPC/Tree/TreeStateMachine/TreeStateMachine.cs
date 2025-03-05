using System;
using System.Collections.Generic;

namespace Runner.NonPlayerCharacters.StateMachine
{
    public class TreeStateMachine
    {
        private TreeState StateCurrent { get; set; }

        private Dictionary<Type, TreeState> _states = new Dictionary<Type, TreeState>();

        public void AddState(TreeState state)
        {
            _states.Add(state.GetType(), state);
        }

        public void SetState<T>() where T : TreeState
        {
            var type = typeof(T);

            if (StateCurrent != null && StateCurrent.GetType() == type)
            {
                return;
            }

            if (_states.TryGetValue(type, out var newState))
            {
                StateCurrent?.Exit();
                StateCurrent = newState;
                StateCurrent.Enter();  
            }
        }

        public void Update()
        {
            StateCurrent?.Update();
        }
    }
}
    

