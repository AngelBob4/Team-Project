using MainGlobal;

namespace Runner.Settings.StateMachine
{
    public class FinishLevelState : LevelState
    {
        private GlobalGame _globalGame;

        public FinishLevelState(LevelStateMachine levelStatemachine, GlobalGame globalGame) : base(levelStatemachine, globalGame)
        {
            _globalGame = globalGame;
        }

        public override void Enter()
        {
            _globalGame.StartEvent();
        }
    }
}
