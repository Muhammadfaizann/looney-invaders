using System;

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
            Rank = rank;
            Name = name;
            Score = score;
            Time = time;
            Accuracy = accuracy;
        }

        public LeaderboardItem(int rank, string name, double score, double levelsCompleted)
        {
            Rank = rank;
            Name = name;
            Score = score;
            LevelsCompleted = levelsCompleted;            
        }

        public override string ToString()
        {
            return Rank.ToString() + ". " + Name + " " + Score.ToString("###,###,###,###");
        }
    }
}
