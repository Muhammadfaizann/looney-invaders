using System;
using System.Collections.Generic;
using CocosSharp;
using LooneyInvaders.Model;

namespace LooneyInvaders.Classes
{
    public class CCLayerColorExt : CCLayerColor
    {
        public CCSprite Background;
        public event EventHandler OnTouchBegan; // touch on the layer but not on any of the buttons
        public event EventHandler OnTouchEnded;
        bool _buttonDown;
        private CCPoint _position;

        public bool Enabled { get; set; } = true;

        public bool EnableMultiTouch { get; set; }

        private CCSprite _transitionImage;
        internal CCLayerColorExt LayerTransitionTarget;
        internal bool IsCartoonFadeIn;

        public override CCPoint Position
        {
            get => _position;
            set => _position = value;
        }

        public CCLayerColorExt()
            : base(CCColor4B.Black)
        {
            _position = new CCPoint(0, 1);
            Shared.GameDelegate.ClearOnBackButtonEvent();
           

            var touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesBegan = OnTouchesBegan;
            touchListener.OnTouchesEnded = OnTouchesEnded;
            touchListener.OnTouchesCancelled = OnTouchesCancelled;
            touchListener.OnTouchesMoved = OnTouchesMoved;
            AddEventListener(touchListener, this);
        }

        public void EndTouchOnBtn(CCSpriteButton button)
        {
            button.Texture = new CCTexture2D(button.ImageNameUntapped);

            button.IsBeingTapped = false;

            button.FireOnClick();

            OnTouchEnded?.Invoke(this, EventArgs.Empty);
        }

        public void SetBackground(string imageName)
        {
            if (Background != null)
            {
                RemoveChild(Background);
                Background.Dispose();
            }

            Background = new CCSprite(GameEnvironment.ImageDirectory + imageName);
            Background.AnchorPoint = new CCPoint(0, 0);
            Background.Position = new CCPoint(0, 0);
            AddChild(Background, -1000);
        }

        public CCSprite AddImageCentered(int x, int y, string imageName, int zOrder)
        {
            var sprite = new CCSprite(GameEnvironment.ImageDirectory + imageName);
            sprite.AnchorPoint = new CCPoint(0.5f, 0.5f);
            sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
            sprite.Position = new CCPoint(x, y);
            AddChild(sprite, zOrder);
            return sprite;
        }

        public CCSprite AddImage(int x, int y, string imageName, int zOrder)
        {
            return AddImage(x, y, imageName, zOrder, GameEnvironment.BlendFuncDefault);
        }

        public CCSprite AddImage(int x, int y, string imageName)
        {
            return AddImage(x, y, imageName, -100, GameEnvironment.BlendFuncDefault);
        }

        public CCSprite AddImage(int x, int y, string imageName, int zOrder, CCBlendFunc blendFunc)
        {
            var sprite = new CCSprite(GameEnvironment.ImageDirectory + imageName);
            sprite.AnchorPoint = new CCPoint(0, 0);
            sprite.BlendFunc = blendFunc;
            sprite.Position = new CCPoint(x, y);
            AddChild(sprite, zOrder);

            return sprite;
        }

        public CCSprite AddImage(int x, int y, CCSpriteFrame frame, int zOrder = -100)
        {
            var sprite = new CCSprite(frame);
            sprite.AnchorPoint = new CCPoint(0, 0);
            sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
            sprite.Position = new CCPoint(x, y);
            AddChild(sprite, zOrder);

            return sprite;
        }

        public CCSpriteButton AddButton(int x, int y, string imageNameUntapped, string imageNameTapped,
            int zOrder = 100, BUTTON_TYPE buttonType = BUTTON_TYPE.Regular)
        {
            var sprite = new CCSpriteButton(GameEnvironment.ImageDirectory + imageNameUntapped, GameEnvironment.ImageDirectory + imageNameTapped);
            sprite.AnchorPoint = new CCPoint(0, 0);
            sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
            sprite.Position = new CCPoint(x, y);
            sprite.ButtonType = buttonType;
            AddChild(sprite, zOrder);

            return sprite;
        }

