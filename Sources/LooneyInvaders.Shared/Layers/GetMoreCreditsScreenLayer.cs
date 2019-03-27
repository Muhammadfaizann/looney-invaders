using System;
using CocosSharp;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;


#if __IOS__
using Foundation;
using Microsoft.AppCenter.Crashes;
#endif
namespace LooneyInvaders.Layers
{
    public class GetMoreCreditsScreenLayer : CCLayerColorExt
    {
        //int _creditsRequired;
        private readonly int _selectedEnemy;
        private readonly int _selectedWeapon;
        private readonly int _caliberSizeSelected;
        private readonly int _firespeedSelected;
        private readonly int _magazineSizeSelected;
        private readonly int _livesSelected;

        private readonly int _imgPlayerCreditsXCoord;
#if __IOS__
        //NSTimer fakeTimer;

#endif

        //CCScheduler m_pScheduler;
        //CCActionManager m_pActionManager;

        private CCSprite[] _imgPlayerCreditsLabel;
        private readonly CCSpriteButton _btn2000Hiden;
        private CCSpriteButton _btn2000;
        private CCSpriteButton _btn4000;
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

            var btn1M = AddButton(0, 475, "UI/Get-more-credits-get-1000000-credits-button-untapped.png", "UI/Get-more-credits-get-1000000-credits-button-tapped.png");
            btn1M.OnClick += btn1m_OnClick;
            btn1M.ButtonType = ButtonType.CreditPurchase;

            AddImage(517, 470, "UI/Get-more-credits-get-7_99-USD.png");

            var btn300K = AddButton(0, 381, "UI/Get-more-credits-get-300000-credits-button-untapped.png", "UI/Get-more-credits-get-300000-credits-button-tapped.png");
            btn300K.OnClick += btn300k_OnClick;
            btn300K.ButtonType = ButtonType.CreditPurchase;

            AddImage(517, 379, "UI/Get-more-credits-get-4_99-USD.png");

            var btn100K = AddButton(0, 290, "UI/Get-more-credits-get-100000-credits-button-untapped.png", "UI/Get-more-credits-get-100000-credits-button-tapped.png");
            btn100K.OnClick += Btn100k_OnClick;
            btn100K.ButtonType = ButtonType.CreditPurchase;

            AddImage(517, 291, "UI/Get-more-credits-get-1_99-USD.png");

            //------------ Prabhjot -----------//

            //if(Player.Instance.FacebookLikeUsed)
            //{
            //    _btn4000 = this.AddButton(0, 199, "UI/Get-more-credits-get-4000-credits-button-tapped.png", "UI/Get-more-credits-get-4000-credits-button-tapped.png");
            //}
            //else
            //{
            //    _btn4000 = this.AddButton(0, 199, "UI/Get-more-credits-get-4000-credits-button-untapped.png", "UI/Get-more-credits-get-4000-credits-button-tapped.png");
            //}

            _btn4000 = AddButton(0, 199, "UI/Get-more-credits-get-4000-credits-button-untapped.png", "UI/Get-more-credits-get-4000-credits-button-tapped.png");


            _btn4000.OnClick += btn4000_OnClick;
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

            _btn2000Hiden = AddButton(0, 105, "UI/Get-more-credits-get-2000-credits-button-tapped.png", "UI/Get-more-credits-get-2000-credits-button-tapped.png");
            _btn2000Hiden.OnClick += btn2000Hiden_OnClick;
            _btn2000Hiden.ButtonType = ButtonType.Silent;
            _btn2000Hiden.Visible = false;

            if (lastAdWatchDayCount >= 10)  // Prabhjot 10
            {
                _btn2000 = AddButton(0, 105, "UI/Get-more-credits-get-2000-credits-button-tapped.png", "UI/Get-more-credits-get-2000-credits-button-untapped.png");
                _btn2000.Enabled = false;
                _btn2000.OnClick += btn2000_OnClick;
                _btn2000.ButtonType = ButtonType.Silent;
                var timeToNewDay = DateTime.Now.AddDays(1).Date - DateTime.Now;
                DisableBtnOnTime(timeToNewDay.TotalSeconds);
            }
            else
            {
                _btn2000 = AddButton(0, 105, "UI/Get-more-credits-get-2000-credits-button-untapped.png", "UI/Get-more-credits-get-2000-credits-button-tapped.png");
                _btn2000.OnClick += btn2000_OnClick;
                _btn2000.ButtonType = ButtonType.Silent;

                if (Settings.Instance.TimeToNewAd > 0)
                {
                    _btn2000.Visible = false;
                    _btn2000Hiden.Visible = true;

                    var timeBeforeLeave = Settings.Instance.TimeWhenPageAdsLeaved;
                    var timeNow = DateTime.Now;
                    var secondsSpent = (timeBeforeLeave - timeNow).Seconds;
                    var timeVal = Settings.Instance.TimeToNewAd + secondsSpent;
                    Settings.Instance.TimeWhenPageAdsLeaved = default(DateTime);
                    //DisableBtnOnTime(timeVal);
                    var backgroundTask = new System.Threading.Thread(() =>
                    {
                        DisableBtnOnTime(timeVal);
                    });
                    backgroundTask.Start();
                }
            }

