using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AppodealXamariniOS;
using CC.Mobile.Purchases;
using CoreMotion;
using Foundation;
using UIKit;
using LooneyInvaders.iOS.Services;
using LooneyInvaders.iOS.Services.Ads;
using LooneyInvaders.Model;
using LooneyInvaders.Services.App42;
using LooneyInvaders.Shared;

namespace LooneyInvaders.iOS
{
    public partial class ViewController : UIViewController, IApp42ServiceInitialization
    {
        private readonly nfloat _adBannerYCoord = -1;

        private CMMotionManager _motionManager;
        private bool _adOnWindow;

        private readonly InterstitialDelegate interstitialDelegate = new InterstitialDelegate();

        private IPurchaseService _svc;
        //string _googlePlayGamesClientId = "647563278989-2c9afc4img7s0t38khukl5ilb8i6k4bt.apps.googleusercontent.com";

        public ViewController(IntPtr handle) : base(handle) { }

        public void CallInitOnApp42ServiceBuilder() => App42ServiceBuilder.Init(GameConstants.App42.ApiKey, GameConstants.App42.SecretKey, 300);

        private bool ChangeUsername(string username) => App42.StorageService.Instance.ChangeUsername(username);
        private bool CheckIsUsernameFree(string username) => App42.StorageService.Instance.CheckIsUsernameFree(username);
        private Task<bool> UsernameGUIDInsertHandler(string guid) => App42.StorageService.Instance.UsernameGUIDInsertHandler(guid);
        private void RefreshLeaderboards(Leaderboard leaderboard) => App42.ScoreBoardService.Instance.RefreshLeaderboards(leaderboard);

        private void UpdateGameViewState(bool isPaused) => BeginInvokeOnMainThread(() =>
        {
            GameView = GameDelegate.GameView;
            try
            {
                GameView.Paused = isPaused;
            }
            catch (Exception ex)
            {
                var mess = ex.Message;
                Debug.WriteLine($"FaultOn_{nameof(UpdateGameViewState)}: {mess}");
            }
        });

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (GameView == null)
            {
                return;
            }
            _motionManager = new CMMotionManager();
            _motionManager.StartDeviceMotionUpdates();

            GameDelegate.FacebookService = new FacebookService();
            GameDelegate.GetGyro = GetGyro;
            GameDelegate.UpdateGameView = UpdateGameViewState;

            CallInitOnApp42ServiceBuilder();

            GameView.MultipleTouchEnabled = true;
            GameView.BackgroundColor = UIColor.Black;

            AdManager.ShowBannerTopHandler = AddBannerToWindowTop;
            AdManager.ShowBannerBottomHandler = AddBannerToWindowBottom;
            AdManager.HideBannerHandler = HideBanner;
            AdManager.LoadInterstitialHandler = LoadInterstitial;
            AdManager.ShowInterstitialHandler = ShowInterstitial;
            Appodeal.SetLogLevel(APDLogLevel.Verbose);
            Appodeal.SetTestingEnabled(false);
            Appodeal.SetBannerAnimationEnabled(true);
            Appodeal.SetBannerBackgroundVisible(false);
            Appodeal.SetSmartBannersEnabled(true);
            Appodeal.SetAutocache(false, AppDelegate.RequiredAdTypes);
            Appodeal.SetAutocache(true, AppodealAdType.Banner);
            AppodealAdsHelper.LoadingPauseMilliseconds = 1500;
            Appodeal.SetInterstitialDelegate(interstitialDelegate);
            Appodeal.SetBannerDelegate(new BannerDelegate());
            Appodeal.CacheAd(AppDelegate.RequiredAdTypes);

            _svc = new PurchaseService();
            Task.Run(async () => await _svc.Init())
                .ContinueWith(task =>
                {
                    PurchaseManager.PurchaseHandler = PurchaseProduct;
                })
                .ConfigureAwait(false);

            VibrationManager.VibrationHandler = Vibrate;

            LeaderboardManager.RefreshLeaderboardsHandler = RefreshLeaderboards;
            // social network sharing
            SocialNetworkShareManager.ShareOnSocialNetwork = ShareOnSocialNetworkHandler;

            // user management
            UserManager.UsernameGuidInsertHandler = UsernameGUIDInsertHandler;
            UserManager.CheckIsUsernameFreeHandler = CheckIsUsernameFree;
            UserManager.ChangeUsernameHandler = ChangeUsername;

            Task.Run(() => UserManager.GenerateGuid()).ConfigureAwait(false);

            // Set loading event to be called once game view is fully initialised
            GameView.ViewCreated += GameDelegate.LoadGame;
        }

        public override void DidReceiveMemoryWarning()
        {
            Debug.WriteLine($"||MEMORY||total: {NSProcessInfo.ProcessInfo.PhysicalMemory}|current_process :{Process.GetCurrentProcess().WorkingSet64}");

            base.DidReceiveMemoryWarning();
        }

        public override async void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            try
            {
                GameDelegate.PauseMusic();

                await _svc.Pause();

                GameDelegate.StopGame();
            }
            catch (Exception ex)
            {
                var mess = ex.Message;
            }
        }

        public override async void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            try
            {
                GameDelegate.ResumeMusic();

                await _svc.Resume();

                GameDelegate.LoadGame(null, null);
            }
            catch (Exception ex)
            {
                var mess = ex.Message;
            }
        }

        private void Vibrate(object sender, EventArgs e)
        {
            AudioToolbox.SystemSound.Vibrate.PlaySystemSound();
        }

        private float RadiansToDegrees(double radians) => (float)(180 / Math.PI * radians);

        private void GetGyro(out float yaw, out float tilt, out float pitch)
        {
            var fullPitch = RadiansToDegrees(_motionManager.DeviceMotion.Attitude.Pitch);

            yaw = RadiansToDegrees(_motionManager.DeviceMotion.Attitude.Yaw);
            tilt = RadiansToDegrees(_motionManager.DeviceMotion.Attitude.Roll);
            pitch = (float)Math.Round(fullPitch, 3);

            if (InterfaceOrientation == UIInterfaceOrientation.LandscapeRight)
            {
                pitch *= -1;
            }
        }
    }
}