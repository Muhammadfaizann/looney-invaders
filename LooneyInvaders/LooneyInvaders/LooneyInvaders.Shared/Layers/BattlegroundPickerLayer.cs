using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;

namespace LooneyInvaders.Layers
{
    public class BattlegroundPickerLayer : CCLayerColorExt
    {
        CCSprite _centerImage;
        CCSprite[] _images = new CCSprite[5];
        CCSprite _imgBattlegroundLocked;
        CCSprite _imgBattlegroundName;
        
        CCSpriteButton _btnBack;
        CCSpriteButton _btnForward;

        CCSprite _imgGameTip;
        CCSprite _imgGameTipArrow;
        CCSpriteButton _btnGameTipOK;
        CCSpriteTwoStateButton _btnGameTipCheckMark;
        CCSprite _imgGameTipCheckMarkLabel;

        bool _isSwiping = false;
        int _selectedBattleground;
        float _lastMovement;
        bool _isHoldAnimations = false;        
        float _nameDisplayTimePassed;
        bool _startedDisplayingName = false;
        bool _startedTalking = false;

        int _selectedEnemy;
        int _selectedWeapon;

        CCSpriteSheet[] _ssFirework;
        int _fireworkFrame = 0;
        CCSprite _firework;

        public BattlegroundPickerLayer(int selectedEnemy, int selectedWeapon)
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.SWIPE);

            this._selectedEnemy = selectedEnemy;
            this._selectedWeapon = selectedWeapon;

           

            if (_selectedEnemy == (int)ENEMIES.HITLER)
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
            else if (_selectedEnemy == (int)ENEMIES.BUSH)
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
            else if (_selectedEnemy == (int)ENEMIES.PUTIN)
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
            else if (_selectedEnemy == (int)ENEMIES.KIM)
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

            _btnBack = this.AddButton(2, 578, "UI/back-button-untapped.png", "UI/back-button-tapped.png", 500, BUTTON_TYPE.Back);
            _btnBack.OnClick += BtnBack_OnClick;
            _btnBack.ButtonType = BUTTON_TYPE.Back;

            Shared.GameDelegate.OnBackButton += BtnBack_OnClick;

            _btnForward = this.AddButton(930, 578, "UI/forward-button-untapped.png", "UI/forward-button-tapped.png", 500);
            _btnForward.OnClick += BtnForward_OnClick;
            _btnForward.ButtonType = BUTTON_TYPE.Forward;

            this.AddImage(353, 507, "UI/Choose-the-battleground-title-text.png", 500);
            this.AddImage(442, 262, "UI/Choose-the-battleground-vs-text.png", 500);

            _imgBattlegroundName = this.AddImage(0, -5, "UI/Choose-the-battleground-in-georgia-text.png", 500);

            _imgBattlegroundLocked = this.AddImage(45, 138, "UI/Choose-the-battleground-battleground-locked-text.png", 600);
            _imgBattlegroundLocked.Visible = false;

            var touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesBegan = OnTouchesBegan;
            touchListener.OnTouchesEnded = OnTouchesEnded;
            touchListener.OnTouchesCancelled = OnTouchesCancelled;
            touchListener.OnTouchesMoved = OnTouchesMoved;

            fillBattlegrounds();
            setBattlegroundName();

            if (_selectedEnemy == (int)ENEMIES.HITLER) this.AddImage(85, 140, "UI/Choose-the-battleground-Adolf-Hitler.png", 0);
            else if (_selectedEnemy == (int)ENEMIES.BUSH) this.AddImage(85, 140, "UI/Choose-the-battleground_George_Bush.png", 0);
            else if (_selectedEnemy == (int)ENEMIES.PUTIN) this.AddImage(85, 140, "UI/Choose-the-battleground-Vladimir-Putin.png", 2);
            else if (_selectedEnemy == (int)ENEMIES.KIM) this.AddImage(85, 140, "UI/Choose-the-battleground-Kim_Jong-un.png", 0);
            else if (_selectedEnemy == (int)ENEMIES.ALIENS) this.AddImage(85, 140, "UI/Alien-C-5_00000.png", 0);

