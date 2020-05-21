using System;
using Plugin.Settings;
using CocosSharp;

namespace LooneyInvaders.Model
{
    /// <summary>
    /// Class for holding setting values and for applying the settings to the game
    /// </summary>
    public class Settings
    {
        public static bool IsFromGameScreen;
        private static Settings _instance;
        public static Settings Instance => _instance ?? (_instance = new Settings());

        private Settings()
        {
            _advertisements = CrossSettings.Current.GetValueOrDefault("advertisements", _advertisements);
            _battlegroundStyle = CrossSettings.Current.GetValueOrDefault("battlegroundStyle", _battlegroundStyle);
            _notificationsEnabled = CrossSettings.Current.GetValueOrDefault("notificationsEnabled", _notificationsEnabled);
            _musicEnabled = CrossSettings.Current.GetValueOrDefault("musicEnabled", _musicEnabled);
            _musicStyle = CrossSettings.Current.GetValueOrDefault("musicStyle", _musicStyle);
            _musicVolume = CrossSettings.Current.GetValueOrDefault("musicVolume", _musicVolume);
            _soundEnabled = CrossSettings.Current.GetValueOrDefault("soundEnabled", _soundEnabled);
            _soundVolume = CrossSettings.Current.GetValueOrDefault("soundVolume", _soundVolume);
            _vibration = CrossSettings.Current.GetValueOrDefault("vibration", _vibration);
            _gameTipQuitGameShow = CrossSettings.Current.GetValueOrDefault("gameTipQuitGameShow", _gameTipQuitGameShow);
            _gameTipProLevelShow = CrossSettings.Current.GetValueOrDefault("gameTipProLevelShow", _gameTipProLevelShow);
            _gameTipEnemyPickerShow = CrossSettings.Current.GetValueOrDefault("gameTipEnemyPickerShow", _gameTipEnemyPickerShow);
            _gameTipWeaponPickerShow = CrossSettings.Current.GetValueOrDefault("gameTipWeaponPickerShow", _gameTipWeaponPickerShow);
            _gameTipBattlegroundPickerShow = CrossSettings.Current.GetValueOrDefault("gameTipBattlegroundPickerShow", _gameTipBattlegroundPickerShow);
            _gameTipGamePlayShow = CrossSettings.Current.GetValueOrDefault("gameTipGamePlayShow", _gameTipGamePlayShow);
            _alienGameTipGamePlayShow = CrossSettings.Current.GetValueOrDefault("alienGameTipGamePlayShow", _alienGameTipGamePlayShow);
            _controlType = CrossSettings.Current.GetValueOrDefault("controlType", _controlType);
            _sensitivityLevel = CrossSettings.Current.GetValueOrDefault("sensitivityLevel", _sensitivityLevel);
            _rightHanded = CrossSettings.Current.GetValueOrDefault("rightHanded", _rightHanded);
            _showSteeringTip = CrossSettings.Current.GetValueOrDefault("showSteeringTip", _showSteeringTip);
            _swearingEnabled = CrossSettings.Current.GetValueOrDefault("swearingEnabled", _swearingEnabled);
            _isPushNotificationEnabled = CrossSettings.Current.GetValueOrDefault("isPushNotificationEnabled", _isPushNotificationEnabled);
        }

        private delegate void MuteConditionallyDelegate(int delayms);
        public void MuteConditionally(int delayms)
        {
            System.Threading.Tasks.Task.Delay(delayms).Wait();
            if (_soundEnabled == false || _soundVolume == 0)
            {
                CCAudioEngine.SharedEngine.StopAllEffects();
                CCAudioEngine.SharedEngine.EffectsVolume = 0;
            }
        }

        public void ApplyValues(bool playMusic = true)
        {
            if (_musicEnabled == false || _musicVolume == 0)
            {
                CCAudioEngine.SharedEngine.StopBackgroundMusic();
                CCAudioEngine.SharedEngine.BackgroundMusicVolume = 0;
                GameEnvironment.MusicPlaying = null;

            }
            else
            {
                CCAudioEngine.SharedEngine.BackgroundMusicVolume = (float)Math.Pow(_musicVolume / 8.00f, 2);
                if (playMusic)
                    GameEnvironment.PlayMusic(Music.MainMenu);
            }

            if (_soundEnabled == false || _soundVolume == 0)
            {
                MuteConditionallyDelegate p = MuteConditionally;
                p.BeginInvoke(400, null, null);
            }
            else
            {
                CCAudioEngine.SharedEngine.EffectsVolume = (float)Math.Pow(_soundVolume / 8.00f, 2);
            }
        }

