using System;
using System.Collections.Generic;
using CocosSharp;
using Xamarin.Essentials;
using Microsoft.Xna.Framework;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;
using System.Threading.Tasks;
using Microsoft.AppCenter.Crashes;


#if __IOS__
using Foundation;
using Microsoft.AppCenter.Crashes;
#endif
namespace LooneyInvaders.Layers
{
    public class GetMoreCreditsScreenLayer : CCLayerColorExt
    {
        int _creditsRequired;
        int _selectedEnemy;
        int _selectedWeapon;
        int _caliberSizeSelected;
        int _firespeedSelected;
        int _magazineSizeSelected;
        int _livesSelected;

        int _imgPlayerCreditsXCoord;
#if __IOS__
        //NSTimer fakeTimer;

#endif

        //CCScheduler m_pScheduler;
        //CCActionManager m_pActionManager;

        CCSprite[] imgPlayerCreditsLabel;
        CCSpriteButton _btn2000Hiden;
        CCSpriteButton _btn2000;
        CCSpriteButton _btn4000;
        CCSprite _tenTimesText;

        CCSprite _timeToNextAdsImg;
        CCSprite _h1;
        CCSprite _h2;
        CCSprite _m1;
        CCSprite _m2;
        CCSprite _s1;
        CCSprite _s2;
        double _timeToNextAds = 0;

        public GetMoreCreditsScreenLayer() : this(0, -1, -1, -1, -1, -1, -1)
        { }

        public GetMoreCreditsScreenLayer(int creditsRequired, int selectedEnemy, int selectedWeapon) : this(creditsRequired, selectedEnemy, selectedWeapon, -1, -1, -1, -1)
        { }

        public GetMoreCreditsScreenLayer(int creditsRequired, int selectedEnemy, int selectedWeapon, int caliberSizeSelected, int fireSpeedSelected, int magazineSizeSelected, int livesSelected)
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();

            this._creditsRequired = creditsRequired;
            this._selectedEnemy = selectedEnemy;
            this._selectedWeapon = selectedWeapon;
            this._caliberSizeSelected = caliberSizeSelected;
            this._firespeedSelected = fireSpeedSelected;
            this._magazineSizeSelected = magazineSizeSelected;
            this._livesSelected = livesSelected;

            this.SetBackground("UI/background.png");

            CCSpriteButton btnBack = this.AddButton(2, 578, "UI/back-button-untapped.png", "UI/back-button-tapped.png", 100, BUTTON_TYPE.Back);
            btnBack.OnClick += BtnBack_OnClick;
            Shared.GameDelegate.OnBackButton += BtnBack_OnClick;

            this.AddImage(307, 560, "UI/Get-more-credits-title-text.png");

            CCSpriteButton btn1m = this.AddButton(0, 475, "UI/Get-more-credits-get-1000000-credits-button-untapped.png", "UI/Get-more-credits-get-1000000-credits-button-tapped.png");
            btn1m.OnClick += btn1m_OnClick;
            btn1m.ButtonType = BUTTON_TYPE.CreditPurchase;

            this.AddImage(517, 470, "UI/Get-more-credits-get-7_99-USD.png");

            CCSpriteButton btn300k = this.AddButton(0, 381, "UI/Get-more-credits-get-300000-credits-button-untapped.png", "UI/Get-more-credits-get-300000-credits-button-tapped.png");
            btn300k.OnClick += btn300k_OnClick;
            btn300k.ButtonType = BUTTON_TYPE.CreditPurchase;

            this.AddImage(517, 379, "UI/Get-more-credits-get-4_99-USD.png");

            CCSpriteButton btn100k = this.AddButton(0, 290, "UI/Get-more-credits-get-100000-credits-button-untapped.png", "UI/Get-more-credits-get-100000-credits-button-tapped.png");
            btn100k.OnClick += Btn100k_OnClick;
            btn100k.ButtonType = BUTTON_TYPE.CreditPurchase;

