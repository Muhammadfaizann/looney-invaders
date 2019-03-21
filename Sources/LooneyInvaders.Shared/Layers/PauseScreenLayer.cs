using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;


namespace LooneyInvaders.Layers
{
    public class PauseScreenLayer : CCLayerColorExt
    {
        float _musicTime;
        bool _backgroundLoading = false;
        CCSprite _imgBruises;

        GamePlayLayer _layerBack;

        public PauseScreenLayer(GamePlayLayer layerBack)
        {
            _layerBack = layerBack;
            this.SetBackground("UI/Pause-screen-example-bush-untapped.png");

            _imgBruises = this.AddImage(390, 210, "UI/Pause-screen-bush-bruises.png");
            _imgBruises.Visible = false;

            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/bush_get_wounded1.wav");
            
            this.RemoveAllListeners();

            var touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesBegan = OnTouchesBegan;
            touchListener.OnTouchesEnded = OnTouchesEnded;
            touchListener.OnTouchesCancelled = OnTouchesCancelled;            
            AddEventListener(touchListener, this);
            CCAudioEngine.SharedEngine.StopBackgroundMusic();
        }

        private void PauseScreenLayer_OnTouchBegan(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void OnTouchesBegan(List<CCTouch> touches, CCEvent touchEvent)
        {            
            if (touches.Count > 0)
            {
                if (_imgBruises.BoundingBoxTransformedToWorld.ContainsPoint(touches[0].Location))
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/bush_get_wounded1.wav");

                    _imgBruises.Visible = true;
                }
            }
        }

        void OnTouchesEnded(List<CCTouch> touches, CCEvent touchEvent)
        {
            // tu se vrati na pocetni layer
            if (_imgBruises.Visible)
            {
                _layerBack.isCartoonFadeIn = false;
                Director.PopScene();
                _layerBack.Continue();
                _imgBruises.Visible = false;
            }
        }

        void OnTouchesCancelled(List<CCTouch> touches, CCEvent touchEvent)
        {
            _imgBruises.Visible = false;
        }        
    }
}