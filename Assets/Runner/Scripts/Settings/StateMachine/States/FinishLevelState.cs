namespace Runner.Settings.StateMachine
{
    public class FinishLevelState : LevelState
    {
        public FinishLevelState(LevelStateMachine levelStatemachine) : base(levelStatemachine)
        {
        }

        public override void Enter()
        {
            GlobalGame.StartEvent();
        }
    }
}
