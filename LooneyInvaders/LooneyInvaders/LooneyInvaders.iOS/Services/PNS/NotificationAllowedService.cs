using System;
using LooneyInvaders.Model;
using UIKit;

namespace LooneyInvaders.Services.PNS
{
	public class NotificationAllowedService : INotificationAllowedService
	{
		#region -- INotificationAllowedService --   

		public bool IsNotificationsAllowed()
		{
			var res = false;

            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                UIUserNotificationType types = UIApplication.SharedApplication.CurrentUserNotificationSettings.Types;

                System.Diagnostics.Debug.WriteLine("\nIn MyApp.iOS.Implementations.NativeHelper_iOS.PushNotificationAlertsEnabledAsync() - Allowed Push Notification Types: {0}\n", types);

                if (types.HasFlag(UIUserNotificationType.Alert)) { res = true; } //Here I only car about Alerts being enabled but you could check for all or none of them and act accordingly
            }
            else
            {
                UIRemoteNotificationType types = UIApplication.SharedApplication.EnabledRemoteNotificationTypes;

                System.Diagnostics.Debug.WriteLine("\nIn MyApp.iOS.Implementations.NativeHelper_iOS.PushNotificationAlertsEnabledAsync() - Allowed Push Notification Types: {0}\n", types);

                if (types.HasFlag(UIRemoteNotificationType.Alert)) { res = true; } //Here I only car about Alerts being enabled but you could check for all or none of them and act accordingly
            }

            if (res == false)
                Settings.Instance.IsPushNotificationEnabled = res;

			return res;
		}

		#endregion
	}
}
