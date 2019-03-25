﻿using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;

namespace LooneyInvaders.Layers
{
    public class PrivacyPolicyScreenLayer : CCLayerColorExt
    {
        readonly CCSpriteButton _btnForward;
        readonly CCSprite _imgPage;
        readonly CCSprite _imgPageNumber;

        int _activePage = 1;

        public PrivacyPolicyScreenLayer()
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            SetBackground("UI/Curtain-and-paper-background.jpg");

            AddImage(307, 570, "UI/privacy-policy-title-text.png", 500);

            CCSpriteButton btnBack = AddButton(2, 578, "UI/back-button-untapped.png", "UI/back-button-tapped.png", 100, BUTTON_TYPE.Back);
            btnBack.OnClick += BtnBack_OnClick;
            Shared.GameDelegate.OnBackButton += BtnBack_OnClick;

			CCSpriteButton btnBackThrow = AddButton(148, 578, "UI/back-to-home-button-untapped.png", "UI/back-to-home-button-tapped.png", 100, BUTTON_TYPE.Back);
            btnBackThrow.OnClick += BtnBackThrow_OnClick;
            Shared.GameDelegate.OnBackButton += BtnBackThrow_OnClick;

            _btnForward = AddButton(930, 578, "UI/forward-button-untapped.png", "UI/forward-button-tapped.png", 100, BUTTON_TYPE.Forward);
            _btnForward.OnClick += BtnForward_OnClick;

			_imgPageNumber = AddImage(815, 592, "UI/about-the-game-page1-page-number.png");
            _imgPage = AddImage(197, 45, "UI/privacy-policy-page1-plain-text.png");
        }

        private void BtnBack_OnClick(object sender, EventArgs e)
        {
            if (_activePage == 1)
            {
                Shared.GameDelegate.ClearOnBackButtonEvent();

                TransitionToLayerCartoonStyle(new GameInfoScreenLayer());
            }
            else
            {
                _activePage--;
                _btnForward.Visible = true;
                SetImages();                    
            }
        }

		private void BtnBackThrow_OnClick(object sender, EventArgs e)
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            TransitionToLayerCartoonStyle(new MainScreenLayer());
        }

        private void SetImages()
        {
            if (_activePage == 1)
            {
                ChangeSpriteImage(_imgPageNumber, "UI/privacy-policy-page1-page-number.png");
                ChangeSpriteImage(_imgPage, "UI/privacy-policy-page1-plain-text.png");
            }
            else if (_activePage == 2)
            {
                ChangeSpriteImage(_imgPageNumber, "UI/privacy-policy-page2-page-number.png");
                ChangeSpriteImage(_imgPage, "UI/privacy-policy-page2-plain-text.png");
            }
            else if (_activePage == 3)
            {
                ChangeSpriteImage(_imgPageNumber, "UI/privacy-policy-page3-page-number.png");
                ChangeSpriteImage(_imgPage, "UI/privacy-policy-page3-plain-text.png");
            }
            else if (_activePage == 4)
            {
                ChangeSpriteImage(_imgPageNumber, "UI/privacy-policy-page4-page-number.png");
                ChangeSpriteImage(_imgPage, "UI/privacy-policy-page4-plain-text.png");
            }
            else if (_activePage == 5)
            {
                ChangeSpriteImage(_imgPageNumber, "UI/privacy-policy-page5-page-number.png");
                ChangeSpriteImage(_imgPage, "UI/privacy-policy-page5-plain-text.png");
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