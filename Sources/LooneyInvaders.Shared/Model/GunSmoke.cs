using CocosSharp;
using LooneyInvaders.Layers;

namespace LooneyInvaders.Model
{
    public class GunSmoke
    {
        private readonly GamePlayLayer _gamePlayLayer;

        public CCSprite Sprite;

        public float Smoke = 0;

        public GunSmoke(GamePlayLayer gamePlayLayer, float x, float y)
        {
            _gamePlayLayer = gamePlayLayer;
            if (_gamePlayLayer.SelectedWeapon == Weapons.Hybrid)
            {
                Sprite = new CCSprite(gamePlayLayer.SsHybridLaser[0].Frames.Find(item => item.TextureFilename == "pipe-flames-and-lens-flare-image_06.png"));
                Sprite.Position = new CCPoint(x - 30, y - 200);
                Sprite.Opacity = 200;
                Sprite.AnchorPoint = new CCPoint(0.5f, 0f);
            }
            else
            {
                Sprite = new CCSprite(gamePlayLayer.SsCannonFlame.Frames.Find(item => item.TextureFilename == "General_cannon_flame00.png"));
                Sprite.Position = new CCPoint(x, y);
                Sprite.AnchorPoint = new CCPoint(0.5f, 0f);
            }
            Sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
            _gamePlayLayer.AddChild(Sprite, 20);
        }

        public bool Destroy()
        {
            _gamePlayLayer.RemoveChild(Sprite);
            Sprite = null;
            return true;
        }
    }
}