        public CCSpriteTwoStateButton AddTwoStateButton(int x, int y, string imageNameUntapped1,
            string imageNameTapped1, string imageNameUntapped2, string imageNameTapped2, int zOrder = 100)
        {
            var sprite = new CCSpriteTwoStateButton(
                GameEnvironment.ImageDirectory + imageNameUntapped1, GameEnvironment.ImageDirectory + imageNameTapped1,
                GameEnvironment.ImageDirectory + imageNameUntapped2, GameEnvironment.ImageDirectory + imageNameTapped2);
            sprite.AnchorPoint = new CCPoint(0, 0);
            sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
            sprite.Position = new CCPoint(x, y);
            AddChild(sprite, zOrder);

            return sprite;
        }

        public CCLabel AddLabel(int x, int y, string text, string fontName, float fontSize)
        {
            return AddLabel(x, y, text, fontName, fontSize, CCColor3B.White);
        }

        public CCLabel AddLabel(int x, int y, string text, string fontName, float fontSize, CCColor3B color)
        {
            var label = new CCLabel(text, fontName, fontSize, CCLabelFormat.SpriteFont);
            label.AnchorPoint = new CCPoint(0, 0);
            label.Position = new CCPoint(x, y);
            label.Color = color;
            AddChild(label);

            return label;
        }

        public CCLabel AddLabelCentered(int x, int y, string text, string fontName, float fontSize)
        {
            var label = new CCLabel(text, fontName, fontSize, CCLabelFormat.SpriteFont);
            label.HorizontalAlignment = CCTextAlignment.Center;
            label.Position = new CCPoint(x, y);
            AddChild(label);

            return label;
        }

        public CCLabel AddLabelRightAligned(int x, int y, string text, string fontName, float fontSize)
        {
            return AddLabelRightAligned(x, y, text, fontName, fontSize, CCColor3B.White);
        }

        public CCLabel AddLabelRightAligned(int x, int y, string text, string fontName, float fontSize, CCColor3B color)
        {
            var label = new CCLabel(text, fontName, fontSize, CCLabelFormat.SpriteFont);
            label.HorizontalAlignment = CCTextAlignment.Right;
            label.AnchorPoint = new CCPoint(1, 0);
            label.Position = new CCPoint(x, y);
            label.Color = color;
            AddChild(label);

            return label;
        }


        public CCSprite[] AddImageLabelRightAligned(int xRight, int y, string text, int fontSize)
        {
            var images = AddImageLabel(xRight, y, text, fontSize);

            var maxRightX = images[images.Length - 1].PositionX + images[images.Length - 1].ContentSize.Width;
            var offsetX = xRight - maxRightX;

            foreach (var img in images)
            {
                img.PositionX += offsetX;
            }

            return images;
        }

        public void AlignImageLabelsRight(List<CCSprite[]> list)
        {
            float maxRightCoord = 0;

            foreach (var images in list)
            {
                if (images[images.Length - 1].PositionX + images[images.Length - 1].ContentSize.Width > maxRightCoord)
                    maxRightCoord = images[images.Length - 1].PositionX + images[images.Length - 1].ContentSize.Width;
            }

            foreach (var images in list)
            {
                var offsetX = maxRightCoord - images[images.Length - 1].PositionX -
                                images[images.Length - 1].ContentSize.Width;

                if (Math.Abs(offsetX) < AppConstants.TOLERANCE)
                    continue;

                foreach (var s in images)
                {
                    s.PositionX += offsetX;
                }
            }

        }


        public CCSprite[] AddImageLabel(int x, int y, string text, int fontSize)
        {
            return AddImageLabel(x, y, text, fontSize, string.Empty);
        }

        public CCSprite[] AddImageLabel(int x, int y, string text, int fontSize, string color)
        {
            if (!string.IsNullOrEmpty(color))
                color = "_" + color;

            var distance = 0;

            switch (fontSize)
            {
                case 57:
                    distance = 27;
                    break;
                case 55:
                case 52:
                    distance = 23;
                    break;
                case 50:
                    distance = 20;
                    break;
                case 42:
                    distance = 19;
                    break;
                case 77:
                    distance = 36;
                    break;
                case 86:
                case 99:
                    distance = 38;
                    break;
                case 998:
                    distance = 23;
                    break;
            }

            var position = x;

            var images = new CCSprite[text.Length];

            for (var i = 0; i < text.Length; i++)
            {
                string imageName;
                switch (fontSize)
                {
                    case 99:
                        imageName = "UI/get-ready-for-next-wave-number-" + text[i] + ".png";
                        break;
                    case 998:
                        imageName = "UI/game-over-screen-moon-level-your-score-number-" + text[i] + ".png";
                        break;
                    default:
                        imageName = "UI/number_" + fontSize + "_" + text[i] + color + ".png";
                        break;
                }

                if (text[i] == 'X') position += 10;

                var image = AddImage(position, y, imageName);
                images[i] = image;
                image.ZOrder = 999;

                if (text[i] == '1') position += Convert.ToInt32(distance * 0.9);
                else if (text[i] == '.') position += Convert.ToInt32(distance * 0.7);
                else position += distance;

                if (text[i] == '.') image.PositionY -= 4;

                if ((text.Length - i - 1) % 3 == 0)
                {
                    if (fontSize == 86 || fontSize == 77) position += distance / 4;
                    else position += distance / 3;
                }
            }

            return images;
        }

