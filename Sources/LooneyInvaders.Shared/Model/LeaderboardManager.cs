using System;
using System.Threading.Tasks;
using Plugin.Settings;
using LooneyInvaders.Extensions;
using LBIField = LooneyInvaders.Model.Enums.LeaderBoardItemField;

namespace LooneyInvaders.Model
{
    public class LeaderboardManager
    {
        static LeaderboardManager()
        {
            ReloadNetworkConnectionManagerSubscription();
        }

        private static bool _isRefreshing;

        private static Leaderboard _regularLeaderboard;
        public static Leaderboard RegularLeaderboard => _regularLeaderboard ?? (_regularLeaderboard = new Leaderboard(LeaderboardType.Regular));

        private static Leaderboard _proLeaderboard;
        public static Leaderboard ProLeaderboard => _proLeaderboard ?? (_proLeaderboard = new Leaderboard(LeaderboardType.Pro));

        public delegate Task SubmitScoreDelegate(double score, double accuracy, double fastestTime, double levelsCompleted);
        public static SubmitScoreDelegate SubmitScoreHandler;

        public delegate void RefreshLeaderboardsDelegate(Leaderboard leaderboard);
        public static RefreshLeaderboardsDelegate RefreshLeaderboardsHandler;

        public static event EventHandler OnLeaderboardsRefreshed;

        private static void ReloadNetworkConnectionManagerSubscription()
        {
            NetworkConnectionManager.ConnectionChanged -= ForceLeaderboardsToBeRefreshed;
            NetworkConnectionManager.ConnectionChanged += ForceLeaderboardsToBeRefreshed;
        }

        public static void ClearOnLeaderboardsRefreshedEvent()
        {
            OnLeaderboardsRefreshed = null;
            ReloadNetworkConnectionManagerSubscription();
        }

        public static double BestScoreRegularScore
        {
            get => CrossSettings.Current.GetValueOrDefault("BestScoreRegular_Score", Convert.ToDouble(0));
            set => CrossSettings.Current.AddOrUpdateValue("BestScoreRegular_Score", value);
        }

        public static double BestScoreRegularFastestTime
        {
            get => CrossSettings.Current.GetValueOrDefault("BestScoreRegular_FastestTime", Convert.ToDouble(0));
            set => CrossSettings.Current.AddOrUpdateValue("BestScoreRegular_FastestTime", value);
        }

        public static double BestScoreRegularAccuracy
        {
            get => CrossSettings.Current.GetValueOrDefault("BestScoreRegular_Accuracy", Convert.ToDouble(0));
            set => CrossSettings.Current.AddOrUpdateValue("BestScoreRegular_Accuracy", value);
        }

        public static bool BestScoreRegularSubmitted
        {
            get => CrossSettings.Current.GetValueOrDefault("BestScoreRegular_Submitted", false);
            set => CrossSettings.Current.AddOrUpdateValue("BestScoreRegular_Submitted", value);
        }

        public static double BestScoreProScore
        {
            get => CrossSettings.Current.GetValueOrDefault("BestScorePro_Score", Convert.ToDouble(0));
            set => CrossSettings.Current.AddOrUpdateValue("BestScorePro_Score", value);
        }

        public static double BestScoreProLevelsCompleted
        {
            get => CrossSettings.Current.GetValueOrDefault("BestScorePro_LevelsCompleted", Convert.ToDouble(0));
            set => CrossSettings.Current.AddOrUpdateValue("BestScorePro_LevelsCompleted", value);
        }

        public static bool BestScoreProSubmitted
        {
            get => CrossSettings.Current.GetValueOrDefault("BestScorePro_Submitted", false);
            set => CrossSettings.Current.AddOrUpdateValue("BestScorePro_Submitted", value);
        }

        public static object GetPlayerRankRegularDailyField(LBIField field)
        {
            return PlayerRankRegularDaily.GetLeaderboardItemField(field);
        }
        public static object GetPlayerRankRegularWeeklyField(LBIField field)
        {
            return PlayerRankRegularWeekly.GetLeaderboardItemField(field);
        }
        public static object GetPlayerRankRegularMonthlyField(LBIField field)
        {
            return PlayerRankRegularMonthly.GetLeaderboardItemField(field);
        }
        public static object GetPlayerRankRegularAlltimeField(LBIField field)
        {
            return PlayerRankRegularAlltime.GetLeaderboardItemField(field);
        }

        public static object GetPlayerRankProDailyField(LBIField field)
        {
            return PlayerRankProDaily.GetLeaderboardItemField(field);
        }
        public static object GetPlayerRankProWeeklyField(LBIField field)
        {
            return PlayerRankProWeekly.GetLeaderboardItemField(field);
        }
        public static object GetPlayerRankProMonthlyField(LBIField field)
        {
            return PlayerRankProMonthly.GetLeaderboardItemField(field);
        }
        public static object GetPlayerRankProAlltimeField(LBIField field)
        {
            return PlayerRankProAlltime.GetLeaderboardItemField(field);
        }

        public static LeaderboardItem PlayerRankRegularDaily;
        public static LeaderboardItem PlayerRankRegularWeekly;
        public static LeaderboardItem PlayerRankRegularMonthly;
        public static LeaderboardItem PlayerRankRegularAlltime;

