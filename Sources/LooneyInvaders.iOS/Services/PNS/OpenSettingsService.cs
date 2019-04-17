using Foundation;
using UIKit;

namespace LooneyInvaders.PNS
{
    public class OpenSettingsService : IOpenSettingsService
    {
        public void OpenNotificationSettings()
        {
            var notifyUrl = new NSUrl("prefs:root=NOTIFICATIONS_ID");

            if (!UIApplication.SharedApplication.CanOpenUrl(notifyUrl))
                notifyUrl = new NSUrl("App-Prefs:root=NOTIFICATIONS_ID");

            UIApplication.SharedApplication.OpenUrl(notifyUrl);
        }
    }
}
