using MainGlobal;
using Reflex.Attributes;

namespace Runner.Settings.StateMachine
{
    public abstract class LevelState
    {
        protected readonly LevelStateMachine LevelStateMachine;
        protected  GlobalGame GlobalGame;

        protected LevelState(LevelStateMachine levelStatemachine)
        {
            LevelStateMachine = levelStatemachine;
        }

        [Inject]
        private void Inject(GlobalGame globalGame)
        {
            GlobalGame = globalGame;
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update() { }
    }
}