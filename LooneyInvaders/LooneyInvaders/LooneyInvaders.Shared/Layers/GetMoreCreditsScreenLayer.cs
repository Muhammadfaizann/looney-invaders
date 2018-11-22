using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;
using System.Threading.Tasks;

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

		CCSprite[] imgPlayerCreditsLabel;
		CCSpriteButton _btn2000Hiden;
		CCSpriteButton _btn2000;
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

			CCSpriteButton btn4000 = this.AddButton(0, 199, "UI/Get-more-credits-get-4000-credits-button-untapped.png", "UI/Get-more-credits-get-4000-credits-button-tapped.png");
			btn4000.OnClick += btn4000_OnClick;
			btn4000.ButtonType = BUTTON_TYPE.Silent;

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

			if (LastAdWatchDayCount >= 10)
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
					DisableBtnOnTime(timeVal);
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
			if (Player.Instance.FacebookLikeUsed)
			{
				GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
				return;
			}

			GameEnvironment.OpenWebPage("http://www.facebook.com/looneyinvaders");

			Player.Instance.Credits += 4000;
			GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CREDITPURCHASE);
			Player.Instance.FacebookLikeUsed = true;
			this.ScheduleOnce(refreshPlayerCreditsLabel, 0.01f);
		}

		private void BtnBack_OnClick(object sender, EventArgs e)
		{
			Shared.GameDelegate.ClearOnBackButtonEvent();

			Unschedule(DisableBtn);

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

			if ((DateTime.Now - LastAdWatchTime).TotalSeconds < 10)
			{
				GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
				Console.WriteLine("10 seconds must pass between ads, passed " + (DateTime.Now - LastAdWatchTime).Seconds.ToString());
				return;
			}

			if (LastAdWatchDayCount >= 10)
			{
				GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
				Console.WriteLine("limited to 10 ads a day");

				var timeToNewDay = DateTime.Now.AddDays(1).Date - DateTime.Now;
				DisableBtnOnTime(timeToNewDay.TotalSeconds);
				return;
			}

			AdMobManager.ShowInterstitial();
   
			DisableBtnOnTime(10);
		}

		private void DisableBtnOnTime(double sec)
		{
			_btn2000.Enabled = false;

            _tenTimesText.Visible = false;

			_timeToNextAdsImg = AddImage(437, 83, "UI/next-ad-available-in-text.png");

			_timeToNextAds = sec;
			Schedule(DisableBtn, 0.16f);
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
			this.RemoveChild(_h1);
			this.RemoveChild(_h2);
			this.RemoveChild(_m1);
			this.RemoveChild(_m2);
			this.RemoveChild(_s1);
			this.RemoveChild(_s2);

			if(Settings.Instance.TimeWhenPageAdsLeaved != default(DateTime))
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

			if (_timeToNextAds < 0)
			{
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
				Unschedule(DisableBtn);
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

            if (Player.Instance.LastAdWatchDayCount >= 10)
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
        {}

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