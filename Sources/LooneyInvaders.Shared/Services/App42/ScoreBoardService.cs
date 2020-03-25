using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.game;
using LooneyInvaders.Extensions;
using LooneyInvaders.Model;
using LooneyInvaders.Services.App42;
using app42ScoreBoardService = com.shephertz.app42.paas.sdk.csharp.game.ScoreBoardService;

namespace LooneyInvaders.App42
{
    public class ScoreBoardService
    {
        static readonly object toGetInstance = new object();
        static readonly int maxAttemptsCount = 4;
        static (string, string, string, string) looneyEarthNames;
        static (string, string, string, string) looneyMoonNames;

        static ScoreBoardService _instance;
        static app42ScoreBoardService _service;
        static GameService _gameService;

        public static string App42ApiKey { get; private set; }
        public static string App42SecretKey { get; private set; }
        public static ScoreBoardService Instance => GetInstance();
        public static app42ScoreBoardService App42Service => GetService();
        public static Exception LastException { get; private set; }
        public static int OverallDelayMS => 5000;

        private ScoreBoardService()
        {
            looneyEarthNames = ("Looney Earth Daily", "Looney Earth Weekly", "Looney Earth Monthly", "Looney Earth Alltime");
            looneyMoonNames = ("Looney Moon Daily", "Looney Moon Weekly", "Looney Moon Monthly", "Looney Moon Alltime");

            try
            {
                _gameService = App42ServiceBuilder.CommonGameService;
                _service = App42ServiceBuilder.API.BuildScoreBoardService();
            }
            catch (Exception ex)
            {
                LastException = ex;
            }
        }

        private static ScoreBoardService GetInstance()
        {
            lock (toGetInstance)
            {
                if (_instance == null)
                {
                    _instance = new ScoreBoardService();
                }
                return _instance;
            }
        }

        private static app42ScoreBoardService GetService()
        {
            GetInstance();
            return _service;
        }

        public async Task SubmitScore(double score, double accuracy, double fastestTime, double levelsCompleted)
        {

            if (Math.Abs(levelsCompleted + 1) < AppConstants.Tolerance) // regular scoreboard
            {
                LeaderboardManager.PlayerRankRegularDaily = null;
                LeaderboardManager.PlayerRankRegularWeekly = null;
                LeaderboardManager.PlayerRankRegularMonthly = null;
                LeaderboardManager.PlayerRankRegularAlltime = null;

                try
                {
                    double encodedScore = LeaderboardManager.EncodeScoreRegular(score, fastestTime, accuracy);
                    await SaveUserScoreForGamesAsync(Player.Instance.Name,
                        encodedScore,
                        TimeSpan.FromMilliseconds(App42ServiceBuilder.CommonDelayOnErrorMS),
                        looneyEarthNames.Item1,
                        looneyEarthNames.Item2,
                        looneyEarthNames.Item3,
                        looneyEarthNames.Item4);
                }
                catch (Exception ex)
                {
                    LastException = ex;
                }
                try
                {
                    LeaderboardManager.PlayerRankRegularDaily = GetPlayerRanking(App42Service,
                        looneyEarthNames.Item1, LeaderboardType.Regular);
                    LeaderboardManager.PlayerRankRegularWeekly = GetPlayerRanking(App42Service,
                        looneyEarthNames.Item2, LeaderboardType.Regular);
                    LeaderboardManager.PlayerRankRegularMonthly = GetPlayerRanking(App42Service,
                        looneyEarthNames.Item3, LeaderboardType.Regular);
                    LeaderboardManager.PlayerRankRegularAlltime = GetPlayerRanking(App42Service,
                        looneyEarthNames.Item4, LeaderboardType.Regular);
                }
                catch (Exception ex)
                {
                    LastException = ex;
                }
            }
            else
            {
                LeaderboardManager.PlayerRankProDaily = null;
                LeaderboardManager.PlayerRankProWeekly = null;
                LeaderboardManager.PlayerRankProMonthly = null;
                LeaderboardManager.PlayerRankProAlltime = null;

                try
                {
                    double encodedScore = LeaderboardManager.EncodeScorePro(score, levelsCompleted);
                    await SaveUserScoreForGamesAsync(Player.Instance.Name,
                        encodedScore,
                        TimeSpan.FromMilliseconds(App42ServiceBuilder.CommonDelayOnErrorMS),
                        looneyMoonNames.Item1,
                        looneyMoonNames.Item2,
                        looneyMoonNames.Item3,
                        looneyMoonNames.Item4);
                }
                catch (Exception ex)
                {
                    LastException = ex;
                }
                try
                {
                    LeaderboardManager.PlayerRankProDaily = GetPlayerRanking(App42Service,
                        looneyMoonNames.Item1, LeaderboardType.Pro);
                    LeaderboardManager.PlayerRankProWeekly = GetPlayerRanking(App42Service,
                        looneyMoonNames.Item2, LeaderboardType.Pro);
                    LeaderboardManager.PlayerRankProMonthly = GetPlayerRanking(App42Service,
                        looneyMoonNames.Item3, LeaderboardType.Pro);
                    LeaderboardManager.PlayerRankProAlltime = GetPlayerRanking(App42Service,
                        looneyMoonNames.Item4, LeaderboardType.Pro);
                }
                catch (Exception ex)
                {
                    LastException = ex;
                }
            }
        }

