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
        CMMotionManager _motionManager;
        BannerView _adViewWindow;
        bool _adOnWindow;
        readonly nfloat _adBannerYCoord = -1;
        Interstitial _intAd;
        IPurchaseService _svc;
        //string _googlePlayGamesClientId = "647563278989-2c9afc4img7s0t38khukl5ilb8i6k4bt.apps.googleusercontent.com";

        public ViewController(IntPtr handle)
            : base(handle)
        {}

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
                UserManager.UsernameGUIDInsertHandler = UsernameGUIDInsertHandler;
                UserManager.CheckIsUsernameFreeHandler = CheckIsUsernameFree;
                UserManager.ChangeUsernameHandler = ChangeUsername;

                if (!UserManager.IsUserGUIDSet) UserManager.GenerateGUID();

                // Set loading event to be called once game view is fully initialised
                GameView.ViewCreated += GameDelegate.LoadGame;
            }
        }

        private bool UsernameGUIDInsertHandler(string guid)
        {
            Console.WriteLine("GUID insert " + guid);

            string dbName = "users";
            string collectionName = "users";
            string json = "{\"name\":\"guest\",\"guid\":\"" + guid + "\"}";

            App42API.Initialize("a0aa82036ff74c83b602de87b68a396cf724df6786ae9caa260e1175a7c8ce26", "14be26afb208c96b1cf16b3b197a988f451bfcf2e0ef2bc6c2dbd6f494f07382");
            StorageService storageService = App42API.BuildStorageService();

            Storage storage = storageService.InsertJSONDocument(dbName, collectionName, json);
            IList<Storage.JSONDocument> jsonDocList = storage.GetJsonDocList();

            string id = jsonDocList[0].GetDocId();
            string playerName = "player_" + id.Substring(id.Length - 9, 8);

            UserManager.UserGUID = guid;
            Player.Instance.Name = playerName;

            json = "{\"name\":\"" + playerName.ToUpper() + "\",\"guid\":\"" + guid + "\"}";
            storageService.UpdateDocumentByDocId(dbName, collectionName, id, json);

            return true;
        }

        private bool CheckIsUsernameFree(string username)
        {
            Console.WriteLine("Check is username free " + username);

            string dbName = "users";
            string collectionName = "users";

            App42API.Initialize("a0aa82036ff74c83b602de87b68a396cf724df6786ae9caa260e1175a7c8ce26", "14be26afb208c96b1cf16b3b197a988f451bfcf2e0ef2bc6c2dbd6f494f07382");
            StorageService storageService = App42API.BuildStorageService();

            try
            {
                Storage storage = storageService.FindDocumentByKeyValue(dbName, collectionName, "name", username.ToUpper());
                IList<Storage.JSONDocument> jsonDocList = storage.GetJsonDocList();

                if (jsonDocList.Count == 0) return true; // no user
                if (jsonDocList[0].GetJsonDoc().Contains(UserManager.UserGUID)) return true; // this user
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

            string dbName = "users";
            string collectionName = "users";
            string guid = UserManager.UserGUID;

            App42API.Initialize("a0aa82036ff74c83b602de87b68a396cf724df6786ae9caa260e1175a7c8ce26", "14be26afb208c96b1cf16b3b197a988f451bfcf2e0ef2bc6c2dbd6f494f07382");
            StorageService storageService = App42API.BuildStorageService();

            Storage storage = storageService.FindDocumentByKeyValue(dbName, collectionName, "guid", guid);
            IList<Storage.JSONDocument> jsonDocList;

            try
            {
                jsonDocList = storage.GetJsonDocList();
            }
            catch (App42NotFoundException)
            {
                UserManager.GenerateGUID();

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

            string id = jsonDocList[0].GetDocId();

            string json = "{\"name\":\"" + username.ToUpper() + "\",\"guid\":\"" + guid + "\"}";
            storageService.UpdateDocumentByDocId(dbName, collectionName, id, json);

            Player.Instance.Name = username;

            return true;
        }

        private float RadiansToDegrees(double radians)
        {
            return (float)(180 / Math.PI * radians);
        }


        private void GetGyro(ref float yaw, ref float tilt, ref float pitch)
        {
            var fullPitch = RadiansToDegrees(_motionManager.DeviceMotion.Attitude.Pitch);

            yaw = RadiansToDegrees(_motionManager.DeviceMotion.Attitude.Yaw);
            tilt = RadiansToDegrees(_motionManager.DeviceMotion.Attitude.Roll);
            pitch = (float)Math.Round(fullPitch, 3);

            if (InterfaceOrientation == UIInterfaceOrientation.LandscapeRight) pitch = pitch * -1;
        }

        async public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            await _svc.Pause();

            if (GameView != null)
            {
                GameView.Paused = true;
                CCAudioEngine.SharedEngine.PauseBackgroundMusic();
            }
        }

        async public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            await _svc.Resume();

            if (GameView != null && GameView.Paused == true)
            {
                GameView.Paused = false;
                CCAudioEngine.SharedEngine.PauseBackgroundMusic();
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        void AddBannerToWindowTop()
        {
            BeginInvokeOnMainThread(() => { AddBannerToWindow(0); });
        }

        void AddBannerToWindowBottom()
        {
            BeginInvokeOnMainThread(() => { AddBannerToWindow(View.Bounds.Size.Height - 50); });
        }

        void HideBanner()
        {
            BeginInvokeOnMainThread(() => { RemoveBannerFromWindow(); });
        }

        void AddBannerToWindow(nfloat yCoord)
        {
            if (_adViewWindow != null && yCoord == _adBannerYCoord) return;

            if (_adViewWindow != null) RemoveBannerFromWindow();

            if (_adViewWindow == null)
            {
                // Setup your GADBannerView, review AdSizeCons class for more Ad sizes. 
                _adViewWindow = new BannerView(size: AdSizeCons.Banner, origin: new CGPoint((View.Bounds.Size.Width - 320) / 2, yCoord));
                _adViewWindow.AdUnitID = "ca-app-pub-5373308786713201/3891909370";
                _adViewWindow.RootViewController = this;

                // Wire AdReceived event to know when the Ad is ready to be displayed
                _adViewWindow.AdReceived += AdViewWindow_AdReceived;
                _adViewWindow.ReceiveAdFailed += AdViewWindow_ReceiveAdFailed;
            }

            Request request = Request.GetDefaultRequest();
#if DEBUG
            //request.TestDevices = new string[] { "91081e0a39a84d0f81f550efec64ec47" };
#endif

            _adViewWindow.LoadRequest(request);
        }

        void RemoveBannerFromWindow()
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

            Request request = Request.GetDefaultRequest();
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

            Request request = Request.GetDefaultRequest();
#if DEBUG
            request.TestDevices = new string[] { "e62a2b8cda8eb947dcd2033062559b9f" };
#endif
            _intAd.LoadRequest(request);
        }

        async Task MakePurchase(IProduct product)
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
            catch (PurchaseError ex)
            {
                Console.WriteLine("Error with {product}:{ex.Message}");
                PurchaseManager.FireOnPurchaseFinished();
            }
        }

        async Task<bool> PurchaseProduct(string productId)
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
                Game game = scoreBoardService.GetUserRanking(gameName, Player.Instance.Name);

                if (game != null && game.GetScoreList() != null && game.GetScoreList().Count > 0)
                {
                    if (game.GetScoreList()[0].GetValue() > 0)
                    {
                        if (type == LeaderboardType.REGULAR) return LeaderboardManager.DecodeScoreRegular(Convert.ToInt32(game.GetScoreList()[0].GetRank()), game.GetScoreList()[0].GetUserName(), game.GetScoreList()[0].GetValue());
                        else if (type == LeaderboardType.PRO) return LeaderboardManager.DecodeScorePro(Convert.ToInt32(game.GetScoreList()[0].GetRank()), game.GetScoreList()[0].GetUserName(), game.GetScoreList()[0].GetValue());
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
            ScoreBoardService scoreBoardService = App42API.BuildScoreBoardService();

            if (levelsCompleted == -1) // regular scoreboard
            {
                LeaderboardManager.PlayerRankRegularDaily = null;
                LeaderboardManager.PlayerRankRegularWeekly = null;
                LeaderboardManager.PlayerRankRegularMonthly = null;
                LeaderboardManager.PlayerRankRegularAlltime = null;

                double gameScoreRegular = LeaderboardManager.EncodeScoreRegular(score, fastestTime, accuracy);

                scoreBoardService.SaveUserScore("Looney Earth Daily", Player.Instance.Name, gameScoreRegular);
                scoreBoardService.SaveUserScore("Looney Earth Weekly", Player.Instance.Name, gameScoreRegular);
                scoreBoardService.SaveUserScore("Looney Earth Monthly", Player.Instance.Name, gameScoreRegular);
                scoreBoardService.SaveUserScore("Looney Earth Alltime", Player.Instance.Name, gameScoreRegular);

                LeaderboardManager.PlayerRankRegularDaily = GetPlayerRanking(scoreBoardService, "Looney Earth Daily", LeaderboardType.REGULAR);
                LeaderboardManager.PlayerRankRegularWeekly = GetPlayerRanking(scoreBoardService, "Looney Earth Weekly", LeaderboardType.REGULAR);
                LeaderboardManager.PlayerRankRegularMonthly = GetPlayerRanking(scoreBoardService, "Looney Earth Monthly", LeaderboardType.REGULAR);
                LeaderboardManager.PlayerRankRegularAlltime = GetPlayerRanking(scoreBoardService, "Looney Earth Alltime", LeaderboardType.REGULAR);
            }
            else
            {
                LeaderboardManager.PlayerRankProDaily = null;
                LeaderboardManager.PlayerRankProWeekly = null;
                LeaderboardManager.PlayerRankProMonthly = null;
                LeaderboardManager.PlayerRankProAlltime = null;

                double gameScorePro = LeaderboardManager.EncodeScorePro(score, levelsCompleted);

                scoreBoardService.SaveUserScore("Looney Moon Daily", Player.Instance.Name, gameScorePro);
                scoreBoardService.SaveUserScore("Looney Moon Weekly", Player.Instance.Name, gameScorePro);
                scoreBoardService.SaveUserScore("Looney Moon Monthly", Player.Instance.Name, gameScorePro);
                scoreBoardService.SaveUserScore("Looney Moon Alltime", Player.Instance.Name, gameScorePro);

                LeaderboardManager.PlayerRankProDaily = GetPlayerRanking(scoreBoardService, "Looney Moon Daily", LeaderboardType.PRO);
                LeaderboardManager.PlayerRankProWeekly = GetPlayerRanking(scoreBoardService, "Looney Moon Weekly", LeaderboardType.PRO);
                LeaderboardManager.PlayerRankProMonthly = GetPlayerRanking(scoreBoardService, "Looney Moon Monthly", LeaderboardType.PRO);
                LeaderboardManager.PlayerRankProAlltime = GetPlayerRanking(scoreBoardService, "Looney Moon Alltime", LeaderboardType.PRO);
            }
        }

        private void FillLeaderboard(ScoreBoardService scoreBoardService, LeaderboardType type, List<LeaderboardItem> scoreList, string gameName)
        {
            scoreList.Clear();

            try
            {
                Game game = scoreBoardService.GetTopNRankers(gameName, 10);

                if (game != null && game.GetScoreList() != null && game.GetScoreList().Count > 0)
                {
                    for (int i = 0; i < game.GetScoreList().Count; i++)
                    {
                        if (game.GetScoreList()[i].GetValue() > 0)
                        {
                            LeaderboardItem lbi = null;

                            if (type == LeaderboardType.REGULAR) lbi = LeaderboardManager.DecodeScoreRegular(i + 1, game.GetScoreList()[i].GetUserName(), game.GetScoreList()[i].GetValue());
                            else if (type == LeaderboardType.PRO) lbi = LeaderboardManager.DecodeScorePro(i + 1, game.GetScoreList()[i].GetUserName(), game.GetScoreList()[i].GetValue());

                            if (lbi != null) scoreList.Add(lbi);
                        }
                    }
                }
            }
            catch (App42NotFoundException nfe)
            {

            }
        }


        private async void RefreshLeaderboardsAsync(Leaderboard leaderboard)
        {
            //---------- Prabhjot Singh ------//
            // await Task.Run(() => refreshLeaderboards(leaderboard));
        }

        private void RefreshLeaderboards(Leaderboard leaderboard)
        {
            if (leaderboard.Type == LeaderboardType.REGULAR) Console.WriteLine("Leaderboard refresh - REGULAR");
            else if (leaderboard.Type == LeaderboardType.PRO) Console.WriteLine("Leaderboard refresh - PRO");
            else Console.WriteLine("Leaderboard refresh - ???");

            App42API.Initialize("a0aa82036ff74c83b602de87b68a396cf724df6786ae9caa260e1175a7c8ce26", "14be26afb208c96b1cf16b3b197a988f451bfcf2e0ef2bc6c2dbd6f494f07382");

            String gameName;

            if (leaderboard.Type == LeaderboardType.REGULAR) gameName = "Looney Earth";
            else if (leaderboard.Type == LeaderboardType.PRO) gameName = "Looney Moon";
            else return;

            ScoreBoardService scoreBoardService = App42API.BuildScoreBoardService();

            DateTime startDate = DateTime.Now.Date.AddDays(-1);
            DateTime endDate = DateTime.Now;

            FillLeaderboard(scoreBoardService, leaderboard.Type, leaderboard.ScoreDaily, gameName + " Daily");
            FillLeaderboard(scoreBoardService, leaderboard.Type, leaderboard.ScoreWeekly, gameName + " Weekly");
            FillLeaderboard(scoreBoardService, leaderboard.Type, leaderboard.ScoreMonthly, gameName + " Monthly");
            FillLeaderboard(scoreBoardService, leaderboard.Type, leaderboard.ScoreAllTime, gameName + " Alltime");

            if (leaderboard.Type == LeaderboardType.REGULAR)
            {
                LeaderboardManager.PlayerRankRegularDaily = GetPlayerRanking(scoreBoardService, "Looney Earth Daily", LeaderboardType.REGULAR);
                LeaderboardManager.PlayerRankRegularWeekly = GetPlayerRanking(scoreBoardService, "Looney Earth Weekly", LeaderboardType.REGULAR);
                LeaderboardManager.PlayerRankRegularMonthly = GetPlayerRanking(scoreBoardService, "Looney Earth Monthly", LeaderboardType.REGULAR);
                //LooneyInvaders.Model.LeaderboardManager.PlayerRankRegularAlltime = getPlayerRanking(scoreBoardService, "Looney Earth Alltime", LooneyInvaders.Model.LeaderboardType.REGULAR);
            }
            else if (leaderboard.Type == LeaderboardType.PRO)
            {
                LeaderboardManager.PlayerRankProDaily = GetPlayerRanking(scoreBoardService, "Looney Moon Daily", LeaderboardType.PRO);
                LeaderboardManager.PlayerRankProWeekly = GetPlayerRanking(scoreBoardService, "Looney Moon Weekly", LeaderboardType.PRO);
                LeaderboardManager.PlayerRankProMonthly = GetPlayerRanking(scoreBoardService, "Looney Moon Monthly", LeaderboardType.PRO);
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
            if (stream == null) Console.WriteLine("stream is null");

            System.IO.MemoryStream ms = (System.IO.MemoryStream)stream;

            NSData data = NSData.FromArray(ms.ToArray());
            UIImage img = UIImage.LoadFromData(data);

            Console.WriteLine("IMAGE width: " + img.Size.Width.ToString() + " height: " + img.Size.Height.ToString());

            BeginInvokeOnMainThread(() => { ShareOnSocialNetworkIos(network, img); });
        }

        public void ShareOnSocialNetworkIos(string network, UIImage img)
        {
            UIActivityViewController activityVc = new UIActivityViewController(new NSObject[] { img }, null);

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