        internal void ResetGameTips()
        {
            _gameTipBattlegroundPickerShow = true;
            _gameTipEnemyPickerShow = true;
            _gameTipGamePlayShow = true;
            _gameTipWeaponPickerShow = true;
        }

        private bool _notificationsEnabled = true;
        public bool NotificationsEnabled
        {
            get => _notificationsEnabled;
            set { _notificationsEnabled = value; CrossSettings.Current.AddOrUpdateValue("notificationsEnabled", value); ApplyValues(); }
        }

        private bool _voiceoversEnabled = true;
        public bool VoiceoversEnabled
        {
            get => _voiceoversEnabled;
            set { _voiceoversEnabled = value; CrossSettings.Current.AddOrUpdateValue("voiceoversEnabled", value); ApplyValues(); }
        }

        private bool _swearingEnabled = true;
        public bool SwearingEnabled
        {
            get => _swearingEnabled;
            set { _swearingEnabled = value; CrossSettings.Current.AddOrUpdateValue("swearingEnabled", value); ApplyValues(); }
        }

        private bool _musicEnabled = true;
        public bool MusicEnabled
        {
            get => _musicEnabled;
            set { _musicEnabled = value; CrossSettings.Current.AddOrUpdateValue("musicEnabled", value); ApplyValues(); }
        }

        private int _musicVolume = 7;
        public int MusicVolume
        {
            get => _musicVolume;
            set { _musicVolume = value; CrossSettings.Current.AddOrUpdateValue("musicVolume", value); ApplyValues(); }
        }

        private bool _soundEnabled = true;
        public bool SoundEnabled
        {
            get => _soundEnabled;
            set { _soundEnabled = value; CrossSettings.Current.AddOrUpdateValue("soundEnabled", value); ApplyValues(); }
        }

        private int _soundVolume = 7;
        public int SoundVolume
        {
            get => _soundVolume;
            set { _soundVolume = value; CrossSettings.Current.AddOrUpdateValue("soundVolume", value); ApplyValues(); }
        }

        private int _musicStyle = (int)MusicStyle.BeatBox;
        public MusicStyle MusicStyle
        {
            get => (MusicStyle)_musicStyle;
            set { _musicStyle = (int)value; CrossSettings.Current.AddOrUpdateValue("musicStyle", (int)value); ApplyValues(); }
        }

        private bool _vibration = true;
        public bool Vibration
        {
            get => _vibration;
            set { _vibration = value; CrossSettings.Current.AddOrUpdateValue("vibration", value); ApplyValues(); }
        }

        private int _battlegroundStyle = (int)BattlegroundStyle.Cartonic;
        public BattlegroundStyle BattlegroundStyle
        {
            get => (BattlegroundStyle)_battlegroundStyle;
            set { _battlegroundStyle = (int)value; CrossSettings.Current.AddOrUpdateValue("battlegroundStyle", (int)value); ApplyValues(); }
        }

        private bool _advertisements = true;
        public bool Advertisements
        {
            get => _advertisements;
            set { _advertisements = value; CrossSettings.Current.AddOrUpdateValue("advertisements", value); ApplyValues(); }
        }

        private bool _gameTipQuitGameShow = true;
        public bool GameTipQuitGameShow
        {
            get => _gameTipQuitGameShow;
            set { _gameTipQuitGameShow = value; CrossSettings.Current.AddOrUpdateValue("gameTipQuitGameShow", value); ApplyValues(); }
        }

        private bool _gameTipProLevelShow = true;
        public bool GameTipProLevelShow
        {
            get => _gameTipProLevelShow;
            set { _gameTipProLevelShow = value; CrossSettings.Current.AddOrUpdateValue("gameTipProLevelShow", value); ApplyValues(); }
        }

        private bool _gameTipEnemyPickerShow = true;
        public bool GameTipEnemyPickerShow
        {
            get => _gameTipEnemyPickerShow;
            set { _gameTipEnemyPickerShow = value; CrossSettings.Current.AddOrUpdateValue("gameTipEnemyPickerShow", value); ApplyValues(); }
        }

        private bool _gameTipWeaponPickerShow = true;
        public bool GameTipWeaponPickerShow
        {
            get => _gameTipWeaponPickerShow;
            set { _gameTipWeaponPickerShow = value; CrossSettings.Current.AddOrUpdateValue("gameTipWeaponPickerShow", value); ApplyValues(); }
        }

