using MainGlobal;
using Reflex.Attributes;
using Runner.UI;
using UnityEngine;
using UnityEngine.UIElements;
using YG;

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

        public void OnLeaderboardButtonPressed()
        {
            if (YandexGame.auth == false)
            {
              //  _canvasUI.ShowAuthorisePanel();
            }
            else
            {
               // YandexGame.GetLeaderboard(LeaderboardName, 10, 3, 3, "small");
              //  _canvasUI.ShowLeaderboardView();
               // _yandexLeaderboard.Fill();
            }
        }

        public void OnCloseLeaderboardButtonPressed()
        {
            //_canvasUI.CloseLeaderboardView();
        }
    }
}