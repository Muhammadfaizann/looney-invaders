using System;
using System.IO;
using System.Net;
using System.Text;

namespace LooneyInvaders.Model
{
    public class RewardsManager
    {
        public static string GetRewardCode(string rewardId)
        {
            byte[] data = Encoding.ASCII.GetBytes("token=12345qwerty&hero_id=" + rewardId);

            WebRequest request = WebRequest.Create("http://www.looneyinvaders.com/wp-json/codegenerator/v1/make/");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            string responseContent;

            using (WebResponse response = request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader sr99 = new StreamReader(stream ?? throw new InvalidOperationException()))
                    {
                        responseContent = sr99.ReadToEnd();
                    }
                }
            }

            string[] parts = responseContent.Split(':');

            if (parts.Length < 2) return "";
            if (parts[1].Length < 4) return "";

            string code = parts[1].Substring(1, parts[1].Length - 3);
            return code;
        }

        public static string GetWeaponRewardCode(Weapons weapon)
        {
            string weaponId = "";

            if (weapon == Weapons.Standard) weaponId = "std_gun";
            else if (weapon == Weapons.Compact) weaponId = "sprayer";
            else if (weapon == Weapons.Bazooka) weaponId = "bazooka";

            return GetRewardCode(weaponId);
        }

        public static string GetEnemyRewardCode(Enemies enemy)
        {
            string enemyId = "";

            if (enemy == Enemies.Hitler) enemyId = "hitler";
            else if (enemy == Enemies.Bush) enemyId = "bush";
            else if (enemy == Enemies.Putin) enemyId = "putin";
            else if (enemy == Enemies.Kim) enemyId = "kim";

            return GetRewardCode(enemyId);
        }
    }
}
