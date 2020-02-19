using System;
using CocosSharp;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;
using System.Threading.Tasks;

namespace LooneyInvaders.Layers
{
    public class MyStatsAndRewards3Layer : CCLayerColorExt
    {
        private int _currentGunFrame = 1;
        private readonly CCSprite _imgGun;
        private readonly CCSprite _imgOffline;
        private readonly CCSprite _imgGetActivationCode;
        private readonly CCSpriteButton _btnSend;
        private CCLabel _lblCode;
        private string _code = "";

        public MyStatsAndRewards3Layer()
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            SetBackground("UI/Curtain-and-paper-background.jpg");


            while (GameAnimation.Instance.PreloadNextSpriteSheetRotate(Weapons.Compact, null)) { }

            var btnBack = AddButton(2, 578, "UI/back-button-untapped.png", "UI/back-button-tapped.png", 100, ButtonType.Back);
            btnBack.OnClick += BtnBack_OnClick;
            Shared.GameDelegate.OnBackButton += BtnBack_OnClick;

			var btnBackThrow = AddButton(148, 578, "UI/back-to-home-button-untapped.png", "UI/back-to-home-button-tapped.png", 100, ButtonType.Back);
            btnBackThrow.OnClick += BtnBackThrow_OnClick;
            Shared.GameDelegate.OnBackButton += BtnBackThrow_OnClick;

            var btnForward = AddButton(930, 578, "UI/forward-button-untapped.png", "UI/forward-button-tapped.png", 100, ButtonType.Forward);
            btnForward.OnClick += BtnForward_OnClick;

			AddImage(287, 560, "UI/My-stats-&-rewards-title-text.png");
            AddImage(829, 592, "UI/My-stats-&-rewards-page3_8--text.png");
            AddImage(191, 495, "UI/My-stats-&-rewards-reward-compact-sprayer-text.png");

            var frame = GameAnimation.Instance.GetRotateFrame(Weapons.Compact, null, 0);
            _imgGun = AddImage(118, 80, frame);
            _imgGun.Scale = 2.0f;

            if (Player.Instance.GetWeapon(Weapons.Compact))
            {
                AddImage(260, 95, "UI/My-stats-&-rewards-reward-unlocked.png");

                _imgGetActivationCode = AddImage(245, 50, "UI/My-stats-&-rewards-get-download-activation-code-text.png");

                _btnSend = AddButton(185, 42, "UI/check-button-untapped_old.png", "UI/check-button-tapped_old.png");
                _btnSend.OnClick += BtnSend_OnClick;

                _imgOffline = AddImage(300, 230, "UI/My-stats-&-rewards-no-internet-connection-notification.png");
                _imgOffline.Visible = false;
            }
            else
            {
                _imgGetActivationCode = AddImage(245, 50, "UI/My-stats-&-rewards-get-download-activation-code-text.png");

                _btnSend = AddButton(185, 42, "UI/check-button-tapped_old.png", "UI/check-button-tapped_old.png");
                _btnSend.ButtonType = ButtonType.CannotTap;

                AddImage(260, 95, "UI/My-stats-&-rewards-reward-locked.png");
            }


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
                _code = RewardsManager.GetWeaponRewardCode(Weapons.Compact);
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

            TransitionToLayer(new MyStatsAndRewards2Layer());
        }

		private async void BtnBackThrow_OnClick(object sender, EventArgs e)
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            var newLayer = new MainScreenLayer();
            await TransitionToLayerCartoonStyleAsync(newLayer);
        }

        private void BtnForward_OnClick(object sender, EventArgs e)
        {
            TransitionToLayer(new MyStatsAndRewards4Layer());
        }

        private void RotateGun(float dt)
        {
            if (_currentGunFrame < 47) _currentGunFrame++;
            else _currentGunFrame = 0;

            var frame = GameAnimation.Instance.GetRotateFrame(Weapons.Compact, null, _currentGunFrame);

            ChangeSpriteImage(_imgGun, frame);
        }
    }
}
