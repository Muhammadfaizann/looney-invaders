using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;
using LooneyInvaders.PNS;
using LooneyInvaders.Services.PNS;

namespace LooneyInvaders.Layers
{
    public class SettingsScreenLayer : CCLayerColorExt
    {
        IOpenSettingsService _openSettingsService;

        CCSpriteTwoStateButton _btnMusicState;
        CCSpriteTwoStateButton _btnMusicStyle;
        CCSpriteTwoStateButton _btnSoundState;
        CCSpriteTwoStateButton _btnBattleGroundStyle;
        CCSpriteTwoStateButton _btnVibrationState;
        CCSpriteTwoStateButton _btnAdvertisements;
        CCSpriteTwoStateButton _btnNotifications;
        CCSpriteTwoStateButton _btnPushNotifications;
        CCSpriteTwoStateButton _btnVoiceOvers;
        CCSpriteTwoStateButton _btnSwearing;
        CCSpriteTwoStateButton _btnControlType;
        CCSpriteTwoStateButton _btnHandeness;

        CCSpriteButton _btnBack;

        CCSpriteButton _btnForward;
        CCSpriteButton _btnMusicMinus;
        CCSpriteButton _btnMusicPlus;
        CCSpriteButton _btnSoundMinus;
        CCSpriteButton _btnSoundPlus;
        CCSpriteButton _btnPlayerName;

        CCSpriteButton _btnResetSensitivity;

        CCLabel _lblPlayerName;

        CCNodeExt _pg1;
        CCNodeExt _pg2;
        CCNodeExt _pg3;

        CCSpriteButton _btnSenseMinus;
        CCSpriteButton _btnSensePlus;

        CCSprite _imgMusicVolume;
        CCSprite _imgSoundVolume;

        CCSprite _imgSenseLevel;

        CCSprite _imgAdvertisementsTip;
        CCSpriteButton _btnNoAdvertisements;
        CCSpriteButton _btnCancel;

        CCSprite _imgHandinessText;

        GamePlayLayer _layerBack;

        GamePlayLayer _steeringTestLayer;

        List<CCSprite> titlAngleIndicator;
        List<CCSprite> canonSpeedIndicator;

        CCSprite _tiltAngle;
        string _fromPage;

        public string Test { get; set; }

