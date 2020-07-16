using System.Threading.Tasks;
using AppodealXamariniOS;
using UIKit;

namespace LooneyInvaders.iOS.Services.Ads
{
    public static class AppodealAdsHelper
    {
        public enum AdType : ulong
        {
            Interstitial = AppodealShowStyle.Interstitial,
            BannerTop = AppodealShowStyle.BannerTop,
            Banner = AppodealShowStyle.BannerBottom,
            Rewarded = AppodealAdType.RewardedVideo
        }

        public static int LoadingPauseMilliseconds { get; set; }

        public static async Task LoadAsync(this AdType type, bool show = true)
        {
            var ad = (AppodealShowStyle)type;
            if (!Appodeal.IsReadyForShowWithStyle(ad))
            {
                Appodeal.CacheAd(type.ToAppodealType());

                if (show)
                {
                    await Task.Delay(LoadingPauseMilliseconds);
                }
            }

            if (show)
            {
                if (UIApplication.SharedApplication.Windows[0]?.RootViewController is ViewController root)
                {
                    Appodeal.ShowAd(ad, root);
                }
            }
        }

        private static AppodealAdType ToAppodealType(this AdType type)
        {
            switch (type)
            {
                case AdType.Banner:
                case AdType.BannerTop: return AppodealAdType.Banner;
                case AdType.Interstitial: return AppodealAdType.Interstitial;
                case AdType.Rewarded: return AppodealAdType.RewardedVideo;
                default: return AppodealAdType.Banner;
            }
        }
    }
}
