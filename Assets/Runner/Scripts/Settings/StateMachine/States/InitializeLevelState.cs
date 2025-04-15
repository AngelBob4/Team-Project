using MainGlobal;

namespace Runner.Settings.StateMachine
{
    public class InitializeLevelState : LevelState
    {
        public InitializeLevelState(LevelStateMachine levelStatemachine, GlobalGame globalGame, LevelController levelController)
            : base(levelStatemachine, globalGame, levelController) { }

        public override void Enter()
        {
            LevelController.InitRunnerFeatures(GlobalGame.LocationRunnerTypes, GlobalGame.Level);
        }
    }
}