using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;

namespace LooneyInvaders.Layers
{
    public class AboutGameScreenLayer : CCLayerColorExt
    {
        readonly CCSpriteButton _btnForward;
        readonly CCSprite _imgPage;
        readonly CCSprite _imgPageNumber;

        int _activePage = 1;

        public AboutGameScreenLayer()
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            this.SetBackground("UI/Curtain-and-paper-background.jpg");
            
            this.AddImage(292, 565, "UI/about-the-game-title-text.png", 500);

            CCSpriteButton btnBack = this.AddButton(2, 578, "UI/back-button-untapped.png", "UI/back-button-tapped.png", 100, BUTTON_TYPE.Back);
            btnBack.OnClick += BtnBack_OnClick;
            btnBack.ButtonType = BUTTON_TYPE.Back;
            Shared.GameDelegate.OnBackButton += BtnBack_OnClick;

			CCSpriteButton btnBackThrow = this.AddButton(148, 578, "UI/back-to-home-button-untapped.png", "UI/back-to-home-button-tapped.png", 100, BUTTON_TYPE.Back);
			btnBackThrow.OnClick += BtnBackThrow_OnClick;
			btnBackThrow.ButtonType = BUTTON_TYPE.Back;
			Shared.GameDelegate.OnBackButton += BtnBackThrow_OnClick;

            _btnForward = this.AddButton(930, 578, "UI/forward-button-untapped.png", "UI/forward-button-tapped.png");
            _btnForward.OnClick += BtnForward_OnClick;
            _btnForward.ButtonType = BUTTON_TYPE.Forward;

			_imgPageNumber = this.AddImage(815, 592, "UI/about-the-game-page1-page-number.png");
            _imgPage = this.AddImage(190, 18, "UI/about-the-game-page1-plain-text.png");
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
                this.ChangeSpriteImage(_imgPageNumber, "UI/about-the-game-page1-page-number.png");
                this.ChangeSpriteImage(_imgPage, "UI/about-the-game-page1-plain-text.png");
            }
            else if (_activePage == 2)
            {
                this.ChangeSpriteImage(_imgPageNumber, "UI/about-the-game-page2-page-number.png");
                this.ChangeSpriteImage(_imgPage, "UI/about-the-game-page2-plain-text.png");
            }
            else if (_activePage == 3)
            {
                this.ChangeSpriteImage(_imgPageNumber, "UI/about-the-game-page3-page-number.png");
                this.ChangeSpriteImage(_imgPage, "UI/about-the-game-page3-plain-text.png");
            }
        }

        private void BtnForward_OnClick(object sender, EventArgs e)
        {
            _activePage++;

            setImages();

            if (_activePage == 3)
            {
                _btnForward.Visible = false;
            }
        }
    }
}