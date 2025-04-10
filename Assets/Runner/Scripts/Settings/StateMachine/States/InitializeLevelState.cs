using MainGlobal;

namespace Runner.Settings.StateMachine
{
    public class InitializeLevelState : LevelState
    {
        private LevelController _levelController;

        public InitializeLevelState(LevelStateMachine levelStatemachine, GlobalGame globalGame, LevelController levelController) : base(levelStatemachine, globalGame)
        {
            _levelController = levelController;
        }

        public override void Enter()
        {
            _levelController.InitRunnerFeatures(GlobalGame.LocationRunnerTypes, GlobalGame.Level);
        }
    }
}