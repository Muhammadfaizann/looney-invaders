using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;
using System.Threading.Tasks;


namespace LooneyInvaders.Layers
{
    public class MyStatsAndRewards5Layer : CCLayerColorExt
    {
        int _currentGunFrame = 1;
        readonly CCSprite imgGun;
        readonly CCSprite imgOffline;
        readonly CCSprite imgGetActivationCode;
        readonly CCSpriteButton btnSend;
        CCLabel lblCode;
        string code = "";

        public MyStatsAndRewards5Layer()
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            this.SetBackground("UI/Curtain-and-paper-background.jpg");

            while (GameAnimation.Instance.PreloadNextSpriteSheetRotate(null, ENEMIES.HITLER)) { }

            CCSpriteButton btnBack = this.AddButton(2, 578, "UI/back-button-untapped.png", "UI/back-button-tapped.png", 100, BUTTON_TYPE.Back);
            btnBack.OnClick += BtnBack_OnClick;
            Shared.GameDelegate.OnBackButton += BtnBack_OnClick;

			CCSpriteButton btnBackThrow = this.AddButton(148, 578, "UI/back-to-home-button-untapped.png", "UI/back-to-home-button-tapped.png", 100, BUTTON_TYPE.Back);
            btnBackThrow.OnClick += BtnBackThrow_OnClick;
            Shared.GameDelegate.OnBackButton += BtnBackThrow_OnClick;

            CCSpriteButton btnForward = this.AddButton(930, 578, "UI/forward-button-untapped.png", "UI/forward-button-tapped.png", 100, BUTTON_TYPE.Forward);
            btnForward.OnClick += BtnForward_OnClick;

			AddImage(287, 560, "UI/My-stats-&-rewards-title-text.png");
            AddImage(829, 592, "UI/My-stats-&-rewards-page5_8--text.png");
            AddImage(191, 495, "UI/My-stats-&-rewards-reward-adolf-hitler-text.png");

            this.AddImage(191, 430, "UI/My-stats-&-rewards-poland-text.png");
            if(Player.Instance.GetSavedCountries(BATTLEGROUNDS.POLAND)>0) this.AddImage(415, 432, "UI/My-stats-&-rewards-country-defended-symbol.png"); else this.AddImage(415, 432, "UI/My-stats-&-rewards-country-not-defended-symbol.png");

            this.AddImage(191, 368, "UI/My-stats-&-rewards-denmark-text.png");
            if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.DENMARK) > 0) this.AddImage(415, 370, "UI/My-stats-&-rewards-country-defended-symbol.png"); else this.AddImage(415, 370, "UI/My-stats-&-rewards-country-not-defended-symbol.png");

            this.AddImage(191, 306, "UI/My-stats-&-rewards-norway-text.png");
            if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.NORWAY) > 0) this.AddImage(415, 308, "UI/My-stats-&-rewards-country-defended-symbol.png"); else this.AddImage(415, 308, "UI/My-stats-&-rewards-country-not-defended-symbol.png");

            this.AddImage(191, 244, "UI/My-stats-&-rewards-france-text.png");
            if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.FRANCE) > 0) this.AddImage(415, 246, "UI/My-stats-&-rewards-country-defended-symbol.png"); else this.AddImage(415, 246, "UI/My-stats-&-rewards-country-not-defended-symbol.png");

            this.AddImage(191, 182, "UI/My-stats-&-rewards-england-text.png");
            if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.ENGLAND) > 0) this.AddImage(415, 184, "UI/My-stats-&-rewards-country-defended-symbol.png"); else this.AddImage(415, 184, "UI/My-stats-&-rewards-country-not-defended-symbol.png");

            CCSpriteFrame frame = GameAnimation.Instance.GetRotateFrame(null, ENEMIES.HITLER, 0);
            imgGun = this.AddImage(635, 80, frame);
            imgGun.Scale = 2.0f;

            imgGetActivationCode = this.AddImage(245, 50, "UI/My-stats-&-rewards-get-download-activation-code-text.png");                                    
            if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.ENGLAND) > 0)
            {
                this.AddImage(181, 95, "UI/My-stats-&-rewards-reward-unlocked.png");
                btnSend = this.AddButton(185, 42, "UI/check-button-untapped.png", "UI/check-button-tapped.png");
                btnSend.OnClick += BtnSend_OnClick;
            }
            else
            {
                this.AddImage(181, 95, "UI/My-stats-&-rewards-reward-locked.png");
                btnSend = this.AddButton(185, 42, "UI/check-button-tapped.png", "UI/check-button-untapped.png");
                btnSend.Enabled = false;
            }

            imgOffline = this.AddImage(300, 230, "UI/My-stats-&-rewards-no-internet-connection-notification.png");
            imgOffline.Visible = false;

            this.Schedule(rotateGun, 0.1f);
        }

        private void BtnSend_OnClick(object sender, EventArgs e)
        {
            if (NetworkConnectionManager.IsInternetConnectionAvailable() == false)
            {
                imgOffline.Visible = true;
                return;
            }

            imgOffline.Visible = false;
            btnSend.Visible = false;
            imgGetActivationCode.Visible = false;

            this.AddImage(175, 20, "UI/My-stats-&-rewards-your-activation-code-text.png");

            getRewardCode();
        }

        private async void getRewardCode()
        {
            lblCode = this.AddLabel(530, 76, "getting code..", "Fonts/AktivGroteskBold", 16, CCColor3B.Black);

            await Task.Run(() => {
                code = RewardsManager.GetEnemyRewardCode(ENEMIES.HITLER);
                this.Schedule(displayCode, 0.1f);
            });
        }

        private void displayCode(float dt)
        {
            this.Children.Remove(lblCode);
            lblCode = this.AddLabel(530, 76, code, "Fonts/AktivGroteskBold", 16, CCColor3B.Black);
        }

        private void BtnBack_OnClick(object sender, EventArgs e)
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            this.TransitionToLayer(new MyStatsAndRewards4Layer());
        }

		private void BtnBackThrow_OnClick(object sender, EventArgs e)
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            this.TransitionToLayerCartoonStyle(new MainScreenLayer());
        }

        private void BtnForward_OnClick(object sender, EventArgs e)
        {
            this.TransitionToLayer(new MyStatsAndRewards6Layer());
        }

        private void rotateGun(float dt)
        {
            if (_currentGunFrame < 47) _currentGunFrame++;
            else _currentGunFrame = 0;

            CCSpriteFrame frame = GameAnimation.Instance.GetRotateFrame(null, ENEMIES.HITLER, _currentGunFrame);

            this.ChangeSpriteImage(imgGun, frame);
        }
    }
}
