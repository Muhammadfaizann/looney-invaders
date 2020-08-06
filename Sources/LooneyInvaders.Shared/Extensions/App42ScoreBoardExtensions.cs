using System;
using System.Diagnostics;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.game;
using LooneyInvaders.Services.App42;
using app42ScoreBoardService = com.shephertz.app42.paas.sdk.csharp.game.ScoreBoardService;

namespace LooneyInvaders.Extensions
{
    public static class App42ScoreBoardExtensions
    {
        private const string ErrPrefix = "extension error";

        public static void SaveUserScoreCallback(this app42ScoreBoardService service,
            string gameName, string gameUserName, double gameScore,
            GameService gameService, App42CallbackHandler callbackHandler)
        {
            Game game = null;
            if (service == null)
            {
                var message = $"{nameof(SaveUserScoreCallback)} {ErrPrefix}: {nameof(app42ScoreBoardService)} is null";
                Debug.WriteLine(message); throw new ArgumentNullException(message);
            }

            try
            {
                if (callbackHandler != null)
                {
                    callbackHandler.OnExceptionCallback =
                        (ex) => service.GetGameOnSaveUserScoreException(ex, gameName, gameUserName, gameScore, gameService);
                    service.SaveUserScore(gameName, gameUserName, gameScore, callbackHandler);
                }
                else throw new Exception($"{nameof(SaveUserScoreCallback)} {ErrPrefix}: {nameof(App42CallbackHandler)} {callbackHandler} is null");
            }
            catch (Exception ex)
            {
                game = service.GetGameOnSaveUserScoreException(ex, gameName, gameUserName, gameScore, gameService);
                if (game == null)
                {
                    callbackHandler.Response = ex;
                }
            }
        }

        public static bool SaveUserScore(this app42ScoreBoardService service,
            string gameName, string gameUserName, double gameScore,
            GameService gameService)
        {
            Game game = null;
            if (service == null)
            {
                var message = $"{nameof(SaveUserScoreCallback)} {ErrPrefix}: {nameof(app42ScoreBoardService)} is null";
                Debug.WriteLine(message); throw new ArgumentNullException(message);
            }

            try
            {
                service.SaveUserScore(gameName, gameUserName, gameScore);
                return true;
            }
            catch (Exception ex)
            {
                game = service.GetGameOnSaveUserScoreException(ex, gameName, gameUserName, gameScore, gameService);
                return false;
            }
        }

        public static Game GetGameOnSaveUserScoreException(this app42ScoreBoardService service,
                                                                            Exception exception,
                                                                            string gameName, string gameUserName, double gameScore,
                                                                            GameService gameService)
        {
            var message = $"{nameof(GetGameOnSaveUserScoreException)} {ErrPrefix}: " +
                $"{ (exception == null ? nameof(App42Exception) : nameof(app42ScoreBoardService)) } is null";
            Game game = null;

            if (exception == null || service == null)
            {
                Debug.WriteLine(message); throw new ArgumentNullException(message);
            }

            /// Exception Caught
            if (!(exception is App42Exception _exception))
            {
                Debug.WriteLine($"{nameof(GetGameOnSaveUserScoreException)} not {nameof(App42Exception)} handled {ErrPrefix}: {exception.Message}");
                Debug.WriteLine(exception.StackTrace);
                return game;
            }
            /// Do exception Handling of Score Board Service functions.
            if (_exception.GetAppErrorCode() == 3002)
            {
                Game createGame = gameService.CreateGame(gameName, gameName);

                try
                {
                    game = service.SaveUserScore(gameName, gameUserName, gameScore);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Inner {ErrPrefix} is : " + ex);
                }
            }
            else if (_exception.GetAppErrorCode() == 1401)
            {
                Debug.WriteLine("Please verify your API_KEY and SECRET_KEY From AppHq Debug (Apphq.shephertz.com).");
            }
            else
            {
                Debug.WriteLine("Exception is : " + exception);
            }

            return game;
        }

        public static bool IsEmpty(this Game game) =>
            game?.description == App42.ScoreBoardService.EmptyDescription;
    }
}
