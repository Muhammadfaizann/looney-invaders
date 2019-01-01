using System;
using System.Collections.Generic;
using System.Linq;
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
using LooneyInvaders.Classes;

namespace LooneyInvaders.iOS
{
    public partial class ViewController : UIViewController
    {
        CMMotionManager motionManager;
        BannerView adViewWindow;
        bool adOnWindow = false;
        nfloat adBannerYCoord = -1;
        Interstitial intAd;
        IPurchaseService svc;
        string googlePlayGamesClientID = "647563278989-2c9afc4img7s0t38khukl5ilb8i6k4bt.apps.googleusercontent.com";

        public ViewController(IntPtr handle)
            : base(handle)
        {
        }

        async public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (GameView != null)
            {
                motionManager = new CMMotionManager();
                motionManager.StartDeviceMotionUpdates();


                //------------ Prabhjot -----------//
                //     GameDelegate.GetGyro = getGyro;


                GameView.MultipleTouchEnabled = true;

                LooneyInvaders.Model.AdMobManager.ShowBannerTopHandler = AddBannerToWindowTop;
                LooneyInvaders.Model.AdMobManager.ShowBannerBottomHandler = AddBannerToWindowBottom;
                LooneyInvaders.Model.AdMobManager.HideBannerHandler = HideBanner;
                LooneyInvaders.Model.AdMobManager.LoadInterstitialHandler = LoadInterstitial;
                LooneyInvaders.Model.AdMobManager.ShowInterstitialHandler = ShowInterstitial;

                GameView.BackgroundColor = UIColor.Black;

                this.LoadInterstitial();

                svc = new PurchaseService();
                await svc.Init();

                LooneyInvaders.Model.PurchaseManager.PurchaseHandler = purchaseProduct;

                LooneyInvaders.Model.VibrationManager.VibrationHandler = Vibrate;

                //SignIn.SharedInstance.UIDelegate = this;
                //Google.Play.GameServices.Manager.SharedInstance.SignIn(googlePlayGamesClientID, false);

                LooneyInvaders.Model.LeaderboardManager.SubmitScoreHandler = submitScore;
                LooneyInvaders.Model.LeaderboardManager.RefreshLeaderboardsHandler = refreshLeaderboardsAsync;

                // social network sharing
                LooneyInvaders.Model.SocialNetworkShareManager.ShareOnSocialNetwork = ShareOnSocialNetworkHandler;

                // user management
                LooneyInvaders.Model.UserManager.UsernameGUIDInsertHandler = UsernameGUIDInsertHandler;
                LooneyInvaders.Model.UserManager.CheckIsUsernameFreeHandler = CheckIsUsernameFree;
                LooneyInvaders.Model.UserManager.ChangeUsernameHandler = ChangeUsername;

                if (!LooneyInvaders.Model.UserManager.IsUserGUIDSet) LooneyInvaders.Model.UserManager.GenerateGUID();

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
            IList<Storage.JSONDocument> JsonDocList = storage.GetJsonDocList();

            string id = JsonDocList[0].GetDocId();
            string playerName = "player_" + id.Substring(id.Length - 9, 8);

            LooneyInvaders.Model.UserManager.UserGUID = guid;
            LooneyInvaders.Model.Player.Instance.Name = playerName;

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
                IList<Storage.JSONDocument> JsonDocList = storage.GetJsonDocList();

                if (JsonDocList.Count == 0) return true; // no user
                if (JsonDocList[0].GetJsonDoc().Contains(LooneyInvaders.Model.UserManager.UserGUID)) return true; // this user
            }
            catch (App42NotFoundException nfe)
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
            string guid = LooneyInvaders.Model.UserManager.UserGUID;

            App42API.Initialize("a0aa82036ff74c83b602de87b68a396cf724df6786ae9caa260e1175a7c8ce26", "14be26afb208c96b1cf16b3b197a988f451bfcf2e0ef2bc6c2dbd6f494f07382");
            StorageService storageService = App42API.BuildStorageService();

            Storage storage = storageService.FindDocumentByKeyValue(dbName, collectionName, "guid", guid);
            IList<Storage.JSONDocument> JsonDocList = null;

            try
            {
                JsonDocList = storage.GetJsonDocList();
            }
            catch (App42NotFoundException nfe)
            {
                LooneyInvaders.Model.UserManager.GenerateGUID();

                try
                {
                    storage = storageService.FindDocumentByKeyValue(dbName, collectionName, "guid", guid);
                    JsonDocList = storage.GetJsonDocList();
                }
                catch
                {
                    return false;
                }
            }

