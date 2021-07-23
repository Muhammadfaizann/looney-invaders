using System;
using Plugin.Settings;

namespace LooneyInvaders.Model
{
    public class Player
    {
        public bool IsProLevelSelected = false;
        public Action OnCreditsChanged;
        
        private static Player _instance;
        public static Player Instance => _instance ?? (_instance = new Player());

        public bool NameChanged
        {
            get => CrossSettings.Current.GetValueOrDefault("PlayerNameChanged", false);
            set => CrossSettings.Current.AddOrUpdateValue("PlayerNameChanged", value);
        }
        public string Name
        {
            get => CrossSettings.Current.GetValueOrDefault("PlayerName", "LOONEY");
            set
            {
                var oldName = CrossSettings.Current.GetValueOrDefault("PlayerName", "LOONEY");
                if (oldName != value)
                {
                    CrossSettings.Current.AddOrUpdateValue("PlayerName", value);
                    NameChanged = true;
                }
            }
        }
        public int Score
        {
            get => CrossSettings.Current.GetValueOrDefault("Score", 0);
            set => CrossSettings.Current.AddOrUpdateValue("Score", value);
        }
        public int WinCount
        {
            get => CrossSettings.Current.GetValueOrDefault(nameof(WinCount), 0);
            set => CrossSettings.Current.AddOrUpdateValue(nameof(WinCount), value);
        }
        public int Credits
        {
            get => CrossSettings.Current.GetValueOrDefault("Credits", 0);
            set
            {
                CrossSettings.Current.AddOrUpdateValue("Credits", value);
                OnCreditsPropertyChanged();
            }
        }

        public int CachedFacebookLikesCount
        {
            get => CrossSettings.Current.GetValueOrDefault(nameof(CachedFacebookLikesCount), 0);
            set => CrossSettings.Current.AddOrUpdateValue(nameof(CachedFacebookLikesCount), value);
        }
        public bool Hakkeroitu
        {
            get => CrossSettings.Current.GetValueOrDefault("Hakkeroitu", false);
            set => CrossSettings.Current.AddOrUpdateValue("Hakkeroitu", value);
        }

        public DateTime GetFixedDate(DateTime value)
        {
            return TimeZoneInfo.ConvertTime(value.ToUniversalTime(), TimeZoneInfo.Utc, TimeZoneInfo.FindSystemTimeZoneById(TimeZoneInfo.Local.Id));
        }
        
        public bool IsAdInCountdown
        {
            get => CrossSettings.Current.GetValueOrDefault(nameof(IsAdInCountdown), false);
            set => CrossSettings.Current.AddOrUpdateValue(nameof(IsAdInCountdown), value);
        }
        
        public DateTime DateTimeOfCountdownPassed
        {
            get => GetFixedDate(CrossSettings.Current.GetValueOrDefault(nameof(DateTimeOfCountdownPassed), default(DateTime)));
            set => CrossSettings.Current.AddOrUpdateValue(nameof(DateTimeOfCountdownPassed), value);
        }
        
        public DateTime LastAdWatchTime
        {
            get => GetFixedDate(CrossSettings.Current.GetValueOrDefault("LastAdWatchTime", Convert.ToDateTime("1990-01-01")));
            set => CrossSettings.Current.AddOrUpdateValue("LastAdWatchTime", value);
        }

        public DateTime LastAdWatchDay
        {
            get => GetFixedDate(CrossSettings.Current.GetValueOrDefault("LastAdWatchDay", Convert.ToDateTime("1990-01-01")));
            set => CrossSettings.Current.AddOrUpdateValue("LastAdWatchDay", value);
        }

        public int LastAdWatchDayCount
        {
            get => CrossSettings.Current.GetValueOrDefault("LastAdWatchDayCount", 0);
            set => CrossSettings.Current.AddOrUpdateValue("LastAdWatchDayCount", value);
        }

