using System;
using System.IO;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Gms.Ads;
using Android.Graphics;
using Android.Hardware;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CC.Mobile.Purchases;
using CocosSharp;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Push;
using NotificationCenter;
using LooneyInvaders.Droid.Extensions;
using LooneyInvaders.Model;
using LooneyInvaders.Services.App42;
using LooneyInvaders.Services.PNS;
using LooneyInvaders.Shared;
using LaunchMode = Android.Content.PM.LaunchMode;
using Debug = System.Diagnostics.Debug;

namespace LooneyInvaders.Droid
{
    public class CustomExceptionHandler : Java.Lang.Object, Java.Lang.Thread.IUncaughtExceptionHandler
    {
        public void UncaughtException(Java.Lang.Thread t, Java.Lang.Throwable e)
        {
            Tracer.Trace($"{e.Message} {e.StackTrace}");
        }
    }

    [Activity(
        Label = "Looney Invaders",
        MainLauncher = true,
        Icon = "@drawable/icon",
        Theme = "@android:style/Theme.Holo.NoActionBar.Fullscreen",
        AlwaysRetainTaskState = true,
        LaunchMode = LaunchMode.SingleTop,
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden,
        ScreenOrientation = ScreenOrientation.SensorLandscape)]
    public class MainActivity : Activity, ISensorEventListener, IApp42ServiceInitialization
    {
        public static MainActivity Instance;

        public CCGameView GameView;

        public Action CheckGamePauseState;

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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            ////for analytics
            var counter = GameDelegate.Counter;
            var maxTime = GameDelegate.MaxTime;
            var timer = GameDelegate.Timer;
            timer?.Start();
            ////
            AppDomain.CurrentDomain.UnhandledException += (sender, e) => Tracer.Trace($"{e.ExceptionObject.ToString()}");
            TaskScheduler.UnobservedTaskException += (sender, e) => Tracer.Trace($"{e.Exception?.Message} {e.Exception?.StackTrace}");
            AndroidEnvironment.UnhandledExceptionRaiser += (sender, e) => Tracer.Trace($"{e.Exception?.Message} {e.Exception?.StackTrace}");
            Java.Lang.Thread.DefaultUncaughtExceptionHandler = new CustomExceptionHandler();
            //---------- Prabhjot ---------//
            AppCenter.LogLevel = LogLevel.Verbose;
            AppCenter.Start("51b755ae-47b2-472a-b134-ea89837cad38",
                    typeof(Analytics), typeof(Crashes));
            Crashes.SetEnabledAsync(true);
            MobileAds.Initialize(this, "ca-app-pub-5373308786713201~4768370178");
            CallInitOnApp42ServiceBuilder();
            SetSessionInfo();
            CheckNotificationPremissions();
            //toGetPermissionsForStorage();
            Tracer.Title = "LaunchingAppTime(ms)";
            TrackTime();
            // ErrorReport crashReport = Crashes.GetLastSessionCrashReportAsync();
            base.OnCreate(savedInstanceState);
            Instance = this;
            TrackTime();
            // remove navigation bar
            var decorView = Window.DecorView;
            var newUiOptions = (int)decorView.SystemUiVisibility;
            newUiOptions |= (int)SystemUiFlags.HideNavigation;
            newUiOptions |= (int)SystemUiFlags.ImmersiveSticky;
            newUiOptions |= (int)SystemUiFlags.Fullscreen;
            decorView.SystemUiVisibility = (StatusBarVisibility)newUiOptions;

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            TrackTime();
            // add gyro
            GameDelegate.GetGyro = GetGyro;
            _sensorManager = (SensorManager)GetSystemService(SensorService);
            /*Sensor gyro = sm.GetDefaultSensor(SensorType.RotationVector);
            sm.RegisterListener(this, gyro, SensorDelay.Game);*/

            // clearing on iOS does not properly work
            GameDelegate.UseAnimationClearing = true;
            GameDelegate.UpdateGameView = UpdateGameViewState;

