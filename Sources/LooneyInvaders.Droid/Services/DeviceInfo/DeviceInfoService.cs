using System;
using Android;
using Android.Content.PM;
using Android.OS;
using Android.Telephony;
using Android.Widget;
using LooneyInvaders.Droid;
using LooneyInvaders.Droid.Extensions;
using LooneyInvaders.Model;
using ActivityCompat = Android.Support.V4.App.ActivityCompat;
using ContextCompat = Android.Support.V4.Content.ContextCompat;

namespace LooneyInvaders.DeviceInfo
{
    public class DeviceInfoService : IDeviceInfoService
    {
        public DeviceInfoModel GetDeviceInfo()
        {
            const string none = "-";
            var androidID = Android.Provider.Settings.Secure.GetString(MainActivity.Instance.ApplicationContext.ContentResolver, Android.Provider.Settings.Secure.AndroidId);
			var osVersion = "Android " + (Build.VERSION.Release ?? none);
            var manufacturer = Build.Manufacturer;
            var model = Build.Model;

            var mTelephonyMgr = (TelephonyManager)MainActivity.Instance.ApplicationContext.GetSystemService(Android.Content.Context.TelephonyService);
            var imei = (Build.VERSION.SdkInt <= BuildVersionCodes.LollipopMr1)
                ? (mTelephonyMgr?.DeviceId ?? none)
                : (ContextCompat.CheckSelfPermission(MainActivity.Instance, Manifest.Permission.ReadPhoneState) == Permission.Granted)
                    ? (Build.VERSION.SdkInt < BuildVersionCodes.O)
                        ? (mTelephonyMgr?.DeviceId ?? none)
                        : (mTelephonyMgr?.Imei ?? none)
                    : none.WithAction(() => RequestPermission(Manifest.Permission.ReadPhoneState));

            var deviceInfo = new DeviceInfoModel
            {
                Imei = imei,
                Software = osVersion,
                DeviceModel = $"{System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(manufacturer.ToLower())} {model}"
            };

            return deviceInfo;
        }

        private void RequestPermission(string permission)
        {
            var permissions = new string[]{ permission };
            try
            {
                ActivityCompat.RequestPermissions(MainActivity.Instance, permissions, 1);
            }
            catch (Exception ex)
            {
                var mess = ex.Message;
                Toast.MakeText(MainActivity.Instance, "Unknown error", ToastLength.Short);
            }
        }
    }
}
