using MainGlobal;
using Runner.UI;

namespace Runner.Settings.StateMachine
{
    public class GameProcessLevelState : LevelState
    {
        private EntryPoint _entryPoint;
        private CanvasUI _canvasUI;

        public GameProcessLevelState(LevelStateMachine levelStatemachine, GlobalGame globalGame, EntryPoint entryPoint, CanvasUI canvasUI) : base(levelStatemachine, globalGame)
        {
            _entryPoint = entryPoint;
            _canvasUI = canvasUI;
        }

        public override void Enter()
        {
            _entryPoint.StartRunner();
            _canvasUI.DisableStartButton();
        }
    }
}