        public static LeaderboardItem PlayerRankProDaily;
        public static LeaderboardItem PlayerRankProWeekly;
        public static LeaderboardItem PlayerRankProMonthly;
        public static LeaderboardItem PlayerRankProAlltime;

        internal async static void ForceLeaderboardsToBeRefreshed(object sender, EventArgs args)
        {
            await RefreshLeaderboards(750); //delay to ensure inet connection isn't so weak
        }

        internal static void FireOnLeaderboardsRefreshed()
        {
            var onLeaderboardsRefreshed = OnLeaderboardsRefreshed;
            onLeaderboardsRefreshed?.Invoke(null, EventArgs.Empty);
        }

        public static async Task<bool> SubmitScoreRegularAsync(double score, double accuracy, double fastestTime)
        {
            if (Math.Abs(score) < AppConstants.Tolerance)
                return true;

            if (score > BestScoreRegularScore)
            {
                BestScoreRegularScore = score;
                BestScoreRegularAccuracy = accuracy;
                BestScoreRegularFastestTime = fastestTime;
                BestScoreRegularSubmitted = false;
            }

            if (SubmitScoreHandler != null && NetworkConnectionManager.IsInternetConnectionAvailable())
            {
                await Task.Run(() => SubmitScoreHandler(score, accuracy, fastestTime, -1));
                BestScoreRegularSubmitted = true;
                return true;
            }
            return false;
        }

        public static async Task<bool> SubmitScoreProAsync(double score, double levelsCompleted)
        {
            if (Math.Abs(score) < AppConstants.Tolerance)
            {
                return true;
            }

            if (score > BestScoreProScore)
            {
                BestScoreProScore = score;
                BestScoreProLevelsCompleted = levelsCompleted;
                BestScoreProSubmitted = false;
            }

            if (SubmitScoreHandler != null && NetworkConnectionManager.IsInternetConnectionAvailable())
            {
                await Task.Run(() => SubmitScoreHandler(score, -1, -1, levelsCompleted)).ConfigureAwait(false);
                BestScoreProSubmitted = true;
                return true;
            }
            return false;
        }

        public static void SubmitUnsubmittedScores()
        {
            if (BestScoreRegularSubmitted == false && SubmitScoreHandler != null && NetworkConnectionManager.IsInternetConnectionAvailable() && BestScoreRegularScore > 0)
            {
                SubmitScoreHandler(BestScoreRegularScore, BestScoreRegularAccuracy, BestScoreRegularFastestTime, -1);
                BestScoreRegularSubmitted = true;
            }

            if (BestScoreProSubmitted == false && SubmitScoreHandler != null && NetworkConnectionManager.IsInternetConnectionAvailable() && BestScoreProScore > 0)
            {
                SubmitScoreHandler(BestScoreProScore, -1, -1, BestScoreProLevelsCompleted);
                BestScoreProSubmitted = true;
            }
        }

        public static async Task RefreshLeaderboards(int millisecondsPreDelay = 0)
        {
            await Task.Delay(millisecondsPreDelay);
            if (_isRefreshing || RefreshLeaderboardsHandler == null) {
                return;
            }
            _isRefreshing = true;

            await Task.Run(() =>
            {
                if (NetworkConnectionManager.IsInternetConnectionAvailable())
                {
                    SubmitUnsubmittedScores();
                    RefreshLeaderboardsHandler(RegularLeaderboard);
                    RefreshLeaderboardsHandler(ProLeaderboard);
                }
                else FireOnLeaderboardsRefreshed();
            });
            _isRefreshing = false;
        }

        public static LeaderboardItem DecodeScoreRegular(int rank, string name, double encodedScore)
        {
            var s = encodedScore.ToString("000000000000000");
            var accuracy = Convert.ToDouble(s.Substring(s.Length - 4, 4)) / 100;
            var time = Convert.ToDouble(s.Substring(s.Length - 9, 5)) / 100;
            var score = Convert.ToDouble(s.Substring(0, s.Length - 9));

            return new LeaderboardItem(rank, name, score, time, accuracy);
        }

        public static double EncodeScoreRegular(double score, double time, double accuracy)
        {
            var scoreString = score.ToString("000000");
            var timeString = time.ToString("000.00").Replace(".", "").Replace(",", "");
            var accuracyString = accuracy.ToString("00.00").Replace(".", "").Replace(",", "");

            if (scoreString.Length > 6) scoreString = "999999";
            if (timeString.Length > 5) timeString = "99999";
            if (accuracyString.Length > 4) accuracyString = "9999";

            return Convert.ToDouble(scoreString + timeString + accuracyString);
        }

        public static LeaderboardItem DecodeScorePro(int rank, string name, double encodedScore)
        {
            var s = encodedScore.ToString("000000000000000");

            var levelsCompleted = Convert.ToDouble(s.Substring(s.Length - 9, 9));
            var score = Convert.ToDouble(s.Substring(0, s.Length - 9));

            return new LeaderboardItem(rank, name, score, levelsCompleted);
        }

        public static double EncodeScorePro(double score, double levelsCompleted)
        {
            var scoreString = score.ToString("000000");
            var levelsCompletedString = levelsCompleted.ToString("000000000");

            if (scoreString.Length > 6) scoreString = "999999";
            if (levelsCompletedString.Length > 9) levelsCompletedString = "999999999";

            return Convert.ToDouble(scoreString + levelsCompletedString);
        }
    }
}
