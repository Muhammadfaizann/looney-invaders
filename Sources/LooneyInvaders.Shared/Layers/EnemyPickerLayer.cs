using System;
using System.Collections.Generic;
using CocosSharp;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;
//using CCSprite = LooneyInvaders.Classes.CCSpriteWrapper;

namespace LooneyInvaders.Layers
{
    public class EnemyPickerLayer : CCLayerColorExt
    {
        private CCSprite _imgEnemyName;
        private CCSprite _imgEnemyLocked;
        private CCSprite _imgSpotlight;

        private CCSprite _centerImage;
        private CCSprite[] _images;
        private bool _isSwiping;
        private int _selectedEnemy;
        private float _lastMovement;
        private int _talkingSpriteIndex;
        private float _talkTimePassed;
        private bool _startedTalking;
        private bool _isHoldAnimations;

        private CCSpriteButton _btnBack;
        private CCSpriteButton _btnForward;
        private CCSpriteButton _btnForwardNoPasaran;

        private CCSprite _imgGameTip;
        private CCSprite _imgGameTipArrow;
        private CCSpriteButton _btnGameTipOk;
        private CCSpriteTwoStateButton _btnGameTipCheckMark;
        private CCSprite _imgGameTipCheckMarkLabel;

        //------Prabhjot -------//
        private bool _isShowGameTipViewLoaded;
        private bool _isInitialized;

        public EnemyPickerLayer()
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            SetBackground("UI/Choose-your-curtain-background-with-spotlight.jpg");

            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Bush_1_safer_world.wav");
            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Hitler_1_strenght_for_echo.wav");
            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Putin_1_Mighty_Independence.wav");
            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Kim_1_National_Strength2_Enhanced.wav");
            GameEnvironment.PreloadSoundEffect(SoundEffect.Swipe);

            if (Settings.Instance.VoiceoversEnabled)
            {
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/George Bush VO_mono.wav");
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Adolf Hitler VO_mono.wav");
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Vladimir_Putin_VO_mono.wav");
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Kim Jong-un VO_mono.wav");
            }

            //ContinueInitialize().Wait();
        }

