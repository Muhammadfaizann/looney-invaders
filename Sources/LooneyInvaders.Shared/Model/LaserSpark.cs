using System;
using System.Collections.Generic;
using System.Text;
using CocosSharp;
using LooneyInvaders.Layers;

namespace LooneyInvaders.Model
{
    public class LaserSpark
    {
        private GamePlayLayer _gamePlayLayer;

        public CCSprite Sprite;

        public float Frame = 0;

        public LaserSpark(GamePlayLayer gamePlayLayer, float x, float y)
        {
            this._gamePlayLayer = gamePlayLayer;
            this.Sprite = new CCSprite(gamePlayLayer.ssLaserSparks.Frames.Find(item => item.TextureFilename == "Alien-laser-hitting-animation-without-laser-image_00.png"));
            this.Sprite.AnchorPoint = new CCPoint(0.5f, 0.25f);
            this.Sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
            this.Sprite.Position = new CCPoint(x, y);
            this._gamePlayLayer.AddChild(this.Sprite, 100);
        }

        public bool Destroy()
        {
            this._gamePlayLayer.RemoveChild(Sprite, true);
            this.Sprite = null;
            return true;
        }
    }
}