        public CCSprite[] AddImageLabelCentered(int xCenter, int y, string text, int fontSize, string color = null)
        {
            var images = AddImageLabel(xCenter, y, text, fontSize, color);

            var maxRightX = images[images.Length - 1].PositionX + images[images.Length - 1].ContentSize.Width;
            var offsetX = (xCenter - maxRightX) / 2;

            foreach (var img in images)
            {
                img.PositionX += offsetX;
            }

            return images;
        }

        public void ChangeSpriteImage(CCSprite sprite, string imageName)
        {
            var texture = new CCTexture2D(GameEnvironment.ImageDirectory + imageName);
            sprite.ReplaceTexture(texture,
                new CCRect(0, 0, texture.ContentSizeInPixels.Width, texture.ContentSizeInPixels.Height));
            sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
        }

        public void ChangeSpriteImage(CCSprite sprite, CCSpriteFrame frame)
        {
            sprite.SpriteFrame = frame;
            sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
        }

        internal void FireOnTouchBegan()
        {
            OnTouchBegan?.Invoke(this, EventArgs.Empty);
        }

        
        void OnTouchesBegan(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (Enabled == false) return;

            if (touches.Count > 0 && !_buttonDown)
            {
                var buttonTouched = false;

                foreach (var touch in touches)
                {
                    foreach (var node in Children)
                    {
                        if (node is CCSpriteButton && node.Visible &&
                            node.BoundingBoxTransformedToWorld.ContainsPoint(touch.Location))
                        {
                            if (EnableMultiTouch)
                                buttonTouched = false;
                            else
                                buttonTouched = true;

                            var button = (CCSpriteButton)node;
                            if (!button.Enabled) continue;

                            CCAudioEngine.SharedEngine.StopAllEffects();

                            if (button.ButtonType == BUTTON_TYPE.Back)
                                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_BACK);
                            else if (button.ButtonType == BUTTON_TYPE.Forward)
                                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_FORWARD);
                            else if (button.ButtonType == BUTTON_TYPE.VolumeUp ||
                                     button.ButtonType == BUTTON_TYPE.VolumeDown)
                                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_VOLUME_CHANGE);
                            else if (button.ButtonType == BUTTON_TYPE.Minus)
                                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_MINUS);
                            else if (button.ButtonType == BUTTON_TYPE.Plus)
                                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_PLUS);
                            else if (button.ButtonType == BUTTON_TYPE.CannotTap)
                                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
                            else if (button.ButtonType == BUTTON_TYPE.CheckMark)
                                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CHECKMARK);
                            else if (button.ButtonType == BUTTON_TYPE.CreditPurchase)
                                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CREDITPURCHASE);
                            else if (button.ButtonType == BUTTON_TYPE.Link)
                                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.CLICK_LINK);
                            else if (button.ButtonType == BUTTON_TYPE.Rewind)
                                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.REWIND);
                            else if (button.ButtonType == BUTTON_TYPE.OnOff && button is CCSpriteTwoStateButton &&
                                     ((CCSpriteTwoStateButton)button).State == 1)
                                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.OFF);
                            else if (button.ButtonType == BUTTON_TYPE.OnOff && button is CCSpriteTwoStateButton &&
                                     ((CCSpriteTwoStateButton)button).State == 2)
                                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.ON);
                            else if (button.ButtonType != BUTTON_TYPE.Silent)
                                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP);

                            button.IsBeingTapped = true;
                            button.Texture = new CCTexture2D(button.ImageNameTapped);
                        }

                        if (node is CCNodeExt && node.Visible & node.Opacity == byte.MaxValue)
                        {
                            foreach (var node2 in node.Children)
                            {
                                if (node2 is CCSpriteButton && node2.Visible &&
                                    node2.BoundingBoxTransformedToWorld.ContainsPoint(touch.Location))
                                {
                                    buttonTouched = true;

                                    var button = (CCSpriteButton)node2;
                                    if (!button.Enabled) continue;

                                    CCAudioEngine.SharedEngine.StopAllEffects();

                                    if (button.ButtonType == BUTTON_TYPE.Back)
                                        GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_BACK);
                                    else if (button.ButtonType == BUTTON_TYPE.Forward)
                                        GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_FORWARD);
                                    else if (button.ButtonType == BUTTON_TYPE.VolumeUp ||
                                             button.ButtonType == BUTTON_TYPE.VolumeDown)
                                        GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_VOLUME_CHANGE);
                                    else if (button.ButtonType == BUTTON_TYPE.Minus)
                                        GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_MINUS);
                                    else if (button.ButtonType == BUTTON_TYPE.Plus)
                                        GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_PLUS);
                                    else if (button.ButtonType == BUTTON_TYPE.CannotTap)
                                        GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
                                    else if (button.ButtonType == BUTTON_TYPE.CheckMark)
                                        GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CHECKMARK);
                                    else if (button.ButtonType == BUTTON_TYPE.CreditPurchase)
                                        GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CREDITPURCHASE);
                                    else if (button.ButtonType == BUTTON_TYPE.Link)
                                        GameEnvironment.PlaySoundEffect(SOUNDEFFECT.CLICK_LINK);
                                    else if (button.ButtonType == BUTTON_TYPE.Rewind)
                                        GameEnvironment.PlaySoundEffect(SOUNDEFFECT.REWIND);
                                    else if (button.ButtonType == BUTTON_TYPE.OnOff &&
                                             button is CCSpriteTwoStateButton &&
                                             ((CCSpriteTwoStateButton)button).State == 1)
                                        GameEnvironment.PlaySoundEffect(SOUNDEFFECT.OFF);
                                    else if (button.ButtonType == BUTTON_TYPE.OnOff &&
                                             button is CCSpriteTwoStateButton &&
                                             ((CCSpriteTwoStateButton)button).State == 2)
                                        GameEnvironment.PlaySoundEffect(SOUNDEFFECT.ON);
                                    else if (button.ButtonType != BUTTON_TYPE.Silent)
                                        GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP);

                                    button.IsBeingTapped = true;
                                    button.Texture = new CCTexture2D(button.ImageNameTapped);
                                }

                            }
                        }

                        if (buttonTouched)
                        {
                            _buttonDown = true;
                            break;
                        }
                    }

                    if (buttonTouched)
                    {
                        break;
                    }
                }

                if (buttonTouched == false) FireOnTouchBegan();
            }
        }

        void OnTouchesEnded(List<CCTouch> touches, CCEvent touchEvent)
        {
            _buttonDown = false;
            if (Enabled == false) return;

            var buttonsToFireOnClick = new List<CCSpriteButton>();

            if (touches.Count > 0)
            {
                foreach (var touch in touches)
                {
                    foreach (var node in Children)
                    {
                        if (node is CCSpriteButton && node.Visible &&
                            node.BoundingBoxTransformedToWorld.ContainsPoint(touch.Location))
                        {
                            var button = (CCSpriteButton)node;
                            if (!button.Enabled) continue;

                            buttonsToFireOnClick.Add(button);

                            if (button is CCSpriteTwoStateButton) ((CCSpriteTwoStateButton)button).SetStateImages();
                            else button.Texture = new CCTexture2D(button.ImageNameUntapped);

                            button.IsBeingTapped = false;
                        }

                        if (node is CCNodeExt && node.Visible & node.Opacity == byte.MaxValue)
                        {
                            foreach (var node2 in node.Children)
                            {
                                if (node2 is CCSpriteButton && node2.Visible &&
                                    node2.BoundingBoxTransformedToWorld.ContainsPoint(touch.Location))
                                {
                                    var button = (CCSpriteButton)node2;
                                    if (!button.Enabled) continue;

                                    buttonsToFireOnClick.Add(button);

                                    if (button is CCSpriteTwoStateButton)
                                        ((CCSpriteTwoStateButton)button).SetStateImages();
                                    else button.Texture = new CCTexture2D(button.ImageNameUntapped);

                                    button.IsBeingTapped = false;
                                }
                            }
                        }
                    }
                }

                foreach (var button in buttonsToFireOnClick)
                {
                    button.FireOnClick();
                }

                if (EnableMultiTouch)
                    OnTouchEnded?.Invoke(this, EventArgs.Empty);
            }
        }

        void OnTouchesCancelled(List<CCTouch> touches, CCEvent touchEvent)
        {
            foreach (var node in Children)
            {
                if (node is CCSpriteButton)
                {
                    var button = (CCSpriteButton)node;

                    if (button.IsBeingTapped)
                    {
                        button.IsBeingTapped = false;
                        button.Texture = new CCTexture2D(button.ImageNameUntapped);
                    }
                }

                if (node is CCNodeExt && node.Visible & node.Opacity == byte.MaxValue)
                {
                    foreach (var node2 in node.Children)
                    {
                        if (node2 is CCSpriteButton)
                        {
                            var button = (CCSpriteButton)node2;

                            if (button.IsBeingTapped)
                            {
                                button.IsBeingTapped = false;
                                button.Texture = new CCTexture2D(button.ImageNameUntapped);
                            }
                        }
                    }
                }
            }
        }

        void OnTouchesMoved(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (touches.Count > 0)
            {
                foreach (var node in Children)
                {
                    if (node is CCSpriteButton)
                    {
                        var button = (CCSpriteButton)node;

                        if (button.IsBeingTapped &&
                            !node.BoundingBoxTransformedToWorld.ContainsPoint(touches[0].Location) && !EnableMultiTouch)
                        {
                            button.IsBeingTapped = false;
                            button.Texture = new CCTexture2D(button.ImageNameUntapped);
                            button.BlendFunc = GameEnvironment.BlendFuncDefault;
                        }
                    }

                    if (node is CCNodeExt && node.Visible & node.Opacity == byte.MaxValue)
                    {
                        foreach (var node2 in node.Children)
                        {
                            if (node2 is CCSpriteButton)
                            {
                                var button = (CCSpriteButton)node2;

                                if (button.IsBeingTapped &&
                                    !node2.BoundingBoxTransformedToWorld.ContainsPoint(touches[0].Location))
                                {
                                    button.IsBeingTapped = false;
                                    button.Texture = new CCTexture2D(button.ImageNameUntapped);
                                }
                            }
                        }
                    }
                }
            }
        }

        public void TransitionToLayer(CCLayer layer)
        {
            GC.Collect();
            //GC.WaitForPendingFinalizers();

            var gameScene = new CCScene(GameView);
            gameScene.AddLayer(layer);
            var transition = new CCTransitionFade(0.3f, gameScene);
            Director.ReplaceScene(transition);
        }

        public void TransitionToLayerCartoonStyle(CCLayerColorExt layer)
        {
            GC.Collect();
            //GC.WaitForPendingFinalizers();

            Enabled = false;
            LayerTransitionTarget = layer;

            // source          

            GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.TRANSITION_LOOP1);
            GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.TRANSITION_LOOP2);
            GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.TRANSITION_LOOP3);
            GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.TRANSITION_LOOP4);
            GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.TRANSITION_LOOP5);
            GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.TRANSITION_LOOP6);

            var framesSource = new List<CCSpriteFrame>();
            framesSource.Add(new CCSpriteFrame(
                new CCTexture2D(GameEnvironment.ImageDirectory + "UI/screen-transition_stage_1.png"),
                new CCRect(0, 0, 1136, 640)));
            framesSource.Add(new CCSpriteFrame(
                new CCTexture2D(GameEnvironment.ImageDirectory + "UI/screen-transition_stage_2.png"),
                new CCRect(0, 0, 1136, 640)));
            framesSource.Add(new CCSpriteFrame(
                new CCTexture2D(GameEnvironment.ImageDirectory + "UI/screen-transition_stage_3.png"),
                new CCRect(0, 0, 1136, 640)));
            framesSource.Add(new CCSpriteFrame(
                new CCTexture2D(GameEnvironment.ImageDirectory + "UI/screen-transition_stage_4.png"),
                new CCRect(0, 0, 1136, 640)));
            framesSource.Add(new CCSpriteFrame(
                new CCTexture2D(GameEnvironment.ImageDirectory + "UI/screen-transition_stage_5.png"),
                new CCRect(0, 0, 1136, 640)));
            framesSource.Add(new CCSpriteFrame(
                new CCTexture2D(GameEnvironment.ImageDirectory + "UI/screen-transition_stage_6.png"),
                new CCRect(0, 0, 1136, 640)));

            var animationSource = new CCAnimation(framesSource, 0.10f);

            var transitionImageSource = new CCSprite(framesSource[0]);
            transitionImageSource.AnchorPoint = new CCPoint(0, 0);
            transitionImageSource.Position = new CCPoint(0, 0);
            transitionImageSource.BlendFunc = GameEnvironment.BlendFuncDefault;
            AddChild(transitionImageSource, 9999);

            var actions = new CCFiniteTimeAction[2];
            actions[0] = new CCRepeat(new CCAnimate(animationSource), 1);
            actions[1] = new CCCallFunc(ReplaceScene);

            var seq = new CCSequence(actions);
            transitionImageSource.RunAction(seq);
            ScheduleOnce(playEffect1, 0.1f);
            ScheduleOnce(playEffect2, 0.2f);
            ScheduleOnce(playEffect3, 0.3f);
            ScheduleOnce(playEffect4, 0.4f);
            ScheduleOnce(playEffect5, 0.5f);
            ScheduleOnce(playEffect6, 0.6f);
        }

        private void playEffect1(float dt)
        {
            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.TRANSITION_LOOP1);
        }

        private void playEffect2(float dt)
        {
            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.TRANSITION_LOOP2);
        }

        private void playEffect3(float dt)
        {
            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.TRANSITION_LOOP3);
        }

        private void playEffect4(float dt)
        {
            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.TRANSITION_LOOP4);
        }

        private void playEffect5(float dt)
        {
            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.TRANSITION_LOOP5);
        }

        private void playEffect6(float dt)
        {
            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.TRANSITION_LOOP6);
        }



        public void ReplaceScene()
        {
            var newScene = new CCScene(GameView);
            LayerTransitionTarget.IsCartoonFadeIn = true;
            newScene.AddLayer(LayerTransitionTarget);
            Director.ReplaceScene(newScene);
        }


        public override void OnEnterTransitionDidFinish()
        {
            base.OnEnterTransitionDidFinish();

            if (IsCartoonFadeIn)
            {
                var framesTarget = new List<CCSpriteFrame>();
                framesTarget.Add(new CCSpriteFrame(
                    new CCTexture2D(GameEnvironment.ImageDirectory + "UI/screen-transition_stage_5.png"),
                    new CCRect(0, 0, 1136, 640)));
                framesTarget.Add(new CCSpriteFrame(
                    new CCTexture2D(GameEnvironment.ImageDirectory + "UI/screen-transition_stage_4.png"),
                    new CCRect(0, 0, 1136, 640)));
                framesTarget.Add(new CCSpriteFrame(
                    new CCTexture2D(GameEnvironment.ImageDirectory + "UI/screen-transition_stage_3.png"),
                    new CCRect(0, 0, 1136, 640)));
                framesTarget.Add(new CCSpriteFrame(
                    new CCTexture2D(GameEnvironment.ImageDirectory + "UI/screen-transition_stage_2.png"),
                    new CCRect(0, 0, 1136, 640)));
                framesTarget.Add(new CCSpriteFrame(
                    new CCTexture2D(GameEnvironment.ImageDirectory + "UI/screen-transition_stage_1.png"),
                    new CCRect(0, 0, 1136, 640)));

                var animationTarget = new CCAnimation(framesTarget, 0.10f);

                _transitionImage = new CCSprite(framesTarget[0]);
                _transitionImage.AnchorPoint = new CCPoint(0, 0);
                _transitionImage.Position = new CCPoint(0, 0);
                _transitionImage.BlendFunc = GameEnvironment.BlendFuncDefault;
                AddChild(_transitionImage, 9999);

                var actions = new CCFiniteTimeAction[2];
                actions[0] = new CCRepeat(new CCAnimate(animationTarget), 1);
                actions[1] = new CCCallFunc(RemoveTransitionImage);

                var seq = new CCSequence(actions);
                _transitionImage.RunAction(seq);

                _transitionImage.RunAction(new CCRepeat(new CCAnimate(animationTarget), 1));

                ScheduleOnce(playEffect5, 0.1f);
                ScheduleOnce(playEffect4, 0.2f);
                ScheduleOnce(playEffect3, 0.3f);
                ScheduleOnce(playEffect2, 0.4f);
                ScheduleOnce(playEffect1, 0.5f);
            }
        }

        public void RemoveTransitionImage()
        {
            _transitionImage.RemoveFromParent();
        }
    }
}