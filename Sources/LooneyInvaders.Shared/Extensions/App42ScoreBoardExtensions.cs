using System;
using System.Linq;
using com.shephertz.app42.paas.sdk.csharp.game;
using com.shephertz.app42.paas.sdk.csharp.user;
using app42ScoreBoardService = com.shephertz.app42.paas.sdk.csharp.game.ScoreBoardService;

namespace LooneyInvaders.Extensions
{
    public static class App42ScoreBoardExtensions
    {
        public static Game SaveUserScore(this app42ScoreBoardService service, string gameName, string gameUserName, double gameScore, bool isInDebug = false)
        {
            Game game = null;
            User user = null;
            if (service == null)
            {
                if (isInDebug)
                { Console.WriteLine("SaveUserScore extension error: app42ScoreBoardService is null"); }
                return game;
            }
            try
            {
                var userService = com.shephertz.app42.paas.sdk.csharp.App42API.BuildUserService();
                user = userService?.GetUser(gameUserName);
            }
            catch (Exception ex)
            {
                var mess = ex.Message;
            }
            finally
            {
                if (user == null)
                {
                    user = new User();
                    user.SetUserName(gameUserName);
                    user.SetAccountLocked(false);
                    user.SetResponseSuccess(true);
                }
                try
                {
                    game = service.GetLastGameScore(gameUserName);
                    if (game != null)
                    {
                        service.EditScoreValueById(game.GetScoreList()?.LastOrDefault()?.GetScoreId(), gameScore);
                    }
                }
                catch (Exception ex)
                {
                    Tracer.Trace($"|Cannot Edit Score Value By Id| name = {gameUserName} | {ex.Message}");
                }
                if (game == null)
                    game = service.SaveUserScore(gameName, gameUserName, gameScore);
            }
            return game;
        }
    }
}

