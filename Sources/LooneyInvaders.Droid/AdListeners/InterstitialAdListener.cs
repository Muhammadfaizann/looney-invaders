using System;
using Android.Runtime;
using Com.Appodeal.Ads;

namespace LooneyInvaders.Droid
{
    public class InterstitialAdListener : Java.Lang.Object, IInterstitialCallbacks
    {
        public InterstitialAdListener() { }

        public InterstitialAdListener(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer) { }

        public void OnInterstitialLoaded(bool b) { }
        public void OnInterstitialFailedToLoad() { Model.AdManager.InterstitialAdFailedToLoad(); }
        public void OnInterstitialShown() { Model.AdManager.InterstitialAdOpened(); }
        public void OnInterstitialClosed() { Model.AdManager.InterstitialAdClosed(); }
        public void OnInterstitialClicked() { }
    }
}
