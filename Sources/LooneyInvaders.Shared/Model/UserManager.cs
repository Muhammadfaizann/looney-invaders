using System;
using Plugin.Settings;

namespace LooneyInvaders.Model
{
    public class UserManager
    {
        public delegate bool UsernameHandlerDelegate(string guid);
        public delegate bool UsernameChangeHandlerDelegate(string userName);

        public static UsernameHandlerDelegate UsernameGuidInsertHandler;
        public static UsernameChangeHandlerDelegate ChangeUsernameHandler;
        public static UsernameChangeHandlerDelegate CheckIsUsernameFreeHandler;

        public static bool IsUserGuidSet => !string.IsNullOrWhiteSpace(CrossSettings.Current.GetValueOrDefault("UserGUID", ""));

        public static string UserGuid
        {
            get => CrossSettings.Current.GetValueOrDefault("UserGUID", "");
            set => CrossSettings.Current.AddOrUpdateValue("UserGUID", value);
        }

        public static void GenerateGuid()
        {
            if (IsUserGuidSet)
                return;
            if (UsernameGuidInsertHandler == null)
                return;
            if (NetworkConnectionManager.IsInternetConnectionAvailable() == false)
                return;

            Console.WriteLine("GenerateGUID()");

            var guid = Guid.NewGuid().ToString();

            UsernameGuidInsertHandler(guid);
        }

        public static bool CheckIsUsernameFree(string userName)
        {
            if (NetworkConnectionManager.IsInternetConnectionAvailable() == false)
                return false;

            if (!IsUserGuidSet)
                GenerateGuid();

            return CheckIsUsernameFreeHandler != null && CheckIsUsernameFreeHandler(userName);
        }

        public static bool ChangeUsername(string userName)
        {
            if (NetworkConnectionManager.IsInternetConnectionAvailable() == false)
                return false;
            if (!IsUserGuidSet)
                GenerateGuid();

            return ChangeUsernameHandler != null && ChangeUsernameHandler(userName);
        }
    }
}
