using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LooneyInvaders.Model
{
    public class RewardsManager
    {
        private static async Task<string> GetRewardCodeHttpClientAsync(HttpClient httpClient, string rewardId, CancellationToken token)
        {
            try
            {
                var content = new StringContent($"token=12345qwerty&hero_id={rewardId}", Encoding.ASCII);
                var request = await httpClient.PostAsync("http://www.looneyinvaders.com/wp-json/codegenerator/v1/make/", content, token);

                // request.ContentType = "application/x-www-form-urlencoded";

                if (!request.IsSuccessStatusCode)
                    return string.Empty;

                string responseContent = await request.Content.ReadAsStringAsync();

                var parts = responseContent.Split(':');

                if (parts.Length < 2) return string.Empty;
                if (parts[1].Length < 4) return string.Empty;

                var code = parts[1].Substring(1, parts[1].Length - 3);
                return code;
            }
            catch (Exception ex)
            {
                throw;
                //return string.Empty;
            }
        }


        public static Task<string> GetWeaponRewardCodeAsync(HttpClient httpClient, Weapons weapon, CancellationToken token = default(CancellationToken))
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

            return GetRewardCodeHttpClientAsync(httpClient, weaponId, token);
        }

        public static string GetRewardCode(string rewardId)
        {
            try
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

                if (parts.Length < 2) return string.Empty;
                if (parts[1].Length < 4) return string.Empty;

                var code = parts[1].Substring(1, parts[1].Length - 3);
                return code;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
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