using LooneyInvaders.Model;
using LooneyInvaders.Droid;

namespace LooneyInvaders.DeviceInfo
{
    public class DeviceInfoService : IDeviceInfoService
    {
        public DeviceInfoModel GetDeviceInfo()
        {
            var androidID = Android.Provider.Settings.Secure.GetString(MainActivity.Instance.ApplicationContext.ContentResolver, Android.Provider.Settings.Secure.AndroidId);
			var osVersion = "Android " + (Android.OS.Build.VERSION.Release ?? "-");
            var manufacturer = Android.OS.Build.Manufacturer;
            var model = Android.OS.Build.Model;

            Android.Telephony.TelephonyManager mTelephonyMgr;
            mTelephonyMgr = (Android.Telephony.TelephonyManager)MainActivity.Instance.ApplicationContext.GetSystemService(Android.Content.Context.TelephonyService);
            var imei = mTelephonyMgr.DeviceId ?? "-";

            var deviceInfo = new DeviceInfoModel()
            {
                Imei = imei,
                Software = osVersion,
                DeviceModel = $"{System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(manufacturer.ToLower())} {model}"
            };

            return deviceInfo;
        }
    }
}
