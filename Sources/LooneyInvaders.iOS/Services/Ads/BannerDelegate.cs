using System.Diagnostics;
using AppodealXamariniOS;

namespace LooneyInvaders.iOS.Services.Ads
{
    public class BannerDelegate : AppodealBannerDelegate
    {
        public override void BannerDidFailToLoadAd()
        {
            base.BannerDidFailToLoadAd();

            Debug.WriteLine("BannerDidFailToLoadAd");
        }

        public override void BannerDidLoadAdIsPrecache(bool precache)
        {
            base.BannerDidLoadAdIsPrecache(precache);

            Debug.WriteLine("BannerDidLoadAdIsPrecache");
        }

        public override void BannerDidShow()
        {
            base.BannerDidShow();

            Debug.WriteLine("BannerDidShow");
        }

        public override void BannerDidClick()
        {
            base.BannerDidClick();

            Debug.WriteLine("BannerDidClick");
        }

        public override void BannerDidExpired()
        {
            base.BannerDidExpired();

            Debug.WriteLine("BannerDidExpired");
        }
    }
}
