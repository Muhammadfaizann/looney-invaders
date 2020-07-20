using System.Diagnostics;
using AppodealXamariniOS;
using LooneyInvaders.Model;

namespace LooneyInvaders.iOS.Services.Ads
{
    public class InterstitialDelegate : AppodealInterstitialDelegate
    {
        public override void InterstitialDidLoadAdIsPrecache(bool precache)
        {
            base.InterstitialDidLoadAdIsPrecache(precache);

            Debug.WriteLine("InterstitialDidLoadAdisPrecache");
        }

        public override void InterstitialDidFailToLoadAd()
        {
            base.InterstitialDidFailToLoadAd();

            AdManager.InterstitialAdFailedToLoad();
            Debug.WriteLine("InterstitialDidFailToLoadAd");
        }

        public override void InterstitialDidFailToPresent()
        {
            base.InterstitialDidFailToPresent();

            Debug.WriteLine("InterstitialDidFailToPresent");
        }

        public override void InterstitialWillPresent()
        {
            base.InterstitialWillPresent();

            AdManager.InterstitialAdOpened();
            Debug.WriteLine("InterstitialWillPresent");
        }

        public override void InterstitialDidDismiss()
        {
            base.InterstitialDidDismiss();

            AdManager.InterstitialAdClosed();
            Debug.WriteLine("InterstitialDidDismiss");
        }

        public override void InterstitialDidClick()
        {
            base.InterstitialDidClick();

            Debug.WriteLine("InterstitialDidClick");
        }
    }
}
