using LooneyInvaders.Model.Facebook;
using LooneyInvaders.Shared;

namespace LooneyInvaders.Model
{
    public static class CreditsHelper
    {
        public static async void AddIfCurrentLikeCountMore()
        {
            if (GameDelegate.FacebookService.LoginState == LoginState.Success )
            {
                var currentLikeCount = await GameDelegate.FacebookService.CountPageLikes(PageData.PageId);
                
                if (Player.Instance.CachedLikeCount < currentLikeCount)
                {
                    Player.Instance.Credits += 4000;
                    Player.Instance.FacebookLikeUsed = true;
                }
            }
        }
    }
}