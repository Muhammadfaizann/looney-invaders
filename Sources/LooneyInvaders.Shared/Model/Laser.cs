using System;
using System.Collections.Generic;
using System.Text;
using CocosSharp;
using LooneyInvaders.Layers;


namespace LooneyInvaders.Model
{
    public class Laser
    {
        public CCSprite Sprite;

        public float y;

        public bool LaserHit = false;

        public bool Left;

        private GamePlayLayer _gamePlayLayer;

        public Laser(GamePlayLayer gamePlayLayer, bool left)
        {
            this._gamePlayLayer = gamePlayLayer;
            this.y = 0;
            this.Left = left;
            this.Sprite = new CCSprite(GameEnvironment.ImageDirectory + "Enemies/Laser-image_middle.png");
            //this.Sprite = new CCSprite(gamePlayLayer.ssBomb.Frames.Find(item => item.TextureFilename == "bomb-animation-image-0.png"));
            this.Sprite.Position = new CCPoint(0, 0);
            this.Sprite.AnchorPoint = new CCPoint(0.5f, 0.0f);
            this.Sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
            this._gamePlayLayer.AddChild(this.Sprite, 11);

        }

        public bool Destroy()
        {
            this._gamePlayLayer.RemoveChild(Sprite, true);
            this.Sprite = null;
            return true;
        }
    }
}
