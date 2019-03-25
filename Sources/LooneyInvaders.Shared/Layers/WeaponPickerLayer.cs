using System;
using System.Collections.Generic;
using CocosSharp;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;

namespace LooneyInvaders.Layers
{
    public class WeaponPickerLayer : CCLayerColorExt
    {
        readonly int _selectedEnemy;

        readonly CCSprite _imgWeaponDescription;
        CCSprite _imgWeaponStatsBoard;
        CCSprite _imgWeaponStatsText;
        readonly CCSprite _imgWeaponLocked;
        readonly CCSprite[] _imgWeaponStatsStars = new CCSprite[18];

        CCSprite _centerImage;
        readonly CCSprite[] _images = new CCSprite[3]; // Previous was CCSprite[6] ----- Prabhjot ------- 
        bool _isSwiping;
        readonly bool _isSwipingEnabled = true;
        int _selectedWeapon;
        float _lastMovement;
        int _bowingSpriteIndex;
        float _bowTimePassed;
        bool _startedBowing;
        bool _isHoldAnimations;
        readonly CCSprite _imgSpotlight;

        CCSpriteButton _btnBack;
        CCSpriteButton _btnForward;
        readonly CCSpriteButton _btnForwardNoPasaran;



        CCSprite _imgGameTip;
        CCSprite _imgGameTipArrow;
        CCSpriteButton _btnGameTipOk;
        CCSpriteTwoStateButton _btnGameTipCheckMark;
        CCSprite _imgGameTipCheckMarkLabel;
        readonly CCSpriteButton _btnWeaponUpgrade;
        readonly CCSpriteButton _btnTestProperties;
        readonly CCSpriteButton _btnWeaponBuy;

        readonly CCSprite _imgGameTipCredits;
        readonly CCSpriteButton _btnGetCredits;
        readonly CCSpriteButton _btnCancel;

        //----------- Prabhjot ----------//
        bool _isShowGameTipViewLoaded;

        public WeaponPickerLayer(int selectedEnemy, bool gameTipAvailable = true)
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            GameEnvironment.PreloadSoundEffect(SoundEffect.Swipe);

            //CCTexture2D.DefaultIsAntialiased = false;
            //CCLayer.DefaultCameraProjection = CCCameraProjection.Projection2D;

            _selectedEnemy = selectedEnemy;

            SetBackground("UI/Choose-your-curtain-background-with-spotlight.jpg");

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

            _imgGameTipCredits = AddImage(14, 8, "UI/Choose-your-weapon-not-enough-credits-to-unlocked-notification.png", 2000);
            _imgGameTipCredits.Visible = false;

            _btnGetCredits = AddButton(33, 30, "UI/get-more-firepower-notification-get-more-credits-button-untapped.png", "UI/get-more-firepower-notification-get-more-credits-button-tapped.png", 2100);
            _btnGetCredits.OnClick += _btnGetCredits_OnClick;
            _btnGetCredits.Visible = false;
            _btnGetCredits.Enabled = false;

            _btnCancel = AddButton(637, 30, "UI/get-more-firepower-notification-cancel-button-untapped.png", "UI/get-more-firepower-notification-cancel-button-tapped.png", 2100);
            _btnCancel.OnClick += BtnCancel_OnClick;
            _btnCancel.Visible = false;
            _btnCancel.Enabled = false;

            AddImage(236, 560, "UI/Choose-your-weapon-title-text.png", 500);
            AddImage(0, 0, "UI/Background-just-curtain-with-spotlight.png", 100);

            _imgSpotlight = AddImage(370, 0, "UI/Choose-your-enemy-spotlight-front.png", 400);
            _imgSpotlight.Opacity = 0;

            var touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesBegan = OnTouchesBegan;
            touchListener.OnTouchesEnded = OnTouchesEnded;
            touchListener.OnTouchesCancelled = OnTouchesCancelled;
            touchListener.OnTouchesMoved = OnTouchesMoved;

