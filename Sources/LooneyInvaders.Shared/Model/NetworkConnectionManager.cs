using System;
using Xamarin.Essentials;
using Access = Xamarin.Essentials.NetworkAccess;

namespace LooneyInvaders.Model
{
    public class NetworkConnectionManager
    {
        public static event EventHandler ConnectionChanged;

        static NetworkConnectionManager()
        {
            Connectivity.ConnectivityChanged += ConnectionChangedHandler;
        }

        private static void ConnectionChangedHandler(object sender, EventArgs args)
        {
            var @event = ConnectionChanged;
            @event?.Invoke(sender, EventArgs.Empty);
        }

        public static bool IsInternetConnectionAvailable()
        {
            return Connectivity.NetworkAccess == Access.Internet;
        }

        public static void ClearConnectionChangedEvent()
        {
            ConnectionChanged = null;
        }
    }
}
