using System;
using System.Collections.Generic;
using System.Text;
using CocosSharp;
using LooneyInvaders.Layers;

namespace LooneyInvaders.Model
{
    public class GunSmoke
    {
        private readonly GamePlayLayer _gamePlayLayer;

        public CCSprite Sprite;

        public float Smoke = 0;

        public GunSmoke(GamePlayLayer gamePlayLayer, float x, float y)
        {
            this._gamePlayLayer = gamePlayLayer;
            if (_gamePlayLayer.SelectedWeapon == WEAPONS.HYBRID)
            {
                this.Sprite = new CCSprite(gamePlayLayer.SsHybridLaser[0].Frames.Find(item => item.TextureFilename == "pipe-flames-and-lens-flare-image_06.png"));
                this.Sprite.Position = new CCPoint(x-30, y-200);
                this.Sprite.Opacity = 200;
                this.Sprite.AnchorPoint = new CCPoint(0.5f, 0f);
            }
            else
            {
                this.Sprite = new CCSprite(gamePlayLayer.SsCannonFlame.Frames.Find(item => item.TextureFilename == "General_cannon_flame00.png"));
                this.Sprite.Position = new CCPoint(x, y);
                this.Sprite.AnchorPoint = new CCPoint(0.5f, 0f);
            }
            this.Sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
            this._gamePlayLayer.AddChild(this.Sprite, 20);
        }

        public bool Destroy()
        {
            this._gamePlayLayer.RemoveChild(Sprite, true);
            this.Sprite = null;
            return true;
        }
    }
}
