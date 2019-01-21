using System;
using System.IO;
using System.Collections.Generic;

using Android;
using Android.Graphics;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MonoGame;
using Android.Hardware;
using CocosSharp;
using LooneyInvaders.Shared;
using LooneyInvaders.Layers;
using Android.Gms.Ads;
using Android.Gms.Common;
using Android.Gms.Common.Apis;
using Android.Gms.Plus;
using CC.Mobile.Purchases;
using System.Threading.Tasks;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.game;
using com.shephertz.app42.paas.sdk.csharp.storage;
using LooneyInvaders.Model;
using Microsoft.AppCenter.Push;
using Microsoft.AppCenter;
using Android.Support.V4.App;
using LooneyInvaders.Services.PNS;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Analytics;
using NotificationCenter;

namespace LooneyInvaders.Droid
{
    [BroadcastReceiver(Enabled = true)]
    [IntentFilter(new[] { Android.Content.Intent.ActionUserPresent })]
    public class UserPresentReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            if (MainActivity.Instance == null) return;

            if (MainActivity.Instance._adBanner != null) MainActivity.Instance._adBanner.Resume();
            CCGameView gameView = (CCGameView)MainActivity.Instance.FindViewById(Resource.Id.GameView);
            if (gameView != null)
                gameView.Paused = false;
        }
    }

    [Activity(
        Label = "Looney Invaders",
        MainLauncher = true,
        Icon = "@drawable/icon",
        Theme = "@android:style/Theme.Holo.NoActionBar.Fullscreen",
        AlwaysRetainTaskState = true,
        //Immersive = true,
        //LaunchMode = LaunchMode.SingleInstance,
        LaunchMode = LaunchMode.SingleTop,
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden,
        ScreenOrientation = ScreenOrientation.SensorLandscape)]
    public class MainActivity : Activity, ISensorEventListener
    {
        public const string HOCKEYAPP_KEY = "9316a9e8222e467a8fdc7ffc7e7c2f21";

        public static MainActivity Instance;

        const string API_KEY = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA0Hv7vhVm/h274S6ok1M1cm+mGUMVzk3OK/rNIG07bvMaLCPXmHpidGCqs8/IaWlnfpsEuny0eZuAYzrpiupi+OvSEX+gqjVLvExh1yh+qOQvXhvwS6YbAl+czFxdMS0Tb6LtJ5dcUDoLJR+oLpV63+SCU9hdL0yP9gm87zxPAF0KalEA72Wr3pyRMdzeD6nZy/3gDJq9CDxMyyo695TvPt5AEeeDJIcIifA/XV0Z9wtnFWWGCmPuX+ZN99CojG2HaXnBg65TuqNal8S9z5IACxkSGbe3CKzwbYZmuvBiF8TXX+5y0u1f44eoiwg2JKkOmc5F9OxlX6BVX+SAxn4/wwIDAQAB";
        //const string API_KEY = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAgeKpYmhtzBDiUXng7xxSw8GBUrkMsjdxWjb4tutL7t0Ms+zNa9e5Et3QlwSVr9Fusn15Wfc9C01cQkLMRRmwcdtR4sGbEwyk127RfdW2/iWYRDP2CypIQj0uApwg3Uay24mjQNnSphXG2KXC+Olv/ZnU7KCamnPlcGngX596ZjKluInnn4ZTqZdNM1nCfJyLxsFA7sWbttyYKHR6i0fNbdKon0SJ2CY/KuA6H1E0MMuaEvm6keS59bP3FWlbNsaT3lw4RFoT40cYa8lgzNeS5Y2GXXYAHdZQj6d4dPSErjevloRf/h7V6CZBrbGRZBMfWn5PZamg0P0d5I0ewMZ/FQIDAQAB";        
        IPurchaseService svc;

        public AdView _adBanner;
        private InterstitialAd _intAd;

        // Facebook
        const string FacebookAppId = "487297588275151";
        string userToken;

        // Client used to interact with Google APIs.
        GoogleApiClient mGoogleApiClient;
        SensorManager sensorManager;

        private void HockeyAppInit()
        {
            //#if !DEBUG
//HockeyApp.Android.CrashManager.Register(this, HOCKEYAPP_KEY);
           // HockeyApp.Android.Metrics.MetricsManager.Register(Application, HOCKEYAPP_KEY);
            //#endif
        }

        private void SetSessionInfo()
        {
            var count = Settings.Instance.GetSessionsCount();
            Settings.Instance.SetSessionsCount(count + 1);
            Settings.Instance.SetTodaySessionDuration(0, true);
            Settings.Instance.IsAskForNotificationToday = false;
        }

        private void CheckNotificationPremissions()
        {
            var notificationsAllowed = new NotificationAllowedService();
            var res = notificationsAllowed.IsNotificationsAllowed();
            Settings.Instance.IsPushNotificationEnabled = res;
        }

        #region -- Push notification --

        protected override void OnNewIntent(Android.Content.Intent intent)
        {
            base.OnNewIntent(intent);
            Push.CheckLaunchedFromNotification(this, intent);
        }

        #endregion

       // override on


         protected override void OnCreate(Bundle bundle)
        {

            //---------- Prabhjot ---------//
            AppCenter.LogLevel = LogLevel.Verbose;
            AppCenter.Start("51b755ae-47b2-472a-b134-ea89837cad38",
                    typeof(Analytics), typeof(Crashes));
            Crashes.SetEnabledAsync(true);


            HockeyAppInit();
            SetSessionInfo();
            CheckNotificationPremissions();
           // ErrorReport crashReport = Crashes.GetLastSessionCrashReportAsync();
            base.OnCreate(bundle);
            Instance = this;
            // remove navigation bar
            View decorView = this.Window.DecorView;
            var uiOptions = (int)decorView.SystemUiVisibility;
            var newUiOptions = (int)uiOptions;
            newUiOptions |= (int)SystemUiFlags.HideNavigation;
            newUiOptions |= (int)SystemUiFlags.ImmersiveSticky;
            newUiOptions |= (int)SystemUiFlags.Fullscreen;
            decorView.SystemUiVisibility = (StatusBarVisibility)newUiOptions;

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // add gyro
            GameDelegate.GetGyro = getGyro;
            sensorManager = (SensorManager)this.GetSystemService(Context.SensorService);
            /*Sensor gyro = sm.GetDefaultSensor(SensorType.RotationVector);
            sm.RegisterListener(this, gyro, SensorDelay.Game);*/

            // connect to AdMob
            Android.Graphics.Point size = new Android.Graphics.Point();
            this.WindowManager.DefaultDisplay.GetRealSize(size);

            _adBanner = new AdView(Application.Context);
            _adBanner.AdSize = AdSize.Banner;
            _adBanner.AdUnitId = "ca-app-pub-5373308786713201/9938442971";
            _adBanner.Id = 999;
            _adBanner.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
            ViewGroup.LayoutParams adParams = new ViewGroup.LayoutParams(size.X, _adBanner.AdSize.GetHeightInPixels(Application.Context));
            _adBanner.SetY(0);
            _adBanner.SetX(0);

            var requestbuilder = new AdRequest.Builder();
            requestbuilder.AddTestDevice(AdRequest.DeviceIdEmulator);
            requestbuilder.AddTestDevice("C663A5E7C7E3925C26A199E85E3E39D6");
            _adBanner.LoadAd(requestbuilder.Build());

            _adBanner.Visibility = ViewStates.Invisible;

            this.AddContentView(_adBanner, adParams);
            _adBanner.AdListener = new AdListenerEx(_adBanner);

            LooneyInvaders.Model.AdMobManager.ShowBannerTopHandler = ShowBannerTop;
            LooneyInvaders.Model.AdMobManager.ShowBannerBottomHandler = ShowBannerBottom;
            LooneyInvaders.Model.AdMobManager.HideBannerHandler = HideBanner;
            LooneyInvaders.Model.AdMobManager.LoadInterstitialHandler = LoadInterstitial;
            LooneyInvaders.Model.AdMobManager.ShowInterstitialHandler = ShowInterstitial;
            LooneyInvaders.Model.AdMobManager.HideInterstitialHandler = HideInterstitial;

            this.LoadInterstitial();


#if (DEBUG == false)
            // set up in-game purchases
           InGamePurchasesAsync();

                LooneyInvaders.Model.PurchaseManager.PurchaseHandler = purchaseProduct;
                LooneyInvaders.Model.VibrationManager.VibrationHandler = Vibrate;
#endif

            LooneyInvaders.Model.LeaderboardManager.SubmitScoreHandler = submitScore;
            LooneyInvaders.Model.LeaderboardManager.RefreshLeaderboardsHandler = refreshLeaderboardsAsync;

            // social network sharing
            LooneyInvaders.Model.SocialNetworkShareManager.ShareOnSocialNetwork = ShareOnSocialNetworkHandler;

            // user management
            LooneyInvaders.Model.UserManager.UsernameGUIDInsertHandler = UsernameGUIDInsertHandler;
            LooneyInvaders.Model.UserManager.CheckIsUsernameFreeHandler = CheckIsUsernameFree;
            LooneyInvaders.Model.UserManager.ChangeUsernameHandler = ChangeUsername;

            if (!LooneyInvaders.Model.UserManager.IsUserGUIDSet) LooneyInvaders.Model.UserManager.GenerateGUID();

            // start the game
            CCGameView gameView = (CCGameView)FindViewById(Resource.Id.GameView);
            gameView.ViewCreated += GameDelegate.LoadGame;
        }

        //In-Game Purchases
        private async Task InGamePurchasesAsync()
        {
            svc = new PurchaseService(API_KEY);
            await svc.Init(this);
            Task<bool> svcResume = svc.Resume();
            if (svcResume != null) await svcResume;
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
            catch (System.Net.WebException webex)
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

        private void Vibrate(object sender, EventArgs e)
        {
            Vibrator vibrator = (Vibrator)this.GetSystemService(Context.VibratorService);
            vibrator.Vibrate(500);
        }

        private float _yaw = 0;
        private float _tilt = 0;
        private float _pitch = 0;

        void getGyro(ref float yaw, ref float tilt, ref float pitch)
        {
            yaw = _yaw;
            tilt = _tilt;
            pitch = (float)Math.Round(_pitch, 3);
        }

        void ISensorEventListener.OnAccuracyChanged(Sensor sensor, SensorStatus accuracy)
        {

        }

        private ScreenOrientation GetScreenOrientation()
        {
            ScreenOrientation orientation;
            SurfaceOrientation rotation = WindowManager.DefaultDisplay.Rotation;

            Android.Util.DisplayMetrics dm = new Android.Util.DisplayMetrics();
            WindowManager.DefaultDisplay.GetMetrics(dm);

            if ((rotation == SurfaceOrientation.Rotation0 || rotation == SurfaceOrientation.Rotation180) && dm.HeightPixels > dm.WidthPixels
                || (rotation == SurfaceOrientation.Rotation90 || rotation == SurfaceOrientation.Rotation270) && dm.WidthPixels > dm.HeightPixels)
            {
                // The device's natural orientation is portrait
                switch (rotation)
                {
                    case SurfaceOrientation.Rotation0:
                        orientation = ScreenOrientation.Portrait;
                        break;
                    case SurfaceOrientation.Rotation90:
                        orientation = ScreenOrientation.Landscape;
                        break;
                    case SurfaceOrientation.Rotation180:
                        orientation = ScreenOrientation.ReversePortrait;
                        break;
                    case SurfaceOrientation.Rotation270:
                        orientation = ScreenOrientation.ReverseLandscape;
                        break;
                    default:
                        orientation = ScreenOrientation.Portrait;
                        break;
                }
            }
            else
            {
                // The device's natural orientation is landscape or if the device is square
                switch (rotation)
                {
                    case SurfaceOrientation.Rotation0:
                        orientation = ScreenOrientation.Landscape;
                        break;
                    case SurfaceOrientation.Rotation90:
                        orientation = ScreenOrientation.Portrait;
                        break;
                    case SurfaceOrientation.Rotation180:
                        orientation = ScreenOrientation.ReverseLandscape;
                        break;
                    case SurfaceOrientation.Rotation270:
                        orientation = ScreenOrientation.ReversePortrait;
                        break;
                    default:
                        orientation = ScreenOrientation.Landscape;
                        break;
                }
            }

            return orientation;
        }

        protected float[] lowPass(float[] input, float[] output)
        {
            if (output == null) return input;
            for (int i = 0; i < input.Length; i++)
            {
                output[i] = output[i] + 0.2f * (input[i] - output[i]);
            }
            return output;
        }

        protected float[] gravSensorVals;
        protected float[] magSensorVals;

        void ISensorEventListener.OnSensorChanged(SensorEvent e)
        {
            float[] vals = new float[e.Values.Count];
            int i = 0;
            foreach (float f in e.Values) vals[i++] = f;
            if (e.Sensor.Type == SensorType.Accelerometer)
            {
                gravSensorVals = lowPass(vals, gravSensorVals);
            }
            else if (e.Sensor.Type == SensorType.MagneticField)
            {
                magSensorVals = lowPass(vals, magSensorVals);
            }
            if (gravSensorVals != null && magSensorVals != null)
            {
                float[] R = new float[9];
                float[] I = new float[9];
                bool success = SensorManager.GetRotationMatrix(R, I, gravSensorVals, magSensorVals);
                if (success)
                {
                    float[] orientationData = new float[3];
                    SensorManager.GetOrientation(R, orientationData);
                    if (GetScreenOrientation() == ScreenOrientation.ReverseLandscape)
                    {
                        //azimuth = orientationData[0];
                        _pitch = (float)(orientationData[1] * 180 / Math.PI) + 180;
                        //roll = orientationData[2];
                    }
                    else
                    {
                        //azimuth = orientationData[0];
                        _pitch = (float)(orientationData[1] * 180 / Math.PI);
                        //roll = orientationData[2];
                    }
                }

            }
            //fallback if no mag sensor to work just with gravity
            else if (e.Sensor.Type == SensorType.Accelerometer)
            {
                float y = e.Values[1];
                if (y > 10) y = 10;
                if (y < -10) y = -10;
                if (GetScreenOrientation() == ScreenOrientation.ReverseLandscape)
                {
                    _pitch = (float)(Math.Asin(y / 10) * 180 / Math.PI);
                }
                else
                {
                    _pitch = -(float)(Math.Asin(y / 10) * 180 / Math.PI);
                }

            }


            /*
            float[] rotationMatrix = new float[16];
            float[] orientation = new float[3];

            float[] values = new float[3];
            values[0] = e.Values[0];
            values[1] = e.Values[1];
            values[2] = e.Values[2];
          

            SensorManager.GetRotationMatrixFromVector(rotationMatrix, values);
            SensorManager.GetOrientation(rotationMatrix, orientation);

            //_yaw = (float) (orientation[0] * 180 / Math.PI) + 90;
            //_pitch = (float) (-orientation[2] * 180 / Math.PI) - 90;
            //_tilt = (float) (-orientation[1] * 180 / Math.PI);



            if (GetScreenOrientation() == ScreenOrientation.ReverseLandscape)
            {

                _pitch = (float)(-orientation[1] * 180 / Math.PI);
            }
            else
            {
                _pitch = (float)(-orientation[1] * 180 / Math.PI) + 180;
            }
            */
        }

        protected override void OnPostResume()
        {
            base.OnPostResume();

            if (_adBanner != null) _adBanner.Resume();
            CCGameView gameView = (CCGameView)FindViewById(Resource.Id.GameView);
            if (gameView != null)
                gameView.Paused = false;

            Sensor acc = sensorManager.GetDefaultSensor(SensorType.Accelerometer);
            sensorManager.RegisterListener(this, acc, SensorDelay.Game);
            Sensor mag = sensorManager.GetDefaultSensor(SensorType.MagneticField);
            sensorManager.RegisterListener(this, mag, SensorDelay.Game);

            try
            {
                if (!String.IsNullOrWhiteSpace(music))
                    CCAudioEngine.SharedEngine.PlayBackgroundMusic(music, true);
            }
            catch (Exception ex)
            {
                var t = ex;
            }
        }

        string music = String.Empty;

        protected override void OnPause()
        {
            if (_adBanner != null) _adBanner.Pause();
            CCGameView gameView = (CCGameView)FindViewById(Resource.Id.GameView);
            if (gameView != null)
                gameView.Paused = true;

            sensorManager.UnregisterListener(this);

            music = GameEnvironment.MusicPlaying;
            CCAudioEngine.SharedEngine?.StopBackgroundMusic();
            if (!_isAdsShoving)
                Settings.Instance.TimeWhenPageAdsLeaved = DateTime.Now;
            _isAdsShoving = false;

            //---------- Prabhjot ---------//
            NotificationCenterManager.Instance.PostNotification(@"GameInBackground");

            base.OnPause();
        }

        public void ShowBannerTop()
        {
            this.RunOnUiThread(new Action(showBannerTopUIThread));
        }

        private void showBannerTopUIThread()
        {
            _adBanner.SetY(0);
            _adBanner.SetX(0);
            _adBanner.Visibility = ViewStates.Visible;
            _adBanner.BringToFront();
        }

        public void ShowBannerBottom()
        {
            this.RunOnUiThread(new Action(showBannerBottomUIThread));
        }

        private void showBannerBottomUIThread()
        {
            Android.Graphics.Point size = new Android.Graphics.Point();
            this.WindowManager.DefaultDisplay.GetRealSize(size);

            _adBanner.SetY(size.Y - _adBanner.AdSize.GetHeightInPixels(Application.Context));
            //_adBanner.SetX( size.X /2  - _adBanner.AdSize.GetWidthInPixels(Application.Context) / 2);
            _adBanner.SetX(0);

            _adBanner.Visibility = ViewStates.Visible;
            _adBanner.BringToFront();
        }

        public void HideBanner()
        {
            this.RunOnUiThread(new Action(hideBannerUIThread));
        }

        private void hideBannerUIThread()
        {
            _adBanner.Visibility = ViewStates.Invisible;
        }

        private bool _isAdsShoving;

        public void ShowInterstitial()
        {
            _isAdsShoving = true;
            Settings.Instance.TimeWhenPageAdsLeaved = default(DateTime);
            this.RunOnUiThread(new Action(showInterstitialUIThread));
        }

        private void showInterstitialUIThread()
        {
            if (_intAd.IsLoaded) _intAd.Show();
        }

        public void HideInterstitial()
        {
            this.RunOnUiThread(new Action(hideInterstitialUIThread));
        }

        private void hideInterstitialUIThread()
        {
            FindViewById(Resource.Id.GameView).BringToFront();
        }

        public void LoadInterstitial()
        {
            this.RunOnUiThread(new Action(LoadInterstitialUIThread));
        }

        private void LoadInterstitialUIThread()
        {
            _intAd = new InterstitialAd(Application.Context);
            _intAd.AdUnitId = "ca-app-pub-5373308786713201/3641230573";
            _intAd.AdListener = new AdListenerInterstitial(_intAd, this);

            var requestbuilder = new AdRequest.Builder();
            requestbuilder.AddTestDevice(AdRequest.DeviceIdEmulator);
            requestbuilder.AddTestDevice("C663A5E7C7E3925C26A199E85E3E39D6");
            _intAd.LoadAd(requestbuilder.Build());
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Android.Content.Intent data)
        {
            if (svc != null) (svc as PurchaseService).HandleActivityResult(requestCode, resultCode, data);
        }

        protected override void OnDestroy()
        {
            if (svc != null)
            {
                svc.Dispose();
                svc = null;
            }

            base.OnDestroy();
        }

        async Task MakePurchase(IProduct product)
        {
            try
            {
                var purchase = await svc.Purchase(product);

                if (purchase.Status == TransactionStatus.Purchased)
                {
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
            this.RunOnUiThread(new Action(() => purchaseItem(productId)));

            return true;
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
            catch (App42NotFoundException nfe) { }
            catch (System.Net.WebException webex)
            {
                return null;
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

                try
                {
                    scoreBoardService.SaveUserScore("Looney Earth Daily", Player.Instance.Name, gameScoreRegular);
                    scoreBoardService.SaveUserScore("Looney Earth Weekly", Player.Instance.Name, gameScoreRegular);
                    scoreBoardService.SaveUserScore("Looney Earth Monthly", Player.Instance.Name, gameScoreRegular);
                    scoreBoardService.SaveUserScore("Looney Earth Alltime", Player.Instance.Name, gameScoreRegular);
                }
                catch (Exception ex)
                {
                    var t = ex;
                }

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
            catch (App42NotFoundException nfe) { }
            catch (Exception ex)
            {
                var t = 1;
            }
        }

        public override void OnBackPressed()
        {
            GameDelegate.FireBackButtonPressed();
        }

        private async void refreshLeaderboardsAsync(LooneyInvaders.Model.Leaderboard leaderboard)
        {
            await Task.Run(() => refreshLeaderboards(leaderboard));
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

            this.RunOnUiThread(new Action(fireLeaderboardRefreshed));
        }

        private void fireLeaderboardRefreshed()
        {
            LeaderboardManager.FireOnLeaderboardsRefreshed();
        }

        private static Java.IO.File StoreScreenShot(Bitmap picture)
        {
            var folder = Android.OS.Environment.ExternalStorageDirectory + Java.IO.File.Separator + "LooneyInvaders";
            var extFileName = Android.OS.Environment.ExternalStorageDirectory +
            Java.IO.File.Separator +
            Guid.NewGuid() + ".jpeg";
            try
            {
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                Java.IO.File file = new Java.IO.File(extFileName);

                using (var fs = new FileStream(extFileName, FileMode.OpenOrCreate))
                {
                    try
                    {
                        picture.Compress(Bitmap.CompressFormat.Jpeg, 100, fs);
                    }
                    finally
                    {
                        fs.Flush();
                        fs.Close();
                    }
                    return file;
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message.ToString());
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message.ToString());
                return null;
            }
        }

        public void ShareOnSocialNetworkHandler(string network, System.IO.Stream stream)
        {
            stream.Position = 0;

            var drawable = Android.Graphics.Drawables.Drawable.CreateFromStream(stream, "looney");
            Android.Graphics.Bitmap bitmap = ((Android.Graphics.Drawables.BitmapDrawable)drawable).Bitmap;

            Java.IO.File file = StoreScreenShot(bitmap);
            if (file == null) return;

            this.RunOnUiThread(new Action(() => ShareOnSocialNetwork(network, file)));
        }

        public void ShareOnSocialNetwork(string network, Java.IO.File file)
        {
            Android.Net.Uri uri = Android.Net.Uri.FromFile(file);
            Intent i = new Intent(Intent.ActionSend);

            // if (network == "facebook") i.SetPackage("com.facebook.katana");
            // else if (network == "twitter") i.SetPackage("com.twitter.android");
            // else return;

            i.AddFlags(ActivityFlags.GrantReadUriPermission);
            i.PutExtra(Intent.ExtraSubject, "Looney Invaders score");
            i.PutExtra(Intent.ExtraText, "Looney Invaders score");
            i.PutExtra(Intent.ExtraStream, uri);
            i.SetType("image/*");

            try
            {
                this.StartActivity(Intent.CreateChooser(i, "Looney Invaders score"));
            }
            catch (ActivityNotFoundException ex)
            {
                Toast.MakeText(this, "No App Available", ToastLength.Long).Show();
            }
        }
    }
}


