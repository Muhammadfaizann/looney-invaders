using System;
using CocosSharp;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;

namespace LooneyInvaders.Layers
{
    public class GetMoreCreditsScreenLayer : CCLayerColorExt
    {
        private readonly int _selectedEnemy;
        private readonly int _selectedWeapon;
        private readonly int _caliberSizeSelected;
        private readonly int _firespeedSelected;
        private readonly int _magazineSizeSelected;
        private readonly int _livesSelected;
        private readonly int _imgPlayerCreditsXCoord;

        private CCSprite[] _imgPlayerCreditsLabel;
        private CCSpriteButton _btn2000;
        private CCSpriteButton _btn4000;
        private CCSpriteButton _btn100K;
        private CCSpriteButton _btn300K;
        private CCSpriteButton _btn1M;
        private readonly CCSprite _tenTimesText;

        private CCSprite _timeToNextAdsImg;
        private CCSprite _h1;
        private CCSprite _h2;
        private CCSprite _m1;
        private CCSprite _m2;
        private CCSprite _s1;
        private CCSprite _s2;
        private double _timeToNextAds;

        public GetMoreCreditsScreenLayer() : this(0, -1, -1, -1, -1, -1, -1)
        { }

        public GetMoreCreditsScreenLayer(int creditsRequired, int selectedEnemy, int selectedWeapon) : this(creditsRequired, selectedEnemy, selectedWeapon, -1, -1, -1, -1)
        { }

        public GetMoreCreditsScreenLayer(int creditsRequired, int selectedEnemy, int selectedWeapon, int caliberSizeSelected, int fireSpeedSelected, int magazineSizeSelected, int livesSelected)
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            //_creditsRequired = creditsRequired;
            _selectedEnemy = selectedEnemy;
            _selectedWeapon = selectedWeapon;
            _caliberSizeSelected = caliberSizeSelected;
            _firespeedSelected = fireSpeedSelected;
            _magazineSizeSelected = magazineSizeSelected;
            _livesSelected = livesSelected;

            SetBackground("UI/background.png");

            var btnBack = AddButton(2, 578, "UI/back-button-untapped.png", "UI/back-button-tapped.png", 100, ButtonType.Back);
            btnBack.OnClick += BtnBack_OnClick;
            Shared.GameDelegate.OnBackButton += BtnBack_OnClick;

            AddImage(307, 560, "UI/Get-more-credits-title-text.png");

            _btn1M = AddButton(0, 475, "UI/Get-more-credits-get-1000000-credits-button-untapped.png", "UI/Get-more-credits-get-1000000-credits-button-tapped.png");
            _btn1M.OnClick += Btn1m_OnClick;
            _btn1M.ButtonType = ButtonType.CreditPurchase;

            AddImage(517, 470, "UI/Get-more-credits-get-7_99-USD.png");

            _btn300K = AddButton(0, 381, "UI/Get-more-credits-get-300000-credits-button-untapped.png", "UI/Get-more-credits-get-300000-credits-button-tapped.png");
            _btn300K.OnClick += Btn300k_OnClick;
            _btn300K.ButtonType = ButtonType.CreditPurchase;

            AddImage(517, 379, "UI/Get-more-credits-get-4_99-USD.png");

            _btn100K = AddButton(0, 290, "UI/Get-more-credits-get-100000-credits-button-untapped.png", "UI/Get-more-credits-get-100000-credits-button-tapped.png");
            _btn100K.OnClick += Btn100k_OnClick;
            _btn100K.ButtonType = ButtonType.CreditPurchase;

            AddImage(517, 291, "UI/Get-more-credits-get-1_99-USD.png");

            _btn4000 = AddButton(0, 199, "UI/Get-more-credits-get-4000-credits-button-untapped.png", "UI/Get-more-credits-get-4000-credits-button-tapped.png");


            _btn4000.OnClick += Btn4000_OnClick;
            _btn4000.ButtonType = ButtonType.Silent;

            AddImage(437, 199, "UI/Get-more-credits-like-us-on-facebook-text.png");

            _tenTimesText = AddImage(437, 83, "UI/Get-more-credits-watch-advertisement.png");

