using System;
using System.Threading.Tasks;
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

        private readonly CCSpriteButton _btn1M;
        private readonly CCSpriteButton _btn300K;
        private readonly CCSpriteButton _btn100K;
        private readonly CCSpriteButton _btn4000;
        private readonly CCSpriteButton _btn2000;
        private readonly CCSprite _tenTimesText;

        private CCSprite[] _imgPlayerCreditsLabel;
        private CCSprite _notificationImage;
        private CCSprite _timeToNextAdsImg;
        private CCSprite _h1;
        private CCSprite _h2;
        private CCSprite _m1;
        private CCSprite _m2;
        private CCSprite _s1;
        private CCSprite _s2;
        private bool _adWasShownOrFailed;

        private CustomCancellationTokenSource _notificationTokenSource;

        public GetMoreCreditsScreenLayer() : this(0, -1, -1, -1, -1, -1, -1) { }

        public GetMoreCreditsScreenLayer(int creditsRequired, int selectedEnemy, int selectedWeapon)
            : this(creditsRequired, selectedEnemy, selectedWeapon, -1, -1, -1, -1)
        { }

        public GetMoreCreditsScreenLayer(int creditsRequired, int selectedEnemy, int selectedWeapon, int caliberSizeSelected, int fireSpeedSelected, int magazineSizeSelected, int livesSelected)
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();
            
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
            _btn4000.OnClick += (s, e) => ScheduleOnce(Btn4000_OnClick, 0f);
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
            _btn2000 = AddButton(0, 105, "UI/Get-more-credits-get-2000-credits-button-untapped.png", "UI/Get-more-credits-get-2000-credits-button-tapped.png");
            _btn2000.ButtonType = ButtonType.CreditPurchase;

            var lastAdWatchDayCount = Player.Instance.LastAdWatchDayCount;
            if (lastAdWatchDayCount >= 10)
            {
                ScheduleOnce(_ =>
                {
                    DisableButton2000ForTime(Player.Instance.LastAdWatchTime.AddDays(1));
                }, 0.1f);
            }
            else
            {
                _btn2000.OnClick += (s, e) => ScheduleOnce(Btn2000_OnClick, 0f);

                if (Player.Instance.IsAdInCountdown)
                {
                    ScheduleOnce(_ =>
                    {
                        DisableButton2000ForTime(Player.Instance.DateTimeOfCountdownPassed);
                    }, 0.1f);
                }
            }
            Children.Add(_tenTimesText);

            DisableButtonsIfNoInternet();

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

            PurchaseManager.ClearEvents();
            AdManager.ClearInterstitialEvents();
            AdManager.OnInterstitialAdOpened += AdMobManager_OnInterstitialAdOpened;
            AdManager.OnInterstitialAdClosed += AdMobManager_OnInterstitialAdClosed;
            AdManager.OnInterstitialAdFailedToLoad += AdMobManager_OnInterstitialAdFailedToLoad;
            PurchaseManager.OnPurchaseFinished -= PurchaseManager_OnPurchaseFinished;
            PurchaseManager.OnPurchaseFinished += PurchaseManager_OnPurchaseFinished;

            if (Player.Instance.FacebookLikeUsed)
            {
                _btn4000 = AddButton(0, 199, "UI/Get-more-credits-get-4000-credits-button-tapped.png", "UI/Get-more-credits-get-4000-credits-button-tapped.png");
            }
        }

        private void RefreshPlayerCreditsLabel(float dt = 0f)
        {
            if (_imgPlayerCreditsLabel != null)
            {
                foreach (var img in _imgPlayerCreditsLabel)
                {
                    img.RemoveFromParent();
                }
            }
            _imgPlayerCreditsLabel = AddImageLabel(_imgPlayerCreditsXCoord, 0, Player.Instance.Credits.ToString(), 0);
        }

        private void Btn4000_OnClick(float period)
        {
            if (!NetworkConnectionManager.IsInternetConnectionAvailable() || Player.Instance.FacebookLikeUsed)
            {
                GameEnvironment.PlaySoundEffect(SoundEffect.MenuTapCannotTap);
                return;
            }
            DisableButtonsOnLayer(_btn4000);

            GameEnvironment.OpenWebPage("http://www.facebook.com/looneyinvaders");
            GameEnvironment.PlaySoundEffect(SoundEffect.MenuTapCreditPurchase);
            Player.Instance.Credits += 4000;
            Player.Instance.FacebookLikeUsed = true;

            ScheduleOnce(RefreshPlayerCreditsLabel, 0.01f);
        }

        private async void BtnBack_OnClick(object sender, EventArgs e)
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();
            Unschedule(RefreshBtn2000);

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

        private void Btn2000_OnClick(float period)
        {
            if (!NetworkConnectionManager.IsInternetConnectionAvailable()) {
                return;
            }

            if (Player.Instance.LastAdWatchDay.Date != DateTime.Now.Date)
            {
                Player.Instance.LastAdWatchDay = DateTime.Now;
                Player.Instance.LastAdWatchTime = Convert.ToDateTime("1900-01-01");
                Player.Instance.LastAdWatchDayCount = 0;
            }

            var lastAdWatchTime = Player.Instance.LastAdWatchTime;
            var lastAdWatchDayCount = Player.Instance.LastAdWatchDayCount;
            if (lastAdWatchDayCount > 10) {
                return;
            }

            if (lastAdWatchDayCount == 10)
            {
                DisableButton2000ForTime(lastAdWatchTime.AddDays(1));
                return;
            }

            Player.Instance.IsAdInCountdown = true;
            DisableButton2000ForTime(DateTime.Now.AddSeconds(6));
            ScheduleOnce(_ => AdManager.ShowInterstitial(), 0.05f);
        }

        private void DisableButton2000ForTime(DateTime dateTimeButtonActivated)
        {
            Player.Instance.DateTimeOfCountdownPassed = dateTimeButtonActivated;

            _tenTimesText.Visible = false;
            _timeToNextAdsImg = AddImage(437, 83, "UI/next-ad-available-in-text.png");

            ScheduleOnce(_ => DisableButtonsOnLayer(_btn2000), 0f);
            Schedule(RefreshBtn2000, 0.15f);
        }

        private void RefreshBtn2000(float dt)
        {
            RemoveChildren(_h1, _h2, _m1, _m2, _s1, _s2);

            var currentTimeSpan = CountTimeSpan(Player.Instance.DateTimeOfCountdownPassed);
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
                if (!_adWasShownOrFailed)
                {
                    AdManager.HideInterstitial();
                    AdManager.LoadInterstitial();
                    ShowErrorNotification("ads-not-quick-loaded-notification");
                }
                Player.Instance.IsAdInCountdown = false;
                RemoveChildren(_timeToNextAdsImg, _h1, _h2, _m1, _m2, _s1, _s2);
                Unschedule(RefreshBtn2000);
                ScheduleOnce(_ =>
                {
                    EnableButtonsOnLayer(_btn2000);
                    _tenTimesText.Visible = true;
                }, 0f);
            }
        }

        private void AdMobManager_OnInterstitialAdOpened(object s, EventArgs e) => ScheduleOnce(InterstitialOpened, 0.01f);

        private void AdMobManager_OnInterstitialAdClosed(object s, EventArgs e) { }

        private void InterstitialOpened(float dt = 0.00f)
        {
            _adWasShownOrFailed = true;

            Player.Instance.LastAdWatchTime = DateTime.Now;
            Player.Instance.Credits += 2000;
            ++Player.Instance.LastAdWatchDayCount;

            RefreshPlayerCreditsLabel();
        }

        private void AdMobManager_OnInterstitialAdFailedToLoad(object sender, EventArgs e)
        {
            ScheduleOnce(_ => ShowErrorNotification("ads-not-available-notification"), 0f);
            _adWasShownOrFailed = true;
        }

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

        private void DisableButtonsIfNoInternet()
        {
            if (!NetworkConnectionManager.IsInternetConnectionAvailable())
            {
                DisableButtonsOnLayer(_btn2000, _btn4000, _btn100K, _btn300K, _btn1M);
            }
        }

        private TimeSpan CountTimeSpan(DateTime pastDateTime)
        {
            var currentDateTime = DateTime.Now;
            return pastDateTime - currentDateTime;
        }

        private async void ShowErrorNotification(string imageName)
        {
            if (_notificationImage == null)
            {
                _notificationImage = AddImage(0, 0, $"UI/{imageName}.png");
                _notificationImage.Opacity = 210;
                AddChild(_notificationImage, 600);
            }
            _notificationImage.Visible = true;
            PauseListeners();

            using (_notificationTokenSource = new CustomCancellationTokenSource())
            {
                await Task.Delay(2000, _notificationTokenSource.Token);
                //custom token source isn't still used since all events are paused
                _notificationImage.Visible = false;
                //cancel token where you want to hide _notificationImage
                _notificationTokenSource.Cancel();

                ResumeListeners();
            }
        }
    }
}