            if (_selectedWeapon == (int)WEAPONS.STANDARD) this.AddImage(700, 40, "UI/Choose-the-battleground-standard_gun.png", 2);
            else if (_selectedWeapon == (int)WEAPONS.COMPACT) this.AddImage(700, 40, "UI/Choose-the-battleground-compact_sprayer.png", 2);
            else if (_selectedWeapon == (int)WEAPONS.BAZOOKA) this.AddImage(700, 40, "UI/Choose-the-battleground-black_bazooka.png", 2);

            AddEventListener(touchListener, this);
            this.AddEventListener(touchListener);
            
            if (Settings.Instance.NotificationsEnabled && Settings.Instance.GameTipBattlegroundPickerShow)
            {
                _isHoldAnimations = true;
                showGameTip();
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
                    if (_selectedEnemy == (int)ENEMIES.HITLER)
                    {
                        CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hitler countries Poland.wav");
                    }
                    else if (_selectedEnemy == (int)ENEMIES.BUSH)
                    {
                        CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bush countries Vietman.wav");
                    }
                    else if (_selectedEnemy == (int)ENEMIES.PUTIN)
                    {
                        CCAudioEngine.SharedEngine.PlayEffect("Sounds/Putin countries Georgia.wav");

                    }
                    else if (_selectedEnemy == (int)ENEMIES.KIM)
                    {
                        CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim countries South Korea.wav");
                    }
                /*}*/
            }
        }
                
        // TODO: staviti da ide preko poziva GetBattlegroundImageName
        private void fillBattlegrounds()
        {
            string battlegroundStyle;
               
            if (Settings.Instance.BattlegroundStyle == BATTLEGROUND_STYLE.Cartonic) battlegroundStyle = "cartonic";
            else battlegroundStyle = "realistic";

            if (_selectedEnemy == (int)ENEMIES.HITLER)
            {
                _images[0] = this.AddImage(568, 320, "Battlegrounds/poland_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[0].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[0].Tag = (int)BATTLEGROUNDS.POLAND;

                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.POLAND) > 0)
                    _images[1] = this.AddImage(568 + 1136, 320, "Battlegrounds/denmark_" + battlegroundStyle + "_1136x640.jpg", 0);
                else
                    _images[1] = this.AddImage(568 + 1136, 320, "Battlegrounds/denmark_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[1].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[1].Tag = (int)BATTLEGROUNDS.DENMARK;

                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.DENMARK) > 0)
                    _images[2] = this.AddImage(568 + 1136 * 2, 320, "Battlegrounds/norway_" + battlegroundStyle + "_1136x640.jpg", 0);
                else
                    _images[2] = this.AddImage(568 + 1136 * 2, 320, "Battlegrounds/norway_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[2].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[2].Tag = (int)BATTLEGROUNDS.NORWAY;

                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.NORWAY) > 0)
                    _images[3] = this.AddImage(568 + 1136 * 3, 320, "Battlegrounds/france_" + battlegroundStyle + "_1136x640.jpg", 0);
                else
                    _images[3] = this.AddImage(568 + 1136 * 3, 320, "Battlegrounds/france_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[3].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[3].Tag = (int)BATTLEGROUNDS.FRANCE;

                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.FRANCE) > 0)
                    _images[4] = this.AddImage(568 + 1136 * 4, 320, "Battlegrounds/england_" + battlegroundStyle + "_1136x640.jpg", 0);
                else
                    _images[4] = this.AddImage(568 + 1136 * 4, 320, "Battlegrounds/england_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[4].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[4].Tag = (int)BATTLEGROUNDS.ENGLAND;

                _selectedBattleground = (int)BATTLEGROUNDS.POLAND;
            }
            else if (_selectedEnemy == (int)ENEMIES.BUSH)
            {
                _images[0] = this.AddImage(568, 320, "Battlegrounds/vietnam_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[0].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[0].Tag = (int)BATTLEGROUNDS.VIETNAM;

                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.VIETNAM) > 0)
                    _images[1] = this.AddImage(568 + 1136, 320, "Battlegrounds/iraq_" + battlegroundStyle + "_1136x640.jpg", 0);
                else
                    _images[1] = this.AddImage(568 + 1136, 320, "Battlegrounds/iraq_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[1].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[1].Tag = (int)BATTLEGROUNDS.IRAQ;

                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.IRAQ) > 0)
                    _images[2] = this.AddImage(568 + 1136 * 2, 320, "Battlegrounds/afganistan_" + battlegroundStyle + "_1136x640.jpg", 0);
                else
                    _images[2] = this.AddImage(568 + 1136 * 2, 320, "Battlegrounds/afganistan_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[2].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[2].Tag = (int)BATTLEGROUNDS.AFGHANISTAN;

                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.AFGHANISTAN) > 0)
                    _images[3] = this.AddImage(568 + 1136 * 3, 320, "Battlegrounds/libya_" + battlegroundStyle + "_1136x640.jpg", 0);
                else
                    _images[3] = this.AddImage(568 + 1136 * 3, 320, "Battlegrounds/libya_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[3].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[3].Tag = (int)BATTLEGROUNDS.LIBYA;

                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.LIBYA) > 0)
                    _images[4] = this.AddImage(568 + 1136 * 4, 320, "Battlegrounds/russia_" + battlegroundStyle + "_1136x640.jpg", 0);
                else
                    _images[4] = this.AddImage(568 + 1136 * 4, 320, "Battlegrounds/russia_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[4].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[4].Tag = (int)BATTLEGROUNDS.RUSSIA;

                _selectedBattleground = (int)BATTLEGROUNDS.VIETNAM;
            }
            else if (_selectedEnemy == (int)ENEMIES.PUTIN)
            {
                _images[0] = this.AddImage(568, 320, "Battlegrounds/georgia_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[0].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[0].Tag = (int)BATTLEGROUNDS.GEORGIA;

                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.GEORGIA) > 0)
                    _images[1] = this.AddImage(568 + 1136, 320, "Battlegrounds/ukraine_" + battlegroundStyle + "_1136x640.jpg", 0);
                else
                    _images[1] = this.AddImage(568 + 1136, 320, "Battlegrounds/ukraine_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[1].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[1].Tag = (int)BATTLEGROUNDS.UKRAINE;

                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.UKRAINE) > 0)
                    _images[2] = this.AddImage(568 + 1136 * 2, 320, "Battlegrounds/syria_" + battlegroundStyle + "_1136x640.jpg", 0);
                else
                    _images[2] = this.AddImage(568 + 1136 * 2, 320, "Battlegrounds/syria_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[2].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[2].Tag = (int)BATTLEGROUNDS.SYRIA;

                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.SYRIA) > 0)
                    _images[3] = this.AddImage(568 + 1136 * 3, 320, "Battlegrounds/estonia_" + battlegroundStyle + "_1136x640.jpg", 0);
                else
                    _images[3] = this.AddImage(568 + 1136 * 3, 320, "Battlegrounds/estonia_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[3].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[3].Tag = (int)BATTLEGROUNDS.ESTONIA;

                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.ESTONIA) > 0)
                {
                    _images[4] = this.AddImage(568 + 1136 * 4, 320, "Battlegrounds/finland_" + battlegroundStyle + "_1136x640.jpg", 0);
                }
                else
                    _images[4] = this.AddImage(568 + 1136 * 4, 320, "Battlegrounds/finland_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[4].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[4].Tag = (int)BATTLEGROUNDS.FINLAND;

               



                _selectedBattleground = (int)BATTLEGROUNDS.GEORGIA;
            }
            else if (_selectedEnemy == (int)ENEMIES.KIM)
            {
                _images[0] = this.AddImage(568, 320, "Battlegrounds/south-korea_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[0].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[0].Tag = (int)BATTLEGROUNDS.SOUTH_KOREA;

                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.SOUTH_KOREA) > 0)
                    _images[1] = this.AddImage(568 + 1136, 320, "Battlegrounds/israel_" + battlegroundStyle + "_1136x640.jpg", 0);
                else
                    _images[1] = this.AddImage(568 + 1136, 320, "Battlegrounds/israel_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[1].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[1].Tag = (int)BATTLEGROUNDS.ISRAEL;

                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.ISRAEL) > 0)
                    _images[2] = this.AddImage(568 + 1136 * 2, 320, "Battlegrounds/japan_" + battlegroundStyle + "_1136x640.jpg", 0);
                else
                    _images[2] = this.AddImage(568 + 1136 * 2, 320, "Battlegrounds/japan_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[2].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[2].Tag = (int)BATTLEGROUNDS.JAPAN;

                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.JAPAN) > 0)
                    _images[3] = this.AddImage(568 + 1136 * 3, 320, "Battlegrounds/great-britain_" + battlegroundStyle + "_1136x640.jpg", 0);
                else
                    _images[3] = this.AddImage(568 + 1136 * 3, 320, "Battlegrounds/great-britain_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[3].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[3].Tag = (int)BATTLEGROUNDS.GREAT_BRITAIN;

                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.GREAT_BRITAIN) > 0)
                    _images[4] = this.AddImage(568 + 1136 * 4, 320, "Battlegrounds/usa_" + battlegroundStyle + "_1136x640.jpg", 0);
                else
                    _images[4] = this.AddImage(568 + 1136 * 4, 320, "Battlegrounds/usa_" + battlegroundStyle + "_1136x640.jpg", 0);
                _images[4].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[4].Tag = (int)BATTLEGROUNDS.UNITED_STATES;

                _selectedBattleground = (int)BATTLEGROUNDS.SOUTH_KOREA;
            }
            else if (_selectedEnemy == (int)ENEMIES.ALIENS)
            {
                _images[0] = this.AddImage(568, 320, "Battlegrounds/Test-battleground-moon-" + battlegroundStyle + ".jpg", 0);
                _images[0].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[0].Tag = (int)BATTLEGROUNDS.MOON;                

                _selectedBattleground = (int)BATTLEGROUNDS.MOON;
            }

            _centerImage = _images[0];

           
        }

        private void showGameTip()
        {
            _isHoldAnimations = true;
            _btnBack.Enabled = false;
            _btnForward.Enabled = false;

            _imgGameTip = this.AddImage(14, 8, "UI/Choose-the-battleground-gametip-notification-background-with-text.png", 600);
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
            Settings.Instance.GameTipBattlegroundPickerShow = _btnGameTipCheckMark.State == 1 ? false : true;

            _imgGameTip.Visible = false;
            _imgGameTipArrow.Visible = false;
            _btnGameTipOK.Visible = false;
            _btnGameTipOK.Enabled = false;
            _btnGameTipCheckMark.Visible = false;
            _btnGameTipCheckMark.Enabled = false;
            _imgGameTipCheckMarkLabel.Visible = false;

            _btnBack.Enabled = true;
            _btnForward.Enabled = true;
            _isHoldAnimations = false;

            if (_selectedEnemy == (int)ENEMIES.HITLER)
            {
                CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hitler countries Poland.wav");
            }
            else if (_selectedEnemy == (int)ENEMIES.BUSH)
            {
                CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bush countries Vietman.wav");
            }
            else if (_selectedEnemy == (int)ENEMIES.PUTIN)
            {
                CCAudioEngine.SharedEngine.PlayEffect("Sounds/Putin countries Georgia.wav");

            }
            else if (_selectedEnemy == (int)ENEMIES.KIM)
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
            Shared.GameDelegate.ClearOnBackButtonEvent();

            _isHoldAnimations = true;
 
            this.UnscheduleAll();

            this.TransitionToLayer(new WeaponPickerLayer(this._selectedEnemy, this._selectedWeapon));
        }

        private void BtnForward_OnClick(object sender, EventArgs e)
        {
            if (_btnForward.Opacity > 0)
            {
                _isHoldAnimations = true;

                this.UnscheduleAll();

                this.TransitionToLayer(new GamePlayLayer((ENEMIES)this._selectedEnemy, (WEAPONS)this._selectedWeapon, (BATTLEGROUNDS)this._selectedBattleground, false));
            }
        }

        void OnTouchesBegan(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (_selectedEnemy == (int)ENEMIES.ALIENS) return;

            if (touches.Count > 0 && _btnBack.BoundingBoxTransformedToWorld.ContainsPoint(touches[0].Location)) return;
            if (touches.Count > 0 && _btnForward.BoundingBoxTransformedToWorld.ContainsPoint(touches[0].Location)) return;

            if (_isHoldAnimations) return;

            this.UnscheduleAll();
            if (_fireworkFrame != 0)
            {
                this.RemoveChild(_firework, true);
                _fireworkFrame = 0;
            }

            CCAudioEngine.SharedEngine.StopAllEffects();
            _imgBattlegroundName.Opacity = 0;
            _imgBattlegroundLocked.Opacity = 0;
            _btnForward.Opacity = 0;

            _isSwiping = true;
        }

        void OnTouchesMoved(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (_selectedEnemy == (int)ENEMIES.ALIENS) return;

            if (_isHoldAnimations) return;

            if (_isSwiping)
            {
                float movementX = (touches[0].Location.X - touches[0].PreviousLocation.X);
                _lastMovement = movementX;

                moveImages(movementX);
            }
        }

        private void moveImages(float movementX)
        {
            if (_selectedEnemy == (int)ENEMIES.ALIENS) return;

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

            foreach (CCSprite img in _images)
            {
                img.PositionX += movementX;

                if (_centerImage == null) _centerImage = img;
                else if (Math.Abs(568 - img.PositionX) < Math.Abs(568 - _centerImage.PositionX)) _centerImage = img;
            }
                        
            if (_centerImage.Tag != _selectedBattleground)
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.SWIPE);

                _selectedBattleground = _centerImage.Tag;

                setBattlegroundName();
            }
        }

        private void setBattlegroundName()
        {
            _imgBattlegroundLocked.Visible = false;
            if (_selectedBattleground == (int)BATTLEGROUNDS.POLAND)
            {
                this.ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-poland-text");
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hitler countries Poland.wav");
            }
            else if (_selectedBattleground == (int)BATTLEGROUNDS.DENMARK)
            {
                this.ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-denmark-text");
                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.POLAND) == 0) _imgBattlegroundLocked.Visible = true;
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hitler countries Denmark.wav");
            }
            else if (_selectedBattleground == (int)BATTLEGROUNDS.NORWAY)
            {
                this.ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-norway-text");
                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.DENMARK) == 0) _imgBattlegroundLocked.Visible = true;
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hitler countries Noeway.wav");
            }
            else if (_selectedBattleground == (int)BATTLEGROUNDS.FRANCE)
            {
                this.ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-france-text");
                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.NORWAY) == 0) _imgBattlegroundLocked.Visible = true;
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hitler countries France.wav");
            }
            else if (_selectedBattleground == (int)BATTLEGROUNDS.ENGLAND)
            {
                this.ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-england-text");
                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.FRANCE) == 0) _imgBattlegroundLocked.Visible = true;
                // TODO: fali wav
            }
            else if (_selectedBattleground == (int)BATTLEGROUNDS.VIETNAM)
            {
                this.ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-vietnam-text");
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bush countries Vietman.wav");
            }
            else if (_selectedBattleground == (int)BATTLEGROUNDS.IRAQ)
            {
                this.ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-iraq-text");
                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.VIETNAM) == 0) _imgBattlegroundLocked.Visible = true;
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bush countries Irak.wav");
            }
            else if (_selectedBattleground == (int)BATTLEGROUNDS.AFGHANISTAN)
            {
                this.ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-afghanistan-text");
                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.IRAQ) == 0) _imgBattlegroundLocked.Visible = true;
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bush countries Afganistan.wav");
            }
            else if (_selectedBattleground == (int)BATTLEGROUNDS.LIBYA)
            {
                this.ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-libya-text");
                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.AFGHANISTAN) == 0) _imgBattlegroundLocked.Visible = true;
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bush countries Libya.wav");
            }
            else if (_selectedBattleground == (int)BATTLEGROUNDS.RUSSIA)
            {
                this.ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-russia-text");
                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.LIBYA) == 0) _imgBattlegroundLocked.Visible = true;
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bush countries Russian.wav");
            }
            else if (_selectedBattleground == (int)BATTLEGROUNDS.GEORGIA)
            {
                this.ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-georgia-text");
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Putin countries Georgia.wav");
            }
            else if (_selectedBattleground == (int)BATTLEGROUNDS.UKRAINE)
            {
                this.ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-ukraine-text");
                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.GEORGIA) == 0) _imgBattlegroundLocked.Visible = true;
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Putin countries Ukraine.wav");
            }
            else if (_selectedBattleground == (int)BATTLEGROUNDS.SYRIA)
            {
                this.ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-syria-text");
                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.UKRAINE) == 0) _imgBattlegroundLocked.Visible = true;
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Putin countries Syria.wav");
            }
            else if (_selectedBattleground == (int)BATTLEGROUNDS.ESTONIA)
            {
                this.ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-estonia-text");
                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.SYRIA) == 0) _imgBattlegroundLocked.Visible = true;
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Putin countries Estonia.wav");
            }
            else if (_selectedBattleground == (int)BATTLEGROUNDS.FINLAND)
            {
                this.ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-finland-text");
                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.ESTONIA) == 0) _imgBattlegroundLocked.Visible = true;
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Putin countries Finland.wav");
            }
            else if (_selectedBattleground == (int)BATTLEGROUNDS.SOUTH_KOREA)
            {
                this.ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-south-korea-text");
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim countries South Korea.wav");
            }
            else if (_selectedBattleground == (int)BATTLEGROUNDS.ISRAEL)
            {
                this.ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-israel-text");
                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.SOUTH_KOREA) == 0) _imgBattlegroundLocked.Visible = true;
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim countries South Israel.wav");
            }
            else if (_selectedBattleground == (int)BATTLEGROUNDS.JAPAN)
            {
                this.ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-japan-text");
                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.ISRAEL) == 0) _imgBattlegroundLocked.Visible = true;
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim countries Japan.wav");
            }
            else if (_selectedBattleground == (int)BATTLEGROUNDS.GREAT_BRITAIN)
            {
                this.ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-great-britain-text");
                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.JAPAN) == 0) _imgBattlegroundLocked.Visible = true;
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim countries Great Britain.wav");
            }
            else if (_selectedBattleground == (int)BATTLEGROUNDS.UNITED_STATES)
            {
                this.ChangeSpriteImage(_imgBattlegroundName, "UI/Choose-the-battleground-in-united-states-text");
                if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.GREAT_BRITAIN) == 0) _imgBattlegroundLocked.Visible = true;
                //CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim countries United States.wav");
            }
        }

        void updateFirework(float dt)
        {
            if (_fireworkFrame > 0 || _selectedBattleground == (int)BATTLEGROUNDS.FINLAND)
            {
                _fireworkFrame++;
            }
            else
            {
                return;
            }

            if (_fireworkFrame == 1) {
                CCAudioEngine.SharedEngine.PlayEffect("Sounds/Firework Sound Effect mono.wav");
                _firework = new CCSprite(_ssFirework[0].Frames.Find(item => item.TextureFilename == "Firework_animation_image_001.png"));
                _firework.AnchorPoint = new CCPoint(0.5f, 0.5f);
                _firework.Position = new CCPoint(_images[4].Position);
                _firework.ZOrder = 0;
                _firework.Scale = 4;
                _fireworkFrame = 1;
                this.AddChild(_firework);
            }
            else if (_fireworkFrame <= 84)
            {
                _firework.TextureRectInPixels = _ssFirework[0].Frames.Find(item => item.TextureFilename == "Firework_animation_image_" + _fireworkFrame.ToString().PadLeft(3, '0') + ".png").TextureRectInPixels;
                _firework.BlendFunc = GameEnvironment.BlendFuncDefault;
            }
            else if(_fireworkFrame == 85)
            {
                this.RemoveChild(_firework, true);
                _firework = new CCSprite(_ssFirework[1].Frames.Find(item => item.TextureFilename == "Firework_animation_image_085.png"));
                _firework.AnchorPoint = new CCPoint(0.5f, 0.5f);
                _firework.Position = new CCPoint(_images[4].Position);
                _firework.ZOrder = 0;
                _firework.Scale = 4;
                this.AddChild(_firework);

            }
            else if(_fireworkFrame <= 124 )
            {
                _firework.TextureRectInPixels = _ssFirework[1].Frames.Find(item => item.TextureFilename == "Firework_animation_image_" + _fireworkFrame.ToString().PadLeft(3, '0') + ".png").TextureRectInPixels;
                _firework.BlendFunc = GameEnvironment.BlendFuncDefault;
            }
            if (_fireworkFrame>=124)
            {
                this.RemoveChild(_firework, true);
                _fireworkFrame = 0;
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
                float movementX = _lastMovement * 0.9f;

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
            if (_centerImage != null && _centerImage.PositionX != 568)
            {
                float differenceX = 568 - _centerImage.PositionX;
                float snapMovement = differenceX / 5;

                if (Math.Abs(snapMovement) < 1f) snapMovement = Math.Sign(snapMovement) * 1f;

                totalMovementX += snapMovement;                
            }

            if (Math.Abs(568 - _centerImage.PositionX) < 1) totalMovementX = 568 - _centerImage.PositionX;

            if (totalMovementX == 0)
            {
                this.Unschedule(snapToCentre);

                _startedDisplayingName = false;
                this.Schedule(startDisplayingName, 0.025f);
            }
            else
            {
                moveImages(totalMovementX);
            }
        }

        void startDisplayingName(float dt)
        {
            if (!_startedDisplayingName)
            {                
                _startedDisplayingName = true;
                _nameDisplayTimePassed = 0;
                _startedTalking = false;
            }

            _nameDisplayTimePassed += dt;

            int imgOpacity = Convert.ToInt32(_nameDisplayTimePassed * 255f);
            if (imgOpacity > 255) imgOpacity = 255;

            _imgBattlegroundName.Opacity = (byte)imgOpacity;
            _imgBattlegroundLocked.Opacity = (byte)imgOpacity;
            if(!_imgBattlegroundLocked.Visible) _btnForward.Opacity = (byte)imgOpacity;

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
                    if (_selectedBattleground == (int)BATTLEGROUNDS.POLAND)
                    {
                        CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hitler countries Poland.wav");
                    }
                    else if (_selectedBattleground == (int)BATTLEGROUNDS.DENMARK)
                    {
                        CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hitler countries Denmark.wav");
                    }
                    else if (_selectedBattleground == (int)BATTLEGROUNDS.NORWAY)
                    {
                        CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hitler countries Norway.wav");
                    }
                    else if (_selectedBattleground == (int)BATTLEGROUNDS.FRANCE)
                    {
                        CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hitler countries France.wav");
                    }
                    else if (_selectedBattleground == (int)BATTLEGROUNDS.ENGLAND)
                    {
                        CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hitler countries England.wav");
                    }
                    else if (_selectedBattleground == (int)BATTLEGROUNDS.VIETNAM)
                    {
                        CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bush countries Vietman.wav");
                    }
                    else if (_selectedBattleground == (int)BATTLEGROUNDS.IRAQ)
                    {
                        CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bush countries Irak.wav");
                    }
                    else if (_selectedBattleground == (int)BATTLEGROUNDS.AFGHANISTAN)
                    {
                        CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bush countries Afganistan.wav");
                    }
                    else if (_selectedBattleground == (int)BATTLEGROUNDS.LIBYA)
                    {
                        CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bush countries Libya.wav");
                    }
                    else if (_selectedBattleground == (int)BATTLEGROUNDS.RUSSIA)
                    {
                        CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bush countries Russian.wav");
                    }
                    else if (_selectedBattleground == (int)BATTLEGROUNDS.GEORGIA)
                    {
                        CCAudioEngine.SharedEngine.PlayEffect("Sounds/Putin countries Georgia.wav");
                    }
                    else if (_selectedBattleground == (int)BATTLEGROUNDS.UKRAINE)
                    {
                        CCAudioEngine.SharedEngine.PlayEffect("Sounds/Putin countries Ukraine.wav");
                    }
                    else if (_selectedBattleground == (int)BATTLEGROUNDS.SYRIA)
                    {
                        CCAudioEngine.SharedEngine.PlayEffect("Sounds/Putin countries Syria.wav");
                    }
                    else if (_selectedBattleground == (int)BATTLEGROUNDS.ESTONIA)
                    {
                        CCAudioEngine.SharedEngine.PlayEffect("Sounds/Putin countries Estonia.wav");
                    }
                    else if (_selectedBattleground == (int)BATTLEGROUNDS.FINLAND)
                    {
                        CCAudioEngine.SharedEngine.PlayEffect("Sounds/Putin countries Finland.wav");
                        if (Player.Instance.GetSavedCountries(BATTLEGROUNDS.ESTONIA) > 0)
                            Schedule(updateFirework, 0.03f);
                    }
                    else if (_selectedBattleground == (int)BATTLEGROUNDS.SOUTH_KOREA)
                    {
                        CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim countries South Korea.wav");
                    }
                    else if (_selectedBattleground == (int)BATTLEGROUNDS.ISRAEL)
                    {
                        CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim countries Israel.wav");
                    }
                    else if (_selectedBattleground == (int)BATTLEGROUNDS.JAPAN)
                    {
                        CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim countries Japan.wav");
                    }
                    else if (_selectedBattleground == (int)BATTLEGROUNDS.GREAT_BRITAIN)
                    {
                        CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim countries Great Britain.wav");
                    }
                    else if (_selectedBattleground == (int)BATTLEGROUNDS.UNITED_STATES)
                    {
                        CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim countries United States.wav");
                    }
               /* }*/
            }

            if (imgOpacity == 255) this.Unschedule(startDisplayingName);
        }        
    }
}


