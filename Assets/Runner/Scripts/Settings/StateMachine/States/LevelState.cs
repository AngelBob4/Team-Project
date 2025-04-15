using MainGlobal;

namespace Runner.Settings.StateMachine
{
    public abstract class LevelState
    {
        protected readonly LevelStateMachine LevelStateMachine;
        protected GlobalGame GlobalGame;
        protected LevelController LevelController;

        protected LevelState(LevelStateMachine levelStatemachine, GlobalGame globalGame)
        {
            LevelStateMachine = levelStatemachine;
            GlobalGame = globalGame;
        }

        protected LevelState(LevelStateMachine levelStatemachine, GlobalGame globalGame,LevelController levelController)
        {
            LevelStateMachine = levelStatemachine;
            GlobalGame = globalGame;
            LevelController = levelController;
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update() { }
    }
}