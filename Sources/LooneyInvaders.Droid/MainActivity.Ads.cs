using System;
using Android.App;
using Android.Hardware;
using Com.Appodeal.Ads;
using LooneyInvaders.Model;
using LooneyInvaders.Services.App42;
using static LooneyInvaders.Droid.Helpers.AppodealAdsHelper;

namespace LooneyInvaders.Droid
{
    public partial class MainActivity : Activity, ISensorEventListener, IApp42ServiceInitialization, IInterstitialCallbacks//, IBannerCallbacks
    {
        private const string AppodealApiKey = "c0502298783c2decd053ad8514ee4cf2fa08d25e1f676360";

        private readonly int requiredAdTypes = AdType.Interstitial.ToInt();
        private bool _isAdsShoving;
        private bool _wasResumed;
        // Do not delete this bunch of code
        /*public void OnBannerClicked() { }
        public void OnBannerFailedToLoad() { }
        public void OnBannerLoaded(int p0, bool p1) { }
        public void OnBannerShown() { }
        public void OnBannerExpired() { }
        public void OnBannerShowFailed() { }*/

        public void OnInterstitialLoaded(bool b) { }
        public void OnInterstitialFailedToLoad() => AdManager.InterstitialAdFailedToLoad();
        public void OnInterstitialShown() => AdManager.InterstitialAdOpened();
        public void OnInterstitialClosed() => AdManager.InterstitialAdClosed();
        public void OnInterstitialClicked() { }
        public void OnInterstitialExpired() { }
        public void OnInterstitialShowFailed() => AdManager.InterstitialAdFailedToLoad();

        //public void ShowBannerBottom() => RunOnUiThread(async () => await AdType.Banner.LoadAsync(this));
        // Do not delete this bunch of code
        /*public void HideBanner() => RunOnUiThread(() =>
        {
            AdType.Banner.Hide(this);
        });*/

        public void ShowInterstitial()
        {
            _isAdsShoving = true;
            Settings.Instance.TimeWhenPageAdsLeaved = default(DateTime);

            RunOnUiThread(async () => await AdType.Interstitial.LoadAsync(this));
        }

        public void LoadInterstitial() => RunOnUiThread(async () => await AdType.Interstitial.LoadAsync(this, false));

        public void HideInterstitial() => RunOnUiThread(() => AdType.Interstitial.Hide(this));
    }
}
