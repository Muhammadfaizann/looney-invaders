using System;
using Plugin.Connectivity;

namespace LooneyInvaders.Model
{
    public class NetworkConnectionManager
    {
        public static event EventHandler ConnectionChanged;

        static NetworkConnectionManager()
        {
            CrossConnectivity.Current.ConnectivityChanged += ConnectionChangedHandler;
        }

        private static void ConnectionChangedHandler(object sender, EventArgs args)
        {
            var @event = ConnectionChanged;
            @event?.Invoke(typeof(CrossConnectivity), EventArgs.Empty);
        }

        public static bool IsInternetConnectionAvailable()
        {
            return CrossConnectivity.Current.IsConnected;
        }
    }
}
