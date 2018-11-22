using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Gms.Ads;

namespace LooneyInvaders.Droid
{
    class AdListenerEx : AdListener
    {
        AdView ad;        

        public AdListenerEx(AdView ad)
        {
            this.ad = ad;
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
            if (AdLoaded != null) this.AdLoaded();
            base.OnAdLoaded();            

            ad.BringToFront();
        }

        public override void OnAdClosed()
        {
            if (AdClosed != null) this.AdClosed();
            base.OnAdClosed();
        }
        public override void OnAdOpened()
        {
            if (AdOpened != null) this.AdOpened();
            base.OnAdOpened();
        }
    }

    class AdListenerInterstitial : AdListener
    {
        InterstitialAd _intAd;
        Activity _activity;

        public AdListenerInterstitial(InterstitialAd intAd, Activity activity)
        {
            this._intAd = intAd;
            this._activity = activity;
        }

        public override void OnAdLoaded()
        {
            base.OnAdLoaded();
        }

        public override void OnAdClosed()
        {
            base.OnAdClosed();

            Console.WriteLine("Interstitial ad closed");

            LooneyInvaders.Model.AdMobManager.InterstitialAdClosed();

            var requestbuilder = new AdRequest.Builder();
            requestbuilder.AddTestDevice(AdRequest.DeviceIdEmulator);
            requestbuilder.AddTestDevice("C663A5E7C7E3925C26A199E85E3E39D6");
            _intAd.LoadAd(requestbuilder.Build());

            // remove navigation bar
            View decorView = _activity.Window.DecorView;
            var uiOptions = (int)decorView.SystemUiVisibility;
            var newUiOptions = (int)uiOptions;
            newUiOptions |= (int)SystemUiFlags.HideNavigation;
            newUiOptions |= (int)SystemUiFlags.ImmersiveSticky;
            newUiOptions |= (int)SystemUiFlags.Fullscreen;
            decorView.SystemUiVisibility = (StatusBarVisibility)newUiOptions;
        }
        public override void OnAdOpened()
        {
            base.OnAdOpened();

            Console.WriteLine("Interstitial ad opened");

            LooneyInvaders.Model.AdMobManager.InterstitialAdOpened();
        }

        public override void OnAdFailedToLoad(int errorCode)
        {            
            base.OnAdFailedToLoad(errorCode);

            Console.WriteLine("Interstitial ad failed to load. Error code: " + errorCode.ToString());

            LooneyInvaders.Model.AdMobManager.InterstitialAdFailedToLoad();
        }
    }
}