using Foundation;
using UIKit;

namespace LooneyInvaders.PNS
{
    public class OpenSettingsService : IOpenSettingsService
    {
        public void OpenNotificationSettings()
        {
			var notifUrl = new NSUrl("prefs:root=NOTIFICATIONS_ID");
            if (UIApplication.SharedApplication.CanOpenUrl(notifUrl))
            {   //Pre iOS 10
                UIApplication.SharedApplication.OpenUrl(notifUrl);
            }
            else
            {   //iOS 10
				UIApplication.SharedApplication.OpenUrl(new NSUrl("App-Prefs:root=NOTIFICATIONS_ID"));
            }
        }
    }
}
