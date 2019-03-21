using System;
using System.Collections.Generic;
using System.Text;
using CocosSharp;
using LooneyInvaders.Layers;

namespace LooneyInvaders.Model
{
    public class Explosion
    {
        private GamePlayLayer _gamePlayLayer;

        public CCSprite Sprite;

        public float Explo = 0;

        public Explosion(GamePlayLayer gamePlayLayer, float x, float y)
        {
            this._gamePlayLayer = gamePlayLayer;
            this.Sprite = new CCSprite( gamePlayLayer.ssPreExplosion.Frames.Find(item => item.TextureFilename == "Pre-explosion_image_00.png"));
            this.Sprite.Position = new CCPoint(x, y);
            this.Sprite.AnchorPoint = new CCPoint(0.5f, 0.5f);
            this.Sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
            this._gamePlayLayer.AddChild(this.Sprite, 111);
        }

        public bool Destroy()
        {
            this._gamePlayLayer.RemoveChild(Sprite, true);
            this.Sprite = null;
            return true;
        }
    }
}
