using Plugin.Connectivity;

namespace LooneyInvaders.Model
{
    public class NetworkConnectionManager
    {
        public static bool IsInternetConnectionAvailable()
        {
            return CrossConnectivity.Current.IsConnected;
        }
    }
}
