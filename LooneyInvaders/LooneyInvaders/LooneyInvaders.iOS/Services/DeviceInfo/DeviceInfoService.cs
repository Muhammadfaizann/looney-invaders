using LooneyInvaders.iOS.Services.DeviceInfo;
using LooneyInvaders.Model;
using UIKit;

namespace LooneyInvaders.DeviceInfo
{
    public class DeviceInfoService : IDeviceInfoService
    {
        public DeviceInfoModel GetDeviceInfo()
        {
            var osVersion = $"{UIDevice.CurrentDevice.SystemName} {UIDevice.CurrentDevice.SystemVersion}";
            var imei = UIDevice.CurrentDevice.IdentifierForVendor ?? new Foundation.NSUuid("-");
            var model = DeviceHardware.Model ?? "-";

            var deviceInfo = new DeviceInfoModel()
            {
                Imei = imei.Description,
                Software = osVersion,
                DeviceModel = model
            };

            return deviceInfo;
        }
    }
}