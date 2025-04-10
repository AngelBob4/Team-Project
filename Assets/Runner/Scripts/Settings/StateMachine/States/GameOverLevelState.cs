using MainGlobal;

namespace Runner.Settings.StateMachine
{
    public class GameOverLevelState : LevelState
    {
        private LevelController _levelcontroller;

        public GameOverLevelState(LevelStateMachine levelStatemachine, GlobalGame globalGame, LevelController levelController) : base(levelStatemachine, globalGame)
        {
            _levelcontroller = levelController;
        }

        public override void Enter()
        {
            _levelcontroller.StopRunner();
        }
    }
}
