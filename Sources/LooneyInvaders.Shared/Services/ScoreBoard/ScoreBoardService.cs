using System;
using System.Threading.Tasks;
using com.shephertz.app42.paas.sdk.csharp;
using app42ScoreBoardService = com.shephertz.app42.paas.sdk.csharp.game.ScoreBoardService;

namespace LooneyInvaders.ScoreBoard
{
    public class ScoreBoardService
    {
        static object toGetService = new object();
        static ScoreBoardService instance;

        static app42ScoreBoardService _service;

        public static app42ScoreBoardService Instance => GetService();

        private ScoreBoardService()
        {
            App42API.Initialize("a0aa82036ff74c83b602de87b68a396cf724df6786ae9caa260e1175a7c8ce26", "14be26afb208c96b1cf16b3b197a988f451bfcf2e0ef2bc6c2dbd6f494f07382");
            _service = App42API.BuildScoreBoardService();
        }

        private static app42ScoreBoardService GetService()
        {
            lock (toGetService)
            {
                if (instance == null)
                {
                    instance = new ScoreBoardService();
                }
                return _service;
            }
        }

        public static async Task SaveUserScoreForGamesAsync(string gameUserName, double gameScore, TimeSpan delayAfterEachSave, params string[] gameNames)
        {
            if (gameNames.Length <= 0)
            {
                return;
            }
            var maxAttemptsCount = 4;

            foreach (var gameName in gameNames)
            {
                var attemptsCount = 0;
                var saveIsSuccessful = false;

                while (!saveIsSuccessful)
                {
                    if (attemptsCount > maxAttemptsCount)
                    {
                        break;
                    }
                    saveIsSuccessful = GetService().SaveUserScore(gameName, gameUserName, gameScore).IsResponseSuccess();
                    if (!saveIsSuccessful)
                    {
                        await Task.Delay(delayAfterEachSave);
                    }
                }
            }
        }
    }
}
