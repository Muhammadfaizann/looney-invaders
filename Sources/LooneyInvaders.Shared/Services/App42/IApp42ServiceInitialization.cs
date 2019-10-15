using System.Globalization;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.game;

namespace LooneyInvaders.Services.App42
{
    public interface IApp42ServiceInitialization
    {
        void CallInitOnApp42ServiceBuilder();
    }

    public static class App42ServiceBuilder
    {
        public static ServiceAPI API { get; private set; }
        public static GameService CommonGameService { get; private set; }
        public static int CommonDelayOnErrorMS { get; private set; }

        public static void Init(string apiKey, string secretKey, int delayOnErrorMS)
        {
            //Disabling any localization since shephertz.app42 doesn't recognize current culture
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;

            API = new ServiceAPI(apiKey, secretKey);
            CommonDelayOnErrorMS = delayOnErrorMS;
            CommonGameService = API.BuildGameService();
        }
    }
}
