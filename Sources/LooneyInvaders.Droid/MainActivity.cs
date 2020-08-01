using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.Hardware;
using Android.OS;
using Android.Runtime;
using Android.Views;
using CC.Mobile.Purchases;
using CocosSharp;
using Com.Appodeal.Ads;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Push;
using NotificationCenter;
using Debug = System.Diagnostics.Debug;
using CCLayerColorExt = LooneyInvaders.Classes.CCLayerColorExt;
using JavaThread = Java.Lang.Thread;
using LaunchMode = Android.Content.PM.LaunchMode;
using LooneyInvaders.Droid.Helpers;
using LooneyInvaders.Model;
using LooneyInvaders.Services.App42;
using LooneyInvaders.Services.PNS;
using LooneyInvaders.Shared;

/* //probably future setting
Configure R8 to complete successfully despite warnings

Add a new text file to the project, named for example proguard-rules.pro.
Set the contents of the file to: -ignorewarnings

This changes R8’s behavior so that it will complete successfully even it encounters warnings like “Missing class: java.lang.ClassValue.”
When using R8 for multidex only and not code shrinking, this approach should work correctly, as long as the app was working correctly in the previous Xamarin.Android version when using multidex.

Edit the .csproj file in a text editor and add --pg-conf proguard-rules.pro to the AndroidR8ExtraArguments MSBuild property, for example by adding the following lines:

    <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
        <AndroidR8ExtraArguments>--pg-conf proguard-rules.pro</AndroidR8ExtraArguments>
    </PropertyGroup>
*/
//[assembly: UsesLibrary("org.apache.http.legacy", false)]
namespace LooneyInvaders.Droid
{
    public class CustomExceptionHandler : Java.Lang.Object, JavaThread.IUncaughtExceptionHandler
    {
        public void UncaughtException(JavaThread t, Java.Lang.Throwable e)
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
    public partial class MainActivity : Activity, ISensorEventListener, IApp42ServiceInitialization, IInterstitialCallbacks, IBannerCallbacks
    {
        private const string ApiKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA0Hv7vhVm/h274S6ok1M1cm+mGUMVzk3OK/rNIG07bvMaLCPXmHpidGCqs8/IaWlnfpsEuny0eZuAYzrpiupi+OvSEX+gqjVLvExh1yh+qOQvXhvwS6YbAl+czFxdMS0Tb6LtJ5dcUDoLJR+oLpV63+SCU9hdL0yP9gm87zxPAF0KalEA72Wr3pyRMdzeD6nZy/3gDJq9CDxMyyo695TvPt5AEeeDJIcIifA/XV0Z9wtnFWWGCmPuX+ZN99CojG2HaXnBg65TuqNal8S9z5IACxkSGbe3CKzwbYZmuvBiF8TXX+5y0u1f44eoiwg2JKkOmc5F9OxlX6BVX+SAxn4/wwIDAQAB";
        //const string API_KEY = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAgeKpYmhtzBDiUXng7xxSw8GBUrkMsjdxWjb4tutL7t0Ms+zNa9e5Et3QlwSVr9Fusn15Wfc9C01cQkLMRRmwcdtR4sGbEwyk127RfdW2/iWYRDP2CypIQj0uApwg3Uay24mjQNnSphXG2KXC+Olv/ZnU7KCamnPlcGngX596ZjKluInnn4ZTqZdNM1nCfJyLxsFA7sWbttyYKHR6i0fNbdKon0SJ2CY/KuA6H1E0MMuaEvm6keS59bP3FWlbNsaT3lw4RFoT40cYa8lgzNeS5Y2GXXYAHdZQj6d4dPSErjevloRf/h7V6CZBrbGRZBMfWn5PZamg0P0d5I0ewMZ/FQIDAQAB";

        public CCGameView GameView;
        public Action CheckGamePauseState;

        public void CallInitOnApp42ServiceBuilder() => App42ServiceBuilder.Init(GameConstants.App42.ApiKey, GameConstants.App42.SecretKey, 333);

        private void RefreshLeaderboards(Leaderboard leaderboard) => App42.ScoreBoardService.Instance.RefreshLeaderboards(leaderboard);
        private Task<bool> UsernameGUIDInsertHandler(string guid) => App42.StorageService.Instance.UsernameGUIDInsertHandler(guid);
        private bool CheckIsUsernameFree(string username) => App42.StorageService.Instance.CheckIsUsernameFree(username);
        private bool ChangeUsername(string username) => App42.StorageService.Instance.ChangeUsername(username);

