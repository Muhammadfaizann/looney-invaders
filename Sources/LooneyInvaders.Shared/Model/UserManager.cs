using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace LooneyInvaders.Model
{
    public class UserManager
    {
        public delegate bool UsernameHandlerDelegate(string guid);
        public delegate bool UsernameChangeHandlerDelegate(string userName);

        public static UsernameHandlerDelegate UsernameGUIDInsertHandler;
        public static UsernameChangeHandlerDelegate ChangeUsernameHandler;
        public static UsernameChangeHandlerDelegate CheckIsUsernameFreeHandler;

        public static bool IsUserGUIDSet
        {
            get { if (CrossSettings.Current.GetValueOrDefault("UserGUID", "") == "") return false; else return true; }
        }

        public static string UserGUID
        {
            get { return CrossSettings.Current.GetValueOrDefault("UserGUID", ""); }
            set { CrossSettings.Current.AddOrUpdateValue("UserGUID", value); }
        }

        public static void GenerateGUID()
        {
            if (IsUserGUIDSet) return;
            if (UsernameGUIDInsertHandler == null) return;
            if (NetworkConnectionManager.IsInternetConnectionAvailable() == false) return;

            Console.WriteLine("GenerateGUID()");

            string guid = Guid.NewGuid().ToString();

            UsernameGUIDInsertHandler(guid);
        }

        public static bool CheckIsUsernameFree(string userName)
        {
            if (NetworkConnectionManager.IsInternetConnectionAvailable() == false) return false;
            if (!LooneyInvaders.Model.UserManager.IsUserGUIDSet) LooneyInvaders.Model.UserManager.GenerateGUID();

            if (CheckIsUsernameFreeHandler == null) return false;
            return CheckIsUsernameFreeHandler(userName);
        }

        public static bool ChangeUsername(string userName)
        {
            if (NetworkConnectionManager.IsInternetConnectionAvailable() == false) return false;
            if (!LooneyInvaders.Model.UserManager.IsUserGUIDSet) LooneyInvaders.Model.UserManager.GenerateGUID();

            if (ChangeUsernameHandler == null) return false;
            return ChangeUsernameHandler(userName);
        }
    }
}