        public SettingsScreenLayer(GamePlayLayer layerBack = null, string fromPage = null)
        {
            titlAngleIndicator = new List<CCSprite>();
            canonSpeedIndicator = new List<CCSprite>();

            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Voiceover on VO_mono.wav");
            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Voiceover off VO_mono.wav");

            //Sound effects for swearing
            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/swearing_on_vo_mono.wav");
            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/swearing_off_vo_mono.wav");

            this._layerBack = layerBack;
            this.SetBackground("UI/background.jpg");
            _fromPage = fromPage;

            _btnBack = this.AddButton(2, 578, "UI/back-button-untapped.png", "UI/back-button-tapped.png", 100, BUTTON_TYPE.Back);
            _btnBack.OnClick += BtnBack_OnClick;
            Shared.GameDelegate.OnBackButton += BtnBack_OnClick;

            _btnForward = this.AddButton(930, 578, "UI/forward-button-untapped.png", "UI/forward-button-tapped.png", 100, BUTTON_TYPE.Forward);
            _btnForward.OnClick += BtnForward_OnClick;

            this.AddImage(319, 574, "UI/Settings_settings_text.png", 1500);

            _pg1 = new CCNodeExt();
            _pg1.AddImage(786, 594, "UI/Settings_page1-3_text.png");

            _pg1.AddImage(68, 481, "UI/Settings-music-text.png");
            _btnMusicState = _pg1.AddTwoStateButton(245, 477, "UI/Settings-on_off-button-untapped.png", "UI/Settings-on_off-button-tapped.png", "UI/Settings-on_off-button-tapped.png", "UI/Settings-on_off-button-untapped.png");
            _btnMusicState.ButtonType = BUTTON_TYPE.OnOff;
            _btnMusicState.OnClick += BtnMusicState_OnClick;

            _btnMusicMinus = _pg1.AddButton(75, 406, "UI/minus-button-untapped.png", "UI/minus-button-tapped.png");
            _btnMusicMinus.OnClick += BtnMusicMinus_OnClick;
            _btnMusicMinus.ButtonType = BUTTON_TYPE.Silent;

            _btnMusicPlus = _pg1.AddButton(161, 405, "UI/plus-button-untapped.png", "UI/plus-button-tapped.png");
            _btnMusicPlus.OnClick += BtnMusicPlus_OnClick;
            _btnMusicPlus.ButtonType = BUTTON_TYPE.Silent;

            _pg1.AddImage(253, 399, "UI/Settings-volume-text.png");
            _imgMusicVolume = _pg1.AddImage(487, 409, "UI/Settings-loudness-indicator-level8-ON-stage.png");

            _pg1.AddImage(66, 319, "UI/Settings-sound-text.png");
            _btnSoundState = _pg1.AddTwoStateButton(275, 318, "UI/Settings-on_off-button-untapped.png", "UI/Settings-on_off-button-tapped.png", "UI/Settings-on_off-button-tapped.png", "UI/Settings-on_off-button-untapped.png");
            _btnSoundState.ButtonType = BUTTON_TYPE.OnOff;
            _btnSoundState.OnClick += BtnSoundState_OnClick;

            _btnSoundMinus = _pg1.AddButton(75, 246, "UI/minus-button-untapped.png", "UI/minus-button-tapped.png");
            _btnSoundMinus.OnClick += BtnSoundMinus_OnClick;
            _btnSoundMinus.ButtonType = BUTTON_TYPE.Silent;

            _btnSoundPlus = _pg1.AddButton(161, 245, "UI/plus-button-untapped.png", "UI/plus-button-tapped.png");
            _btnSoundPlus.OnClick += BtnSoundPlus_OnClick;
            _btnSoundPlus.ButtonType = BUTTON_TYPE.Silent;

            _pg1.AddImage(250, 241, "UI/Settings-volume-for-sounds-text.png");
            _imgSoundVolume = _pg1.AddImage(487, 249, "UI/Settings-loudness-indicator-level8-ON-stage.png");

            _pg1.AddImage(68, 164, "UI/Settings-music-style-text.png");
            _btnMusicStyle = _pg1.AddTwoStateButton(392, 162, "UI/Settings-instrumental-button-untapped.png", "UI/Settings-instrumental-button-tapped.png", "UI/Settings-beatbox-button-untapped.png", "UI/Settings-beatbox-button-tapped.png");
            _btnMusicStyle.OnClick += BtnMusicStyle_OnClick;

            _pg1.AddImage(68, 87, "UI/Settings_voice-overs_text.png");
            _btnVoiceOvers = _pg1.AddTwoStateButton(392, 85, "UI/Settings-on_off-button-untapped.png", "UI/Settings-on_off-button-tapped.png", "UI/Settings-on_off-button-tapped.png", "UI/Settings-on_off-button-untapped.png");
            _btnVoiceOvers.ButtonType = BUTTON_TYPE.Silent;
            _btnVoiceOvers.OnClick += BtnVoiceOvers_OnClick;

            _pg1.AddImage(68, 10, "UI/Settings_swearing_text.png");
            _btnSwearing = _pg1.AddTwoStateButton(348, 8, "UI/Settings-on_off-button-untapped.png", "UI/Settings-on_off-button-tapped.png", "UI/Settings-on_off-button-tapped.png", "UI/Settings-on_off-button-untapped.png");
            _btnSwearing.ButtonType = BUTTON_TYPE.Silent;
            _btnSwearing.OnClick += BtnSwearing_OnClick;

            this.AddChild(_pg1);

            _pg2 = new CCNodeExt();
            _pg2.AddImage(786, 594, "UI/Settings_page2-3_text.png");

            _pg2.AddImage(71, 468, "UI/Settings_your_player_name_text.png");
            _lblPlayerName = _pg2.AddLabel(546, 494, Player.Instance.Name, "Fonts/AktivGroteskBold", 16);
            _lblPlayerName.Scale = 2;

            _pg2.AddImage(71, 390, "UI/Settings_change_player_name_text.png");
            _btnPlayerName = _pg2.AddButton(600, 388, "UI/Settings_tap_here_button_untapped.png", "UI/Settings_tap_here_button_tapped.png");
            _btnPlayerName.ButtonType = BUTTON_TYPE.Regular;
            _btnPlayerName.OnClick += BtnPlayerName_OnClick;

            _pg2.AddImage(70, 318, "UI/Settings-vibration-text.png");

            _btnVibrationState = _pg2.AddTwoStateButton(328, 316, "UI/Settings-on_off-button-untapped.png", "UI/Settings-on_off-button-tapped.png", "UI/Settings-on_off-button-tapped.png", "UI/Settings-on_off-button-untapped.png");
            _btnVibrationState.ButtonType = BUTTON_TYPE.OnOff;
            _btnVibrationState.OnClick += BtnVibrationState_OnClick;

            _pg2.AddImage(63, 240, "UI/Settings-battleground-style-text.png");

            _btnBattleGroundStyle = _pg2.AddTwoStateButton(590, 238, "UI/Settings-realistic-button-untapped.png", "UI/Settings-realistic-button-tapped.png", "UI/Settings-cartonic-button-untapped.png", "UI/Settings-cartonic-button-tapped.png");
            _btnBattleGroundStyle.OnClick += BtnBattleGroundStyle_OnClick;

            _pg2.AddImage(72, 164, "UI/game-instructions-text.png");

            _btnNotifications = _pg2.AddTwoStateButton(580, 162, "UI/Settings-on_off-button-untapped.png", "UI/Settings-on_off-button-tapped.png", "UI/Settings-on_off-button-tapped.png", "UI/Settings-on_off-button-untapped.png");
            _btnNotifications.ButtonType = BUTTON_TYPE.Silent;
            _btnNotifications.OnClick += BtnNotifications_OnClick;

            _pg2.AddImage(72, 88, "UI/Settings-advertisements-text.png");

            _btnAdvertisements = _pg2.AddTwoStateButton(490, 86, "UI/Settings-on_off-button-untapped.png", "UI/Settings-on_off-button-tapped.png", "UI/Settings-on_off-button-tapped.png", "UI/Settings-on_off-button-untapped.png");
            _btnAdvertisements.ButtonType = BUTTON_TYPE.Silent;
            _btnAdvertisements.OnClick += BtnAdvertisements_OnClick;

            _pg2.AddImage(72, 12, "UI/push-notifications-text.png");

            _btnPushNotifications = _pg2.AddTwoStateButton(580, 10, "UI/Settings-on_off-button-untapped.png", "UI/Settings-on_off-button-tapped.png", "UI/Settings-on_off-button-tapped.png", "UI/Settings-on_off-button-untapped.png");
            _btnPushNotifications.ButtonType = BUTTON_TYPE.Silent;
            _btnPushNotifications.OnClick += BtnPushNotifications_OnClick;

            _imgAdvertisementsTip = this.AddImage(14, 8, "UI/Settings-notification-background-with-text.png", 1500);
            _imgAdvertisementsTip.Visible = false;

            _btnNoAdvertisements = this.AddButton(33, 30, "UI/Settings-notification-buy-add-free-button-untapped.png", "UI/Settings-notification-buy-add-free-button-tapped.png", 1600);
            _btnNoAdvertisements.ButtonType = BUTTON_TYPE.OnOff;
            _btnNoAdvertisements.Visible = false;
            _btnNoAdvertisements.OnClick += _btnNoAdvertisements_OnClick;

            _btnCancel = this.AddButton(637, 30, "UI/Settings-notification-cancel-button-untapped.png", "UI/Settings-notification-cancel-button-tapped.png", 1600);
            _btnCancel.OnClick += _btnCancel_OnClick; ;
            _btnCancel.Visible = false;

            this.AddChild(_pg2);
            _pg2.Visible = false;

            //Setting up a page 3 for settings
            _pg3 = new CCNodeExt();

            //Creating a game scene as an object to place in page 3 of settings
            //_steeringTestLayer = new GamePlayLayer(ENEMIES.TRUMP, (WEAPONS)0, BATTLEGROUNDS.CURTAINS, false, 1, 1, 1, 3, ENEMIES.TRUMP, LAUNCH_MODE.STEERING_TEST);
            //_pg3.AddChild(_steeringTestLayer);

            _pg3.AddImage(786, 594, "UI/Settings_page3-3_text.png", 100);

            //Setting up control settings button and label
            _pg3.AddImage(68, 464, "UI/Settings_steering-system_text.png", 100);
            _btnControlType = _pg3.AddTwoStateButton(488, 461, "UI/Settings_tilt-steering-button-untapped.png", "UI/Settings_tilt-steering-button-tapped.png", "UI/Settings_touch-steering-button-untapped.png", "UI/Settings_touch-steering-button-tapped.png");
            _btnControlType.OnClick += BtControlType_OnClick;

            if (Settings.Instance.ControlType == CONTROL_TYPE.MANUAL)
            {
                //Setting up handeness for controll
                AddHandinessSettings();
            }

            //Settig up sensitivity level
            _btnSenseMinus = _pg3.AddButton(75, 315, "UI/minus-button-untapped.png", "UI/minus-button-tapped.png");
            _btnSenseMinus.OnClick += BtnSenseLevelMinus_OnClick;
            _btnSenseMinus.ButtonType = BUTTON_TYPE.Silent;

            _btnSensePlus = _pg3.AddButton(161, 312, "UI/plus-button-untapped.png", "UI/plus-button-tapped.png");
            _btnSensePlus.OnClick += BtnSenseLevelPlus_OnClick;
            _btnSensePlus.ButtonType = BUTTON_TYPE.Silent;

            _pg3.AddImage(253, 313, "UI/Settings-sensitivity-text.png", 100);
            _imgSenseLevel = _pg3.AddImage(575, 313, "UI/Settings-loudness-indicator-level7-ON-stage.png", 100);

            //Resetting sensitivity
            _pg3.AddImage(68, 230, "UI/Settings_reset-sensitivity-text.png", 100);
            _btnResetSensitivity = _pg3.AddButton(538, 227, "UI/Settings_reset-button-untapped.png", "UI/Settings_reset-button-tapped.png");
            _btnResetSensitivity.OnClick += BtnRexetSensitivity_OnClick;

            _pg3.AddImage(68, 156, "UI/Settings_cannon-speed_text.png", 100);

            if (Settings.Instance.ControlType == CONTROL_TYPE.GYROSCOPE)
            {
                _tiltAngle = _pg3.AddImage(569, 156, "UI/Settings_tilt-angle_text.png", 100);
            }


            this.AddChild(_pg3);
            _pg3.Visible = false;

            refreshSettings();

            GameEnvironment.PlayMusic(MUSIC.MAIN_MENU, false);

            PurchaseManager.OnPurchaseFinished += PurchaseManager_OnPurchaseFinished;
            _openSettingsService = new OpenSettingsService();

            SetAdditionalBackBtn();
        }

