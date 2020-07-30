using System;
using Android.App;
using Android.Hardware;
using Com.Appodeal.Ads;
using LooneyInvaders.Model;
using LooneyInvaders.Services.App42;
using static LooneyInvaders.Droid.Helpers.AppodealAdsHelper;

namespace LooneyInvaders.Droid
{
    public partial class MainActivity : Activity, ISensorEventListener, IApp42ServiceInitialization, IInterstitialCallbacks, IBannerCallbacks
    {
        private const string AppodealApiKey = "c0502298783c2decd053ad8514ee4cf2fa08d25e1f676360";

        private readonly int requiredAdTypes = (int)AdType.Interstitial
                                             | (int)AdType.Rewarded
                                             | (int)AdType.Banner
                                             | (int)AdType.BannerTop;
        private bool _isAdsShoving;
        private bool _wasResumed;

        public void OnBannerClicked() { }
        public void OnBannerFailedToLoad() { }
        public void OnBannerLoaded(int p0, bool p1) { }
        public void OnBannerShown() { }

        public void OnInterstitialLoaded(bool b) { }
        public void OnInterstitialFailedToLoad() => AdManager.InterstitialAdFailedToLoad();
        public void OnInterstitialShown() => AdManager.InterstitialAdOpened();
        public void OnInterstitialClosed() => AdManager.InterstitialAdClosed();
        public void OnInterstitialClicked() { }

        protected override void OnResume()
        {
            base.OnResume();

            //if (_wasResumed)
            {   //ToDo: find out what the problem with resuming (egl_swap)
                Appodeal.OnResume(this, requiredAdTypes); //is it needed
            }
            //else _wasResumed = true;
        }

        public void ShowBannerTop() => RunOnUiThread(async () => await AdType.BannerTop.LoadAsync(this));

        public void ShowBannerBottom() => RunOnUiThread(async () => await AdType.Banner.LoadAsync(this));

        public void HideBanner() => RunOnUiThread(() =>
        {
            AdType.Banner.Hide(this);
            AdType.BannerTop.Hide(this);
        });

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
