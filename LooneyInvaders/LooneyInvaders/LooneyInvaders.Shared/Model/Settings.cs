using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using CocosSharp;
using Microsoft.Xna.Framework;

namespace LooneyInvaders.Model
{
    /// <summary>
    /// Class for holding setting values and for applying the settings to the game
    /// </summary>
    public class Settings
    {
        private static Settings _instance = null;
        public static Settings Instance
        {
            get
            {
                if (_instance == null) _instance = new Settings();
                return _instance;
            }
        }

        private Settings()
        {   
            this._advertisements = CrossSettings.Current.GetValueOrDefault("advertisements", _advertisements);
            this._battlegroundStyle = CrossSettings.Current.GetValueOrDefault("battlegroundStyle", _battlegroundStyle);
            this._notificationsEnabled = CrossSettings.Current.GetValueOrDefault("notificationsEnabled", _notificationsEnabled);            
            this._musicEnabled = CrossSettings.Current.GetValueOrDefault("musicEnabled", _musicEnabled);
            this._musicStyle = CrossSettings.Current.GetValueOrDefault("musicStyle", _musicStyle);
            this._musicVolume= CrossSettings.Current.GetValueOrDefault("musicVolume", _musicVolume);
            this._soundEnabled = CrossSettings.Current.GetValueOrDefault("soundEnabled", _soundEnabled);
            this._soundVolume = CrossSettings.Current.GetValueOrDefault("soundVolume", _soundVolume);
            this._vibration = CrossSettings.Current.GetValueOrDefault("vibration", _vibration);
            this._gameTipProLevelShow = CrossSettings.Current.GetValueOrDefault("gameTipProLevelShow", _gameTipProLevelShow);
            this._gameTipEnemyPickerShow = CrossSettings.Current.GetValueOrDefault("gameTipEnemyPickerShow", _gameTipEnemyPickerShow);
            this._gameTipWeaponPickerShow = CrossSettings.Current.GetValueOrDefault("gameTipWeaponPickerShow", _gameTipWeaponPickerShow);
            this._gameTipBattlegroundPickerShow = CrossSettings.Current.GetValueOrDefault("gameTipBattlegroundPickerShow", _gameTipBattlegroundPickerShow);
            this._gameTipGamePlayShow = CrossSettings.Current.GetValueOrDefault("gameTipGamePlayShow", _gameTipGamePlayShow);
            this._alienGameTipGamePlayShow = CrossSettings.Current.GetValueOrDefault("alienGameTipGamePlayShow", _alienGameTipGamePlayShow);
            this._controlType = CrossSettings.Current.GetValueOrDefault("controlType", _controlType);
            this._sensitivityLevel = CrossSettings.Current.GetValueOrDefault("sensitivityLevel", _sensitivityLevel);
            this._rightHanded = CrossSettings.Current.GetValueOrDefault("rightHanded", _rightHanded);
            this._showSteeringTip = CrossSettings.Current.GetValueOrDefault("showSteeringTip", _showSteeringTip);
            this._swearingEnabled = CrossSettings.Current.GetValueOrDefault("swearingEnabled", _swearingEnabled);
			this._isPushNotificationEnabled = CrossSettings.Current.GetValueOrDefault("isPushNotificationEnabled", _isPushNotificationEnabled);
        }

        delegate void MuteConditionallyDelegate(int delayms);
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
                if(playMusic) GameEnvironment.PlayMusic(MUSIC.MAIN_MENU);
            }

            if (_soundEnabled == false || _soundVolume == 0)
            {
                MuteConditionallyDelegate p = MuteConditionally;
                IAsyncResult res = p.BeginInvoke(400, null, null);
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
            get { return _notificationsEnabled; }
            set { _notificationsEnabled = value; CrossSettings.Current.AddOrUpdateValue("notificationsEnabled", value); this.ApplyValues(); }
        }

