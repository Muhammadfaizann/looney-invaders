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
            _gamePlayLayer = gamePlayLayer;
            if (_gamePlayLayer.SelectedEnemy == Enemies.Aliens)
            {
                //this.Sprite = new CCSprite(GameEnvironment.ImageDirectory + "Enemies/green-slime-ball.png");
                Sprite = new CCSprite(gamePlayLayer.SsBomb.Frames.Find(item => item.TextureFilename == "slime-ball-image_0.png"));
                Sprite.Scale = 0.5f;
            }
            else
            {
                Sprite = new CCSprite(gamePlayLayer.SsBomb.Frames.Find(item => item.TextureFilename == "bomb-animation-image-0.png"));
                Sprite.Scale = 0.5f;
            }
            Sprite.Position = new CCPoint(x, y);
            Sprite.AnchorPoint = new CCPoint(0.5f, 0.5f);
            Sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
            _gamePlayLayer.AddChild(Sprite, 11);

            SpeedY = 0;
            SpeedX = 0;
            Rotation = 0;
            RotationSpeed = 0;
        }

        public bool Destroy()
        {
            _gamePlayLayer.RemoveChild(Sprite);
            Sprite = null;
            return true;
        }
    }
}
