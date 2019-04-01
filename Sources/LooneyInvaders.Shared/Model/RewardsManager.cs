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
            var data = Encoding.ASCII.GetBytes("token=12345qwerty&hero_id=" + rewardId);

            var request = WebRequest.Create("http://www.looneyinvaders.com/wp-json/codegenerator/v1/make/");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            string responseContent;

            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var sr99 = new StreamReader(stream ?? throw new InvalidOperationException()))
                    {
                        responseContent = sr99.ReadToEnd();
                    }
                }
            }

            var parts = responseContent.Split(':');

            if (parts.Length < 2) return "";
            if (parts[1].Length < 4) return "";

            var code = parts[1].Substring(1, parts[1].Length - 3);
            return code;
        }

        public static string GetWeaponRewardCode(Weapons weapon)
        {
            var weaponId = "";

            switch (weapon)
            {
                case Weapons.Standard:
                    weaponId = "std_gun";
                    break;
                case Weapons.Compact:
                    weaponId = "sprayer";
                    break;
                case Weapons.Bazooka:
                    weaponId = "bazooka";
                    break;
            }

            return GetRewardCode(weaponId);
        }

        public static string GetEnemyRewardCode(Enemies enemy)
        {
            var enemyId = "";

            if (enemy == Enemies.Hitler) enemyId = "hitler";
            else if (enemy == Enemies.Bush) enemyId = "bush";
            else if (enemy == Enemies.Putin) enemyId = "putin";
            else if (enemy == Enemies.Kim) enemyId = "kim";

            return GetRewardCode(enemyId);
        }
    }
}
