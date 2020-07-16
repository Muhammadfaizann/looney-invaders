using AppodealXamariniOS;
using LooneyInvaders.Droid.Services.AdvertisementProvider;
using UIKit;

namespace LooneyInvaders.iOS.CustomRenderers
{
    public class IosAdvertisementProvider : IAdvertisementProvider
    {
        public void ShowBanner()
        {
            Appodeal.ShowAd(AppodealShowStyle.BannerBottom,
                UIApplication.SharedApplication.Windows[0].RootViewController);
        }
    }
}