            // disable watch ad button
            if (Player.Instance.LastAdWatchDay.Date != DateTime.Now.Date)
            {
                Player.Instance.LastAdWatchDay = DateTime.Now;
                Player.Instance.LastAdWatchTime = Convert.ToDateTime("1900-01-01");
                Player.Instance.LastAdWatchDayCount = 0;
            }

            var lastAdWatchDayCount = Player.Instance.LastAdWatchDayCount;
            
            _btn2000 = AddButton(0, 105, "UI/Get-more-credits-get-2000-credits-button-untapped.png", "UI/Get-more-credits-get-2000-credits-button-tapped.png");
            _btn2000.ButtonType = ButtonType.CreditPurchase;
            
            if (lastAdWatchDayCount >= 10)
            {
                DisableButtonsOnLayer(_btn2000);
                
                var backgroundTask = new System.Threading.Thread(() =>
                {
                    var timeCountdown = CountTimeSpan(Player.Instance.LastAdWatchTime.AddDays(1));
                    DisableBtnOnTime(timeCountdown.Seconds);
                });
                    
                backgroundTask.Start();
            }
            else
            {
                _btn2000.OnClick += Btn2000_OnClick;

                if (Player.Instance.IsAdInCountdown)
                {
                    var backgroundTask = new System.Threading.Thread(() =>
                    {
                        var adCountdown = CountTimeSpan(Player.Instance.DateTimeOfLastOpenedAd);
                        DisableBtnOnTime(adCountdown.Seconds);
                    });
                    
                    backgroundTask.Start();
                }
            }

            Children.Add(_tenTimesText);

            CheckNetworkConnection();

            if (creditsRequired != 0)
            {
                AddImage(0, 0, "UI/Get-more-credits-credits-needed-for-your-text.png");
                AddImageLabel(305, 5, creditsRequired.ToString(), 77);

                AddImage(544, 0, "UI/Get-more-credits-your-currently-available-credits-text.png");
                _imgPlayerCreditsXCoord = 850;
            }
            else
            {
                AddImage(5, 0, "UI/Get-more-credits-main-screen-your-currently-available-credits.png");
                _imgPlayerCreditsXCoord = 855;
            }

            RefreshPlayerCreditsLabel();

            AdManager.ClearEvents();
            PurchaseManager.ClearEvents();

            AdManager.OnInterstitialAdOpened += AdMobManager_OnInterstitialAdOpened;
            AdManager.OnInterstitialAdClosed += AdMobManager_OnInterstitialAdClosed;
            AdManager.OnInterstitialAdFailedToLoad += AdMobManager_OnInterstitialAdFailedToLoad;
            PurchaseManager.OnPurchaseFinished += PurchaseManager_OnPurchaseFinished;

            if (Player.Instance.FacebookLikeUsed)
            {
                _btn4000 = AddButton(0, 199, "UI/Get-more-credits-get-4000-credits-button-tapped.png", "UI/Get-more-credits-get-4000-credits-button-tapped.png");
            }
        }

        private void RefreshPlayerCreditsLabel(float dt = 0.00f)
        {
            if (_imgPlayerCreditsLabel != null)
            {
                foreach (var img in _imgPlayerCreditsLabel)
                {
                    img.RemoveFromParent();
                }
            }

            _imgPlayerCreditsLabel = AddImageLabel(_imgPlayerCreditsXCoord, 0, Player.Instance.Credits.ToString(), 77);
        }

        private void Btn4000_OnClick(object sender, EventArgs e)
        {
            if (!NetworkConnectionManager.IsInternetConnectionAvailable())
            {
                return;
            }
            Player.Instance.FacebookLikeUsed = false;

            if (Player.Instance.FacebookLikeUsed)
            {
                _btn4000 = AddButton(0, 199, "UI/Get-more-credits-get-4000-credits-button-tapped.png", "UI/Get-more-credits-get-4000-credits-button-tapped.png");
                
                if(_btn4000.ButtonType != ButtonType.CannotTap)
                    GameEnvironment.PlaySoundEffect(SoundEffect.MenuTapCannotTap);
                
                return;
            }

            GameEnvironment.OpenWebPage("http://www.facebook.com/looneyinvaders");

            _btn4000 = AddButton(0, 199, "UI/Get-more-credits-get-4000-credits-button-tapped.png", "UI/Get-more-credits-get-4000-credits-button-tapped.png");
            Player.Instance.Credits += 4000;
            GameEnvironment.PlaySoundEffect(SoundEffect.MenuTapCreditPurchase);
            Player.Instance.FacebookLikeUsed = true;
            ScheduleOnce(RefreshPlayerCreditsLabel, 0.01f);
        }

