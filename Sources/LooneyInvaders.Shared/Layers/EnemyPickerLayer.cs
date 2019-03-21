using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;

namespace LooneyInvaders.Layers
{
    public class EnemyPickerLayer : CCLayerColorExt
    {
        CCSprite _imgEnemyName;
        CCSprite _imgEnemyLocked;

        CCSprite _centerImage;
        CCSprite[] _images;
        bool _isSwiping = false;
        int _selectedEnemy;
        float _lastMovement;
        int _talkingSpriteIndex;
        float _talkTimePassed;
        bool _startedTalking = false;
        bool _isHoldAnimations = false;
        CCSprite _imgSpotlight;

        CCSpriteButton _btnBack;
        CCSpriteButton _btnForward;
        CCSpriteButton _btnForwardNoPasaran;

        CCSprite _imgGameTip;
        CCSprite _imgGameTipArrow;
        CCSpriteButton _btnGameTipOK;
        CCSpriteTwoStateButton _btnGameTipCheckMark;
        CCSprite _imgGameTipCheckMarkLabel;

        //------Prabhjot -------//
        bool _isShowGameTipViewLoaded = false;

        public EnemyPickerLayer()
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            this.SetBackground("UI/Choose-your-curtain-background-with-spotlight.jpg");

            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Bush_1_safer_world.wav");
            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Hitler_1_strenght_for_echo.wav");
            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Putin_1_Mighty_Independence.wav");
            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Kim_1_National_Strength2_Enhanced.wav");
            GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.SWIPE);

            if (Settings.Instance.VoiceoversEnabled)
            {
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/George Bush VO_mono.wav");
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Adolf Hitler VO_mono.wav");
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Vladimir_Putin_VO_mono.wav");
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Kim Jong-un VO_mono.wav");
            }

                while (GameAnimation.Instance.PreloadNextSpriteSheetEnemies()) { }            

            _btnBack = this.AddButton(2, 578, "UI/back-button-untapped.png", "UI/back-button-tapped.png", 500, BUTTON_TYPE.Back);
            _btnBack.OnClick += BtnBack_OnClick;
            _btnBack.ButtonType = BUTTON_TYPE.Back;

            Shared.GameDelegate.OnBackButton += BtnBack_OnClick;


            _btnForward = this.AddButton(930, 578, "UI/forward-button-untapped.png", "UI/forward-button-tapped.png", 500);
            _btnForward.OnClick += BtnForward_OnClick;
            _btnForward.ButtonType = BUTTON_TYPE.Forward;

            _btnForwardNoPasaran = this.AddButton(930, 578, "UI/forward-button-tapped.png", "UI/forward-button-tapped.png", 500);
            _btnForwardNoPasaran.ButtonType = BUTTON_TYPE.CannotTap;
            _btnForwardNoPasaran.Visible = false;


            this.AddImage(262, 560, "UI/Choose-your-enemy-title-text.png", 500);
            this.AddImage(0, 0, "UI/Background-just-curtain-with-spotlight.png", 100);

            _imgSpotlight = this.AddImage(370, 0, "UI/Choose-your-enemy-spotlight-front.png", 400);
            _imgSpotlight.Opacity = 0;

            var touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesBegan = OnTouchesBegan;
            touchListener.OnTouchesEnded = OnTouchesEnded;
            touchListener.OnTouchesCancelled = OnTouchesCancelled;
            touchListener.OnTouchesMoved = OnTouchesMoved;

            int enemyPositionX = 570;
            int enemyCount = 0;
            bool isAliensEnabled = Player.Instance.GetSavedCountries(BATTLEGROUNDS.UNITED_STATES)>0;

            if (isAliensEnabled)
            {
                _images = new CCSprite[5];
                _images[enemyCount] = this.AddImage(enemyPositionX, 320, "UI/Alien-C-5_00000.png", 0);
                _images[enemyCount].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[enemyCount].Scale = 1f;
                _images[enemyCount].Tag = (int)ENEMIES.ALIENS;

                enemyPositionX += 420;
                enemyCount++;
            }
            else
            {
                _images = new CCSprite[4];
            }

            _images[enemyCount] = this.AddImage(enemyPositionX, 320, "UI/Hitler-Strength-E00000.png", 0);
            _images[enemyCount].AnchorPoint = new CCPoint(0.5f, 0.5f);