            var designedSize = new Point();
            WindowManager.DefaultDisplay.GetSize(designedSize);
            if (designedSize.X > 0)
                GameDelegate.DesignSize.Width = designedSize.X;
            if (designedSize.Y > 0)
                GameDelegate.DesignSize.Height = designedSize.Y;
            TrackTime();
            // connect to AdMob
            var size = new Point();
            WindowManager.DefaultDisplay.GetRealSize(size);
            TrackTime();
            var requestbuilder = new AdRequest.Builder();
            requestbuilder.AddTestDevice(AdRequest.DeviceIdEmulator);
            requestbuilder.AddTestDevice("C663A5E7C7E3925C26A199E85E3E39D6"); // Client Device
            //requestbuilder.AddTestDevice("03DFB7A18513DDF6BDB8533960DADD46"); // My Device
            TrackTime();
            AdBanner = new AdView(Application.Context)
            {
                AdSize = AdSize.SmartBanner,
                AdUnitId = "ca-app-pub-5373308786713201/9938442971", // Android
                //AdUnitId = "ca-app-pub-5373308786713201/3891909370";   // iOS
                Id = 999,
                LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.MatchParent)
            };
            TrackTime();
            AdBanner.SetY(0);
            AdBanner.SetX(0);
            AdBanner.LoadAd(requestbuilder.Build());
            AdBanner.ChangeVisibility(ViewStates.Invisible);
            AdBanner.AdListener = new AdListenerEx(AdBanner);
            TrackTime();
            var adParams = new ViewGroup.LayoutParams(size.X, AdBanner.AdSize.GetHeightInPixels(Application.Context));
            AddContentView(AdBanner, adParams);
            TrackTime();
            AdMobManager.ShowBannerTopHandler = ShowBannerTop;
            AdMobManager.ShowBannerBottomHandler = ShowBannerBottom;
            AdMobManager.HideBannerHandler = HideBanner;
            AdMobManager.LoadInterstitialHandler = LoadInterstitial;
            AdMobManager.ShowInterstitialHandler = ShowInterstitial;
            AdMobManager.HideInterstitialHandler = HideInterstitial;
            TrackTime();
            LoadInterstitial();
            TrackTime();
            // set up in-game purchases
            InGamePurchasesAsync();
            TrackTime();
            PurchaseManager.PurchaseHandler = PurchaseProduct;
            VibrationManager.VibrationHandler = Vibrate;
            LeaderboardManager.SubmitScoreHandler = SubmitScoreAsync;
            LeaderboardManager.RefreshLeaderboardsHandler = RefreshLeaderboards;

            // social network sharing
            SocialNetworkShareManager.ShareOnSocialNetwork = ShareOnSocialNetworkHandler;
            TrackTime();
            // user management
            Model.UserManager.UsernameGuidInsertHandler = UsernameGUIDInsertHandler;
            Model.UserManager.CheckIsUsernameFreeHandler = CheckIsUsernameFree;
            Model.UserManager.ChangeUsernameHandler = ChangeUsername;
            TrackTime();
            Task.Run(() => Model.UserManager.GenerateGuid()).ConfigureAwait(false);
            // start the game
            GameView = (CCGameView)FindViewById(Resource.Id.GameView) ?? GameView;
            //GameView.RenderOnUIThread = true;
            GameView.ViewCreated += GameDelegate.LoadGame;
            TrackTime();
            GameDelegate.Counter = counter;