        public override async System.Threading.Tasks.Task ContinueInitialize(bool condition = true)
        {
            if (_isInitialized)
                return;
            _isInitialized = true;

            while (await GameAnimation.Instance.PreloadNextSpriteSheetEnemiesAsync()) { }

            _btnBack = AddButton(2, 578, "UI/back-button-untapped.png", "UI/back-button-tapped.png", 500, ButtonType.Back);
            _btnBack.OnClick += BtnBack_OnClick;
            _btnBack.ButtonType = ButtonType.Back;

            Shared.GameDelegate.OnBackButton += BtnBack_OnClick;


            _btnForward = AddButton(930, 578, "UI/forward-button-untapped.png", "UI/forward-button-tapped.png", 500);
            _btnForward.OnClick += BtnForward_OnClick;
            _btnForward.ButtonType = ButtonType.Forward;

            _btnForwardNoPasaran = AddButton(930, 578, "UI/forward-button-tapped.png", "UI/forward-button-tapped.png", 500);
            _btnForwardNoPasaran.ButtonType = ButtonType.CannotTap;
            _btnForwardNoPasaran.Visible = false;


            AddImage(262, 560, "UI/Choose-your-enemy-title-text.png", 500);
            AddImage(0, 0, "UI/Background-just-curtain-with-spotlight.png", 100);

            _imgSpotlight = AddImage(370, 0, "UI/Choose-your-enemy-spotlight-front.png", 400);
            _imgSpotlight.Opacity = 0;

            var touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesBegan = OnTouchesBegan;
            touchListener.OnTouchesEnded = OnTouchesEnded;
            touchListener.OnTouchesCancelled = OnTouchesCancelled;
            touchListener.OnTouchesMoved = OnTouchesMoved;

            var enemyPositionX = 570;
            var enemyCount = 0;
            var isAliensEnabled = Player.Instance.GetSavedCountries(Battlegrounds.UnitedStates) > 0;

            if (isAliensEnabled)
            {
                _images = new CCSprite[5];
                _images[enemyCount] = AddImage(enemyPositionX, 320, "UI/Alien-C-5_00000.png", 0);
                _images[enemyCount].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[enemyCount].Scale = 1f;
                _images[enemyCount].Tag = (int)Enemies.Aliens;

                enemyPositionX += 420;
                enemyCount++;
            }
            else
            {
                _images = new CCSprite[4];
            }

            _images[enemyCount] = AddImage(enemyPositionX, 320, "UI/Hitler-Strength-E00000.png", 0);
            _images[enemyCount].AnchorPoint = new CCPoint(0.5f, 0.5f);

            if (isAliensEnabled) _images[enemyCount].Scale = 0.5f;
            else _images[enemyCount].Scale = 1f;

            _images[enemyCount].Tag = (int)Enemies.Hitler;
            enemyPositionX += 420;
            enemyCount++;

            _images[enemyCount] = AddImage(enemyPositionX, 320, "UI/Bush-Safe-C_00000.png", 0);
            _images[enemyCount].AnchorPoint = new CCPoint(0.5f, 0.5f);
            _images[enemyCount].Scale = 0.5f;
            _images[enemyCount].Tag = (int)Enemies.Bush;
            enemyPositionX += 420;
            enemyCount++;

            _images[enemyCount] = AddImage(enemyPositionX, 320, "UI/Putin-Strength-D00000.png", 0);
            _images[enemyCount].AnchorPoint = new CCPoint(0.5f, 0.5f);
            _images[enemyCount].Scale = 0.5f;
            _images[enemyCount].Tag = (int)Enemies.Putin;
            enemyPositionX += 420;
            enemyCount++;

            _images[enemyCount] = AddImage(enemyPositionX, 320, "UI/Kim-Strength-D00000.png", 0);
            _images[enemyCount].AnchorPoint = new CCPoint(0.5f, 0.5f);
            _images[enemyCount].Scale = 0.5f;
            _images[enemyCount].Tag = (int)Enemies.Kim;
            //enemyPositionX += 420;
            //enemyCount++;

            AddEventListener(touchListener, this);
            AddEventListener(touchListener);

            if (isAliensEnabled)
            {
                _centerImage = _images[0];

                _selectedEnemy = (int)Enemies.Aliens;
                _imgEnemyName = AddImage(335, -5, "UI/Choose-your-enemy-alien-text.png", 500);
                _imgEnemyName.Opacity = 0;
                _startedTalking = false;
            }
            else
            {
                _centerImage = _images[0];

                _selectedEnemy = (int)Enemies.Hitler;
                _imgEnemyName = AddImage(335, -5, "UI/Choose-your-enemy-adolf-hitler-text.png", 500);
                _imgEnemyName.Opacity = 0;
                _startedTalking = false;
            }
            _imgEnemyLocked = AddImage(1136 / 2, 410, "UI/Choose-your-enemy-george-bush-locked-text.png", 500);
            _imgEnemyLocked.AnchorPoint = new CCPoint(0.5f, 0f);
            _imgEnemyLocked.Opacity = 0;
            _imgEnemyLocked.Visible = false;

            if (Settings.Instance.NotificationsEnabled && Settings.Instance.GameTipEnemyPickerShow)
            {
                _isHoldAnimations = true;
                ShowGameTip();
            }
            else
            {
                _isHoldAnimations = false;
                //this.ScheduleOnce(delayedTalk, 1.0f); // Commented by ----------- Prabhjot -------------
            }
        }

