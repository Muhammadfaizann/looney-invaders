using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foundation;
using UIKit;
using CoreMotion;
using CocosSharp;
using LooneyInvaders.Shared;
using CoreGraphics;
using Google.MobileAds;
using CC.Mobile.Purchases;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.game;
using com.shephertz.app42.paas.sdk.csharp.storage;
using LooneyInvaders.Model;

namespace LooneyInvaders.iOS
{
    public partial class ViewController : UIViewController
    {
        private CMMotionManager _motionManager;
        private BannerView _adViewWindow;
        private bool _adOnWindow;
        private readonly nfloat _adBannerYCoord = -1;
        private Interstitial _intAd;

        private IPurchaseService _svc;
        //string _googlePlayGamesClientId = "647563278989-2c9afc4img7s0t38khukl5ilb8i6k4bt.apps.googleusercontent.com";

        public ViewController(IntPtr handle)
            : base(handle)
        { }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (GameView != null)
            {
                _motionManager = new CMMotionManager();
                _motionManager.StartDeviceMotionUpdates();


                //------------ Prabhjot -----------//
                GameDelegate.GetGyro = GetGyro;


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

                LeaderboardManager.SubmitScoreHandler = SubmitScore;
                LeaderboardManager.RefreshLeaderboardsHandler = RefreshLeaderboardsAsync;

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
        }

        private bool UsernameGUIDInsertHandler(string guid)
        {
            Console.WriteLine("GUID insert " + guid);

            const string dbName = "users";
            const string collectionName = "users";
            var json = "{\"name\":\"guest\",\"guid\":\"" + guid + "\"}";

            App42API.Initialize("a0aa82036ff74c83b602de87b68a396cf724df6786ae9caa260e1175a7c8ce26", "14be26afb208c96b1cf16b3b197a988f451bfcf2e0ef2bc6c2dbd6f494f07382");
            var storageService = App42API.BuildStorageService();

            var storage = storageService.InsertJSONDocument(dbName, collectionName, json);
            var jsonDocList = storage.GetJsonDocList();

            var id = jsonDocList[0].GetDocId();
            var playerName = "player_" + id.Substring(id.Length - 9, 8);

            UserManager.UserGuid = guid;
            Player.Instance.Name = playerName;

            json = "{\"name\":\"" + playerName.ToUpper() + "\",\"guid\":\"" + guid + "\"}";
            storageService.UpdateDocumentByDocId(dbName, collectionName, id, json);

            return true;
        }

        private bool CheckIsUsernameFree(string username)
        {
            Console.WriteLine("Check is username free " + username);

            const string dbName = "users";
            const string collectionName = "users";

            App42API.Initialize("a0aa82036ff74c83b602de87b68a396cf724df6786ae9caa260e1175a7c8ce26", "14be26afb208c96b1cf16b3b197a988f451bfcf2e0ef2bc6c2dbd6f494f07382");
            var storageService = App42API.BuildStorageService();

            try
            {
                var storage = storageService.FindDocumentByKeyValue(dbName, collectionName, "name", username.ToUpper());
                var jsonDocList = storage.GetJsonDocList();

                if (jsonDocList.Count == 0) return true; // no user
                if (jsonDocList[0].GetJsonDoc().Contains(UserManager.UserGuid)) return true; // this user
            }
            catch (App42Exception)
            {
                return true;
            }

            return false;
        }

        private bool ChangeUsername(string username)
        {
            Console.WriteLine("Change username");

            const string dbName = "users";
            const string collectionName = "users";
            var guid = UserManager.UserGuid;

            App42API.Initialize("a0aa82036ff74c83b602de87b68a396cf724df6786ae9caa260e1175a7c8ce26", "14be26afb208c96b1cf16b3b197a988f451bfcf2e0ef2bc6c2dbd6f494f07382");
            var storageService = App42API.BuildStorageService();

            var storage = storageService.FindDocumentByKeyValue(dbName, collectionName, "guid", guid);
            IList<Storage.JSONDocument> jsonDocList;

            try
            {
                jsonDocList = storage.GetJsonDocList();
            }
            catch (App42NotFoundException)
            {
                UserManager.GenerateGuid();

                try
                {
                    storage = storageService.FindDocumentByKeyValue(dbName, collectionName, "guid", guid);
                    jsonDocList = storage.GetJsonDocList();
                }
                catch
                {
                    return false;
                }
            }

            var id = jsonDocList[0].GetDocId();

            var json = "{\"name\":\"" + username.ToUpper() + "\",\"guid\":\"" + guid + "\"}";
            storageService.UpdateDocumentByDocId(dbName, collectionName, id, json);

            Player.Instance.Name = username;

            return true;
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

        public override async void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            await _svc.Pause();

            if (GameView != null)
            {
                GameView.Paused = true;
                CCAudioEngine.SharedEngine.PauseBackgroundMusic();
            }
        }

