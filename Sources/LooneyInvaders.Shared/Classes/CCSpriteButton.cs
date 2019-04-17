using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;
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
        public BUTTON_TYPE ButtonType { get; set; }

        public char Slovo;
        

        public CCSpriteButton(string imageNameUntapped, string imageNameTapped, BUTTON_TYPE buttonType = BUTTON_TYPE.Regular) : base(imageNameUntapped)
        {            
            this.ImageNameUntapped = imageNameUntapped;
            this.ImageNameTapped = imageNameTapped;
            this.ButtonType = buttonType;            
        }

        internal void FireOnClick()
        {
            if (OnClick != null)
            {
                OnClick(this, EventArgs.Empty);
            }
			#if __ANDROID__
			    this.BlendFunc = CCBlendFunc.NonPremultiplied;
            #endif
        }
    }
}
