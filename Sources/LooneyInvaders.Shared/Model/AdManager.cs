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

        public static void ClearEvents()
        {
            OnInterstitialAdOpened = null;
            OnInterstitialAdClosed = null;
            OnInterstitialAdFailedToLoad = null;
        }

        public static void ShowBannerTop()
        {
            if (Settings.Instance.Advertisements) 
                ShowBannerTopHandler?.Invoke();
        }

        public static void ShowBannerBottom()
        {
            if (Settings.Instance.Advertisements) 
                ShowBannerBottomHandler?.Invoke();
        }

        public static void HideBanner()
        {
            if (Settings.Instance.Advertisements) 
                HideBannerHandler?.Invoke();
        }

        public static void LoadInterstitial()
        {
            LoadInterstitialHandler?.Invoke();
        }

        public static void ShowInterstitial()
        {
            ShowInterstitialHandler?.Invoke();
        }

        public static void HideInterstitial()
        {
            HideInterstitialHandler?.Invoke();
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
        }
    }
}