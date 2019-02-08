using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;

namespace LooneyInvaders.Layers
{
    public class WeaponPickerLayer : CCLayerColorExt
    {
        int _selectedEnemy;
                
        CCSprite _imgWeaponDescription;        
        CCSprite _imgWeaponStatsBoard;
        CCSprite _imgWeaponStatsText;
        CCSprite _imgWeaponLocked;
        CCSprite[] _imgWeaponStatsStars = new CCSprite[18];

        CCSprite _centerImage;
        CCSprite[] _images = new CCSprite[6];
        bool _isSwiping = false;
        bool _isSwipingEnabled = true;
        int _selectedWeapon;
        float _lastMovement;
        int _bowingSpriteIndex;
        float _bowTimePassed;
        bool _startedBowing = false;
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
        CCSpriteButton _btnWeaponUpgrade;
        CCSpriteButton _btnTestProperties;
        CCSpriteButton _btnWeaponBuy;

        CCSprite _imgGameTipCredits;
        CCSpriteButton _btnGetCredits;
        CCSpriteButton _btnCancel;

        //----------- Prabhjot ----------//
        bool _isShowGameTipViewLoaded = false;

        public WeaponPickerLayer(int selectedEnemy, bool gameTipAvailable = true)
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.SWIPE);

            //CCTexture2D.DefaultIsAntialiased = false;
            //CCLayer.DefaultCameraProjection = CCCameraProjection.Projection2D;

            this._selectedEnemy = selectedEnemy;

            this.SetBackground("UI/Choose-your-curtain-background-with-spotlight.jpg");

            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Soldier Proper UK Service.wav");
            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Soldier Hardened Japan Service.wav");
            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Soldier Young Thug Service.wav");
            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/hybrid_defender_service.wav");


            if (Settings.Instance.VoiceoversEnabled)
            {
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Standard Gun VO_mono.wav");
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Compact Sprayer VO_mono.wav");
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Black Bazooka VO_mono.wav");
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Hybrid Defender VO_mono.wav");
            }

            while (GameAnimation.Instance.PreloadNextSpriteSheetWeapons()) { }
            
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

            _imgGameTipCredits = this.AddImage(14, 8, "UI/Choose-your-weapon-not-enough-credits-to-unlocked-notification.png", 2000);
            _imgGameTipCredits.Visible = false;

            _btnGetCredits = this.AddButton(33, 30, "UI/get-more-firepower-notification-get-more-credits-button-untapped.png", "UI/get-more-firepower-notification-get-more-credits-button-tapped.png", 2100);
            _btnGetCredits.OnClick += _btnGetCredits_OnClick;
            _btnGetCredits.Visible = false;
            _btnGetCredits.Enabled = false;

            _btnCancel = this.AddButton(637, 30, "UI/get-more-firepower-notification-cancel-button-untapped.png", "UI/get-more-firepower-notification-cancel-button-tapped.png", 2100);
            _btnCancel.OnClick += BtnCancel_OnClick;
            _btnCancel.Visible = false;
            _btnCancel.Enabled = false;

            this.AddImage(236, 560, "UI/Choose-your-weapon-title-text.png", 500);
            this.AddImage(0, 0, "UI/Background-just-curtain-with-spotlight.png", 100);            

            _imgSpotlight = this.AddImage(370, 0, "UI/Choose-your-enemy-spotlight-front.png", 400);
            _imgSpotlight.Opacity = 0;

            var touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesBegan = OnTouchesBegan;
            touchListener.OnTouchesEnded = OnTouchesEnded;
            touchListener.OnTouchesCancelled = OnTouchesCancelled;
            touchListener.OnTouchesMoved = OnTouchesMoved;

