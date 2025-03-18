using MainGlobal;
using Reflex.Attributes;
using UnityEngine;

namespace ScenesTest
{
    public class StartGemeTest : MonoBehaviour
    {
        private GlobalGame _globalGame;

        [Inject]
        private void Inject(GlobalGame globalGame)
        {
            _globalGame = globalGame;
        }

        public void StartNewGame()
        {
            _globalGame.NewGame();
        }
    }
}
