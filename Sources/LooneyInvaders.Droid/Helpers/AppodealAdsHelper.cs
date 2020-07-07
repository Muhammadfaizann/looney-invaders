using System;
using System.Threading.Tasks;
using Android.App;
using Com.Appodeal.Ads;

namespace LooneyInvaders.Droid.Helpers
{
    public static class AppodealAdsHelper
    {
        public enum AdType
        {
            Interstitial = Appodeal.INTERSTITIAL,
            Banner = Appodeal.BANNER_BOTTOM,
            BannerTop = Appodeal.BANNER_TOP,
            Rewarded = Appodeal.REWARDED_VIDEO
        }

        public static int LoadingPauseMilliseconds { get; set; }

        public static async Task LoadAsync(this AdType type, Activity context, bool show = true)
        {
            ThrowIfActivityIsNull(context);

            var ad = (int)type;
            if (!Appodeal.IsLoaded(ad))
            {
                Appodeal.Cache(context, ad);

                if (show)
                {
                    await Task.Delay(LoadingPauseMilliseconds);
                }
            }

            if (show)
            {
                Appodeal.Show(context, ad);
            }
        }

        public static void Hide(this AdType type, Activity context)
        {
            ThrowIfActivityIsNull(context);

            Appodeal.Hide(context, (int)type);
        }

        private static void ThrowIfActivityIsNull(Activity context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
        }
    }
}