        private void _btnCancel_OnClick(object sender, EventArgs e)
        {
            hideAdvertisementsTip();
        }

        public void RefreshPlayerName()
        {
            _pg2.RemoveChild(_lblPlayerName);
            _lblPlayerName = _pg2.AddLabel(546, 494, Player.Instance.Name, "Fonts/AktivGroteskBold", 16);
            _lblPlayerName.Scale = 2;
        }

        private void showAdvertisementsTip()
        {
            _btnMusicState.Enabled = false;
            _btnMusicStyle.Enabled = false;
            _btnSoundState.Enabled = false;
            _btnBattleGroundStyle.Enabled = false;
            _btnVibrationState.Enabled = false;
            _btnAdvertisements.Enabled = false;
            _btnBack.Enabled = false;
            _btnMusicMinus.Enabled = false;
            _btnMusicPlus.Enabled = false;
            _btnSoundMinus.Enabled = false;
            _btnSoundPlus.Enabled = false;
            _btnPlayerName.Enabled = false;

            _imgAdvertisementsTip.Visible = true;
            _btnNoAdvertisements.Visible = true;
            _btnCancel.Visible = true;
        }

        private void hideAdvertisementsTip()
        {
            _btnMusicState.Enabled = true;
            _btnMusicStyle.Enabled = true;
            _btnSoundState.Enabled = true;
            _btnBattleGroundStyle.Enabled = true;
            _btnVibrationState.Enabled = true;
            _btnAdvertisements.Enabled = true;
            _btnBack.Enabled = true;
            _btnMusicMinus.Enabled = true;
            _btnMusicPlus.Enabled = true;
            _btnSoundMinus.Enabled = true;
            _btnSoundPlus.Enabled = true;
            _btnPlayerName.Enabled = true;

            _imgAdvertisementsTip.Visible = false;
            _btnNoAdvertisements.Visible = false;
            _btnCancel.Visible = false;
        }