        public void RefreshLeaderboards(Leaderboard leaderboard)
        {
            (string, string, string, string) gameNames;
            switch (leaderboard.Type)
            {
                case LeaderboardType.Regular:
                    gameNames = looneyEarthNames;
                    break;
                case LeaderboardType.Pro:
                    gameNames = looneyMoonNames;
                    break;
                default: return;
            }

            FillLeaderboard(App42Service, leaderboard.Type, leaderboard.ScoreDaily, gameNames.Item1);
            FillLeaderboard(App42Service, leaderboard.Type, leaderboard.ScoreWeekly, gameNames.Item2);
            FillLeaderboard(App42Service, leaderboard.Type, leaderboard.ScoreMonthly, gameNames.Item3);
            FillLeaderboard(App42Service, leaderboard.Type, leaderboard.ScoreAllTime, gameNames.Item4);

            if (leaderboard.Type == LeaderboardType.Regular)
            {
                LeaderboardManager.PlayerRankRegularDaily = GetPlayerRanking(App42Service, gameNames.Item1, LeaderboardType.Regular);
                LeaderboardManager.PlayerRankRegularWeekly = GetPlayerRanking(App42Service, gameNames.Item2, LeaderboardType.Regular);
                LeaderboardManager.PlayerRankRegularMonthly = GetPlayerRanking(App42Service, gameNames.Item3, LeaderboardType.Regular);
            }
            else if (leaderboard.Type == LeaderboardType.Pro)
            {
                LeaderboardManager.PlayerRankProDaily = GetPlayerRanking(App42Service, gameNames.Item1, LeaderboardType.Pro);
                LeaderboardManager.PlayerRankProWeekly = GetPlayerRanking(App42Service, gameNames.Item2, LeaderboardType.Pro);
                LeaderboardManager.PlayerRankProMonthly = GetPlayerRanking(App42Service, gameNames.Item3, LeaderboardType.Pro);
            }

            LeaderboardManager.FireOnLeaderboardsRefreshed();
        }