        private bool _gameTipBattlegroundPickerShow = true;
        public bool GameTipBattlegroundPickerShow
        {
            get => _gameTipBattlegroundPickerShow;
            set { _gameTipBattlegroundPickerShow = value; CrossSettings.Current.AddOrUpdateValue("gameTipBattlegroundPickerShow", value); ApplyValues(); }
        }

        private bool _gameTipGamePlayShow = true;
        public bool GameTipGamePlayShow
        {
            get => _gameTipGamePlayShow;
            set { _gameTipGamePlayShow = value; CrossSettings.Current.AddOrUpdateValue("gameTipGamePlayShow", value); }
        }

        private bool _alienGameTipGamePlayShow = true;
        public bool AlienGameTipGamePlayShow
        {
            get => _alienGameTipGamePlayShow;
            set { _alienGameTipGamePlayShow = value; CrossSettings.Current.AddOrUpdateValue("alienGameTipGamePlayShow", value); }
        }

        private bool _gamePauseFriendly;
        public bool GamePauseFriendly
        {
            get => _gamePauseFriendly;
            set { _gamePauseFriendly = value; CrossSettings.Current.AddOrUpdateValue("gamePauseFriendly", value); }
        }

        private int _controlType = (int)ControlType.Gyroscope;
        public ControlType ControlType
        {
            get => (ControlType)_controlType;
            set { _controlType = (int)value; CrossSettings.Current.AddOrUpdateValue("controlType", (int)value); }
        }


        private int _sensitivityLevel = 4;
        public int SensitivityLevel
        {
            get => _sensitivityLevel;
            set { _sensitivityLevel = value; CrossSettings.Current.AddOrUpdateValue("sensitivityLevel", value); }
        }

        private bool _rightHanded = true;
        public bool RightHanded
        {
            get => _rightHanded;
            set { _rightHanded = value; CrossSettings.Current.AddOrUpdateValue("rightHanded", value); }
        }

        private bool _showSteeringTip = true;
        public bool ShowSteeringTip
        {
            get => _showSteeringTip;
            set { _showSteeringTip = value; CrossSettings.Current.AddOrUpdateValue("showSteeringTip", value); }
        }

        private bool _isPushNotificationEnabled = true;
        public bool IsPushNotificationEnabled
        {
            get => _isPushNotificationEnabled;
            set { _isPushNotificationEnabled = value; CrossSettings.Current.AddOrUpdateValue("isPushNotificationEnabled", value); }
        }



        public int GetTodaySessionDuration()
        {
            //get duration in seconds
            var stringDate = DateTime.Now.ToString("dd-MM-yyyy") + "duration";
            var todaySessionDuration = CrossSettings.Current.GetValueOrDefault(stringDate, 0);

            return todaySessionDuration;
        }

        private double _timeToNewAd;
        public double TimeToNewAd
        {
            get => _timeToNewAd;
            set { _timeToNewAd = value; CrossSettings.Current.AddOrUpdateValue("TimeToNewAd", value); }
        }

        private DateTime _timeWhenPageAdsLeaved;
        public DateTime TimeWhenPageAdsLeaved
        {
            get => _timeWhenPageAdsLeaved;
            set { _timeWhenPageAdsLeaved = value; CrossSettings.Current.AddOrUpdateValue("TimeWhenPageAdsLeaved", value); }
        }


        public void SetTodaySessionDuration(int duration, bool clearAll = false)
        {
            var stringDate = DateTime.Now.ToString("dd-MM-yyyy") + "duration";

            var alreadyPlayedTime = GetTodaySessionDuration();

            int totalTodayPlayd;

            if (clearAll)
                totalTodayPlayd = duration;
            else
                totalTodayPlayd = alreadyPlayedTime + duration;

            CrossSettings.Current.AddOrUpdateValue(stringDate, totalTodayPlayd);
        }

        public int GetSessionsCount()
        {
            return CrossSettings.Current.GetValueOrDefault("sessionscount", 0);
        }

        public void SetSessionsCount(int count)
        {
            CrossSettings.Current.AddOrUpdateValue("sessionscount", count);
        }

        public void CheckIfChangeNamePopupShown()
        {
            var count = GetSessionsCount();
            
            if (count == 3 || count == 5 || count == 10)
                Player.Instance.IsChangeNamePopupShown = false;
        }

        private bool _isAskForNotificationToday;
        public bool IsAskForNotificationToday
        {
            get => _isAskForNotificationToday;
            set { _isAskForNotificationToday = value; CrossSettings.Current.AddOrUpdateValue("isAskForNotificationToday", value); }
        }
    }
}