        private bool _voiceoversEnabled = true;
        public bool VoiceoversEnabled
        {
            get { return _voiceoversEnabled; }
            set { _voiceoversEnabled = value; CrossSettings.Current.AddOrUpdateValue("voiceoversEnabled", value); this.ApplyValues(); }
        }

        private bool _swearingEnabled = true;
        public bool SwearingEnabled
        {
            get { return _swearingEnabled; }
            set { _swearingEnabled = value; CrossSettings.Current.AddOrUpdateValue("swearingEnabled", value); this.ApplyValues(); }
        }

        private bool _musicEnabled = true;
        public bool MusicEnabled
        {
            get { return _musicEnabled; }
            set { _musicEnabled = value; CrossSettings.Current.AddOrUpdateValue("musicEnabled", value); this.ApplyValues(); }
        }

        private int _musicVolume = 7;
        public int MusicVolume
        {
            get { return _musicVolume; }
            set { _musicVolume = value; CrossSettings.Current.AddOrUpdateValue("musicVolume", value); this.ApplyValues(); }
        }

        private bool _soundEnabled = true;
        public bool SoundEnabled
        {
            get { return _soundEnabled; }
            set { _soundEnabled = value; CrossSettings.Current.AddOrUpdateValue("soundEnabled", value); this.ApplyValues(); }
        }

        private int _soundVolume = 7;
        public int SoundVolume
        {
            get { return _soundVolume; }
            set { _soundVolume = value; CrossSettings.Current.AddOrUpdateValue("soundVolume", value); this.ApplyValues(); }
        }

        private int _musicStyle = (int)MUSIC_STYLE.Instrumental;
        public MUSIC_STYLE MusicStyle
        {
            get { return (MUSIC_STYLE)_musicStyle; }
            set { _musicStyle = (int)value; CrossSettings.Current.AddOrUpdateValue("musicStyle", (int)value); this.ApplyValues(); }
        }

        private bool _vibration = true;
        public bool Vibration
        {
            get { return _vibration; }
            set { _vibration = value; CrossSettings.Current.AddOrUpdateValue("vibration", value); this.ApplyValues(); }
        }

        private int _battlegroundStyle = (int)BATTLEGROUND_STYLE.Realistic;
        public BATTLEGROUND_STYLE BattlegroundStyle
        {
            get { return (BATTLEGROUND_STYLE)_battlegroundStyle; }
            set { _battlegroundStyle = (int)value; CrossSettings.Current.AddOrUpdateValue("battlegroundStyle", (int)value); this.ApplyValues(); }
        }

        private bool _advertisements = true;
        public bool Advertisements
        {
            get { return _advertisements; }
            set { _advertisements = value; CrossSettings.Current.AddOrUpdateValue("advertisements", value); this.ApplyValues(); }
        }

        private bool _gameTipProLevelShow = true;
        public bool GameTipProLevelShow
        {
            get { return _gameTipProLevelShow; }
            set { _gameTipProLevelShow = value; CrossSettings.Current.AddOrUpdateValue("gameTipProLevelShow", value); this.ApplyValues(); }
        }

        private bool _gameTipEnemyPickerShow = true;
        public bool GameTipEnemyPickerShow
        {
            get { return _gameTipEnemyPickerShow; }
            set { _gameTipEnemyPickerShow = value; CrossSettings.Current.AddOrUpdateValue("gameTipEnemyPickerShow", value); this.ApplyValues(); }
        }

        private bool _gameTipWeaponPickerShow = true;
        public bool GameTipWeaponPickerShow
        {
            get { return _gameTipWeaponPickerShow; }
            set { _gameTipWeaponPickerShow = value; CrossSettings.Current.AddOrUpdateValue("gameTipWeaponPickerShow", value); this.ApplyValues(); }
        }