        private void UpdateGameViewState(bool isPaused)
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
                    CheckGamePauseState = new Action(async () =>
                    {
                        if (await isGamePaused(100))
                        {
                            RunOnUiThread(() =>
                            {
                                GameView.Paused = false;
                            });
                        }
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
                Debug.WriteLine($"FaultOn_{nameof(UpdateGameViewState)}: {mess}");
            }

            async Task<bool> isGamePaused(int delayMS)
            {
                if (GameDelegate.IsBusyLayerProperty) { return false; }

                GameDelegate.IsBusyLayerProperty = true;
                await Task.Delay(delayMS);

                var enabled = (GameDelegate.Layer as CCLayerColorExt)?.Enabled == true;
                GameDelegate.IsBusyLayerProperty = false;

                return enabled && GameView?.Paused == true;
            }
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);

            Push.CheckLaunchedFromNotification(this, intent);
        }

        protected override void AttachBaseContext(Context @base) => base.AttachBaseContext(@base);

        public override void OnAttachedToWindow() => base.OnAttachedToWindow();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, e) => Tracer.Trace($"{e.ExceptionObject.ToString()}");
            TaskScheduler.UnobservedTaskException += (sender, e) => Tracer.Trace($"{e.Exception?.Message} {e.Exception?.StackTrace}");
            AndroidEnvironment.UnhandledExceptionRaiser += (sender, e) => Tracer.Trace($"{e.Exception?.Message} {e.Exception?.StackTrace}");
            JavaThread.DefaultUncaughtExceptionHandler = new CustomExceptionHandler();

            AppCenter.LogLevel = LogLevel.Verbose;
            AppCenter.Start("51b755ae-47b2-472a-b134-ea89837cad38", typeof(Analytics), typeof(Crashes));
            Crashes.SetEnabledAsync(true);
            //Helpers.EglHelper.InitEgl();
            AdManager.ShowBannerTopHandler = ShowBannerTop;
            AdManager.ShowBannerBottomHandler = ShowBannerBottom;
            AdManager.HideBannerHandler = HideBanner;
            AdManager.LoadInterstitialHandler = LoadInterstitial;
            AdManager.ShowInterstitialHandler = ShowInterstitial;
            AdManager.HideInterstitialHandler = HideInterstitial;
            Appodeal.SetTesting(false);
            Appodeal.LogLevel = Com.Appodeal.Ads.Utils.Log.LogLevel.Verbose;
            Appodeal.SetBannerAnimation(true);
            Appodeal.SetSmartBanners(true);
            Appodeal.SetAutoCache(requiredAdTypes, false);
            Appodeal.SetAutoCacheNativeIcons(false);
            Appodeal.SetAutoCacheNativeMedia(false);
            //MobileAds.Initialize(this, "ca-app-pub-5373308786713201~4768370178");
            CallInitOnApp42ServiceBuilder();
            SetSessionInfo();
            CheckNotificationPremissions();
            Tracer.Title = "LaunchingAppTime(ms)";
            TrackTime();

            base.OnCreate(savedInstanceState);

            GameDelegate.PermissionService = new Permissions.PermissionService(this);
            GameDelegate.DeviceInfoService = new DeviceInfo.DeviceInfoService(this);
            GameDelegate.OpenSettingsService = new PNS.OpenSettingsService(this);
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

            GameDelegate.CloseAppAllowed = true;
            GameDelegate.CloseApp = CloseActivity;
            // clearing on iOS does not properly work
            GameDelegate.UseAnimationClearing = true;
            GameDelegate.UpdateGameView = UpdateGameViewState;

            var designedSize = new Point();
            WindowManager.DefaultDisplay.GetSize(designedSize);
            if (designedSize.X > 0)
            {
                GameDelegate.DesignSize.Width = designedSize.X;
            }
            if (designedSize.Y > 0)
            {
                GameDelegate.DesignSize.Height = designedSize.Y;
            }
            var size = new Point();
            WindowManager.DefaultDisplay.GetRealSize(size);
            TrackTime();

            AppodealAdsHelper.LoadingPauseMilliseconds = 1500;
            Appodeal.SetInterstitialCallbacks(this);
            Appodeal.SetBannerCallbacks(this);
            Appodeal.Initialize(this, AppodealApiKey, requiredAdTypes);
            Appodeal.Cache(this, requiredAdTypes);
            TrackTime();
            // set up in-game purchases
            InGamePurchasesAsync();
            TrackTime();
            PurchaseManager.PurchaseHandler = PurchaseProduct;
            VibrationManager.VibrationHandler = Vibrate;
            LeaderboardManager.RefreshLeaderboardsHandler = RefreshLeaderboards;
            // social network sharing
            SocialNetworkShareManager.ShareOnSocialNetwork = ShareOnSocialNetworkHandler;
            TrackTime();
            // user management
            Model.UserManager.UsernameGuidInsertHandler = UsernameGUIDInsertHandler;
            Model.UserManager.CheckIsUsernameFreeHandler = CheckIsUsernameFree;
            Model.UserManager.ChangeUsernameHandler = ChangeUsername;
            TrackTime();
            Task.Run(Model.UserManager.GenerateGuid).ConfigureAwait(false);
            TrackTime();
            // start the game
            GameView = (CCGameView)FindViewById(Resource.Id.GameView) ?? GameView;
            //GameView.RenderOnUIThread = true;
            GameView.ViewCreated += GameDelegate.LoadGame;
            TrackTime();
            Debug.WriteLine("Activity created(OnCreate passed)");