            if (_selectedEnemy != (int)Enemies.Aliens)
            {
                _images[0] = AddImage(-270, 260, "UI/compact-sprayer_bow_00.png", 0);
                _images[0].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[0].Scale = 0.6f;
                _images[0].Tag = (int)Weapons.Compact;

                _images[1] = AddImage(150, 260, "UI/black_bazooka_bow_00.png", 0);
                _images[1].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[1].Scale = 0.6f;
                _images[1].Tag = (int)Weapons.Bazooka;

                _images[2] = AddImage(570, 260, "UI/standard_gun_bow_00.png", 0);
                _images[2].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[2].Scale = 1.0f;
                _images[2].Tag = (int)Weapons.Standard;

                //----------------- Prabhjot -----------------//
                /*_images[3] = this.AddImage(990, 260, "UI/compact-sprayer_bow_00.png", 0);
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
                */
                _selectedWeapon = (int)Weapons.Standard;

                _imgWeaponDescription = AddImage(795, 15, "UI/Choose-your-weapon-standard-gun-text-board-all.png", 1000);
                _imgWeaponDescription.Opacity = 0;

            }
            else
            {
                _isSwipingEnabled = false;

                _images[2] = AddImage(570, 260, "UI/hybrid_defender_bow_00.png", 0);
                _images[2].AnchorPoint = new CCPoint(0.5f, 0.5f);
                _images[2].Scale = 1.0f;
                _images[2].Tag = (int)Weapons.Hybrid;

                _selectedWeapon = (int)Weapons.Hybrid;

                _imgWeaponDescription = AddImage(795, 15, "UI/Choose-your-weapon-hybrid-defender-text-board-plain-text.png", 1000);
                _imgWeaponDescription.Opacity = 0;

            }

            _imgWeaponLocked = AddImage(1136 / 2, 410, "UI/Choose-your-weapon-weapon-locked-text.png", 500);
            _imgWeaponLocked.AnchorPoint = new CCPoint(0.5f, 0f);
            _imgWeaponLocked.Opacity = 0;
            _imgWeaponLocked.Visible = false;

            SetWeaponStatsImages();
            SetWeaponStatsOpacity(0);

            _btnWeaponUpgrade = AddButton(2, 28, "UI/Choose-your-weapon-weapon-characters-board-get-more-firepower-button-untapped.png", "UI/Choose-your-weapon-weapon-characters-board-get-more-firepower-button-tapped.png", 1100);
            _btnWeaponUpgrade.Opacity = 0;
            _btnWeaponUpgrade.Enabled = false;
            _btnWeaponUpgrade.OnClick += _btnWeaponUpgrade_OnClick;

            _btnTestProperties = AddButton(2, 28, "UI/Choose-your-weapon-weapon-characters-board-test-properties-button-untapped.png", "UI/Choose-your-weapon-weapon-characters-board-test-properties-button-tapped.png", 1100);
            _btnTestProperties.Opacity = 0;
            _btnTestProperties.Enabled = false;
            _btnTestProperties.OnClick += _btnTestProperties_OnClick;

            _btnWeaponBuy = AddButton(2, 9, "UI/Choose-your-weapon-unlock-button-untapped.png", "UI/Choose-your-weapon-unlock-button-tapped.png", 1100);
            _btnWeaponBuy.Opacity = 0;
            _btnWeaponBuy.Enabled = false;
            _btnWeaponBuy.OnClick += _btnWeaponBuy_OnClick;
            _btnWeaponBuy.Visible = false;

            _centerImage = _images[2];

            AddEventListener(touchListener, this);
            AddEventListener(touchListener);


            SetWeaponStatsStars();

            _startedBowing = false;

            if (Settings.Instance.NotificationsEnabled && Settings.Instance.GameTipWeaponPickerShow && gameTipAvailable)
            {
                _isHoldAnimations = true;
                ShowGameTip();
            }
            else
            {
                _isHoldAnimations = false;
                ScheduleOnce(DelayedBow, 1.0f);
            }
        }

