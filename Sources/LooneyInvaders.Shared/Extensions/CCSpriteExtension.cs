using System;
using CocosSharp;
using LooneyInvaders.Classes;
using LooneyInvaders.Model;

namespace LooneyInvaders.Extensions
{
    public static class CCSpriteExtension
    {
        public static void ChangeVisibility(this CCSprite ccSprite, bool isVisible)
        {
            if (ccSprite != null)
            {
                ccSprite.Visible = isVisible;
            }
        }

        public static void CreateIfNeededAndChangeVisibility(this CCSpriteButton ccSprite, bool isVisible,
            CCLayerColorExt layer,
            int x, int y,
            string imageNameUntapped,
            string imageNameTapped,
            int zOrder = 100,
            ButtonType buttonType = ButtonType.Regular,
            EventHandler onClick = null)
        {
            if (ccSprite == null)
            {
                if (layer != null)
                {
                    ccSprite = layer.AddButton(x, y, imageNameUntapped, imageNameTapped, zOrder, buttonType);
                    ccSprite.OnClick += onClick;
                    ccSprite.Visible = isVisible;
                }
            }
            else
            {
                ccSprite.Visible = isVisible;
            }
        }
    }
}
