using Foundation;
using UIKit;

namespace LooneyInvaders.PNS
{
    public class OpenSettingsService : IOpenSettingsService
    {
        public void OpenNotificationSettings()
        {
			var notifyUrl = new NSUrl("prefs:root=NOTIFICATIONS_ID");
            if (UIApplication.SharedApplication.CanOpenUrl(notifyUrl))
            {   //Pre iOS 10
                UIApplication.SharedApplication.OpenUrl(notifyUrl);
            }
            else
            {   //iOS 10
				UIApplication.SharedApplication.OpenUrl(new NSUrl("App-Prefs:root=NOTIFICATIONS_ID"));
            }
        }
    }
}
