namespace Runner.Settings.StateMachine
{
    public class EducationLevelState : LevelState
    {
        private LevelStateMachine _levelStateMachine;

        public EducationLevelState(LevelStateMachine levelStatemachine) : base(levelStatemachine)
        {
        }
    }
}