using System;
using CocosSharp;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;

namespace LooneyInvaders.Layers
{
    public class WeaponUpgradeScreenLayer : CCLayerColorExt
    {
        readonly int _selectedEnemy;
        readonly int _selectedWeapon;

        int _credits;

        int _caliberSizeMinimum;
        int _firespeedMinimum;
        int _magazineSizeMinimum;
        int _livesMinimum;

        readonly int _caliberSizeMaximum;
        readonly int _firespeedMaximum;
        readonly int _magazineSizeMaximum = 4;
        readonly int _livesMaximum;

        int _caliberSize;
        int _firespeed;
        int _magazineSize;
        int _lives;

        int _caliberSizePrice;
        int _firespeedPrice;
        int _magazineSizePrice;
        int _livesPrice;

        readonly CCSprite[] _imgCaliberSize = new CCSprite[6];
        readonly CCSprite[] _imgFirespeed = new CCSprite[6];
        readonly CCSprite[] _imgMagazineSize = new CCSprite[6];
        readonly CCSprite[] _imgLives = new CCSprite[7];

        CCSprite[] _lblPriceCaliberSize;
        CCSprite[] _lblPriceFirespeed;
        CCSprite[] _lblPriceMagazineSize;
        CCSprite[] _lblPriceLives;
        CCSprite[] _lblPriceTotal;
        CCSprite[] _lblCredits;

        readonly CCSprite _summationLine;
        readonly CCSprite _lblCreditsNeeded;
        readonly CCSprite _lblYourCredits;

        CCSpriteButton _btnBack;
        CCSpriteButton _btnForward;

        readonly CCSpriteButton _btnCalibreDecrease;
        readonly CCSpriteButton _btnCalibreIncrease;
        readonly CCSpriteButton _btnFirespeedIncrease;
        readonly CCSpriteButton _btnFirespeedDecrease;
        readonly CCSpriteButton _btnMagazineSizeDecrease;
        readonly CCSpriteButton _btnMagazineSizeIncrease;
        readonly CCSpriteButton _btnLivesDecrease;
        readonly CCSpriteButton _btnLivesIncrease;
        readonly CCSpriteButton _btnTestModification;
        readonly CCSpriteButton _btnBuy;
        readonly CCSpriteButton _btnGetMoreCredits;

        readonly CCSprite _imgGameTip;
        readonly CCSpriteButton _btnGetCredits;
        readonly CCSpriteButton _btnCancel;

        readonly CCSprite _imgGameTipNoBuy;
        readonly CCSpriteButton _btnNoBuyBack;
        readonly CCSpriteButton _btnNoBuyExit;

        readonly CCSprite _lblWeaponUpgraded;

        bool _isForwardTapped;
        //bool _isBackTapped;
        //bool _isPopupShiving;

        //----------- Prabhjot ----------//
        bool _isShowGameTipViewLoaded;

        public WeaponUpgradeScreenLayer(int selectedEnemy, int selectedWeapon, int caliberSizeSelected = -1, int fireSpeedSelected = -1, int magazineSizeSelected = -1, int livesSelected = -1)
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            _selectedEnemy = selectedEnemy;
            _selectedWeapon = selectedWeapon;

            _credits = Player.Instance.Credits;

            _caliberSizeMinimum = Weapon.GetCaliberSize((WEAPONS)selectedWeapon);
            _firespeedMinimum = Weapon.GetFirespeed((WEAPONS)selectedWeapon);
            _magazineSizeMinimum = 1;
            _livesMinimum = 1;
            _magazineSizeMinimum = Weapon.GetMagazineSize((WEAPONS)selectedWeapon);
            _livesMinimum = Weapon.GetLives((WEAPONS)selectedWeapon);

            _livesMaximum = 7;
            _firespeedMaximum = 5;
            _caliberSizeMaximum = 5;
            _magazineSize = 1;

