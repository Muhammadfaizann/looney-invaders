using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using CocosSharp;
using Microsoft.Xna.Framework;

namespace LooneyInvaders.Model
{
    public class Player
    {
        private static Player _instance = null;
        public static Player Instance
        {
            get
            {
                if (_instance == null) _instance = new Player();
                return _instance;
            }
        }

        public string Name
        {
            get
            {
                return CrossSettings.Current.GetValueOrDefault("PlayerName", "LOONEY");
            }
            set
            {
                CrossSettings.Current.AddOrUpdateValue("PlayerName", value);
            }
        }
        public int Score
        {
            get
            {
                return CrossSettings.Current.GetValueOrDefault("Score", 0);
            }
            set
            {
                CrossSettings.Current.AddOrUpdateValue("Score", value);
            }
        }
        public int Credits
        {
            get
            {

                return CrossSettings.Current.GetValueOrDefault("Credits", 0);
            }
            set
            {
                CrossSettings.Current.AddOrUpdateValue("Credits", value);
            }
        }

        public DateTime getFixedDate(DateTime Value)
        {
            var FixedDate = TimeZoneInfo.ConvertTime(Value.ToUniversalTime(), TimeZoneInfo.Utc, TimeZoneInfo.FindSystemTimeZoneById(TimeZoneInfo.Local.Id));
            return FixedDate;
        }

        public DateTime LastAdWatchTime
        {
            get
            {
                return getFixedDate(CrossSettings.Current.GetValueOrDefault("LastAdWatchTime", Convert.ToDateTime("1990-01-01")));
            }
            set
            {
                CrossSettings.Current.AddOrUpdateValue("LastAdWatchTime", value);
            }
        }

        public DateTime LastAdWatchDay
        {
            get
            {
                return getFixedDate(CrossSettings.Current.GetValueOrDefault("LastAdWatchDay", Convert.ToDateTime("1990-01-01")));
            }
            set
            {
                CrossSettings.Current.AddOrUpdateValue("LastAdWatchDay", value);
            }
        }

        public int LastAdWatchDayCount
        {
            get
            {
                return CrossSettings.Current.GetValueOrDefault("LastAdWatchDayCount", 0);
            }
            set
            {
                CrossSettings.Current.AddOrUpdateValue("LastAdWatchDayCount", value);
            }
        }

        public bool FacebookLikeUsed
        {
            get
            {
                return CrossSettings.Current.GetValueOrDefault("FacebookLikeUsed", false);
            }
            set
            {
                CrossSettings.Current.AddOrUpdateValue("FacebookLikeUsed", value);
            }
        }

        public bool GetWeapon(WEAPONS weapon)
        {
            if (weapon == WEAPONS.STANDARD || weapon == WEAPONS.HYBRID) return true;
            else return CrossSettings.Current.GetValueOrDefault("STATS2_weapons_" + weapon.ToString(), false);
        }

        public void AddWeapon(WEAPONS weapon)
        {
            CrossSettings.Current.AddOrUpdateValue("STATS2_weapons_" + weapon.ToString(), true);
        }

        public int GetKills(ENEMIES enemy)
        {
            return CrossSettings.Current.GetValueOrDefault("STATS3_enemyKills_" + enemy.ToString(), 0);
        }

        public int GetKillsTotal()
        {
            return CrossSettings.Current.GetValueOrDefault("STATS3_enemyKillsTotal", 0);
        }

        public void AddKill(ENEMIES enemy)
        {
            CrossSettings.Current.AddOrUpdateValue("STATS3_enemyKills_" + enemy.ToString(), GetKills(enemy) + 1);
            CrossSettings.Current.AddOrUpdateValue("STATS3_enemyKillsTotal", GetKillsTotal() + 1);
        }

        public void AddKills(ENEMIES enemy, int kills)
        {
            CrossSettings.Current.AddOrUpdateValue("STATS3_enemyKills_" + enemy.ToString(), GetKills(enemy) + kills);
            CrossSettings.Current.AddOrUpdateValue("STATS3_enemyKillsTotal", GetKillsTotal() + kills);
        }


        public int GetSavedCountries(BATTLEGROUNDS country)
        {
            //if(country == BATTLEGROUNDS.UNITED_STATES) return 0; else return 1;
            return CrossSettings.Current.GetValueOrDefault("STATS3_savedCountries_" + country.ToString(), 0);
        }

        public int GetSavedCountriesTotal()
        {
            return CrossSettings.Current.GetValueOrDefault("STATS3_savedCountriesTotal", 0);
        }

        public void AddSavedCountry(BATTLEGROUNDS country)
        {
            CrossSettings.Current.AddOrUpdateValue("STATS3_savedCountries_" + country.ToString(), GetSavedCountries(country) + 1);
            CrossSettings.Current.AddOrUpdateValue("STATS3_savedCountriesTotal", GetSavedCountriesTotal() + 1);
        }

        public void GetQuickGame(ref ENEMIES enemy, ref BATTLEGROUNDS battleground, ref WEAPONS weapon)
        {
            enemy = (ENEMIES)CrossSettings.Current.GetValueOrDefault("QUICKGAME_enemy", (int)ENEMIES.HITLER);
            battleground = (BATTLEGROUNDS)CrossSettings.Current.GetValueOrDefault("QUICKGAME_battleground", (int)BATTLEGROUNDS.POLAND);
            weapon = (WEAPONS)CrossSettings.Current.GetValueOrDefault("QUICKGAME_weapon", (int)WEAPONS.STANDARD);
        }

        public void SetQuickGame(ENEMIES enemy, BATTLEGROUNDS battleground, WEAPONS weapon)
        {
            CrossSettings.Current.AddOrUpdateValue("QUICKGAME_enemy", (int)enemy);
            CrossSettings.Current.AddOrUpdateValue("QUICKGAME_battleground", (int)battleground);
            CrossSettings.Current.AddOrUpdateValue("QUICKGAME_weapon", (int)weapon);
        }
        
        public int GetDayScore(DateTime date, bool isPro = false)
        {
			var stringDate = date.ToString("dd-MM-yyyy") + (isPro ? "_pro" : "");
            return CrossSettings.Current.GetValueOrDefault(stringDate, 0);
        }

		public void SetDayScore(int score, bool isPro = false)
        {
			var stringDate = DateTime.Now.AddMinutes(-15).AddSeconds(-10).ToString("dd-MM-yyyy") + (isPro ? "_pro" : "");

			var bestScoreOfDay = GetDayScore(DateTime.Now.AddMinutes(-15).AddSeconds(-10).Date, isPro);

			if(score > bestScoreOfDay)
                CrossSettings.Current.AddOrUpdateValue(stringDate, score);

			SetBestScoreAllTime(score, isPro);
        }

		public void RemoveDayScore(DateTime date, bool isPro = false)
        {
			var stringDate = date.ToString("dd-MM-yyyy") + (isPro ? "_pro" : "");
            CrossSettings.Current.Remove(stringDate);
        }

		public int GetBestScoreAllTime(bool isPro = false)
        {
			var keyName = "allTimeBestScore" + (isPro ? "_pro" : "");

			return CrossSettings.Current.GetValueOrDefault(keyName, 0);
        }

		private void SetBestScoreAllTime(int score, bool isPro = false)
        {
			var lastBest = GetBestScoreAllTime(isPro);

			if (score > GetBestScoreAllTime(isPro))
			{
				var keyName = "allTimeBestScore" + (isPro ? "_pro" : "");
				CrossSettings.Current.AddOrUpdateValue(keyName, score);
			}
        }      
    }
}
