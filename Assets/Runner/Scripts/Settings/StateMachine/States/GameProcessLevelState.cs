using MainGlobal;

namespace Runner.Settings.StateMachine
{
    public class GameProcessLevelState : LevelState
    {
        private LevelController _levelController;

        public GameProcessLevelState(LevelStateMachine levelStatemachine, GlobalGame globalGame, LevelController levelController) : base(levelStatemachine, globalGame)
        {
            _levelController = levelController;
        }

        public override void Enter()
        {
            _levelController.StartRunner();
        }
    }
}
