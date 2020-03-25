﻿using System;
using CocosSharp;
using LooneyInvaders.Model;

namespace LooneyInvaders.Classes
{
    public class CCSpriteButton : CCSprite
    {
        public bool Enabled { get; set; } = true;
        public string ImageNameTapped { get; set; }
        public string ImageNameUntapped { get; set; }
        public event EventHandler OnClick;
        public bool IsBeingTapped { get; set; }
        public ButtonType ButtonType { get; set; }

        public char Slovo;

        public CCSpriteButton(string imageNameUntapped, string imageNameTapped, ButtonType buttonType = ButtonType.Regular) : base(imageNameUntapped)
        {
            ImageNameUntapped = imageNameUntapped;
            ImageNameTapped = imageNameTapped;
            ButtonType = buttonType;
        }

        public void DisableClick()
        {
            OnClick = null;
        }

        public void ChangeImagesTo(string imageNameUntapped, string imageNameTapped)
        {
            ImageNameUntapped = GameEnvironment.ImageDirectory + imageNameUntapped;
            ImageNameTapped = GameEnvironment.ImageDirectory + imageNameTapped;
        }

        internal void FireOnClick()
        {
            OnClick?.Invoke(this, EventArgs.Empty);
#if __ANDROID__
            BlendFunc = CCBlendFunc.NonPremultiplied;
#endif
        }
    }
}