        private void refreshSettings()
        {
            Settings settings = Settings.Instance;

            _btnMusicState.State = settings.MusicEnabled == true ? 1 : 2;
            _btnMusicState.SetStateImages();

            if (settings.MusicEnabled)
            {
                if (settings.MusicVolume == 0) ChangeSpriteImage(_imgMusicVolume, "UI/Settings-loudness-indicator-level0.png");
                else ChangeSpriteImage(_imgMusicVolume, "UI/Settings-loudness-indicator-level" + settings.MusicVolume.ToString() + "-ON-stage.png");
            }
            else
            {
                if (settings.MusicVolume == 0) ChangeSpriteImage(_imgMusicVolume, "UI/Settings-loudness-indicator-level0.png");
                else ChangeSpriteImage(_imgMusicVolume, "UI/Settings-loudness-indicator-level" + settings.MusicVolume.ToString() + "-OFF-stage.png");
            }

            _imgMusicVolume.BlendFunc = GameEnvironment.BlendFuncDefault;

            _btnSoundState.State = settings.SoundEnabled == true ? 1 : 2;
            _btnSoundState.SetStateImages();

            _btnVoiceOvers.State = settings.VoiceoversEnabled == true ? 1 : 2;
            _btnVoiceOvers.SetStateImages();

            _btnSwearing.State = settings.SwearingEnabled == true ? 1 : 2;
            _btnSwearing.SetStateImages();

            _btnControlType.State = settings.ControlType == CONTROL_TYPE.GYROSCOPE ? 1 : 2;
            _btnControlType.SetStateImages();

            if (_btnHandeness != null)
            {
                _btnHandeness.State = settings.RightHanded ? 1 : 2;
                _btnHandeness.SetStateImages();
            }

            if (settings.SensitivityLevel == 0) ChangeSpriteImage(_imgSenseLevel, "UI/Settings-loudness-indicator-level0.png");
            else ChangeSpriteImage(_imgSenseLevel, "UI/Settings-loudness-indicator-level" + settings.SensitivityLevel.ToString() + "-ON-stage.png");

            if (settings.SoundEnabled)
            {
                if (settings.SoundVolume == 0) ChangeSpriteImage(_imgSoundVolume, "UI/Settings-loudness-indicator-level0.png");
                else ChangeSpriteImage(_imgSoundVolume, "UI/Settings-loudness-indicator-level" + settings.SoundVolume.ToString() + "-ON-stage.png");
            }
            else
            {
                if (settings.SoundVolume == 0) ChangeSpriteImage(_imgSoundVolume, "UI/Settings-loudness-indicator-level0.png");
                else ChangeSpriteImage(_imgSoundVolume, "UI/Settings-loudness-indicator-level" + settings.SoundVolume.ToString() + "-OFF-stage.png");
            }

            _imgSoundVolume.BlendFunc = GameEnvironment.BlendFuncDefault;

            _btnMusicStyle.State = settings.MusicStyle == MUSIC_STYLE.Instrumental ? 1 : 2;
            _btnMusicStyle.SetStateImages();

            _btnVibrationState.State = settings.Vibration == true ? 1 : 2;
            _btnVibrationState.SetStateImages();

            _btnBattleGroundStyle.State = settings.BattlegroundStyle == BATTLEGROUND_STYLE.Realistic ? 1 : 2;
            _btnBattleGroundStyle.SetStateImages();

            _btnNotifications.State = settings.NotificationsEnabled == true ? 1 : 2;
            _btnNotifications.SetStateImages();

            var notificationsAllowed = new NotificationAllowedService();
            Settings.Instance.IsPushNotificationEnabled = notificationsAllowed.IsNotificationsAllowed();

            _btnPushNotifications.State = settings.IsPushNotificationEnabled == true ? 1 : 2;
            _btnPushNotifications.SetStateImages();

            _btnAdvertisements.State = settings.Advertisements == true ? 1 : 2;
            _btnAdvertisements.SetStateImages();
            if (LooneyInvaders.Model.Settings.Instance.Advertisements == false) _btnAdvertisements.Enabled = false;
        }

