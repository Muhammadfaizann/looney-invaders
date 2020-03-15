using System;
using Android.App;
using Android.Content;
using LooneyInvaders.Services.PNS;

namespace LooneyInvaders.PNS
{
    public class OpenSettingsService : IOpenSettingsService
    {
        private readonly Activity activity;

        public OpenSettingsService() { }

        public OpenSettingsService(Activity activity)
        {
            this.activity = activity;
        }

        public void OpenNotificationSettings()
        {
            try
            {
                activity.StartActivity(new Intent(Android.Provider.Settings.ActionApplicationSettings));
            }
            catch (Exception ex)
            {
                var mess = ex.Message;
            }
        }
    }
}
