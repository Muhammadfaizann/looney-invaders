using LooneyInvaders.Model;
using Microsoft.AppCenter;

using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

using Microsoft.AppCenter.Push;

namespace LooneyInvaders.PNS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    public class PushNotificationService
    {
        public bool CheckDoesNeedAskPremission()
        {
            var sessionsCount = Settings.Instance.GetSessionsCount();
            var sessionDuration = Settings.Instance.GetTodaySessionDuration();
            bool isAskForN = false;

            switch (sessionsCount)
            {
                case 1:
                    {
                        if (sessionDuration >= 5 * 60)
                        {
                            isAskForN = true;
                        }
                        break;
                    }
                case 2:
                case 3:
                    {
                        if (sessionDuration >= 3 * 60)
                        {
                            isAskForN = true;
                        }
                        break;
                    }
                case 7:
                    {
                        if (sessionDuration >= 1 * 60)
                        {
                            isAskForN = true;
                        }
                        break;
                    }
                case 15:
                    {
                        if (sessionDuration >= 1 * 60)
                        {
                            isAskForN = true;
                        }
                        break;
                    }
            }

            if (Settings.Instance.IsPushNotificationEnabled)
            {
                isAskForN = false;
            }

            return isAskForN;
        }

        public void AskForPremissons()
        {
            string keyForNotification;

#if __IOS__
            keyForNotification = "4cd7f485-df2b-40b9-ad4c-f9e08623a548";
#endif
#if __ANDROID__
            keyForNotification = "51b755ae-47b2-472a-b134-ea89837cad38";
            Settings.Instance.IsPushNotificationEnabled = true;
#endif

            AppCenter.Start(keyForNotification, typeof(Push), typeof(Crashes), typeof(Analytics));
        }
    }


}