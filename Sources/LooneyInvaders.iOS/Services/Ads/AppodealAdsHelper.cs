using System.Threading.Tasks;
using AppodealXamariniOS;
using LooneyInvaders.iOS.Extensions;

namespace LooneyInvaders.iOS.Services.Ads
{
    public static class AppodealAdsHelper
    {
        public enum AdType : ulong
        {
            Interstitial = AppodealShowStyle.Interstitial,
            BannerTop = AppodealShowStyle.BannerTop,
            Banner = AppodealShowStyle.BannerBottom,
            Rewarded = AppodealShowStyle.RewardedVideo
        }

        public static int LoadingPauseMilliseconds { get; set; }

        public static async Task LoadAsync(this AdType type, bool show = true)
        {
            var ad = (AppodealShowStyle)type.To<AppodealShowStyle>();
            if (!Appodeal.IsReadyForShowWithStyle(ad))
            {
                var toCache = (AppodealAdType)type.To<AppodealAdType>();
                Appodeal.CacheAd(toCache);

                if (show)
                {
                    await Task.Delay(LoadingPauseMilliseconds);
                }
            }

            if (show)
            {
                var root = ad.GetCurrentViewController();
                Appodeal.ShowAd(ad, root);
            }
        }

        private static System.Enum To<T>(this AdType type) where T : System.Enum
        {
            if (typeof (T) == typeof(AppodealAdType))
            {
                return type switch
                {
                    AdType.Banner or AdType.BannerTop => AppodealAdType.Banner,
                    AdType.Interstitial => AppodealAdType.Interstitial,
                    AdType.Rewarded => AppodealAdType.RewardedVideo,
                    _ => AppodealAdType.Interstitial,
                };
            }
            else if (typeof(T) == typeof(AppodealShowStyle))
            {
                return (AppodealShowStyle)type;
            }
            else throw new System.InvalidCastException("Error on casting in a method: " + nameof(To));
        }
    }
}
