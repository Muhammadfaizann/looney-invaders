using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.storage;
using LooneyInvaders.Model;
using LooneyInvaders.Services.App42;
using app42StorageService = com.shephertz.app42.paas.sdk.csharp.storage.StorageService;

namespace LooneyInvaders.App42
{
    public class StorageService
    {
        static readonly object toGetInstance = new object();
        const string dbName = "users";
        const string collectionName = "users";

        static StorageService _instance;
        static app42StorageService _service;

        public static string App42ApiKey { get; private set; }
        public static string App42SecretKey { get; private set; }
        public static app42StorageService App42Service => GetService();
        public static StorageService Instance => GetInstance();
        public static Exception LastException { get; private set; }

        private StorageService()
        {
            try
            {
                _service = App42ServiceBuilder.API.BuildStorageService();
            }
            catch (Exception ex)
            {
                LastException = ex;
            }
        }

        private static StorageService GetInstance()
        {
            lock (toGetInstance)
            {
                if (_instance == null)
                {
                    _instance = new StorageService();
                }
                return _instance;
            }
        }

        private static app42StorageService GetService()
        {
            GetInstance();
            return _service;
        }

        public Task<bool> UsernameGUIDInsertHandler(string guid)
        {
            var json = "{\"name\":\"guest\",\"guid\":\"" + guid + "\"}";

            try
            {
                var time = DateTime.Now;
                Console.WriteLine($"{nameof(UsernameGUIDInsertHandler)}1 : start");
                var storage = App42Service.InsertJSONDocument(dbName, collectionName, json);
                Console.WriteLine($"{nameof(UsernameGUIDInsertHandler)}2 : {(DateTime.Now - time)}");
                var jsonDocList = storage.GetJsonDocList();
                var id = jsonDocList[0].GetDocId();
                var playerName = "player_" + id.Substring(id.Length - 9, 8);

                UserManager.UserGuid = guid;
                Console.WriteLine($"{nameof(UsernameGUIDInsertHandler)}3 : {(DateTime.Now - time)}");
                Player.Instance.Name = playerName;

                json = "{\"name\":\"a" + playerName.ToUpper() + "\",\"guid\":\"" + guid + "\"}";

                Task.Run(() => 
                    App42Service.UpdateDocumentByDocId(dbName, collectionName, id, json));
                Console.WriteLine($"{nameof(UsernameGUIDInsertHandler)}3 : {(DateTime.Now - time)}");

            }
            catch (Exception ex)
            {
                LastException = ex;
            }
            return Task.FromResult(true);
        }

        public bool CheckIsUsernameFree(string username)
        {
            try
            {
                var storage = App42Service.FindDocumentByKeyValue(dbName, collectionName, "name", username.ToUpper());
                var jsonDocList = storage.GetJsonDocList();

                if (jsonDocList.Count == 0) return true; // no user
                if (jsonDocList[0].GetJsonDoc().Contains(UserManager.UserGuid)) return true; // this user
            }
            catch (App42NotFoundException)
            {
                return true;
            }
            catch (System.Net.WebException)
            {
                return true;
            }
            return false;
        }

        public bool ChangeUsername(string username)
        {
            var guid = UserManager.UserGuid;
            var storage = App42Service.FindDocumentByKeyValue(dbName, collectionName, "guid", guid);
            IList<Storage.JSONDocument> jsonDocList;

            try
            {
                jsonDocList = storage.GetJsonDocList();
            }
            catch (App42NotFoundException)
            {
                UserManager.GenerateGuid();

                try
                {
                    storage = App42Service.FindDocumentByKeyValue(dbName, collectionName, "guid", guid);
                    jsonDocList = storage.GetJsonDocList();
                }
                catch
                {
                    return false;
                }
            }

            var id = jsonDocList[0].GetDocId();
            var json = "{\"name\":\"" + username.ToUpper() + "\",\"guid\":\"" + guid + "\"}";

            App42Service.UpdateDocumentByDocId(dbName, collectionName, id, json);

            Player.Instance.Name = username;

            return true;
        }
    }
}
