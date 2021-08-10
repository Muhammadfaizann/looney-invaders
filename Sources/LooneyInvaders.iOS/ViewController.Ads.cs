using UIKit;
using AppodealXamariniOS;
using LooneyInvaders.iOS.Services.Ads;
using LooneyInvaders.Model;
using LooneyInvaders.Services.App42;
using static LooneyInvaders.iOS.Services.Ads.AppodealAdsHelper;

namespace LooneyInvaders.iOS
{
    public partial class ViewController : UIViewController, IApp42ServiceInitialization
    {
        private void AddBannerToWindowTop()
        {
            if (!_adOnWindow)
            {
                BeginInvokeOnMainThread(async () => await AdType.BannerTop.LoadAsync());
                _adOnWindow = true;
            }
        }

        private void AddBannerToWindowBottom()
        {
            if (!_adOnWindow)
            {
                BeginInvokeOnMainThread(async () => await AdType.Banner.LoadAsync());
                _adOnWindow = true;
            }
        }

        private void HideBanner()
        {
            BeginInvokeOnMainThread(Appodeal.HideBanner);
            _adOnWindow = false;
        }

        public void ShowInterstitial() => BeginInvokeOnMainThread(async () => await AdType.Interstitial.LoadAsync());

        public void LoadInterstitial() => BeginInvokeOnMainThread(async () => await AdType.Interstitial.LoadAsync(false));
    }
}
