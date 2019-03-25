using System.Collections.Generic;
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



        public EnemyState State;

        public float KeepGrimace;

        public float FloatX;
        public float FloatY;
        public float FloatVx;
        public float FloatVy;

        public float WaveVy;
        public float WaveAy;

        public Enemy(GamePlayLayer gamePlayLayer, float x, float y)
        {
            _gamePlayLayer = gamePlayLayer;
            State = EnemyState.Normal;
            Sprite = new CCSprite(GameEnvironment.ImageDirectory + _gamePlayLayer.EnemyMouthClosed);
            Sprite.Position = new CCPoint(x, y);
            Sprite.AnchorPoint = new CCPoint(0.5f, 1);
            Sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
            Lasers = new List<Laser>();
            _gamePlayLayer.AddChild(Sprite, 10);
            Health = 1;
        }

        public void OpenForBomb()
        {
            string png;
            if (State == EnemyState.Grimace1 || State == EnemyState.Grimace2)
            {
                State = EnemyState.Normal;
                KeepGrimace = 0;
            }
            if (State == EnemyState.Damage1)
            {
                png = _gamePlayLayer.EnemyMouthOpenDamaged1;
            }
            else if (State == EnemyState.Damage2)
            {
                png = _gamePlayLayer.EnemyMouthOpenDamaged2;
            }
            else
            {
                png = _gamePlayLayer.EnemyMouthOpen;
            }


            OpenMouth = new CCSprite(GameEnvironment.ImageDirectory + png, new CCRect(0, 0, _gamePlayLayer.EnemyMouthClipWidth, _gamePlayLayer.EnemyMouthClipHeight));
            OpenMouth.Position = new CCPoint(Sprite.PositionX, Sprite.PositionY);
            OpenMouth.AnchorPoint = new CCPoint(0.5f, 1);
            OpenMouth.BlendFunc = GameEnvironment.BlendFuncDefault;
            _gamePlayLayer.AddChild(OpenMouth, Sprite.ZOrder + 2);
            Sprite.Texture = new CCTexture2D(GameEnvironment.ImageDirectory + png);
            Sprite.BlendFunc = GameEnvironment.BlendFuncDefault;

        }

        public void BombOut()
        {
            string png;
            if (State == EnemyState.Damage1)
            {
                png = _gamePlayLayer.EnemyMouthClosedDamaged1;
            }
            else if (State == EnemyState.Damage2)
            {
                png = _gamePlayLayer.EnemyMouthClosedDamaged2;
            }
            else
            {
                png = _gamePlayLayer.EnemyMouthClosed;
            }
            _gamePlayLayer.RemoveChild(OpenMouth);
            OpenMouth = null;
            Sprite.Texture = new CCTexture2D(GameEnvironment.ImageDirectory + png);
            Sprite.BlendFunc = GameEnvironment.BlendFuncDefault;

        }

        public bool Destroy()
        {
            if (OpenMouth != null)
            {
                _gamePlayLayer.RemoveChild(OpenMouth);
                OpenMouth = null;
            }
            if (Explosion != null)
            {
                _gamePlayLayer.RemoveChild(Explosion);
                Explosion = null;
            }
            if (Spit != null)
            {
                _gamePlayLayer.RemoveChild(Spit);
                Spit = null;
            }
            if (LaserTop != null)
            {
                _gamePlayLayer.RemoveChild(LaserTop);
                LaserTop = null;
            }
            if (LaserLeftSpark != null)
            {
                _gamePlayLayer.RemoveChild(LaserLeftSpark);
                LaserLeftSpark = null;
            }
            if (LaserRightSpark != null)
            {
                _gamePlayLayer.RemoveChild(LaserRightSpark);
                LaserRightSpark = null;
            }
            if (LensFlare != null)
            {
                _gamePlayLayer.RemoveChild(LensFlare);
                LensFlare = null;
            }

            foreach (Laser laser in Lasers)
            {
                laser.Destroy();
            }

            _gamePlayLayer.RemoveChild(Sprite);
            Sprite = null;
            return true;
        }
    }
}
