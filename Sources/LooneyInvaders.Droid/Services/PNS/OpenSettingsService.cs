using Android.Content;
using LooneyInvaders.Droid;

namespace LooneyInvaders.PNS
{
    public class OpenSettingsService : IOpenSettingsService
    {
        public void OpenNotificationSettings()
        {
            MainActivity.Instance.StartActivity(new Intent(Android.Provider.Settings.ActionApplicationSettings));
        }
    }
}
