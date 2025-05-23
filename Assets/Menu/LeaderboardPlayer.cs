using UnityEngine;

namespace Menu
{
    public class LeaderboardPlayer : MonoBehaviour
    {
        public LeaderboardPlayer(int rank, string name, int score)
        {
            Rank = rank;
            Name = name;
            Score = score;
        }

        public int Rank { get; private set; }
        public int Score { get; private set; }
        public string Name { get; private set; }
    }
}