            if (selectedWeapon == (int)WEAPONS.STANDARD)
            {
                SetBackground("UI/get-more-firepower-background-layer-with-standard-gun.jpg");
                _caliberSizeMaximum = 4;
                _firespeedMaximum = 4;
                _magazineSizeMaximum = 4;
            }
            else if (selectedWeapon == (int)WEAPONS.COMPACT)
            {
                SetBackground("UI/get-more-firepower-background-layer-with-compact-sprayer.jpg");
                _caliberSizeMaximum = 4;
                _firespeedMaximum = 6;
                _magazineSizeMaximum = 5;
            }
            else if (selectedWeapon == (int)WEAPONS.BAZOOKA)
            {
                SetBackground("UI/get-more-firepower-background-layer-with-black-bazooka.jpg");
                _caliberSizeMaximum = 6;
                _firespeedMaximum = 4;
                _magazineSizeMaximum = 5;
            }
            else if (selectedWeapon == (int)WEAPONS.HYBRID)
            {
                SetBackground("UI/get-more-firepower-background-layer-with-hybrid-defender.jpg");
                _caliberSizeMaximum = 6;
                _firespeedMaximum = 6;
                _magazineSizeMaximum = 6;
            }

            if (caliberSizeSelected == -1) _caliberSize = _caliberSizeMinimum;
            else _caliberSize = caliberSizeSelected;

            if (fireSpeedSelected == -1) _firespeed = _firespeedMinimum;
            else _firespeed = fireSpeedSelected;

            if (magazineSizeSelected == -1) _magazineSize = _magazineSizeMinimum;
            else _magazineSize = magazineSizeSelected;

            if (livesSelected == -1) _lives = _livesMinimum;
            else _lives = livesSelected;

            _caliberSizePrice = GetCaliberSizePrice();
            _firespeedPrice = GetFirespeedPrice();
            _magazineSizePrice = GetMagazineSizePrice();
            _livesPrice = GetLivesPrice();

            if (selectedWeapon == (int)WEAPONS.STANDARD) SetBackground("UI/get-more-firepower-background-layer-with-standard-gun.jpg");
            else if (selectedWeapon == (int)WEAPONS.COMPACT) SetBackground("UI/get-more-firepower-background-layer-with-compact-sprayer.jpg");
            else if (selectedWeapon == (int)WEAPONS.BAZOOKA) SetBackground("UI/get-more-firepower-background-layer-with-black-bazooka.jpg");
            else if (selectedWeapon == (int)WEAPONS.HYBRID) SetBackground("UI/get-more-firepower-background-layer-with-hybrid-defender.jpg");

            _btnBack = AddButton(2, 578, "UI/back-button-untapped.png", "UI/back-button-tapped.png", 100, BUTTON_TYPE.Back);
            _btnBack.OnClick += BtnBack_OnClick;
            _btnBack.ButtonType = BUTTON_TYPE.Back;
            Shared.GameDelegate.OnBackButton += BtnBack_OnClick;


            _btnForward = AddButton(930, 578, "UI/forward-button-untapped.png", "UI/forward-button-tapped.png", 100, BUTTON_TYPE.Forward);
            _btnForward.OnClick += BtnForward_OnClick;
            _btnForward.ButtonType = BUTTON_TYPE.Forward;

            AddImage(233, 566, "UI/get-more-firepower-upgrade-your-weapon-text.png");

            _btnCalibreDecrease = AddButton(30, 508, "UI/minus-button-untapped.png", "UI/minus-button-tapped.png");
            _btnCalibreDecrease.OnClick += BtnCalibreDecrease_OnClick;
            _btnCalibreDecrease.ButtonType = BUTTON_TYPE.Silent;

            _btnCalibreIncrease = AddButton(105, 505, "UI/plus-button-untapped.png", "UI/plus-button-tapped.png");
            _btnCalibreIncrease.OnClick += BtnCalibreIncrease_OnClick;
            _btnCalibreIncrease.ButtonType = BUTTON_TYPE.Silent;

            AddImage(169, 500, "UI/get-more-firepower-increase-caliber-size-text.png");

            if (_caliberSizeMaximum > 0) _imgCaliberSize[0] = AddImage(700, 517, "UI/get-more-firepower-star-active.png");
            if (_caliberSizeMaximum > 1) _imgCaliberSize[1] = AddImage(745, 517, "UI/get-more-firepower-star-active.png");
            if (_caliberSizeMaximum > 2) _imgCaliberSize[2] = AddImage(790, 517, "UI/get-more-firepower-star-active.png");
            if (_caliberSizeMaximum > 3) _imgCaliberSize[3] = AddImage(835, 517, "UI/get-more-firepower-star-active.png");
            if (_caliberSizeMaximum > 4) _imgCaliberSize[4] = AddImage(880, 517, "UI/get-more-firepower-star-active.png");
            if (_caliberSizeMaximum > 5) _imgCaliberSize[5] = AddImage(925, 517, "UI/get-more-firepower-star-active.png");

