using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace LooneyInvaders.Model
{
    public class LeaderboardManager
    {
        private static Leaderboard regularLeaderboard;
        public static Leaderboard RegularLeaderboard { get { if (regularLeaderboard == null) regularLeaderboard = new Leaderboard(LeaderboardType.REGULAR); return regularLeaderboard; }  }

        private static Leaderboard proLeaderboard;
        public static Leaderboard ProLeaderboard { get { if (proLeaderboard == null) proLeaderboard = new Leaderboard(LeaderboardType.PRO); return proLeaderboard; } }

        public delegate void SubmitScoreDelegate(double score, double accuracy, double fastestTime, double levelsCompleted);
        public static SubmitScoreDelegate SubmitScoreHandler;

        public delegate void RefreshLeaderboardsDelegate(Leaderboard leaderboard);
        public static RefreshLeaderboardsDelegate RefreshLeaderboardsHandler;

        public static event EventHandler OnLeaderboardsRefreshed;

        public static void ClearOnLeaderboardsRefreshedEvent()
        {
            OnLeaderboardsRefreshed = null;
        }
        public static double BestScoreRegular_Score
        {
                get { return CrossSettings.Current.GetValueOrDefault("BestScoreRegular_Score", Convert.ToDouble(0)); }
                set { CrossSettings.Current.AddOrUpdateValue("BestScoreRegular_Score", value); }
        }

        public static double BestScoreRegular_FastestTime
        {
            get { return CrossSettings.Current.GetValueOrDefault("BestScoreRegular_FastestTime", Convert.ToDouble(0)); }
            set { CrossSettings.Current.AddOrUpdateValue("BestScoreRegular_FastestTime", value); }
        }

        public static double BestScoreRegular_Accuracy
        {
            get { return CrossSettings.Current.GetValueOrDefault("BestScoreRegular_Accuracy", Convert.ToDouble(0)); }
            set { CrossSettings.Current.AddOrUpdateValue("BestScoreRegular_Accuracy", value); }
        }

        public static bool BestScoreRegular_Submitted
        {
            get { return CrossSettings.Current.GetValueOrDefault("BestScoreRegular_Submitted", false); }
            set { CrossSettings.Current.AddOrUpdateValue("BestScoreRegular_Submitted", value); }
        }

        public static double BestScorePro_Score
        {
            get { return CrossSettings.Current.GetValueOrDefault("BestScorePro_Score", Convert.ToDouble(0)); }
            set { CrossSettings.Current.AddOrUpdateValue("BestScorePro_Score", value); }
        }

        public static double BestScorePro_LevelsCompleted
        {
            get { return CrossSettings.Current.GetValueOrDefault("BestScorePro_LevelsCompleted", Convert.ToDouble(0)); }
            set { CrossSettings.Current.AddOrUpdateValue("BestScorePro_LevelsCompleted", value); }
        }

        public static bool BestScorePro_Submitted
        {
            get { return CrossSettings.Current.GetValueOrDefault("BestScorePro_Submitted", false); }
            set { CrossSettings.Current.AddOrUpdateValue("BestScorePro_Submitted", value); }
        }

        public static LeaderboardItem PlayerRankRegularDaily = null;
        public static LeaderboardItem PlayerRankRegularWeekly = null;
        public static LeaderboardItem PlayerRankRegularMonthly = null;
        public static LeaderboardItem PlayerRankRegularAlltime = null;

        public static LeaderboardItem PlayerRankProDaily = null;
        public static LeaderboardItem PlayerRankProWeekly = null;
        public static LeaderboardItem PlayerRankProMonthly = null;
        public static LeaderboardItem PlayerRankProAlltime = null;

        private static bool IsRefreshing;
                

        public static bool SubmitScoreRegular(double score, double accuracy, double fastestTime)
        {
            if (score == 0) return true;

            if (score > BestScoreRegular_Score)
            {
                BestScoreRegular_Score = score;
                BestScoreRegular_Accuracy = accuracy;
                BestScoreRegular_FastestTime = fastestTime;
                BestScoreRegular_Submitted = false;
            }

            if (SubmitScoreHandler != null && NetworkConnectionManager.IsInternetConnectionAvailable() == true)
            {
                SubmitScoreHandler(score, accuracy, fastestTime, -1);
                BestScoreRegular_Submitted = true;
                return true;
            }
            return false;
        }

        public static bool SubmitScorePro(double score, double levelsCompleted)
        {
            if (score == 0) return true;

            if (score > BestScorePro_Score)
            {
                BestScorePro_Score = score;
                BestScorePro_LevelsCompleted = levelsCompleted;
                BestScorePro_Submitted = false;
            }

            if (SubmitScoreHandler != null && NetworkConnectionManager.IsInternetConnectionAvailable() == true)
            {
                BestScorePro_Submitted = true;
                SubmitScoreHandler(score, -1, -1, levelsCompleted);
                return true;
            }
            return false;
        }

        public static void SubmitUnsubmittedScores()
        {
            if (BestScoreRegular_Submitted == false && SubmitScoreHandler != null && NetworkConnectionManager.IsInternetConnectionAvailable() == true && BestScoreRegular_Score > 0)
            {
                SubmitScoreHandler(BestScoreRegular_Score, BestScoreRegular_Accuracy, BestScoreRegular_FastestTime, -1);
                BestScoreRegular_Submitted = true;
            }

            if (BestScorePro_Submitted == false && SubmitScoreHandler != null && NetworkConnectionManager.IsInternetConnectionAvailable() == true && BestScorePro_Score > 0)
            {
                BestScorePro_Submitted = true;
                SubmitScoreHandler(BestScorePro_Score, -1, -1, BestScorePro_LevelsCompleted);
            }
        }

        public static async void RefreshLeaderboards()
        {
            if (IsRefreshing) return;

            if (RefreshLeaderboardsHandler != null && NetworkConnectionManager.IsInternetConnectionAvailable() == true)
            {
                IsRefreshing = true;

                await Task.Run(() => SubmitUnsubmittedScores());
                RefreshLeaderboardsHandler(RegularLeaderboard);                
                RefreshLeaderboardsHandler(ProLeaderboard);
                IsRefreshing = false;
            }
        }

        internal static void FireOnLeaderboardsRefreshed()
        {
            if (OnLeaderboardsRefreshed != null) OnLeaderboardsRefreshed(null, EventArgs.Empty);
        }

        public static LeaderboardItem DecodeScoreRegular(int rank, string name, double encodedScore)
        {
            double score;
            double time;
            double accuracy;

            string s = encodedScore.ToString("000000000000000");

            accuracy = Convert.ToDouble(s.Substring(s.Length - 4, 4)) / 100;
            time = Convert.ToDouble(s.Substring(s.Length - 9, 5)) / 100;
            score = Convert.ToDouble(s.Substring(0, s.Length - 9));

            return new LeaderboardItem(rank, name, score, time, accuracy);
        }

        public static double EncodeScoreRegular(double score, double time, double accuracy)
        {
            string scoreString = score.ToString("000000");
            string timeString = time.ToString("000.00").Replace(".", "").Replace(",", "");
            string accuracyString = accuracy.ToString("00.00").Replace(".", "").Replace(",", "");

            if (scoreString.Length > 6) scoreString = "999999";
            if (timeString.Length > 5) timeString = "99999";
            if (accuracyString.Length > 4) accuracyString = "9999";

            return Convert.ToDouble(scoreString + timeString + accuracyString);
        }

        public static LeaderboardItem DecodeScorePro(int rank, string name, double encodedScore)
        {
            double score;
            double levelsCompleted;

            string s = encodedScore.ToString("000000000000000");            

            levelsCompleted = Convert.ToDouble(s.Substring(s.Length - 9, 9));            
            score = Convert.ToDouble(s.Substring(0, s.Length - 9));

            return new LeaderboardItem(rank, name, score, levelsCompleted);
        }

        public static double EncodeScorePro(double score, double levelsCompleted)
        {
            string scoreString = score.ToString("000000");
            string levelsCompletedString = levelsCompleted.ToString("000000000");            

            if (scoreString.Length > 6) scoreString = "999999";
            if (levelsCompletedString.Length > 9) levelsCompletedString = "999999999";            

            return Convert.ToDouble(scoreString + levelsCompletedString);
        }


    }
}
