using MainGlobal;

namespace Runner.Settings.StateMachine
{
    public class EducationLevelState : LevelState
    {
        private LevelStateMachine _levelStateMachine;

        public EducationLevelState(LevelStateMachine levelStatemachine, GlobalGame globalGame) : base(levelStatemachine, globalGame)
        {
        }
    }
}