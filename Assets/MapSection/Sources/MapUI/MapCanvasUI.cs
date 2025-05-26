using Menu;
using UnityEngine;
using YG;

namespace MapSection.MapUI
{
    public class MapCanvasUI : MonoBehaviour
    {
        public static readonly string LeaderboardName = "LeaderboardPlayers";

        [SerializeField] private LeaderboardView _leaderBoardView;
        [SerializeField] private GameObject _authorisePanel;
        [SerializeField] private YandexLeaderboard _yandexLeaderboard;

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

        public void OnAuthButtonPressed()
        {
            YandexGame.AuthDialog();
        }
        //public void SetScore(int score)
        //{
        //    YandexGame.GetLeaderboard(LeaderboardName, 10, 3, 3, "small");
        //    YandexGame.NewLeaderboardScores(LeaderboardName, score);
    }
}
