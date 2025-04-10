using MainGlobal;
using Runner.PlayerController;
using Runner.UI;

namespace Runner.Settings.StateMachine
{
    public class GameOverLevelState : LevelState
    {
        private Player _player;
        private CanvasUI _canvasUI;
        private EntryPoint _entryPoint;

        public GameOverLevelState(LevelStateMachine levelStatemachine, GlobalGame globalgame, EntryPoint entryPoint, Player player, CanvasUI canvasUI) : base(levelStatemachine, globalgame)
        {
            _player = player;
            _canvasUI = canvasUI;
            _entryPoint = entryPoint;
        }

        public override void Enter()
        {
            _entryPoint.StopRunner();
            _player.Die();
            _canvasUI.EnableDeathPanel();
        }
    }
}
