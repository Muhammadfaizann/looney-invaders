using System.Diagnostics;
using AppodealXamariniOS;
using Foundation;
using LooneyInvaders.Model;

namespace LooneyInvaders.iOS.Services.Ads
{
    public class InterstitialDelegate : AppodealInterstitialDelegate
    {
        [Export("interstitialDidDismiss")]
        public new void InterstitialDidDismiss()
        {
            AdManager.InterstitialAdClosed();
        }

        [Export("interstitialWillPresent")]
        public new void InterstitialWillPresent()
        {
            AdManager.InterstitialAdOpened();
        }

        public override void InterstitialDidLoadAdIsPrecache(bool precache)
        {
            Debug.WriteLine("InterstitialDidLoadAdisPrecache");
        }

        [Export("interstitialDidFailToLoadAd")]
        public new void InterstitialDidFailToLoadAd()
        {
            AdManager.InterstitialAdFailedToLoad();
        }

        public override void InterstitialDidFailToPresent()
        {
            base.InterstitialDidFailToPresent();

            Debug.WriteLine("InterstitialDidFailToPresent");
        }
    }
}
