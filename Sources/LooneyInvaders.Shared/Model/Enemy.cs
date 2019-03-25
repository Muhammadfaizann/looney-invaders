using System;
using System.Collections.Generic;
using System.Text;
using CocosSharp;
using LooneyInvaders.Layers;

namespace LooneyInvaders.Model
{
    public class Enemy 
    {
        public CCSprite Sprite;

        public CCSprite OpenMouth;

        public CCSprite Explosion;

        public CCSprite Spit;

        public CCSprite LaserTop;

        public CCSprite LaserLeftSpark;

        public CCSprite LaserRightSpark;

        public CCSprite LensFlare;

        public int LaserLeftSparkFrame;

        public int LaserRightSparkFrame;

        public int LaserLeftSparkCooloff;

        public int LaserRightSparkCooloff;

        public float LensFlareFrame; 

        public int? LaserFxId1;
        public int? LaserFxId2;
        public int? LaserFxId3;


        public float Spitting;

        public Bomb AttachedBomb;

        public List<Laser> Lasers;

        private readonly GamePlayLayer _gamePlayLayer;

        public bool Killed;

        public float Exploding = 1;

        public float SpeedX;

        public float Health;

        

        public ENEMYSTATE State;

        public float keepGrimace;

        public float floatX;
        public float floatY;
        public float floatVX;
        public float floatVY;

        public float waveVY;
        public float waveAY;

        public Enemy(GamePlayLayer gamePlayLayer, float x, float y)
        {
            this._gamePlayLayer = gamePlayLayer;
            this.State = ENEMYSTATE.NORMAL;
            this.Sprite = new CCSprite(GameEnvironment.ImageDirectory + this._gamePlayLayer.EnemyMouthClosed);
            this.Sprite.Position = new CCPoint(x, y);
            this.Sprite.AnchorPoint = new CCPoint(0.5f, 1);
            this.Sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
            this.Lasers = new List<Laser>();
            this._gamePlayLayer.AddChild(this.Sprite, 10);
            this.Health = 1;
        }

        public void OpenForBomb()
        {
            string png;
            if (this.State == ENEMYSTATE.GRIMACE1 || this.State == ENEMYSTATE.GRIMACE2)
            {
                this.State = ENEMYSTATE.NORMAL;
                this.keepGrimace = 0;
            }
            if (this.State == ENEMYSTATE.DAMAGE1) {
                png = this._gamePlayLayer.EnemyMouthOpenDamaged1;
            }
            else if (this.State == ENEMYSTATE.DAMAGE2)
            {
                png = this._gamePlayLayer.EnemyMouthOpenDamaged2;
            }
            else 
            {
                png = this._gamePlayLayer.EnemyMouthOpen;
            }


            this.OpenMouth = new CCSprite(GameEnvironment.ImageDirectory + png, new CCRect(0,0,this._gamePlayLayer.EnemyMouthClipWidth,this._gamePlayLayer.EnemyMouthClipHeight));
            this.OpenMouth.Position = new CCPoint(this.Sprite.PositionX, this.Sprite.PositionY);
            this.OpenMouth.AnchorPoint = new CCPoint(0.5f, 1);
            this.OpenMouth.BlendFunc = GameEnvironment.BlendFuncDefault;
            this._gamePlayLayer.AddChild(this.OpenMouth, this.Sprite.ZOrder + 2);
            this.Sprite.Texture = new CCTexture2D(GameEnvironment.ImageDirectory + png);
            this.Sprite.BlendFunc = GameEnvironment.BlendFuncDefault;

        }

        public void BombOut()
        {
            string png;
            if (this.State == ENEMYSTATE.DAMAGE1)
            {
                png = this._gamePlayLayer.EnemyMouthClosedDamaged1;
            }
            else if (this.State == ENEMYSTATE.DAMAGE2)
            {
                png = this._gamePlayLayer.EnemyMouthClosedDamaged2;
            }
            else
            {
                png = this._gamePlayLayer.EnemyMouthClosed;
            }
            this._gamePlayLayer.RemoveChild(this.OpenMouth, true);
            this.OpenMouth = null;
            this.Sprite.Texture = new CCTexture2D(GameEnvironment.ImageDirectory + png);
            this.Sprite.BlendFunc = GameEnvironment.BlendFuncDefault;

        }

        public bool Destroy()
        {
            if (this.OpenMouth != null)
            {
                this._gamePlayLayer.RemoveChild(this.OpenMouth, true);
                this.OpenMouth = null;
            }
            if (this.Explosion != null)
            {
                this._gamePlayLayer.RemoveChild(this.Explosion, true);
                this.Explosion = null;
            }
            if (this.Spit !=null)
            {
                this._gamePlayLayer.RemoveChild(this.Spit, true);
                this.Spit = null;
            }
            if (this.LaserTop != null)
            {
                this._gamePlayLayer.RemoveChild(LaserTop, true);
                this.LaserTop = null;
            }
            if (this.LaserLeftSpark != null)
            {
                this._gamePlayLayer.RemoveChild(LaserLeftSpark, true);
                this.LaserLeftSpark = null;
            }
            if (this.LaserRightSpark != null)
            {
                this._gamePlayLayer.RemoveChild(LaserRightSpark, true);
                this.LaserRightSpark = null;
            }
            if (this.LensFlare != null)
            {
                this._gamePlayLayer.RemoveChild(LensFlare, true);
                this.LensFlare = null;
            }

            foreach (Laser laser in this.Lasers)
            {
                laser.Destroy();
            }

            this._gamePlayLayer.RemoveChild(Sprite, true);
            this.Sprite = null;
            return true;
        }
    }
}