            this.AddImage(517, 291, "UI/Get-more-credits-get-1_99-USD.png");

            //------------ Prabhjot -----------//

            /*if(Player.Instance.FacebookLikeUsed)
            {
                _btn4000 = this.AddButton(0, 199, "UI/Get-more-credits-get-4000-credits-button-tapped.png", "UI/Get-more-credits-get-4000-credits-button-tapped.png");
            }
            else
            {
                _btn4000 = this.AddButton(0, 199, "UI/Get-more-credits-get-4000-credits-button-untapped.png", "UI/Get-more-credits-get-4000-credits-button-tapped.png");
            }*/

            _btn4000 = this.AddButton(0, 199, "UI/Get-more-credits-get-4000-credits-button-untapped.png", "UI/Get-more-credits-get-4000-credits-button-tapped.png");


            _btn4000.OnClick += btn4000_OnClick;
            _btn4000.ButtonType = BUTTON_TYPE.Silent;

            this.AddImage(437, 199, "UI/Get-more-credits-like-us-on-facebook-text.png");

            _tenTimesText = AddImage(437, 83, "UI/Get-more-credits-watch-advertisement.png");

            // disable watch ad button
            if (Player.Instance.LastAdWatchDay.Date != DateTime.Now.Date)
            {
                Player.Instance.LastAdWatchDay = DateTime.Now;
                Player.Instance.LastAdWatchTime = Convert.ToDateTime("1900-01-01");
                Player.Instance.LastAdWatchDayCount = 0;
            }

            DateTime LastAdWatchTime = Player.Instance.LastAdWatchTime;
            int LastAdWatchDayCount = Player.Instance.LastAdWatchDayCount;

            _btn2000Hiden = this.AddButton(0, 105, "UI/Get-more-credits-get-2000-credits-button-tapped.png", "UI/Get-more-credits-get-2000-credits-button-tapped.png");
            _btn2000Hiden.OnClick += btn2000Hiden_OnClick;
            _btn2000Hiden.ButtonType = BUTTON_TYPE.Silent;
            _btn2000Hiden.Visible = false;