            _lblPriceCaliberSize = AddImageLabelRightAligned(1110, 500, "1000", 55);

            _btnFirespeedDecrease = AddButton(30, 445, "UI/minus-button-untapped.png", "UI/minus-button-tapped.png");
            _btnFirespeedDecrease.OnClick += BtnFirespeedDecrease_OnClick;
            _btnFirespeedDecrease.ButtonType = BUTTON_TYPE.Silent;

            _btnFirespeedIncrease = AddButton(105, 443, "UI/plus-button-untapped.png", "UI/plus-button-tapped.png");
            _btnFirespeedIncrease.OnClick += BtnFirespeedIncrease_OnClick;
            _btnFirespeedIncrease.ButtonType = BUTTON_TYPE.Silent;

            AddImage(163, 440, "UI/get-more-firepower-increase-firespeedr-text.png");

            if (_firespeedMaximum > 0) _imgFirespeed[0] = AddImage(700, 455, "UI/get-more-firepower-star-active.png");
            if (_firespeedMaximum > 1) _imgFirespeed[1] = AddImage(745, 455, "UI/get-more-firepower-star-active.png");
            if (_firespeedMaximum > 2) _imgFirespeed[2] = AddImage(790, 455, "UI/get-more-firepower-star-active.png");
            if (_firespeedMaximum > 3) _imgFirespeed[3] = AddImage(835, 455, "UI/get-more-firepower-star-active.png");
            if (_firespeedMaximum > 4) _imgFirespeed[4] = AddImage(880, 455, "UI/get-more-firepower-star-active.png");
            if (_firespeedMaximum > 5) _imgFirespeed[5] = AddImage(925, 455, "UI/get-more-firepower-star-active.png");

            _lblPriceFirespeed = AddImageLabelRightAligned(1110, 440, "1000", 55);

            _btnMagazineSizeDecrease = AddButton(30, 381, "UI/minus-button-untapped.png", "UI/minus-button-tapped.png");
            _btnMagazineSizeDecrease.OnClick += BtnMagazineSizeDecrease_OnClick;
            _btnMagazineSizeDecrease.ButtonType = BUTTON_TYPE.Silent;

            _btnMagazineSizeIncrease = AddButton(105, 378, "UI/plus-button-untapped.png", "UI/plus-button-tapped.png");
            _btnMagazineSizeIncrease.OnClick += BtnMagazineSizeIncrease_OnClick;
            _btnMagazineSizeIncrease.ButtonType = BUTTON_TYPE.Silent;

            AddImage(168, 373, "UI/get-more-firepower-increase-magazine-size-text.png");

            if (_magazineSizeMaximum > 0) _imgMagazineSize[0] = AddImage(700, 393, "UI/get-more-firepower-star-active.png");
            if (_magazineSizeMaximum > 1) _imgMagazineSize[1] = AddImage(745, 393, "UI/get-more-firepower-star-active.png");
            if (_magazineSizeMaximum > 2) _imgMagazineSize[2] = AddImage(790, 393, "UI/get-more-firepower-star-active.png");
            if (_magazineSizeMaximum > 3) _imgMagazineSize[3] = AddImage(835, 393, "UI/get-more-firepower-star-active.png");
            if (_magazineSizeMaximum > 4) _imgMagazineSize[4] = AddImage(880, 393, "UI/get-more-firepower-star-active.png");
            if (_magazineSizeMaximum > 5) _imgMagazineSize[5] = AddImage(925, 393, "UI/get-more-firepower-star-active.png");

            _lblPriceMagazineSize = AddImageLabelRightAligned(1110, 380, "1000", 55);

            _btnLivesDecrease = AddButton(30, 319, "UI/minus-button-untapped.png", "UI/minus-button-tapped.png");
            _btnLivesDecrease.OnClick += _btnLivesDecrease_OnClick;
            _btnLivesDecrease.ButtonType = BUTTON_TYPE.Silent;

            _btnLivesIncrease = AddButton(105, 317, "UI/plus-button-untapped.png", "UI/plus-button-tapped.png");
            _btnLivesIncrease.OnClick += _btnLivesIncrease_OnClick;
            _btnLivesIncrease.ButtonType = BUTTON_TYPE.Silent;

            AddImage(167, 313, "UI/get-more-firepower-get-more-lives-text.png");

