﻿using System;
using CocosSharp;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;

namespace LooneyInvaders.Layers
{
    public class AboutGameScreenLayer : CCLayerColorExt
    {
        private readonly CCSpriteButton _btnForward;
        private readonly CCSprite _imgPage;
        private readonly CCSprite _imgPageNumber;

        private int _activePage = 1;

        public AboutGameScreenLayer()
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            SetBackground("UI/Curtain-and-paper-background.jpg");

            AddImage(292, 565, "UI/about-the-game-title-text.png", 500);

            var btnBack = AddButton(2, 578, "UI/back-button-untapped.png", "UI/back-button-tapped.png", 100, ButtonType.Back);
            btnBack.OnClick += BtnBack_OnClick;
            btnBack.ButtonType = ButtonType.Back;
            Shared.GameDelegate.OnBackButton += BtnBack_OnClick;

            var btnBackThrow = AddButton(148, 578, "UI/back-to-home-button-untapped.png", "UI/back-to-home-button-tapped.png", 100, ButtonType.Back);
            btnBackThrow.OnClick += BtnBackThrow_OnClick;
            btnBackThrow.ButtonType = ButtonType.Back;
            Shared.GameDelegate.OnBackButton += BtnBackThrow_OnClick;

            _btnForward = AddButton(930, 578, "UI/forward-button-untapped.png", "UI/forward-button-tapped.png");
            _btnForward.OnClick += BtnForward_OnClick;
            _btnForward.ButtonType = ButtonType.Forward;

            _imgPageNumber = AddImage(815, 592, "UI/about-the-game-page1-page-number.png");
            _imgPage = AddImage(190, 18, "UI/about-the-game-page1-plain-text.png");
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
            if (_activePage == 1)
            {
                ChangeSpriteImage(_imgPageNumber, "UI/about-the-game-page1-page-number.png");
                ChangeSpriteImage(_imgPage, "UI/about-the-game-page1-plain-text.png");
            }
            else if (_activePage == 2)
            {
                ChangeSpriteImage(_imgPageNumber, "UI/about-the-game-page2-page-number.png");
                ChangeSpriteImage(_imgPage, "UI/about-the-game-page2-plain-text.png");
            }
            else if (_activePage == 3)
            {
                ChangeSpriteImage(_imgPageNumber, "UI/about-the-game-page3-page-number.png");
                ChangeSpriteImage(_imgPage, "UI/about-the-game-page3-plain-text.png");
            }
        }

        private void BtnForward_OnClick(object sender, EventArgs e)
        {
            _activePage++;

            SetImages();

            if (_activePage == 3)
            {
                _btnForward.Visible = false;
            }
        }
    }
}