        private async void BtnBack_OnClick(object sender, EventArgs e)
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            Unschedule(DisableBtn);

            AdManager.OnInterstitialAdOpened -= AdMobManager_OnInterstitialAdOpened;
            AdManager.OnInterstitialAdClosed -= AdMobManager_OnInterstitialAdClosed;
            AdManager.OnInterstitialAdFailedToLoad -= AdMobManager_OnInterstitialAdFailedToLoad;
            PurchaseManager.OnPurchaseFinished -= PurchaseManager_OnPurchaseFinished;

            if (_selectedWeapon == -1)
            {
                var newLayer = new MainScreenLayer();
                await TransitionToLayerCartoonStyleAsync(newLayer);
            }
            else if (_caliberSizeSelected == -1)
            {
                TransitionToLayer(new WeaponPickerLayer(_selectedEnemy, _selectedWeapon));
            }
            else
            {
                TransitionToLayer(new WeaponUpgradeScreenLayer(_selectedEnemy, _selectedWeapon, _caliberSizeSelected, _firespeedSelected, _magazineSizeSelected, _livesSelected));
            }
        }

        private void Btn2000_OnClick(object sender, EventArgs e)
        {
            if (!NetworkConnectionManager.IsInternetConnectionAvailable())
                return;

            if (Player.Instance.LastAdWatchDay.Date != DateTime.Now.Date)
            {
                Player.Instance.LastAdWatchDay = DateTime.Now;
                Player.Instance.LastAdWatchTime = Convert.ToDateTime("1900-01-01");
                Player.Instance.LastAdWatchDayCount = 0;
            }

            var lastAdWatchTime = Player.Instance.LastAdWatchTime;
            var lastAdWatchDayCount = Player.Instance.LastAdWatchDayCount;
            
            if(lastAdWatchDayCount > 10)
                return;

            if (lastAdWatchDayCount == 10)
            {
                var timeToNewDay = CountTimeSpan(lastAdWatchTime.AddDays(1));
                DisableBtnOnTime(timeToNewDay.TotalSeconds);
                return;
            }
            
            DisableBtnOnTime(6);
            Player.Instance.IsAdInCountdown = true;
            ScheduleOnce(RunAdInDelay, 0.16f);
        }

        private void RunAdInDelay(float obj)
        {
            AdManager.ShowInterstitial();
        }

        private void DisableBtnOnTime(double sec)
        {
            Player.Instance.DateTimeOfLastOpenedAd = DateTime.Now.AddSeconds(sec);
            DisableButtonsOnLayer(_btn2000);
            _tenTimesText.Visible = false;
            _timeToNextAdsImg = AddImage(437, 83, "UI/next-ad-available-in-text.png");
            //_timeToNextAds = sec;

            var backgroundTask = new System.Threading.Thread(() =>
            {
                Schedule(DisableBtn, 0.16f);
            });
            
            backgroundTask.Start();
        }

        // public override void OnExit()
        // {
        //     if (_timeToNextAds > 0)
        //     {
        //         Settings.Instance.TimeToNewAd = _timeToNextAds;
        //         Settings.Instance.TimeWhenPageAdsLeaved = DateTime.Now;
        //     }
        //
        //     base.OnExit();
        // }

        private void DisableBtn(float dt)
        {
            RemoveChild(_h1);
            RemoveChild(_h2);
            RemoveChild(_m1);
            RemoveChild(_m2);
            RemoveChild(_s1);
            RemoveChild(_s2);
            var currentTimeSpan = CountTimeSpan(Player.Instance.DateTimeOfLastOpenedAd);
            
            var h1 = '0';
            var h2 = '0';
            
            if (currentTimeSpan.Hours > 9)
            {
                h1 = currentTimeSpan.Hours.ToString()[0];
                h2 = currentTimeSpan.Hours.ToString()[1];
            }
            else
            {
                h2 = currentTimeSpan.Hours.ToString()[0];
            }
            
            _h1 = AddImage(513, 83, $"UI/number_57_{h1}.png");
            _h2 = AddImage(540, 83, $"UI/number_57_{h2}.png");
            
            var m1 = '0';
            var m2 = '0';
            if (currentTimeSpan.Minutes > 9)
            {
                m1 = currentTimeSpan.Minutes.ToString()[0];
                m2 = currentTimeSpan.Minutes.ToString()[1];
            }
            else
            {
                m2 = currentTimeSpan.Minutes.ToString()[0];
            
            }
            _m1 = AddImage(663, 83, $"UI/number_57_{m1}.png");
            _m2 = AddImage(690, 83, $"UI/number_57_{m2}.png");
            
            var s1 = '0';
            var s2 = '0';
            if (currentTimeSpan.Seconds > 9)
            {
                s1 = currentTimeSpan.Seconds.ToString()[0];
                s2 = currentTimeSpan.Seconds.ToString()[1];
            }
            else
            {
                s2 = currentTimeSpan.Seconds.ToString()[0];
            }
            
            _s1 = AddImage(843, 83, $"UI/number_57_{s1}.png");
            _s2 = AddImage(870, 83, $"UI/number_57_{s2}.png");
            
            if (currentTimeSpan.Seconds <= 0)
            {
                Player.Instance.IsAdInCountdown = false;
                RemoveChild(_timeToNextAdsImg);
                RemoveChild(_h1);
                RemoveChild(_h2);
                RemoveChild(_m1);
                RemoveChild(_m2);
                RemoveChild(_s1);
                RemoveChild(_s2);
            
                EnableButtonsOnLayer(_btn2000);
                _tenTimesText.Visible = true;
                Unschedule(DisableBtn);
            }
        }

        private void AdMobManager_OnInterstitialAdOpened(object sender, EventArgs e)
        {
            ScheduleOnce(InterstitialOpened, 0.01f);
        }

        private void AdMobManager_OnInterstitialAdClosed(object sender, EventArgs e)
        {

        }

        private void InterstitialOpened(float dt = 0.00f)
        {
            Player.Instance.LastAdWatchTime = DateTime.Now;
            ++Player.Instance.LastAdWatchDayCount;
            Player.Instance.Credits += 2000;
            RefreshPlayerCreditsLabel();
        }

        private void AdMobManager_OnInterstitialAdFailedToLoad(object sender, EventArgs e) { }

        //ToDo: Bass - check if asyncs is profit
        private async void Btn1m_OnClick(object sender, EventArgs e)
        {
            Enabled = false;
            await PurchaseManager.Purchase("credits_1_mil");
        }

        private async void Btn300k_OnClick(object sender, EventArgs e)
        {
            Enabled = false;
            await PurchaseManager.Purchase("credits_300_k");
        }

        private async void Btn100k_OnClick(object sender, EventArgs e)
        {
            Enabled = false;
            await PurchaseManager.Purchase("credits_100_k");
        }

        private void PurchaseManager_OnPurchaseFinished(object sender, EventArgs e)
        {
            Enabled = true;
            ScheduleOnce(RefreshPlayerCreditsLabel, 0.01f);
        }

        private void CheckNetworkConnection()
        {
            var isButtonsDisabled = false;
            
            if (!NetworkConnectionManager.IsInternetConnectionAvailable())
            {
                isButtonsDisabled = true;
                DisableButtonsOnLayer(_btn2000, _btn4000, _btn100K, _btn300K, _btn1M);
            }
            else
            {
                if(isButtonsDisabled)
                    EnableButtonsOnLayer(_btn2000, _btn4000, _btn100K, _btn300K, _btn1M);
            }
        }

        private TimeSpan CountTimeSpan(DateTime pastDateTime)
        {
            var currentDateTime = DateTime.Now;
            return pastDateTime - currentDateTime;
        }
    }
}