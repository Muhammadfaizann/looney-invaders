using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;

namespace LooneyInvaders.Layers
{
    public class PrivacyPolicyScreenLayer : CCLayerColorExt
    {
        CCSpriteButton _btnForward;
        CCSprite _imgPage;
        CCSprite _imgPageNumber;

        int _activePage = 1;

        public PrivacyPolicyScreenLayer()
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            this.SetBackground("UI/Curtain-and-paper-background.jpg");

            this.AddImage(307, 570, "UI/privacy-policy-title-text.png", 500);

            CCSpriteButton btnBack = this.AddButton(2, 578, "UI/back-button-untapped.png", "UI/back-button-tapped.png", 100, BUTTON_TYPE.Back);
            btnBack.OnClick += BtnBack_OnClick;
            Shared.GameDelegate.OnBackButton += BtnBack_OnClick;

			CCSpriteButton btnBackThrow = this.AddButton(148, 578, "UI/back-to-home-button-untapped.png", "UI/back-to-home-button-tapped.png", 100, BUTTON_TYPE.Back);
            btnBackThrow.OnClick += BtnBackThrow_OnClick;
            Shared.GameDelegate.OnBackButton += BtnBackThrow_OnClick;

            _btnForward = this.AddButton(930, 578, "UI/forward-button-untapped.png", "UI/forward-button-tapped.png", 100, BUTTON_TYPE.Forward);
            _btnForward.OnClick += BtnForward_OnClick;

			_imgPageNumber = this.AddImage(815, 592, "UI/about-the-game-page1-page-number.png");
            _imgPage = this.AddImage(197, 45, "UI/privacy-policy-page1-plain-text.png");
        }

        private void BtnBack_OnClick(object sender, EventArgs e)
        {
            if (_activePage == 1)
            {
                Shared.GameDelegate.ClearOnBackButtonEvent();

                this.TransitionToLayerCartoonStyle(new GameInfoScreenLayer());
            }
            else
            {
                _activePage--;
                _btnForward.Visible = true;
                setImages();                    
            }
        }

		private void BtnBackThrow_OnClick(object sender, EventArgs e)
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            this.TransitionToLayerCartoonStyle(new MainScreenLayer());
        }

        private void setImages()
        {
            if (_activePage == 1)
            {
                this.ChangeSpriteImage(_imgPageNumber, "UI/privacy-policy-page1-page-number.png");
                this.ChangeSpriteImage(_imgPage, "UI/privacy-policy-page1-plain-text.png");
            }
            else if (_activePage == 2)
            {
                this.ChangeSpriteImage(_imgPageNumber, "UI/privacy-policy-page2-page-number.png");
                this.ChangeSpriteImage(_imgPage, "UI/privacy-policy-page2-plain-text.png");
            }
            else if (_activePage == 3)
            {
                this.ChangeSpriteImage(_imgPageNumber, "UI/privacy-policy-page3-page-number.png");
                this.ChangeSpriteImage(_imgPage, "UI/privacy-policy-page3-plain-text.png");
            }
            else if (_activePage == 4)
            {
                this.ChangeSpriteImage(_imgPageNumber, "UI/privacy-policy-page4-page-number.png");
                this.ChangeSpriteImage(_imgPage, "UI/privacy-policy-page4-plain-text.png");
            }
            else if (_activePage == 5)
            {
                this.ChangeSpriteImage(_imgPageNumber, "UI/privacy-policy-page5-page-number.png");
                this.ChangeSpriteImage(_imgPage, "UI/privacy-policy-page5-plain-text.png");
            }
        }

        private void BtnForward_OnClick(object sender, EventArgs e)
        {
            _activePage++;

            setImages();

            if (_activePage == 5)
            {
                _btnForward.Visible = false;
            }
        }
    }
}