        public bool FacebookLikeUsed
        {
            get => CrossSettings.Current.GetValueOrDefault("FacebookLikeUsed", false);
            set => CrossSettings.Current.AddOrUpdateValue("FacebookLikeUsed", value);
        }

        public int SessionsCountBeforeFirstVictory
        {
            get => CrossSettings.Current.GetValueOrDefault("sessionscountfirstvictory", 0);
            set => CrossSettings.Current.AddOrUpdateValue("sessionscountfirstvictory", value);
        }

        public bool GetWeapon(Weapons weapon)
        {
            if (weapon == Weapons.Standard || weapon == Weapons.Hybrid)
                return true;

            return CrossSettings.Current.GetValueOrDefault("STATS2_weapons_" + weapon, false);
        }

        public void AddWeapon(Weapons weapon)
        {
            CrossSettings.Current.AddOrUpdateValue("STATS2_weapons_" + weapon, true);
        }

        public int GetKills(Enemies enemy)
        {
            return CrossSettings.Current.GetValueOrDefault("STATS3_enemyKills_" + enemy, 0);
        }

        public int GetKillsTotal()
        {
            return CrossSettings.Current.GetValueOrDefault("STATS3_enemyKillsTotal", 0);
        }
        
        
        public bool IsChangeNamePopupShown
        {
            get => CrossSettings.Current.GetValueOrDefault(nameof(IsChangeNamePopupShown), false);
            set => CrossSettings.Current.AddOrUpdateValue(nameof(IsChangeNamePopupShown), value);
        }

        public void AddKill(Enemies enemy)
        {
            CrossSettings.Current.AddOrUpdateValue("STATS3_enemyKills_" + enemy, GetKills(enemy) + 1);
            CrossSettings.Current.AddOrUpdateValue("STATS3_enemyKillsTotal", GetKillsTotal() + 1);
        }

        public void AddKills(Enemies enemy, int kills)
        {
            CrossSettings.Current.AddOrUpdateValue("STATS3_enemyKills_" + enemy, GetKills(enemy) + kills);
            CrossSettings.Current.AddOrUpdateValue("STATS3_enemyKillsTotal", GetKillsTotal() + kills);
        }


        public int GetSavedCountries(Battlegrounds country)
        {
            //if(country == BATTLEGROUNDS.UNITED_STATES) return 0; else return 1;
            return CrossSettings.Current.GetValueOrDefault("STATS3_savedCountries_" + country, 0);
        }

        public int GetSavedCountriesTotal()
        {
            return CrossSettings.Current.GetValueOrDefault("STATS3_savedCountriesTotal", 0);
        }

        public void AddSavedCountry(Battlegrounds country)
        {
            CrossSettings.Current.AddOrUpdateValue("STATS3_savedCountries_" + country, GetSavedCountries(country) + 1);
            CrossSettings.Current.AddOrUpdateValue("STATS3_savedCountriesTotal", GetSavedCountriesTotal() + 1);
        }

        public void GetQuickGame(out Enemies enemy, out Battlegrounds battleground, out Weapons weapon)
        {
            enemy = (Enemies)CrossSettings.Current.GetValueOrDefault("QUICKGAME_enemy", (int)Enemies.Milo);
            battleground = (Battlegrounds)CrossSettings.Current.GetValueOrDefault("QUICKGAME_battleground", (int)Battlegrounds.Slovenia);
            weapon = (Weapons)CrossSettings.Current.GetValueOrDefault("QUICKGAME_weapon", (int)Weapons.Standard);
        }

        public void SetQuickGame(Enemies enemy, Battlegrounds battleground, Weapons weapon)
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

            if (score > bestScoreOfDay)
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
            if (score > GetBestScoreAllTime(isPro))
            {
                var keyName = "allTimeBestScore" + (isPro ? "_pro" : "");
                CrossSettings.Current.AddOrUpdateValue(keyName, score);
            }
        }
        
        private void OnCreditsPropertyChanged()
        {
            OnCreditsChanged?.Invoke();
        }
    }
}
