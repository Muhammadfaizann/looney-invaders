using System.Linq;
using Android.App;
using LooneyInvaders.Services.Alerts;
using Main = LooneyInvaders.Droid.MainActivity;

namespace LooneyInvaders.Alerts
{
    public class AlertService : IAlertService
    {
        private readonly Activity _activity;

        public AlertService(Activity activity) => _activity = activity;

        public void ShowAlert(string message)
        {
            //var iconPaths = Main.IconAppName.Trim('@').Split('/', System.StringSplitOptions.RemoveEmptyEntries).ToList();
            _activity.RunOnUiThread(() =>
            {
                var dialogBuilder = new AlertDialog.Builder(_activity);
                dialogBuilder.SetMessage(message);
                //dialogBuilder.SetIcon(_activity.GetDrawable(_activity.Resources.GetIdentifier(iconPaths.LastOrDefault() ?? "", iconPaths.FirstOrDefault() ?? "", _activity.PackageName)));
                dialogBuilder.SetPositiveButton("Ok", handler: (s, ea) => { });
                dialogBuilder.Create().Show();
            });
        }
    }
}