        private void ShowGameTip()
        {
            _isHoldAnimations = true;

            //------------- Prabhjot ---------------//

            //_btnBack.Enabled = false;
            //_btnForward.Enabled = false;

            _isShowGameTipViewLoaded = true;

            _btnBack = AddButton(2, 578, "UI/back-button-tapped.png", "UI/back-button-untapped.png", 500, ButtonType.Back);
            _btnForward = AddButton(930, 578, "UI/forward-button-tapped.png", "UI/forward-button-untapped.png", 500);


            _imgGameTip = AddImage(14, 8, "UI/Choose-your-enemy-game-tip-notification-background-with-text.png", 600);
            _imgGameTipArrow = AddImage(210, 155, "UI/game-tip-notification-arrow.png", 610);

            _btnGameTipOk = AddButton(655, 35, "UI/OK-I-got-it-button-untapped.png", "UI/OK-I-got-it-button-tapped.png", 610);
            _btnGameTipOk.OnClick += btnGameTipOK_OnClick;

            _btnGameTipCheckMark = AddTwoStateButton(45, 50, "UI/check-button-untapped.png", "UI/check-button-tapped.png", "UI/check-button-tapped.png", "UI/check-button-untapped.png", 610);
            _btnGameTipCheckMark.OnClick += btnGameTipCheckMark_OnClick;
            _btnGameTipCheckMark.ButtonType = ButtonType.CheckMark;

            _imgGameTipCheckMarkLabel = AddImage(105, 60, "UI/do-not-show-text.png", 610);
            GameEnvironment.PlaySoundEffect(SoundEffect.NotificationPopUp);
        }

        private void btnGameTipOK_OnClick(object sender, EventArgs e)
        {
            Settings.Instance.GameTipEnemyPickerShow = _btnGameTipCheckMark.State != 1;

            _imgGameTip.Visible = false;
            _imgGameTipArrow.Visible = false;
            _btnGameTipOk.Visible = false;
            _btnGameTipOk.Enabled = false;
            _btnGameTipCheckMark.Visible = false;
            _btnGameTipCheckMark.Enabled = false;
            _imgGameTipCheckMarkLabel.Visible = false;

            //_btnBack.Enabled = true;
            //_btnForward.Enabled = true;
            _isHoldAnimations = false;


            //------------- Prabhjot ---------------//
            _btnBack = AddButton(2, 578, "UI/back-button-untapped.png", "UI/back-button-tapped.png", 500, ButtonType.Back);
            _btnForward = AddButton(930, 578, "UI/forward-button-untapped.png", "UI/forward-button-tapped.png", 500);
            _isShowGameTipViewLoaded = false;

            ScheduleOnce(DelayedTalk, 1f);
        }

        private void btnGameTipCheckMark_OnClick(object sender, EventArgs e)
        {
            _btnGameTipCheckMark.ChangeState();
            _btnGameTipCheckMark.SetStateImages();
        }

        private async void BtnBack_OnClick(object sender, EventArgs e)
        {
            //------------- Prabhjot ---------------//
            if (_isShowGameTipViewLoaded)
            {
                GameEnvironment.PlaySoundEffect(SoundEffect.MenuTapCannotTap);
                return;
            }

            Shared.GameDelegate.ClearOnBackButtonEvent();
            CCAudioEngine.SharedEngine.StopAllEffects();
            _isHoldAnimations = true;
            UnscheduleAll();

            var newLayer = new MainScreenLayer();
            await TransitionToLayerCartoonStyle(newLayer);
        }

        private void BtnForward_OnClick(object sender, EventArgs e)
        {
            //------------- Prabhjot ---------------//
            if (_isShowGameTipViewLoaded)
            {
                GameEnvironment.PlaySoundEffect(SoundEffect.MenuTapCannotTap);
                return;
            }

            _isHoldAnimations = true;
            UnscheduleAll();

            TransitionToLayer(new WeaponPickerLayer(_selectedEnemy));
        }

        private void OnTouchesBegan(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (GameView == null)
                return;
            if (touches.Count > 0 && _btnBack.BoundingBoxTransformedToWorld.ContainsPoint(touches[0].Location)) return;
            if (touches.Count > 0 && _btnForward.BoundingBoxTransformedToWorld.ContainsPoint(touches[0].Location)) return;
            if (touches.Count > 0 && _btnForwardNoPasaran.BoundingBoxTransformedToWorld.ContainsPoint(touches[0].Location)) return;


            if (_isHoldAnimations) return;

            UnscheduleAll();

            CCAudioEngine.SharedEngine.StopAllEffects();
            ResetCenterImage();

            _isSwiping = true;
        }

        private void OnTouchesMoved(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (_isHoldAnimations) return;

            if (_isSwiping)
            {
                var movementX = (touches[0].Location.X - touches[0].PreviousLocation.X) / 2.0f;
                _lastMovement = movementX;

                MoveImages(movementX);
            }
        }

