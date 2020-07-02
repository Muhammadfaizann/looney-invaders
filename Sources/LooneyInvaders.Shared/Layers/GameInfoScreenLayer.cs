using System;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;

namespace LooneyInvaders.Layers
{
    public class GameInfoScreenLayer : CCLayerColorExt
    {   
        public GameInfoScreenLayer()
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            SetBackground("UI/background.png");

            var btnBack = AddButton(2, 578, "UI/back-button-untapped.png", "UI/back-button-tapped.png", 100, ButtonType.Back);
            btnBack.OnClick += BtnBack_OnClick;
            Shared.GameDelegate.OnBackButton += BtnBack_OnClick;

            AddImage(400, 573, "UI/Game-info-game-info-text.png");            

            var btnAboutGame = AddButton(300, 480, "UI/Game-info-about-the-game-button-untapped.png", "UI/Game-info-about-the-game-button-tapped.png");
            btnAboutGame.OnClick += BtnAboutGame_OnClick;

            var btnPrivacyPolicy = AddButton(300, 400, "UI/Game-info-privacy-policy-untapped.png", "UI/Game-info-privacy-policy-tapped.png");
            btnPrivacyPolicy.OnClick += BtnPrivacyPolicy_OnClick;

            var btnMyStats = AddButton(300, 320, "UI/Game-info-my-stats-and-rewards-untapped.png", "UI/Game-info-my-stats-and-rewards-tapped.png");
            btnMyStats.OnClick += BtnMyStats_OnClick;

            var btnWebSite = AddButton(300, 240, "UI/Game-info-our-website-untapped.png", "UI/Game-info-our-website-tapped.png");
            btnWebSite.OnClick += BtnWebSite_OnClick;

            var btnFacebook = AddButton(300, 160, "UI/Game-info-like-us-on-facebook-untapped.png", "UI/Game-info-like-us-on-facebook-tapped.png");
            btnFacebook.OnClick += BtnFacebook_OnClick;

            var btnTwitter = AddButton(300, 80, "UI/Game-info-follow-us-on-twitter-untapped.png", "UI/Game-info-follow-us-on-twitter-tapped.png");
            btnTwitter.OnClick += BtnTwitter_OnClick;

            AdManager.ShowBannerBottom();

            ScheduleOnce(FreeAllSpriteSheets, 0.54f);
        }

        private void FreeAllSpriteSheets(float delta)
        {
            GameAnimation.Instance.FreeAllSpriteSheets(true);
        }


        private void BtnTwitter_OnClick(object sender, EventArgs e)
        {
            GameEnvironment.OpenWebPage("http://www.twitter.com/looneyinvaders");
        }

        private void BtnFacebook_OnClick(object sender, EventArgs e)
        {
            GameEnvironment.OpenWebPage("http://www.facebook.com/looneyinvaders");
        }

        private void BtnWebSite_OnClick(object sender, EventArgs e)
        {
            GameEnvironment.OpenWebPage("http://www.looneyinvaders.com");
        }

        private async void BtnPrivacyPolicy_OnClick(object sender, EventArgs e)
        {
            AdManager.HideBanner();

            var newLayer = new PrivacyPolicyScreenLayer();
            await TransitionToLayerCartoonStyleAsync(newLayer);
        }

        private async void BtnAboutGame_OnClick(object sender, EventArgs e)
        {
            AdManager.HideBanner();

            var newLayer = new AboutGameScreenLayer();
            await TransitionToLayerCartoonStyleAsync(newLayer);
        }

        private async void BtnMyStats_OnClick(object sender, EventArgs e)
        {
            AdManager.HideBanner();

            var newLayer = new MyStatsAndRewards1Layer();
            await TransitionToLayerCartoonStyleAsync(newLayer);
        }

        private async void BtnBack_OnClick(object sender, EventArgs e)
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();
            AdManager.HideBanner();

            var newLayer = new MainScreenLayer();
            await TransitionToLayerCartoonStyleAsync(newLayer);
        }
    }
}