            static void TrackTime() { GameDelegate.TrackTime(); }
        }

        protected override void OnPostResume()
        {
            base.OnPostResume();

            GameDelegate.LoadGame(null, null);

            var acc = _sensorManager.GetDefaultSensor(SensorType.Accelerometer);
            _sensorManager.RegisterListener(this, acc, SensorDelay.Game);
            var mag = _sensorManager.GetDefaultSensor(SensorType.MagneticField);
            _sensorManager.RegisterListener(this, mag, SensorDelay.Game);
        }

        protected override void OnPause()
        {
            base.OnPause();

            if ((GameDelegate.Layer is Layers.GamePlayLayer || GameDelegate.Layer is Layers.PauseScreenLayer)
                && IsScreenOn(GetSystemService(PowerService) as PowerManager))
            {
                var layer = GameDelegate.Layer as CCLayerColorExt;
                GameDelegate.IsCartoonFadeInOnLayer = layer.IsCartoonFadeIn;
                layer.IsCartoonFadeIn = false;

                ActivityManager activityManager = ApplicationContext.GetSystemService(ActivityService) as ActivityManager;
                activityManager?.MoveTaskToFront(TaskId, 0);
            }
            else
            {
                GameDelegate.StopGame();
                _sensorManager.UnregisterListener(this);

                if (!_isAdsShoving)
                {
                    Settings.Instance.TimeWhenPageAdsLeaved = DateTime.Now;
                }
                _isAdsShoving = false;

                if (Settings.IsFromGameScreen)
                {
                    NotificationCenterManager.Instance.PostNotification(@"GameInBackground");
                }
            }

            static bool IsScreenOn(PowerManager pm)
            {
                if (pm == null) { return true; }

                if (Build.VERSION.SdkInt > BuildVersionCodes.Kitkat)
                {
                    if (!pm.IsInteractive)
                    {
                        return false;
                    }
                }
                else
                {
    #pragma warning disable CS0618 // Type or member is obsolete
                    if (!pm.IsScreenOn)
    #pragma warning restore CS0618 // Type or member is obsolete
                        return false;
                }

                return true;
            }
        }

        public override void OnBackPressed() => GameDelegate.FireBackButtonPressed();

        public override void OnTrimMemory([GeneratedEnum] TrimMemory level)
        {
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            if (level != TrimMemory.Complete)
            {
                Java.Lang.JavaSystem.Gc();
            }

            base.OnTrimMemory(level);
        }

        public override bool OnKeyDown([GeneratedEnum] Keycode keyCode, KeyEvent e)
        {
            if (((keyCode == Keycode.Home || keyCode == Keycode.MoveHome) &&
                    GameDelegate.Layer is Layers.GamePlayLayer)
                || (keyCode == Keycode.Back &&
                    !(GameDelegate.Layer is Layers.MainScreenLayer)))
            {
                return true;
            }

            return base.OnKeyDown(keyCode, e);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data) =>
            (_svc as PurchaseService)?.HandleActivityResult(requestCode, resultCode, data);

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
            JavaThread.DefaultUncaughtExceptionHandler = null;

            base.OnDestroy();
        }

        private void Vibrate(object sender, EventArgs e)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var vibrator = (Vibrator)GetSystemService(VibratorService);
                vibrator.Vibrate(VibrationEffect.CreateOneShot(500, 10));
            }
        }

        private void CheckNotificationPremissions()
        {
            var notificationsAllowed = new NotificationAllowedService();
            var res = notificationsAllowed.IsNotificationsAllowed();
            Settings.Instance.IsPushNotificationEnabled = res;
        }

        private void SetSessionInfo()
        {
            var count = Settings.Instance.GetSessionsCount();
            Settings.Instance.SetSessionsCount(count + 1);
            Settings.Instance.SetTodaySessionDuration(0, true);
            Settings.Instance.IsAskForNotificationToday = false;
        }

        private void CloseActivity()
        {
            //ToDo: Bass - here's the place to save everything before definetely close the app
            //Quitting guide: https://stackoverflow.com/questions/6330200/how-to-quit-android-application-programmatically
            Debug.WriteLine("quitting game");

            FinishAndRemoveTask();
            FinishAffinity();
            Process.KillProcess(Process.MyPid());
        }
    }
}
