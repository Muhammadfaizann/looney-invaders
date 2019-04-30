using System;
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
                return game;
            }
            finally
            {
                if (user == null)
                {
                    user = new User();
                    user.SetUserName(gameUserName);
                }
                game = service.SaveUserScore(gameName, gameUserName, gameScore);
            }
            return game;
        }
    }
}