        public override async void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            await _svc.Resume();

            if (GameView != null && GameView.Paused)
            {
                GameView.Paused = false;
                CCAudioEngine.SharedEngine.PauseBackgroundMusic();
            }
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
            BeginInvokeOnMainThread(() => { if (_intAd.IsReady) _intAd.PresentFromRootViewController(this); });
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

        private LeaderboardItem GetPlayerRanking(ScoreBoardService scoreBoardService, string gameName, LeaderboardType type)
        {
            try
            {
                var game = scoreBoardService.GetUserRanking(gameName, Player.Instance.Name);

                if (game != null && game.GetScoreList() != null && game.GetScoreList().Count > 0)
                {
                    if (game.GetScoreList()[0].GetValue() > 0)
                    {
                        if (type == LeaderboardType.Regular)
                            return LeaderboardManager.DecodeScoreRegular(Convert.ToInt32(game.GetScoreList()[0].GetRank()), game.GetScoreList()[0].GetUserName(), game.GetScoreList()[0].GetValue());
                        if (type == LeaderboardType.Pro) 
                            return LeaderboardManager.DecodeScorePro(Convert.ToInt32(game.GetScoreList()[0].GetRank()), game.GetScoreList()[0].GetUserName(), game.GetScoreList()[0].GetValue());
                    }
                }
            }
            catch (App42NotFoundException nfe)
            {
                Console.WriteLine(nfe.Message);
            }

            return null;
        }

        private void SubmitScore(double score, double accuracy, double fastestTime, double levelsCompleted)
        {
            Console.WriteLine("Leaderboard submit");

            App42API.Initialize("a0aa82036ff74c83b602de87b68a396cf724df6786ae9caa260e1175a7c8ce26", "14be26afb208c96b1cf16b3b197a988f451bfcf2e0ef2bc6c2dbd6f494f07382");
            var scoreBoardService = App42API.BuildScoreBoardService();

            if (Math.Abs(levelsCompleted - -1) < AppConstants.Tolerance) // regular scoreboard
            {
                LeaderboardManager.PlayerRankRegularDaily = null;
                LeaderboardManager.PlayerRankRegularWeekly = null;
                LeaderboardManager.PlayerRankRegularMonthly = null;
                LeaderboardManager.PlayerRankRegularAlltime = null;

                var gameScoreRegular = LeaderboardManager.EncodeScoreRegular(score, fastestTime, accuracy);

                scoreBoardService.SaveUserScore("Looney Earth Daily", Player.Instance.Name, gameScoreRegular);
                scoreBoardService.SaveUserScore("Looney Earth Weekly", Player.Instance.Name, gameScoreRegular);
                scoreBoardService.SaveUserScore("Looney Earth Monthly", Player.Instance.Name, gameScoreRegular);
                scoreBoardService.SaveUserScore("Looney Earth Alltime", Player.Instance.Name, gameScoreRegular);

                LeaderboardManager.PlayerRankRegularDaily = GetPlayerRanking(scoreBoardService, "Looney Earth Daily", LeaderboardType.Regular);
                LeaderboardManager.PlayerRankRegularWeekly = GetPlayerRanking(scoreBoardService, "Looney Earth Weekly", LeaderboardType.Regular);
                LeaderboardManager.PlayerRankRegularMonthly = GetPlayerRanking(scoreBoardService, "Looney Earth Monthly", LeaderboardType.Regular);
                LeaderboardManager.PlayerRankRegularAlltime = GetPlayerRanking(scoreBoardService, "Looney Earth Alltime", LeaderboardType.Regular);
            }
            else
            {
                LeaderboardManager.PlayerRankProDaily = null;
                LeaderboardManager.PlayerRankProWeekly = null;
                LeaderboardManager.PlayerRankProMonthly = null;
                LeaderboardManager.PlayerRankProAlltime = null;

                var gameScorePro = LeaderboardManager.EncodeScorePro(score, levelsCompleted);

                scoreBoardService.SaveUserScore("Looney Moon Daily", Player.Instance.Name, gameScorePro);
                scoreBoardService.SaveUserScore("Looney Moon Weekly", Player.Instance.Name, gameScorePro);
                scoreBoardService.SaveUserScore("Looney Moon Monthly", Player.Instance.Name, gameScorePro);
                scoreBoardService.SaveUserScore("Looney Moon Alltime", Player.Instance.Name, gameScorePro);

                LeaderboardManager.PlayerRankProDaily = GetPlayerRanking(scoreBoardService, "Looney Moon Daily", LeaderboardType.Pro);
                LeaderboardManager.PlayerRankProWeekly = GetPlayerRanking(scoreBoardService, "Looney Moon Weekly", LeaderboardType.Pro);
                LeaderboardManager.PlayerRankProMonthly = GetPlayerRanking(scoreBoardService, "Looney Moon Monthly", LeaderboardType.Pro);
                LeaderboardManager.PlayerRankProAlltime = GetPlayerRanking(scoreBoardService, "Looney Moon Alltime", LeaderboardType.Pro);
            }
        }

