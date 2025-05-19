using MainGlobal;
using Reflex.Attributes;
using UnityEngine;
using YG;

namespace Menu
{
    public class MainMenuCanvas : MonoBehaviour
    {
       // private const string LeaderboardName = "LeaderboardPlayers";

        public static readonly string LeaderboardName = "LeaderboardPlayers";

        [SerializeField] private LeaderboardView _leaderBoardView;
        [SerializeField] private GameObject _authorisePanel;
        [SerializeField] private YandexLeaderboard _yandexLeaderboard;

        private GlobalGame _globalGame;

        public GlobalGame GlobalGame => _globalGame;

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
                _authorisePanel.SetActive(true);
            }
            else
            {
                YandexGame.GetLeaderboard(LeaderboardName, 10, 3, 3, "small");
                _yandexLeaderboard.Fill();
                _leaderBoardView.gameObject.SetActive(true);
            }
        }

        public void OnCloseButtonPressed(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }

        //public void SetScore(int score)
        //{
        //    YandexGame.GetLeaderboard(LeaderboardName, 10, 3, 3, "small");
        //    YandexGame.NewLeaderboardScores(LeaderboardName, score);
        //}
    }
}