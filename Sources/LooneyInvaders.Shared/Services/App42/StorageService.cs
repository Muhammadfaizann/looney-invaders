using System;
using System.Collections.Generic;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.game;
using com.shephertz.app42.paas.sdk.csharp.storage;
using LooneyInvaders.Model;
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
        static GameService _gameService;

        public static string App42ApiKey { get; private set; }
        public static string App42SecretKey { get; private set; }
        public static app42StorageService App42Service => GetService();
        public static StorageService Instance => GetInstance();
        public static Exception LastException { get; private set; }

        private StorageService()
        {
            App42API.Initialize(App42ApiKey, App42SecretKey);
            try
            {
                _gameService = App42API.BuildGameService();
                _service = App42API.BuildStorageService();
            }
            catch (Exception ex)
            {
                LastException = ex;
            }
        }

        public static void Init(string app42ApiKey, string app42SecretKey)
        {
            App42ApiKey = app42ApiKey;
            App42SecretKey = app42SecretKey;
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

        public bool UsernameGUIDInsertHandler(string guid)
        {
            var json = "{\"name\":\"guest\",\"guid\":\"" + guid + "\"}";

            try
            {
                var storage = App42Service.InsertJSONDocument(dbName, collectionName, json);
                var jsonDocList = storage.GetJsonDocList();

                var id = jsonDocList[0].GetDocId();
                var playerName = "player_" + id.Substring(id.Length - 9, 8);

                UserManager.UserGuid = guid;
                Player.Instance.Name = playerName;

                json = "{\"name\":\"a" + playerName.ToUpper() + "\",\"guid\":\"" + guid + "\"}";
                App42Service.UpdateDocumentByDocId(dbName, collectionName, id, json);

            }
            catch (Exception ex)
            {
                var mess = ex.Message;
            }
            return true;
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
            catch (App42NotFoundException ex)
            {
                return true;
            }
            catch (System.Net.WebException e)
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