        private void MoveImages(float movementX)
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

            foreach (var img in _images)
            {
                img.PositionX += movementX;

                if (img.PositionX <= 150 || img.PositionX >= 990)
                {
                    img.Scale = 0.5f;
                }
                else
                {
                    var distanceFromCentre = Math.Abs(570 - img.PositionX);
                    var distancePercentage = distanceFromCentre / 420.00f;

                    img.Scale = 1.0f - 0.5f * distancePercentage;
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
                GameEnvironment.PlaySoundEffect(SoundEffect.Swipe);

                _selectedEnemy = _centerImage.Tag;

                if (_selectedEnemy == (int)Enemies.Hitler)
                {
                    ChangeSpriteImage(_imgEnemyName, "UI/Choose-your-enemy-adolf-hitler-text.png");
                    _imgEnemyLocked.Visible = false;
                }
                else if (_selectedEnemy == (int)Enemies.Bush)
                {
                    ChangeSpriteImage(_imgEnemyName, "UI/Choose-your-enemy-george-bush-text.png");
                    ChangeSpriteImage(_imgEnemyLocked, "UI/Choose-your-enemy-george-bush-locked-text.png");
                    _imgEnemyLocked.Visible = Player.Instance.GetSavedCountries(Battlegrounds.England) == 0;
                }
                else if (_selectedEnemy == (int)Enemies.Putin)
                {
                    ChangeSpriteImage(_imgEnemyName, "UI/Choose-your-enemy-vladimir-putin-text.png");
                    ChangeSpriteImage(_imgEnemyLocked, "UI/Choose-your-enemy-vladimir-putin-locked-text.png");
                    _imgEnemyLocked.Visible = Player.Instance.GetSavedCountries(Battlegrounds.Russia) == 0;
                }
                else if (_selectedEnemy == (int)Enemies.Kim)
                {
                    ChangeSpriteImage(_imgEnemyName, "UI/Choose-your-enemy-kim-jong-un-text.png");
                    ChangeSpriteImage(_imgEnemyLocked, "UI/Choose-your-enemy-kim-jong-un-locked-text.png");
                    _imgEnemyLocked.Visible = Player.Instance.GetSavedCountries(Battlegrounds.Finland) == 0;
                }
                else if (_selectedEnemy == (int)Enemies.Aliens)
                {
                    ChangeSpriteImage(_imgEnemyName, "UI/Choose-your-enemy-alien-text.png");
                    _imgEnemyLocked.Visible = false;
                }
                _btnForward.Visible = !_imgEnemyLocked.Visible;
                _btnForwardNoPasaran.Visible = _imgEnemyLocked.Visible;

            }
        }

        private void OnTouchesEnded(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (_isHoldAnimations) return;

            _isSwiping = false;

            Schedule(SnapToCentre, 0.03f);
        }

        private void OnTouchesCancelled(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (_isHoldAnimations) return;

            _isSwiping = false;

            Schedule(SnapToCentre, 0.03f);
        }