            Children.Add(_tenTimesText);

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

            AdMobManager.ClearEvents();
            PurchaseManager.ClearEvents();

            AdMobManager.OnInterstitialAdOpened += AdMobManager_OnInterstitialAdOpened;
            AdMobManager.OnInterstitialAdClosed += AdMobManager_OnInterstitialAdClosed;
            AdMobManager.OnInterstitialAdFailedToLoad += AdMobManager_OnInterstitialAdFailedToLoad;
            PurchaseManager.OnPurchaseFinished += PurchaseManager_OnPurchaseFinished;

            //-------------- Prabhjot -------------//
            if (!NetworkConnectionManager.IsInternetConnectionAvailable())
            {
                Console.WriteLine("No Net");

                _btn2000 = AddButton(0, 105, "UI/Get-more-credits-get-2000-credits-button-tapped.png", "UI/Get-more-credits-get-2000-credits-button-tapped.png");
                _btn2000.Enabled = false;
                _btn4000 = AddButton(0, 199, "UI/Get-more-credits-get-4000-credits-button-tapped.png", "UI/Get-more-credits-get-4000-credits-button-tapped.png");
                _btn4000.Enabled = false;
            }
            else if (Player.Instance.FacebookLikeUsed)
            {
                _btn4000 = AddButton(0, 199, "UI/Get-more-credits-get-4000-credits-button-tapped.png", "UI/Get-more-credits-get-4000-credits-button-tapped.png");
            }
        }

        private void RefreshPlayerCreditsLabel(float dt = 0.00f)
        {
            if (_imgPlayerCreditsLabel != null)
            {
                foreach (var img in _imgPlayerCreditsLabel) img.RemoveFromParent();
            }

            _imgPlayerCreditsLabel = AddImageLabel(_imgPlayerCreditsXCoord, 0, Player.Instance.Credits.ToString(), 77);
        }

