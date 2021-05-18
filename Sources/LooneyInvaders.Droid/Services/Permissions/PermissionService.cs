using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Support.V4.Content.Res;
using LooneyInvaders.Droid.Extensions;
using LooneyInvaders.Services.Permissions;
using static Android.Content.PM.Permission;
using static Android.Resource.Mipmap;
using ActivityCompat = Android.Support.V4.App.ActivityCompat;
using ContextCompat = Android.Support.V4.Content.ContextCompat;
using Permission = Android.Manifest.Permission;

namespace LooneyInvaders.Permissions
{
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

        private readonly int RequestCode = new System.Random().Next(new System.Random().Next(), int.MaxValue);

        private readonly Activity activity;

        public readonly List<PermissionQuest> AndroidPermissionsAndExplanations = new List<PermissionQuest> {
            new PermissionQuest(Permission.ReadExternalStorage, "access to your files - to show your game score, without grant that can't be done;\n", false),
            new PermissionQuest(Permission.WriteExternalStorage, "access to your files - to save your game score;\n", false),
            new PermissionQuest(Permission.AccessCoarseLocation, "access your location - for analytics service or ads service proper work, " +
                "you can discard to avoid analytics work - the app is just a game and doesn't collect any user data, please read our privacy policy;\n", false)};

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

                var title = $"You need to grant that required permission to use full functionality of the game";
                var explanation = $"For example: {explanations}";

                await activity.RunOnUiThreadAsync(() =>
                {   // we can use another user dialog type to inform user
                    var dialogBuilder = new AlertDialog.Builder(activity);
                    dialogBuilder.SetTitle(title);
                    dialogBuilder.SetMessage(explanation);
                    dialogBuilder.SetIcon(ResourcesCompat.GetDrawable(activity.Resources, Android.Resource.Id.Icon1/*SymDefAppIcon*/, activity.Theme));
                    dialogBuilder.SetPositiveButton("Ok", handler: (s, ea) => RequestPermissions(nonGrantedRequestRequiredPermissions));
                    dialogBuilder.Create().Show();
                });
            }

            if (nonGrantedPermissions.Count > 0)
            {
                await activity.RunOnUiThreadAsync(() => RequestPermissions(nonGrantedPermissions));
            }

            void RequestPermissions(List<PermissionQuest> quests) =>
                ActivityCompat.RequestPermissions(activity,
                    quests.Select(p => p.Permission).ToArray(),
                    RequestCode);
        }
    }
}