            if(isAliensEnabled) _images[enemyCount].Scale = 0.5f;
            else _images[enemyCount].Scale = 1f;

            _images[enemyCount].Tag = (int)ENEMIES.HITLER;
            enemyPositionX += 420;
            enemyCount++;

            _images[enemyCount] = this.AddImage(enemyPositionX, 320, "UI/Bush-Safe-C_00000.png", 0);
            _images[enemyCount].AnchorPoint = new CCPoint(0.5f, 0.5f);
            _images[enemyCount].Scale = 0.5f;
            _images[enemyCount].Tag = (int)ENEMIES.BUSH;
            enemyPositionX += 420;
            enemyCount++;

            _images[enemyCount] = this.AddImage(enemyPositionX, 320, "UI/Putin-Strength-D00000.png", 0);
            _images[enemyCount].AnchorPoint = new CCPoint(0.5f, 0.5f);
            _images[enemyCount].Scale = 0.5f;
            _images[enemyCount].Tag = (int)ENEMIES.PUTIN;
            enemyPositionX += 420;
            enemyCount++;

            _images[enemyCount] = this.AddImage(enemyPositionX, 320, "UI/Kim-Strength-D00000.png", 0);
            _images[enemyCount].AnchorPoint = new CCPoint(0.5f, 0.5f);
            _images[enemyCount].Scale = 0.5f;
            _images[enemyCount].Tag = (int)ENEMIES.KIM;
            enemyPositionX += 420;
            enemyCount++;

            AddEventListener(touchListener, this);
            this.AddEventListener(touchListener);

            if (isAliensEnabled)
            {
                _centerImage = _images[0];

                _selectedEnemy = (int)ENEMIES.ALIENS;
                _imgEnemyName = this.AddImage(335, -5, "UI/Choose-your-enemy-alien-text.png", 500);
                _imgEnemyName.Opacity = 0;
                _startedTalking = false;
            }
            else
            {
                _centerImage = _images[0];

                _selectedEnemy = (int)ENEMIES.HITLER;
                _imgEnemyName = this.AddImage(335, -5, "UI/Choose-your-enemy-adolf-hitler-text.png", 500);
                _imgEnemyName.Opacity = 0;
                _startedTalking = false;
            }
            _imgEnemyLocked = this.AddImage(1136/2, 410, "UI/Choose-your-enemy-george-bush-locked-text.png", 500);
            _imgEnemyLocked.AnchorPoint = new CCPoint(0.5f, 0f);
            _imgEnemyLocked.Opacity = 0;
            _imgEnemyLocked.Visible = false;