        private bool _gameTipBattlegroundPickerShow = true;
        public bool GameTipBattlegroundPickerShow
        {
            get { return _gameTipBattlegroundPickerShow; }
            set { _gameTipBattlegroundPickerShow = value; CrossSettings.Current.AddOrUpdateValue("gameTipBattlegroundPickerShow", value); this.ApplyValues(); }
        }        

        private bool _gameTipGamePlayShow = true;
        public bool GameTipGamePlayShow
        {
            get { return _gameTipGamePlayShow; }
            set { _gameTipGamePlayShow = value; CrossSettings.Current.AddOrUpdateValue("gameTipGamePlayShow", value); }
        }

        private bool _alienGameTipGamePlayShow = true;
        public bool AlienGameTipGamePlayShow
        {
            get { return _alienGameTipGamePlayShow; }
            set { _alienGameTipGamePlayShow = value; CrossSettings.Current.AddOrUpdateValue("alienGameTipGamePlayShow", value); }
        }

        private bool _gamePauseFriendly = false;
        public bool GamePauseFriendly
        {
            get { return _gamePauseFriendly; }
            set { _gamePauseFriendly = value; CrossSettings.Current.AddOrUpdateValue("gamePauseFriendly", value); }
        }

        private int _controlType = (int)CONTROL_TYPE.GYROSCOPE; 
        public CONTROL_TYPE ControlType 
        { 
            get { return (CONTROL_TYPE)_controlType; } 
            set { _controlType = (int)value; CrossSettings.Current.AddOrUpdateValue("controlType", (int)value); } 
        }


        private int _sensitivityLevel = 4;
        public int SensitivityLevel
        {
            get { return _sensitivityLevel; }
            set { _sensitivityLevel = value; CrossSettings.Current.AddOrUpdateValue("sensitivityLevel", value); }
        }

        private bool _rightHanded = true;
        public bool RightHanded
        {
            get { return _rightHanded; }
            set { _rightHanded = value; CrossSettings.Current.AddOrUpdateValue("rightHanded", value); }
        }

        private bool _showSteeringTip = true;
        public bool ShowSteeringTip
        {
            get { return _showSteeringTip; }
            set { _showSteeringTip = value; CrossSettings.Current.AddOrUpdateValue("showSteeringTip", value); }
        }

		private bool _isPushNotificationEnabled;
        public bool IsPushNotificationEnabled
        {
			get { return _isPushNotificationEnabled; }
			set { _isPushNotificationEnabled = value; CrossSettings.Current.AddOrUpdateValue("isPushNotificationEnabled", value); }
        }

		public int GetTodaySessionDuration()
        {
			//get duration in secconds
			var stringDate = DateTime.Now.ToString("dd-MM-yyyy") + ("duration");
            var todaySessionDuration = CrossSettings.Current.GetValueOrDefault(stringDate, 0);

			return todaySessionDuration;
        }

		private double _timeToNewAd;
		public double TimeToNewAd
        {
			get { return _timeToNewAd; }
			set { _timeToNewAd = value; CrossSettings.Current.AddOrUpdateValue("TimeToNewAd", value); }
        }

		private DateTime _timeWhenPageAdsLeaved;
        public DateTime TimeWhenPageAdsLeaved
        {
			get { return _timeWhenPageAdsLeaved; }
			set { _timeWhenPageAdsLeaved = value; CrossSettings.Current.AddOrUpdateValue("TimeWhenPageAdsLeaved", value); }
        }

        public void SetTodaySessionDuration(int duration, bool clearAll = false)
        {
			var stringDate = DateTime.Now.ToString("dd-MM-yyyy") + ("duration");

			var alreadyPlayedTime = GetTodaySessionDuration();

			int totalTodayPlayd;

			if(clearAll)
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

		private bool _isAskForNotificationToday;
        public bool IsAskForNotificationToday
        {
			get { return _isAskForNotificationToday; }
			set { _isAskForNotificationToday = value; CrossSettings.Current.AddOrUpdateValue("isAskForNotificationToday", value); }
        }
    }    
}
