using System;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;

namespace LooneyInvaders.Layers
{
    public class SplashScreenLayer : CCLayerColorExt
    {
        private float _musicTime;
        private bool? _backgroundLoading = false;
        public bool EnabledTouch { get; set; }

        public SplashScreenLayer()
        {
            Enabled = false;
            EnabledTouch = false;
            ScheduleOnce((obj) => SetBackground("UI/Splash-screen-background-2.jpg"), 0f);
            //SetBackground("UI/Splash-screen-background-2.jpg");
            Settings.Instance.ApplyValues(false);

            GameEnvironment.PlayMusic(Music.SplashScreen);

            switch (Settings.Instance.MusicStyle)
            {
                case MusicStyle.Instrumental:
                    _musicTime = 7;
                    break;
                case MusicStyle.BeatBox:
                    _musicTime = 5;
                    break;
            }

            Schedule(WaitForMusicToEnd, 0.5f);
        }

        private bool _b = true;

        public object Content { get; protected set; }

        private void SwitchBackground(float dt)
        {
            if (_b)
            {
                SetBackground("UI/Splash-screen-background-1.jpg");
                _b = false;

            }
            else
            {
                SetBackground("UI/Splash-screen-background-2.jpg");
                _b = true;
            }
        }


        private void WaitForMusicToEnd(float dt)
        {
            if (_backgroundLoading != null)
            {
                if (!_backgroundLoading.Value)
                {
                    SetBackground("UI/Splash-screen-background-1.jpg");
                    _backgroundLoading = true;
                }
                else
                {
                    Schedule(SwitchBackground, 1f);

                    SetBackground("UI/Splash-screen-background-2.jpg");
                    _backgroundLoading = null;
                }
            }


            _musicTime -= dt;

            var date = DateTime.Now;

            if (_musicTime <= 1.2)
            {
                //---------- Prabhjot ----------//
                GameEnvironment.PlayMusic(Music.MainMenu);

            }


            if (_musicTime <= 0)
            {
                //---------- Prabhjot ----------//
                //GameEnvironment.PlayMusic(MUSIC.MAIN_MENU);

                TransitionToLayer(new MainScreenLayer());
            }

            while (DateTime.Now.Subtract(date).TotalMilliseconds < 1000) GameAnimation.Instance.PreloadNextSpriteSheet();
        }
    }
}
