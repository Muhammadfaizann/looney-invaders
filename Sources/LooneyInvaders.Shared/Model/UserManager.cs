using System;
using System.Threading.Tasks;
using Plugin.Settings;

namespace LooneyInvaders.Model
{
    public class UserManager
    {
        public delegate Task<bool> UsernameHandlerDelegate(string guid);
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

        public static Task GenerateGuid()
        {
            if (IsUserGuidSet)
                return Task.CompletedTask;
            if (UsernameGuidInsertHandler == null)
                return Task.CompletedTask;
            if (NetworkConnectionManager.IsInternetConnectionAvailable() == false)
                return Task.CompletedTask;

            Console.WriteLine("GenerateGUID()");

            var guid = Guid.NewGuid().ToString();

            return UsernameGuidInsertHandler(guid);
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
