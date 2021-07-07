using System;

namespace LooneyInvaders.Model
{
    public class AdManager
    {
        public delegate void ShowBannerDelegate();

        public static ShowBannerDelegate ShowBannerTopHandler;
        public static ShowBannerDelegate ShowBannerBottomHandler;
        public static ShowBannerDelegate HideBannerHandler;

        public static ShowBannerDelegate LoadInterstitialHandler;
        public static ShowBannerDelegate ShowInterstitialHandler;
        public static ShowBannerDelegate HideInterstitialHandler;

        public static event EventHandler OnInterstitialAdOpened;
        public static event EventHandler OnInterstitialAdClosed;
        public static event EventHandler OnInterstitialAdFailedToLoad;
        public static event EventHandler OnInterstitialAdFailedToPreload;

        public static void ClearInterstitialEvents()
        {
            OnInterstitialAdOpened = null;
            OnInterstitialAdClosed = null;
            OnInterstitialAdFailedToLoad = null;
        }

        public static void ClearInterstitialEvents(
            EventHandler onAdOpenedHandler,
            EventHandler onAdClosedHandler = null,
            EventHandler onAdFailedToLoadHandler = null)
        {
            OnInterstitialAdOpened -= onAdOpenedHandler;
            OnInterstitialAdClosed -= onAdClosedHandler;
            OnInterstitialAdFailedToLoad -= onAdFailedToLoadHandler;
        }

        public static void ShowBannerTop()
        {   // Do not delete this bunch of code
            /*if (Settings.Instance.Advertisements)
            {
                if (NetworkConnectionManager.IsInternetConnectionAvailable())
                { ShowBannerTopHandler?.Invoke(); }
            }*/
        }

        public static void ShowBannerBottom()
        {   // Do not delete this bunch of code
            /*if (Settings.Instance.Advertisements)
            {
                if (NetworkConnectionManager.IsInternetConnectionAvailable())
                { ShowBannerBottomHandler?.Invoke(); }
            }*/
        }

        public static void HideBanner()
        {   // Do not delete this bunch of code
            /*if (Settings.Instance.Advertisements)
            { HideBannerHandler?.Invoke(); }*/
        }

        public static void LoadInterstitial()
        {
            if (Settings.Instance.Advertisements)
            {
                LoadInterstitialHandler?.Invoke();
            }
        }

        public static void ShowInterstitial()
        {
            if (Settings.Instance.Advertisements)
            {
                if (NetworkConnectionManager.IsInternetConnectionAvailable())
                {
                    ShowInterstitialHandler?.Invoke();
                }
                else InterstitialAdFailedToLoad();
            }
        }

        public static void HideInterstitial()
        {
            if (Settings.Instance.Advertisements)
            {
                HideInterstitialHandler?.Invoke();
            }
        }

        public static void InterstitialAdOpened()
        {
            OnInterstitialAdOpened?.Invoke(null, EventArgs.Empty);
        }

        public static void InterstitialAdClosed()
        {
            OnInterstitialAdClosed?.Invoke(null, EventArgs.Empty);
        }

        public static void InterstitialAdFailedToLoad()
        {
            OnInterstitialAdFailedToLoad?.Invoke(null, EventArgs.Empty);
            System.Diagnostics.Debug.WriteLine($"{nameof(OnInterstitialAdFailedToLoad)} called");
        }

        public static void InterstitialAdFailedToPreload()
        {
            OnInterstitialAdFailedToPreload?.Invoke(null, EventArgs.Empty);
            System.Diagnostics.Debug.WriteLine($"{nameof(OnInterstitialAdFailedToPreload)} called");
        }
    }
}