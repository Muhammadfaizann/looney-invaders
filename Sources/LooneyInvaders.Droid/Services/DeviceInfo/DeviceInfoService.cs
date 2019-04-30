using Android.OS;
using Android.Telephony;
using LooneyInvaders.Model;
using LooneyInvaders.Droid;

namespace LooneyInvaders.DeviceInfo
{
    public class DeviceInfoService : IDeviceInfoService
    {
        public DeviceInfoModel GetDeviceInfo()
        {
            var androidID = Android.Provider.Settings.Secure.GetString(MainActivity.Instance.ApplicationContext.ContentResolver, Android.Provider.Settings.Secure.AndroidId);
			var osVersion = "Android " + (Build.VERSION.Release ?? "-");
            var manufacturer = Build.Manufacturer;
            var model = Build.Model;

            var mTelephonyMgr = (TelephonyManager)MainActivity.Instance.ApplicationContext.GetSystemService(Android.Content.Context.TelephonyService);
            var imei = Build.VERSION.SdkInt < BuildVersionCodes.O ? mTelephonyMgr.DeviceId ?? "-" : mTelephonyMgr.Imei;

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
