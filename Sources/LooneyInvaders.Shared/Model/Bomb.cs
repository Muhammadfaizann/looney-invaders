using System;
using System.Collections.Generic;
using System.Text;
using CocosSharp;
using LooneyInvaders.Layers;

namespace LooneyInvaders.Model
{
    public class Bomb
    {

        public CCSprite Sprite;

        public float SpeedY;
        public float SpeedX;
        public float RotationSpeed;
        public float Rotation;
        public bool Released = false;
        public bool Collided = false;
        public bool Spitted = false;

        private readonly GamePlayLayer _gamePlayLayer;

        public Bomb(GamePlayLayer gamePlayLayer, float x, float y)
        {
            this._gamePlayLayer = gamePlayLayer;
            if (_gamePlayLayer.SelectedEnemy == ENEMIES.ALIENS)
            {
                //this.Sprite = new CCSprite(GameEnvironment.ImageDirectory + "Enemies/green-slime-ball.png");
                this.Sprite = new CCSprite(gamePlayLayer.SsBomb.Frames.Find(item => item.TextureFilename == "slime-ball-image_0.png"));
                this.Sprite.Scale = 0.5f;
            }
            else
            {
                this.Sprite = new CCSprite(gamePlayLayer.SsBomb.Frames.Find(item => item.TextureFilename == "bomb-animation-image-0.png"));
                this.Sprite.Scale = 0.5f;
            }
            this.Sprite.Position = new CCPoint(x, y);
            this.Sprite.AnchorPoint = new CCPoint(0.5f, 0.5f);
            this.Sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
            this._gamePlayLayer.AddChild(this.Sprite, 11);

            this.SpeedY = 0;
            this.SpeedX = 0;
            this.Rotation = 0;
            this.RotationSpeed = 0;
        }

        public bool Destroy()
        {
            this._gamePlayLayer.RemoveChild(Sprite, true);
            this.Sprite = null;
            return true;
        }
    }
}