        private void _btnTestProperties_OnClick(object sender, EventArgs e)
        {
            _isHoldAnimations = true;
            CCAudioEngine.SharedEngine.StopAllEffects();
            UnscheduleAll();

            int caliberSize = Weapon.GetCaliberSize((Weapons)_selectedWeapon);
            int firespeed = Weapon.GetFirespeed((Weapons)_selectedWeapon);
            int magazineSize = Weapon.GetMagazineSize((Weapons)_selectedWeapon);
            int lives = Weapon.GetLives((Weapons)_selectedWeapon);

            TransitionToLayer(new GamePlayLayer(Enemies.Trump, (Weapons)_selectedWeapon, Battlegrounds.WhiteHouse, false, caliberSize, firespeed, magazineSize, lives, (Enemies)_selectedEnemy, LaunchMode.WeaponTest));
        }

        public WeaponPickerLayer(int selectedEnemy, int selectedWeapon) : this(selectedEnemy, false)
        {
            if (selectedWeapon == (int)Weapons.Bazooka)
            {
                MoveImages(420);
                _centerImage = _images[1];
            }
            else if (selectedWeapon == (int)Weapons.Compact)
            {
                MoveImages(840);
                _centerImage = _images[3];
            }

            _selectedWeapon = selectedWeapon;

            SetWeaponStatsStars();
            SetWeaponDescription();

            UnscheduleAll();
            SetWeaponStatsOpacity(255);

            if (IsWeaponAtMax(selectedWeapon))
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

        private bool IsWeaponAtMax(int selectedWeapon)
        {
            int caliberSize = Weapon.GetCaliberSize((Weapons)selectedWeapon);
            int firespeed = Weapon.GetFirespeed((Weapons)selectedWeapon);
            int magazineSize = Weapon.GetMagazineSize((Weapons)selectedWeapon);
            int lives = Weapon.GetLives((Weapons)selectedWeapon);

            int livesMaximum = 7;
            int caliberSizeMaximum = 10;
            int firespeedMaximum = 10;
            int magazineSizeMaximum = 10;

            if (selectedWeapon == (int)Weapons.Standard)
            {
                caliberSizeMaximum = 4;
                firespeedMaximum = 4;
                magazineSizeMaximum = 4;
            }
            else if (selectedWeapon == (int)Weapons.Compact)
            {
                caliberSizeMaximum = 4;
                firespeedMaximum = 6;
                magazineSizeMaximum = 5;
            }
            else if (selectedWeapon == (int)Weapons.Bazooka)
            {
                caliberSizeMaximum = 6;
                firespeedMaximum = 4;
                magazineSizeMaximum = 5;
            }
            else if (selectedWeapon == (int)Weapons.Hybrid)
            {
                caliberSizeMaximum = 6;
                firespeedMaximum = 6;
                magazineSizeMaximum = 6;
            }

            if (caliberSize == caliberSizeMaximum && firespeed == firespeedMaximum && magazineSize == magazineSizeMaximum && lives == livesMaximum) return true;

            return false;
        }

        private void SetWeaponStatsOpacity(byte opacity)
        {
            _imgWeaponStatsBoard.Opacity = opacity;
            _imgWeaponStatsText.Opacity = opacity;

            foreach (CCSprite s in _imgWeaponStatsStars) s.Opacity = opacity;
        }

        private void SetWeaponStatsImages()
        {
            _imgWeaponStatsBoard = AddImage(0, 15, "UI/Choose-your-weapon-weapon-characters-plain-board-background.png", 1000);
            _imgWeaponStatsText = AddImage(0, 15, "UI/Choose-your-weapon-weapon-characters-board-all-texts.png", 1005);

            _imgWeaponStatsStars[0] = AddImage(18, 330, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
            _imgWeaponStatsStars[1] = AddImage(59, 330, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
            _imgWeaponStatsStars[2] = AddImage(100, 330, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
            _imgWeaponStatsStars[3] = AddImage(141, 330, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
            _imgWeaponStatsStars[4] = AddImage(182, 330, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
            _imgWeaponStatsStars[5] = AddImage(223, 330, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);

            _imgWeaponStatsStars[6] = AddImage(18, 220, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
            _imgWeaponStatsStars[7] = AddImage(59, 220, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
            _imgWeaponStatsStars[8] = AddImage(100, 220, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
            _imgWeaponStatsStars[9] = AddImage(141, 220, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
            _imgWeaponStatsStars[10] = AddImage(182, 220, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
            _imgWeaponStatsStars[11] = AddImage(223, 220, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);

            _imgWeaponStatsStars[12] = AddImage(18, 110, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
            _imgWeaponStatsStars[13] = AddImage(59, 110, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
            _imgWeaponStatsStars[14] = AddImage(100, 110, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
            _imgWeaponStatsStars[15] = AddImage(141, 110, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
            _imgWeaponStatsStars[16] = AddImage(182, 110, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
            _imgWeaponStatsStars[17] = AddImage(223, 110, "UI/Choose-your-weapon-weapon-characters-board-star-filled.png", 1010);
        }

        private void SetWeaponStatsStars()
        {
            int caliberSize = Weapon.GetCaliberSize((Weapons)_selectedWeapon);
            int firespeed = Weapon.GetFirespeed((Weapons)_selectedWeapon);
            int magazineSize = Weapon.GetMagazineSize((Weapons)_selectedWeapon);

            if (_selectedWeapon == (int)Weapons.Standard)
            {
                _imgWeaponStatsStars[4].Visible = false; // calibre size 5
                _imgWeaponStatsStars[5].Visible = false; // calibre size 6
                _imgWeaponStatsStars[10].Visible = false; // firespeed 5
                _imgWeaponStatsStars[11].Visible = false; // firespeed 6
                _imgWeaponStatsStars[16].Visible = false; // magazine size 5
                _imgWeaponStatsStars[17].Visible = false; // magazine size 6                
            }
            else if (_selectedWeapon == (int)Weapons.Compact)
            {
                _imgWeaponStatsStars[4].Visible = false; // calibre size 5
                _imgWeaponStatsStars[5].Visible = false; // calibre size 6
                _imgWeaponStatsStars[10].Visible = true; // firespeed 5
                _imgWeaponStatsStars[11].Visible = true; // firespeed 6
                _imgWeaponStatsStars[16].Visible = true; // magazine size 5
                _imgWeaponStatsStars[17].Visible = false; // magazine size 6    
            }
            else if (_selectedWeapon == (int)Weapons.Bazooka)
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
                if (caliberSize > i) ChangeSpriteImage(_imgWeaponStatsStars[i], "UI/Choose-your-weapon-weapon-characters-board-star-filled.png");
                else ChangeSpriteImage(_imgWeaponStatsStars[i], "UI/Choose-your-weapon-weapon-characters-board-star-unfilled.png");

                if (firespeed > i) ChangeSpriteImage(_imgWeaponStatsStars[6 + i], "UI/Choose-your-weapon-weapon-characters-board-star-filled.png");
                else ChangeSpriteImage(_imgWeaponStatsStars[6 + i], "UI/Choose-your-weapon-weapon-characters-board-star-unfilled.png");

                if (magazineSize > i) ChangeSpriteImage(_imgWeaponStatsStars[12 + i], "UI/Choose-your-weapon-weapon-characters-board-star-filled.png");
                else ChangeSpriteImage(_imgWeaponStatsStars[12 + i], "UI/Choose-your-weapon-weapon-characters-board-star-unfilled.png");
            }
        }

        private void _btnWeaponUpgrade_OnClick(object sender, EventArgs e)
        {
            _isHoldAnimations = true;
            CCAudioEngine.SharedEngine.StopAllEffects();
            UnscheduleAll();

            TransitionToLayer(new WeaponUpgradeScreenLayer(_selectedEnemy, _selectedWeapon));
        }



        private void _btnWeaponBuy_OnClick(object sender, EventArgs e)
        {
            CCAudioEngine.SharedEngine.StopAllEffects();
            if (Player.Instance.Credits > 30000)
            {
                Player.Instance.AddWeapon((Weapons)_selectedWeapon);
                Player.Instance.Credits -= 30000;
                GameEnvironment.PlaySoundEffect(SoundEffect.MenuTapCreditPurchase);

                _btnWeaponBuy.Visible = false;
                _btnWeaponUpgrade.Visible = true;
                _imgWeaponLocked.Visible = false;
                _btnForward.Visible = true;
                _btnForwardNoPasaran.Visible = false;



            }
            else
            {
                GameEnvironment.PlaySoundEffect(SoundEffect.MenuTapCannotTap);
                _btnBack.Enabled = false;
                _btnForwardNoPasaran.Enabled = false;
                _btnWeaponBuy.Enabled = false;

                _imgGameTipCredits.Visible = true;
                _btnGetCredits.Visible = true;
                _btnCancel.Visible = true;
                _btnGetCredits.Enabled = true;
                _btnCancel.Enabled = true;
                GameEnvironment.PlaySoundEffect(SoundEffect.NotificationPopUp);

                _isHoldAnimations = true;
            }

        }

        private void _btnGetCredits_OnClick(object sender, EventArgs e)
        {
            _isHoldAnimations = true;
            CCAudioEngine.SharedEngine.StopAllEffects();
            UnscheduleAll();

            TransitionToLayer(new GetMoreCreditsScreenLayer(30000, _selectedEnemy, _selectedWeapon));
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

        private void ShowGameTip()
        {
            _isHoldAnimations = true;

            //------------- Prabhjot ---------------//

            //_btnBack.Enabled = false;
            //_btnForward.Enabled = false;

            _isShowGameTipViewLoaded = true;

            _btnBack = AddButton(2, 578, "UI/back-button-tapped.png", "UI/back-button-untapped.png", 500, ButtonType.Back);
            _btnForward = AddButton(930, 578, "UI/forward-button-tapped.png", "UI/forward-button-untapped.png", 500);

            _imgGameTip = AddImage(14, 8, "UI/Choose-your-weapon-notification-background-with-all-text.png", 1500);
            _imgGameTipArrow = AddImage(210, 155, "UI/game-tip-notification-arrow.png", 1510);

            _btnGameTipOk = AddButton(655, 35, "UI/OK-I-got-it-button-untapped.png", "UI/OK-I-got-it-button-tapped.png", 1510);
            _btnGameTipOk.OnClick += btnGameTipOK_OnClick;

            _btnGameTipCheckMark = AddTwoStateButton(45, 50, "UI/check-button-untapped.png", "UI/check-button-tapped.png", "UI/check-button-tapped.png", "UI/check-button-untapped.png", 1510);
            _btnGameTipCheckMark.OnClick += btnGameTipCheckMark_OnClick;
            _btnGameTipCheckMark.ButtonType = ButtonType.CheckMark;

            _imgGameTipCheckMarkLabel = AddImage(105, 60, "UI/do-not-show-text.png", 1510);
            GameEnvironment.PlaySoundEffect(SoundEffect.NotificationPopUp);

        }

        private void btnGameTipOK_OnClick(object sender, EventArgs e)
        {
            Settings.Instance.GameTipWeaponPickerShow = _btnGameTipCheckMark.State == 1 ? false : true;

            _imgGameTip.Visible = false;
            _imgGameTipArrow.Visible = false;
            _btnGameTipOk.Visible = false;
            _btnGameTipOk.Enabled = false;
            _btnGameTipCheckMark.Visible = false;
            _btnGameTipCheckMark.Enabled = false;
            _imgGameTipCheckMarkLabel.Visible = false;

            _btnBack.Enabled = true;
            _btnForward.Enabled = true;
            _isHoldAnimations = false;

            //------------- Prabhjot ---------------//
            _btnBack = AddButton(2, 578, "UI/back-button-untapped.png", "UI/back-button-tapped.png", 500, ButtonType.Back);
            _btnForward = AddButton(930, 578, "UI/forward-button-untapped.png", "UI/forward-button-tapped.png", 500);

            _isShowGameTipViewLoaded = false;

            ScheduleOnce(DelayedBow, 1f);

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
            CCAudioEngine.SharedEngine.StopAllEffects();
            _isHoldAnimations = true;

            UnscheduleAll();

            TransitionToLayer(new EnemyPickerLayer());
        }

        private void BtnForward_OnClick(object sender, EventArgs e)
        {
            //------------- Prabhjot ---------------//
            if (_isShowGameTipViewLoaded)
            {
                GameEnvironment.PlaySoundEffect(SoundEffect.MenuTapCannotTap);
                return;
            }

            if (_selectedWeapon == (int)Weapons.Hybrid)
            {
                UnscheduleAll();
                TransitionToLayer(new GamePlayLayer(Enemies.Aliens, (Weapons)_selectedWeapon, Battlegrounds.Moon, false));
                return;
            }

            _isHoldAnimations = true;

            UnscheduleAll();

            CCAudioEngine.SharedEngine.StopAllEffects();
            TransitionToLayer(new BattlegroundPickerLayer(_selectedEnemy, _selectedWeapon));
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


                UnscheduleAll();

                CCAudioEngine.SharedEngine.StopAllEffects();
                ResetCenterImage();

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

                MoveImages(movementX);
            }
        }

        private void MoveImages(float movementX)
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


                // circular motion
                //if (img.PositionX > 2250) img.PositionX = -270 + img.PositionX - 2250;
                //else if (img.PositionX < -270) img.PositionX = 2250 + img.PositionX + 270;

                if (_centerImage == null) _centerImage = img;
                else if (Math.Abs(570 - img.PositionX) < Math.Abs(570 - _centerImage.PositionX)) _centerImage = img;



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
                GameEnvironment.PlaySoundEffect(SoundEffect.Swipe);

                _selectedWeapon = _centerImage.Tag;

                SetWeaponDescription();

                SetWeaponStatsStars();
            }
        }

        private void SetWeaponDescription()
        {
            if (_centerImage.Tag == (int)Weapons.Standard)
            {
                ChangeSpriteImage(_imgWeaponDescription, "UI/Choose-your-weapon-standard-gun-text-board-all.png");
                _imgWeaponLocked.Visible = false;
            }
            else if (_centerImage.Tag == (int)Weapons.Compact)
            {
                ChangeSpriteImage(_imgWeaponDescription, "UI/Choose-your-weapon-compact-sprayer-text-board-all.png");
                _imgWeaponLocked.Visible = !Player.Instance.GetWeapon(Weapons.Compact);
            }
            else if (_centerImage.Tag == (int)Weapons.Bazooka)
            {
                ChangeSpriteImage(_imgWeaponDescription, "UI/Choose-your-weapon-black-bazooka-text-board-all.png");
                _imgWeaponLocked.Visible = !Player.Instance.GetWeapon(Weapons.Bazooka);
            }
            else if (_centerImage.Tag == (int)Weapons.Hybrid)
            {
                ChangeSpriteImage(_imgWeaponDescription, "UI/Choose-your-weapon-hybrid-defender-text-board-plain-text.png");
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

            if (_isSwiping) Schedule(SnapToCentre, 0.03f);

            _isSwiping = false;

        }

        void OnTouchesCancelled(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (_isHoldAnimations) return;

            _isSwiping = false;

            Schedule(SnapToCentre, 0.03f);
        }

        void SnapToCentre(float dt)
        {
            if (_isSwiping) return;

            float totalMovementX = 0;

            // inertial movement
            if (Math.Abs(_lastMovement) > AppConstants.TOLERANCE)
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
            if (_centerImage != null)
            {
                if (Math.Abs(_centerImage.PositionX - 570) > AppConstants.TOLERANCE)
                {
                    float differenceX = 570 - _centerImage.PositionX;
                    float snapMovement = differenceX / 5;

                    if (Math.Abs(snapMovement) < 0.5f) snapMovement = Math.Sign(snapMovement) * 0.5f;

                    totalMovementX += snapMovement;
                }

                if (Math.Abs(570 - _centerImage.PositionX) < 1)
                    totalMovementX = 570 - _centerImage.PositionX;
            }

            if (Math.Abs(totalMovementX) < AppConstants.TOLERANCE)
            {
                Unschedule(SnapToCentre);

                _startedBowing = false;
                Schedule(StartBowing, 0.025f);
            }
            else
            {
                MoveImages(totalMovementX);
            }
        }

        void DelayedBow(float dt)
        {
            Schedule(StartBowing, 0.025f);
        }

        void StartBowing(float dt)
        {
            Unschedule(StartBowing);
            if (Settings.Instance.VoiceoversEnabled)
            {
                if (_centerImage.Tag == (int)Weapons.Standard) { CCAudioEngine.SharedEngine.PlayEffect("Sounds/Standard Gun VO_mono.wav"); ScheduleOnce(StartStartBowing, 1.36f); }
                else if (_centerImage.Tag == (int)Weapons.Compact) { CCAudioEngine.SharedEngine.PlayEffect("Sounds/Compact Sprayer VO_mono.wav"); ScheduleOnce(StartStartBowing, 1.8f); }
                else if (_centerImage.Tag == (int)Weapons.Bazooka) { CCAudioEngine.SharedEngine.PlayEffect("Sounds/Black Bazooka VO_mono.wav"); ScheduleOnce(StartStartBowing, 1.5f); }
                else if (_centerImage.Tag == (int)Weapons.Hybrid) { CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hybrid Defender VO_mono.wav"); ScheduleOnce(StartStartBowing, 1.8f); }


                Schedule(StartFading, 0.025f);


            }
            else
            {
                Schedule(StartBowing2, 0.025f);
            }
        }

        void StartStartBowing(float dt)
        {
            Schedule(StartBowing2, 0.025f);
        }

        int _labelOpacity;

        void StartFading(float dt)
        {
            _labelOpacity += 10;
            if (_labelOpacity > 255) { _labelOpacity = 255; Unschedule(StartFading); }

            SetWeaponStatsOpacity((byte)_labelOpacity);
            _imgWeaponDescription.Opacity = (byte)_labelOpacity;
            _imgSpotlight.Opacity = (byte)_labelOpacity;

            if (IsWeaponAtMax(_centerImage.Tag))
            {
                _btnTestProperties.Visible = true;
                _btnTestProperties.Opacity = (byte)_labelOpacity;
            }
            else
            {
                _btnWeaponUpgrade.Opacity = (byte)_labelOpacity;
            }

            _btnWeaponBuy.Opacity = (byte)_labelOpacity;
            _imgWeaponLocked.Opacity = (byte)_labelOpacity;
        }

        void StartBowing2(float dt)
        {
            if (!_startedBowing)
            {
                CCAudioEngine.SharedEngine.StopAllEffects();

                if (_centerImage.Tag == (int)Weapons.Standard) CCAudioEngine.SharedEngine.PlayEffect("Sounds/Soldier Proper UK Service.wav");
                else if (_centerImage.Tag == (int)Weapons.Compact) CCAudioEngine.SharedEngine.PlayEffect("Sounds/Soldier Hardened Japan Service.wav");
                else if (_centerImage.Tag == (int)Weapons.Bazooka) CCAudioEngine.SharedEngine.PlayEffect("Sounds/Soldier Young Thug Service.wav");
                else if (_centerImage.Tag == (int)Weapons.Hybrid) CCAudioEngine.SharedEngine.PlayEffect("Sounds/hybrid_defender_service.wav");

                _startedBowing = true;
                _bowTimePassed = 0;
            }

            _bowTimePassed += dt;

            string imageNamePrefix = "";

            if (_centerImage.Tag == (int)Weapons.Standard) imageNamePrefix = "UI/standard_gun_bow_";
            else if (_centerImage.Tag == (int)Weapons.Compact) imageNamePrefix = "UI/compact-sprayer_bow_";
            else if (_centerImage.Tag == (int)Weapons.Bazooka) imageNamePrefix = "UI/black_bazooka_bow_";
            else if (_centerImage.Tag == (int)Weapons.Hybrid) imageNamePrefix = "UI/hybrid_defender_bow_";

            _bowingSpriteIndex = Convert.ToInt32(_bowTimePassed / 0.039f);

            int imgOpacity = Convert.ToInt32(_bowTimePassed * 255f) + _labelOpacity;
            if (imgOpacity > 255) imgOpacity = 255;

            SetWeaponStatsOpacity((byte)imgOpacity);
            _imgWeaponDescription.Opacity = (byte)imgOpacity;
            _imgSpotlight.Opacity = (byte)imgOpacity;

            if (IsWeaponAtMax(_centerImage.Tag))
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
                if (IsWeaponAtMax(_centerImage.Tag))
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
                if (IsWeaponAtMax(_centerImage.Tag))
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

                Unschedule(StartBowing);

                _centerImage.Scale = 1f;

                ChangeSpriteImage(_centerImage, imageName);
            }
            else
            {
                if (GameEnvironment.GetTotalRamSizeMb() > 500)
                {
                    //string imageName = imageNamePrefix + _bowingSpriteIndex.ToString("00") + ".png";

                    CCSpriteFrame frame = GameAnimation.Instance.GetWeaponBowFrame((Weapons)_centerImage.Tag, _bowingSpriteIndex);

                    _centerImage.Scale = 2f;

                    ChangeSpriteImage(_centerImage, frame);
                }
            }
        }

        private void ResetCenterImage()
        {
            _bowingSpriteIndex = 0;
            _imgWeaponDescription.Opacity = 0;
            SetWeaponStatsOpacity(0);
            _imgSpotlight.Opacity = 0;
            _btnWeaponUpgrade.Opacity = 0;
            _btnWeaponUpgrade.Enabled = false;
            _btnTestProperties.Opacity = 0;
            _btnTestProperties.Enabled = false;
            _btnWeaponBuy.Opacity = 0;
            _imgWeaponLocked.Opacity = 0;
            _btnWeaponBuy.Enabled = false;
            _labelOpacity = 0;

            if (_centerImage.Tag == (int)Weapons.Standard)
            {
                ChangeSpriteImage(_centerImage, "UI/standard_gun_bow_00.png");
                ChangeSpriteImage(_imgWeaponDescription, "UI/Choose-your-weapon-standard-gun-text-board-all.png");
            }
            else if (_centerImage.Tag == (int)Weapons.Compact)
            {
                ChangeSpriteImage(_centerImage, "UI/compact-sprayer_bow_00.png");
                ChangeSpriteImage(_imgWeaponDescription, "UI/Choose-your-weapon-compact-sprayer-text-board-all.png");
            }
            else if (_centerImage.Tag == (int)Weapons.Bazooka)
            {
                ChangeSpriteImage(_centerImage, "UI/black_bazooka_bow_00.png");
                ChangeSpriteImage(_imgWeaponDescription, "UI/Choose-your-weapon-black-bazooka-text-board-all.png");
            }
            else if (_centerImage.Tag == (int)Weapons.Hybrid)
            {
                ChangeSpriteImage(_centerImage, "UI/hybrid_defender_bow_00.png");
                ChangeSpriteImage(_imgWeaponDescription, "UI/Choose-your-weapon-hybrid-defender-text-board-plain-text.png");
            }

            _centerImage.Scale = 1;
        }
    }
}

