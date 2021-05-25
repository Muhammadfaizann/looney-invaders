using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Android.App;
using Android.OS;
using LooneyInvaders.Droid.Extensions;
using LooneyInvaders.Services.Permissions;
using static Android.Content.PM.Permission;
using ActivityCompat = Android.Support.V4.App.ActivityCompat;
using ContextCompat = Android.Support.V4.Content.ContextCompat;
using Permission = Android.Manifest.Permission;
using Main = LooneyInvaders.Droid.MainActivity;

namespace LooneyInvaders.Permissions
{
    /// <summary>
    /// You should provide all permissions at a time - the first one will be asked otherwise
    /// </summary>
    public class PermissionService : IPermissionService
    {
        public class PermissionQuest // All crucial info about permission.
        {
            public string Permission { get; set; }
            public string Explanation { get; set; }
            public bool Asked { get; set; }

            public PermissionQuest(string p, string explanation, bool asked)
            {
                Permission = p; Explanation = explanation; Asked = asked;
            }
        }

        private int RequestCode = new System.Random().Next(new System.Random().Next(), int.MaxValue);

        private readonly Activity activity;

        public readonly List<PermissionQuest> AndroidPermissionsAndExplanations = new List<PermissionQuest> {
            new PermissionQuest(Permission.ReadExternalStorage, "access to your files - to show your game score, without grant that can't be done;\n", false),
            new PermissionQuest(Permission.WriteExternalStorage, "access to your files - to save your game score, without grant that can't be done;\n", false),
            new PermissionQuest(Permission.AccessCoarseLocation, "access your location - for analytics service or ads service proper work, " +
                "you can discard to avoid analytics work - the app is just a game and doesn't collect any user data;\n", false)};

        public PermissionService(Activity activity)
        {
            this.activity = activity;
        }

        public void GetPermissions()
        {
            _ = GetPermissions(AndroidPermissionsAndExplanations.ToArray());
        }

        public async Task GetPermissions(params PermissionQuest[] permissionQuests)
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.M)
            {
                // We have all required permissions confirmed on app install.
                return;
            }

            List<PermissionQuest> nonGrantedPermissions = new List<PermissionQuest>();
            List<PermissionQuest> nonGrantedRequestRequiredPermissions = new List<PermissionQuest>();

            foreach (var quest in permissionQuests)
            {
                if (ContextCompat.CheckSelfPermission(activity, quest.Permission) != (int)Granted)
                {
                    // We don't have permission.
                    // If necessary display rationale &request.
                    if (ActivityCompat.ShouldShowRequestPermissionRationale(activity, quest.Permission))
                    {
                        // Provide an additional rationale to the user if the permission was not granted
                        // and the user would benefit from additional context for the use of the permission.
                        // For example if the user has previously denied the permission.
                        nonGrantedRequestRequiredPermissions.Add(quest);
                    }
                    else nonGrantedPermissions.Add(quest); // this list and requestRequired list must be disjoint
                }
            }

            if (nonGrantedRequestRequiredPermissions.Count > 0)
            {
                // Show an explanation to the user *asynchronously* -- don't block
                // this thread waiting for the user's response. After the user
                // sees the explanation, try again to request the permission.
                var explanations = "";
                nonGrantedRequestRequiredPermissions.ForEach(q => explanations += q.Explanation);

                var title = $"You need to grant that required permissions to use full functionality of the game";
                var explanation = $"For example: {explanations}\nPlease read our privacy policy.";
                var iconPaths = Main.IconAppName.Trim('@').Split('/', System.StringSplitOptions.RemoveEmptyEntries).ToList();

                await activity.RunOnUiThreadAsync(() =>
                {   // we can use another user dialog type to inform user
                    var dialogBuilder = new AlertDialog.Builder(activity);
                    dialogBuilder.SetTitle(title);
                    dialogBuilder.SetMessage(explanation);
                    dialogBuilder.SetIcon(activity.GetDrawable(activity.Resources.GetIdentifier(iconPaths.LastOrDefault() ?? "", iconPaths.FirstOrDefault() ?? "", activity.PackageName)));
                    dialogBuilder.SetPositiveButton("Ok", handler: (s, ea) => RequestPermissions(nonGrantedRequestRequiredPermissions));
                    dialogBuilder.Create().Show();
                });
                await Task.Run(() => { });
            }

            if (nonGrantedPermissions.Count > 0)
            {
                await activity.RunOnUiThreadAsync(() => RequestPermissions(nonGrantedPermissions));
            }

            void RequestPermissions(List<PermissionQuest> quests) =>
                ActivityCompat.RequestPermissions(activity,
                    quests.Select(p => p.Permission).ToArray(),
                    RequestCode++);
        }
    }
}