        private void BtnSoundPlus_OnClick(object sender, EventArgs e)
        {
            if (Settings.Instance.SoundVolume < 8)
            {
                Settings.Instance.SoundVolume++;
                refreshSettings();
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_VOLUME_CHANGE);
            }
            else
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
            }
        }

        private void BtnSoundMinus_OnClick(object sender, EventArgs e)
        {
            if (Settings.Instance.SoundVolume > 0)
            {
                Settings.Instance.SoundVolume--;
                refreshSettings();
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_VOLUME_CHANGE);
            }
            else
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
            }
        }

        private void BtnMusicPlus_OnClick(object sender, EventArgs e)
        {
            if (Settings.Instance.MusicVolume < 8)
            {
                Settings.Instance.MusicVolume++;
                refreshSettings();
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_MINUS);
            }
            else
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
            }
        }

        private void BtnMusicMinus_OnClick(object sender, EventArgs e)
        {
            if (Settings.Instance.MusicVolume > 0)
            {
                Settings.Instance.MusicVolume--;
                refreshSettings();
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_MINUS);
            }
            else
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
            }
        }

        private void BtnRexetSensitivity_OnClick(object sender, EventArgs e)
        {
            Settings.Instance.SensitivityLevel = 4;
            refreshSettings();
        }

        private void BtnSenseLevelPlus_OnClick(object sender, EventArgs e)
        {
            if (Settings.Instance.SensitivityLevel < 8)
            {
                Settings.Instance.SensitivityLevel++;
                refreshSettings();
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_MINUS);

                if (Settings.Instance.ControlType == CONTROL_TYPE.MANUAL)
                {
                    RemoveManualSensitivityLevel();
                }
                else
                {
                    RemoveGyroSensitivityLevel();
                }
            }
            else
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
            }
        }

        private void BtnSenseLevelMinus_OnClick(object sender, EventArgs e)
        {
            if (Settings.Instance.SensitivityLevel > 1)
            {
                Settings.Instance.SensitivityLevel--;
                refreshSettings();
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_MINUS);

                if (Settings.Instance.ControlType == CONTROL_TYPE.MANUAL)
                {
                    RemoveManualSensitivityLevel();
                }
                else
                {
                    RemoveGyroSensitivityLevel();
                }
            }
            else
            {
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
            }
        }

        private void BtnAdvertisements_OnClick(object sender, EventArgs e)
        {
            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
            showAdvertisementsTip();
        }

        private void BtnVibrationState_OnClick(object sender, EventArgs e)
        {
            _btnVibrationState.ChangeState();

            if (_btnVibrationState.State == 1)
            {
                Settings.Instance.Vibration = true;
                VibrationManager.Vibrate();
            }
            else Settings.Instance.Vibration = false;

            refreshSettings();
        }

        private void BtnSoundState_OnClick(object sender, EventArgs e)
        {
            _btnSoundState.ChangeState();
            if (_btnSoundState.State == 1) Settings.Instance.SoundEnabled = true;
            else Settings.Instance.SoundEnabled = false;

            refreshSettings();
        }

        private void BtnMusicState_OnClick(object sender, EventArgs e)
        {
            _btnMusicState.ChangeState();

            if (_btnMusicState.State == 1) Settings.Instance.MusicEnabled = true;
            else Settings.Instance.MusicEnabled = false;

            refreshSettings();
        }

        private void BtnBattleGroundStyle_OnClick(object sender, EventArgs e)
        {
            _btnBattleGroundStyle.ChangeState();

            if (_btnBattleGroundStyle.State == 1) Settings.Instance.BattlegroundStyle = BATTLEGROUND_STYLE.Realistic;
            else Settings.Instance.BattlegroundStyle = BATTLEGROUND_STYLE.Cartonic;

            refreshSettings();
        }

        private void BtnMusicStyle_OnClick(object sender, EventArgs e)
        {
            _btnMusicStyle.ChangeState();

            if (_btnMusicStyle.State == 1) Settings.Instance.MusicStyle = MUSIC_STYLE.Instrumental;
            else Settings.Instance.MusicStyle = MUSIC_STYLE.Beatbox;

            refreshSettings();
        }

        private void BtnNotifications_OnClick(object sender, EventArgs e)
        {
            //------------ Prabhjot ------------//
            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP);

            _btnNotifications.ChangeState();

            if (_btnNotifications.State == 1)
            {
                Settings.Instance.NotificationsEnabled = true;
                Settings.Instance.GameTipProLevelShow = true;
                Settings.Instance.GameTipEnemyPickerShow = true;
                Settings.Instance.GameTipWeaponPickerShow = true;
                Settings.Instance.GameTipBattlegroundPickerShow = true;
                Settings.Instance.GameTipGamePlayShow = true;
            }
            else Settings.Instance.NotificationsEnabled = false;

            refreshSettings();
        }

        private void BtnPushNotifications_OnClick(object sender, EventArgs e)
        {
            //------------ Prabhjot ------------//
            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP);

            _btnPushNotifications.ChangeState();

            this.ScheduleOnce(openSettings, 0.50f);

            refreshSettings();
        }
        private void openSettings(float obj)
        {
            _openSettingsService.OpenNotificationSettings();
        }

        private void BtnVoiceOvers_OnClick(object sender, EventArgs e)
        {
            _btnVoiceOvers.ChangeState();
            if (_btnVoiceOvers.State == 1) Settings.Instance.VoiceoversEnabled = true;
            else Settings.Instance.VoiceoversEnabled = false;
            CCAudioEngine.SharedEngine.StopAllEffects();
            if (Settings.Instance.VoiceoversEnabled)
                CCAudioEngine.SharedEngine.PlayEffect("Sounds/Voiceover on VO_mono.wav");
            else
                CCAudioEngine.SharedEngine.PlayEffect("Sounds/Voiceover off VO_mono.wav");
            refreshSettings();
        }

        private void BtnSwearing_OnClick(object sender, EventArgs e)
        {
            _btnSwearing.ChangeState();
            string state = "on";

            if (_btnSwearing.State == 1) Settings.Instance.SwearingEnabled = true;
            else Settings.Instance.SwearingEnabled = false;

            state = Settings.Instance.SwearingEnabled ? state : "off";

            CCAudioEngine.SharedEngine.StopAllEffects();
            CCAudioEngine.SharedEngine.PlayEffect($"Sounds/swearing_{state}_vo_mono.wav");

            refreshSettings();
        }

        private void BtnBack_OnClick(object sender, EventArgs e)
        {
            if (_pg1.Visible)
            {
                Shared.GameDelegate.ClearOnBackButtonEvent();

                if (_layerBack != null)
                {
                    PurchaseManager.OnPurchaseFinished -= PurchaseManager_OnPurchaseFinished;
                    Shared.GameDelegate.OnBackButton -= BtnBack_OnClick;
                    _layerBack.isCartoonFadeIn = false;
                    Director.PopScene();
                    _layerBack.Continue();
                    //this.TransitionToPoppedLayerCartoonStyle();
                }
                else
                {
                    PurchaseManager.OnPurchaseFinished -= PurchaseManager_OnPurchaseFinished;

                    this.TransitionToLayerCartoonStyle(new MainScreenLayer());
                }
            }
            else if (!_pg2.Visible)
            {
                _pg1.Visible = false;
                _pg2.Visible = true;
                _pg3.Visible = false;

                _steeringTestLayer.StopAllActions();
                _pg3.RemoveChild(_steeringTestLayer, true);
                GameEnvironment.PlayMusic(MUSIC.MAIN_MENU, true);

                _btnForward.Visible = true;

                Unschedule(UpdateSteeringSpeedIndicator);
            }
            else if (!_pg1.Visible)
            {
                _pg1.Visible = true;
                _pg2.Visible = false;
                _pg3.Visible = false;
                _btnForward.Visible = true;
            }
        }

        private void BtnForward_OnClick(object sender, EventArgs e)
        {
            if (!_pg2.Visible)
            {
                _pg1.Visible = false;
                _pg2.Visible = true;
                _pg3.Visible = false;
                _btnForward.Visible = true;
            }
            else if (!_pg3.Visible)
            {
                _pg1.Visible = false;
                _pg2.Visible = false;

                _steeringTestLayer = new GamePlayLayer(ENEMIES.TRUMP, (WEAPONS)0, BATTLEGROUNDS.CURTAINS, false, 1, 1, 1, 3, ENEMIES.TRUMP, LAUNCH_MODE.STEERING_TEST);
                _pg3.AddChild(_steeringTestLayer);
                _pg3.Visible = true;
                _btnForward.Visible = false;

                Schedule(UpdateSteeringSpeedIndicator, 0.16f);
            }
            else
            {
                if (_layerBack != null)
                {
                    PurchaseManager.OnPurchaseFinished -= PurchaseManager_OnPurchaseFinished;

                    _layerBack.isCartoonFadeIn = false;
                    Director.PopScene();
                    _layerBack.Continue();
                    //this.TransitionToPoppedLayerCartoonStyle();
                }
                else
                {
                    PurchaseManager.OnPurchaseFinished -= PurchaseManager_OnPurchaseFinished;

                    this.TransitionToLayerCartoonStyle(new MainScreenLayer());
                }
            }
        }


        private void BtnPlayerName_OnClick(object sender, EventArgs e)
        {
            CCScene newScene = new CCScene(this.GameView);
            newScene.AddLayer(new PlayerNameLayer(this));
            Director.PushScene(newScene);
        }

        private void _btnNoAdvertisements_OnClick(object sender, EventArgs e)
        {
            hideAdvertisementsTip();
            PurchaseManager.Purchase("ads_off");
            this.Enabled = false;
        }

        private void PurchaseManager_OnPurchaseFinished(object sender, EventArgs e)
        {
            _btnAdvertisements.State = LooneyInvaders.Model.Settings.Instance.Advertisements == true ? 1 : 2;
            if (LooneyInvaders.Model.Settings.Instance.Advertisements == false) _btnAdvertisements.Enabled = false;
            _btnAdvertisements.SetStateImages();
            this.Enabled = true;
        }

        private void AddHandinessSettings()
        {
            _imgHandinessText = _pg3.AddImage(75, 390, "UI/Settings-handedness-text.png", 100);
            _btnHandeness = _pg3.AddTwoStateButton(400, 387, "UI/Settings_right-button-untapped.png", "UI/Settings_right-button-tapped.png", "UI/Settings_left-button-untapped.png", "UI/Settings_left-button-tapped.png");
            _btnHandeness.OnClick += BtnHandeness_OnClick;
        }

        private void BtnHandeness_OnClick(object sender, EventArgs e)
        {
            _btnHandeness.ChangeState();

            Settings.Instance.RightHanded = _btnHandeness.State == 1;
            refreshSettings();

            _steeringTestLayer.SetUpSteering(true);
        }

        private void BtControlType_OnClick(object sender, EventArgs e)
        {
            _btnControlType.ChangeState();

            if (_btnControlType.State == 1)
            {
                Settings.Instance.ControlType = CONTROL_TYPE.GYROSCOPE;
                _pg3.RemoveChild(_imgHandinessText);
                _pg3.RemoveChild(_btnHandeness);
                _tiltAngle = _pg3.AddImage(569, 156, "UI/Settings_tilt-angle_text.png", 100);

            }
            else
            {
                Settings.Instance.ControlType = CONTROL_TYPE.MANUAL;
                AddHandinessSettings();
                _pg3.RemoveChild(_tiltAngle);
                RemoveGyroSensitivityLevel();
            }

            _steeringTestLayer.SetUpSteering(true);

            refreshSettings();
        }

        private void AddCanonSpeedIndicatorLevel()
        {
            string speed = string.Empty;
            if (_steeringTestLayer != null)
            {
                speed = ((int)(Math.Abs(_steeringTestLayer.controlMovement) * 100)).ToString();
            }

            int initPosition = 426;

            foreach (var item in speed)
            {
                canonSpeedIndicator.Add(_pg3.AddImage(initPosition, 156, $"UI/number_57_{item}.png", 100));
                initPosition += 27;
            }

            canonSpeedIndicator.Add(_pg3.AddImage(initPosition + 10, 156, "UI/number_57_%.png", 100));
        }

        private void RemoveGyroSensitivityLevel()
        {
            foreach (var item in titlAngleIndicator)
            {
                _pg3.RemoveChild(item);
            }
        }

        private void RemoveManualSensitivityLevel()
        {
            foreach (var item in canonSpeedIndicator)
            {
                _pg3.RemoveChild(item);
            }
        }

        private void AddTiltingAngleLevel()
        {
            int angle = 0;

            if (_steeringTestLayer != null)
            {
                angle = (int)_steeringTestLayer.tiltAngle;
            }

            int initPosition = 850;

            if (angle >= 0)
            {
                titlAngleIndicator.Add(_pg3.AddImage(initPosition, 156, $"UI/number_57_+.png", 100));
                initPosition += 27;
            }

            foreach (var item in angle.ToString())
            {
                titlAngleIndicator.Add(_pg3.AddImage(initPosition, 156, $"UI/number_57_{item}.png", 100));
                initPosition += 27;
            }

            titlAngleIndicator.Add(_pg3.AddImage(initPosition + 10, 156, "UI/number_57_degree-symbol.png", 100));
        }

        private void UpdateSteeringSpeedIndicator(float dt)
        {
            RemoveManualSensitivityLevel();
            AddCanonSpeedIndicatorLevel();

            if (Settings.Instance.ControlType == CONTROL_TYPE.GYROSCOPE)
            {
                RemoveGyroSensitivityLevel();
                AddTiltingAngleLevel();
            }
        }

        private void SetAdditionalBackBtn()
        {
            CCSpriteButton btnBackThrowPg2;
            CCSpriteButton btnBackThrowPg3;

            if (_fromPage == GameConstants.NavigationParam.MainScreen)
            {
                btnBackThrowPg2 = _pg2.AddButton(148, 578, "UI/back-to-home-button-untapped.png", "UI/back-to-home-button-tapped.png", 100, BUTTON_TYPE.Back);
                btnBackThrowPg3 = _pg3.AddButton(148, 578, "UI/back-to-home-button-untapped.png", "UI/back-to-home-button-tapped.png", 100, BUTTON_TYPE.Back);
            }
            else //if(_fromPage == GameConstants.NavigationParam.GameScreen)
            {
                btnBackThrowPg2 = _pg2.AddButton(148, 578, "UI/back-to-battle-button-untapped.png", "UI/back-to-battle-button-tapped.png", 100, BUTTON_TYPE.Back);
                btnBackThrowPg3 = _pg3.AddButton(148, 578, "UI/back-to-battle-button-untapped.png", "UI/back-to-battle-button-tapped.png", 100, BUTTON_TYPE.Back);
            }

            btnBackThrowPg2.OnClick += BtnBackThrow_OnClick;
            btnBackThrowPg3.OnClick += BtnBackThrow_OnClick;

            Shared.GameDelegate.OnBackButton += BtnBackThrow_OnClick;
        }

        private void BtnBackThrow_OnClick(object sender, EventArgs e)
        {
            if (_fromPage == GameConstants.NavigationParam.MainScreen)
            {
                PurchaseManager.OnPurchaseFinished -= PurchaseManager_OnPurchaseFinished;

                this.TransitionToLayerCartoonStyle(new MainScreenLayer());
            }
            else if (_fromPage == GameConstants.NavigationParam.GameScreen)
            {
                PurchaseManager.OnPurchaseFinished -= PurchaseManager_OnPurchaseFinished;
                Shared.GameDelegate.OnBackButton -= BtnBackThrow_OnClick;
                _layerBack.isCartoonFadeIn = false;
                Director.PopScene();
                _layerBack.Continue();
            }

            if (_pg1.Visible)
            {
                Shared.GameDelegate.ClearOnBackButtonEvent();
            }
            else if (!_pg2.Visible)
            {
                _steeringTestLayer.StopAllActions();
                _pg3.RemoveChild(_steeringTestLayer, true);
                GameEnvironment.PlayMusic(MUSIC.MAIN_MENU, true);

                Unschedule(UpdateSteeringSpeedIndicator);
            }
        }
    }
}
