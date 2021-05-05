using System;
using CocosSharp;
using Xamarin.Essentials;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;

namespace LooneyInvaders.Layers
{
    public class PrivacyPolicyScreenLayer : CCLayerColorExt
    {
        private readonly string _adsPrivacyPolicyLink = "https://appodeal.com/privacy-policy/";
        private readonly CCSpriteButton _btnForward;
        private readonly CCSpriteButton _btnLinkToAdPrivacy; //Users/bass/Projects/looney-invaders/Sources/Content/Images/Hd/UI/link-to-appodeal-privacy.png
        private readonly CCSprite _imgPage;
        private readonly CCSprite _imgPageNumber;

        private int _activePage = 1;

        public PrivacyPolicyScreenLayer()
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            SetBackground("UI/Curtain-and-paper-background.jpg");

            AddImage(307, 570, "UI/privacy-policy-title-text.png", 500);

            var btnBack = AddButton(2, 578, "UI/back-button-untapped.png", "UI/back-button-tapped.png", 100, ButtonType.Back);
            btnBack.OnClick += BtnBack_OnClick;
            Shared.GameDelegate.OnBackButton += BtnBack_OnClick;

            var btnBackThrow = AddButton(148, 578, "UI/back-to-home-button-untapped.png", "UI/back-to-home-button-tapped.png", 100, ButtonType.Back);
            btnBackThrow.OnClick += BtnBackThrow_OnClick;
            Shared.GameDelegate.OnBackButton += BtnBackThrow_OnClick;

            _btnForward = AddButton(930, 578, "UI/forward-button-untapped.png", "UI/forward-button-tapped.png", 100, ButtonType.Forward);
            _btnForward.OnClick += BtnForward_OnClick;

            _btnLinkToAdPrivacy = AddButton(585, 330, "UI/link-to-appodeal-privacy.png", "UI/link-to-appodeal-privacy-tapped.png", 100, ButtonType.Link);
            _btnLinkToAdPrivacy.OnClick += BtnLinkToAdPrivacy_OnClick; ;
            _btnLinkToAdPrivacy.Visible = false;

            _imgPageNumber = AddImage(815, 592, "UI/about-the-game-page1-page-number.png");
            _imgPage = AddImage(197, 45, "UI/privacy-policy-page1-plain-text.png");
        }

        private void BtnLinkToAdPrivacy_OnClick(object sender, EventArgs e)
        {
            _ = Browser.OpenAsync(_adsPrivacyPolicyLink, BrowserLaunchMode.External);
        }

        private async void BtnBack_OnClick(object sender, EventArgs e)
        {
            if (_activePage == 1)
            {
                Shared.GameDelegate.ClearOnBackButtonEvent();

                var newLayer = new GameInfoScreenLayer();
                await TransitionToLayerCartoonStyleAsync(newLayer);
            }
            else
            {
                _activePage--;
                _btnForward.Visible = true;
                SetImages();                    
            }
        }

        private async void BtnBackThrow_OnClick(object sender, EventArgs e)
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            var newLayer = new MainScreenLayer();
            await TransitionToLayerCartoonStyleAsync(newLayer);
        }

        private void SetImages()
        {
            switch (_activePage)
            {
                case 1:
                    ChangeSpriteImage(_imgPageNumber, "UI/privacy-policy-page1-page-number.png");
                    ChangeSpriteImage(_imgPage, "UI/privacy-policy-page1-plain-text.png");
                    break;
                case 2:
                    ChangeSpriteImage(_imgPageNumber, "UI/privacy-policy-page2-page-number.png");
                    ChangeSpriteImage(_imgPage, "UI/privacy-policy-page2-plain-text.png");
                    break;
                case 3:
                    ChangeSpriteImage(_imgPageNumber, "UI/privacy-policy-page3-page-number.png");
                    ChangeSpriteImage(_imgPage, "UI/privacy-policy-page3-plain-text.png");
                    _btnLinkToAdPrivacy.Visible = false;
                    break;
                case 4:
                    ChangeSpriteImage(_imgPageNumber, "UI/privacy-policy-page4-page-number.png");
                    ChangeSpriteImage(_imgPage, "UI/privacy-policy-page4-plain-text.png");
                    _btnLinkToAdPrivacy.Visible = true;
                    break;
                case 5:
                    ChangeSpriteImage(_imgPageNumber, "UI/privacy-policy-page5-page-number.png");
                    ChangeSpriteImage(_imgPage, "UI/privacy-policy-page5-plain-text.png");
                    _btnLinkToAdPrivacy.Visible = false;
                    break;
            }
        }

        private void BtnForward_OnClick(object sender, EventArgs e)
        {
            _activePage++;

            SetImages();

            if (_activePage == 5)
            {
                _btnForward.Visible = false;
            }
        }
    }
}