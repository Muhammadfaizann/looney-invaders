using System;
using Foundation;
using UIKit;
using LooneyInvaders.Model;
using LooneyInvaders.Services.PNS;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Push;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Analytics;
using NotificationCenter;

namespace LooneyInvaders.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations
        public const string HockeyappKey = "7b026ab1c1fd4dc8bea25d9b232d618f";

        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // Override point for customization after application launch.
            // If not required for your application you can safely delete this method         

            CrashAnalyticsAppInit();
            SetSessionInfo();
            CheckNotificationPremissions();

            return true;
        }

        public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
        {
            Push.RegisteredForRemoteNotifications(deviceToken);
        }

        public override void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
        {
            Push.FailedToRegisterForRemoteNotifications(error);
        }

        public override void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
        {
            var result = Push.DidReceiveRemoteNotification(userInfo);
            if (result)
            {
                completionHandler?.Invoke(UIBackgroundFetchResult.NewData);
            }
            else
            {
                completionHandler?.Invoke(UIBackgroundFetchResult.NoData);
            }
        }

        public override void OnResignActivation(UIApplication application)
        {
            // Invoked when the application is about to move from active to inactive state.
            // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
            // or when the user quits the application and it begins the transition to the background state.
            // Games should use this method to pause the game.

            // ----------- Prabhjot ----------- //

            if (Settings.IsFromGameScreen)
            {
                NotificationCenterManager.Instance.PostNotification(@"GameInBackground");
            }

        }

        public override void DidEnterBackground(UIApplication application)
        {
            // Use this method to release shared resources, save user data, invalidate timers and store the application state.
            // If your application supports background exection this method is called instead of WillTerminate when the user quits.

            Settings.Instance.TimeWhenPageAdsLeaved = DateTime.Now;

        }

        public override void WillEnterForeground(UIApplication application)
        {
            // Called as part of the transiton from background to active state.
            // Here you can undo many of the changes made on entering the background.
        }

        public override void OnActivated(UIApplication application)
        {
            // Restart any tasks that were paused (or not yet started) while the application was inactive. 
            // If the application was previously in the background, optionally refresh the user interface.
        }

        public override void WillTerminate(UIApplication application)
        {
            // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
        }

        #region -- Private helpers -- 

        private void CrashAnalyticsAppInit()
        {
            //var manager = HockeyApp.iOS.BITHockeyManager.SharedHockeyManager;
            //manager.Configure(HOCKEYAPP_KEY);
            //manager.StartManager();
            //manager.Authenticator.AuthenticateInstallation();


            //--------- Prabhjot ---------//

            const string keyForNotification = "4cd7f485-df2b-40b9-ad4c-f9e08623a548";

            AppCenter.Start(keyForNotification, typeof(Crashes), typeof(Analytics));
            Crashes.SetEnabledAsync(true);
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
            Settings.Instance.IsPushNotificationEnabled = notificationsAllowed.IsNotificationsAllowed();
        }

        #endregion
    }
}