using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;
using LooneyInvaders.Model;

namespace LooneyInvaders.Layers
{
    public class SplashScreenLayer : CCLayerColorExt
    {
        float _musicTime;
        bool? _backgroundLoading = false;
        public bool EnabledTouch { get; set; } = false;

        public SplashScreenLayer()
        {
            
            this.Enabled = false;
            this.EnabledTouch = false;
            this.SetBackground("UI/Splash-screen-background-2.jpg");
            Settings.Instance.ApplyValues(false);

            GameEnvironment.PlayMusic(MUSIC.SPLASH_SCREEN);

            if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental)
            {
                _musicTime = 7;
            }
            else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox)
            {
                _musicTime = 5;
            }

            this.Schedule(waitForMusicToEnd, 1f);

           
        }

        bool b = true;

        public object Content { get; private set; }

        private void switchBackground(float dt)
        {
            if (b)
            {
                this.SetBackground("UI/Splash-screen-background-1.jpg");
                b = false;
               
            }
            else
            {
                this.SetBackground("UI/Splash-screen-background-2.jpg");
                b = true;
            }
        }


        private void waitForMusicToEnd(float dt)
        {
            if (_backgroundLoading != null)
            {
                if (!_backgroundLoading.Value)
                {
                    this.SetBackground("UI/Splash-screen-background-1.jpg");
                    _backgroundLoading = true;
                }
                else
                {
                    this.Schedule(switchBackground, 1f);

                    this.SetBackground("UI/Splash-screen-background-2.jpg");
                    _backgroundLoading = null;
                }
            }
           

            _musicTime -= dt;

            DateTime date = DateTime.Now;
            
            if (_musicTime <= 0)
            {
                //---------- Prabhjot ----------//
                GameEnvironment.PlayMusic(MUSIC.MAIN_MENU);

                TransitionToLayer(new MainScreenLayer());
            }

            while (DateTime.Now.Subtract(date).TotalMilliseconds < 1000) GameAnimation.Instance.PreloadNextSpriteSheet();
        }
    }
}