using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using LooneyInvaders.Droid;
using LooneyInvaders.Services.Permissions;
using ActivityCompat = Android.Support.V4.App.ActivityCompat;
using ContextCompat = Android.Support.V4.Content.ContextCompat;

namespace LooneyInvaders.Permissions
{
    public class PermissionService : IPermissionService
    {
        private readonly Activity activity;

        private Android.Views.View GameView => (activity as MainActivity)?.GameView;

        public PermissionService(Activity activity)
        {
            this.activity = activity;
        }

        public void GetPermissions()
        {
            GetPermissions(true, Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage);
        }

        private void GetPermissions(bool checkAnyway = false, params string[] permissions)
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.LollipopMr1 && !checkAnyway)
            {
                // We have all required permissions confirmed on app install.
                return;
            }

            foreach (var permission in permissions)
            {
                var requiredPermissions = new string[] { permission };
                if (ContextCompat.CheckSelfPermission(activity, permission) != (int)Permission.Granted)
                {
                    // We don't have permission. If necessary display rationale &request.
                    if (ActivityCompat.ShouldShowRequestPermissionRationale(activity, permission))
                    {
                        // Provide an additional rationale to the user if the permission was not granted
                        // and the user would benefit from additional context for the use of the permission.
                        // For example if the user has previously denied the permission.
                        // Show an explanation to the user *asynchronously* -- don't block
                        // this thread waiting for the user's response! After the user
                        // sees the explanation, try again to request the permission.
                        string explanation = $"{permission} - you need to grant that required permission to use full functionality of this game.";
                        Android.Support.Design.Widget.Snackbar.Make(GameView,
                                    explanation,
                                    Android.Support.Design.Widget.Snackbar.LengthIndefinite)
                                .SetAction("Ok", (view) => ActivityCompat.RequestPermissions(activity, requiredPermissions, permission.GetHashCode()))
                                .Show();
                    }
                    else
                    {
                        ActivityCompat.RequestPermissions(activity, requiredPermissions, permission.GetHashCode());
                    }
                }
            }
        }
    }
}
