using System;
using System.Threading.Tasks;
using LooneyInvaders.Model;
using LooneyInvaders.Shared;

namespace LooneyInvaders.Services
{
    public static class FacebookLikesHelper
    {
        public const string PageId = "101000795058301";
        public const string PageUrl = "https://www.facebook.com/Testing-API-by-maxoiduss-101000795058301";

        public static Action DisableCreditButtonAction;

        public static async Task AddCreditsIfPageIsLiked()
        {
            if (GameDelegate.FacebookService.LoginState == LoginState.Success)
            {
                var currentFBLikesCount = await GameDelegate.FacebookService.CountPageLikes(PageId);
                if (Player.Instance.CachedFacebookLikesCount < currentFBLikesCount)
                {
                    Player.Instance.Credits += 4000;
                    Player.Instance.FacebookLikeUsed = true;

                    DisableCreditButtonAction?.Invoke();
                }
            }
        }
    }
}
