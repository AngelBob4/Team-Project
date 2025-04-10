using MainGlobal;
using UnityEngine;

namespace Runner.Settings.StateMachine
{
    public class InitializeLevelState : LevelState
    {
        private EntryPoint _entryPoint;
              
        public InitializeLevelState(LevelStateMachine levelStatemachine, GlobalGame globalGame, EntryPoint entryPoint) : base(levelStatemachine,globalGame)
        {
            _entryPoint = entryPoint;
        }

        public override void Enter()
        {
           _entryPoint.InitAllSettingsForRunner(GlobalGame.LocationRunnerTypes);
        }
    }
}