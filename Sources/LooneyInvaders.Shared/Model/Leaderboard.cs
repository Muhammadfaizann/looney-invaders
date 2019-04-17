using System.Collections.Generic;

namespace LooneyInvaders.Model
{
    public class Leaderboard
    {
        public List<LeaderboardItem> ScoreDaily = new List<LeaderboardItem>();
        public List<LeaderboardItem> ScoreWeekly = new List<LeaderboardItem>();
        public List<LeaderboardItem> ScoreMonthly = new List<LeaderboardItem>();
        public List<LeaderboardItem> ScoreAllTime = new List<LeaderboardItem>();

        public LeaderboardType Type;

        public Leaderboard(LeaderboardType type)
        {
            Type = type;
        }
    }
}
