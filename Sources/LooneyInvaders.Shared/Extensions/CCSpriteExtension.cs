﻿using System;
using CocosSharp;
using LooneyInvaders.Classes;
using LooneyInvaders.Model;

namespace LooneyInvaders.Extensions
{
    public static class CCSpriteExtension
    {
        public static void ChangeVisibility(this CCSpriteButton ccSprite, bool isVisible)
        {
            if (ccSprite != null)
            {
                var isEnabled = ccSprite.Enabled;
                ccSprite.Enabled = true;
                ccSprite.Visible = isVisible;
                ccSprite.Enabled = isEnabled;
            }
        }

        public static void ChangeAvailability(this CCSpriteButton ccSprite, bool isEnabled)
        {
            if (ccSprite != null)
            {
                ccSprite.Enabled = isEnabled;
            }
        }

        public static CCSpriteButton CreateButton(this CCLayerColorExt layer,
            int x, int y,
            string imageNameUntapped,
            string imageNameTapped,
            int zOrder = 100,
            ButtonType buttonType = ButtonType.Regular,
            EventHandler onClick = null)
        {
            CCSpriteButton ccSprite = null;
            if (layer != null)
            {
                ccSprite = layer.AddButton(x, y, imageNameUntapped, imageNameTapped, zOrder, buttonType);
                ccSprite.OnClick += onClick;
            }
            return ccSprite;
        }

        public static CCSpriteButton CreateIfNeeded(this CCSpriteButton ccSprite,
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
                }
            }
            return ccSprite;
        }
    }
}
