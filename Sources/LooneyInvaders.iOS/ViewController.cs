using System;
using System.Threading.Tasks;
using CC.Mobile.Purchases;
using CoreGraphics;
using CoreMotion;
using Foundation;
using Google.MobileAds;
using UIKit;
using LooneyInvaders.Model;
using LooneyInvaders.Services.App42;
using LooneyInvaders.Shared;

namespace LooneyInvaders.iOS
{
    public partial class ViewController : UIViewController, IApp42ServiceInitialization
    {
        private CMMotionManager _motionManager;
        private BannerView _adViewWindow;
        private bool _adOnWindow;
        private readonly nfloat _adBannerYCoord = -1;
        private Interstitial _intAd;

        private IPurchaseService _svc;
        //string _googlePlayGamesClientId = "647563278989-2c9afc4img7s0t38khukl5ilb8i6k4bt.apps.googleusercontent.com";

        public ViewController(IntPtr handle) : base(handle)
        { }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (GameView == null)
                return;

            _motionManager = new CMMotionManager();
            _motionManager.StartDeviceMotionUpdates();

            InitScoreBoardService();
            InitStorageService();

            //------------ Prabhjot -----------//
            GameDelegate.GetGyro = GetGyro;
            GameDelegate.UpdateGameView = UpdateGameViewState;

            GameView.MultipleTouchEnabled = true;

            AdMobManager.ShowBannerTopHandler = AddBannerToWindowTop;
            AdMobManager.ShowBannerBottomHandler = AddBannerToWindowBottom;
            AdMobManager.HideBannerHandler = HideBanner;
            AdMobManager.LoadInterstitialHandler = LoadInterstitial;
            AdMobManager.ShowInterstitialHandler = ShowInterstitial;

            GameView.BackgroundColor = UIColor.Black;

            LoadInterstitial();

            _svc = new PurchaseService();
            await _svc.Init();

            PurchaseManager.PurchaseHandler = PurchaseProduct;

            VibrationManager.VibrationHandler = Vibrate;

            //SignIn.SharedInstance.UIDelegate = this;
            //Google.Play.GameServices.Manager.SharedInstance.SignIn(googlePlayGamesClientID, false);

            LeaderboardManager.SubmitScoreHandler = SubmitScoreAsync;
            LeaderboardManager.RefreshLeaderboardsHandler = RefreshLeaderboards;

            // social network sharing
            SocialNetworkShareManager.ShareOnSocialNetwork = ShareOnSocialNetworkHandler;

            // user management
            UserManager.UsernameGuidInsertHandler = UsernameGUIDInsertHandler;
            UserManager.CheckIsUsernameFreeHandler = CheckIsUsernameFree;
            UserManager.ChangeUsernameHandler = ChangeUsername;

            if (!UserManager.IsUserGuidSet) UserManager.GenerateGuid();

            // Set loading event to be called once game view is fully initialised
            GameView.ViewCreated += GameDelegate.LoadGame;
        }

        public void InitScoreBoardService()
        {
            App42.ScoreBoardService.Init(GameConstants.App42.ApiKey, GameConstants.App42.SecretKey, 400);
        }

        public void InitStorageService()
        {
            App42.StorageService.Init(GameConstants.App42.ApiKey, GameConstants.App42.SecretKey);
        }

        private bool UsernameGUIDInsertHandler(string guid)
        {
            return App42.StorageService.Instance.UsernameGUIDInsertHandler(guid);
        }

        private bool CheckIsUsernameFree(string username)
        {
            return App42.StorageService.Instance.CheckIsUsernameFree(username);
        }

        private bool ChangeUsername(string username)
        {
            return App42.StorageService.Instance.ChangeUsername(username);
        }

        private float RadiansToDegrees(double radians)
        {
            return (float)(180 / Math.PI * radians);
        }


        private void GetGyro(out float yaw, out float tilt, out float pitch)
        {
            var fullPitch = RadiansToDegrees(_motionManager.DeviceMotion.Attitude.Pitch);

            yaw = RadiansToDegrees(_motionManager.DeviceMotion.Attitude.Yaw);
            tilt = RadiansToDegrees(_motionManager.DeviceMotion.Attitude.Roll);
            pitch = (float)Math.Round(fullPitch, 3);

            if (InterfaceOrientation == UIInterfaceOrientation.LandscapeRight) pitch = pitch * -1;
        }