            void TrackTime()
            {
                if (timer != null)
                    Tracer.TrackerAppendUntil($"{(++counter).ToString("D4")}-{timer.ElapsedMilliseconds}");
            }
        }

        public void CallInitOnApp42ServiceBuilder()
        {
            App42ServiceBuilder.Init(GameConstants.App42.ApiKey, GameConstants.App42.SecretKey, 300);
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

        public override void OnTrimMemory([GeneratedEnum] TrimMemory level)
        {
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            if (level != TrimMemory.Complete)
            {
                Java.Lang.JavaSystem.Gc();
            }
            base.OnTrimMemory(level);
        }

        //In-Game Purchases
        private async void InGamePurchasesAsync()
        {
            try
            {
                _svc = new PurchaseService(ApiKey);

                await _svc.Init(this);
                var svcResume = _svc.Resume();
                if (svcResume != null)
                    await svcResume;
            }
            catch (Exception ex)
            {
                var mess = ex.Message;
            }
        }

        private Task<bool> UsernameGUIDInsertHandler(string guid)
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

        public void UpdateGameViewState(bool isPaused)
        {
            UpdateGameViewStateUIThread(isPaused);
        }

        private void UpdateGameViewStateUIThread(bool isPaused)
        {
            GameView = GameDelegate.GameView;
            try
            {
                if (!isPaused)
                {
                    RunOnUiThread(() =>
                    {
                        GameView.Paused = isPaused;
                    });
                    CheckGamePauseState = new Action(() =>
                    {
                        if (((GameDelegate.Layer as Classes.CCLayerColorExt)?.Enabled).GetValueOrDefault()
                            && (GameView?.Paused).GetValueOrDefault())
                            RunOnUiThread(() =>
                            {
                                GameView.Paused = false;
                            });
                    });
                }
                else
                {
                    CheckGamePauseState = null;
                    GameView.MobilePlatformUpdatePaused();
                }
            }
            catch (Exception ex)
            {
                var mess = ex.Message;
                Debug.WriteLine($"FaultOn_{nameof(UpdateGameViewStateUIThread)}: {mess}");
            }
        }

        private void Vibrate(object sender, EventArgs e)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var vibrator = (Vibrator)GetSystemService(VibratorService);
                vibrator.Vibrate(VibrationEffect.CreateOneShot(500, 10));
            }
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
            CheckGamePauseState?.Invoke();

            ScreenOrientation orientation;
            var rotation = WindowManager?.DefaultDisplay?.Rotation;

            var dm = new Android.Util.DisplayMetrics();
            WindowManager?.DefaultDisplay?.GetMetrics(dm);

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
            if (input == null)
            { return null; }
            if (output == null)
            { return input; }
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
            if (e == null || e.Sensor == null)
            {
                return;
            }
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

            } //fallback if no mag sensor to work just with gravity
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
            GameDelegate.LoadGame(null, null);

            var acc = _sensorManager.GetDefaultSensor(SensorType.Accelerometer);
            _sensorManager.RegisterListener(this, acc, SensorDelay.Game);
            var mag = _sensorManager.GetDefaultSensor(SensorType.MagneticField);
            _sensorManager.RegisterListener(this, mag, SensorDelay.Game);

            //if (!string.IsNullOrWhiteSpace(_music))
                //CCAudioEngine.SharedEngine.PlayBackgroundMusic(_music, true);
        }

        protected override void OnPause()
        {
            base.OnPause();

            AdBanner?.Pause();
            GameDelegate.StopGame();

            _sensorManager.UnregisterListener(this);

            //_music = GameEnvironment.MusicPlaying;
            //CCAudioEngine.SharedEngine?.StopBackgroundMusic();
            if (!_isAdsShoving)
                Settings.Instance.TimeWhenPageAdsLeaved = DateTime.Now;
            _isAdsShoving = false;

            if (Settings.IsFromGameScreen)
            {
                NotificationCenterManager.Instance.PostNotification(@"GameInBackground");
            }
        }

        public void ShowBannerTop()
        {
            RunOnUiThread(ShowBannerTopUiThread);
        }

        private void ShowBannerTopUiThread()
        {
            AdBanner?.SetY(0);
            AdBanner?.SetX(0);
            AdBanner.ChangeVisibility(ViewStates.Visible);
            AdBanner?.BringToFront();
        }

        public void ShowBannerBottom()
        {
            RunOnUiThread(ShowBannerBottomUiThread);
        }

        private void ShowBannerBottomUiThread()
        {
            try
            {
                var size = new Point();
                WindowManager.DefaultDisplay.GetRealSize(size);

                AdBanner?.SetY(size.Y - AdBanner.AdSize.GetHeightInPixels(Application.Context));
                //_adBanner.SetX( size.X /2  - _adBanner.AdSize.GetWidthInPixels(Application.Context) / 2);
                AdBanner?.SetX(0);

                AdBanner.ChangeVisibility(ViewStates.Visible);
                AdBanner?.BringToFront();
            }
            catch (Exception ex)
            {
                var mess = ex.Message;
            }
        }

        public void HideBanner()
        {
            RunOnUiThread(HideBannerUiThread);
        }

        private void HideBannerUiThread()
        {
            AdBanner?.ChangeVisibility(ViewStates.Invisible);
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
            if (_intAd.IsLoaded && !Settings.IsFromGameScreen)
                _intAd.Show();
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

            if (GameView != null)
            {
                GameView.ViewCreated -= GameDelegate.LoadGame;
            }
            Java.Lang.Thread.DefaultUncaughtExceptionHandler = null;

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
            catch (PurchaseError ex)
            {
                Console.WriteLine($"Error with {product}:{ex.Message}");
                PurchaseManager.FireOnPurchaseFinished();
            }
        }

        private async Task<bool> PurchaseProduct(string productId)
        {
            await MakePurchase(new Product(productId))
                .ConfigureAwait(false);
            return true;
        }

        private async Task SubmitScoreAsync(double score, double accuracy, double fastestTime, double levelsCompleted)
        {
            await App42.ScoreBoardService.Instance.SubmitScore(score, accuracy, fastestTime, levelsCompleted);
        }

        public override void OnBackPressed()
        {
            GameDelegate.FireBackButtonPressed();
        }

        private void RefreshLeaderboards(Leaderboard leaderboard)
        {
            App42.ScoreBoardService.Instance.RefreshLeaderboards(leaderboard);
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
            try
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

                StartActivity(Intent.CreateChooser(i, "Looney Invaders score"));
            }
            catch (ActivityNotFoundException)
            {
                Toast.MakeText(this, "No App Available", ToastLength.Long).Show();
            }
            catch (Exception ex)
            {
                var mess = ex.Message;
            }
        }
    }
}
