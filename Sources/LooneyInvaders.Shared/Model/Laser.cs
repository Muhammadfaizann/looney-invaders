using CocosSharp;
using LooneyInvaders.Layers;


namespace LooneyInvaders.Model
{
    public class Laser
    {
        public CCSprite Sprite;

        public float Y;

        public bool LaserHit = false;

        public bool Left;

        private readonly GamePlayLayer _gamePlayLayer;

        public Laser(GamePlayLayer gamePlayLayer, bool left)
        {
            _gamePlayLayer = gamePlayLayer;
            Y = 0;
            Left = left;
            Sprite = new CCSprite(GameEnvironment.ImageDirectory + "Enemies/Laser-image_middle.png");
            //this.Sprite = new CCSprite(gamePlayLayer.ssBomb.Frames.Find(item => item.TextureFilename == "bomb-animation-image-0.png"));
            Sprite.Position = new CCPoint(0, 0);
            Sprite.AnchorPoint = new CCPoint(0.5f, 0.0f);
            Sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
            _gamePlayLayer.AddChild(Sprite, 11);

        }

        public bool Destroy()
        {
            _gamePlayLayer.RemoveChild(Sprite);
            Sprite = null;
            return true;
        }
    }
}