            if (_livesMaximum > 0) _imgLives[0] = AddImage(655, 330, "UI/get-more-firepower-star-active.png");
            if (_livesMaximum > 1) _imgLives[1] = AddImage(700, 330, "UI/get-more-firepower-star-active.png");
            if (_livesMaximum > 2) _imgLives[2] = AddImage(745, 330, "UI/get-more-firepower-star-active.png");
            if (_livesMaximum > 3) _imgLives[3] = AddImage(790, 330, "UI/get-more-firepower-star-active.png");
            if (_livesMaximum > 4) _imgLives[4] = AddImage(835, 330, "UI/get-more-firepower-star-active.png");
            if (_livesMaximum > 5) _imgLives[5] = AddImage(880, 330, "UI/get-more-firepower-star-active.png");
            if (_livesMaximum > 6) _imgLives[6] = AddImage(925, 330, "UI/get-more-firepower-star-active.png");

            _lblPriceLives = AddImageLabelRightAligned(1130, 317, "25000", 55);

            _summationLine = AddImage(1020, 286, "UI/get-more-firepower-summation-line.png");

            _lblCreditsNeeded = AddImage(633, 241, "UI/get-more-firepower-credits-needed-text.png");
            _lblPriceTotal = AddImageLabelRightAligned(1080, 243, "3000", 55);

            _lblYourCredits = AddImage(640, 192, "UI/get-more-firepower-your-credits-text.png");
            _lblCredits = AddImageLabelRightAligned(1090, 192, "30000", 55);

            _btnTestModification = AddButton(2, 80, "UI/get-more-firepower-test-upgrade-button-untapped.png", "UI/get-more-firepower-test-upgrade-button-tapped.png");
            _btnTestModification.OnClick += _btnTestModification_OnClick;

            _btnBuy = AddButton(2, 10, "UI/get-more-firepower-implement-upgrade-button-untapped.png", "UI/get-more-firepower-implement-upgrade-button-tapped.png");
            _btnBuy.ButtonType = BUTTON_TYPE.Silent;
            _btnBuy.OnClick += BtnBuy_OnClick;

            _btnGetMoreCredits = AddButton(713, 10, "UI/get-more-firepower-get-more-credits-button-untapped.png", "UI/get-more-firepower-get-more-credits-button-tapped.png");
            _btnGetMoreCredits.OnClick += _btnGetCredits_OnClick;

            _lblWeaponUpgraded = AddImage(0, 170, "UI/get-more-firepower-weapon-upgraded!!-text.png");

            SetStatsImages();

            _imgGameTip = AddImage(14, 8, "UI/get-more-firepower-notification-background-with-all-text.png", 1000);
            _imgGameTip.Visible = false;

            _btnGetCredits = AddButton(33, 30, "UI/get-more-firepower-notification-get-more-credits-button-untapped.png", "UI/get-more-firepower-notification-get-more-credits-button-tapped.png", 1100);
            _btnGetCredits.OnClick += _btnGetCredits_OnClick;
            _btnGetCredits.Visible = false;
            _btnGetCredits.Enabled = false;

            _btnCancel = AddButton(637, 30, "UI/get-more-firepower-notification-cancel-button-untapped.png", "UI/get-more-firepower-notification-cancel-button-tapped.png", 1100);
            _btnCancel.OnClick += BtnCancel_OnClick;
            _btnCancel.Visible = false;
            _btnCancel.Enabled = false;




            _imgGameTipNoBuy = AddImage(14, 8, "UI/get-more-firepower-want-to-exit-notification-with-text.png", 1000);
            _imgGameTipNoBuy.Visible = false;

            _btnNoBuyBack = AddButton(33, 30, "UI/get-more-firepower-want-to-exit-notification-back-to-upgrading-button-untapped.png", "UI/get-more-firepower-want-to-exit-notification-back-to-upgrading-button-tapped.png", 1100);
            _btnNoBuyBack.OnClick += _btnNoBuyBack_OnClick;
            _btnNoBuyBack.Visible = false;
            _btnNoBuyBack.Enabled = false;

            _btnNoBuyExit = AddButton(590, 30, "UI/get-more-firepower-want-to-exit-notification-exit-without-upgrade-button-untapped.png", "UI/get-more-firepower-want-to-exit-notification-exit-without-upgrade-button-tapped.png", 1100);
            _btnNoBuyExit.OnClick += _btnNoBuyExit_OnClick;
            _btnNoBuyExit.Visible = false;
            _btnNoBuyExit.Enabled = false;

