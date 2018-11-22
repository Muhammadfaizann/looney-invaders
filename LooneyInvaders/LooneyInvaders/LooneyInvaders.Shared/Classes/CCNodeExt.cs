using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;
using LooneyInvaders.Model;
using System.Threading.Tasks;

namespace LooneyInvaders.Classes
{
    public class CCNodeExt : CCNode
    {

        public CCNodeExt() : base()
        {

        }

        public CCSprite AddImageCentered(int x, int y, string imageName, int zOrder)
        {
            CCSprite sprite = new CCSprite(GameEnvironment.ImageDirectory + imageName);
            sprite.AnchorPoint = new CCPoint(0.5f, 0.5f);
            sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
            sprite.Position = new CCPoint(x, y);
            this.AddChild(sprite, zOrder);
            return sprite;
        }
        public CCSprite AddImage(int x, int y, string imageName, int zOrder)
        {
            return this.AddImage(x, y, imageName, zOrder, GameEnvironment.BlendFuncDefault);
        }

        public CCSprite AddImage(int x, int y, string imageName)
        {
            return this.AddImage(x, y, imageName, -100, GameEnvironment.BlendFuncDefault);
        }

        public CCSprite AddImage(int x, int y, string imageName, int zOrder, CCBlendFunc blendFunc)
        {
            CCSprite sprite = new CCSprite(GameEnvironment.ImageDirectory + imageName);
            sprite.AnchorPoint = new CCPoint(0, 0);
            sprite.BlendFunc = blendFunc;
            sprite.Position = new CCPoint(x, y);
            this.AddChild(sprite, zOrder);

            return sprite;
        }

        public CCSprite AddImage(int x, int y, CCSpriteFrame frame, int zOrder = -100)
        {
            CCSprite sprite = new CCSprite(frame);
            sprite.AnchorPoint = new CCPoint(0, 0);
            sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
            sprite.Position = new CCPoint(x, y);
            this.AddChild(sprite, zOrder);

            return sprite;
        }

        public CCSpriteButton AddButton(int x, int y, string imageNameUntapped, string imageNameTapped, int zOrder = 100, BUTTON_TYPE buttonType = BUTTON_TYPE.Regular)
        {
            CCSpriteButton sprite = new CCSpriteButton(GameEnvironment.ImageDirectory + imageNameUntapped, GameEnvironment.ImageDirectory + imageNameTapped);
            sprite.AnchorPoint = new CCPoint(0, 0);
            sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
            sprite.Position = new CCPoint(x, y);
            sprite.ButtonType = buttonType;
            this.AddChild(sprite, zOrder);

            return sprite;
        }

        public CCSpriteTwoStateButton AddTwoStateButton(int x, int y, string imageNameUntapped1, string imageNameTapped1, string imageNameUntapped2, string imageNameTapped2, int zOrder = 100)
        {
            CCSpriteTwoStateButton sprite = new CCSpriteTwoStateButton(GameEnvironment.ImageDirectory + imageNameUntapped1, GameEnvironment.ImageDirectory + imageNameTapped1, GameEnvironment.ImageDirectory + imageNameUntapped2, GameEnvironment.ImageDirectory + imageNameTapped2);
            sprite.AnchorPoint = new CCPoint(0, 0);
            sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
            sprite.Position = new CCPoint(x, y);
            this.AddChild(sprite, zOrder);

            return sprite;
        }

        public CCLabel AddLabel(int x, int y, string text, string fontName, float fontSize)
        {
            CCLabel label = new CCLabel(text, fontName, fontSize, CCLabelFormat.SpriteFont);
            label.AnchorPoint = new CCPoint(0, 0);
            label.Position = new CCPoint(x, y);
            this.AddChild(label);

            return label;
        }

        public CCLabel AddLabelCentered(int x, int y, string text, string fontName, float fontSize)
        {
            CCLabel label = new CCLabel(text, fontName, fontSize, CCLabelFormat.SpriteFont);
            label.HorizontalAlignment = CCTextAlignment.Center;
            label.Position = new CCPoint(x, y);
            this.AddChild(label);

            return label;
        }

        public CCSprite[] AddImageLabel(int x, int y, string text, int fontSize, string color = null)
        {
            if (color != null) color = "_" + color; else color = "";
            int distance = 0;

            if (fontSize == 57) distance = 27;
            else if (fontSize == 55) distance = 23;
            else if (fontSize == 52) distance = 23;
            else if (fontSize == 50) distance = 20;
            else if (fontSize == 42) distance = 19;
            else if (fontSize == 77) distance = 36;
            else if (fontSize == 86) distance = 38;
            else if (fontSize == 99) distance = 38;
            else if (fontSize == 998) distance = 23;

            int position = x;

            CCSprite[] images = new CCSprite[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                string imageName;
                if (fontSize == 99)
                {
                    imageName = "UI/get-ready-for-next-wave-number-" + text[i].ToString() + ".png";

                }
                if (fontSize == 998)
                {
                    imageName = "UI/game-over-screen-moon-level-your-score-number-" + text[i].ToString() + ".png";

                }
                else
                {
                    imageName = "UI/number_" + fontSize.ToString() + "_" + text[i].ToString() + color + ".png";
                }

                if (text[i] == 'X') position += 10;

                CCSprite image = this.AddImage(position, y, imageName);
                images[i] = image;
                image.ZOrder = 999;

                if (text[i] == '1') position += Convert.ToInt32(distance * 0.9);
                else if (text[i] == '.') position += Convert.ToInt32(distance * 0.7);
                else position += distance;

                if (text[i] == '.') image.PositionY -= 4;

                if ((text.Length - i - 1) % 3 == 0)
                {
                    if (fontSize == 86 || fontSize == 77) position += distance / 4;
                    else position += distance / 3;
                }
            }

            return images;
        }

        public CCSprite[] AddImageLabelRightAligned(int xRight, int y, string text, int fontSize, string color = null)
        {
            CCSprite[] images = AddImageLabel(xRight, y, text, fontSize, color);

            float maxRightX = images[images.Length - 1].PositionX + images[images.Length - 1].ContentSize.Width;
            float offsetX = xRight - maxRightX;

            foreach (CCSprite img in images)
            {
                img.PositionX += offsetX;
            }

            return images;
        }

        public CCSprite[] AddImageLabelCentered(int xCenter, int y, string text, int fontSize, string color = null)
        {
            CCSprite[] images = AddImageLabel(xCenter, y, text, fontSize, color);

            float maxRightX = images[images.Length - 1].PositionX + images[images.Length - 1].ContentSize.Width;
            float offsetX = (xCenter - maxRightX) / 2;

            foreach (CCSprite img in images)
            {
                img.PositionX += offsetX;
            }

            return images;
        }

        public void AlignImageLabelsRight(List<CCSprite[]> list)
        {
            float maxRightCoord = 0;

            foreach (CCSprite[] images in list)
            {
                if (images[images.Length - 1].PositionX + images[images.Length - 1].ContentSize.Width > maxRightCoord) maxRightCoord = images[images.Length - 1].PositionX + images[images.Length - 1].ContentSize.Width;
            }

            foreach (CCSprite[] images in list)
            {
                float offsetX = maxRightCoord - images[images.Length - 1].PositionX - images[images.Length - 1].ContentSize.Width;

                if (offsetX == 0) continue;

                foreach (CCSprite s in images)
                {
                    s.PositionX += offsetX;
                }
            }

        }

    }
}
