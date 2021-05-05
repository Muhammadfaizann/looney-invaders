using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Telephony;
using LooneyInvaders.Droid.Extensions;
using LooneyInvaders.Model;
using LooneyInvaders.Services.DeviceInfo;
using ActivityCompat = Android.Support.V4.App.ActivityCompat;
using ContextCompat = Android.Support.V4.Content.ContextCompat;
using MPermission = Android.Manifest.Permission;

namespace LooneyInvaders.DeviceInfo
{
    public class DeviceInfoService : IDeviceInfoService
    {
        private readonly Activity activity;

        public DeviceInfoService() { }

        public DeviceInfoService(Activity activity)
        {
            this.activity = activity;
        }

        public DeviceInfoModel GetDeviceInfo()
        {
            const string none = "-";
            var androidID = Android.Provider.Settings.Secure.GetString(activity.ApplicationContext.ContentResolver, Android.Provider.Settings.Secure.AndroidId);
            var osVersion = "Android " + (Build.VERSION.Release ?? none);
            var manufacturer = Build.Manufacturer;
            var model = Build.Model;

            var mTelephonyMgr = (TelephonyManager)activity.ApplicationContext.GetSystemService(Android.Content.Context.TelephonyService);
            var imei = (Build.VERSION.SdkInt <= BuildVersionCodes.LollipopMr1)
                ? (mTelephonyMgr?.DeviceId ?? none)
                : (ContextCompat.CheckSelfPermission(activity, MPermission.ReadPhoneState) == Permission.Granted)
                    ? (Build.VERSION.SdkInt < BuildVersionCodes.O)
                        ? (mTelephonyMgr?.DeviceId ?? none)
                        : (mTelephonyMgr?.Imei ?? none)
                    : none.WithAction(async () => await activity.RunOnUiThreadAsync(() =>
                    {
                        var dialogBuilder = new AlertDialog.Builder(activity);
                        dialogBuilder.SetTitle("Warning");
                        dialogBuilder.SetMessage("You'll be asked to grant managing your phone info (as calls) or not.\n" +
                            "This data is used just for drawing graph with your phone ID as a name.\n" +
                            "No user data will be collected or stolen.");
                        dialogBuilder.SetPositiveButton("Ok", handler: (s, ea) => ActivityCompat.RequestPermissions(activity, new string[] { MPermission.ReadPhoneState }, 1488));
                        dialogBuilder.Create().Show();
                    }));

            var deviceInfo = new DeviceInfoModel
            {
                Imei = imei,
                Software = osVersion,
                DeviceModel = $"{System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(manufacturer.ToLower())} {model}"
            };

            return deviceInfo;
        }
    }
}
