using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace LooneyInvaders.Model
{
    [Serializable]
    public class LeaderboardItem
    {
        public int Rank;
        public string Name;
        public double Score;
        public double Time;
        public double Accuracy;
        public double LevelsCompleted;
        public DateTime Date;

        public LeaderboardItem(int rank, string name, double score, double time, double accuracy)
        {
            this.Rank = rank;
            this.Name = name;
            this.Score = score;
            this.Time = time;
            this.Accuracy = accuracy;
        }

        public LeaderboardItem(int rank, string name, double score, double levelsCompleted)
        {
            this.Rank = rank;
            this.Name = name;
            this.Score = score;
            this.LevelsCompleted = levelsCompleted;            
        }

        public override string ToString()
        {
            return Rank.ToString() + ". " + Name + " " + Score.ToString("###,###,###,###");
        }
    }
}
