using System;
using System.Collections.Generic;
using CocosSharp;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;

namespace LooneyInvaders.Layers
{
    public class BattlegroundPickerLayer : CCLayerColorExt
    {
        private CCSprite _centerImage;
        private readonly CCSprite[] _images = new CCSprite[5];
        private readonly CCSprite _imgBattlegroundLocked;
        private readonly CCSprite _imgBattlegroundName;

        private CCSpriteButton _btnBack;
        private CCSpriteButton _btnForward;

        private CCSprite _imgGameTip;
        private CCSprite _imgGameTipArrow;
        private CCSpriteButton _btnGameTipOk;
        private CCSpriteTwoStateButton _btnGameTipCheckMark;
        private CCSprite _imgGameTipCheckMarkLabel;

        private bool _isSwiping;
        private int _selectedBattleground;
        private float _lastMovement;
        private bool _isHoldAnimations;
        private float _nameDisplayTimePassed;
        private bool _startedDisplayingName;
        private bool _startedTalking;

        private readonly int _selectedEnemy;
        private readonly int _selectedWeapon;

        private readonly CCSpriteSheet[] _ssFirework;
        private int _fireworkFrame;
        private CCSprite _firework;

        //------Prabhjot -------//
        private bool _isShowGameTipViewLoaded;

        public BattlegroundPickerLayer(int selectedEnemy, int selectedWeapon)
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            GameEnvironment.PreloadSoundEffect(SoundEffect.Swipe);

            _selectedEnemy = selectedEnemy;
            _selectedWeapon = selectedWeapon;



            if (_selectedEnemy == (int)Enemies.Hitler)
            {
                /*if (Settings.Instance.VoiceoversEnabled)
                {
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Norway VO_mono.wav");
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Poland VO_mono.wav");
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/England VO_mono.wav");
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Denmark VO_mono.wav");
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/France VO_mono.wav");

                }
                else
                {*/
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Hitler countries Poland.wav");
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Hitler countries Denmark.wav");
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Hitler countries Norway.wav");
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Hitler countries France.wav");
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Hitler countries England.wav");
                /* }*/
            }
            else if (_selectedEnemy == (int)Enemies.Bush)
            {
                /* if (Settings.Instance.VoiceoversEnabled)
                 {
                     CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Vietnam VO_mono.wav");
                     CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Russia VO_mono.wav");
                     CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Libya VO_mono.wav");
                     CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Afghanistan VO_mono.wav");
                     CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Irak VO_mono.wav");
                 }
                 else
                 {*/
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Bush countries Vietman.wav");
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Bush countries Irak.wav");
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Bush countries Afganistan.wav");
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Bush countries Libya.wav");
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Bush countries Russian.wav");
                /*}*/
            }
            else if (_selectedEnemy == (int)Enemies.Putin)
            {
                /* if (Settings.Instance.VoiceoversEnabled)
                 {
                     CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Syria VO_mono.wav");
                     CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Georgia VO_mono.wav");
                     CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Finland VO_mono.wav");
                     CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Estonia VO_mono.wav");
                     CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Ukraine VO_mono.wav");
                 }
                 else
                 {*/
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Putin countries Georgia.wav");
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Putin countries Ukraine.wav");
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Putin countries Syria.wav");
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Putin countries Estonia.wav");
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Putin countries Finland.wav");
                /* }*/
                _ssFirework = new CCSpriteSheet[2];
                _ssFirework[0] = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/firework-0.plist");
                _ssFirework[1] = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/firework-1.plist");
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Firework Sound Effect mono.wav");

            }
            else if (_selectedEnemy == (int)Enemies.Kim)
            {
                /*  if (Settings.Instance.VoiceoversEnabled)
                  {
                      CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Great Britain VO_mono.wav");
                      CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Israel VO_mono.wav");
                      CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Japan VO_mono.wav");
                      CCAudioEngine.SharedEngine.PreloadEffect("Sounds/South Korea VO_mono.wav");
                      CCAudioEngine.SharedEngine.PreloadEffect("Sounds/USA VO_mono.wav");
                  }
                  else
                  {*/
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Kim countries South Korea.wav");
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Kim countries Israel.wav");
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Kim countries Japan.wav");
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Kim countries Great Britain.wav");
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Kim countries United States.wav");
                /*}*/
            }

            _btnBack = AddButton(2, 578, "UI/back-button-untapped.png", "UI/back-button-tapped.png", 500, ButtonType.Back);
            _btnBack.OnClick += BtnBack_OnClick;
            _btnBack.ButtonType = ButtonType.Back;

            Shared.GameDelegate.OnBackButton += BtnBack_OnClick;

