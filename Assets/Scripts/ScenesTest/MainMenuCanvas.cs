using MainGlobal;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UIElements;

namespace ScenesTest
{
    public class MainMenuCanvas : MonoBehaviour
    {
        private GlobalGame _globalGame;

        public GlobalGame GlobalGame =>_globalGame;

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