            if (LastAdWatchDayCount >= 10)  // Prabhjot 10
            {
                _btn2000 = this.AddButton(0, 105, "UI/Get-more-credits-get-2000-credits-button-tapped.png", "UI/Get-more-credits-get-2000-credits-button-untapped.png");
                _btn2000.Enabled = false;
                _btn2000.OnClick += btn2000_OnClick;
                _btn2000.ButtonType = BUTTON_TYPE.Silent;
                var timeToNewDay = DateTime.Now.AddDays(1).Date - DateTime.Now;
                DisableBtnOnTime(timeToNewDay.TotalSeconds);
            }
            else
            {
                _btn2000 = this.AddButton(0, 105, "UI/Get-more-credits-get-2000-credits-button-untapped.png", "UI/Get-more-credits-get-2000-credits-button-tapped.png");
                _btn2000.OnClick += btn2000_OnClick;
                _btn2000.ButtonType = BUTTON_TYPE.Silent;

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
                    var backgroundTask = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
                    {
                        DisableBtnOnTime(timeVal);
                    }));
                    backgroundTask.Start();
                }
            }

            Children.Add(_tenTimesText);

            if (creditsRequired != 0)
            {
                this.AddImage(0, 0, "UI/Get-more-credits-credits-needed-for-your-text.png");
                this.AddImageLabel(305, 5, creditsRequired.ToString(), 77);

                this.AddImage(544, 0, "UI/Get-more-credits-your-currently-available-credits-text.png");
                _imgPlayerCreditsXCoord = 850;
            }
            else
            {
                this.AddImage(5, 0, "UI/Get-more-credits-main-screen-your-currently-available-credits.png");
                _imgPlayerCreditsXCoord = 855;
            }

            refreshPlayerCreditsLabel();

            AdMobManager.ClearEvents();
            PurchaseManager.ClearEvents();

            AdMobManager.OnInterstitialAdOpened += AdMobManager_OnInterstitialAdOpened;
            AdMobManager.OnInterstitialAdClosed += AdMobManager_OnInterstitialAdClosed;
            AdMobManager.OnInterstitialAdFailedToLoad += AdMobManager_OnInterstitialAdFailedToLoad;
            PurchaseManager.OnPurchaseFinished += PurchaseManager_OnPurchaseFinished;



            if (!NetworkConnectionManager.IsInternetConnectionAvailable())
            {
                Console.WriteLine("No Net");

                _btn2000 = this.AddButton(0, 105, "UI/Get-more-credits-get-2000-credits-button-tapped.png", "UI/Get-more-credits-get-2000-credits-button-untapped.png");
                _btn2000.Enabled = false;
                _btn4000 = this.AddButton(0, 199, "UI/Get-more-credits-get-4000-credits-button-tapped.png", "UI/Get-more-credits-get-4000-credits-button-tapped.png");
                _btn4000.Enabled = false;
                return;
            }


        }

        private void refreshPlayerCreditsLabel(float dt = 0.00f)
        {
            if (imgPlayerCreditsLabel != null)
            {
                foreach (CCSprite img in imgPlayerCreditsLabel) img.RemoveFromParent();
            }

            imgPlayerCreditsLabel = this.AddImageLabel(_imgPlayerCreditsXCoord, 0, Player.Instance.Credits.ToString(), 77);
        }

        private void btn4000_OnClick(object sender, EventArgs e)
        {

            if (!NetworkConnectionManager.IsInternetConnectionAvailable())
            {
                _btn4000 = this.AddButton(0, 199, "UI/Get-more-credits-get-4000-credits-button-tapped.png", "UI/Get-more-credits-get-4000-credits-button-tapped.png");
                _btn4000.Enabled = false;
                return;
            }

            if (Player.Instance.FacebookLikeUsed)
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
                //return;
            }

            GameEnvironment.OpenWebPage("http://www.facebook.com/looneyinvaders");

            _btn4000 = this.AddButton(0, 199, "UI/Get-more-credits-get-4000-credits-button-tapped.png", "UI/Get-more-credits-get-4000-credits-button-tapped.png");
            Player.Instance.Credits += 4000;
            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CREDITPURCHASE);
            Player.Instance.FacebookLikeUsed = true;
            this.ScheduleOnce(refreshPlayerCreditsLabel, 0.01f);
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
                this.TransitionToLayerCartoonStyle(new MainScreenLayer());
            }
            else if (_caliberSizeSelected == -1)
            {
                this.TransitionToLayer(new WeaponPickerLayer(_selectedEnemy, _selectedWeapon));
            }
            else
            {
                this.TransitionToLayer(new WeaponUpgradeScreenLayer(_selectedEnemy, _selectedWeapon, _caliberSizeSelected, _firespeedSelected, _magazineSizeSelected, _livesSelected));
            }
        }

        private async void btn2000Hiden_OnClick(object sender, EventArgs e)
        {
            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
        }

        private async void btn2000_OnClick(object sender, EventArgs e)
        {
            //Crashes.GenerateTestCrash();

            if (!NetworkConnectionManager.IsInternetConnectionAvailable())
            {
                _btn2000 = this.AddButton(0, 105, "UI/Get-more-credits-get-2000-credits-button-tapped.png", "UI/Get-more-credits-get-2000-credits-button-untapped.png");
                _btn2000.Enabled = false;
                return;
            }

            _btn2000Hiden.Visible = true;
            _btn2000.Visible = false;

            Console.WriteLine("Last watch count before: " + Player.Instance.LastAdWatchDayCount.ToString());

            if (Player.Instance.LastAdWatchDay.Date != DateTime.Now.Date)
            {
                Player.Instance.LastAdWatchDay = DateTime.Now;
                Player.Instance.LastAdWatchTime = Convert.ToDateTime("1900-01-01");
                Player.Instance.LastAdWatchDayCount = 0;
            }

            DateTime LastAdWatchTime = Player.Instance.LastAdWatchTime;
            int LastAdWatchDayCount = Player.Instance.LastAdWatchDayCount;

            Console.WriteLine("Total seconds passed: " + (DateTime.Now - LastAdWatchTime).TotalSeconds.ToString());

            //if ((DateTime.Now - LastAdWatchTime).TotalSeconds < 5)
            //{
            //  GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
            //  Console.WriteLine("5 seconds must pass between ads, passed " + (DateTime.Now - LastAdWatchTime).Seconds.ToString());
            //  return;
            //}

            if (LastAdWatchDayCount >= 10)  // Prabhjot 10
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
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

            ScheduleOnce(runAdInDelay, 0.16f);

            //_s1 = AddImage(843, 83, $"UI/number_57_0.png");
            //_s2 = AddImage(870, 83, $"UI/number_57_0.png");


        }

        private void runAdInDelay(float obj)
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


            var backgroundTask = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
            {
                Schedule(DisableBtn, 0.16f);
            }));
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


                this.RemoveChild(_h1);
                this.RemoveChild(_h2);
                this.RemoveChild(_m1);
                this.RemoveChild(_m2);
                this.RemoveChild(_s1);
                this.RemoveChild(_s2);


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

            char h1 = '0';
            char h2 = '0';
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

            char m1 = '0';
            char m2 = '0';
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

            char s1 = '0';
            char s2 = '0';
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


                var backgroundTask = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
                {
                    Unschedule(DisableBtn);
                }));
                backgroundTask.Start();
            }
        }

        private void AdMobManager_OnInterstitialAdOpened(object sender, EventArgs e)
        {
            this.ScheduleOnce(interstitialOpened, 0.01f);

        }

        private void AdMobManager_OnInterstitialAdClosed(object sender, EventArgs e)
        {

        }

        private void interstitialOpened(float dt = 0.00f)
        {
            Player.Instance.LastAdWatchTime = DateTime.Now;

            Player.Instance.LastAdWatchDayCount = Player.Instance.LastAdWatchDayCount + 1;
            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CREDITPURCHASE);

            if (Player.Instance.LastAdWatchDayCount >= 10) // Prabhjot 10
            {
                this.Children.Remove(this._btn2000);
                _btn2000 = this.AddButton(0, 105, "UI/Get-more-credits-get-2000-credits-button-tapped.png", "UI/Get-more-credits-get-2000-credits-button-untapped.png");
                _btn2000.Enabled = false;
                _btn2000.OnClick += btn2000_OnClick;
                _btn2000.ButtonType = BUTTON_TYPE.Silent;
                var timeToNewDay = DateTime.Now.AddDays(1).Date - DateTime.Now;
                DisableBtnOnTime(timeToNewDay.TotalSeconds);

            }

            Player.Instance.Credits += 2000;
            Console.WriteLine("Last watch count after: " + Player.Instance.LastAdWatchDayCount.ToString());
            refreshPlayerCreditsLabel();
        }

        private void AdMobManager_OnInterstitialAdFailedToLoad(object sender, EventArgs e)
        { }

        private void btn1m_OnClick(object sender, EventArgs e)
        {
            PurchaseManager.Purchase("credits_1_mil");
            this.Enabled = false;
        }

        private void btn300k_OnClick(object sender, EventArgs e)
        {
            PurchaseManager.Purchase("credits_300_k");
            this.Enabled = false;
        }

        private void Btn100k_OnClick(object sender, EventArgs e)
        {
            PurchaseManager.Purchase("credits_100_k");
            this.Enabled = false;
        }

        private void PurchaseManager_OnPurchaseFinished(object sender, EventArgs e)
        {
            this.Enabled = true;
            this.ScheduleOnce(refreshPlayerCreditsLabel, 0.01f);
        }
    }
}