        private void FillLeaderboard(ScoreBoardService scoreBoardService, LeaderboardType type, List<LeaderboardItem> scoreList, string gameName)
        {
            scoreList.Clear();

            try
            {
                var game = scoreBoardService.GetTopNRankers(gameName, 10);

                if (game != null && game.GetScoreList() != null && game.GetScoreList().Count > 0)
                {
                    for (var i = 0; i < game.GetScoreList().Count; i++)
                    {
                        if (game.GetScoreList()[i].GetValue() > 0)
                        {
                            LeaderboardItem lbi = null;

                            if (type == LeaderboardType.Regular) lbi = LeaderboardManager.DecodeScoreRegular(i + 1, game.GetScoreList()[i].GetUserName(), game.GetScoreList()[i].GetValue());
                            else if (type == LeaderboardType.Pro) lbi = LeaderboardManager.DecodeScorePro(i + 1, game.GetScoreList()[i].GetUserName(), game.GetScoreList()[i].GetValue());

                            if (lbi != null) scoreList.Add(lbi);
                        }
                    }
                }
            }
            catch (App42NotFoundException)
            {

            }
        }


        private void RefreshLeaderboardsAsync(Leaderboard leaderboard)
        {
            //---------- Prabhjot Singh ------//
            // await Task.Run(() => refreshLeaderboards(leaderboard));
        }

        private void RefreshLeaderboards(Leaderboard leaderboard)
        {
            switch (leaderboard.Type)
            {
                case LeaderboardType.Regular:
                    Console.WriteLine("Leaderboard refresh - REGULAR");
                    break;
                case LeaderboardType.Pro:
                    Console.WriteLine("Leaderboard refresh - PRO");
                    break;
                default:
                    Console.WriteLine("Leaderboard refresh - ???");
                    break;
            }

            App42API.Initialize("a0aa82036ff74c83b602de87b68a396cf724df6786ae9caa260e1175a7c8ce26", "14be26afb208c96b1cf16b3b197a988f451bfcf2e0ef2bc6c2dbd6f494f07382");

            string gameName;

            switch (leaderboard.Type)
            {
                case LeaderboardType.Regular:
                    gameName = "Looney Earth";
                    break;
                case LeaderboardType.Pro:
                    gameName = "Looney Moon";
                    break;
                default:
                    return;
            }

            var scoreBoardService = App42API.BuildScoreBoardService();

            FillLeaderboard(scoreBoardService, leaderboard.Type, leaderboard.ScoreDaily, gameName + " Daily");
            FillLeaderboard(scoreBoardService, leaderboard.Type, leaderboard.ScoreWeekly, gameName + " Weekly");
            FillLeaderboard(scoreBoardService, leaderboard.Type, leaderboard.ScoreMonthly, gameName + " Monthly");
            FillLeaderboard(scoreBoardService, leaderboard.Type, leaderboard.ScoreAllTime, gameName + " Alltime");

            if (leaderboard.Type == LeaderboardType.Regular)
            {
                LeaderboardManager.PlayerRankRegularDaily = GetPlayerRanking(scoreBoardService, "Looney Earth Daily", LeaderboardType.Regular);
                LeaderboardManager.PlayerRankRegularWeekly = GetPlayerRanking(scoreBoardService, "Looney Earth Weekly", LeaderboardType.Regular);
                LeaderboardManager.PlayerRankRegularMonthly = GetPlayerRanking(scoreBoardService, "Looney Earth Monthly", LeaderboardType.Regular);
                //LooneyInvaders.Model.LeaderboardManager.PlayerRankRegularAlltime = getPlayerRanking(scoreBoardService, "Looney Earth Alltime", LooneyInvaders.Model.LeaderboardType.REGULAR);
            }
            else if (leaderboard.Type == LeaderboardType.Pro)
            {
                LeaderboardManager.PlayerRankProDaily = GetPlayerRanking(scoreBoardService, "Looney Moon Daily", LeaderboardType.Pro);
                LeaderboardManager.PlayerRankProWeekly = GetPlayerRanking(scoreBoardService, "Looney Moon Weekly", LeaderboardType.Pro);
                LeaderboardManager.PlayerRankProMonthly = GetPlayerRanking(scoreBoardService, "Looney Moon Monthly", LeaderboardType.Pro);
                //LooneyInvaders.Model.LeaderboardManager.PlayerRankProAlltime = getPlayerRanking(scoreBoardService, "Looney Moon Alltime", LooneyInvaders.Model.LeaderboardType.PRO);
            }

            BeginInvokeOnMainThread(() => { FireLeaderboardRefreshed(); });
        }

        private void FireLeaderboardRefreshed()
        {
            LeaderboardManager.FireOnLeaderboardsRefreshed();
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