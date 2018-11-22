using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Text;

namespace LooneyInvaders.Model
{
    public class RewardsManager
    {
        public static string GetRewardCode(string rewardId)
        {
            byte[] data = Encoding.ASCII.GetBytes("token=12345qwerty&hero_id=" + rewardId);

            WebRequest request = WebRequest.Create("http://dev3.looneyinvaders.com/wp-json/codegenerator/v1/make/");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            string responseContent = null;

            using (WebResponse response = request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader sr99 = new StreamReader(stream))
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

        public static string GetWeaponRewardCode(WEAPONS weapon)
        {
            string weapon_id = "";

            if (weapon == WEAPONS.STANDARD) weapon_id = "std_gun";
            else if (weapon == WEAPONS.COMPACT) weapon_id = "sprayer";
            else if (weapon == WEAPONS.BAZOOKA) weapon_id = "bazooka";

            return GetRewardCode(weapon_id);
        }
        
        public static string GetEnemyRewardCode(ENEMIES enemy)
        {
            string enemy_id = "";

            if (enemy == ENEMIES.HITLER) enemy_id = "hitler";
            else if (enemy == ENEMIES.BUSH) enemy_id = "bush";
            else if (enemy == ENEMIES.PUTIN) enemy_id = "putin";
            else if (enemy == ENEMIES.KIM) enemy_id = "kim";

            return GetRewardCode(enemy_id);
        }
    }
}