            if (Settings.Instance.NotificationsEnabled && Settings.Instance.GameTipEnemyPickerShow)
            {
                _isHoldAnimations = true;
                showGameTip();
            }
            else
            {
                _isHoldAnimations = false;
                //this.ScheduleOnce(delayedTalk, 1.0f); // Commented by ----------- Prabhjot -------------
            }
        }
        
        private void showGameTip()
        {            
            _isHoldAnimations = true;

            //------------- Prabhjot ---------------//

            //_btnBack.Enabled = false;
            //_btnForward.Enabled = false;

            _isShowGameTipViewLoaded = true;

            _btnBack = this.AddButton(2, 578, "UI/back-button-tapped.png", "UI/back-button-untapped.png", 500, BUTTON_TYPE.Back);
            _btnForward = this.AddButton(930, 578, "UI/forward-button-tapped.png", "UI/forward-button-untapped.png", 500);


            _imgGameTip = this.AddImage(14, 8, "UI/Choose-your-enemy-game-tip-notification-background-with-text.png", 600);
            _imgGameTipArrow = this.AddImage(210, 155, "UI/game-tip-notification-arrow.png", 610);

            _btnGameTipOK = this.AddButton(655, 35, "UI/OK-I-got-it-button-untapped.png", "UI/OK-I-got-it-button-tapped.png", 610);
            _btnGameTipOK.OnClick += btnGameTipOK_OnClick;

            _btnGameTipCheckMark = this.AddTwoStateButton(45, 50, "UI/check-button-untapped.png", "UI/check-button-tapped.png", "UI/check-button-tapped.png", "UI/check-button-untapped.png", 610);
            _btnGameTipCheckMark.OnClick += btnGameTipCheckMark_OnClick;
            _btnGameTipCheckMark.ButtonType = BUTTON_TYPE.CheckMark;

            _imgGameTipCheckMarkLabel = this.AddImage(105, 60, "UI/do-not-show-text.png", 610);
            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.NOTIFICATION_POP_UP);
        }

        private void btnGameTipOK_OnClick(object sender, EventArgs e)
        {
            Settings.Instance.GameTipEnemyPickerShow = _btnGameTipCheckMark.State == 1 ? false : true;

            _imgGameTip.Visible = false;
            _imgGameTipArrow.Visible = false;
            _btnGameTipOK.Visible = false;
            _btnGameTipOK.Enabled = false;
            _btnGameTipCheckMark.Visible = false;
            _btnGameTipCheckMark.Enabled = false;
            _imgGameTipCheckMarkLabel.Visible = false;

            //_btnBack.Enabled = true;
            //_btnForward.Enabled = true;
            _isHoldAnimations = false;


            //------------- Prabhjot ---------------//
            _btnBack = this.AddButton(2, 578, "UI/back-button-untapped.png", "UI/back-button-tapped.png", 500, BUTTON_TYPE.Back);
            _btnForward = this.AddButton(930, 578, "UI/forward-button-untapped.png", "UI/forward-button-tapped.png", 500);
            _isShowGameTipViewLoaded = false;

            this.ScheduleOnce(delayedTalk, 1f);
        }

        private void btnGameTipCheckMark_OnClick(object sender, EventArgs e)
        {
            _btnGameTipCheckMark.ChangeState();
            _btnGameTipCheckMark.SetStateImages();
        }

        private void BtnBack_OnClick(object sender, EventArgs e)
        {
            //------------- Prabhjot ---------------//
            if (_isShowGameTipViewLoaded == true)
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
                return;
            }

            Shared.GameDelegate.ClearOnBackButtonEvent();
            CCAudioEngine.SharedEngine.StopAllEffects();
            _isHoldAnimations = true;
            this.UnscheduleAll();

            this.TransitionToLayerCartoonStyle(new MainScreenLayer());
        }

        private void BtnForward_OnClick(object sender, EventArgs e)
        {
            //------------- Prabhjot ---------------//
            if (_isShowGameTipViewLoaded == true)
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
                return;
            }

            _isHoldAnimations = true;
            this.UnscheduleAll();
            
            this.TransitionToLayer(new WeaponPickerLayer(this._selectedEnemy));
        }

        void OnTouchesBegan(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (touches.Count > 0 && _btnBack.BoundingBoxTransformedToWorld.ContainsPoint(touches[0].Location)) return;
            if (touches.Count > 0 && _btnForward.BoundingBoxTransformedToWorld.ContainsPoint(touches[0].Location)) return;
            if (touches.Count > 0 && _btnForwardNoPasaran.BoundingBoxTransformedToWorld.ContainsPoint(touches[0].Location)) return;


            if (_isHoldAnimations) return;

            this.UnscheduleAll();

            CCAudioEngine.SharedEngine.StopAllEffects();
            resetCenterImage();

            _isSwiping = true;
        }

        void OnTouchesMoved(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (_isHoldAnimations) return;

            if (_isSwiping)
            {
                float movementX = (touches[0].Location.X - touches[0].PreviousLocation.X) / 2.0f;
                _lastMovement = movementX;

                moveImages(movementX);
            }
        }

        private void moveImages(float movementX)
        {
            if (_images[0].PositionX + movementX > 570)
            {
                _lastMovement = 0;
                movementX = 570 - _images[0].PositionX;
            }
            else if (_images[_images.Length - 1].PositionX + movementX < 568)
            {
                _lastMovement = 0;
                movementX = 570 - _images[_images.Length - 1].PositionX;
            }

            foreach (CCSprite img in _images)
            {
                img.PositionX += movementX;

                if (img.PositionX <= 150 || img.PositionX >= 990)
                {
                    img.Scale = 0.5f;
                }
                else
                {
                    float distanceFromCentre = Math.Abs(570 - img.PositionX);
                    float distancePercentage = distanceFromCentre / 420.00f;

                    img.Scale = 1.0f - (0.5f * distancePercentage);
                }

//                // circular motion
//                if (img.PositionX > 1410) img.PositionX = -270 + img.PositionX - 1410;
//                else if (img.PositionX < -270) img.PositionX = 1410 + img.PositionX + 270;

                if (_centerImage == null) _centerImage = img;
                else if (Math.Abs(570 - img.PositionX) < Math.Abs(570 - _centerImage.PositionX)) _centerImage = img;
            }

            if (_centerImage.Tag != _selectedEnemy)
            {
                CCAudioEngine.SharedEngine.StopAllEffects();
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.SWIPE);

                _selectedEnemy = _centerImage.Tag;
                
                if (_selectedEnemy == (int)ENEMIES.HITLER)
                {
                    this.ChangeSpriteImage(_imgEnemyName, "UI/Choose-your-enemy-adolf-hitler-text.png");
                    _imgEnemyLocked.Visible = false;
                }
                else if (_selectedEnemy == (int)ENEMIES.BUSH)
                {
                    this.ChangeSpriteImage(_imgEnemyName, "UI/Choose-your-enemy-george-bush-text.png");
                    this.ChangeSpriteImage(_imgEnemyLocked, "UI/Choose-your-enemy-george-bush-locked-text.png");
                    _imgEnemyLocked.Visible = Player.Instance.GetSavedCountries(BATTLEGROUNDS.ENGLAND) == 0;
                }
                else if (_selectedEnemy == (int)ENEMIES.PUTIN)
                {
                    this.ChangeSpriteImage(_imgEnemyName, "UI/Choose-your-enemy-vladimir-putin-text.png");
                    this.ChangeSpriteImage(_imgEnemyLocked, "UI/Choose-your-enemy-vladimir-putin-locked-text.png");
                    _imgEnemyLocked.Visible = Player.Instance.GetSavedCountries(BATTLEGROUNDS.RUSSIA) == 0;
                }
                else if (_selectedEnemy == (int)ENEMIES.KIM)
                {
                    this.ChangeSpriteImage(_imgEnemyName, "UI/Choose-your-enemy-kim-jong-un-text.png");
                    this.ChangeSpriteImage(_imgEnemyLocked, "UI/Choose-your-enemy-kim-jong-un-locked-text.png");
                    _imgEnemyLocked.Visible = Player.Instance.GetSavedCountries(BATTLEGROUNDS.FINLAND) == 0;
                }
                else if (_selectedEnemy == (int)ENEMIES.ALIENS)
                {
                    this.ChangeSpriteImage(_imgEnemyName, "UI/Choose-your-enemy-alien-text.png");
                    _imgEnemyLocked.Visible = false;
                }
                _btnForward.Visible = !_imgEnemyLocked.Visible;
                _btnForwardNoPasaran.Visible = _imgEnemyLocked.Visible;

            }
        }

        void OnTouchesEnded(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (_isHoldAnimations) return;

            _isSwiping = false;

            Schedule(snapToCentre, 0.03f);
        }

        void OnTouchesCancelled(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (_isHoldAnimations) return;

            _isSwiping = false;

            Schedule(snapToCentre, 0.03f);
        }

        void snapToCentre(float dt)
        {
            if (_isSwiping) return;

            float totalMovementX = 0;

            // inertial movement
            if (_lastMovement != 0)
            {
                float movementX = _lastMovement * 0.8f;

                if (Math.Abs(movementX) < 1)
                {
                    movementX = 1 * Math.Sign(movementX);
                    _lastMovement = 0;
                }
                else
                {
                    _lastMovement = movementX;
                }

                totalMovementX += movementX;
            }            

            // snap to center
            if (_centerImage != null && _centerImage.PositionX != 570)
            {
                float differenceX = 570 - _centerImage.PositionX;
                float snapMovement = differenceX / 5;

                if (Math.Abs(snapMovement) < 0.5f) snapMovement = Math.Sign(snapMovement) * 0.5f;

                totalMovementX += snapMovement;                
            }

            if (Math.Abs(570 -_centerImage.PositionX) < 1) totalMovementX = 570 - _centerImage.PositionX;

            if (totalMovementX == 0)
            {
                this.Unschedule(snapToCentre);

                _startedTalking = false;
                this.Schedule(startTalking, 0.025f);
            }
            else
            {
                moveImages(totalMovementX);
            }
        }

        void delayedTalk(float dt)
        {
            _isHoldAnimations = false;
            this.Schedule(startTalking, 0.025f);
        }

        void startTalking(float dt)
        {
            this.Unschedule(startTalking);
            if (Settings.Instance.VoiceoversEnabled)
            {
                if (_centerImage.Tag == (int)ENEMIES.BUSH) CCAudioEngine.SharedEngine.PlayEffect("Sounds/George Bush VO_mono.wav");
                else if (_centerImage.Tag == (int)ENEMIES.HITLER) CCAudioEngine.SharedEngine.PlayEffect("Sounds/Adolf Hitler VO_mono.wav");
                else if (_centerImage.Tag == (int)ENEMIES.PUTIN) CCAudioEngine.SharedEngine.PlayEffect("Sounds/Vladimir_Putin_VO_mono.wav");
                else if (_centerImage.Tag == (int)ENEMIES.KIM) CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim Jong-un VO_mono.wav");
                else if (_centerImage.Tag == (int)ENEMIES.ALIENS) CCAudioEngine.SharedEngine.PlayEffect("Sounds/Space Invader VO_mono.wav");

                this.Schedule(startFading, 0.025f);
                this.ScheduleOnce(startStartTalking, 1.8f);
            }
            else
            {
                this.Schedule(startTalking2, 0.025f);
            }
        }

        void startStartTalking (float dt)
        {
            this.Schedule(startTalking2, 0.025f);
        }

        int labelOpacity = 0;

        void startFading(float dt)
        {
            labelOpacity += 10;
            if (labelOpacity > 255) { labelOpacity = 255; this.Unschedule(startFading); }

            _imgSpotlight.Opacity = (byte)labelOpacity;
            _imgEnemyName.Opacity = (byte)labelOpacity;
            _imgEnemyLocked.Opacity = (byte)labelOpacity;
        }

        void startTalking2(float dt)
        {
            if (!_startedTalking)
            {
                if (_centerImage.Tag == (int)ENEMIES.BUSH) CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bush_1_safer_world.wav");
                else if (_centerImage.Tag == (int)ENEMIES.HITLER) CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hitler_1_strenght_for_echo.wav");
                else if (_centerImage.Tag == (int)ENEMIES.PUTIN) CCAudioEngine.SharedEngine.PlayEffect("Sounds/Putin_1_Mighty_Independence.wav");
                else if (_centerImage.Tag == (int)ENEMIES.KIM) CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim_1_National_Strength2_Enhanced.wav");
                else if (_centerImage.Tag == (int)ENEMIES.ALIENS) CCAudioEngine.SharedEngine.PlayEffect("Sounds/Alien_6_dialogue 2.wav");

                _startedTalking = true;
                _talkTimePassed = 0;
            }            

            _talkTimePassed += dt;
            
            string imageNamePrefix = "";

            if (_centerImage.Tag == (int)ENEMIES.BUSH) imageNamePrefix = "UI/Bush-Safe-C_";
            else if (_centerImage.Tag == (int)ENEMIES.HITLER) imageNamePrefix = "UI/Hitler-Strength-E";
            else if (_centerImage.Tag == (int)ENEMIES.PUTIN) imageNamePrefix = "UI/Putin-Strength-D";
            else if (_centerImage.Tag == (int)ENEMIES.KIM) imageNamePrefix = "UI/Kim-Strength-D";
            else if (_centerImage.Tag == (int)ENEMIES.ALIENS) imageNamePrefix = "UI/Alien-C-5_";

            _talkingSpriteIndex = Convert.ToInt32(_talkTimePassed / 0.039f);
            
            if (_centerImage.Tag == (int)ENEMIES.BUSH && _talkingSpriteIndex > 94)
            {
                _talkingSpriteIndex = 0;
                this.Unschedule(startTalking);
            }
            else if (_centerImage.Tag == (int)ENEMIES.HITLER && _talkingSpriteIndex > 151)
            {
                _talkingSpriteIndex = 0;
                this.Unschedule(startTalking);
            }
            else if (_centerImage.Tag == (int)ENEMIES.PUTIN && _talkingSpriteIndex > 138)
            {
                _talkingSpriteIndex = 0;
                this.Unschedule(startTalking);
            }
            else if (_centerImage.Tag == (int)ENEMIES.KIM && _talkingSpriteIndex > 129)
            {
                _talkingSpriteIndex = 0;
                this.Unschedule(startTalking);
            }
            else if (_centerImage.Tag == (int)ENEMIES.ALIENS && _talkingSpriteIndex > 415)
            {
                _talkingSpriteIndex = 0;
                this.Unschedule(startTalking);
            }

            string imageName = imageNamePrefix + _talkingSpriteIndex.ToString("00000") + ".png";

            if (GameEnvironment.GetTotalRAMSizeMB() > 500)
            {
                if (_centerImage.Tag == (int)ENEMIES.HITLER && _talkingSpriteIndex > 0 && _talkingSpriteIndex <= 151)
                {
                    CCSpriteFrame frame = GameAnimation.Instance.GetEnemyTalkFrame((ENEMIES)_centerImage.Tag, _talkingSpriteIndex);
                    _centerImage.Scale = 2;
                    this.ChangeSpriteImage(_centerImage, frame);
                }
                else if (_centerImage.Tag == (int)ENEMIES.BUSH && _talkingSpriteIndex > 0 && _talkingSpriteIndex <= 94)
                {
                    CCSpriteFrame frame = GameAnimation.Instance.GetEnemyTalkFrame((ENEMIES)_centerImage.Tag, _talkingSpriteIndex);
                    _centerImage.Scale = 2;
                    this.ChangeSpriteImage(_centerImage, frame);
                }
                else if (_centerImage.Tag == (int)ENEMIES.KIM && _talkingSpriteIndex > 0 && _talkingSpriteIndex <= 129)
                {
                    CCSpriteFrame frame = GameAnimation.Instance.GetEnemyTalkFrame((ENEMIES)_centerImage.Tag, _talkingSpriteIndex);
                    _centerImage.Scale = 2;
                    this.ChangeSpriteImage(_centerImage, frame);
                }
                else if (_centerImage.Tag == (int)ENEMIES.PUTIN && _talkingSpriteIndex > 0 && _talkingSpriteIndex <= 138)
                {
                    CCSpriteFrame frame = GameAnimation.Instance.GetEnemyTalkFrame((ENEMIES)_centerImage.Tag, _talkingSpriteIndex);
                    _centerImage.Scale = 2;
                    this.ChangeSpriteImage(_centerImage, frame);
                }
                else if (_centerImage.Tag == (int)ENEMIES.ALIENS && _talkingSpriteIndex > 0 && _talkingSpriteIndex <= 415)
                {   
                    CCSpriteFrame frame = GameAnimation.Instance.GetEnemyTalkFrame((ENEMIES)_centerImage.Tag, _talkingSpriteIndex);
                    _centerImage.Scale = 2;
                    this.ChangeSpriteImage(_centerImage, frame);
                }
                else
                {
                    _centerImage.Scale = 1;
                    this.ChangeSpriteImage(_centerImage, imageName);
                }
            }

            // fade in spotlight and text
            int imgOpacity = Convert.ToInt32(_talkTimePassed * 255f) + labelOpacity;
            if (imgOpacity > 255) imgOpacity = 255;

            _imgSpotlight.Opacity = (byte)imgOpacity;
            _imgEnemyName.Opacity = (byte)imgOpacity;
            _imgEnemyLocked.Opacity = (byte)imgOpacity;
        }

        private void resetCenterImage()
        {
            _talkingSpriteIndex = 0;
            _imgSpotlight.Opacity = 0;
            _imgEnemyName.Opacity = 0;
            _imgEnemyLocked.Opacity = 0;
            labelOpacity = 0;

            if (_centerImage.Tag == (int)ENEMIES.BUSH) this.ChangeSpriteImage(_centerImage, "UI/Bush-Safe-C_00000.png");
            else if (_centerImage.Tag == (int)ENEMIES.HITLER) this.ChangeSpriteImage(_centerImage, "UI/Hitler-Strength-E00000.png");
            else if (_centerImage.Tag == (int)ENEMIES.PUTIN) this.ChangeSpriteImage(_centerImage, "UI/Putin-Strength-D00000.png");
            else if (_centerImage.Tag == (int)ENEMIES.KIM) this.ChangeSpriteImage(_centerImage, "UI/Kim-Strength-D00000.png");
            else if (_centerImage.Tag == (int)ENEMIES.ALIENS) this.ChangeSpriteImage(_centerImage, "UI/Alien-C-5_00000.png");

            _centerImage.Scale = 1;
        }
    }
}