        public override void DidReceiveMemoryWarning()
        {
#if DEBUG
            Console.WriteLine($"||MEMORY||total: {Foundation.NSProcessInfo.ProcessInfo.PhysicalMemory}|current_process :{System.Diagnostics.Process.GetCurrentProcess().WorkingSet64}");
#endif
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

        public void UpdateGameViewState()
        {
            UpdateGameViewStateUIThread();
        }

        private void UpdateGameViewStateUIThread()
        {
            BeginInvokeOnMainThread(() =>
            {
                //GameView.Paused = false;
                GameView.MobilePlatformUpdatePaused();
            });
        }

        private void AddBannerToWindowTop()
        {
            BeginInvokeOnMainThread(() => { AddBannerToWindow(0); });
        }

        private void AddBannerToWindowBottom()
        {
            BeginInvokeOnMainThread(() => { AddBannerToWindow(View.Bounds.Size.Height - 50); });
        }

        private void HideBanner()
        {
            BeginInvokeOnMainThread(() => { RemoveBannerFromWindow(); });
        }

        private void AddBannerToWindow(nfloat yCoord)
        {
            if (_adViewWindow != null && yCoord == _adBannerYCoord) return;

            if (_adViewWindow != null) RemoveBannerFromWindow();

            if (_adViewWindow == null)
            {
                // Setup your GADBannerView, review AdSizeCons class for more Ad sizes. 
                _adViewWindow = new BannerView(AdSizeCons.Banner, new CGPoint((View.Bounds.Size.Width - 320) / 2, yCoord));
                _adViewWindow.AdUnitID = "ca-app-pub-5373308786713201/3891909370";
                _adViewWindow.RootViewController = this;

                // Wire AdReceived event to know when the Ad is ready to be displayed
                _adViewWindow.AdReceived += AdViewWindow_AdReceived;
                _adViewWindow.ReceiveAdFailed += AdViewWindow_ReceiveAdFailed;
            }

            var request = Request.GetDefaultRequest();
#if DEBUG
            //request.TestDevices = new string[] { "91081e0a39a84d0f81f550efec64ec47" };
#endif

            _adViewWindow.LoadRequest(request);
        }

        private void RemoveBannerFromWindow()
        {
            if (_adViewWindow != null)
            {
                if (_adOnWindow)
                {
                    _adViewWindow.RemoveFromSuperview();
                }
                _adOnWindow = false;

                // You need to explicitly Dispose BannerView when you dont need it anymore
                // to avoid crashes if pending request are in progress
                _adViewWindow.Dispose();
                _adViewWindow = null;
            }
        }

        private void AdViewWindow_AdReceived(object sender, EventArgs e)
        {
            if (!_adOnWindow)
            {
                View.AddSubview(_adViewWindow);
                _adOnWindow = true;
            }
        }

        private void AdViewWindow_ReceiveAdFailed(object sender, BannerViewErrorEventArgs e)
        {
            Console.WriteLine("Ad receive failed: " + e.Error.DebugDescription);
        }

        public void ShowInterstitial()
        {
            BeginInvokeOnMainThread(() =>
            {
                if (_intAd.IsReady && !Settings.IsFromGameScreen)
                    _intAd.PresentFromRootViewController(this);
            });
        }

        public void LoadInterstitial()
        {
            _intAd = new Interstitial("ca-app-pub-5373308786713201/2524424172");
            _intAd.Delegate = new InterstitialDelegate();
            _intAd.ReceiveAdFailed += IntAd_ReceiveAdFailed;
            _intAd.ScreenDismissed += IntAd_ScreenDismissed;
            _intAd.WillPresentScreen += IntAd_WillPresentScreen;

            var request = Request.GetDefaultRequest();
#if DEBUG
            request.TestDevices = new string[] { "e62a2b8cda8eb947dcd2033062559b9f" };
#endif
            _intAd.LoadRequest(request);
        }

        private void IntAd_ReceiveAdFailed(object sender, InterstitialDidFailToReceiveAdWithErrorEventArgs e)
        {
            Console.WriteLine("Interstitial ad: receive ad failed");

            AdMobManager.InterstitialAdFailedToLoad();
        }

        private void IntAd_WillPresentScreen(object sender, EventArgs e)
        {
            Console.WriteLine("Interstitial ad: will present screen");

            AdMobManager.InterstitialAdOpened();
        }

        private void IntAd_ScreenDismissed(object sender, EventArgs e)
        {
            Console.WriteLine("Interstitial ad: screen dismissed");

            AdMobManager.InterstitialAdClosed();

            _intAd.Dispose();
            _intAd = null;

            _intAd = new Interstitial("ca-app-pub-5373308786713201/2524424172");
            _intAd.Delegate = new InterstitialDelegate();
            _intAd.ReceiveAdFailed += IntAd_ReceiveAdFailed;
            _intAd.ScreenDismissed += IntAd_ScreenDismissed;
            _intAd.WillPresentScreen += IntAd_WillPresentScreen;

            var request = Request.GetDefaultRequest();
#if DEBUG
            request.TestDevices = new string[] { "e62a2b8cda8eb947dcd2033062559b9f" };
#endif
            _intAd.LoadRequest(request);
        }

        private async Task MakePurchase(IProduct product)
        {
            try
            {
                var purchase = await _svc.Purchase(product);
                if (purchase.Status == TransactionStatus.Purchased)
                {
                    //new UIAlertView("Success", $"Just Purchased {product}", null, "OK").Show();
                    if (product.ProductId == "credits_1_mil") Player.Instance.Credits += 1000000;
                    else if (product.ProductId == "credits_300_k") Player.Instance.Credits += 300000;
                    else if (product.ProductId == "credits_100_k") Player.Instance.Credits += 100000;
                    else if (product.ProductId == "ads_off") Settings.Instance.Advertisements = false;

                    PurchaseManager.FireOnPurchaseFinished();
                }
                else
                {
                    Console.WriteLine("Failed Purchase: Cannot Purchase " + product.ProductId);
                    PurchaseManager.FireOnPurchaseFinished();
                }
            }
            catch (PurchaseError)
            {
                Console.WriteLine("Error with {product}:{ex.Message}");
                PurchaseManager.FireOnPurchaseFinished();
            }
        }

        private async Task<bool> PurchaseProduct(string productId)
        {
            await MakePurchase(new Product(productId))
                .ConfigureAwait(false);

            return true;
        }

        private void Vibrate(object sender, EventArgs e)
        {
            AudioToolbox.SystemSound.Vibrate.PlaySystemSound();
        }

        private async Task SubmitScoreAsync(double score, double accuracy, double fastestTime, double levelsCompleted)
        {
            await App42.ScoreBoardService.Instance.SubmitScore(score, accuracy, fastestTime, levelsCompleted);
        }

        private void RefreshLeaderboards(Leaderboard leaderboard)
        {
            App42.ScoreBoardService.Instance.RefreshLeaderboards(leaderboard);
        }

        public void ShareOnSocialNetworkHandler(string network, System.IO.Stream stream)
        {
            if (stream == null)
            {
                Console.WriteLine("stream is null");
                return;
            }

            var ms = (System.IO.MemoryStream)stream;

            var data = NSData.FromArray(ms.ToArray());
            var img = UIImage.LoadFromData(data);

            Console.WriteLine($"IMAGE width: {img.Size.Width} height: {img.Size.Height}");

            BeginInvokeOnMainThread(() => { ShareOnSocialNetworkIos(network, img); });
        }

        public void ShareOnSocialNetworkIos(string network, UIImage img)
        {
            var activityVc = new UIActivityViewController(new NSObject[] { img }, null);

            /*
            if (network == "facebook")
            {
                activityVC.ExcludedActivityTypes = new NSString[]
                    {
                        UIActivityType.AddToReadingList,
                        UIActivityType.AirDrop,
                        UIActivityType.AssignToContact,
                        UIActivityType.CopyToPasteboard,
                        UIActivityType.Mail,
                        UIActivityType.Message,
                        UIActivityType.OpenInIBooks,                
                        UIActivityType.PostToFlickr,
                        UIActivityType.PostToTencentWeibo,
                        UIActivityType.PostToTwitter,
                        UIActivityType.PostToVimeo,
                        UIActivityType.PostToWeibo,
                        UIActivityType.Print,
                        UIActivityType.SaveToCameraRoll
                    };
            }
            else if(network == "twitter")
            {
                activityVC.ExcludedActivityTypes = new NSString[]
                    {
                        UIActivityType.AddToReadingList,
                        UIActivityType.AirDrop,
                        UIActivityType.AssignToContact,
                        UIActivityType.CopyToPasteboard,
                        UIActivityType.Mail,
                        UIActivityType.Message,
                        UIActivityType.OpenInIBooks,
                        UIActivityType.PostToFacebook,
                        UIActivityType.PostToFlickr,
                        UIActivityType.PostToTencentWeibo,                
                        UIActivityType.PostToVimeo,
                        UIActivityType.PostToWeibo,
                        UIActivityType.Print,
                        UIActivityType.SaveToCameraRoll
                    };
            }
            */

            if (activityVc.PopoverPresentationController != null)
                activityVc.PopoverPresentationController.SourceView = View;

            PresentViewController(activityVc, true, null);
        }
    }
}