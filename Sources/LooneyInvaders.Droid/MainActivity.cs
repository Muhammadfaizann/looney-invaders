using System;
using System.IO;
using System.Collections.Generic;
using Android.Graphics;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Hardware;
using CocosSharp;
using LooneyInvaders.Shared;
using Android.Gms.Ads;
using CC.Mobile.Purchases;
using System.Threading.Tasks;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.game;
using com.shephertz.app42.paas.sdk.csharp.storage;
using LooneyInvaders.Model;
using Microsoft.AppCenter.Push;
using Microsoft.AppCenter;
using LooneyInvaders.Services.PNS;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Analytics;
using NotificationCenter;
using LaunchMode = Android.Content.PM.LaunchMode;

namespace LooneyInvaders.Droid
{
    [BroadcastReceiver(Enabled = true)]
    [IntentFilter(new[] { Intent.ActionUserPresent })]
    public class UserPresentReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            if (MainActivity.Instance == null) return;

            if (MainActivity.Instance.AdBanner != null) MainActivity.Instance.AdBanner.Resume();
            var gameView = (CCGameView)MainActivity.Instance.FindViewById(Resource.Id.GameView);
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
        //public const string HOCKEYAPP_KEY = "9316a9e8222e467a8fdc7ffc7e7c2f21";

        public static MainActivity Instance;

        private const string ApiKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA0Hv7vhVm/h274S6ok1M1cm+mGUMVzk3OK/rNIG07bvMaLCPXmHpidGCqs8/IaWlnfpsEuny0eZuAYzrpiupi+OvSEX+gqjVLvExh1yh+qOQvXhvwS6YbAl+czFxdMS0Tb6LtJ5dcUDoLJR+oLpV63+SCU9hdL0yP9gm87zxPAF0KalEA72Wr3pyRMdzeD6nZy/3gDJq9CDxMyyo695TvPt5AEeeDJIcIifA/XV0Z9wtnFWWGCmPuX+ZN99CojG2HaXnBg65TuqNal8S9z5IACxkSGbe3CKzwbYZmuvBiF8TXX+5y0u1f44eoiwg2JKkOmc5F9OxlX6BVX+SAxn4/wwIDAQAB";
        //const string API_KEY = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAgeKpYmhtzBDiUXng7xxSw8GBUrkMsjdxWjb4tutL7t0Ms+zNa9e5Et3QlwSVr9Fusn15Wfc9C01cQkLMRRmwcdtR4sGbEwyk127RfdW2/iWYRDP2CypIQj0uApwg3Uay24mjQNnSphXG2KXC+Olv/ZnU7KCamnPlcGngX596ZjKluInnn4ZTqZdNM1nCfJyLxsFA7sWbttyYKHR6i0fNbdKon0SJ2CY/KuA6H1E0MMuaEvm6keS59bP3FWlbNsaT3lw4RFoT40cYa8lgzNeS5Y2GXXYAHdZQj6d4dPSErjevloRf/h7V6CZBrbGRZBMfWn5PZamg0P0d5I0ewMZ/FQIDAQAB";        
        private IPurchaseService _svc;

        public AdView AdBanner;
        private InterstitialAd _intAd;

        // Facebook
        //const string FacebookAppId = "487297588275151";
        //string userToken;

        // Client used to interact with Google APIs.
        //GoogleApiClient _mGoogleApiClient;
        private SensorManager _sensorManager;

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

        protected override void OnNewIntent(Intent intent)
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
            MobileAds.Initialize(this, "ca-app-pub-5373308786713201~4768370178");

            HockeyAppInit();
            SetSessionInfo();
            CheckNotificationPremissions();
            //toGetPermissionsForStorage();

