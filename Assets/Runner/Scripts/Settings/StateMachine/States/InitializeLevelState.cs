namespace Runner.Settings.StateMachine
{
    public class InitializeLevelState : LevelState
    {
        private EntryPoint _entryPoint;
              
        public InitializeLevelState(LevelStateMachine levelStatemachine, EntryPoint entryPoint) : base(levelStatemachine)
        {
            _entryPoint = entryPoint;
        }

        public override void Enter()
        {
            _entryPoint.InitRunnerFeatures(GlobalGame.LocationRunnerTypes, GlobalGame.Level);
        }
    }
}