            string id = JsonDocList[0].GetDocId();

            string json = "{\"name\":\"" + username.ToUpper() + "\",\"guid\":\"" + guid + "\"}";
            storageService.UpdateDocumentByDocId(dbName, collectionName, id, json);

            LooneyInvaders.Model.Player.Instance.Name = username;

            return true;
        }

        private float radiansToDegrees(double radians)
        {
            return (float)(180 / Math.PI * radians);
        }


        private void getGyro(ref float yaw, ref float tilt, ref float pitch)
        {
            var fullPitch = radiansToDegrees(motionManager.DeviceMotion.Attitude.Pitch);

            yaw = radiansToDegrees(motionManager.DeviceMotion.Attitude.Yaw);
            tilt = radiansToDegrees(motionManager.DeviceMotion.Attitude.Roll);
            pitch = (float)Math.Round(fullPitch, 3);

            if (InterfaceOrientation == UIInterfaceOrientation.LandscapeRight) pitch = pitch * -1;
        }

        async public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            await svc.Pause();

			if (GameView != null)
			{
				GameView.Paused = true;
				CCAudioEngine.SharedEngine.PauseBackgroundMusic();
			}
        }

		async public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            await svc.Resume();

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
            BeginInvokeOnMainThread(() => { this.AddBannerToWindow(0); });
        }

        void AddBannerToWindowBottom()
        {
            BeginInvokeOnMainThread(() => { this.AddBannerToWindow(this.View.Bounds.Size.Height - 50); });
        }

        void HideBanner()
        {
            BeginInvokeOnMainThread(() => { this.RemoveBannerFromWindow(); });
        }

        void AddBannerToWindow(nfloat yCoord)
        {
            if (adViewWindow != null && yCoord == adBannerYCoord) return;

            if (adViewWindow != null) this.RemoveBannerFromWindow();

            if (adViewWindow == null)
            {
                // Setup your GADBannerView, review AdSizeCons class for more Ad sizes. 
                adViewWindow = new BannerView(size: AdSizeCons.Banner, origin: new CGPoint((this.View.Bounds.Size.Width - 320) / 2, yCoord));
                adViewWindow.AdUnitID = "ca-app-pub-5373308786713201/3891909370";
                adViewWindow.RootViewController = this;

                // Wire AdReceived event to know when the Ad is ready to be displayed
                adViewWindow.AdReceived += AdViewWindow_AdReceived;
                adViewWindow.ReceiveAdFailed += AdViewWindow_ReceiveAdFailed;
            }

            Request request = Request.GetDefaultRequest();
#if DEBUG
            //request.TestDevices = new string[] { "91081e0a39a84d0f81f550efec64ec47" };
#endif

            adViewWindow.LoadRequest(request);
        }

        void RemoveBannerFromWindow()
        {
            if (adViewWindow != null)
            {
                if (adOnWindow)
                {
                    adViewWindow.RemoveFromSuperview();
                }
                adOnWindow = false;

                // You need to explicitly Dispose BannerView when you dont need it anymore
                // to avoid crashes if pending request are in progress
                adViewWindow.Dispose();
                adViewWindow = null;
            }
        }

        private void AdViewWindow_AdReceived(object sender, EventArgs e)
        {
            if (!adOnWindow)
            {
                this.View.AddSubview(adViewWindow);
                adOnWindow = true;
            }
        }

        private void AdViewWindow_ReceiveAdFailed(object sender, BannerViewErrorEventArgs e)
        {
            Console.WriteLine("Ad receive failed: " + e.Error.DebugDescription);
        }

        public void ShowInterstitial()
        {
            BeginInvokeOnMainThread(() => { if (this.intAd.IsReady) this.intAd.PresentFromRootViewController(this); });
        }

        public void LoadInterstitial()
        {
            intAd = new Interstitial("ca-app-pub-5373308786713201/2524424172");
            intAd.Delegate = new InterstitialDelegate();
            intAd.ReceiveAdFailed += IntAd_ReceiveAdFailed;
            intAd.ScreenDismissed += IntAd_ScreenDismissed;
            intAd.WillPresentScreen += IntAd_WillPresentScreen;

            Request request = Request.GetDefaultRequest();
#if DEBUG
            request.TestDevices = new string[] { "e62a2b8cda8eb947dcd2033062559b9f" };
#endif
            intAd.LoadRequest(request);
        }

        private void IntAd_ReceiveAdFailed(object sender, InterstitialDidFailToReceiveAdWithErrorEventArgs e)
        {
            Console.WriteLine("Interstitial ad: receive ad failed");

            LooneyInvaders.Model.AdMobManager.InterstitialAdFailedToLoad();
        }

        private void IntAd_WillPresentScreen(object sender, EventArgs e)
        {
            Console.WriteLine("Interstitial ad: will present screen");

            LooneyInvaders.Model.AdMobManager.InterstitialAdOpened();
        }

        private void IntAd_ScreenDismissed(object sender, EventArgs e)
        {
            Console.WriteLine("Interstitial ad: screen dismissed");

            LooneyInvaders.Model.AdMobManager.InterstitialAdClosed();

            intAd.Dispose();
            intAd = null;

            intAd = new Interstitial("ca-app-pub-5373308786713201/2524424172");
            intAd.Delegate = new InterstitialDelegate();
            intAd.ReceiveAdFailed += IntAd_ReceiveAdFailed;
            intAd.ScreenDismissed += IntAd_ScreenDismissed;
            intAd.WillPresentScreen += IntAd_WillPresentScreen;

            Request request = Request.GetDefaultRequest();
#if DEBUG
            request.TestDevices = new string[] { "e62a2b8cda8eb947dcd2033062559b9f" };
#endif
            intAd.LoadRequest(request);
        }

        async Task MakePurchase(IProduct product)
        {
            try
            {
                var purchase = await svc.Purchase(product);
                if (purchase.Status == TransactionStatus.Purchased)
                {
                    //new UIAlertView("Success", $"Just Purchased {product}", null, "OK").Show();
                    if (product.ProductId == "credits_1_mil") LooneyInvaders.Model.Player.Instance.Credits += 1000000;
                    else if (product.ProductId == "credits_300_k") LooneyInvaders.Model.Player.Instance.Credits += 300000;
                    else if (product.ProductId == "credits_100_k") LooneyInvaders.Model.Player.Instance.Credits += 100000;
                    else if (product.ProductId == "ads_off") LooneyInvaders.Model.Settings.Instance.Advertisements = false;

                    LooneyInvaders.Model.PurchaseManager.FireOnPurchaseFinished();
                }
                else
                {
                    Console.WriteLine("Failed Purchase: Cannot Purchase " + product.ProductId);
                    LooneyInvaders.Model.PurchaseManager.FireOnPurchaseFinished();
                }
            }
            catch (PurchaseError ex)
            {
                Console.WriteLine("Error with {product}:{ex.Message}");
                LooneyInvaders.Model.PurchaseManager.FireOnPurchaseFinished();
            }
        }

        void purchaseItem(string productId)
        {
            Task t = MakePurchase(new Product(productId));
        }

        bool purchaseProduct(string productId)
        {
            BeginInvokeOnMainThread(() => { purchaseItem(productId); });

            return true;
        }

        private void Vibrate(object sender, EventArgs e)
        {
            AudioToolbox.SystemSound.Vibrate.PlaySystemSound();
        }

        private LeaderboardItem getPlayerRanking(ScoreBoardService scoreBoardService, string gameName, LooneyInvaders.Model.LeaderboardType type)
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
            catch (App42NotFoundException nfe) {
                Console.WriteLine(nfe.Message);
            }

            return null;
        }

        private void submitScore(double score, double accuracy, double fastestTime, double levelsCompleted)
        {
            Console.WriteLine("Leaderboard submit");

            App42API.Initialize("a0aa82036ff74c83b602de87b68a396cf724df6786ae9caa260e1175a7c8ce26", "14be26afb208c96b1cf16b3b197a988f451bfcf2e0ef2bc6c2dbd6f494f07382");
            ScoreBoardService scoreBoardService = App42API.BuildScoreBoardService();

            if (levelsCompleted == -1) // regular scoreboard
            {
                LooneyInvaders.Model.LeaderboardManager.PlayerRankRegularDaily = null;
                LooneyInvaders.Model.LeaderboardManager.PlayerRankRegularWeekly = null;
                LooneyInvaders.Model.LeaderboardManager.PlayerRankRegularMonthly = null;
                LooneyInvaders.Model.LeaderboardManager.PlayerRankRegularAlltime = null;

                double gameScoreRegular = LooneyInvaders.Model.LeaderboardManager.EncodeScoreRegular(score, fastestTime, accuracy);

                scoreBoardService.SaveUserScore("Looney Earth Daily", Player.Instance.Name, gameScoreRegular);
                scoreBoardService.SaveUserScore("Looney Earth Weekly", Player.Instance.Name, gameScoreRegular);
                scoreBoardService.SaveUserScore("Looney Earth Monthly", Player.Instance.Name, gameScoreRegular);
                scoreBoardService.SaveUserScore("Looney Earth Alltime", Player.Instance.Name, gameScoreRegular);

                LooneyInvaders.Model.LeaderboardManager.PlayerRankRegularDaily = getPlayerRanking(scoreBoardService, "Looney Earth Daily", LooneyInvaders.Model.LeaderboardType.REGULAR);
                LooneyInvaders.Model.LeaderboardManager.PlayerRankRegularWeekly = getPlayerRanking(scoreBoardService, "Looney Earth Weekly", LooneyInvaders.Model.LeaderboardType.REGULAR);
                LooneyInvaders.Model.LeaderboardManager.PlayerRankRegularMonthly = getPlayerRanking(scoreBoardService, "Looney Earth Monthly", LooneyInvaders.Model.LeaderboardType.REGULAR);
                LooneyInvaders.Model.LeaderboardManager.PlayerRankRegularAlltime = getPlayerRanking(scoreBoardService, "Looney Earth Alltime", LooneyInvaders.Model.LeaderboardType.REGULAR);
            }
            else
            {
                LooneyInvaders.Model.LeaderboardManager.PlayerRankProDaily = null;
                LooneyInvaders.Model.LeaderboardManager.PlayerRankProWeekly = null;
                LooneyInvaders.Model.LeaderboardManager.PlayerRankProMonthly = null;
                LooneyInvaders.Model.LeaderboardManager.PlayerRankProAlltime = null;

                double gameScorePro = LooneyInvaders.Model.LeaderboardManager.EncodeScorePro(score, levelsCompleted);

                scoreBoardService.SaveUserScore("Looney Moon Daily", Player.Instance.Name, gameScorePro);
                scoreBoardService.SaveUserScore("Looney Moon Weekly", Player.Instance.Name, gameScorePro);
                scoreBoardService.SaveUserScore("Looney Moon Monthly", Player.Instance.Name, gameScorePro);
                scoreBoardService.SaveUserScore("Looney Moon Alltime", Player.Instance.Name, gameScorePro);

                LooneyInvaders.Model.LeaderboardManager.PlayerRankProDaily = getPlayerRanking(scoreBoardService, "Looney Moon Daily", LooneyInvaders.Model.LeaderboardType.PRO);
                LooneyInvaders.Model.LeaderboardManager.PlayerRankProWeekly = getPlayerRanking(scoreBoardService, "Looney Moon Weekly", LooneyInvaders.Model.LeaderboardType.PRO);
                LooneyInvaders.Model.LeaderboardManager.PlayerRankProMonthly = getPlayerRanking(scoreBoardService, "Looney Moon Monthly", LooneyInvaders.Model.LeaderboardType.PRO);
                LooneyInvaders.Model.LeaderboardManager.PlayerRankProAlltime = getPlayerRanking(scoreBoardService, "Looney Moon Alltime", LooneyInvaders.Model.LeaderboardType.PRO);
            }
        }

        private void fillLeaderboard(ScoreBoardService scoreBoardService, LeaderboardType type, List<LeaderboardItem> scoreList, string gameName)
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
                            LooneyInvaders.Model.LeaderboardItem lbi = null;

                            if (type == LeaderboardType.REGULAR) lbi = LeaderboardManager.DecodeScoreRegular(i + 1, game.GetScoreList()[i].GetUserName(), game.GetScoreList()[i].GetValue());
                            else if (type == LeaderboardType.PRO) lbi = LeaderboardManager.DecodeScorePro(i + 1, game.GetScoreList()[i].GetUserName(), game.GetScoreList()[i].GetValue());

                            if (lbi != null) scoreList.Add(lbi);
                        }
                    }
                }
            }
            catch (App42NotFoundException nfe) {
            
            }
        }


        private async void refreshLeaderboardsAsync(LooneyInvaders.Model.Leaderboard leaderboard)
        {
            //---------- Prabhjot Singh ------//
            // await Task.Run(() => refreshLeaderboards(leaderboard));
        }

        private void refreshLeaderboards(LooneyInvaders.Model.Leaderboard leaderboard)
        {
            if (leaderboard.Type == LeaderboardType.REGULAR) Console.WriteLine("Leaderboard refresh - REGULAR");
            else if (leaderboard.Type == Model.LeaderboardType.PRO) Console.WriteLine("Leaderboard refresh - PRO");
            else Console.WriteLine("Leaderboard refresh - ???");

            App42API.Initialize("a0aa82036ff74c83b602de87b68a396cf724df6786ae9caa260e1175a7c8ce26", "14be26afb208c96b1cf16b3b197a988f451bfcf2e0ef2bc6c2dbd6f494f07382");

            String gameName;

            if (leaderboard.Type == Model.LeaderboardType.REGULAR) gameName = "Looney Earth";
            else if (leaderboard.Type == Model.LeaderboardType.PRO) gameName = "Looney Moon";
            else return;

            ScoreBoardService scoreBoardService = App42API.BuildScoreBoardService();

            DateTime startDate = DateTime.Now.Date.AddDays(-1);
            DateTime endDate = DateTime.Now;

            fillLeaderboard(scoreBoardService, leaderboard.Type, leaderboard.ScoreDaily, gameName + " Daily");
            fillLeaderboard(scoreBoardService, leaderboard.Type, leaderboard.ScoreWeekly, gameName + " Weekly");
            fillLeaderboard(scoreBoardService, leaderboard.Type, leaderboard.ScoreMonthly, gameName + " Monthly");
            fillLeaderboard(scoreBoardService, leaderboard.Type, leaderboard.ScoreAllTime, gameName + " Alltime");

            if (leaderboard.Type == Model.LeaderboardType.REGULAR)
            {
                LooneyInvaders.Model.LeaderboardManager.PlayerRankRegularDaily = getPlayerRanking(scoreBoardService, "Looney Earth Daily", LooneyInvaders.Model.LeaderboardType.REGULAR);
                LooneyInvaders.Model.LeaderboardManager.PlayerRankRegularWeekly = getPlayerRanking(scoreBoardService, "Looney Earth Weekly", LooneyInvaders.Model.LeaderboardType.REGULAR);
                LooneyInvaders.Model.LeaderboardManager.PlayerRankRegularMonthly = getPlayerRanking(scoreBoardService, "Looney Earth Monthly", LooneyInvaders.Model.LeaderboardType.REGULAR);
                //LooneyInvaders.Model.LeaderboardManager.PlayerRankRegularAlltime = getPlayerRanking(scoreBoardService, "Looney Earth Alltime", LooneyInvaders.Model.LeaderboardType.REGULAR);
            }
            else if (leaderboard.Type == Model.LeaderboardType.PRO)
            {
                LooneyInvaders.Model.LeaderboardManager.PlayerRankProDaily = getPlayerRanking(scoreBoardService, "Looney Moon Daily", LooneyInvaders.Model.LeaderboardType.PRO);
                LooneyInvaders.Model.LeaderboardManager.PlayerRankProWeekly = getPlayerRanking(scoreBoardService, "Looney Moon Weekly", LooneyInvaders.Model.LeaderboardType.PRO);
                LooneyInvaders.Model.LeaderboardManager.PlayerRankProMonthly = getPlayerRanking(scoreBoardService, "Looney Moon Monthly", LooneyInvaders.Model.LeaderboardType.PRO);
                //LooneyInvaders.Model.LeaderboardManager.PlayerRankProAlltime = getPlayerRanking(scoreBoardService, "Looney Moon Alltime", LooneyInvaders.Model.LeaderboardType.PRO);
            }

            BeginInvokeOnMainThread(() => { fireLeaderboardRefreshed(); });
        }

        private void fireLeaderboardRefreshed()
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

            BeginInvokeOnMainThread(() => { ShareOnSocialNetworkIOS(network, img); });
        }

        public void ShareOnSocialNetworkIOS(string network, UIImage img)
        {
            UIActivityViewController activityVC = new UIActivityViewController(new NSObject[] { img }, null);

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

            if (activityVC.PopoverPresentationController != null)
                activityVC.PopoverPresentationController.SourceView = this.View;

            this.PresentViewController(activityVC, true, null);
        }
    }
}