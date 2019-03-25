using CocosSharp;
using LooneyInvaders.Layers;

namespace LooneyInvaders.Model
{
    public class Explosion
    {
        private readonly GamePlayLayer _gamePlayLayer;

        public CCSprite Sprite;

        public float Explo = 0;

        public Explosion(GamePlayLayer gamePlayLayer, float x, float y)
        {
            _gamePlayLayer = gamePlayLayer;
            Sprite = new CCSprite(gamePlayLayer.SsPreExplosion.Frames.Find(item => item.TextureFilename == "Pre-explosion_image_00.png"));
            Sprite.Position = new CCPoint(x, y);
            Sprite.AnchorPoint = new CCPoint(0.5f, 0.5f);
            Sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
            _gamePlayLayer.AddChild(Sprite, 111);
        }

        public bool Destroy()
        {
            _gamePlayLayer.RemoveChild(Sprite);
            Sprite = null;
            return true;
        }
    }
}