        private void SnapToCentre(float dt)
        {
            if (_isSwiping) return;

            float totalMovementX = 0;

            // inertial movement
            if (Math.Abs(_lastMovement) > AppConstants.Tolerance)
            {
                var movementX = _lastMovement * 0.8f;

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
            if (_centerImage != null && Math.Abs(_centerImage.PositionX - 570) > AppConstants.Tolerance)
            {
                var differenceX = 570 - _centerImage.PositionX;
                var snapMovement = differenceX / 5;

                if (Math.Abs(snapMovement) < 0.5f) snapMovement = Math.Sign(snapMovement) * 0.5f;

                totalMovementX += snapMovement;
            }

            if (_centerImage != null && Math.Abs(570 - _centerImage.PositionX) < 1)
                totalMovementX = 570 - _centerImage.PositionX;

            if (Math.Abs(totalMovementX) < AppConstants.Tolerance)
            {
                Unschedule(SnapToCentre);

                _startedTalking = false;
                Schedule(StartTalking, 0.025f);
            }
            else
            {
                MoveImages(totalMovementX);
            }
        }

        private void DelayedTalk(float dt)
        {
            _isHoldAnimations = false;
            Schedule(StartTalking, 0.025f);
        }

        private void StartTalking(float dt)
        {
            Unschedule(StartTalking);
            if (Settings.Instance.VoiceoversEnabled)
            {
                if (_centerImage.Tag == (int)Enemies.Bush) CCAudioEngine.SharedEngine.PlayEffect("Sounds/George Bush VO_mono.wav");
                else if (_centerImage.Tag == (int)Enemies.Hitler) CCAudioEngine.SharedEngine.PlayEffect("Sounds/Adolf Hitler VO_mono.wav");
                else if (_centerImage.Tag == (int)Enemies.Putin) CCAudioEngine.SharedEngine.PlayEffect("Sounds/Vladimir_Putin_VO_mono.wav");
                else if (_centerImage.Tag == (int)Enemies.Kim) CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim Jong-un VO_mono.wav");
                else if (_centerImage.Tag == (int)Enemies.Aliens) CCAudioEngine.SharedEngine.PlayEffect("Sounds/Space Invader VO_mono.wav");

                Schedule(StartFading, 0.025f);
                ScheduleOnce(StartStartTalking, 1.8f);
            }
            else
            {
                Schedule(StartTalking2, 0.025f);
            }
        }

        private void StartStartTalking(float dt)
        {
            Schedule(StartTalking2, 0.025f);
        }

        private int _labelOpacity;

        private void StartFading(float dt)
        {
            _labelOpacity += 10;
            if (_labelOpacity > 255) { _labelOpacity = 255; Unschedule(StartFading); }

            _imgSpotlight.Opacity = (byte)_labelOpacity;
            _imgEnemyName.Opacity = (byte)_labelOpacity;
            _imgEnemyLocked.Opacity = (byte)_labelOpacity;
        }

        private void StartTalking2(float dt)
        {
            if (!_startedTalking)
            {
                if (_centerImage.Tag == (int)Enemies.Bush) CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bush_1_safer_world.wav");
                else if (_centerImage.Tag == (int)Enemies.Hitler) CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hitler_1_strenght_for_echo.wav");
                else if (_centerImage.Tag == (int)Enemies.Putin) CCAudioEngine.SharedEngine.PlayEffect("Sounds/Putin_1_Mighty_Independence.wav");
                else if (_centerImage.Tag == (int)Enemies.Kim) CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim_1_National_Strength2_Enhanced.wav");
                else if (_centerImage.Tag == (int)Enemies.Aliens) CCAudioEngine.SharedEngine.PlayEffect("Sounds/Alien_6_dialogue 2.wav");

                _startedTalking = true;
                _talkTimePassed = 0;
            }

            _talkTimePassed += dt;

            var imageNamePrefix = "";

            if (_centerImage.Tag == (int)Enemies.Bush) imageNamePrefix = "UI/Bush-Safe-C_";
            else if (_centerImage.Tag == (int)Enemies.Hitler) imageNamePrefix = "UI/Hitler-Strength-E";
            else if (_centerImage.Tag == (int)Enemies.Putin) imageNamePrefix = "UI/Putin-Strength-D";
            else if (_centerImage.Tag == (int)Enemies.Kim) imageNamePrefix = "UI/Kim-Strength-D";
            else if (_centerImage.Tag == (int)Enemies.Aliens) imageNamePrefix = "UI/Alien-C-5_";

            _talkingSpriteIndex = Convert.ToInt32(_talkTimePassed / 0.039f);

            if (_centerImage.Tag == (int)Enemies.Bush && _talkingSpriteIndex > 94)
            {
                _talkingSpriteIndex = 0;
                Unschedule(StartTalking);
            }
            else if (_centerImage.Tag == (int)Enemies.Hitler && _talkingSpriteIndex > 151)
            {
                _talkingSpriteIndex = 0;
                Unschedule(StartTalking);
            }
            else if (_centerImage.Tag == (int)Enemies.Putin && _talkingSpriteIndex > 138)
            {
                _talkingSpriteIndex = 0;
                Unschedule(StartTalking);
            }
            else if (_centerImage.Tag == (int)Enemies.Kim && _talkingSpriteIndex > 129)
            {
                _talkingSpriteIndex = 0;
                Unschedule(StartTalking);
            }
            else if (_centerImage.Tag == (int)Enemies.Aliens && _talkingSpriteIndex > 415)
            {
                _talkingSpriteIndex = 0;
                Unschedule(StartTalking);
            }

            var imageName = imageNamePrefix + _talkingSpriteIndex.ToString("00000") + ".png";

            if (GameEnvironment.GetTotalRamSizeMb() > 500)
            {
                if (_centerImage.Tag == (int)Enemies.Hitler && _talkingSpriteIndex > 0 && _talkingSpriteIndex <= 151)
                {
                    var frame = GameAnimation.Instance.GetEnemyTalkFrame((Enemies)_centerImage.Tag, _talkingSpriteIndex);
                    _centerImage.Scale = 2;
                    ChangeSpriteImage(_centerImage, frame);
                }
                else if (_centerImage.Tag == (int)Enemies.Bush && _talkingSpriteIndex > 0 && _talkingSpriteIndex <= 94)
                {
                    var frame = GameAnimation.Instance.GetEnemyTalkFrame((Enemies)_centerImage.Tag, _talkingSpriteIndex);
                    _centerImage.Scale = 2;
                    ChangeSpriteImage(_centerImage, frame);
                }
                else if (_centerImage.Tag == (int)Enemies.Kim && _talkingSpriteIndex > 0 && _talkingSpriteIndex <= 129)
                {
                    var frame = GameAnimation.Instance.GetEnemyTalkFrame((Enemies)_centerImage.Tag, _talkingSpriteIndex);
                    _centerImage.Scale = 2;
                    ChangeSpriteImage(_centerImage, frame);
                }
                else if (_centerImage.Tag == (int)Enemies.Putin && _talkingSpriteIndex > 0 && _talkingSpriteIndex <= 138)
                {
                    var frame = GameAnimation.Instance.GetEnemyTalkFrame((Enemies)_centerImage.Tag, _talkingSpriteIndex);
                    _centerImage.Scale = 2;
                    ChangeSpriteImage(_centerImage, frame);
                }
                else if (_centerImage.Tag == (int)Enemies.Aliens && _talkingSpriteIndex > 0 && _talkingSpriteIndex <= 415)
                {
                    var frame = GameAnimation.Instance.GetEnemyTalkFrame((Enemies)_centerImage.Tag, _talkingSpriteIndex);
                    _centerImage.Scale = 2;
                    ChangeSpriteImage(_centerImage, frame);
                }
                else
                {
                    _centerImage.Scale = 1;
                    ChangeSpriteImage(_centerImage, imageName);
                }
            }

            // fade in spotlight and text
            var imgOpacity = Convert.ToInt32(_talkTimePassed * 255f) + _labelOpacity;
            if (imgOpacity > 255) imgOpacity = 255;

            _imgSpotlight.Opacity = (byte)imgOpacity;
            _imgEnemyName.Opacity = (byte)imgOpacity;
            _imgEnemyLocked.Opacity = (byte)imgOpacity;
        }

        private void ResetCenterImage()
        {
            _talkingSpriteIndex = 0;
            _imgSpotlight.Opacity = 0;
            _imgEnemyName.Opacity = 0;
            _imgEnemyLocked.Opacity = 0;
            _labelOpacity = 0;

            if (_centerImage.Tag == (int)Enemies.Bush) ChangeSpriteImage(_centerImage, "UI/Bush-Safe-C_00000.png");
            else if (_centerImage.Tag == (int)Enemies.Hitler) ChangeSpriteImage(_centerImage, "UI/Hitler-Strength-E00000.png");
            else if (_centerImage.Tag == (int)Enemies.Putin) ChangeSpriteImage(_centerImage, "UI/Putin-Strength-D00000.png");
            else if (_centerImage.Tag == (int)Enemies.Kim) ChangeSpriteImage(_centerImage, "UI/Kim-Strength-D00000.png");
            else if (_centerImage.Tag == (int)Enemies.Aliens) ChangeSpriteImage(_centerImage, "UI/Alien-C-5_00000.png");

            _centerImage.Scale = 1;
        }
    }
}