            if (_selectedEnemy != (int)ENEMIES.ALIENS)
            {
                _images[0] = this.AddImage(-270, 260, "UI/compact-sprayer_bow_00.png", 0);
                _images[0].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[0].Scale = 0.6f;
                _images[0].Tag = (int)WEAPONS.COMPACT;

                _images[1] = this.AddImage(150, 260, "UI/black_bazooka_bow_00.png", 0);
                _images[1].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[1].Scale = 0.6f;
                _images[1].Tag = (int)WEAPONS.BAZOOKA;

                _images[2] = this.AddImage(570, 260, "UI/standard_gun_bow_00.png", 0);
                _images[2].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[2].Scale = 1.0f;
                _images[2].Tag = (int)WEAPONS.STANDARD;

                _images[3] = this.AddImage(990, 260, "UI/compact-sprayer_bow_00.png", 0);
                _images[3].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[3].Scale = 0.6f;
                _images[3].Tag = (int)WEAPONS.COMPACT;

                _images[4] = this.AddImage(1410, 260, "UI/black_bazooka_bow_00.png", 0);
                _images[4].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[4].Scale = 0.6f;
                _images[4].Tag = (int)WEAPONS.BAZOOKA;

                _images[5] = this.AddImage(1830, 260, "UI/standard_gun_bow_00.png", 0);
                _images[5].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[5].Scale = 0.6f;
                _images[5].Tag = (int)WEAPONS.STANDARD;

                _selectedWeapon = (int)WEAPONS.STANDARD;

                _imgWeaponDescription = this.AddImage(795, 15, "UI/Choose-your-weapon-standard-gun-text-board-all.png", 1000);
                _imgWeaponDescription.Opacity = 0;

            }
            else
            {
                _isSwipingEnabled = false;

                _images[2] = this.AddImage(570, 260, "UI/hybrid_defender_bow_00.png", 0);
                _images[2].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[2].Scale = 1.0f;
                _images[2].Tag = (int)WEAPONS.HYBRID;

                _selectedWeapon = (int)WEAPONS.HYBRID;

                _imgWeaponDescription = this.AddImage(795, 15, "UI/Choose-your-weapon-hybrid-defender-text-board-plain-text.png", 1000);
                _imgWeaponDescription.Opacity = 0;

            }
            
            _imgWeaponLocked = this.AddImage(1136 / 2, 410, "UI/Choose-your-weapon-weapon-locked-text.png", 500);
            _imgWeaponLocked.AnchorPoint = new CCPoint(0.5f, 0f);
            _imgWeaponLocked.Opacity = 0;
            _imgWeaponLocked.Visible = false;

            setWeaponStatsImages();            
            setWeaponStatsOpacity(0);            

            _btnWeaponUpgrade = this.AddButton(2, 28, "UI/Choose-your-weapon-weapon-characters-board-get-more-firepower-button-untapped.png", "UI/Choose-your-weapon-weapon-characters-board-get-more-firepower-button-tapped.png", 1100);
            _btnWeaponUpgrade.Opacity = 0;
            _btnWeaponUpgrade.Enabled = false;
            _btnWeaponUpgrade.OnClick += _btnWeaponUpgrade_OnClick;

            _btnTestProperties = this.AddButton(2, 28, "UI/Choose-your-weapon-weapon-characters-board-test-properties-button-untapped.png", "UI/Choose-your-weapon-weapon-characters-board-test-properties-button-tapped.png", 1100);
            _btnTestProperties.Opacity = 0;
            _btnTestProperties.Enabled = false;
            _btnTestProperties.OnClick += _btnTestProperties_OnClick; ;

            _btnWeaponBuy = this.AddButton(2, 9, "UI/Choose-your-weapon-unlock-button-untapped.png", "UI/Choose-your-weapon-unlock-button-tapped.png", 1100);
            _btnWeaponBuy.Opacity = 0;
            _btnWeaponBuy.Enabled = false;
            _btnWeaponBuy.OnClick += _btnWeaponBuy_OnClick;
            _btnWeaponBuy.Visible = false;

            _centerImage = _images[2];

            AddEventListener(touchListener, this);
            this.AddEventListener(touchListener);

            
            setWeaponStatsStars();

            _startedBowing = false;            

