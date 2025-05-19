using Events.Main.Events;
using MainGlobal;
using Reflex.Attributes;

namespace Menu
{
    public class TestEventRunner : GameEvent
    {
        private GlobalGame _globalGame;

        [Inject]
        private void Inject(GlobalGame globalGame)
        {
            _globalGame = globalGame;
        }

        public override void StartEvent(int level)
        {

        }

        public void OnClickButton()
        {
            _globalGame.StartEvent();
        }
    }
}
