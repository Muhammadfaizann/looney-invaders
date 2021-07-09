using System;
using System.Threading.Tasks;
using Android.App;
using Com.Appodeal.Ads;

namespace LooneyInvaders.Droid.Helpers
{
    public static class AppodealAdsHelper
    {
        public static int ToInt(this AdType type) => type.Code;//NotifyType;//type.Code;

        public static int LoadingPauseMilliseconds { get; set; }

        public static async Task LoadAsync(this AdType type, Activity context, bool show = true)
        {
            ThrowIfActivityIsNull(context);

            var ad = type.ToInt();
            if (!Appodeal.IsLoaded(ad))
            {
                Appodeal.Cache(context, ad);

                if (show)
                {
                    await Task.Delay(LoadingPauseMilliseconds);
                }
            }

            if (show && Appodeal.CanShow(ad))
            {
                Appodeal.Show(context, ad);
            }
        }

        public static void Hide(this AdType type, Activity context)
        {
            ThrowIfActivityIsNull(context);

            Appodeal.Hide(context, type.ToInt());
        }

        private static void ThrowIfActivityIsNull(Activity context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
        }
    }
}