            // ErrorReport crashReport = Crashes.GetLastSessionCrashReportAsync();
            base.OnCreate(bundle);
            Instance = this;
            // remove navigation bar
            var decorView = Window.DecorView;
            var uiOptions = (int)decorView.SystemUiVisibility;
            var newUiOptions = uiOptions;
            newUiOptions |= (int)SystemUiFlags.HideNavigation;
            newUiOptions |= (int)SystemUiFlags.ImmersiveSticky;
            newUiOptions |= (int)SystemUiFlags.Fullscreen;
            decorView.SystemUiVisibility = (StatusBarVisibility)newUiOptions;

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // add gyro
            GameDelegate.GetGyro = GetGyro;
            _sensorManager = (SensorManager)GetSystemService(SensorService);
            /*Sensor gyro = sm.GetDefaultSensor(SensorType.RotationVector);
            sm.RegisterListener(this, gyro, SensorDelay.Game);*/

            // connect to AdMob
            var size = new Point();
            WindowManager.DefaultDisplay.GetRealSize(size);

            AdBanner = new AdView(Application.Context);
            AdBanner.AdSize = AdSize.SmartBanner;
            AdBanner.AdUnitId = "ca-app-pub-5373308786713201/9938442971"; // Android
            //_adBanner.AdUnitId = "ca-app-pub-5373308786713201/3891909370";   // iOS
            AdBanner.Id = 999;
            AdBanner.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.MatchParent);
            var adParams = new ViewGroup.LayoutParams(size.X, AdBanner.AdSize.GetHeightInPixels(Application.Context));
            AdBanner.SetY(0);
            AdBanner.SetX(0);

            var requestbuilder = new AdRequest.Builder();
            requestbuilder.AddTestDevice(AdRequest.DeviceIdEmulator);
            requestbuilder.AddTestDevice("C663A5E7C7E3925C26A199E85E3E39D6"); // Client Device
            //requestbuilder.AddTestDevice("03DFB7A18513DDF6BDB8533960DADD46"); // My Device

            AdBanner.LoadAd(requestbuilder.Build());

            AdBanner.Visibility = ViewStates.Invisible;

            AddContentView(AdBanner, adParams);
            AdBanner.AdListener = new AdListenerEx(AdBanner);

            AdMobManager.ShowBannerTopHandler = ShowBannerTop;
            AdMobManager.ShowBannerBottomHandler = ShowBannerBottom;
            AdMobManager.HideBannerHandler = HideBanner;
            AdMobManager.LoadInterstitialHandler = LoadInterstitial;
            AdMobManager.ShowInterstitialHandler = ShowInterstitial;
            AdMobManager.HideInterstitialHandler = HideInterstitial;

            LoadInterstitial();

            // set up in-game purchases
            InGamePurchasesAsync();

            PurchaseManager.PurchaseHandler = PurchaseProduct;
            VibrationManager.VibrationHandler = Vibrate;

            LeaderboardManager.SubmitScoreHandler = SubmitScoreAsync;
            LeaderboardManager.RefreshLeaderboardsHandler = RefreshLeaderboards;

            // social network sharing
            SocialNetworkShareManager.ShareOnSocialNetwork = ShareOnSocialNetworkHandler;

            // user management
            Model.UserManager.UsernameGuidInsertHandler = UsernameGUIDInsertHandler;
            Model.UserManager.CheckIsUsernameFreeHandler = CheckIsUsernameFree;
            Model.UserManager.ChangeUsernameHandler = ChangeUsername;

            if (!Model.UserManager.IsUserGuidSet) Model.UserManager.GenerateGuid();

            // start the game
            var gameView = (CCGameView)FindViewById(Resource.Id.GameView);
            gameView.ViewCreated += GameDelegate.LoadGame;
        }

        /* private void toGetPermissionsForStorage()
         {
             if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReadExternalStorage) == (int)Android.Content.PM.Permission.Granted &&
                 ContextCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) == (int)Android.Content.PM.Permission.Granted)
             {
                 // We have permission, go ahead and use the camera.
             }
             else
             {
                 // Camera permission is not granted. If necessary display rationale & request.
                 if (ActivityCompat.ShouldShowRequestPermissionRationale(this, Manifest.Permission.ReadExternalStorage))
                 {
                     // Provide an additional rationale to the user if the permission was not granted
                     // and the user would benefit from additional context for the use of the permission.
                     // For example if the user has previously denied the permission.
                     Console.WriteLine("Displaying camera permission rationale to provide additional context.");

                     var requiredPermissions = new System.String[] { Manifest.Permission.ReadExternalStorage };
                     Snackbar.Make(Layout,
                                    Resource.String.permission_location_rationale,
                                    Snackbar.LengthIndefinite)
                             .SetAction(Resource.String.ok,
                                        new Action<View>(delegate (View obj) {
                                            ActivityCompat.RequestPermissions(this, requiredPermissions, REQUEST_LOCATION);
                                        }
                             )
                     ).Show();
                 }
                 else
                 {
                     ActivityCompat.RequestPermissions(this, new System.String[] { Manifest.Permission.ReadExternalStorage }, REQUEST_LOCATION);
                 }
             }
         }*/

        // Storage Permissions



        //In-Game Purchases
        private async void InGamePurchasesAsync()
        {
            _svc = new PurchaseService(ApiKey);
            await _svc.Init(this);
            var svcResume = _svc.Resume();
            if (svcResume != null)
                await svcResume;
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

            Model.UserManager.UserGuid = guid;
            Player.Instance.Name = playerName;

            json = "{\"name\":\"a" + playerName.ToUpper() + "\",\"guid\":\"" + guid + "\"}";
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
                if (jsonDocList[0].GetJsonDoc().Contains(Model.UserManager.UserGuid)) return true; // this user
            }
            catch (App42NotFoundException)
            {
                return true;
            }
            catch (System.Net.WebException)
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
            var guid = Model.UserManager.UserGuid;

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
                Model.UserManager.GenerateGuid();

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

        private void Vibrate(object sender, EventArgs e)
        {
            var vibrator = (Vibrator)GetSystemService(VibratorService);
            vibrator.Vibrate(VibrationEffect.CreateOneShot(500, 10));
        }

        private const float Yaw = 0;
        private const float Tilt = 0;
        private float _pitch;

        private void GetGyro(out float yaw, out float tilt, out float pitch)
        {
            yaw = Yaw;
            tilt = Tilt;
            pitch = (float)Math.Round(_pitch, 3);
        }

        void ISensorEventListener.OnAccuracyChanged(Sensor sensor, SensorStatus accuracy)
        {

        }

        private ScreenOrientation GetScreenOrientation()
        {
            ScreenOrientation orientation;
            var rotation = WindowManager.DefaultDisplay.Rotation;

            var dm = new Android.Util.DisplayMetrics();
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

        protected float[] LowPass(float[] input, float[] output)
        {
            if (output == null) return input;
            for (var i = 0; i < input.Length; i++)
            {
                output[i] = output[i] + 0.2f * (input[i] - output[i]);
            }
            return output;
        }

        protected float[] GravSensorVals;
        protected float[] MagSensorVals;

        void ISensorEventListener.OnSensorChanged(SensorEvent e)
        {
            var vals = new float[e.Values.Count];
            var i = 0;
            foreach (var f in e.Values) vals[i++] = f;
            if (e.Sensor.Type == SensorType.Accelerometer)
            {
                GravSensorVals = LowPass(vals, GravSensorVals);
            }
            else if (e.Sensor.Type == SensorType.MagneticField)
            {
                MagSensorVals = LowPass(vals, MagSensorVals);
            }
            if (GravSensorVals != null && MagSensorVals != null)
            {
                var r = new float[9];
                var I = new float[9];
                var success = SensorManager.GetRotationMatrix(r, I, GravSensorVals, MagSensorVals);
                if (success)
                {
                    var orientationData = new float[3];
                    SensorManager.GetOrientation(r, orientationData);
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
                var y = e.Values[1];
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

            AdBanner?.Resume();
            var gameView = (CCGameView)FindViewById(Resource.Id.GameView);
            if (gameView != null)
                gameView.Paused = false;

            var acc = _sensorManager.GetDefaultSensor(SensorType.Accelerometer);
            _sensorManager.RegisterListener(this, acc, SensorDelay.Game);
            var mag = _sensorManager.GetDefaultSensor(SensorType.MagneticField);
            _sensorManager.RegisterListener(this, mag, SensorDelay.Game);

            try
            {
                if (!string.IsNullOrWhiteSpace(_music))
                    CCAudioEngine.SharedEngine.PlayBackgroundMusic(_music, true);
            }
            catch (Exception)
            {
                //var t = ex;
            }
        }

        private string _music = string.Empty;

        protected override void OnPause()
        {
            AdBanner?.Pause();
            var gameView = (CCGameView)FindViewById(Resource.Id.GameView);
            if (gameView != null)
                gameView.Paused = true;

            _sensorManager.UnregisterListener(this);

            _music = GameEnvironment.MusicPlaying;
            CCAudioEngine.SharedEngine?.StopBackgroundMusic();
            if (!_isAdsShoving)
                Settings.Instance.TimeWhenPageAdsLeaved = DateTime.Now;
            _isAdsShoving = false;


            // ----------- Prabhjot ----------- //

            if (Settings.IsFromGameScreen)
            {
                NotificationCenterManager.Instance.PostNotification(@"GameInBackground");
            }

            base.OnPause();
        }

        public void ShowBannerTop()
        {
            RunOnUiThread(ShowBannerTopUiThread);
        }

        private void ShowBannerTopUiThread()
        {
            AdBanner.SetY(0);
            AdBanner.SetX(0);
            AdBanner.Visibility = ViewStates.Visible;
            AdBanner.BringToFront();
        }

        public void ShowBannerBottom()
        {
            RunOnUiThread(ShowBannerBottomUiThread);
        }

        private void ShowBannerBottomUiThread()
        {
            var size = new Point();
            WindowManager.DefaultDisplay.GetRealSize(size);

            AdBanner.SetY(size.Y - AdBanner.AdSize.GetHeightInPixels(Application.Context));
            //_adBanner.SetX( size.X /2  - _adBanner.AdSize.GetWidthInPixels(Application.Context) / 2);
            AdBanner.SetX(0);

            AdBanner.Visibility = ViewStates.Visible;
            AdBanner.BringToFront();
        }

        public void HideBanner()
        {
            RunOnUiThread(HideBannerUiThread);
        }

        private void HideBannerUiThread()
        {
            AdBanner.Visibility = ViewStates.Invisible;
        }

        private bool _isAdsShoving;

        public void ShowInterstitial()
        {
            _isAdsShoving = true;
            Settings.Instance.TimeWhenPageAdsLeaved = default(DateTime);
            RunOnUiThread(ShowInterstitialUiThread);
        }

        private void ShowInterstitialUiThread()
        {
            if (_intAd.IsLoaded) _intAd.Show();
        }

        public void HideInterstitial()
        {
            RunOnUiThread(HideInterstitialUiThread);
        }

        private void HideInterstitialUiThread()
        {
            FindViewById(Resource.Id.GameView).BringToFront();
        }

        public void LoadInterstitial()
        {
            RunOnUiThread(LoadInterstitialUiThread);
        }

        private void LoadInterstitialUiThread()
        {
            _intAd = new InterstitialAd(Application.Context);
            _intAd.AdUnitId = "ca-app-pub-5373308786713201/3641230573";
            _intAd.AdListener = new AdListenerInterstitial(_intAd, this);

            var requestbuilder = new AdRequest.Builder();
            requestbuilder.AddTestDevice(AdRequest.DeviceIdEmulator);
            requestbuilder.AddTestDevice("C663A5E7C7E3925C26A199E85E3E39D6"); // Client Device
            //requestbuilder.AddTestDevice("03DFB7A18513DDF6BDB8533960DADD46"); //MY device
            _intAd.LoadAd(requestbuilder.Build());
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            (_svc as PurchaseService)?.HandleActivityResult(requestCode, resultCode, data);
        }

        protected override void OnDestroy()
        {
            if (_svc != null)
            {
                _svc.Dispose();
                _svc = null;
            }

            base.OnDestroy();
        }

        private async Task MakePurchase(IProduct product)
        {
            try
            {
                var purchase = await _svc.Purchase(product);

                if (purchase.Status == TransactionStatus.Purchased)
                {
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
            catch (App42NotFoundException)
            { }
            catch (System.Net.WebException)
            {
                return null;
            }
            return null;
        }

        private async Task SubmitScoreAsync(double score, double accuracy, double fastestTime, double levelsCompleted)
        {
            var looneyEarthNames = ("Looney Earth Daily", "Looney Earth Weekly", "Looney Earth Monthly", "Looney Earth Alltime" );
            var looneyMoonNames = ("Looney Moon Daily", "Looney Moon Weekly", "Looney Moon Monthly", "Looney Moon Alltime");

            if (Math.Abs(levelsCompleted + 1) < AppConstants.Tolerance) // regular scoreboard
            {
                LeaderboardManager.PlayerRankRegularDaily = null;
                LeaderboardManager.PlayerRankRegularWeekly = null;
                LeaderboardManager.PlayerRankRegularMonthly = null;
                LeaderboardManager.PlayerRankRegularAlltime = null;

                try
                {
                    await ScoreBoard.ScoreBoardService.SaveUserScoreForGamesAsync(Player.Instance.Name,
                        LeaderboardManager.EncodeScoreRegular(score, fastestTime, accuracy),
                        TimeSpan.FromMilliseconds(500),
                        looneyEarthNames.Item1,
                        looneyEarthNames.Item2,
                        looneyEarthNames.Item3,
                        looneyEarthNames.Item4);
               
                    LeaderboardManager.PlayerRankRegularDaily = GetPlayerRanking(ScoreBoard.ScoreBoardService.Instance,
                        looneyEarthNames.Item1, LeaderboardType.Regular);
                    LeaderboardManager.PlayerRankRegularWeekly = GetPlayerRanking(ScoreBoard.ScoreBoardService.Instance,
                        looneyEarthNames.Item2, LeaderboardType.Regular);
                    LeaderboardManager.PlayerRankRegularMonthly = GetPlayerRanking(ScoreBoard.ScoreBoardService.Instance,
                        looneyEarthNames.Item3, LeaderboardType.Regular);
                    LeaderboardManager.PlayerRankRegularAlltime = GetPlayerRanking(ScoreBoard.ScoreBoardService.Instance,
                        looneyEarthNames.Item4, LeaderboardType.Regular);
                }
                catch (Exception ex)
                {
                    var mess = ex.Message;
                }
            }
            else
            {
                LeaderboardManager.PlayerRankProDaily = null;
                LeaderboardManager.PlayerRankProWeekly = null;
                LeaderboardManager.PlayerRankProMonthly = null;
                LeaderboardManager.PlayerRankProAlltime = null;

                try
                {
                    await ScoreBoard.ScoreBoardService.SaveUserScoreForGamesAsync(Player.Instance.Name,
                        LeaderboardManager.EncodeScorePro(score, levelsCompleted),
                        TimeSpan.FromMilliseconds(25),
                        looneyMoonNames.Item1,
                        looneyMoonNames.Item2,
                        looneyMoonNames.Item3,
                        looneyMoonNames.Item4);
                
                    LeaderboardManager.PlayerRankProDaily = GetPlayerRanking(ScoreBoard.ScoreBoardService.Instance,
                        looneyMoonNames.Item1, LeaderboardType.Pro);
                    LeaderboardManager.PlayerRankProWeekly = GetPlayerRanking(ScoreBoard.ScoreBoardService.Instance,
                        looneyMoonNames.Item2, LeaderboardType.Pro);
                    LeaderboardManager.PlayerRankProMonthly = GetPlayerRanking(ScoreBoard.ScoreBoardService.Instance,
                        looneyMoonNames.Item3, LeaderboardType.Pro);
                    LeaderboardManager.PlayerRankProAlltime = GetPlayerRanking(ScoreBoard.ScoreBoardService.Instance,
                        looneyMoonNames.Item4, LeaderboardType.Pro);
                }
                catch (Exception ex)
                {
                    var mess = ex.Message;
                }
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

                            if (type == LeaderboardType.Regular)
                                lbi = LeaderboardManager.DecodeScoreRegular(i + 1, game.GetScoreList()[i].GetUserName(), game.GetScoreList()[i].GetValue());
                            else if (type == LeaderboardType.Pro)
                                lbi = LeaderboardManager.DecodeScorePro(i + 1, game.GetScoreList()[i].GetUserName(), game.GetScoreList()[i].GetValue());

                            if (lbi != null) scoreList.Add(lbi);
                        }
                    }
                }
            }
            catch (App42NotFoundException)
            {

            }
            catch (Exception)
            {
                //var t = 1;
            }
        }

        public override void OnBackPressed()
        {
            GameDelegate.FireBackButtonPressed();

        }

        private void RefreshLeaderboards(Leaderboard leaderboard)
        {
            string gameName;
            switch (leaderboard.Type)
            {
                case LeaderboardType.Regular: gameName = "Looney Earth";
                    break;
                case LeaderboardType.Pro: gameName = "Looney Moon";
                    break;
                default: return;
            }

            FillLeaderboard(ScoreBoard.ScoreBoardService.Instance, leaderboard.Type, leaderboard.ScoreDaily, gameName + " Daily");
            FillLeaderboard(ScoreBoard.ScoreBoardService.Instance, leaderboard.Type, leaderboard.ScoreWeekly, gameName + " Weekly");
            FillLeaderboard(ScoreBoard.ScoreBoardService.Instance, leaderboard.Type, leaderboard.ScoreMonthly, gameName + " Monthly");
            FillLeaderboard(ScoreBoard.ScoreBoardService.Instance, leaderboard.Type, leaderboard.ScoreAllTime, gameName + " Alltime");

            if (leaderboard.Type == LeaderboardType.Regular)
            {
                LeaderboardManager.PlayerRankRegularDaily = GetPlayerRanking(ScoreBoard.ScoreBoardService.Instance, "Looney Earth Daily", LeaderboardType.Regular);
                LeaderboardManager.PlayerRankRegularWeekly = GetPlayerRanking(ScoreBoard.ScoreBoardService.Instance, "Looney Earth Weekly", LeaderboardType.Regular);
                LeaderboardManager.PlayerRankRegularMonthly = GetPlayerRanking(ScoreBoard.ScoreBoardService.Instance, "Looney Earth Monthly", LeaderboardType.Regular);
                //LooneyInvaders.Model.LeaderboardManager.PlayerRankRegularAlltime = getPlayerRanking(scoreBoardService, "Looney Earth Alltime", LooneyInvaders.Model.LeaderboardType.REGULAR);
            }
            else if (leaderboard.Type == LeaderboardType.Pro)
            {
                LeaderboardManager.PlayerRankProDaily = GetPlayerRanking(ScoreBoard.ScoreBoardService.Instance, "Looney Moon Daily", LeaderboardType.Pro);
                LeaderboardManager.PlayerRankProWeekly = GetPlayerRanking(ScoreBoard.ScoreBoardService.Instance, "Looney Moon Weekly", LeaderboardType.Pro);
                LeaderboardManager.PlayerRankProMonthly = GetPlayerRanking(ScoreBoard.ScoreBoardService.Instance, "Looney Moon Monthly", LeaderboardType.Pro);
                //LooneyInvaders.Model.LeaderboardManager.PlayerRankProAlltime = getPlayerRanking(scoreBoardService, "Looney Moon Alltime", LooneyInvaders.Model.LeaderboardType.PRO);
            }

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

                var file = new Java.IO.File(extFileName);

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
                Console.WriteLine("ERROR: " + ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                return null;
            }
        }

        public void ShareOnSocialNetworkHandler(string network, Stream stream)
        {
            stream.Position = 0;

            var drawable = Android.Graphics.Drawables.Drawable.CreateFromStream(stream, "looney");
            var bitmap = ((Android.Graphics.Drawables.BitmapDrawable)drawable).Bitmap;

            var file = StoreScreenShot(bitmap);
            if (file == null) return;

            RunOnUiThread(() => ShareOnSocialNetwork(network, file));
        }

        public void ShareOnSocialNetwork(string network, Java.IO.File file)
        {
            var uri = Android.Net.Uri.FromFile(file);
            var i = new Intent(Intent.ActionSend);

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
                StartActivity(Intent.CreateChooser(i, "Looney Invaders score"));
            }
            catch (ActivityNotFoundException)
            {
                Toast.MakeText(this, "No App Available", ToastLength.Long).Show();
            }
        }
    }
}