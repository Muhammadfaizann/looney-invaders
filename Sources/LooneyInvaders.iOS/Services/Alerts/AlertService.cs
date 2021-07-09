using UIKit;
using LooneyInvaders.Services.Alerts;
using LooneyInvaders.iOS.Extensions;

namespace LooneyInvaders.Alerts
{
    public class AlertService : IAlertService
    {
        public void ShowAlert(string message)
        {
            var alert = UIAlertController.Create("", message, UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Cancel, (_) => { }));

            Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(() => 
                this.GetCurrentViewController().PresentViewController(alert, false, () => { }));
        }
    }
}
