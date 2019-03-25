using System.Collections.Generic;
using CocosSharp;
using LooneyInvaders.Classes;


namespace LooneyInvaders.Layers
{
    public class PauseScreenLayer : CCLayerColorExt
    {
        readonly CCSprite _imgBruises;
        readonly GamePlayLayer _layerBack;

        public PauseScreenLayer(GamePlayLayer layerBack)
        {
            _layerBack = layerBack;
            SetBackground("UI/Pause-screen-example-bush-untapped.png");

            _imgBruises = AddImage(390, 210, "UI/Pause-screen-bush-bruises.png");
            _imgBruises.Visible = false;

            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/bush_get_wounded1.wav");

            RemoveAllListeners();

            var touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesBegan = OnTouchesBegan;
            touchListener.OnTouchesEnded = OnTouchesEnded;
            touchListener.OnTouchesCancelled = OnTouchesCancelled;
            AddEventListener(touchListener, this);
            CCAudioEngine.SharedEngine.StopBackgroundMusic();
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
                _layerBack.IsCartoonFadeIn = false;
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