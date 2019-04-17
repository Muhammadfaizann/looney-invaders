using CocosSharp;
using LooneyInvaders.Layers;

namespace LooneyInvaders.Model
{
    public class LaserSpark
    {
        private readonly GamePlayLayer _gamePlayLayer;

        public CCSprite Sprite;

        public float Frame = 0;

        public LaserSpark(GamePlayLayer gamePlayLayer, float x, float y)
        {
            _gamePlayLayer = gamePlayLayer;
            Sprite = new CCSprite(gamePlayLayer.SsLaserSparks.Frames.Find(item => item.TextureFilename == "Alien-laser-hitting-animation-without-laser-image_00.png"));
            Sprite.AnchorPoint = new CCPoint(0.5f, 0.25f);
            Sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
            Sprite.Position = new CCPoint(x, y);
            _gamePlayLayer.AddChild(Sprite, 100);
        }

        public bool Destroy()
        {
            _gamePlayLayer.RemoveChild(Sprite);
            Sprite = null;
            return true;
        }
    }
}