        private void btn4000_OnClick(object sender, EventArgs e)
        {

            //if (!NetworkConnectionManager.IsInternetConnectionAvailable())
            //{
            //    _btn4000 = this.AddButton(0, 199, "UI/Get-more-credits-get-4000-credits-button-tapped.png", "UI/Get-more-credits-get-4000-credits-button-tapped.png");
            //    _btn4000.Enabled = false;
            //    return;
            //}

            if (Player.Instance.FacebookLikeUsed || !NetworkConnectionManager.IsInternetConnectionAvailable())
            {
                _btn4000 = AddButton(0, 199, "UI/Get-more-credits-get-4000-credits-button-tapped.png", "UI/Get-more-credits-get-4000-credits-button-tapped.png");
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

        private void BtnBack_OnClick(object sender, EventArgs e)
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            Unschedule(DisableBtn);


            //----------------- Prabhjot ----------------//
            /*    #if __IOS__
                if (fakeTimer != null)
                {
                    fakeTimer.Invalidate();
                    fakeTimer.Dispose();
                    fakeTimer = null;

                }
                #endif

           */

            //if(fakeTimer != null)
            //{
            //    fakeTimer.UnscheduleAll();
            //    fakeTimer = null;
            //}

            AdMobManager.OnInterstitialAdOpened -= AdMobManager_OnInterstitialAdOpened;
            AdMobManager.OnInterstitialAdClosed -= AdMobManager_OnInterstitialAdClosed;
            AdMobManager.OnInterstitialAdFailedToLoad -= AdMobManager_OnInterstitialAdFailedToLoad;
            PurchaseManager.OnPurchaseFinished -= PurchaseManager_OnPurchaseFinished;

            if (_selectedWeapon == -1)
            {
                TransitionToLayerCartoonStyle(new MainScreenLayer());
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

        private void btn2000Hiden_OnClick(object sender, EventArgs e)
        {
            GameEnvironment.PlaySoundEffect(SoundEffect.MenuTapCannotTap);
        }

        private void btn2000_OnClick(object sender, EventArgs e)
        {
            //Crashes.GenerateTestCrash();

            if (!NetworkConnectionManager.IsInternetConnectionAvailable())
            {
                _btn2000 = AddButton(0, 105, "UI/Get-more-credits-get-2000-credits-button-tapped.png", "UI/Get-more-credits-get-2000-credits-button-untapped.png");
                _btn2000.Enabled = false;
                GameEnvironment.PlaySoundEffect(SoundEffect.MenuTapCannotTap);
                return;
            }

            _btn2000Hiden.Visible = true;
            _btn2000.Visible = false;

            Console.WriteLine("Last watch count before: " + Player.Instance.LastAdWatchDayCount);

            if (Player.Instance.LastAdWatchDay.Date != DateTime.Now.Date)
            {
                Player.Instance.LastAdWatchDay = DateTime.Now;
                Player.Instance.LastAdWatchTime = Convert.ToDateTime("1900-01-01");
                Player.Instance.LastAdWatchDayCount = 0;
            }

            var lastAdWatchTime = Player.Instance.LastAdWatchTime;
            var lastAdWatchDayCount = Player.Instance.LastAdWatchDayCount;

            Console.WriteLine($"Total seconds passed: {(DateTime.Now - lastAdWatchTime).TotalSeconds}");

            //if ((DateTime.Now - LastAdWatchTime).TotalSeconds < 5)
            //{
            //  GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
            //  Console.WriteLine("5 seconds must pass between ads, passed " + (DateTime.Now - LastAdWatchTime).Seconds.ToString());
            //  return;
            //}

            if (lastAdWatchDayCount >= 10)  // Prabhjot 10
            {
                GameEnvironment.PlaySoundEffect(SoundEffect.MenuTapCannotTap);
                Console.WriteLine("limited to 10 ads a day");

                var timeToNewDay = DateTime.Now.AddDays(1).Date - DateTime.Now;
                DisableBtnOnTime(timeToNewDay.TotalSeconds);
                return;
            }

            // NSTimer.CreateScheduledTimer(1, (_) => AdMobManager.ShowInterstitial(2));
            DisableBtnOnTime(6);

            //NSTimer.CreateScheduledTimer(new TimeSpan(0, 0, 5), delegate {
            //   AdMobManager.ShowInterstitial(0);
            //});
            //bool isNeedToFire;

            //isNeedToFire = false;

            /*
#if __IOS__
            if (fakeTimer != null){
                fakeTimer.Invalidate();
                fakeTimer.Dispose();
                fakeTimer = null;
            }
            fakeTimer = NSTimer.CreateRepeatingScheduledTimer(TimeSpan.FromSeconds(2.0), delegate {

                //Write Action Here
                //_s1 = AddImage(843, 83, $"UI/number_57_0.png");
                // _s2 = AddImage(870, 83, $"UI/number_57_0.png");
                //_btn2000.Enabled = true;

                //_s1.Visible = false;
                //_s2.Visible = false;
                // _tenTimesText.Visible = true;
                //_btn2000Hiden.Visible = false;
                // _btn2000.Visible = true;

                if (isNeedToFire == true) {
                    _timeToNextAds = -1;
                    Console.WriteLine("NSTimer chal peya");

                    if (fakeTimer != null)
                    {
                        fakeTimer.Invalidate();
                        fakeTimer.Dispose();
                        fakeTimer = null;
                    }
                }

                isNeedToFire = true;

            });
            fakeTimer.Fire();
#endif

            */


            // scheduler
            // m_pScheduler = new CCScheduler();
            // action manager
            //m_pActionManager = new CCActionManager();

            // m_pScheduler.ScheduleUpdateForTarget(m_pActionManager, CCScheduler.kCCPrioritySystem, false)


            // ScheduleOnce(setTimeInDelay, 0.16f);

            ScheduleOnce(RunAdInDelay, 0.16f);

            //_s1 = AddImage(843, 83, $"UI/number_57_0.png");
            //_s2 = AddImage(870, 83, $"UI/number_57_0.png");


        }

        private void RunAdInDelay(float obj)
        {

            AdMobManager.ShowInterstitial(0);
            //_timeToNextAds = -1;
            Console.WriteLine("NSTimer chal peya");


        }
        //private void setTimeInDelay(float obj)
        //{
        //    _timeToNextAds = 0;

        //}

        private void DisableBtnOnTime(double sec)
        {
            // MainThread.BeginInvokeOnMainThread(() =>
            // {
            _btn2000.Enabled = false;

            _tenTimesText.Visible = false;

            _timeToNextAdsImg = AddImage(437, 83, "UI/next-ad-available-in-text.png");

            _timeToNextAds = sec;

            // });


            var backgroundTask = new System.Threading.Thread(() =>
            {
                Schedule(DisableBtn, 0.16f);
            });
            backgroundTask.Start();

        }

        public override void OnExit()
        {
            if (_timeToNextAds > 0)
            {
                Settings.Instance.TimeToNewAd = _timeToNextAds;
                Settings.Instance.TimeWhenPageAdsLeaved = DateTime.Now;
            }

            base.OnExit();
        }


        private void DisableBtn(float dt)
        {
            // this.Invoke(new Action(() => MyFunction()));

            // MainThread.BeginInvokeOnMainThread(() =>
            // {


            RemoveChild(_h1);
            RemoveChild(_h2);
            RemoveChild(_m1);
            RemoveChild(_m2);
            RemoveChild(_s1);
            RemoveChild(_s2);


            // });

            if (Settings.Instance.TimeWhenPageAdsLeaved != default(DateTime))
            {
                var timeBeforeLeave = Settings.Instance.TimeWhenPageAdsLeaved;
                var timeNow = DateTime.Now;
                var secondsSpent = (timeBeforeLeave - timeNow).Seconds;
                var timeVal = Settings.Instance.TimeToNewAd + secondsSpent;
                Settings.Instance.TimeWhenPageAdsLeaved = default(DateTime);
                _timeToNextAds += timeVal;
            }
            else
            {
                _timeToNextAds -= dt;
            }

            var time = TimeSpan.FromSeconds(_timeToNextAds);

            var h1 = '0';
            var h2 = '0';
            // MainThread.BeginInvokeOnMainThread(() =>
            //{

            if (time.Hours > 9)
            {
                h1 = time.Hours.ToString()[0];
                h2 = time.Hours.ToString()[1];
            }
            else
            {
                h2 = time.Hours.ToString()[0];
            }

            _h1 = AddImage(513, 83, $"UI/number_57_{h1}.png");
            _h2 = AddImage(540, 83, $"UI/number_57_{h2}.png");

            var m1 = '0';
            var m2 = '0';
            if (time.Minutes > 9)
            {
                m1 = time.Minutes.ToString()[0];
                m2 = time.Minutes.ToString()[1];
            }
            else
            {
                m2 = time.Minutes.ToString()[0];

            }
            _m1 = AddImage(663, 83, $"UI/number_57_{m1}.png");
            _m2 = AddImage(690, 83, $"UI/number_57_{m2}.png");

            var s1 = '0';
            var s2 = '0';
            if (time.Seconds > 9)
            {
                s1 = time.Seconds.ToString()[0];
                s2 = time.Seconds.ToString()[1];
            }
            else
            {
                s2 = time.Seconds.ToString()[0];
            }

            _s1 = AddImage(843, 83, $"UI/number_57_{s1}.png");
            _s2 = AddImage(870, 83, $"UI/number_57_{s2}.png");

            //  });


            if (_timeToNextAds < 0)
            {
                //MainThread.BeginInvokeOnMainThread(() =>
                //{
                RemoveChild(_timeToNextAdsImg);
                RemoveChild(_h1);
                RemoveChild(_h2);
                RemoveChild(_m1);
                RemoveChild(_m2);
                RemoveChild(_s1);
                RemoveChild(_s2);

                _btn2000.Enabled = true;
                _tenTimesText.Visible = true;
                _btn2000Hiden.Visible = false;
                _btn2000.Visible = true;

                //  });


                var backgroundTask = new System.Threading.Thread(() =>
                {
                    Unschedule(DisableBtn);
                });
                backgroundTask.Start();
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

            Player.Instance.LastAdWatchDayCount = Player.Instance.LastAdWatchDayCount + 1;
            GameEnvironment.PlaySoundEffect(SoundEffect.MenuTapCreditPurchase);

            if (Player.Instance.LastAdWatchDayCount >= 10) // Prabhjot 10
            {
                Children.Remove(_btn2000);
                _btn2000 = AddButton(0, 105, "UI/Get-more-credits-get-2000-credits-button-tapped.png", "UI/Get-more-credits-get-2000-credits-button-untapped.png");
                _btn2000.Enabled = false;
                _btn2000.OnClick += btn2000_OnClick;
                _btn2000.ButtonType = ButtonType.Silent;
                var timeToNewDay = DateTime.Now.AddDays(1).Date - DateTime.Now;
                DisableBtnOnTime(timeToNewDay.TotalSeconds);

            }

            Player.Instance.Credits += 2000;
            Console.WriteLine("Last watch count after: " + Player.Instance.LastAdWatchDayCount);
            RefreshPlayerCreditsLabel();
        }

        private void AdMobManager_OnInterstitialAdFailedToLoad(object sender, EventArgs e)
        { }

        private void btn1m_OnClick(object sender, EventArgs e)
        {
            PurchaseManager.Purchase("credits_1_mil");
            Enabled = false;
        }

        private void btn300k_OnClick(object sender, EventArgs e)
        {
            PurchaseManager.Purchase("credits_300_k");
            Enabled = false;
        }

        private void Btn100k_OnClick(object sender, EventArgs e)
        {
            PurchaseManager.Purchase("credits_100_k");
            Enabled = false;
        }

        private void PurchaseManager_OnPurchaseFinished(object sender, EventArgs e)
        {
            Enabled = true;
            ScheduleOnce(RefreshPlayerCreditsLabel, 0.01f);
        }
    }
}