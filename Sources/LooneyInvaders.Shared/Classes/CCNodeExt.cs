using System;
using System.Collections.Generic;
using CocosSharp;
using LooneyInvaders.Model;

namespace LooneyInvaders.Classes
{
    public class CCNodeExt : CCNode, IDisposable
    {
        public CCNodeExt() : base()
        {

        }

        public CCSprite AddImageCentered(int x, int y, string imageName, int zOrder)
        {
            var sprite = new CCSprite(GameEnvironment.ImageDirectory + imageName);
            sprite.AnchorPoint = new CCPoint(0.5f, 0.5f);
            sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
            sprite.Position = new CCPoint(x, y);
            AddChild(sprite, zOrder);
            return sprite;
        }
        public CCSprite AddImage(int x, int y, string imageName, int zOrder)
        {
            return AddImage(x, y, imageName, zOrder, GameEnvironment.BlendFuncDefault);
        }

        public CCSprite AddImage(int x, int y, string imageName)
        {
            return AddImage(x, y, imageName, -100, GameEnvironment.BlendFuncDefault);
        }

        public CCSprite AddImage(int x, int y, string imageName, int zOrder, CCBlendFunc blendFunc)
        {
            var sprite = new CCSprite(GameEnvironment.ImageDirectory + imageName);
            sprite.AnchorPoint = new CCPoint(0, 0);
            sprite.BlendFunc = blendFunc;
            sprite.Position = new CCPoint(x, y);
            AddChild(sprite, zOrder);

            return sprite;
        }

        public CCSprite AddImage(int x, int y, CCSpriteFrame frame, int zOrder = -100)
        {
            var sprite = new CCSprite(frame);
            sprite.AnchorPoint = new CCPoint(0, 0);
            sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
            sprite.Position = new CCPoint(x, y);
            AddChild(sprite, zOrder);

            return sprite;
        }

        public CCSpriteButton AddButton(int x, int y, string imageNameUntapped, string imageNameTapped, int zOrder = 100, ButtonType buttonType = ButtonType.Regular)
        {
            var sprite = new CCSpriteButton(GameEnvironment.ImageDirectory + imageNameUntapped, GameEnvironment.ImageDirectory + imageNameTapped);
            sprite.AnchorPoint = new CCPoint(0, 0);
            sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
            sprite.Position = new CCPoint(x, y);
            sprite.ButtonType = buttonType;
            AddChild(sprite, zOrder);

            return sprite;
        }

        public CCSpriteTwoStateButton AddTwoStateButton(int x, int y, string imageNameUntapped1, string imageNameTapped1, string imageNameUntapped2, string imageNameTapped2, int zOrder = 100)
        {
            var sprite = new CCSpriteTwoStateButton(GameEnvironment.ImageDirectory + imageNameUntapped1, GameEnvironment.ImageDirectory + imageNameTapped1, GameEnvironment.ImageDirectory + imageNameUntapped2, GameEnvironment.ImageDirectory + imageNameTapped2);
            sprite.AnchorPoint = new CCPoint(0, 0);
            sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
            sprite.Position = new CCPoint(x, y);
            AddChild(sprite, zOrder);

            return sprite;
        }

        public CCLabel AddLabel(int x, int y, string text, string fontName, float fontSize)
        {
            var label = new CCLabel(text, fontName, fontSize, CCLabelFormat.SpriteFont);
            label.AnchorPoint = new CCPoint(0, 0);
            label.Position = new CCPoint(x, y);
            AddChild(label);

            return label;
        }

        public CCLabel AddLabelCentered(int x, int y, string text, string fontName, float fontSize)
        {
            var label = new CCLabel(text, fontName, fontSize, CCLabelFormat.SpriteFont);
            label.HorizontalAlignment = CCTextAlignment.Center;
            label.Position = new CCPoint(x, y);
            AddChild(label);

            return label;
        }

        public CCSprite[] AddImageLabel(int x, int y, string text, int fontSize, string color = null)
        {
            if (color != null) color = "_" + color; else color = "";
            var distance = 0;

            switch (fontSize)
            {
                case 57:
                    distance = 27;
                    break;
                case 55:
                case 52:
                    distance = 23;
                    break;
                case 50:
                    distance = 20;
                    break;
                case 42:
                    distance = 19;
                    break;
                case 77:
                    distance = 36;
                    break;
                case 86:
                case 99:
                    distance = 38;
                    break;
                case 998:
                    distance = 23;
                    break;
            }

            var position = x;

            var images = new CCSprite[text.Length];

            for (var i = 0; i < text.Length; i++)
            {
                string imageName;
                switch (fontSize)
                {
                    case 99:
                        imageName = "UI/get-ready-for-next-wave-number-" + text[i] + ".png";
                        break;
                    case 998:
                        imageName = "UI/game-over-screen-moon-level-your-score-number-" + text[i] + ".png";
                        break;
                    default:
                        imageName = "UI/number_" + fontSize + "_" + text[i] + color + ".png";
                        break;
                }

                if (text[i] == 'X') position += 10;

                var image = AddImage(position, y, imageName);
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
            var images = AddImageLabel(xRight, y, text, fontSize, color);

            var maxRightX = images[images.Length - 1].PositionX + images[images.Length - 1].ContentSize.Width;
            var offsetX = xRight - maxRightX;

            foreach (var img in images)
            {
                img.PositionX += offsetX;
            }

            return images;
        }

        public CCSprite[] AddImageLabelCentered(int xCenter, int y, string text, int fontSize, string color = null)
        {
            var images = AddImageLabel(xCenter, y, text, fontSize, color);

            var maxRightX = images[images.Length - 1].PositionX + images[images.Length - 1].ContentSize.Width;
            var offsetX = (xCenter - maxRightX) / 2;

            foreach (var img in images)
            {
                img.PositionX += offsetX;
            }

            return images;
        }

        public void AlignImageLabelsRight(List<CCSprite[]> list)
        {
            float maxRightCoord = 0;

            foreach (var images in list)
            {
                if (images[images.Length - 1].PositionX + images[images.Length - 1].ContentSize.Width > maxRightCoord) maxRightCoord = images[images.Length - 1].PositionX + images[images.Length - 1].ContentSize.Width;
            }

            foreach (var images in list)
            {
                var offsetX = maxRightCoord - images[images.Length - 1].PositionX - images[images.Length - 1].ContentSize.Width;

                if (Math.Abs(offsetX) < AppConstants.Tolerance)
                    continue;

                foreach (var s in images)
                {
                    s.PositionX += offsetX;
                }
            }
        }
    }
}