            GameEnvironment.PlayMusic(MUSIC.MAIN_MENU);
        }

        private void SetCreditsVisibility()
        {
            if (GetTotalPrice() == 0)
            {
                _lblYourCredits.Visible = false;
                _lblCreditsNeeded.Visible = false;
                _summationLine.Visible = false;

                foreach (CCSprite s in _lblCredits) s.Visible = false;
                foreach (CCSprite s in _lblPriceTotal) s.Visible = false;
                foreach (CCSprite s in _lblPriceCaliberSize) s.Visible = false;
                foreach (CCSprite s in _lblPriceFirespeed) s.Visible = false;
                foreach (CCSprite s in _lblPriceLives) s.Visible = false;
                foreach (CCSprite s in _lblPriceMagazineSize) s.Visible = false;
            }
            else
            {
                _lblYourCredits.Visible = true;
                _lblCreditsNeeded.Visible = true;
                _summationLine.Visible = true;

                foreach (CCSprite s in _lblCredits) s.Visible = true;
                foreach (CCSprite s in _lblPriceTotal) s.Visible = true;
                foreach (CCSprite s in _lblPriceCaliberSize) s.Visible = true;
                foreach (CCSprite s in _lblPriceFirespeed) s.Visible = true;
                foreach (CCSprite s in _lblPriceLives) s.Visible = true;
                foreach (CCSprite s in _lblPriceMagazineSize) s.Visible = true;
            }
        }

        private int GetLivesPrice()
        {
            int price = 0;
            for (int i = 2; i <= 7; i++) if (_livesMinimum < i && _lives >= i) price += 5000 + i * 5000;
            return price;
        }

        private int GetMagazineSizePrice()
        {
            int price = 0;
            for (int i = 2; i <= 6; i++) if (_magazineSizeMinimum < i && _magazineSize >= i) price += 5000 + i * 5000;
            return price;
        }

        private int GetFirespeedPrice()
        {
            int price = 0;
            for (int i = 2; i <= 6; i++) if (_firespeedMinimum < i && _firespeed >= i) price += 5000 + i * 5000;
            return price;
        }

        private int GetCaliberSizePrice()
        {
            int price = 0;
            for (int i = 2; i <= 6; i++) if (_caliberSizeMinimum < i && _caliberSize >= i) price += 5000 + i * 5000;
            return price;
        }

        private int GetTotalPrice()
        {
            return _caliberSizePrice + _firespeedPrice + _magazineSizePrice + _livesPrice;
        }

        private void _btnTestModification_OnClick(object sender, EventArgs e)
        {
            TransitionToLayer(new GamePlayLayer(ENEMIES.TRUMP, (WEAPONS)_selectedWeapon, BATTLEGROUNDS.WHITE_HOUSE, false, _caliberSize, _firespeed, _magazineSize, _lives, (ENEMIES)_selectedEnemy, LAUNCH_MODE.WEAPONS_UPGRADE_TEST));
        }

        private void _btnGetCredits_OnClick(object sender, EventArgs e)
        {
            int totalPrice = GetTotalPrice();

            TransitionToLayer(new GetMoreCreditsScreenLayer(totalPrice, _selectedEnemy, _selectedWeapon, _caliberSize, _firespeed, _magazineSize, _lives));
        }