            if (Settings.Instance.NotificationsEnabled && Settings.Instance.GameTipWeaponPickerShow && gameTipAvailable)
            {
                _isHoldAnimations = true;
                showGameTip();
            }
            else
            {
                _isHoldAnimations = false;
                this.ScheduleOnce(delayedBow, 1.0f);
            }            
        }

        private void _btnTestProperties_OnClick(object sender, EventArgs e)
        {
            _isHoldAnimations = true;
            CCAudioEngine.SharedEngine.StopAllEffects();
            this.UnscheduleAll();

            int caliberSize = Weapon.GetCaliberSize((WEAPONS)_selectedWeapon);
            int firespeed = Weapon.GetFirespeed((WEAPONS)_selectedWeapon);
            int magazineSize = Weapon.GetMagazineSize((WEAPONS)_selectedWeapon);
            int lives = Weapon.GetLives((WEAPONS)_selectedWeapon);

            this.TransitionToLayer(new GamePlayLayer(ENEMIES.TRUMP, (WEAPONS)_selectedWeapon, BATTLEGROUNDS.WHITE_HOUSE, false, caliberSize, firespeed, magazineSize, lives, (ENEMIES)_selectedEnemy, LAUNCH_MODE.WEAPON_TEST));            
        }

        public WeaponPickerLayer(int selectedEnemy, int selectedWeapon) : this(selectedEnemy, false)
        {
            if (selectedWeapon == (int)WEAPONS.BAZOOKA)
            {
                this.moveImages(420);
                this._centerImage = _images[1];
            }
            else if (selectedWeapon == (int)WEAPONS.COMPACT)
            {
                this.moveImages(840);
                this._centerImage = _images[3];
            }

            this._selectedWeapon = selectedWeapon;

            setWeaponStatsStars();
            setWeaponDescription();

            this.UnscheduleAll();
            setWeaponStatsOpacity(255);

            if (isWeaponAtMax(selectedWeapon))
            {
                _btnTestProperties.Visible = true;
                _btnTestProperties.Opacity = 255;
                _btnTestProperties.Enabled = true;
            }
            else
            {
                _btnWeaponUpgrade.Opacity = 255;
                _btnWeaponUpgrade.Enabled = true;
            }

            _imgWeaponDescription.Opacity = 255;
            _btnWeaponBuy.Opacity = 255;
            _imgWeaponLocked.Opacity = 255;
            
            _btnWeaponBuy.Enabled = true;
        }

        private bool isWeaponAtMax(int selectedWeapon)
        {
            int caliberSize = Weapon.GetCaliberSize((WEAPONS)selectedWeapon);
            int firespeed = Weapon.GetFirespeed((WEAPONS)selectedWeapon);
            int magazineSize = Weapon.GetMagazineSize((WEAPONS)selectedWeapon);
            int lives = Weapon.GetLives((WEAPONS)selectedWeapon);

            int livesMaximum = 7;
            int caliberSizeMaximum = 10;
            int firespeedMaximum = 10;
            int magazineSizeMaximum = 10;

            if (selectedWeapon == (int)WEAPONS.STANDARD)
            {   
                caliberSizeMaximum = 4;
                firespeedMaximum = 4;
                magazineSizeMaximum = 4;
            }
            else if (selectedWeapon == (int)WEAPONS.COMPACT)
            {
                caliberSizeMaximum = 4;
                firespeedMaximum = 6;
                magazineSizeMaximum = 5;
            }
            else if (selectedWeapon == (int)WEAPONS.BAZOOKA)
            {
                caliberSizeMaximum = 6;
                firespeedMaximum = 4;
                magazineSizeMaximum = 5;
            }
            else if (selectedWeapon == (int)WEAPONS.HYBRID)
            {
                caliberSizeMaximum = 6;
                firespeedMaximum = 6;
                magazineSizeMaximum = 6;
            }

            if (caliberSize == caliberSizeMaximum && firespeed == firespeedMaximum && magazineSize == magazineSizeMaximum && lives == livesMaximum) return true;

            return false;
        }

        private void setWeaponStatsOpacity(byte opacity)
        {
            _imgWeaponStatsBoard.Opacity = opacity;
            _imgWeaponStatsText.Opacity = opacity;

            foreach (CCSprite s in _imgWeaponStatsStars) s.Opacity = opacity;
        }

        private void setWeaponStatsImages()
        {
            _imgWeaponStatsBoard = this.AddImage(0, 15, "UI/Choose-your-weapon-weapon-characters-plain-board-background.png", 1000);
            _imgWeaponStatsText = this.AddImage(0, 15, "UI/Choose-your-weapon-weapon-characters-board-all-texts.png", 1005);

            _imgWeaponStatsStars[0] = this.AddImage(18, 330, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
            _imgWeaponStatsStars[1] = this.AddImage(59, 330, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
            _imgWeaponStatsStars[2] = this.AddImage(100, 330, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
            _imgWeaponStatsStars[3] = this.AddImage(141, 330, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
            _imgWeaponStatsStars[4] = this.AddImage(182, 330, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
            _imgWeaponStatsStars[5] = this.AddImage(223, 330, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);

            _imgWeaponStatsStars[6] = this.AddImage(18, 220, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
            _imgWeaponStatsStars[7] = this.AddImage(59, 220, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
            _imgWeaponStatsStars[8] = this.AddImage(100, 220, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
            _imgWeaponStatsStars[9] = this.AddImage(141, 220, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
            _imgWeaponStatsStars[10] = this.AddImage(182, 220, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
            _imgWeaponStatsStars[11] = this.AddImage(223, 220, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);

            _imgWeaponStatsStars[12] = this.AddImage(18, 110, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
            _imgWeaponStatsStars[13] = this.AddImage(59, 110, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
            _imgWeaponStatsStars[14] = this.AddImage(100, 110, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
            _imgWeaponStatsStars[15] = this.AddImage(141, 110, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
            _imgWeaponStatsStars[16] = this.AddImage(182, 110, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
            _imgWeaponStatsStars[17] = this.AddImage(223, 110, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
        }

        private void setWeaponStatsStars()
        {
            int caliberSize = Weapon.GetCaliberSize((WEAPONS)this._selectedWeapon);
            int firespeed = Weapon.GetFirespeed((WEAPONS)this._selectedWeapon);
            int magazineSize = Weapon.GetMagazineSize((WEAPONS)this._selectedWeapon);

            if (this._selectedWeapon == (int)WEAPONS.STANDARD)
            {
                _imgWeaponStatsStars[4].Visible = false; // calibre size 5
                _imgWeaponStatsStars[5].Visible = false; // calibre size 6
                _imgWeaponStatsStars[10].Visible = false; // firespeed 5
                _imgWeaponStatsStars[11].Visible = false; // firespeed 6
                _imgWeaponStatsStars[16].Visible = false; // magazine size 5
                _imgWeaponStatsStars[17].Visible = false; // magazine size 6                
            }
            else if (this._selectedWeapon == (int)WEAPONS.COMPACT)
            {
                _imgWeaponStatsStars[4].Visible = false; // calibre size 5
                _imgWeaponStatsStars[5].Visible = false; // calibre size 6
                _imgWeaponStatsStars[10].Visible = true; // firespeed 5
                _imgWeaponStatsStars[11].Visible = true; // firespeed 6
                _imgWeaponStatsStars[16].Visible = true; // magazine size 5
                _imgWeaponStatsStars[17].Visible = false; // magazine size 6    
            }
            else if (this._selectedWeapon == (int)WEAPONS.BAZOOKA)
            {
                _imgWeaponStatsStars[4].Visible = true; // calibre size 5
                _imgWeaponStatsStars[5].Visible = true; // calibre size 6
                _imgWeaponStatsStars[10].Visible = false; // firespeed 5
                _imgWeaponStatsStars[11].Visible = false; // firespeed 6
                _imgWeaponStatsStars[16].Visible = true; // magazine size 5
                _imgWeaponStatsStars[17].Visible = false; // magazine size 6    
            }

            for (int i = 0; i < 6; i++)
            {
                if (caliberSize > i) this.ChangeSpriteImage(_imgWeaponStatsStars[i], "UI/Choose-your-weapon-weapon-characters-board-star-filled.png");
                else this.ChangeSpriteImage(_imgWeaponStatsStars[i], "UI/Choose-your-weapon-weapon-characters-board-star-unfilled.png");

                if (firespeed > i) this.ChangeSpriteImage(_imgWeaponStatsStars[6 + i], "UI/Choose-your-weapon-weapon-characters-board-star-filled.png");
                else this.ChangeSpriteImage(_imgWeaponStatsStars[6 + i], "UI/Choose-your-weapon-weapon-characters-board-star-unfilled.png");

                if (magazineSize > i) this.ChangeSpriteImage(_imgWeaponStatsStars[12 + i], "UI/Choose-your-weapon-weapon-characters-board-star-filled.png");
                else this.ChangeSpriteImage(_imgWeaponStatsStars[12 + i], "UI/Choose-your-weapon-weapon-characters-board-star-unfilled.png");
            }
        }

        private void _btnWeaponUpgrade_OnClick(object sender, EventArgs e)
        {
            _isHoldAnimations = true;
            CCAudioEngine.SharedEngine.StopAllEffects();
            this.UnscheduleAll();

            this.TransitionToLayer(new WeaponUpgradeScreenLayer(this._selectedEnemy, this._selectedWeapon));
        }



        private void _btnWeaponBuy_OnClick(object sender, EventArgs e)
        {
            CCAudioEngine.SharedEngine.StopAllEffects();
            if (Player.Instance.Credits > 30000)
            {
                Player.Instance.AddWeapon((WEAPONS)this._selectedWeapon);
                Player.Instance.Credits -= 30000;
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CREDITPURCHASE);

                _btnWeaponBuy.Visible = false;
                _btnWeaponUpgrade.Visible = true;
                _imgWeaponLocked.Visible = false;
                _btnForward.Visible = true;
                _btnForwardNoPasaran.Visible = false;



            }
            else
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
                _btnBack.Enabled = false;
                _btnForwardNoPasaran.Enabled = false;
                _btnWeaponBuy.Enabled = false;

                _imgGameTipCredits.Visible = true;
                _btnGetCredits.Visible = true;
                _btnCancel.Visible = true;
                _btnGetCredits.Enabled = true;
                _btnCancel.Enabled = true;
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.NOTIFICATION_POP_UP);

                _isHoldAnimations = true;
            }

        }

        private void _btnGetCredits_OnClick(object sender, EventArgs e)
        {
            _isHoldAnimations = true;
            CCAudioEngine.SharedEngine.StopAllEffects();
            this.UnscheduleAll();

            this.TransitionToLayer(new GetMoreCreditsScreenLayer(30000, _selectedEnemy, _selectedWeapon));
        }

        private void BtnCancel_OnClick(object sender, EventArgs e)
        {
            _btnBack.Enabled = true;
            _btnForwardNoPasaran.Enabled = true;
            _btnWeaponBuy.Enabled = true;

            _imgGameTipCredits.Visible = false;
            _btnGetCredits.Visible = false;
            _btnCancel.Visible = false;
            _btnGetCredits.Enabled = false;
            _btnCancel.Enabled = false;

            _isHoldAnimations = false;
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

            _imgGameTip = this.AddImage(14, 8, "UI/Choose-your-weapon-notification-background-with-all-text.png", 1500);
            _imgGameTipArrow = this.AddImage(210, 155, "UI/game-tip-notification-arrow.png", 1510);

            _btnGameTipOK = this.AddButton(655, 35, "UI/OK-I-got-it-button-untapped.png", "UI/OK-I-got-it-button-tapped.png", 1510);
            _btnGameTipOK.OnClick += btnGameTipOK_OnClick;

            _btnGameTipCheckMark = this.AddTwoStateButton(45, 50, "UI/check-button-untapped.png", "UI/check-button-tapped.png", "UI/check-button-tapped.png", "UI/check-button-untapped.png", 1510);
            _btnGameTipCheckMark.OnClick += btnGameTipCheckMark_OnClick;
            _btnGameTipCheckMark.ButtonType = BUTTON_TYPE.CheckMark;

            _imgGameTipCheckMarkLabel = this.AddImage(105, 60, "UI/do-not-show-text.png", 1510);
            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.NOTIFICATION_POP_UP);

        }

        private void btnGameTipOK_OnClick(object sender, EventArgs e)
        {
            Settings.Instance.GameTipWeaponPickerShow = _btnGameTipCheckMark.State == 1 ? false : true;

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

            //------------- Prabhjot ---------------//
            _btnBack = this.AddButton(2, 578, "UI/back-button-untapped.png", "UI/back-button-tapped.png", 500, BUTTON_TYPE.Back);
            _btnForward = this.AddButton(930, 578, "UI/forward-button-untapped.png", "UI/forward-button-tapped.png", 500);

            _isShowGameTipViewLoaded = false;

            this.ScheduleOnce(delayedBow, 1f);

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

            this.TransitionToLayer(new EnemyPickerLayer());
        }

        private void BtnForward_OnClick(object sender, EventArgs e)
        {
            //------------- Prabhjot ---------------//
            if (_isShowGameTipViewLoaded == true)
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
                return;
            }

            if (_selectedWeapon == (int)WEAPONS.HYBRID)
            {
                this.UnscheduleAll();
                this.TransitionToLayer(new GamePlayLayer(ENEMIES.ALIENS, (WEAPONS)this._selectedWeapon, BATTLEGROUNDS.MOON, false));
                return;
            }

            _isHoldAnimations = true;

            this.UnscheduleAll();

            CCAudioEngine.SharedEngine.StopAllEffects();
            this.TransitionToLayer(new BattlegroundPickerLayer(_selectedEnemy, _selectedWeapon));
        }

        void OnTouchesBegan(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (_isSwipingEnabled)
            {
                if (touches.Count > 0 && _btnWeaponUpgrade.BoundingBoxTransformedToWorld.ContainsPoint(touches[0].Location)) return;
                if (touches.Count > 0 && _btnTestProperties.BoundingBoxTransformedToWorld.ContainsPoint(touches[0].Location)) return;
                if (touches.Count > 0 && _btnBack.BoundingBoxTransformedToWorld.ContainsPoint(touches[0].Location)) return;
                if (touches.Count > 0 && _btnForward.BoundingBoxTransformedToWorld.ContainsPoint(touches[0].Location)) return;
                if (touches.Count > 0 && _btnForwardNoPasaran.BoundingBoxTransformedToWorld.ContainsPoint(touches[0].Location)) return;
                if (touches.Count > 0 && _btnWeaponBuy.BoundingBoxTransformedToWorld.ContainsPoint(touches[0].Location)) return;


                if (_isHoldAnimations) return;


                this.UnscheduleAll();

                CCAudioEngine.SharedEngine.StopAllEffects();
                resetCenterImage();

                _isSwiping = true;
            }
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
            foreach (CCSprite img in _images)
            {
                img.PositionX += movementX;

                if (img.PositionX <= 150 || img.PositionX >= 990)
                {
                    img.Scale = 0.6f;
                    //img.PositionY = 155;
                }
                else
                {
                    float distanceFromCentre = Math.Abs(570 - img.PositionX);
                    float distancePercentage = distanceFromCentre / 420.00f;
                    
                    img.Scale = 1.0f - (0.4f * distancePercentage);
                    //img.PositionY = 230 - (75 * distancePercentage);
                }

                if (img.PositionX > 2250) img.PositionX = -270 + img.PositionX - 2250;
                else if (img.PositionX < -270) img.PositionX = 2250 + img.PositionX + 270;

                if (_centerImage == null)
                {
                    _centerImage = img;
                }
                else if (Math.Abs(570 - img.PositionX) < Math.Abs(570 - _centerImage.PositionX))
                {
                    _centerImage = img;
                }
            }

            if (_centerImage.Tag != _selectedWeapon)
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.SWIPE);

                _selectedWeapon = _centerImage.Tag;

                setWeaponDescription();

                setWeaponStatsStars();
            }
        }

        private void setWeaponDescription()
        {
            if (_centerImage.Tag == (int)WEAPONS.STANDARD)
            {
                this.ChangeSpriteImage(_imgWeaponDescription, "UI/Choose-your-weapon-standard-gun-text-board-all.png");
                _imgWeaponLocked.Visible = false;
            }
            else if (_centerImage.Tag == (int)WEAPONS.COMPACT)
            {
                this.ChangeSpriteImage(_imgWeaponDescription, "UI/Choose-your-weapon-compact-sprayer-text-board-all.png");
                _imgWeaponLocked.Visible = !Player.Instance.GetWeapon(WEAPONS.COMPACT);
            }
            else if (_centerImage.Tag == (int)WEAPONS.BAZOOKA)
            {
                this.ChangeSpriteImage(_imgWeaponDescription, "UI/Choose-your-weapon-black-bazooka-text-board-all.png");
                _imgWeaponLocked.Visible = !Player.Instance.GetWeapon(WEAPONS.BAZOOKA);
            }
            else if (_centerImage.Tag == (int)WEAPONS.HYBRID)
            {
                this.ChangeSpriteImage(_imgWeaponDescription, "UI/Choose-your-weapon-hybrid-defender-text-board-plain-text.png");
                _imgWeaponLocked.Visible = false;
            }
            _btnWeaponUpgrade.Visible = !_imgWeaponLocked.Visible;
            _btnTestProperties.Visible = !_imgWeaponLocked.Visible;
            _btnWeaponBuy.Visible = _imgWeaponLocked.Visible;
            _btnForward.Visible = !_imgWeaponLocked.Visible;
            _btnForwardNoPasaran.Visible = _imgWeaponLocked.Visible;
        }

        void OnTouchesEnded(List<CCTouch> touches, CCEvent touchEvent)
        {


            if (_isHoldAnimations) return;

            if (_isSwiping) Schedule(snapToCentre, 0.03f);

            _isSwiping = false;

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

                _startedBowing = false;
                this.Schedule(startBowing, 0.025f);
            }
            else
            {
                moveImages(totalMovementX);
            }
        }

        void delayedBow(float dt)
        {
            this.Schedule(startBowing, 0.025f);
        }

        void startBowing(float dt)
        {
            this.Unschedule(startBowing);
            if (Settings.Instance.VoiceoversEnabled)
            {
                if (_centerImage.Tag == (int)WEAPONS.STANDARD) { CCAudioEngine.SharedEngine.PlayEffect("Sounds/Standard Gun VO_mono.wav"); this.ScheduleOnce(startStartBowing, 1.36f); }
                else if (_centerImage.Tag == (int)WEAPONS.COMPACT) { CCAudioEngine.SharedEngine.PlayEffect("Sounds/Compact Sprayer VO_mono.wav"); this.ScheduleOnce(startStartBowing, 1.8f); }
                else if (_centerImage.Tag == (int)WEAPONS.BAZOOKA) { CCAudioEngine.SharedEngine.PlayEffect("Sounds/Black Bazooka VO_mono.wav"); this.ScheduleOnce(startStartBowing, 1.5f); }
                else if (_centerImage.Tag == (int)WEAPONS.HYBRID) { CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hybrid Defender VO_mono.wav"); this.ScheduleOnce(startStartBowing, 1.8f); }


                this.Schedule(startFading, 0.025f);
               
               
            }
            else
            {
                this.Schedule(startBowing2, 0.025f);
            }
        }

        void startStartBowing(float dt)
        {
            this.Schedule(startBowing2, 0.025f);
        }

        int labelOpacity = 0;

        void startFading(float dt)
        {
            labelOpacity += 10;
            if (labelOpacity > 255) { labelOpacity = 255; this.Unschedule(startFading); }

            setWeaponStatsOpacity((byte)labelOpacity);
            _imgWeaponDescription.Opacity = (byte)labelOpacity;
            _imgSpotlight.Opacity = (byte)labelOpacity;

            if (isWeaponAtMax(_centerImage.Tag))
            {
                _btnTestProperties.Visible = true;
                _btnTestProperties.Opacity = (byte)labelOpacity;
            }
            else
            {
                _btnWeaponUpgrade.Opacity = (byte)labelOpacity;
            }

            _btnWeaponBuy.Opacity = (byte)labelOpacity;
            _imgWeaponLocked.Opacity = (byte)labelOpacity;
        }

        void startBowing2(float dt)
        {
            if (!_startedBowing)
            {
                CCAudioEngine.SharedEngine.StopAllEffects();

                if (_centerImage.Tag == (int)WEAPONS.STANDARD) CCAudioEngine.SharedEngine.PlayEffect("Sounds/Soldier Proper UK Service.wav");
                else if (_centerImage.Tag == (int)WEAPONS.COMPACT) CCAudioEngine.SharedEngine.PlayEffect("Sounds/Soldier Hardened Japan Service.wav");
                else if (_centerImage.Tag == (int)WEAPONS.BAZOOKA) CCAudioEngine.SharedEngine.PlayEffect("Sounds/Soldier Young Thug Service.wav");
                else if (_centerImage.Tag == (int)WEAPONS.HYBRID) CCAudioEngine.SharedEngine.PlayEffect("Sounds/hybrid_defender_service.wav");

                _startedBowing = true;
                _bowTimePassed = 0;
            }

            _bowTimePassed += dt;

            string imageNamePrefix = "";

            if (_centerImage.Tag == (int)WEAPONS.STANDARD) imageNamePrefix = "UI/standard_gun_bow_";
            else if (_centerImage.Tag == (int)WEAPONS.COMPACT) imageNamePrefix = "UI/compact-sprayer_bow_";
            else if (_centerImage.Tag == (int)WEAPONS.BAZOOKA) imageNamePrefix = "UI/black_bazooka_bow_";
            else if (_centerImage.Tag == (int)WEAPONS.HYBRID) imageNamePrefix = "UI/hybrid_defender_bow_";

            _bowingSpriteIndex = Convert.ToInt32(_bowTimePassed / 0.039f);

            int imgOpacity = Convert.ToInt32(_bowTimePassed * 255f) + labelOpacity;
            if (imgOpacity > 255) imgOpacity = 255;

            setWeaponStatsOpacity((byte)imgOpacity);
            _imgWeaponDescription.Opacity = (byte)imgOpacity;
            _imgSpotlight.Opacity = (byte)imgOpacity;

            if (isWeaponAtMax(_centerImage.Tag))
            {
                _btnTestProperties.Visible = true;
                _btnTestProperties.Opacity = (byte)imgOpacity;
            }
            else
            {
                _btnWeaponUpgrade.Opacity = (byte)imgOpacity;
            }            

            _btnWeaponBuy.Opacity = (byte)imgOpacity;
            _imgWeaponLocked.Opacity = (byte)imgOpacity;

            if (imgOpacity < 50)
            {
                if (isWeaponAtMax(_centerImage.Tag))
                {
                    _btnTestProperties.Enabled = false;
                    _btnWeaponBuy.Enabled = _btnTestProperties.Enabled;
                }
                else
                {
                    _btnWeaponUpgrade.Enabled = false;
                    _btnWeaponBuy.Enabled = _btnWeaponUpgrade.Enabled;
                }
            }
            else
            {
                if (isWeaponAtMax(_centerImage.Tag))
                {
                    _btnTestProperties.Enabled = true;
                    _btnWeaponBuy.Enabled = _btnTestProperties.Enabled;
                }
                else
                {
                    _btnWeaponUpgrade.Enabled = true;
                    _btnWeaponBuy.Enabled = _btnWeaponUpgrade.Enabled;
                }                
            }
            
            if (_bowingSpriteIndex == 0 || _bowingSpriteIndex > 63)
            {
                _bowingSpriteIndex = 0;
                string imageName = imageNamePrefix + _bowingSpriteIndex.ToString("00") + ".png";
                
                this.Unschedule(startBowing);

                _centerImage.Scale = 1f;

                this.ChangeSpriteImage(_centerImage, imageName);                
            }
            else
            {
                if (GameEnvironment.GetTotalRAMSizeMB() > 500)
                {
                    string imageName = imageNamePrefix + _bowingSpriteIndex.ToString("00") + ".png";

                    CCSpriteFrame frame = GameAnimation.Instance.GetWeaponBowFrame((WEAPONS)_centerImage.Tag, _bowingSpriteIndex);

                    _centerImage.Scale = 2f;

                    this.ChangeSpriteImage(_centerImage, frame);
                }
            }
        }

        private void resetCenterImage()
        {
            _bowingSpriteIndex = 0;
            _imgWeaponDescription.Opacity = 0;
            setWeaponStatsOpacity(0);
            _imgSpotlight.Opacity = 0;
            _btnWeaponUpgrade.Opacity = 0;
            _btnWeaponUpgrade.Enabled = false;
            _btnTestProperties.Opacity = 0;
            _btnTestProperties.Enabled = false;
            _btnWeaponBuy.Opacity = 0;
            _imgWeaponLocked.Opacity = 0;            
            _btnWeaponBuy.Enabled = false;
            labelOpacity = 0;

            if (_centerImage.Tag == (int)WEAPONS.STANDARD)
            {
                this.ChangeSpriteImage(_centerImage, "UI/standard_gun_bow_00.png");
                this.ChangeSpriteImage(_imgWeaponDescription, "UI/Choose-your-weapon-standard-gun-text-board-all.png");
            }
            else if (_centerImage.Tag == (int)WEAPONS.COMPACT)
            {
                this.ChangeSpriteImage(_centerImage, "UI/compact-sprayer_bow_00.png");
                this.ChangeSpriteImage(_imgWeaponDescription, "UI/Choose-your-weapon-compact-sprayer-text-board-all.png");
            }
            else if (_centerImage.Tag == (int)WEAPONS.BAZOOKA)
            {
                this.ChangeSpriteImage(_centerImage, "UI/black_bazooka_bow_00.png");
                this.ChangeSpriteImage(_imgWeaponDescription, "UI/Choose-your-weapon-black-bazooka-text-board-all.png");
            }
            else if (_centerImage.Tag == (int)WEAPONS.HYBRID)
            {
                this.ChangeSpriteImage(_centerImage, "UI/hybrid_defender_bow_00.png");
                this.ChangeSpriteImage(_imgWeaponDescription, "UI/Choose-your-weapon-hybrid-defender-text-board-plain-text.png");
            }

            _centerImage.Scale = 1;
        }
    }
}

