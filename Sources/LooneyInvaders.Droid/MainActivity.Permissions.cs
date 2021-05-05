using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Hardware;
using Android.Runtime;
using LooneyInvaders.Model;
using LooneyInvaders.Services.App42;
using LooneyInvaders.Services.PNS;
using LooneyInvaders.Shared;

namespace LooneyInvaders.Droid
{
    public partial class MainActivity : Activity, ISensorEventListener, IApp42ServiceInitialization
    {
        private void CheckNotificationPremissions()
        {
            var notificationsAllowed = new NotificationAllowedService();
            var res = notificationsAllowed.IsNotificationsAllowed();
            Settings.Instance.IsPushNotificationEnabled = res;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            List<string> nonGrantedPermissions = new List<string>();

            for (int i = 0; i < permissions.Length; ++i)
            {
                if (grantResults[i] == Permission.Denied)
                {
                    nonGrantedPermissions.Add(permissions[i]);
                }
            }
            var permissionService = GameDelegate.PermissionService as Permissions.PermissionService;
            var permissionQuestsNeedToAsk = permissionService?.AndroidPermissionsAndExplanations?.Where(pq =>
            {
                return nonGrantedPermissions.Contains(pq.Permission) && pq.Asked == false;
            })?.ToList();

            if (permissionQuestsNeedToAsk == null)
            {
                return;
            }
            permissionQuestsNeedToAsk.ForEach(p => p.Asked = true); // we need to ask all

            _ = Task.Run(async () => await permissionService.GetPermissions(permissionQuestsNeedToAsk.ToArray()));

            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }
        }
    }
}
