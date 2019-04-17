using System;
using Android.App;
using Android.Views;
using Android.Gms.Ads;

namespace LooneyInvaders.Droid
{
    internal class AdListenerEx : AdListener
    {
        private readonly AdView _ad;

        public AdListenerEx(AdView ad)
        {
            _ad = ad;
        }

        // Declare the delegate (if using non-generic pattern). 
        public delegate void AdLoadedEvent();
        public delegate void AdClosedEvent();
        public delegate void AdOpenedEvent();

        // Declare the event. 
        public event AdLoadedEvent AdLoaded;
        public event AdClosedEvent AdClosed;
        public event AdOpenedEvent AdOpened;

        public override void OnAdLoaded()
        {
            AdLoaded?.Invoke();
            base.OnAdLoaded();

            _ad.BringToFront();
        }

        public override void OnAdClosed()
        {
            AdClosed?.Invoke();
            base.OnAdClosed();
        }
        public override void OnAdOpened()
        {
            AdOpened?.Invoke();
            base.OnAdOpened();
        }
    }

    internal class AdListenerInterstitial : AdListener
    {
        private readonly InterstitialAd _intAd;
        private readonly Activity _activity;

        public AdListenerInterstitial(InterstitialAd intAd, Activity activity)
        {
            _intAd = intAd;
            _activity = activity;
        }

        public override void OnAdClosed()
        {
            base.OnAdClosed();

            Console.WriteLine("Interstitial ad closed");

            Model.AdMobManager.InterstitialAdClosed();

            var requestbuilder = new AdRequest.Builder();
            requestbuilder.AddTestDevice(AdRequest.DeviceIdEmulator);
            requestbuilder.AddTestDevice("C663A5E7C7E3925C26A199E85E3E39D6");
            _intAd.LoadAd(requestbuilder.Build());

            // remove navigation bar
            var decorView = _activity.Window.DecorView;
            var uiOptions = (int)decorView.SystemUiVisibility;
            var newUiOptions = uiOptions;
            newUiOptions |= (int)SystemUiFlags.HideNavigation;
            newUiOptions |= (int)SystemUiFlags.ImmersiveSticky;
            newUiOptions |= (int)SystemUiFlags.Fullscreen;
            decorView.SystemUiVisibility = (StatusBarVisibility)newUiOptions;
        }
        public override void OnAdOpened()
        {
            base.OnAdOpened();

            Console.WriteLine("Interstitial ad opened");

            Model.AdMobManager.InterstitialAdOpened();
        }

        public override void OnAdFailedToLoad(int errorCode)
        {
            base.OnAdFailedToLoad(errorCode);

            Console.WriteLine("Interstitial ad failed to load. Error code: " + errorCode);

            Model.AdMobManager.InterstitialAdFailedToLoad();
        }
    }
}