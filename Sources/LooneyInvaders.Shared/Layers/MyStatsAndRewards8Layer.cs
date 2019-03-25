﻿using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;
using System.Threading.Tasks;

namespace LooneyInvaders.Layers
{
    public class MyStatsAndRewards8Layer : CCLayerColorExt
    {
        int _currentGunFrame = 1;
        readonly CCSprite _imgGun;
        readonly CCSprite _imgOffline;
        readonly CCSprite _imgGetActivationCode;
        readonly CCSpriteButton _btnSend;
        CCLabel _lblCode;
        string _code = "";

        public MyStatsAndRewards8Layer()
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            SetBackground("UI/Curtain-and-paper-background.jpg");

            while (GameAnimation.Instance.PreloadNextSpriteSheetRotate(null, ENEMIES.KIM)) { }

            CCSpriteButton btnBack = AddButton(2, 578, "UI/back-button-untapped.png", "UI/back-button-tapped.png", 100, BUTTON_TYPE.Back);
            btnBack.OnClick += BtnBack_OnClick;
            Shared.GameDelegate.OnBackButton += BtnBack_OnClick;

			CCSpriteButton btnBackThrow = AddButton(148, 578, "UI/back-to-home-button-untapped.png", "UI/back-to-home-button-tapped.png", 100, BUTTON_TYPE.Back);
            btnBackThrow.OnClick += BtnBackThrow_OnClick;
            Shared.GameDelegate.OnBackButton += BtnBackThrow_OnClick;

			AddImage(287, 560, "UI/My-stats-&-rewards-title-text.png");
            AddImage(829, 592, "UI/My-stats-&-rewards-page8_8--text.png");
            AddImage(191, 495, "UI/My-stats-&-rewards-reward-kim-jong-un-text.png");

            AddImage(191, 430, "UI/My-stats-&-rewards-south-korea-text.png");
            if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.SOUTH_KOREA) > 0) AddImage(530, 432, "UI/My-stats-&-rewards-country-defended-symbol.png"); else AddImage(530, 432, "UI/My-stats-&-rewards-country-not-defended-symbol.png");

            AddImage(191, 368, "UI/My-stats-&-rewards-israel-text.png");
            if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.ISRAEL) > 0) AddImage(530, 370, "UI/My-stats-&-rewards-country-defended-symbol.png"); else AddImage(530, 370, "UI/My-stats-&-rewards-country-not-defended-symbol.png");

            AddImage(191, 306, "UI/My-stats-&-rewards-japan-text.png");
            if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.JAPAN) > 0) AddImage(530, 308, "UI/My-stats-&-rewards-country-defended-symbol.png"); else AddImage(530, 308, "UI/My-stats-&-rewards-country-not-defended-symbol.png");

            AddImage(191, 244, "UI/My-stats-&-rewards-great-britain-text.png");
            if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.GREAT_BRITAIN) > 0) AddImage(530, 246, "UI/My-stats-&-rewards-country-defended-symbol.png"); else AddImage(530, 246, "UI/My-stats-&-rewards-country-not-defended-symbol.png");

            AddImage(191, 182, "UI/My-stats-&-rewards-united-states-text.png");
            if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.UNITED_STATES) > 0) AddImage(530, 184, "UI/My-stats-&-rewards-country-defended-symbol.png"); else AddImage(530, 184, "UI/My-stats-&-rewards-country-not-defended-symbol.png");

            CCSpriteFrame frame = GameAnimation.Instance.GetRotateFrame(null, ENEMIES.KIM, 0);
            _imgGun = AddImage(635, 80, frame);
            _imgGun.Scale = 2.0f;

            _imgGetActivationCode = AddImage(245, 50, "UI/My-stats-&-rewards-get-download-activation-code-text.png");
            if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.UNITED_STATES) > 0)
            {
                AddImage(181, 95, "UI/My-stats-&-rewards-reward-unlocked.png");
                _btnSend = AddButton(185, 42, "UI/check-button-untapped.png", "UI/check-button-tapped.png");
                _btnSend.OnClick += BtnSend_OnClick;
            }
            else
            {
                AddImage(191, 95, "UI/My-stats-&-rewards-reward-locked.png");
                _btnSend = AddButton(185, 42, "UI/check-button-tapped.png", "UI/check-button-untapped.png");
                _btnSend.ButtonType = BUTTON_TYPE.CannotTap;
            }

            _imgOffline = AddImage(300, 230, "UI/My-stats-&-rewards-no-internet-connection-notification.png");
            _imgOffline.Visible = false;

            Schedule(RotateGun, 0.1f);
        }

        private void BtnSend_OnClick(object sender, EventArgs e)
        {
            if (NetworkConnectionManager.IsInternetConnectionAvailable() == false)
            {
                _imgOffline.Visible = true;
                return;
            }

            _imgOffline.Visible = false;
            _btnSend.Visible = false;
            _imgGetActivationCode.Visible = false;

            AddImage(175, 20, "UI/My-stats-&-rewards-your-activation-code-text.png");

            GetRewardCode();
        }

        private async void GetRewardCode()
        {
            _lblCode = AddLabel(530, 76, "getting code..", "Fonts/AktivGroteskBold", 16, CCColor3B.Black);

            await Task.Run(() => {
                _code = RewardsManager.GetEnemyRewardCode(ENEMIES.KIM);
                Schedule(DisplayCode, 0.1f);
            });
        }

        private void DisplayCode(float dt)
        {
            Children.Remove(_lblCode);
            _lblCode = AddLabel(530, 76, _code, "Fonts/AktivGroteskBold", 16, CCColor3B.Black);
        }

        private void BtnBack_OnClick(object sender, EventArgs e)
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            TransitionToLayer(new MyStatsAndRewards7Layer());
        }

		private void BtnBackThrow_OnClick(object sender, EventArgs e)
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            TransitionToLayerCartoonStyle(new MainScreenLayer());
        }

        private void RotateGun(float dt)
        {
            if (_currentGunFrame < 47) _currentGunFrame++;
            else _currentGunFrame = 0;

            CCSpriteFrame frame = GameAnimation.Instance.GetRotateFrame(null, ENEMIES.KIM, _currentGunFrame);

            ChangeSpriteImage(_imgGun, frame);
        }
    }
}
