using System;
using CocosSharp;
using LooneyInvaders.Classes;
using LooneyInvaders.Layers;

namespace LooneyInvaders.Shared
{
    public static class GameDelegate
    {
        public delegate void GetGyroDelegate(out float yaw, out float tilt, out float pitch);

        public static GetGyroDelegate GetGyro;

        public static event EventHandler OnBackButton;

        public static void FireBackButtonPressed()
        {
            OnBackButton?.Invoke(null, EventArgs.Empty);
        }

        public static void ClearOnBackButtonEvent()
        {
            OnBackButton = null;
        }

        public static CCLayer Layer;

        public static CCGameView GameView;

        public static void LoadGame(object sender, EventArgs e)
        {
            GameView = sender as CCGameView;

            if (GameView == null)
                return;

            //var contentSearchPaths = new List<string>() { "Fonts", "Sounds" };
            //CCSizeI viewSize = GameView.ViewSize;

            const int width = 1136; //1136;  // 2436
            const int height = 640; //640;    // 1125

            // Set world dimensions
            GameView.DesignResolution = new CCSizeI(width, height);
            GameView.ResolutionPolicy = CCViewResolutionPolicy.ShowAll;

            // Determine whether to use the high or low def versions of our images
            // Make sure the default texel to content size ratio is set correctly
            // Of course you're free to have a finer set of image resolutions e.g (ld, hd, super-hd)
            //if (width < viewSize.Width)
            //{
            //    contentSearchPaths.Add("Images/Hd");
            //    CCSprite.DefaultTexelToContentSizeRatio = 2.0f;
            //}
            //else
            //{
            //    contentSearchPaths.Add("Images/Ld");
            //    CCSprite.DefaultTexelToContentSizeRatio = 1.0f;
            //}

            // TODO: ovo sloziti kak se spada
            //contentSearchPaths.Add("Images/Hd");

            CCSprite.DefaultTexelToContentSizeRatio = 1.0f;
            //gameView.ContentManager.SearchPaths = contentSearchPaths;

            // TODO: TESTIRANJE, MAKNUTI
            //LooneyInvaders.Model.Weapon.ResetAllSettings();
            //LooneyInvaders.Model.Settings.Instance.Advertisements = false;
            //LooneyInvaders.Model.Player.Instance.Credits = 1000000;
            //

            //LooneyInvaders.Model.LeaderboardManager.SubmitScorePro(12345, 12);
            //LooneyInvaders.Model.LeaderboardManager.SubmitScoreRegular(2345, 67.89, 123.45);

            var gameScene = new CCScene(GameView);
            //gameScene.AddLayer(new EnemyPickerLayer());
            //gameScene.AddLayer(new MainScreenLayer());
            var splashLayer = new SplashScreenLayer();
            gameScene.AddLayer(Layer ?? splashLayer);
            //gameScene.AddLayer(new VictoryScreenLayer(Model.ENEMIES.HITLER, Model.WEAPONS.BAZOOKA, Model.BATTLEGROUNDS.POLAND, 100, 99));
            //gameScene.AddLayer(new SettingsScreenLayer());
            GameView.RunWithScene(gameScene);
        }
    }

    public static class GeometryExtensionHelpers
    {
        public static CCPoint Left(this CCRect visibleRect)
        {
            return new CCPoint(visibleRect.Origin.X, visibleRect.Origin.Y + visibleRect.Size.Height / 2);
        }

        public static CCPoint Right(this CCRect visibleRect)
        {
            return new CCPoint(visibleRect.Origin.X + visibleRect.Size.Width, visibleRect.Origin.Y + visibleRect.Size.Height / 2);
        }

        public static CCPoint Top(this CCRect visibleRect)
        {
            return new CCPoint(visibleRect.Origin.X + visibleRect.Size.Width / 2, visibleRect.Origin.Y + visibleRect.Size.Height);
        }

        public static CCPoint Bottom(this CCRect visibleRect)
        {
            return new CCPoint(visibleRect.Origin.X + visibleRect.Size.Width / 2, visibleRect.Origin.Y);
        }

        public static CCPoint Center(this CCRect visibleRect)
        {
            return new CCPoint(visibleRect.Origin.X + visibleRect.Size.Width / 2, visibleRect.Origin.Y + visibleRect.Size.Height / 2);
        }

        public static CCPoint LeftTop(this CCRect visibleRect)
        {
            return new CCPoint(visibleRect.Origin.X, visibleRect.Origin.Y + visibleRect.Size.Height);
        }

        public static CCPoint RightTop(this CCRect visibleRect)
        {
            return new CCPoint(visibleRect.Origin.X + visibleRect.Size.Width, visibleRect.Origin.Y + visibleRect.Size.Height);
        }

        public static CCPoint LeftBottom(this CCRect visibleRect)
        {
            return visibleRect.Origin;
        }

        public static CCPoint RightBottom(this CCRect visibleRect)
        {
            return new CCPoint(visibleRect.Origin.X + visibleRect.Size.Width, visibleRect.Origin.Y);
        }
    }
}