        public void FillLeaderboard(app42ScoreBoardService scoreBoardService, LeaderboardType type, List<LeaderboardItem> scoreList, string gameName)
        {
            scoreList.Clear();

            try
            {
                Game game = null;

                var gameTask = Task.Run(() => game = scoreBoardService.GetTopNRankers(gameName, 10));
                gameTask.Wait(20000);
                if (game != null && game.GetScoreList() != null && game.GetScoreList().Count > 0)
                {
                    for (var i = 0; i < game.GetScoreList().Count; i++)
                    {
                        if (game.GetScoreList()[i].GetValue() > 0)
                        {
                            LeaderboardItem lbi = null;

                            if (type == LeaderboardType.Regular)
                                lbi = LeaderboardManager.DecodeScoreRegular(i + 1, game.GetScoreList()[i].GetUserName(), game.GetScoreList()[i].GetValue());
                            else if (type == LeaderboardType.Pro)
                                lbi = LeaderboardManager.DecodeScorePro(i + 1, game.GetScoreList()[i].GetUserName(), game.GetScoreList()[i].GetValue());

                            if (lbi != null) scoreList.Add(lbi);
                        }
                    }
                }
            }
            catch (App42NotFoundException ex)
            {
                LastException = ex;
            }
            catch (Exception e)
            {
                LastException = e;
            }
        }

        private LeaderboardItem GetPlayerRanking(app42ScoreBoardService scoreBoardService, string gameName, LeaderboardType type)
        {
            Game game;
            game = TryGetGame(() => scoreBoardService.GetUserRanking(gameName, Player.Instance.Name))
                ?? TryGetGame(() => scoreBoardService.GetScoresByUser(gameName, Player.Instance.Name));
            if (game == null)
            {
                try
                {
                    game = _gameService.GetGameByName(gameName) ?? _gameService.CreateGame(gameName, gameName);
                }
				catch (Exception _ex)
				{
                    LastException = _ex;
                }
            }
            try
            {
                if (game != null && game.GetScoreList() != null && game.GetScoreList().Count > 0)
                {
                    if (game.GetScoreList()[0].GetValue() > 0)
                    {
                        switch (type)
                        {
                            case LeaderboardType.Regular:
                                return LeaderboardManager.DecodeScoreRegular(
                                    Convert.ToInt32(game.GetScoreList()[0].GetRank()),
                                    game.GetScoreList()[0].GetUserName(),
                                    game.GetScoreList()[0].GetValue());
                            case LeaderboardType.Pro:
                                return LeaderboardManager.DecodeScorePro(
                                    Convert.ToInt32(game.GetScoreList()[0].GetRank()),
                                    game.GetScoreList()[0].GetUserName(),
                                    game.GetScoreList()[0].GetValue());
                            default: return null;
                        }
                    }
                }
            }
            catch (App42NotFoundException ex)
            {
                LastException = ex;
            }
            catch (System.Net.WebException e)
            {
                LastException = e;
                return null;
            }

            return null;
        }

        private Game TryGetGame(Func<Game> getter)
        {
            try
            {
                return getter?.Invoke();
            }
            catch (App42NotFoundException ex)
            {
                LastException = ex;
            }
            catch (System.Net.WebException e)
            {
                LastException = e;
                return null;
            }
            return null;
        }

        private async Task SaveUserScoreForGamesAsync(string gameUserName, double gameScore, TimeSpan delayOnError, params string[] gameNames)
        {
            var useCallbackApproach = false; //we can manage that
            if (gameNames.Length <= 0)
            {
                return;
            }

            foreach (var gameName in gameNames)
            {
                var callbackHandler = new App42CallbackHandler();
                callbackHandler.OnErrorCallback = () =>
                {
                    callbackHandler.Response = null;
                    GetService().SaveUserScoreCallback(gameName, gameUserName, gameScore, _gameService, callbackHandler);
                };

                for (var i = 1; i <= maxAttemptsCount; ++i)
                {
                    if (useCallbackApproach) //using app42 api with callback approach
                    {
                        callbackHandler.OnErrorCallback();

                        while (callbackHandler.Response == null) { }
                        if (callbackHandler.IsSuccess) break;
                    }
                    else
                    {
                        if (GetService().SaveUserScore(gameName, gameUserName, gameScore, _gameService))
                            break;
                    }

                    await Task.Delay(delayOnError);
                }
            }
        }
    }
}