        private void ShowGameTip()
        {
            //------------- Prabhjot ---------------//

            _btnBack = AddButton(2, 578, "UI/back-button-tapped.png", "UI/back-button-untapped.png", 500, BUTTON_TYPE.Back);
            _btnForward = AddButton(930, 578, "UI/forward-button-tapped.png", "UI/forward-button-untapped.png", 500);


            _btnCalibreDecrease.Enabled = false;
            _btnCalibreIncrease.Enabled = false;
            _btnFirespeedIncrease.Enabled = false;
            _btnFirespeedDecrease.Enabled = false;
            _btnMagazineSizeDecrease.Enabled = false;
            _btnMagazineSizeIncrease.Enabled = false;
            _btnLivesDecrease.Enabled = false;
            _btnLivesIncrease.Enabled = false;
            _btnTestModification.Enabled = false;
            _btnBuy.Enabled = false;
            _btnGetMoreCredits.Enabled = false;

            _imgGameTip.Visible = true;
            _btnGetCredits.Visible = true;
            _btnCancel.Visible = true;
            _btnGetCredits.Enabled = true;
            _btnCancel.Enabled = true;
            //_isPopupShiving = true;
            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.NOTIFICATION_POP_UP);
        }

        private void HideGameTip()
        {

            //------------- Prabhjot ---------------//

            _btnBack = AddButton(2, 578, "UI/back-button-untapped.png", "UI/back-button-tapped.png", 500, BUTTON_TYPE.Back);
            _btnForward = AddButton(930, 578, "UI/forward-button-untapped.png", "UI/forward-button-tapped.png", 500);


            _btnCalibreDecrease.Enabled = true;
            _btnCalibreIncrease.Enabled = true;
            _btnFirespeedIncrease.Enabled = true;
            _btnFirespeedDecrease.Enabled = true;
            _btnMagazineSizeDecrease.Enabled = true;
            _btnMagazineSizeIncrease.Enabled = true;
            _btnLivesDecrease.Enabled = true;
            _btnLivesIncrease.Enabled = true;
            _btnTestModification.Enabled = true;
            _btnBuy.Enabled = true;
            _btnGetMoreCredits.Enabled = true;

            _imgGameTip.Visible = false;
            _btnGetCredits.Visible = false;
            _btnCancel.Visible = false;
            _btnGetCredits.Enabled = false;
            _btnCancel.Enabled = false;
            //_isPopupShiving = false;
        }

        private void BtnCancel_OnClick(object sender, EventArgs e)
        {
            HideGameTip();
        }

        private void BtnBuy_OnClick(object sender, EventArgs e)
        {
            int totalPrice = GetTotalPrice();

            if (totalPrice > 0)
            {
                if (totalPrice <= _credits)
                {
                    _credits = _credits - totalPrice;
                    _caliberSizePrice = 0;
                    _firespeedPrice = 0;
                    _magazineSizePrice = 0;
                    _livesPrice = 0;

                    _caliberSizeMinimum = _caliberSize;
                    _firespeedMinimum = _firespeed;
                    _magazineSizeMinimum = _magazineSize;
                    _livesMinimum = _lives;

                    Weapon.SetCaliberSize((WEAPONS)_selectedWeapon, _caliberSize);
                    Weapon.SetFirespeed((WEAPONS)_selectedWeapon, _firespeed);
                    Weapon.SetMagazineSize((WEAPONS)_selectedWeapon, _magazineSize);
                    Weapon.SetLives((WEAPONS)_selectedWeapon, _lives);
                    Player.Instance.Credits -= totalPrice;



                    GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CREDITPURCHASE);
                    SetStatsImages();
                    _lblWeaponUpgraded.Visible = true;
                }
                else
                {
                    GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
                    ShowGameTip();
                }
            }
            else
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
                SetStatsImages();
            }
        }

        private void BtnMagazineSizeIncrease_OnClick(object sender, EventArgs e)
        {
            if (_magazineSize < _magazineSizeMaximum)
            {
                _magazineSize++;
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_PLUS);
            }
            else
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
            }
            _magazineSizePrice = GetMagazineSizePrice();
            SetStatsImages();
        }

        private void BtnMagazineSizeDecrease_OnClick(object sender, EventArgs e)
        {
            if (_magazineSize > _magazineSizeMinimum)
            {
                _magazineSize--;
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_MINUS);
            }
            else
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
            }
            _magazineSizePrice = GetMagazineSizePrice();
            SetStatsImages();
        }

        private void BtnFirespeedIncrease_OnClick(object sender, EventArgs e)
        {
            if (_firespeed < _firespeedMaximum)
            {
                _firespeed++;
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_PLUS);
            }
            else
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
            }
            _firespeedPrice = GetFirespeedPrice();
            SetStatsImages();
        }

        private void BtnFirespeedDecrease_OnClick(object sender, EventArgs e)
        {
            if (_firespeed > _firespeedMinimum)
            {
                _firespeed--;
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_MINUS);
            }
            else
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
            }
            _firespeedPrice = GetFirespeedPrice();
            SetStatsImages();
        }

        private void BtnCalibreIncrease_OnClick(object sender, EventArgs e)
        {
            if (_caliberSize < _caliberSizeMaximum)
            {
                _caliberSize++;
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_PLUS);
            }
            else
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
            }
            _caliberSizePrice = GetCaliberSizePrice();
            SetStatsImages();
        }

        private void BtnCalibreDecrease_OnClick(object sender, EventArgs e)
        {
            if (_caliberSize > _caliberSizeMinimum)
            {
                _caliberSize--;
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_MINUS);
            }
            else
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
            }
            _caliberSizePrice = GetCaliberSizePrice();
            SetStatsImages();
        }

        private void _btnLivesIncrease_OnClick(object sender, EventArgs e)
        {
            if (_lives < _livesMaximum)
            {
                _lives++;
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_PLUS);
            }
            else
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
            }
            _livesPrice = GetLivesPrice();
            SetStatsImages();
        }

        private void _btnLivesDecrease_OnClick(object sender, EventArgs e)
        {
            if (_lives > _livesMinimum)
            {
                _lives--;
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_MINUS);
            }
            else
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
            }
            _livesPrice = GetLivesPrice();
            SetStatsImages();
        }

        private void SetStatsImages()
        {
            _lblWeaponUpgraded.Visible = false;
            for (int i = 0; i < _caliberSizeMaximum; i++)
            {
                if (_caliberSize > i) ChangeSpriteImage(_imgCaliberSize[i], "UI/get-more-firepower-star-active.png");
                else ChangeSpriteImage(_imgCaliberSize[i], "UI/get-more-firepower-star-inactive.png");
            }

            for (int i = 0; i < _firespeedMaximum; i++)
            {
                if (_firespeed > i) ChangeSpriteImage(_imgFirespeed[i], "UI/get-more-firepower-star-active.png");
                else ChangeSpriteImage(_imgFirespeed[i], "UI/get-more-firepower-star-inactive.png");
            }

            for (int i = 0; i < _magazineSizeMaximum; i++)
            {
                if (_magazineSize > i) ChangeSpriteImage(_imgMagazineSize[i], "UI/get-more-firepower-star-active.png");
                else ChangeSpriteImage(_imgMagazineSize[i], "UI/get-more-firepower-star-inactive.png");
            }

            for (int i = 0; i < _livesMaximum; i++)
            {
                if (_lives > i) ChangeSpriteImage(_imgLives[i], "UI/get-more-firepower-star-active.png");
                else ChangeSpriteImage(_imgLives[i], "UI/get-more-firepower-star-inactive.png");
            }

            foreach (CCSprite s in _lblPriceCaliberSize) s.RemoveFromParent();
            foreach (CCSprite s in _lblPriceFirespeed) s.RemoveFromParent();
            foreach (CCSprite s in _lblPriceMagazineSize) s.RemoveFromParent();
            foreach (CCSprite s in _lblPriceLives) s.RemoveFromParent();
            foreach (CCSprite s in _lblPriceTotal) s.RemoveFromParent();
            foreach (CCSprite s in _lblCredits) s.RemoveFromParent();

            int totalPrice = GetTotalPrice();

            _lblPriceCaliberSize = AddImageLabelRightAligned(1130, 500, _caliberSizePrice.ToString(), 55);
            _lblPriceFirespeed = AddImageLabelRightAligned(1130, 440, _firespeedPrice.ToString(), 55);
            _lblPriceMagazineSize = AddImageLabelRightAligned(1130, 380, _magazineSizePrice.ToString(), 55);
            _lblPriceLives = AddImageLabelRightAligned(1130, 317, _livesPrice.ToString(), 55);
            _lblPriceTotal = AddImageLabelRightAligned(1130, 246, totalPrice.ToString(), 55);
            _lblCredits = AddImageLabelRightAligned(1130, 192, _credits.ToString(), 55);

            SetCreditsVisibility();
        }

        private void BtnBack_OnClick(object sender, EventArgs e)
        {
            //return;

            //------------- Prabhjot ---------------//
            if (_isShowGameTipViewLoaded)
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
                return;
            }

            //         if (_isPopupShiving)
            //{
            //	GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
            //             return;
            //}

            _isForwardTapped = false;
            //_isBackTapped = true;

            if (GetTotalPrice() == 0)
            {
                Shared.GameDelegate.ClearOnBackButtonEvent();

                TransitionToLayer(new WeaponPickerLayer(_selectedEnemy, _selectedWeapon));
            }
            else
            {
                ShowGameTipNoBuy();
            }
        }

        private void BtnForward_OnClick(object sender, EventArgs e)
        {

            //------------- Prabhjot ---------------//
            if (_isShowGameTipViewLoaded)
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
                return;
            }

            //if (_isPopupShiving)
            //{
            //    GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
            //    return;
            //}

            _isForwardTapped = true;
            //_isBackTapped = false;

            if (GetTotalPrice() == 0)
            {
                if (_selectedWeapon == (int)WEAPONS.HYBRID)
                {
                    UnscheduleAll();
                    TransitionToLayer(new GamePlayLayer(ENEMIES.ALIENS, (WEAPONS)_selectedWeapon, BATTLEGROUNDS.MOON, false));
                    return;
                }

                UnscheduleAll();

                TransitionToLayer(new BattlegroundPickerLayer(_selectedEnemy, _selectedWeapon));
            }
            else
            {
                ShowGameTipNoBuy();
            }
        }

        private void ShowGameTipNoBuy()
        {
            _btnCalibreDecrease.Enabled = false;
            _btnCalibreIncrease.Enabled = false;
            _btnFirespeedIncrease.Enabled = false;
            _btnFirespeedDecrease.Enabled = false;
            _btnMagazineSizeDecrease.Enabled = false;
            _btnMagazineSizeIncrease.Enabled = false;
            _btnLivesDecrease.Enabled = false;
            _btnLivesIncrease.Enabled = false;
            _btnTestModification.Enabled = false;
            _btnBuy.Enabled = false;
            _btnGetMoreCredits.Enabled = false;

            _imgGameTipNoBuy.Visible = true;
            _btnNoBuyBack.Visible = true;
            _btnNoBuyExit.Visible = true;
            _btnNoBuyBack.Enabled = true;
            _btnNoBuyExit.Enabled = true;
            //_isPopupShiving = true;
            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.NOTIFICATION_POP_UP);

            // ---------- Prabhjot ----------//

            _isShowGameTipViewLoaded = true;

            _btnBack = AddButton(2, 578, "UI/back-button-tapped.png", "UI/back-button-untapped.png", 100, BUTTON_TYPE.Back);
            _btnForward = AddButton(930, 578, "UI/forward-button-tapped.png", "UI/forward-button-untapped.png", 100, BUTTON_TYPE.Forward);

            _btnBack.Enabled = false;
            _btnForward.Enabled = false;

        }

        private void HideGameTipNoBuy()
        {

            //-------- Prabhjot ----------//

            _isShowGameTipViewLoaded = false;

            _btnBack = AddButton(2, 578, "UI/back-button-untapped.png", "UI/back-button-tapped.png", 100, BUTTON_TYPE.Back);
            _btnForward = AddButton(930, 578, "UI/forward-button-untapped.png", "UI/forward-button-tapped.png", 100, BUTTON_TYPE.Forward);

            _btnBack.Enabled = true;
            _btnForward.Enabled = true;


            _btnCalibreDecrease.Enabled = true;
            _btnCalibreIncrease.Enabled = true;
            _btnFirespeedIncrease.Enabled = true;
            _btnFirespeedDecrease.Enabled = true;
            _btnMagazineSizeDecrease.Enabled = true;
            _btnMagazineSizeIncrease.Enabled = true;
            _btnLivesDecrease.Enabled = true;
            _btnLivesIncrease.Enabled = true;
            _btnTestModification.Enabled = true;
            _btnBuy.Enabled = true;
            _btnGetMoreCredits.Enabled = true;

            _imgGameTipNoBuy.Visible = false;
            _btnNoBuyBack.Visible = false;
            _btnNoBuyExit.Visible = false;
            _btnNoBuyBack.Enabled = false;
            _btnNoBuyExit.Enabled = false;
            //_isPopupShiving = false;
        }

        private void _btnNoBuyExit_OnClick(object sender, EventArgs e)
        {
            if (_selectedWeapon == (int)WEAPONS.HYBRID)
            {
                UnscheduleAll();
                TransitionToLayer(new GamePlayLayer(ENEMIES.ALIENS, (WEAPONS)_selectedWeapon, BATTLEGROUNDS.MOON, false));
                return;
            }

            if (_isForwardTapped) TransitionToLayer(new BattlegroundPickerLayer(_selectedEnemy, _selectedWeapon));
            else TransitionToLayer(new WeaponPickerLayer(_selectedEnemy, _selectedWeapon));
        }

        private void _btnNoBuyBack_OnClick(object sender, EventArgs e)
        {
            HideGameTipNoBuy();
        }


    }
}