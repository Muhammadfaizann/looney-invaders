using Android.Support.V4.App;

namespace LooneyInvaders.Services.PNS
{
	public class NotificationAllowedService : INotificationAllowedService
	{
		#region -- INotificationAllowedService --   

		public bool IsNotificationsAllowed()
		{
			var nm = NotificationManagerCompat.From(Android.App.Application.Context);
			var isAllowed = nm.AreNotificationsEnabled();

			return isAllowed && Model.Settings.Instance.IsPushNotificationEnabled;
		}

        #endregion
	}
}
