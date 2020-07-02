using System;
using Android.Runtime;
using Com.Appodeal.Ads;

namespace LooneyInvaders.Droid
{
    public class BannerAdListener : Java.Lang.Object, IBannerCallbacks
    {
        public BannerAdListener() { }

        public BannerAdListener(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer) { }

        public void OnBannerClicked()
        {
            
        }

        public void OnBannerFailedToLoad()
        {
            
        }

        public void OnBannerLoaded(int p0, bool p1)
        {
            
        }

        public void OnBannerShown()
        {
            
        }
    }
}
