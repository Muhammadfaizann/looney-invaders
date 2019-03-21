using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
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
