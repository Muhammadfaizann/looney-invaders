using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace LooneyInvaders.Model
{
    public enum LeaderboardType { REGULAR, PRO }

    public class Leaderboard
    {
        public List<LeaderboardItem> ScoreDaily = new List<LeaderboardItem>();
        public List<LeaderboardItem> ScoreWeekly = new List<LeaderboardItem>();
        public List<LeaderboardItem> ScoreMonthly = new List<LeaderboardItem>();
        public List<LeaderboardItem> ScoreAllTime = new List<LeaderboardItem>();

        public LeaderboardType Type;
        
        public Leaderboard(LeaderboardType type)
        {
            this.Type = type;            
        }
    }
}
