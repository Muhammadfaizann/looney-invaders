using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;
using LooneyInvaders.Model;

namespace LooneyInvaders.Classes
{
    public class CCSpriteTwoStateButton : CCSpriteButton
    {
        public string ImageNameTapped1 { get; set; }
        public string ImageNameUntapped1 { get; set; }
        public string ImageNameTapped2 { get; set; }
        public string ImageNameUntapped2 { get; set; }
     
        private int _state = 1;        
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }           

        public CCSpriteTwoStateButton(string imageNameUntapped1, string imageNameTapped1, string imageNameUntapped2, string imageNameTapped2) : base(imageNameUntapped1, imageNameTapped1)
        {            
            this.ImageNameUntapped1 = imageNameUntapped1;
            this.ImageNameTapped1 = imageNameTapped1;
            this.ImageNameUntapped2 = imageNameUntapped2;
            this.ImageNameTapped2 = imageNameTapped2;
        }

        public void ChangeState()
        {
            if (this._state == 1) this._state = 2;
            else this._state = 1;
        }

        public void SetStateImages(bool refreshImage = false)
        {
            if (this._state == 1)
            {
                this.ImageNameUntapped = this.ImageNameUntapped1;
                this.ImageNameTapped = this.ImageNameTapped1;
            }
            else
            {
                this.ImageNameUntapped = this.ImageNameUntapped2;
                this.ImageNameTapped = this.ImageNameTapped2;
            }

            this.Texture = new CCTexture2D(ImageNameUntapped);
            this.BlendFunc = GameEnvironment.BlendFuncDefault;
        }
    }
}