            _btnForward = AddButton(930, 578, "UI/forward-button-untapped.png", "UI/forward-button-tapped.png", 500);
            _btnForward.OnClick += BtnForward_OnClick;
            _btnForward.ButtonType = ButtonType.Forward;

            AddImage(353, 507, "UI/Choose-the-battleground-title-text.png", 500);
            AddImage(442, 262, "UI/Choose-the-battleground-vs-text.png", 500);

            _imgBattlegroundName = AddImage(0, -5, "UI/Choose-the-battleground-in-georgia-text.png", 500);

            _imgBattlegroundLocked = AddImage(45, 138, "UI/Choose-the-battleground-battleground-locked-text.png", 600);
            _imgBattlegroundLocked.Visible = false;

            var touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesBegan = OnTouchesBegan;
            touchListener.OnTouchesEnded = OnTouchesEnded;
            touchListener.OnTouchesCancelled = OnTouchesCancelled;
            touchListener.OnTouchesMoved = OnTouchesMoved;

            FillBattlegrounds();
            SetBattlegroundName();

            if (_selectedEnemy == (int)Enemies.Hitler) AddImage(85, 140, "UI/Choose-the-battleground-Adolf-Hitler.png", 0);
            else if (_selectedEnemy == (int)Enemies.Bush) AddImage(85, 140, "UI/Choose-the-battleground_George_Bush.png", 0);
            else if (_selectedEnemy == (int)Enemies.Putin) AddImage(85, 140, "UI/Choose-the-battleground-Vladimir-Putin.png", 2);
            else if (_selectedEnemy == (int)Enemies.Kim) AddImage(85, 140, "UI/Choose-the-battleground-Kim_Jong-un.png", 0);
            else if (_selectedEnemy == (int)Enemies.Aliens) AddImage(85, 140, "UI/Alien-C-5_00000.png", 0);

            if (_selectedWeapon == (int)Weapons.Standard) AddImage(700, 40, "UI/Choose-the-battleground-standard_gun.png", 2);
            else if (_selectedWeapon == (int)Weapons.Compact) AddImage(700, 40, "UI/Choose-the-battleground-compact_sprayer.png", 2);
            else if (_selectedWeapon == (int)Weapons.Bazooka) AddImage(700, 40, "UI/Choose-the-battleground-black_bazooka.png", 2);

            AddEventListener(touchListener, this);
            AddEventListener(touchListener);

