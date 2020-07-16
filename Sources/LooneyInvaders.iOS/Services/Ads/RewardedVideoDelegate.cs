using System.Diagnostics;
using AppodealXamariniOS;
using Foundation;

namespace LooneyInvaders.iOS.Services.Ads
{
    public class RewardedVideoDelegate : AppodealRewardedVideoDelegate
    {
        public override void RewardedVideoDidLoadAdIsPrecache(bool precache)
        {
            base.RewardedVideoDidLoadAdIsPrecache(precache);

            Debug.WriteLine("RewardedVideoDidLoadAd");
        }

        public override void RewardedVideoWillDismissAndWasFullyWatched(bool wasFullyWatched)
        {
            base.RewardedVideoWillDismissAndWasFullyWatched(wasFullyWatched);

            Debug.WriteLine("RewardedVideoWillDismiss");
        }

        public override void RewardedVideoDidFailToLoadAd()
        {
            base.RewardedVideoDidFailToLoadAd();

            Debug.WriteLine("RewardedVideoDidFailToLoadAd");
        }

        public override void RewardedVideoDidClick()
        {
            base.RewardedVideoDidClick();

            Debug.WriteLine("RewardedVideoDidClick");
        }

        public override void RewardedVideoDidPresent()
        {
            base.RewardedVideoDidPresent();

            Debug.WriteLine("RewardedVideoDidPresent");
        }

        public override void RewardedVideoDidFailToPresentWithError(NSError error)
        {
            base.RewardedVideoDidFailToPresentWithError(error);

            Debug.WriteLine("RewardedVideoDidFailToPresent");
        }

        public override void RewardedVideoDidFinish(float rewardAmount, string rewardName)
        {
            base.RewardedVideoDidFinish(rewardAmount, rewardName);

            Debug.WriteLine("RewardedVideoDidFinish");
        }
    }
}
