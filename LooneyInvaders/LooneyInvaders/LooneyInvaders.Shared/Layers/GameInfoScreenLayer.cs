using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;

namespace LooneyInvaders.Layers
{
    public class GameInfoScreenLayer : CCLayerColorExt
    {   
        public GameInfoScreenLayer()
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            this.SetBackground("UI/background.png");

            CCSpriteButton btnBack = this.AddButton(2, 578, "UI/back-button-untapped.png", "UI/back-button-tapped.png", 100, BUTTON_TYPE.Back);
            btnBack.OnClick += BtnBack_OnClick;
            Shared.GameDelegate.OnBackButton += BtnBack_OnClick;

            this.AddImage(400, 573, "UI/Game-info-game-info-text.png");            

            CCSpriteButton btnAboutGame = this.AddButton(300, 480, "UI/Game-info-about-the-game-button-untapped.png", "UI/Game-info-about-the-game-button-tapped.png");
            btnAboutGame.OnClick += BtnAboutGame_OnClick;

            CCSpriteButton btnPrivacyPolicy = this.AddButton(300, 400, "UI/Game-info-privacy-policy-untapped.png", "UI/Game-info-privacy-policy-tapped.png");
            btnPrivacyPolicy.OnClick += BtnPrivacyPolicy_OnClick;

            CCSpriteButton btnMyStats = this.AddButton(300, 320, "UI/Game-info-my-stats-and-rewards-untapped.png", "UI/Game-info-my-stats-and-rewards-tapped.png");
            btnMyStats.OnClick += BtnMyStats_OnClick;

            CCSpriteButton btnWebSite = this.AddButton(300, 240, "UI/Game-info-our-website-untapped.png", "UI/Game-info-our-website-tapped.png");
            btnWebSite.OnClick += BtnWebSite_OnClick;

            CCSpriteButton btnFacebook = this.AddButton(300, 160, "UI/Game-info-like-us-on-facebook-untapped.png", "UI/Game-info-like-us-on-facebook-tapped.png");
            btnFacebook.OnClick += BtnFacebook_OnClick;

            CCSpriteButton btnTwitter = this.AddButton(300, 80, "UI/Game-info-follow-us-on-twitter-untapped.png", "UI/Game-info-follow-us-on-twitter-tapped.png");
            btnTwitter.OnClick += BtnTwitter_OnClick;

            AdMobManager.ShowBannerBottom();

            ScheduleOnce(freeAllSpriteSheets, 0.54f);
        }

        private void freeAllSpriteSheets(float delta)
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

        private void BtnPrivacyPolicy_OnClick(object sender, EventArgs e)
        {
            AdMobManager.HideBanner();

            this.TransitionToLayerCartoonStyle(new PrivacyPolicyScreenLayer());
        }

        private void BtnAboutGame_OnClick(object sender, EventArgs e)
        {
            AdMobManager.HideBanner();

            this.TransitionToLayerCartoonStyle(new AboutGameScreenLayer());
        }

        private void BtnMyStats_OnClick(object sender, EventArgs e)
        {
            AdMobManager.HideBanner();

            this.TransitionToLayerCartoonStyle(new MyStatsAndRewards1Layer());
        }

        private void BtnBack_OnClick(object sender, EventArgs e)
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();
            AdMobManager.HideBanner();

            this.TransitionToLayerCartoonStyle(new MainScreenLayer());
        }
    }
}