            if (Settings.Instance.NotificationsEnabled && Settings.Instance.GameTipBattlegroundPickerShow)
            {
                _isHoldAnimations = true;
                ShowGameTip();
            }
            else
            {
                /* if (Settings.Instance.VoiceoversEnabled)
                 {
                     if (_selectedEnemy == (int)ENEMIES.HITLER)
                     {
                         CCAudioEngine.SharedEngine.PlayEffect("Sounds/Poland VO_mono.wav");
                     }
                     else if (_selectedEnemy == (int)ENEMIES.BUSH)
                     {
                         CCAudioEngine.SharedEngine.PlayEffect("Sounds/Vietnam VO_mono.wav");
                     }
                     else if (_selectedEnemy == (int)ENEMIES.PUTIN)
                     {
                         CCAudioEngine.SharedEngine.PlayEffect("Sounds/Georgia VO_mono.wav");

                     }
                     else if (_selectedEnemy == (int)ENEMIES.KIM)
                     {
                         CCAudioEngine.SharedEngine.PlayEffect("Sounds/South Korea VO_mono.wav");
                     }
                 }
                 else
                 {*/
                if (_selectedEnemy == (int)Enemies.Hitler)
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hitler countries Poland.wav");
                }
                else if (_selectedEnemy == (int)Enemies.Bush)
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bush countries Vietman.wav");
                }
                else if (_selectedEnemy == (int)Enemies.Putin)
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Putin countries Georgia.wav");

                }
                else if (_selectedEnemy == (int)Enemies.Kim)
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim countries South Korea.wav");
                }
                /*}*/
            }
        }

        // TODO: staviti da ide preko poziva GetBattlegroundImageName
        private void FillBattlegrounds()
        {
            string battlegroundStyle;

            if (Settings.Instance.BattlegroundStyle == BattlegroundStyle.Cartonic) battlegroundStyle = "cartonic";
            else battlegroundStyle = "realistic";

            if (_selectedEnemy == (int)Enemies.Hitler)
            {
                _images[0] = AddImage(568, 320, "Battlegrounds/poland_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[0].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[0].Tag = (int)Battlegrounds.Poland;

                if (Player.Instance.GetSavedCountries(Battlegrounds.Poland) > 0)
                    _images[1] = AddImage(568 + 1136, 320, "Battlegrounds/denmark_" + battlegroundStyle + "_1136x640.jpg", 0);
                else
                    _images[1] = AddImage(568 + 1136, 320, "Battlegrounds/denmark_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[1].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[1].Tag = (int)Battlegrounds.Denmark;

                if (Player.Instance.GetSavedCountries(Battlegrounds.Denmark) > 0)
                    _images[2] = AddImage(568 + 1136 * 2, 320, "Battlegrounds/norway_" + battlegroundStyle + "_1136x640.jpg", 0);
                else
                    _images[2] = AddImage(568 + 1136 * 2, 320, "Battlegrounds/norway_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[2].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[2].Tag = (int)Battlegrounds.Norway;

                if (Player.Instance.GetSavedCountries(Battlegrounds.Norway) > 0)
                    _images[3] = AddImage(568 + 1136 * 3, 320, "Battlegrounds/france_" + battlegroundStyle + "_1136x640.jpg", 0);
                else
                    _images[3] = AddImage(568 + 1136 * 3, 320, "Battlegrounds/france_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[3].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[3].Tag = (int)Battlegrounds.France;

                if (Player.Instance.GetSavedCountries(Battlegrounds.France) > 0)
                    _images[4] = AddImage(568 + 1136 * 4, 320, "Battlegrounds/england_" + battlegroundStyle + "_1136x640.jpg", 0);
                else
                    _images[4] = AddImage(568 + 1136 * 4, 320, "Battlegrounds/england_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[4].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[4].Tag = (int)Battlegrounds.England;

                _selectedBattleground = (int)Battlegrounds.Poland;
            }
            else if (_selectedEnemy == (int)Enemies.Bush)
            {
                _images[0] = AddImage(568, 320, "Battlegrounds/vietnam_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[0].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[0].Tag = (int)Battlegrounds.Vietnam;

                if (Player.Instance.GetSavedCountries(Battlegrounds.Vietnam) > 0)
                    _images[1] = AddImage(568 + 1136, 320, "Battlegrounds/iraq_" + battlegroundStyle + "_1136x640.jpg", 0);
                else
                    _images[1] = AddImage(568 + 1136, 320, "Battlegrounds/iraq_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[1].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[1].Tag = (int)Battlegrounds.Iraq;

                if (Player.Instance.GetSavedCountries(Battlegrounds.Iraq) > 0)
                    _images[2] = AddImage(568 + 1136 * 2, 320, "Battlegrounds/afganistan_" + battlegroundStyle + "_1136x640.jpg", 0);
                else
                    _images[2] = AddImage(568 + 1136 * 2, 320, "Battlegrounds/afganistan_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[2].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[2].Tag = (int)Battlegrounds.Afghanistan;

                if (Player.Instance.GetSavedCountries(Battlegrounds.Afghanistan) > 0)
                    _images[3] = AddImage(568 + 1136 * 3, 320, "Battlegrounds/libya_" + battlegroundStyle + "_1136x640.jpg", 0);
                else
                    _images[3] = AddImage(568 + 1136 * 3, 320, "Battlegrounds/libya_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[3].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[3].Tag = (int)Battlegrounds.Libya;

                if (Player.Instance.GetSavedCountries(Battlegrounds.Libya) > 0)
                    _images[4] = AddImage(568 + 1136 * 4, 320, "Battlegrounds/russia_" + battlegroundStyle + "_1136x640.jpg", 0);
                else
                    _images[4] = AddImage(568 + 1136 * 4, 320, "Battlegrounds/russia_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[4].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[4].Tag = (int)Battlegrounds.Russia;

                _selectedBattleground = (int)Battlegrounds.Vietnam;
            }
            else if (_selectedEnemy == (int)Enemies.Putin)
            {
                _images[0] = AddImage(568, 320, "Battlegrounds/georgia_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[0].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[0].Tag = (int)Battlegrounds.Georgia;

                if (Player.Instance.GetSavedCountries(Battlegrounds.Georgia) > 0)
                    _images[1] = AddImage(568 + 1136, 320, "Battlegrounds/ukraine_" + battlegroundStyle + "_1136x640.jpg", 0);
                else
                    _images[1] = AddImage(568 + 1136, 320, "Battlegrounds/ukraine_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[1].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[1].Tag = (int)Battlegrounds.Ukraine;

                if (Player.Instance.GetSavedCountries(Battlegrounds.Ukraine) > 0)
                    _images[2] = AddImage(568 + 1136 * 2, 320, "Battlegrounds/syria_" + battlegroundStyle + "_1136x640.jpg", 0);
                else
                    _images[2] = AddImage(568 + 1136 * 2, 320, "Battlegrounds/syria_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[2].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[2].Tag = (int)Battlegrounds.Syria;

                if (Player.Instance.GetSavedCountries(Battlegrounds.Syria) > 0)
                    _images[3] = AddImage(568 + 1136 * 3, 320, "Battlegrounds/estonia_" + battlegroundStyle + "_1136x640.jpg", 0);
                else
                    _images[3] = AddImage(568 + 1136 * 3, 320, "Battlegrounds/estonia_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[3].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[3].Tag = (int)Battlegrounds.Estonia;

                if (Player.Instance.GetSavedCountries(Battlegrounds.Estonia) > 0)
                {
                    _images[4] = AddImage(568 + 1136 * 4, 320, "Battlegrounds/finland_" + battlegroundStyle + "_1136x640.jpg", 0);
                }
                else
                    _images[4] = AddImage(568 + 1136 * 4, 320, "Battlegrounds/finland_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[4].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[4].Tag = (int)Battlegrounds.Finland;





                _selectedBattleground = (int)Battlegrounds.Georgia;
            }
            else if (_selectedEnemy == (int)Enemies.Kim)
            {
                _images[0] = AddImage(568, 320, "Battlegrounds/south-korea_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[0].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[0].Tag = (int)Battlegrounds.SouthKorea;

                if (Player.Instance.GetSavedCountries(Battlegrounds.SouthKorea) > 0)
                    _images[1] = AddImage(568 + 1136, 320, "Battlegrounds/israel_" + battlegroundStyle + "_1136x640.jpg", 0);
                else
                    _images[1] = AddImage(568 + 1136, 320, "Battlegrounds/israel_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[1].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[1].Tag = (int)Battlegrounds.Israel;

                if (Player.Instance.GetSavedCountries(Battlegrounds.Israel) > 0)
                    _images[2] = AddImage(568 + 1136 * 2, 320, "Battlegrounds/japan_" + battlegroundStyle + "_1136x640.jpg", 0);
                else
                    _images[2] = AddImage(568 + 1136 * 2, 320, "Battlegrounds/japan_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[2].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[2].Tag = (int)Battlegrounds.Japan;

                if (Player.Instance.GetSavedCountries(Battlegrounds.Japan) > 0)
                    _images[3] = AddImage(568 + 1136 * 3, 320, "Battlegrounds/great-britain_" + battlegroundStyle + "_1136x640.jpg", 0);
                else
                    _images[3] = AddImage(568 + 1136 * 3, 320, "Battlegrounds/great-britain_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[3].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[3].Tag = (int)Battlegrounds.GreatBritain;

                if (Player.Instance.GetSavedCountries(Battlegrounds.GreatBritain) > 0)
                    _images[4] = AddImage(568 + 1136 * 4, 320, "Battlegrounds/usa_" + battlegroundStyle + "_1136x640.jpg", 0);
                else
                    _images[4] = AddImage(568 + 1136 * 4, 320, "Battlegrounds/usa_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[4].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[4].Tag = (int)Battlegrounds.UnitedStates;

                _selectedBattleground = (int)Battlegrounds.SouthKorea;
            }
            else if (_selectedEnemy == (int)Enemies.Aliens)
            {
                _images[0] = AddImage(568, 320, "Battlegrounds/Test-battleground-moon-" + battlegroundStyle + ".jpg", 0);
                _images[0].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[0].Tag = (int)Battlegrounds.Moon;

                _selectedBattleground = (int)Battlegrounds.Moon;
            }

            _centerImage = _images[0];


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


            _imgGameTip = AddImage(14, 8, "UI/Choose-the-battleground-gametip-notification-background-with-text.png", 600);
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
            Settings.Instance.GameTipBattlegroundPickerShow = _btnGameTipCheckMark.State != 1;

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


            if (_selectedEnemy == (int)Enemies.Hitler)
            {
                CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hitler countries Poland.wav");
            }
            else if (_selectedEnemy == (int)Enemies.Bush)
            {
                CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bush countries Vietman.wav");
            }
            else if (_selectedEnemy == (int)Enemies.Putin)
            {
                CCAudioEngine.SharedEngine.PlayEffect("Sounds/Putin countries Georgia.wav");

            }
            else if (_selectedEnemy == (int)Enemies.Kim)
            {
                CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim countries South Korea.wav");
            }
        }

        private void btnGameTipCheckMark_OnClick(object sender, EventArgs e)
        {
            _btnGameTipCheckMark.ChangeState();
            _btnGameTipCheckMark.SetStateImages();
        }

        private void BtnBack_OnClick(object sender, EventArgs e)
        {
            //------------- Prabhjot ---------------//
            if (_isShowGameTipViewLoaded)
            {
                GameEnvironment.PlaySoundEffect(SoundEffect.MenuTapCannotTap);
                return;
            }

            Shared.GameDelegate.ClearOnBackButtonEvent();

            _isHoldAnimations = true;

            UnscheduleAll();

            TransitionToLayer(new WeaponPickerLayer(_selectedEnemy, _selectedWeapon));
        }

        private void BtnForward_OnClick(object sender, EventArgs e)
        {
            //------------- Prabhjot ---------------//
            if (_isShowGameTipViewLoaded)
            {
                GameEnvironment.PlaySoundEffect(SoundEffect.MenuTapCannotTap);
                return;
            }

            if (_btnForward.Opacity > 0)
            {
                _isHoldAnimations = true;

                UnscheduleAll();

                TransitionToLayer(new GamePlayLayer((Enemies)_selectedEnemy, (Weapons)_selectedWeapon, (Battlegrounds)_selectedBattleground, false));
            }
        }

        private void OnTouchesBegan(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (_selectedEnemy == (int)Enemies.Aliens)
                return;
            if (touches.Count > 0 && _btnBack.BoundingBoxTransformedToWorld.ContainsPoint(touches[0].Location))
                return;
            if (touches.Count > 0 && _btnForward.BoundingBoxTransformedToWorld.ContainsPoint(touches[0].Location))
                return;
            if (_isHoldAnimations)
                return;

            UnscheduleAll();
            if (_fireworkFrame != 0)
            {
                RemoveChild(_firework);
                _fireworkFrame = 0;
            }

            CCAudioEngine.SharedEngine.StopAllEffects();
            _imgBattlegroundName.Opacity = 0;
            _imgBattlegroundLocked.Opacity = 0;
            _btnForward.Opacity = 0;

            _isSwiping = true;
        }

        private void OnTouchesMoved(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (_selectedEnemy == (int)Enemies.Aliens) return;

            if (_isHoldAnimations) return;

            if (_isSwiping)
            {
                var movementX = touches[0].Location.X - touches[0].PreviousLocation.X;
                _lastMovement = movementX;

                MoveImages(movementX);
            }
        }

        private void MoveImages(float movementX)
        {
            if (_selectedEnemy == (int)Enemies.Aliens) return;

            if (_images[0].PositionX + movementX > 568)
            {
                _lastMovement = 0;
                movementX = 568 - _images[0].PositionX;
            }
            else if (_images[_images.Length - 1].PositionX + movementX < 568)
            {
                _lastMovement = 0;
                movementX = 568 - _images[_images.Length - 1].PositionX;
            }

            foreach (var img in _images)
            {
                img.PositionX += movementX;

                if (_centerImage == null) _centerImage = img;
                else if (Math.Abs(568 - img.PositionX) < Math.Abs(568 - _centerImage.PositionX)) _centerImage = img;
            }

            if (_centerImage.Tag != _selectedBattleground)
            {
                GameEnvironment.PlaySoundEffect(SoundEffect.Swipe);

                _selectedBattleground = _centerImage.Tag;

                SetBattlegroundName();
            }
        }

        private void SetBattlegroundName()
        {
            _imgBattlegroundLocked.Visible = false;
            if (_selectedBattleground == (int)Battlegrounds.Poland)
            {
                ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-poland-text");
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hitler countries Poland.wav");
            }
            else if (_selectedBattleground == (int)Battlegrounds.Denmark)
            {
                ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-denmark-text");
                if (Player.Instance.GetSavedCountries(Battlegrounds.Poland) == 0) _imgBattlegroundLocked.Visible = true;
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hitler countries Denmark.wav");
            }
            else if (_selectedBattleground == (int)Battlegrounds.Norway)
            {
                ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-norway-text");
                if (Player.Instance.GetSavedCountries(Battlegrounds.Denmark) == 0) _imgBattlegroundLocked.Visible = true;
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hitler countries Noeway.wav");
            }
            else if (_selectedBattleground == (int)Battlegrounds.France)
            {
                ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-france-text");
                if (Player.Instance.GetSavedCountries(Battlegrounds.Norway) == 0) _imgBattlegroundLocked.Visible = true;
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hitler countries France.wav");
            }
            else if (_selectedBattleground == (int)Battlegrounds.England)
            {
                ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-england-text");
                if (Player.Instance.GetSavedCountries(Battlegrounds.France) == 0) _imgBattlegroundLocked.Visible = true;
                // TODO: fali wav
            }
            else if (_selectedBattleground == (int)Battlegrounds.Vietnam)
            {
                ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-vietnam-text");
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bush countries Vietman.wav");
            }
            else if (_selectedBattleground == (int)Battlegrounds.Iraq)
            {
                ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-iraq-text");
                if (Player.Instance.GetSavedCountries(Battlegrounds.Vietnam) == 0) _imgBattlegroundLocked.Visible = true;
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bush countries Irak.wav");
            }
            else if (_selectedBattleground == (int)Battlegrounds.Afghanistan)
            {
                ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-afghanistan-text");
                if (Player.Instance.GetSavedCountries(Battlegrounds.Iraq) == 0) _imgBattlegroundLocked.Visible = true;
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bush countries Afganistan.wav");
            }
            else if (_selectedBattleground == (int)Battlegrounds.Libya)
            {
                ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-libya-text");
                if (Player.Instance.GetSavedCountries(Battlegrounds.Afghanistan) == 0) _imgBattlegroundLocked.Visible = true;
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bush countries Libya.wav");
            }
            else if (_selectedBattleground == (int)Battlegrounds.Russia)
            {
                ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-russia-text");
                if (Player.Instance.GetSavedCountries(Battlegrounds.Libya) == 0) _imgBattlegroundLocked.Visible = true;
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bush countries Russian.wav");
            }
            else if (_selectedBattleground == (int)Battlegrounds.Georgia)
            {
                ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-georgia-text");
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Putin countries Georgia.wav");
            }
            else if (_selectedBattleground == (int)Battlegrounds.Ukraine)
            {
                ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-ukraine-text");
                if (Player.Instance.GetSavedCountries(Battlegrounds.Georgia) == 0) _imgBattlegroundLocked.Visible = true;
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Putin countries Ukraine.wav");
            }
            else if (_selectedBattleground == (int)Battlegrounds.Syria)
            {
                ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-syria-text");
                if (Player.Instance.GetSavedCountries(Battlegrounds.Ukraine) == 0) _imgBattlegroundLocked.Visible = true;
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Putin countries Syria.wav");
            }
            else if (_selectedBattleground == (int)Battlegrounds.Estonia)
            {
                ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-estonia-text");
                if (Player.Instance.GetSavedCountries(Battlegrounds.Syria) == 0) _imgBattlegroundLocked.Visible = true;
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Putin countries Estonia.wav");
            }
            else if (_selectedBattleground == (int)Battlegrounds.Finland)
            {
                ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-finland-text");
                if (Player.Instance.GetSavedCountries(Battlegrounds.Estonia) == 0) _imgBattlegroundLocked.Visible = true;
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Putin countries Finland.wav");
            }
            else if (_selectedBattleground == (int)Battlegrounds.SouthKorea)
            {
                ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-south-korea-text");
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim countries South Korea.wav");
            }
            else if (_selectedBattleground == (int)Battlegrounds.Israel)
            {
                ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-israel-text");
                if (Player.Instance.GetSavedCountries(Battlegrounds.SouthKorea) == 0) _imgBattlegroundLocked.Visible = true;
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim countries South Israel.wav");
            }
            else if (_selectedBattleground == (int)Battlegrounds.Japan)
            {
                ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-japan-text");
                if (Player.Instance.GetSavedCountries(Battlegrounds.Israel) == 0) _imgBattlegroundLocked.Visible = true;
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim countries Japan.wav");
            }
            else if (_selectedBattleground == (int)Battlegrounds.GreatBritain)
            {
                ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-great-britain-text");
                if (Player.Instance.GetSavedCountries(Battlegrounds.Japan) == 0) _imgBattlegroundLocked.Visible = true;
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim countries Great Britain.wav");
            }
            else if (_selectedBattleground == (int)Battlegrounds.UnitedStates)
            {
                ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-united-states-text");
                if (Player.Instance.GetSavedCountries(Battlegrounds.GreatBritain) == 0) _imgBattlegroundLocked.Visible = true;
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim countries United States.wav");
            }
        }

        private void UpdateFirework(float dt)
        {
            if (_fireworkFrame > 0 || _selectedBattleground == (int)Battlegrounds.Finland)
            {
                _fireworkFrame++;
            }
            else
            {
                return;
            }

            if (_fireworkFrame == 1)
            {
                CCAudioEngine.SharedEngine.PlayEffect("Sounds/Firework Sound Effect mono.wav");
                _firework = new CCSprite(_ssFirework[0].Frames.Find(item => item.TextureFilename == "Firework_animation_image_001.png"));
                _firework.AnchorPoint = new CCPoint(0.5f, 0.5f);
                _firework.Position = new CCPoint(_images[4].Position);
                _firework.ZOrder = 0;
                _firework.Scale = 4;
                _fireworkFrame = 1;
                AddChild(_firework);
            }
            else if (_fireworkFrame <= 84)
            {
                _firework.TextureRectInPixels = _ssFirework[0].Frames.Find(item => item.TextureFilename == "Firework_animation_image_" + _fireworkFrame.ToString().PadLeft(3, '0') + ".png").TextureRectInPixels;
                _firework.BlendFunc = GameEnvironment.BlendFuncDefault;
            }
            else if (_fireworkFrame == 85)
            {
                RemoveChild(_firework);
                _firework = new CCSprite(_ssFirework[1].Frames.Find(item => item.TextureFilename == "Firework_animation_image_085.png"));
                _firework.AnchorPoint = new CCPoint(0.5f, 0.5f);
                _firework.Position = new CCPoint(_images[4].Position);
                _firework.ZOrder = 0;
                _firework.Scale = 4;
                AddChild(_firework);

            }
            else if (_fireworkFrame <= 124)
            {
                _firework.TextureRectInPixels = _ssFirework[1].Frames.Find(item => item.TextureFilename == "Firework_animation_image_" + _fireworkFrame.ToString().PadLeft(3, '0') + ".png").TextureRectInPixels;
                _firework.BlendFunc = GameEnvironment.BlendFuncDefault;
            }
            if (_fireworkFrame >= 124)
            {
                RemoveChild(_firework);
                _fireworkFrame = 0;
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
                var movementX = _lastMovement * 0.9f;

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
            if (_centerImage != null && Math.Abs(_centerImage.PositionX - 568) > AppConstants.Tolerance)
            {
                var differenceX = 568 - _centerImage.PositionX;
                var snapMovement = differenceX / 5;

                if (Math.Abs(snapMovement) < 1f) snapMovement = Math.Sign(snapMovement) * 1f;

                totalMovementX += snapMovement;
            }

            if (_centerImage != null && Math.Abs(568 - _centerImage.PositionX) < 1) 
                totalMovementX = 568 - _centerImage.PositionX;

            if (Math.Abs(totalMovementX) < AppConstants.Tolerance)
            {
                Unschedule(SnapToCentre);

                _startedDisplayingName = false;
                Schedule(StartDisplayingName, 0.025f);
            }
            else
            {
                MoveImages(totalMovementX);
            }
        }

        private void StartDisplayingName(float dt)
        {
            if (!_startedDisplayingName)
            {
                _startedDisplayingName = true;
                _nameDisplayTimePassed = 0;
                _startedTalking = false;
            }

            _nameDisplayTimePassed += dt;

            var imgOpacity = Convert.ToInt32(_nameDisplayTimePassed * 255f);
            if (imgOpacity > 255) imgOpacity = 255;

            _imgBattlegroundName.Opacity = (byte)imgOpacity;
            _imgBattlegroundLocked.Opacity = (byte)imgOpacity;
            if (!_imgBattlegroundLocked.Visible) _btnForward.Opacity = (byte)imgOpacity;

            if (_startedTalking == false && imgOpacity > 100)
            {
                _startedTalking = true;

                /*if (Settings.Instance.VoiceoversEnabled)
                {
                    switch ((BATTLEGROUNDS)_selectedBattleground)
                    {
                        case BATTLEGROUNDS.AFGHANISTAN:
                            CCAudioEngine.SharedEngine.PlayEffect("Sounds/Afghanistan VO_mono.wav");
                            break;
                        case BATTLEGROUNDS.DENMARK:
                            CCAudioEngine.SharedEngine.PlayEffect("Sounds/Denmark VO_mono.wav");
                            break;
                        case BATTLEGROUNDS.ENGLAND:
                            CCAudioEngine.SharedEngine.PlayEffect("Sounds/England VO_mono.wav");
                            break;
                        case BATTLEGROUNDS.ESTONIA:
                            CCAudioEngine.SharedEngine.PlayEffect("Sounds/Estonia VO_mono.wav");
                            break;
                        case BATTLEGROUNDS.FINLAND:
                            CCAudioEngine.SharedEngine.PlayEffect("Sounds/Finland VO_mono.wav");
                            break;
                        case BATTLEGROUNDS.FRANCE:
                            CCAudioEngine.SharedEngine.PlayEffect("Sounds/France VO_mono.wav");
                            break;
                        case BATTLEGROUNDS.GEORGIA:
                            CCAudioEngine.SharedEngine.PlayEffect("Sounds/Georgia VO_mono.wav");
                            break;
                        case BATTLEGROUNDS.GREAT_BRITAIN:
                            CCAudioEngine.SharedEngine.PlayEffect("Sounds/Great Britain VO_mono.wav");
                            break;
                        case BATTLEGROUNDS.IRAQ:
                            CCAudioEngine.SharedEngine.PlayEffect("Sounds/Irak VO_mono.wav");
                            break;
                        case BATTLEGROUNDS.ISRAEL:
                            CCAudioEngine.SharedEngine.PlayEffect("Sounds/Israel VO_mono.wav");
                            break;
                        case BATTLEGROUNDS.JAPAN:
                            CCAudioEngine.SharedEngine.PlayEffect("Sounds/Japan VO_mono.wav");
                            break;
                        case BATTLEGROUNDS.LIBYA:
                            CCAudioEngine.SharedEngine.PlayEffect("Sounds/Libya VO_mono.wav");
                            break;
                        case BATTLEGROUNDS.NORWAY:
                            CCAudioEngine.SharedEngine.PlayEffect("Sounds/Norway VO_mono.wav");
                            break;
                        case BATTLEGROUNDS.POLAND:
                            CCAudioEngine.SharedEngine.PlayEffect("Sounds/Poland VO_mono.wav");
                            break;
                        case BATTLEGROUNDS.RUSSIA:
                            CCAudioEngine.SharedEngine.PlayEffect("Sounds/Russia VO_mono.wav");
                            break;
                        case BATTLEGROUNDS.SOUTH_KOREA:
                            CCAudioEngine.SharedEngine.PlayEffect("Sounds/South Korea VO_mono.wav");
                            break;
                        case BATTLEGROUNDS.SYRIA:
                            CCAudioEngine.SharedEngine.PlayEffect("Sounds/Syria VO_mono.wav");
                            break;
                        case BATTLEGROUNDS.UKRAINE:
                            CCAudioEngine.SharedEngine.PlayEffect("Sounds/Ukraine VO_mono.wav");
                            break;
                        case BATTLEGROUNDS.UNITED_STATES:
                            CCAudioEngine.SharedEngine.PlayEffect("Sounds/USA VO_mono.wav");
                            break;
                        case BATTLEGROUNDS.VIETNAM:
                            CCAudioEngine.SharedEngine.PlayEffect("Sounds/Vietnam VO_mono.wav");
                            break;
                    }
                }
                else
                {*/
                if (_selectedBattleground == (int)Battlegrounds.Poland)
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hitler countries Poland.wav");
                }
                else if (_selectedBattleground == (int)Battlegrounds.Denmark)
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hitler countries Denmark.wav");
                }
                else if (_selectedBattleground == (int)Battlegrounds.Norway)
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hitler countries Norway.wav");
                }
                else if (_selectedBattleground == (int)Battlegrounds.France)
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hitler countries France.wav");
                }
                else if (_selectedBattleground == (int)Battlegrounds.England)
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hitler countries England.wav");
                }
                else if (_selectedBattleground == (int)Battlegrounds.Vietnam)
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bush countries Vietman.wav");
                }
                else if (_selectedBattleground == (int)Battlegrounds.Iraq)
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bush countries Irak.wav");
                }
                else if (_selectedBattleground == (int)Battlegrounds.Afghanistan)
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bush countries Afganistan.wav");
                }
                else if (_selectedBattleground == (int)Battlegrounds.Libya)
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bush countries Libya.wav");
                }
                else if (_selectedBattleground == (int)Battlegrounds.Russia)
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bush countries Russian.wav");
                }
                else if (_selectedBattleground == (int)Battlegrounds.Georgia)
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Putin countries Georgia.wav");
                }
                else if (_selectedBattleground == (int)Battlegrounds.Ukraine)
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Putin countries Ukraine.wav");
                }
                else if (_selectedBattleground == (int)Battlegrounds.Syria)
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Putin countries Syria.wav");
                }
                else if (_selectedBattleground == (int)Battlegrounds.Estonia)
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Putin countries Estonia.wav");
                }
                else if (_selectedBattleground == (int)Battlegrounds.Finland)
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Putin countries Finland.wav");
                    if (Player.Instance.GetSavedCountries(Battlegrounds.Estonia) > 0)
                        Schedule(UpdateFirework, 0.03f);
                }
                else if (_selectedBattleground == (int)Battlegrounds.SouthKorea)
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim countries South Korea.wav");
                }
                else if (_selectedBattleground == (int)Battlegrounds.Israel)
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim countries Israel.wav");
                }
                else if (_selectedBattleground == (int)Battlegrounds.Japan)
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim countries Japan.wav");
                }
                else if (_selectedBattleground == (int)Battlegrounds.GreatBritain)
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim countries Great Britain.wav");
                }
                else if (_selectedBattleground == (int)Battlegrounds.UnitedStates)
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim countries United States.wav");
                }
                /* }*/
            }

            if (imgOpacity == 255) Unschedule(StartDisplayingName);
        }
    }
}


