using System;
using System.Collections.Generic;
using CocosSharp;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;
using LooneyInvaders.Shared;
using NotificationCenter;

#if __IOS__
using Foundation;
#endif
namespace LooneyInvaders.Layers
{
    public class GamePlayLayer : CCLayerColorExt
    {
        public static decimal BestScoreTime;
        public static decimal BestScoreAccuracy;
        public static int BestScore;
        public static BATTLEGROUNDS BestScoreCountry;

        public static int BestScoreAlien;
        public static int BestScoreAlienWave;

        public int Kills;
        public float ControlMovement;
        private float _speedTo;
        private float _movingTime;

        public float TiltAngle;

        private readonly List<Bullet> _bullets = new List<Bullet>();
        private readonly List<Enemy> _enemies = new List<Enemy>();
        private readonly List<Bomb> _bombs = new List<Bomb>();
        private readonly List<CCSprite> _ammos = new List<CCSprite>();
        private readonly List<Explosion> _explos = new List<Explosion>();
        private readonly List<CCSprite> _lives = new List<CCSprite>();
        private readonly List<GunSmoke> _gunSmokes = new List<GunSmoke>();
        private readonly List<CCSprite> _multipliers = new List<CCSprite>();
        private readonly List<LaserSpark> _sparks = new List<LaserSpark>();


        //bool Test = false;
        //bool IsTestFromWeaponPicker = false;
        private readonly LAUNCH_MODE _launchMode;

        private float _enemySpeed = 2;
        private float _enemyCurrentSpeed;
        private float _enemyAcceleration;
        private int _bounces;
        private float _goingDown;
        private float _goingDownSpeed = 1;
        private float _goingDownCurrentSpeed = 1;
        private bool _firstGoingDown = true;
        private float _reload;
        private readonly float _reloadTime = 1;
        private CCSprite _reloading;
        private readonly float _playerSpeed = 30;
        private readonly float _bulletScale;
        private readonly float _bulletPower;
        private readonly int _magazineSize;
        private readonly float _gunCooloff;
        private float _gunCoolness;
        private int _bombDensity = 80;
        private readonly float _smokeOffsetY = -40;


        CCSprite _player;
        CCSprite _playerExplosion;
        CCSprite _gameOverExplosion;
        CCSprite[] _time;
        CCSprite _timeLabel;
        CCSprite _multiplierLabel;
        CCSprite _multiplierLabelLabel;
        CCSprite _gameOverLabel;
        int _lastDisplayedTime;
        int _score;
        int _lastDisplayedScore = -1;
        int _scoreMultiplier = 1;
        int _killsWithoutMiss;
        int _fadeLevel;

        float _elapsedTime;
        float _playerExploding;
        float _gameOverExploding;
        float _shitWait;

        int _bulletsFired;
        int _bulletsMissed;

        private float _wavePass;
        private bool _waveTransfer;
        private bool _gameOver;
        private float _updateTillNextBomb;
        private int _wave = 1;

        private int? _cannonMovingFxId;
        //private SOUNDEFFECT? _cannonMovingFx;

        readonly Random _random;

        public string SoundCannonShoot;
        public string VoiceEnemyHit;
        public string VoicePlayerHit;
        public string VoiceGameOver;
        public string VoiceEnemyWound1;
        public string VoiceEnemyWound2;
        public string VoiceEnemyWound3;
        public string VoiceMiss;
        public string VoiceMissAlternate;
        public string EnemyMouthClosed;
        public string EnemyMouthOpen;
        public string EnemyMouthClosedDamaged1;
        public string EnemyMouthOpenDamaged1;
        public string EnemyMouthClosedDamaged2;
        public string EnemyMouthOpenDamaged2;
        public string EnemyGrimace1;
        public string EnemyGrimace2;
        public int EnemyMouthClipHeight;
        public int EnemyMouthClipWidth;
        public string PlayerCannon;
        public string PlayerLivesLeft;
        public string BattlegroundImageName;

        public List<CCPoint> PlayerCollisionPoints = new List<CCPoint>();
        public List<CCPoint> EnemyCollisionPoints = new List<CCPoint>();

        public CCSpriteSheet SsPreExplosion;
        public CCSpriteSheet SsDrooling;
        public CCSpriteSheet SsGameOverExplosion;
        public CCSpriteSheet SsCannonExplosion1;
        public CCSpriteSheet SsCannonExplosion2;
        public CCSpriteSheet SsCannonFlame;
        public CCSpriteSheet SsEnemyExplosion;
        public CCSpriteSheet SsBomb;
        public CCSpriteSheet SsRecoil;
        public CCSpriteSheet SsFlyingSaucer;
        public string SsRecoilKeyPrefix;
        public CCSpriteSheet[] SsHybridLaser;
        public CCSpriteSheet SsLaserSparks;
        public CCSpriteSheet[] SsAlienLensFlare;

        readonly CCSpriteSheet[] _ssFirework;
        float _fireworkFrame;
        int _fireworkFrameLast;

        CCSprite _firework;

        private int _countdown;

        private CCSprite _countdownNumber;
        private CCSprite _fadeShootButton;
        private CCSprite _fadeControlButton;

        public BATTLEGROUNDS SelectedBattleground;
        public ENEMIES SelectedEnemy;
        public WEAPONS SelectedWeapon;

        public ENEMIES SelectedEnemyForPickerScreens;

        public int CaliberSizeSelected;
        public int FireSpeedSelected;
        public int MagazineSizeSelected;
        public int LivesSelected;

        public int LivesLeft;
        public int WinsInSuccession;

        private float _flyingSaucerFrame;
        private float _flyingSaucerWait;
        private float _flyingSaucerSpeed;
        private CCSprite _flyingSaucer;
        private CCSprite _flyingSaucerExplosion;
        private float _flyingSaucerExplosionFrame;
        private float _flyingSaucerIncoming;
        private int? _flyingSaucerFlyingFxId;

        private bool _isCannonMoving;
        private bool _isCannonShooting;

        private readonly CCEventListenerTouchAllAtOnce _touchListener;

        //-------------- Prabhjot -------------//
        bool _isGameOver;


        public GamePlayLayer(ENEMIES selectedEnemy, WEAPONS selectedWeapon, BATTLEGROUNDS selectedBattleground, bool calloutCountryName, int caliberSizeSelected = -1, int fireSpeedSelected = -1, int magazineSizeSelected = -1, int livesSelected = -1, ENEMIES selectedEnemyForPickerScreens = ENEMIES.ALIENS, LAUNCH_MODE launchMode = LAUNCH_MODE.DEFAULT/*bool isTestFromWeaponPicker=false*/, int livesLeft = -1, int winsInSuccession = 0)
        {
            GameDelegate.ClearOnBackButtonEvent();
            EnableMultiTouch = true;

            // ----------- Prabhjot ----------- //
            //this.ScheduleOnce(Victory, 1);
            Settings.isFromGameScreen = true;
            NotificationCenterManager.Instance.AddObserver(OnSwitchIsOn, @"GameInBackground");



            GameAnimation.Instance.FreeAllSpriteSheets();

            _random = new Random();
            _touchListener = new CCEventListenerTouchAllAtOnce();

            _launchMode = launchMode;

            BattlegroundImageName = Battleground.GetBattlegroundImageName(selectedBattleground, Settings.Instance.BattlegroundStyle);

            if (_launchMode == LAUNCH_MODE.DEFAULT)
            {
                if (selectedEnemy == ENEMIES.ALIENS)
                {
                    selectedBattleground = BATTLEGROUNDS.MOON;
                }

                Player.Instance.SetQuickGame(selectedEnemy, selectedBattleground, selectedWeapon);
            }


            SelectedBattleground = selectedBattleground;
            SelectedEnemy = selectedEnemy;
            SelectedWeapon = selectedWeapon;
            CaliberSizeSelected = caliberSizeSelected;
            FireSpeedSelected = fireSpeedSelected;
            MagazineSizeSelected = magazineSizeSelected;
            LivesSelected = livesSelected;
            LivesLeft = livesLeft;
            WinsInSuccession = winsInSuccession;

            SelectedEnemyForPickerScreens = selectedEnemyForPickerScreens;

            switch (selectedEnemy)
            {
                case ENEMIES.PUTIN:
                    if (SelectedBattleground == BATTLEGROUNDS.FINLAND)
                    {
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Firework Sound Effect mono.wav");
                        _ssFirework = new CCSpriteSheet[2];
                        _ssFirework[0] = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/firework-0.plist");
                        _ssFirework[1] = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/firework-1.plist");
                    }
                    VoiceMiss = null;
                    VoiceMissAlternate = null;
                    VoiceEnemyHit = "Sounds/Putin 3 Shit.wav";
                    VoicePlayerHit = "Sounds/Putin 4 Laughs At You.wav";
                    VoiceGameOver = "Sounds/Putin 5 Successful Attack.wav";
                    VoiceEnemyWound1 = "Sounds/Putin_get_wounded1.wav";
                    VoiceEnemyWound2 = "Sounds/Putin_get_wounded2.wav";
                    VoiceEnemyWound3 = "Sounds/Putin_get_wounded3.wav";
                    EnemyMouthClosed = "Enemies/Putin-mouth-closed.png";
                    EnemyMouthClosedDamaged1 = "Enemies/Putin-mouth-closed-bruises.png";
                    EnemyMouthClosedDamaged2 = "Enemies/Putin-mouth-closed-bruises-bandages.png";
                    EnemyMouthOpen = "Enemies/Putin-mouth-open.png";
                    EnemyMouthOpenDamaged1 = "Enemies/Putin-mouth-open-bruises.png";
                    EnemyMouthOpenDamaged2 = "Enemies/Putin-mouth-open-bruises-bandages.png";
                    EnemyGrimace1 = "Enemies/Putin-evil-grimace.png";
                    EnemyGrimace2 = "Enemies/Putin-evil-smile.png";
                    EnemyMouthClipHeight = 45;
                    EnemyMouthClipWidth = 50;
                    EnemyCollisionPoints.Add(new CCPoint(26, 57));
                    EnemyCollisionPoints.Add(new CCPoint(16, 51));
                    EnemyCollisionPoints.Add(new CCPoint(9, 44));
                    EnemyCollisionPoints.Add(new CCPoint(5, 37));
                    EnemyCollisionPoints.Add(new CCPoint(2, 26));
                    EnemyCollisionPoints.Add(new CCPoint(5, 13));
                    EnemyCollisionPoints.Add(new CCPoint(11, 6));
                    EnemyCollisionPoints.Add(new CCPoint(20, 1));
                    EnemyCollisionPoints.Add(new CCPoint(30, 1));
                    EnemyCollisionPoints.Add(new CCPoint(38, 5));
                    EnemyCollisionPoints.Add(new CCPoint(43, 11));
                    EnemyCollisionPoints.Add(new CCPoint(45, 17));
                    EnemyCollisionPoints.Add(new CCPoint(47, 25));
                    EnemyCollisionPoints.Add(new CCPoint(46, 34));
                    EnemyCollisionPoints.Add(new CCPoint(44, 38));
                    EnemyCollisionPoints.Add(new CCPoint(40, 46));
                    EnemyCollisionPoints.Add(new CCPoint(35, 51));
                    EnemyCollisionPoints.Add(new CCPoint(30, 56));
                    break;
                case ENEMIES.KIM:
                    VoiceMiss = null;
                    VoiceMissAlternate = null;
                    VoiceEnemyHit = "Sounds/kim 3 Shit.wav";
                    VoicePlayerHit = "Sounds/Kim 4 In Your Face Laugh- Enhanced.wav";
                    VoiceGameOver = "Sounds/Kim 5 Serves You Right 1 raw.wav";
                    VoiceEnemyWound1 = "Sounds/Kim_get_wounded1.wav";
                    VoiceEnemyWound2 = "Sounds/Kim_get_wounded2.wav";
                    VoiceEnemyWound3 = "Sounds/Kim_get_wounded3.wav";
                    EnemyMouthClosed = "Enemies/Kim-mouth-closed.png";
                    EnemyMouthClosedDamaged1 = "Enemies/Kim-mouth-closed-bruises.png";
                    EnemyMouthClosedDamaged2 = "Enemies/Kim-mouth-closed-bruises-bandages.png";
                    EnemyMouthOpen = "Enemies/Kim-mouth-open.png";
                    EnemyMouthOpenDamaged1 = "Enemies/Kim-mouth-open-bruises.png";
                    EnemyMouthOpenDamaged2 = "Enemies/Kim-mouth-open-bruises-bandages.png";
                    EnemyGrimace1 = "Enemies/Kim-evil-grimace.png";
                    EnemyGrimace2 = "Enemies/Kim-evil-smile.png";
                    EnemyMouthClipHeight = 50;
                    EnemyMouthClipWidth = 50;
                    EnemyCollisionPoints.Add(new CCPoint(24, 62));
                    EnemyCollisionPoints.Add(new CCPoint(17, 60));
                    EnemyCollisionPoints.Add(new CCPoint(11, 55));
                    EnemyCollisionPoints.Add(new CCPoint(7, 45));
                    EnemyCollisionPoints.Add(new CCPoint(3, 34));
                    EnemyCollisionPoints.Add(new CCPoint(4, 19));
                    EnemyCollisionPoints.Add(new CCPoint(8, 8));
                    EnemyCollisionPoints.Add(new CCPoint(15, 3));
                    EnemyCollisionPoints.Add(new CCPoint(24, 2));
                    EnemyCollisionPoints.Add(new CCPoint(37, 4));
                    EnemyCollisionPoints.Add(new CCPoint(44, 11));
                    EnemyCollisionPoints.Add(new CCPoint(45, 23));
                    EnemyCollisionPoints.Add(new CCPoint(47, 33));
                    EnemyCollisionPoints.Add(new CCPoint(45, 41));
                    EnemyCollisionPoints.Add(new CCPoint(4, 41));
                    EnemyCollisionPoints.Add(new CCPoint(41, 48));
                    EnemyCollisionPoints.Add(new CCPoint(38, 55));
                    EnemyCollisionPoints.Add(new CCPoint(32, 60));
                    EnemyCollisionPoints.Add(new CCPoint(27, 62));
                    break;
                case ENEMIES.HITLER:
                    VoiceMiss = null;
                    VoiceMissAlternate = null;
                    VoiceEnemyHit = "Sounds/Hitler 3 shit.wav";
                    VoicePlayerHit = "Sounds/Hitler 4 hah hah haa.wav";
                    VoiceGameOver = "Sounds/Hitler 5 world is mine.wav";
                    VoiceEnemyWound1 = "Sounds/hitler_get_wounded1.wav";
                    VoiceEnemyWound2 = "Sounds/hitler_get_wounded2.wav";
                    VoiceEnemyWound3 = "Sounds/hitler_get_wounded3.wav";
                    EnemyMouthClosed = "Enemies/Hitler-mouth-closed.png";
                    EnemyMouthClosedDamaged1 = "Enemies/Hitler-mouth-closed-bruises.png";
                    EnemyMouthClosedDamaged2 = "Enemies/hitler-mouth-closed-bruises-bandages.png";
                    EnemyMouthOpen = "Enemies/Hitler-mouth-open.png";
                    EnemyMouthOpenDamaged1 = "Enemies/hitler-mouth-open-bruises.png";
                    EnemyMouthOpenDamaged2 = "Enemies/hitler-mouth-open-bruises-bandages.png";
                    EnemyGrimace1 = "Enemies/Hitler-evil-grimace.png";
                    EnemyGrimace2 = "Enemies/Hitler-evil-smile.png";
                    EnemyMouthClipHeight = 53;
                    EnemyMouthClipWidth = 50;
                    EnemyCollisionPoints.Add(new CCPoint(22, 62));
                    EnemyCollisionPoints.Add(new CCPoint(16, 58));
                    EnemyCollisionPoints.Add(new CCPoint(10, 48));
                    EnemyCollisionPoints.Add(new CCPoint(6, 39));
                    EnemyCollisionPoints.Add(new CCPoint(4, 32));
                    EnemyCollisionPoints.Add(new CCPoint(4, 20));
                    EnemyCollisionPoints.Add(new CCPoint(7, 11));
                    EnemyCollisionPoints.Add(new CCPoint(14, 5));
                    EnemyCollisionPoints.Add(new CCPoint(21, 1));
                    EnemyCollisionPoints.Add(new CCPoint(31, 1));
                    EnemyCollisionPoints.Add(new CCPoint(40, 6));
                    EnemyCollisionPoints.Add(new CCPoint(44, 14));
                    EnemyCollisionPoints.Add(new CCPoint(45, 25));
                    EnemyCollisionPoints.Add(new CCPoint(45, 35));
                    EnemyCollisionPoints.Add(new CCPoint(43, 42));
                    EnemyCollisionPoints.Add(new CCPoint(39, 50));
                    EnemyCollisionPoints.Add(new CCPoint(37, 55));
                    EnemyCollisionPoints.Add(new CCPoint(32, 60));
                    EnemyCollisionPoints.Add(new CCPoint(28, 62));
                    break;
                case ENEMIES.BUSH:
                    VoiceMiss = null;
                    VoiceMissAlternate = null;
                    VoiceEnemyHit = "Sounds/Bush 3 Shit.wav";
                    VoicePlayerHit = "Sounds/Bush 4 hah hah haa.wav";
                    VoiceGameOver = "Sounds/Bush 5 natural resourses.wav";
                    VoiceEnemyWound1 = "Sounds/bush_get_wounded1.wav";
                    VoiceEnemyWound2 = "Sounds/bush_get_wounded2.wav";
                    VoiceEnemyWound3 = "Sounds/bush_get_wounded3.wav";
                    EnemyMouthClosed = "Enemies/Bush-mouth-closed.png";
                    EnemyMouthClosedDamaged1 = "Enemies/Bush-mouth-closed-bruises.png";
                    EnemyMouthClosedDamaged2 = "Enemies/Bush-mouth-closed-bruises-bandages.png";
                    EnemyMouthOpen = "Enemies/Bush-mouth-open.png";
                    EnemyMouthOpenDamaged1 = "Enemies/Bush-mouth-open-bruises.png";
                    EnemyMouthOpenDamaged2 = "Enemies/Bush-mouth-open-bruises-bandages.png";
                    EnemyGrimace1 = "Enemies/Bush-evil-grimace.png";
                    EnemyGrimace2 = "Enemies/Bush-evil-smile.png";
                    EnemyMouthClipHeight = 51;
                    EnemyMouthClipWidth = 50;
                    EnemyCollisionPoints.Add(new CCPoint(25, 60));
                    EnemyCollisionPoints.Add(new CCPoint(17, 57));
                    EnemyCollisionPoints.Add(new CCPoint(13, 51));
                    EnemyCollisionPoints.Add(new CCPoint(8, 42));
                    EnemyCollisionPoints.Add(new CCPoint(5, 33));
                    EnemyCollisionPoints.Add(new CCPoint(6, 16));
                    EnemyCollisionPoints.Add(new CCPoint(12, 5));
                    EnemyCollisionPoints.Add(new CCPoint(20, 1));
                    EnemyCollisionPoints.Add(new CCPoint(40, 8));
                    EnemyCollisionPoints.Add(new CCPoint(32, 2));
                    EnemyCollisionPoints.Add(new CCPoint(44, 16));
                    EnemyCollisionPoints.Add(new CCPoint(44, 27));
                    EnemyCollisionPoints.Add(new CCPoint(45, 34));
                    EnemyCollisionPoints.Add(new CCPoint(43, 41));
                    EnemyCollisionPoints.Add(new CCPoint(39, 49));
                    EnemyCollisionPoints.Add(new CCPoint(35, 55));
                    EnemyCollisionPoints.Add(new CCPoint(39, 59));
                    break;
                case ENEMIES.ALIENS:
                    //VoiceEnemyHit = null;
                    //VoicePlayerHit = null;
                    //VoiceGameOver = null;
                    //VoiceEnemyWound1 = null;
                    //VoiceEnemyWound2 = null;
                    //VoiceEnemyWound3 = null;
                    VoiceEnemyHit = "Sounds/Alien 3 shit.wav";
                    VoicePlayerHit = "Sounds/Alien 4 hah hah haa.wav";
                    VoiceGameOver = "Sounds/Alien 5 world is mine.wav";
                    VoiceMiss = null;
                    VoiceMissAlternate = null;
                    VoiceEnemyWound1 = "Sounds/Alien_get_wounded1.wav";
                    VoiceEnemyWound2 = "Sounds/Alien_get_wounded2.wav";
                    VoiceEnemyWound3 = "Sounds/Alien_get_wounded3.wav";
                    EnemyMouthClosed = "Enemies/Alien-mouth-closed.png";
                    EnemyMouthClosedDamaged1 = "Enemies/Alien-mouth-closed-bruises.png";
                    EnemyMouthClosedDamaged2 = "Enemies/Alien-mouth-closed-bruises-bandages.png";
                    EnemyMouthOpen = "Enemies/Alien-mouth-open.png";
                    EnemyMouthOpenDamaged1 = "Enemies/Alien-mouth-open-bruises.png";
                    EnemyMouthOpenDamaged2 = "Enemies/Alien-mouth-open-bruises-bandages.png";
                    EnemyGrimace1 = "Enemies/Alien-evil-grimace.png";
                    EnemyGrimace2 = "Enemies/Alien-evil-smile.png";
                    EnemyMouthClipHeight = 45;
                    EnemyMouthClipWidth = 50;
                    EnemyCollisionPoints.Add(new CCPoint(15, 59));
                    EnemyCollisionPoints.Add(new CCPoint(20, 59));
                    EnemyCollisionPoints.Add(new CCPoint(31, 59));
                    EnemyCollisionPoints.Add(new CCPoint(36, 59));
                    EnemyCollisionPoints.Add(new CCPoint(25, 55));
                    EnemyCollisionPoints.Add(new CCPoint(7, 61));
                    EnemyCollisionPoints.Add(new CCPoint(44, 61));
                    EnemyCollisionPoints.Add(new CCPoint(2, 53));
                    EnemyCollisionPoints.Add(new CCPoint(48, 53));
                    EnemyCollisionPoints.Add(new CCPoint(42, 40));
                    EnemyCollisionPoints.Add(new CCPoint(8, 40));
                    EnemyCollisionPoints.Add(new CCPoint(9, 28));
                    EnemyCollisionPoints.Add(new CCPoint(41, 29));
                    EnemyCollisionPoints.Add(new CCPoint(39, 16));
                    EnemyCollisionPoints.Add(new CCPoint(12, 16));
                    EnemyCollisionPoints.Add(new CCPoint(2, 5));
                    EnemyCollisionPoints.Add(new CCPoint(9, 1));
                    EnemyCollisionPoints.Add(new CCPoint(41, 1));
                    EnemyCollisionPoints.Add(new CCPoint(47, 4));
                    EnemyCollisionPoints.Add(new CCPoint(25, 7));
                    break;
                case ENEMIES.TRUMP:
                    //VoiceEnemyHit = null;
                    //VoicePlayerHit = null;
                    //VoiceGameOver = null;
                    //VoiceEnemyWound1 = null;
                    //VoiceEnemyWound2 = null;
                    //VoiceEnemyWound3 = null;
                    VoiceEnemyHit = "Sounds/Trump 3 shit.wav";
                    VoicePlayerHit = "Sounds/Trump_ha_ha_haa.wav";
                    VoiceGameOver = "Sounds/Trump always good to be underestimated.wav";
                    VoiceMiss = "Sounds/Trump_ha_ha_haa.wav";
                    VoiceMissAlternate = "Sounds/Trump - Phrases_do_not_like_loosers.wav";
                    VoiceEnemyWound1 = "Sounds/Trump_get_wounded1.wav";
                    VoiceEnemyWound2 = "Sounds/Trump_get_wounded2.wav";
                    VoiceEnemyWound3 = "Sounds/Trump_get_wounded3.wav";
                    EnemyMouthClosed = "Enemies/Trump-mouth-closed.png";
                    EnemyMouthClosedDamaged1 = "Enemies/Trump-mouth-closed-bruises.png";
                    EnemyMouthClosedDamaged2 = "Enemies/Trump-mouth-closed-bruises-bandages.png";
                    EnemyMouthOpen = "Enemies/Trump-mouth-open.png";
                    EnemyMouthOpenDamaged1 = "Enemies/Trump-mouth-open-bruises.png";
                    EnemyMouthOpenDamaged2 = "Enemies/Trump-mouth-open-bruises-bandages.png";
                    EnemyGrimace1 = "Enemies/Trump-evil-grimace.png";
                    EnemyGrimace2 = "Enemies/Trump-evil-smile.png";
                    EnemyMouthClipHeight = 50;
                    EnemyMouthClipWidth = 50;
                    EnemyCollisionPoints.Add(new CCPoint(24, 62));
                    EnemyCollisionPoints.Add(new CCPoint(17, 60));
                    EnemyCollisionPoints.Add(new CCPoint(11, 55));
                    EnemyCollisionPoints.Add(new CCPoint(7, 45));
                    EnemyCollisionPoints.Add(new CCPoint(3, 34));
                    EnemyCollisionPoints.Add(new CCPoint(4, 19));
                    EnemyCollisionPoints.Add(new CCPoint(8, 8));
                    EnemyCollisionPoints.Add(new CCPoint(15, 3));
                    EnemyCollisionPoints.Add(new CCPoint(24, 2));
                    EnemyCollisionPoints.Add(new CCPoint(37, 4));
                    EnemyCollisionPoints.Add(new CCPoint(44, 11));
                    EnemyCollisionPoints.Add(new CCPoint(45, 23));
                    EnemyCollisionPoints.Add(new CCPoint(47, 33));
                    EnemyCollisionPoints.Add(new CCPoint(45, 41));
                    EnemyCollisionPoints.Add(new CCPoint(4, 41));
                    EnemyCollisionPoints.Add(new CCPoint(41, 48));
                    EnemyCollisionPoints.Add(new CCPoint(38, 55));
                    EnemyCollisionPoints.Add(new CCPoint(32, 60));
                    EnemyCollisionPoints.Add(new CCPoint(27, 62));
                    break;
            }

            _gunCooloff = 1f / (FireSpeedSelected == -1 ? Weapon.GetFirespeed(selectedWeapon) : FireSpeedSelected);
            _magazineSize = (MagazineSizeSelected == -1 ? Weapon.GetMagazineSize(selectedWeapon) : MagazineSizeSelected) * 5;
            _bulletPower = (CaliberSizeSelected == -1 ? Weapon.GetCaliberSize(selectedWeapon) : CaliberSizeSelected) * 0.5f;
            _bulletScale = 0.7f + ((CaliberSizeSelected == -1 ? Weapon.GetCaliberSize(selectedWeapon) : CaliberSizeSelected) * 0.1f);


            switch (selectedWeapon)
            {
                case WEAPONS.STANDARD:
                    PlayerCannon = "Player/Standard_gun.png";
                    PlayerLivesLeft = "Player/Standard_gun_lives_left_indicator.png";
                    _playerSpeed = 30;
                    _reloadTime = 2f;
                    _smokeOffsetY = -40;
                    if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) SoundCannonShoot = "Sounds/Standard cannon (canon cal 3-3).wav";
                    else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) SoundCannonShoot = "Sounds/cannon shot standard cannon (23).wav";

                    SsRecoil = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/GunRecoil.plist");
                    SsRecoilKeyPrefix = "standard_gun_recoil_image_";

                    PlayerCollisionPoints.Add(new CCPoint(49, 27));
                    PlayerCollisionPoints.Add(new CCPoint(57, 27));
                    PlayerCollisionPoints.Add(new CCPoint(49, 57));
                    PlayerCollisionPoints.Add(new CCPoint(57, 57));
                    PlayerCollisionPoints.Add(new CCPoint(29, 94));
                    PlayerCollisionPoints.Add(new CCPoint(77, 57));
                    PlayerCollisionPoints.Add(new CCPoint(47, 90));
                    PlayerCollisionPoints.Add(new CCPoint(58, 90));
                    PlayerCollisionPoints.Add(new CCPoint(36, 95));
                    PlayerCollisionPoints.Add(new CCPoint(69, 95));
                    PlayerCollisionPoints.Add(new CCPoint(18, 101));
                    PlayerCollisionPoints.Add(new CCPoint(88, 101));
                    PlayerCollisionPoints.Add(new CCPoint(30, 125));
                    PlayerCollisionPoints.Add(new CCPoint(75, 125));
                    PlayerCollisionPoints.Add(new CCPoint(30, 146));
                    PlayerCollisionPoints.Add(new CCPoint(75, 146));
                    PlayerCollisionPoints.Add(new CCPoint(46, 134));
                    PlayerCollisionPoints.Add(new CCPoint(59, 134));
                    PlayerCollisionPoints.Add(new CCPoint(46, 134));
                    PlayerCollisionPoints.Add(new CCPoint(59, 134));
                    break;
                case WEAPONS.COMPACT:
                    PlayerCannon = "Player/Compact_sprayer.png";
                    PlayerLivesLeft = "Player/Compact_sprayerlives_left_indicator.png";
                    _playerSpeed = 45;
                    _reloadTime = 3f;
                    _smokeOffsetY = -60;
                    if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) SoundCannonShoot = "Sounds/Compact sprayer (canon cal 3-3).wav";
                    else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) SoundCannonShoot = "Sounds/cannon shot compact sprayer (23).wav";

                    SsRecoil = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/CompactSprayerRecoil.plist");
                    SsRecoilKeyPrefix = "Compact_sprayer_recoil_animation_image_";

                    PlayerCollisionPoints.Add(new CCPoint(49, 47));
                    PlayerCollisionPoints.Add(new CCPoint(57, 47));
                    PlayerCollisionPoints.Add(new CCPoint(49, 70));
                    PlayerCollisionPoints.Add(new CCPoint(57, 70));
                    PlayerCollisionPoints.Add(new CCPoint(44, 86));
                    PlayerCollisionPoints.Add(new CCPoint(61, 86));
                    PlayerCollisionPoints.Add(new CCPoint(42, 94));
                    PlayerCollisionPoints.Add(new CCPoint(63, 94));
                    PlayerCollisionPoints.Add(new CCPoint(32, 98));
                    PlayerCollisionPoints.Add(new CCPoint(73, 98));
                    PlayerCollisionPoints.Add(new CCPoint(23, 94));
                    PlayerCollisionPoints.Add(new CCPoint(83, 94));
                    PlayerCollisionPoints.Add(new CCPoint(12, 99));
                    PlayerCollisionPoints.Add(new CCPoint(96, 99));
                    PlayerCollisionPoints.Add(new CCPoint(12, 108));
                    PlayerCollisionPoints.Add(new CCPoint(96, 108));
                    PlayerCollisionPoints.Add(new CCPoint(21, 124));
                    PlayerCollisionPoints.Add(new CCPoint(84, 124));
                    PlayerCollisionPoints.Add(new CCPoint(21, 138));
                    PlayerCollisionPoints.Add(new CCPoint(84, 138));
                    PlayerCollisionPoints.Add(new CCPoint(32, 144));
                    PlayerCollisionPoints.Add(new CCPoint(71, 144));
                    PlayerCollisionPoints.Add(new CCPoint(32, 118));
                    PlayerCollisionPoints.Add(new CCPoint(71, 118));

                    break;
                case WEAPONS.BAZOOKA:
                    PlayerCannon = "Player/Big_bazooka.png";
                    PlayerLivesLeft = "Player/Big_bazookalives_left_indicator.png";
                    _playerSpeed = 20;
                    _reloadTime = 1f;
                    _smokeOffsetY = -15;
                    if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) SoundCannonShoot = "Sounds/Black bazooka (canon cal 3-3).wav";
                    else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) SoundCannonShoot = "Sounds/cannon shot black bazooka (23).wav";

                    SsRecoil = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/BlackBazookaRecoil.plist");
                    SsRecoilKeyPrefix = "Black _bazooka_recoil_animation_image_";

                    PlayerCollisionPoints.Add(new CCPoint(53, 3));
                    PlayerCollisionPoints.Add(new CCPoint(47, 6));
                    PlayerCollisionPoints.Add(new CCPoint(58, 6));
                    PlayerCollisionPoints.Add(new CCPoint(49, 33));
                    PlayerCollisionPoints.Add(new CCPoint(56, 33));
                    PlayerCollisionPoints.Add(new CCPoint(48, 57));
                    PlayerCollisionPoints.Add(new CCPoint(57, 57));
                    PlayerCollisionPoints.Add(new CCPoint(42, 90));
                    PlayerCollisionPoints.Add(new CCPoint(63, 90));
                    PlayerCollisionPoints.Add(new CCPoint(28, 93));
                    PlayerCollisionPoints.Add(new CCPoint(78, 93));
                    PlayerCollisionPoints.Add(new CCPoint(16, 90));
                    PlayerCollisionPoints.Add(new CCPoint(90, 90));
                    PlayerCollisionPoints.Add(new CCPoint(4, 99));
                    PlayerCollisionPoints.Add(new CCPoint(102, 99));
                    PlayerCollisionPoints.Add(new CCPoint(4, 118));
                    PlayerCollisionPoints.Add(new CCPoint(102, 118));
                    PlayerCollisionPoints.Add(new CCPoint(10, 126));
                    PlayerCollisionPoints.Add(new CCPoint(95, 126));
                    PlayerCollisionPoints.Add(new CCPoint(30, 130));
                    PlayerCollisionPoints.Add(new CCPoint(74, 130));
                    PlayerCollisionPoints.Add(new CCPoint(30, 145));
                    PlayerCollisionPoints.Add(new CCPoint(74, 145));
                    PlayerCollisionPoints.Add(new CCPoint(52, 122));
                    break;
                case WEAPONS.HYBRID:
                    _magazineSize = _magazineSize / 2;
                    _gunCooloff = _gunCooloff * 2;
                    PlayerCannon = "Player/Hybrid_defender.png";
                    PlayerLivesLeft = "Player/Hybrid_defender_lives_left_indicator.png";
                    _playerSpeed = 20;
                    _reloadTime = 2f;
                    _smokeOffsetY = -15;
                    if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) SoundCannonShoot = "Sounds/Hybrid Canon Shoot Combo.wav";
                    else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) SoundCannonShoot = "Sounds/85 - Hybrid Laser 2.wav";

                    SsRecoil = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/HybridDefenderRecoil.plist");
                    SsRecoilKeyPrefix = "Hybrid_defender_recoil_animation_image_";

                    PlayerCollisionPoints.Add(new CCPoint(53, 7));
                    PlayerCollisionPoints.Add(new CCPoint(46, 11));
                    PlayerCollisionPoints.Add(new CCPoint(60, 11));
                    PlayerCollisionPoints.Add(new CCPoint(46, 26));
                    PlayerCollisionPoints.Add(new CCPoint(60, 26));
                    PlayerCollisionPoints.Add(new CCPoint(48, 40));
                    PlayerCollisionPoints.Add(new CCPoint(58, 40));
                    PlayerCollisionPoints.Add(new CCPoint(46, 56));
                    PlayerCollisionPoints.Add(new CCPoint(60, 56));
                    PlayerCollisionPoints.Add(new CCPoint(43, 75));
                    PlayerCollisionPoints.Add(new CCPoint(63, 75));
                    PlayerCollisionPoints.Add(new CCPoint(37, 82));
                    PlayerCollisionPoints.Add(new CCPoint(68, 82));
                    PlayerCollisionPoints.Add(new CCPoint(27, 86));
                    PlayerCollisionPoints.Add(new CCPoint(80, 86));
                    PlayerCollisionPoints.Add(new CCPoint(15, 87));
                    PlayerCollisionPoints.Add(new CCPoint(94, 90));
                    PlayerCollisionPoints.Add(new CCPoint(11, 92));
                    PlayerCollisionPoints.Add(new CCPoint(96, 92));
                    PlayerCollisionPoints.Add(new CCPoint(8, 98));
                    PlayerCollisionPoints.Add(new CCPoint(99, 98));
                    PlayerCollisionPoints.Add(new CCPoint(3, 104));
                    PlayerCollisionPoints.Add(new CCPoint(103, 105));
                    PlayerCollisionPoints.Add(new CCPoint(3, 118));
                    PlayerCollisionPoints.Add(new CCPoint(103, 118));
                    PlayerCollisionPoints.Add(new CCPoint(9, 124));
                    PlayerCollisionPoints.Add(new CCPoint(98, 124));
                    PlayerCollisionPoints.Add(new CCPoint(113, 144));
                    PlayerCollisionPoints.Add(new CCPoint(93, 144));
                    PlayerCollisionPoints.Add(new CCPoint(40, 119));
                    PlayerCollisionPoints.Add(new CCPoint(67, 119));
                    PlayerCollisionPoints.Add(new CCPoint(45, 86));
                    PlayerCollisionPoints.Add(new CCPoint(61, 86));

                    PlayerCollisionPoints.Add(new CCPoint(33, 90));
                    PlayerCollisionPoints.Add(new CCPoint(73, 90));
                    PlayerCollisionPoints.Add(new CCPoint(79, 87));
                    PlayerCollisionPoints.Add(new CCPoint(29, 87));
                    PlayerCollisionPoints.Add(new CCPoint(39, 77));
                    PlayerCollisionPoints.Add(new CCPoint(67, 77));
                    PlayerCollisionPoints.Add(new CCPoint(16, 87));
                    PlayerCollisionPoints.Add(new CCPoint(92, 87));
                    PlayerCollisionPoints.Add(new CCPoint(7, 99));
                    PlayerCollisionPoints.Add(new CCPoint(99, 99));
                    PlayerCollisionPoints.Add(new CCPoint(20, 86));
                    PlayerCollisionPoints.Add(new CCPoint(97, 87));
                    PlayerCollisionPoints.Add(new CCPoint(81, 86));
                    PlayerCollisionPoints.Add(new CCPoint(88, 86));

                    SsHybridLaser = new CCSpriteSheet[3];
                    SsHybridLaser[0] = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/PipeAndLensFlare-0.plist");
                    SsHybridLaser[1] = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/PipeAndLensFlare-1.plist");
                    SsHybridLaser[2] = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/PipeAndLensFlare-2.plist");

                    SsAlienLensFlare = new CCSpriteSheet[2];
                    SsAlienLensFlare[0] = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/alien-laser-lens-flair-0.plist");
                    SsAlienLensFlare[1] = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/alien-laser-lens-flair-1.plist");



                    break;
            }


            CCAudioEngine.SharedEngine.PreloadEffect(SoundCannonShoot);
            CCAudioEngine.SharedEngine.PreloadEffect(VoiceEnemyHit);
            CCAudioEngine.SharedEngine.PreloadEffect(VoicePlayerHit);
            CCAudioEngine.SharedEngine.PreloadEffect(VoiceGameOver);
            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Hitler 3 Scheisse.wav");
            CCAudioEngine.SharedEngine.PreloadEffect(VoiceEnemyWound1);
            CCAudioEngine.SharedEngine.PreloadEffect(VoiceEnemyWound2);
            CCAudioEngine.SharedEngine.PreloadEffect(VoiceEnemyWound3);
            if (VoiceMiss != null) CCAudioEngine.SharedEngine.PreloadEffect(VoiceMiss);
            if (VoiceMissAlternate != null) CCAudioEngine.SharedEngine.PreloadEffect(VoiceMissAlternate);

            GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.ENEMY_HURT_1);
            GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.ENEMY_HURT_2);
            GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.ENEMY_HURT_3);
            GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.ENEMY_KILLED);


            GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.GUN_HIT_1);
            GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.GUN_HIT_2);
            GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.GUN_HIT_3);
            GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.GUN_HIT_GAME_OVER);

            GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.CANNON_CAL_1_1);
            GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.CALIBRE_1);

            GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.BOMB_FALL1);
            GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.BOMB_FALL2);
            GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.BOMB_FALL3);

            if (SelectedWeapon == WEAPONS.HYBRID)
            {
                GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.EMPTY_CANON_HYBRID);
            }
            else
            {
                GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.EMPTY_CANON);
            }
            GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.COUNTDOWN);

            if (SelectedEnemy == ENEMIES.ALIENS)
            {
                GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.ALIEN_LASER);
                GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.ALIEN_SPIT);
                GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.ALIEN_SPIT2);
                GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.ALIEN_SPIT3);
                GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.MULTIPLIER_INDICATOR);
            }
            else
            {
                GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.ENEMY_SPIT);
                GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.ENEMY_SPIT2);
                GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.ENEMY_SPIT3);
                GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.ENEMY_SPIT4);
            }

            if (Settings.Instance.VoiceoversEnabled)
            {
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/get ready for next wave VO_mono.wav");
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/get ready for final wave VO_mono.wav");
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Victory VO_mono.wav");
                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Game Over VO_mono.wav");

            }



            var cache = CCTextureCache.SharedTextureCache;

            /*
            for (int i = 0; i < 72; i++)
            {
                cache.AddImage(GameEnvironment.ImageDirectory + "Animations/General_cannon_flame" + i.ToString().PadLeft(2, '0') + ".png");
            }
            for (int i = 0; i < 29; i++)
            {
                cache.AddImage(GameEnvironment.ImageDirectory + "Animations/General_enemy_explosion" + i.ToString().PadLeft(2, '0') + ".png");
            }
            for (int i = 0; i < 73; i++)
            {
                cache.AddImage(GameEnvironment.ImageDirectory + "Animations/General_cannon_explosion_" + i.ToString().PadLeft(2, '0') + ".png");
            }
            for (int i = 0; i < 68; i++)
            {
                cache.AddImage(GameEnvironment.ImageDirectory + "Animations/Game-over-explosion-image-" + i.ToString().PadLeft(2, '0') + ".png");
            }
            for (int i = 1; i < 27; i++)
            {
                cache.AddImage(GameEnvironment.ImageDirectory + "Animations/drooling_image__" + i.ToString().PadLeft(2, '0') + ".png");
            }
            for (int i = 0; i < 24; i++)
            {
                cache.AddImage(GameEnvironment.ImageDirectory + "Animations/Pre-explosion_image_" + i.ToString().PadLeft(2, '0') + ".png");
            }*/


            SsPreExplosion = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/Pre-explosion.plist");
            if (SelectedEnemy == ENEMIES.ALIENS)
            {
                SsDrooling = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/AlienSpit.plist");
            }
            else
            {
                SsDrooling = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/drooling.plist");
            }
            SsGameOverExplosion = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/Game-over-explosion.plist");
            SsEnemyExplosion = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/General_enemy_explosion.plist");
            SsCannonFlame = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/General_cannon_flame-0.plist");
            SsCannonExplosion1 = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/General_cannon_explosion-0.plist");
            SsCannonExplosion2 = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/General_cannon_explosion-1.plist");
            if (selectedEnemy != ENEMIES.ALIENS)
            {
                SsBomb = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/BombRotation.plist");
            }
            else
            {
                SsBomb = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/SlimeBall.plist");
                SsFlyingSaucer = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/FlyingSaucer.plist");
                SsLaserSparks = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/AlienLaserHittingWithoutLaser.plist");
            }

            for (var i = 1; i < 6; i++)
            {
                cache.AddImage(GameEnvironment.ImageDirectory + "Animations/get-ready-for-next-attack-countdown-(" + i.ToString() + ").png");
            }

            for (var i = 0; i < 10; i++)
            {
                cache.AddImage(GameEnvironment.ImageDirectory + "UI/number_50_" + i.ToString() + ".png");
            }




            cache.AddImage("UI/Battle-screen-reloading-text.png");
            cache.AddImage("UI/Battle-screen-time-text.png");


            cache.AddImage(BattlegroundImageName);
            cache.AddImage(EnemyMouthClosed);
            cache.AddImage(EnemyMouthClosedDamaged1);
            cache.AddImage(EnemyMouthClosedDamaged2);
            cache.AddImage(EnemyMouthOpen);
            cache.AddImage(EnemyMouthOpenDamaged1);
            cache.AddImage(EnemyMouthOpenDamaged2);
            cache.AddImage(EnemyGrimace1);
            cache.AddImage(EnemyGrimace2);
            cache.AddImage(PlayerCannon);
            cache.AddImage(PlayerLivesLeft);
            cache.AddImage("Player/ammo.png");
            cache.AddImage("Player/laser-ammo.png");
            cache.AddImage("Player/bullet.png");
            cache.AddImage("Player/green-lazer-bullet.png");
            cache.AddImage("UI/back-button-tapped.png");
            cache.AddImage("UI/back-button-untapped.png");
            cache.AddImage("UI/Battle-screen-game-over...-text.png");
            cache.AddImage("UI/get-ready-for-next-wave-text.png");
            cache.AddImage("UI/get-ready-for-final-wave-text.png");
            cache.AddImage("UI/Battle-screen-victory!!!-text.png");
            cache.AddImage("UI/settings-button-untapped.png");
            cache.AddImage("UI/settings-button-tapped.png");
            cache.AddImage("Enemies/green-slime-ball.png");
            cache.AddImage("Enemies/Laser-image_02_middle.png");
            cache.AddImage("Enemies/Laser-image_middle.png");
            cache.AddImage("Enemies/Laser-image_02_top.png");
            cache.AddImage("UI/get-ready-for-next-attack-countdown-(5).png");
            cache.AddImage("UI/get-ready-for-next-attack-countdown-(4).png");
            cache.AddImage("UI/get-ready-for-next-attack-countdown-(3).png");
            cache.AddImage("UI/get-ready-for-next-attack-countdown-(2).png");
            cache.AddImage("UI/get-ready-for-next-attack-countdown-(1).png");



            switch (selectedEnemy)
            {
                case ENEMIES.PUTIN:
                    AddImage(0, 0, "UI/Get-ready-for-next-attack-russian-troops.jpg", 1);
                    break;
                case ENEMIES.BUSH:
                    AddImage(0, 0, "UI/Get-ready-for-next-attack-USA-troops.jpg", 1);
                    break;
                case ENEMIES.KIM:
                    AddImage(0, 0, "UI/Get-ready-for-next-attack-south-korean-troops.jpg", 1);
                    break;
                case ENEMIES.HITLER:
                    AddImage(0, 0, "UI/Get-ready-for-next-attack-german-troops.jpg", 1);
                    break;
                case ENEMIES.ALIENS:
                    if (Settings.Instance.BattlegroundStyle == BATTLEGROUND_STYLE.Cartonic)
                        AddImage(0, 0, "UI/get-ready-for-next-attack-moon-level-cartonic.jpg", 1);
                    else
                        AddImage(0, 0, "UI/get-ready-for-next-attack-moon-level-realistic.jpg", 1);

                    break;
            }
            switch (selectedBattleground)
            {
                case BATTLEGROUNDS.AFGHANISTAN:
                    AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-afghanistan-text.png", 2);
                    break;
                case BATTLEGROUNDS.DENMARK:
                    AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-denmark-text.png", 2);
                    break;
                case BATTLEGROUNDS.ENGLAND:
                    AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-england-text.png", 2);
                    break;
                case BATTLEGROUNDS.ESTONIA:
                    AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-estonia-text.png", 2);
                    break;
                case BATTLEGROUNDS.FINLAND:
                    AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-finland-text.png", 2);
                    break;
                case BATTLEGROUNDS.FRANCE:
                    AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-france-text.png", 2);
                    break;
                case BATTLEGROUNDS.GEORGIA:
                    AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-georgia-text.png", 2);
                    break;
                case BATTLEGROUNDS.GREAT_BRITAIN:
                    AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-great-britain-text.png", 2);
                    break;
                case BATTLEGROUNDS.IRAQ:
                    AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-iraq-text.png", 2);
                    break;
                case BATTLEGROUNDS.ISRAEL:
                    AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-israel-text.png", 2);
                    break;
                case BATTLEGROUNDS.JAPAN:
                    AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-japan-text.png", 2);
                    break;
                case BATTLEGROUNDS.LIBYA:
                    AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-libya-text.png", 2);
                    break;
                case BATTLEGROUNDS.NORWAY:
                    AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-norway-text.png", 2);
                    break;
                case BATTLEGROUNDS.POLAND:
                    AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-poland-text.png", 2);
                    break;
                case BATTLEGROUNDS.RUSSIA:
                    AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-russia-text.png", 2);
                    break;
                case BATTLEGROUNDS.SOUTH_KOREA:
                    AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-south-korea-text.png", 2);
                    break;
                case BATTLEGROUNDS.SYRIA:
                    AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-syria-text.png", 2);
                    break;
                case BATTLEGROUNDS.UKRAINE:
                    AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-ukraine-text.png", 2);
                    break;
                case BATTLEGROUNDS.UNITED_STATES:
                    AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-united-states-text.png", 2);
                    break;
                case BATTLEGROUNDS.VIETNAM:
                    AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-vietnam-text.png", 2);
                    break;
            }
            if (!Settings.Instance.VoiceoversEnabled)
            {
                switch (SelectedBattleground)
                {
                    case BATTLEGROUNDS.AFGHANISTAN:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Bush countries Afganistan.wav");
                        break;
                    case BATTLEGROUNDS.DENMARK:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Hitler countries Denmark.wav");
                        break;
                    case BATTLEGROUNDS.ENGLAND:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Hitler countries England.wav");
                        break;
                    case BATTLEGROUNDS.ESTONIA:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Putin countries Estonia.wav");
                        break;
                    case BATTLEGROUNDS.FINLAND:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Putin countries Finland.wav");
                        break;
                    case BATTLEGROUNDS.FRANCE:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Hitler countries France.wav");
                        break;
                    case BATTLEGROUNDS.GEORGIA:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Putin countries Georgia.wav");
                        break;
                    case BATTLEGROUNDS.GREAT_BRITAIN:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Kim countries Great Britain.wav");
                        break;
                    case BATTLEGROUNDS.IRAQ:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Bush countries Irak.wav");
                        break;
                    case BATTLEGROUNDS.ISRAEL:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Kim countries Israel.wav");
                        break;
                    case BATTLEGROUNDS.JAPAN:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Kim countries Japan.wav");
                        break;
                    case BATTLEGROUNDS.LIBYA:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Bush countries Libya.wav");
                        break;
                    case BATTLEGROUNDS.NORWAY:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Hitler countries Norway.wav");
                        break;
                    case BATTLEGROUNDS.POLAND:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Hitler countries Poland.wav");
                        break;
                    case BATTLEGROUNDS.RUSSIA:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Bush countries Russian.wav");
                        break;
                    case BATTLEGROUNDS.SOUTH_KOREA:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Kim countries South Korea.wav");
                        break;
                    case BATTLEGROUNDS.SYRIA:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Putin countries Syria.wav");
                        break;
                    case BATTLEGROUNDS.UKRAINE:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Putin countries Ukraine.wav");
                        break;
                    case BATTLEGROUNDS.UNITED_STATES:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Kim countries United States.wav");
                        break;
                    case BATTLEGROUNDS.VIETNAM:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Bush countries Vietman.wav");
                        break;
                }
            }
            else
            {
                switch (SelectedBattleground)
                {
                    case BATTLEGROUNDS.AFGHANISTAN:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Afghanistan VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.DENMARK:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Denmark VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.ENGLAND:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/England VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.ESTONIA:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Estonia VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.FINLAND:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Finland VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.FRANCE:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/France VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.GEORGIA:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Georgia VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.GREAT_BRITAIN:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Great Britain VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.IRAQ:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Irak VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.ISRAEL:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Israel VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.JAPAN:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Japan VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.LIBYA:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Libya VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.NORWAY:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Norway VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.POLAND:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Poland VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.RUSSIA:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Russia VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.SOUTH_KOREA:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/South Korea VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.SYRIA:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Syria VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.UKRAINE:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Ukraine VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.UNITED_STATES:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/USA VO_mono.wav");
                        break;
                    case BATTLEGROUNDS.VIETNAM:
                        CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Vietnam VO_mono.wav");
                        break;
                }
            }

            if (SelectedEnemy == ENEMIES.ALIENS)
            {
                if (Settings.Instance.VoiceoversEnabled) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/get ready for battle of existence VO_mono.wav");
                GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.COUNTDOWNALIEN);
            }
            else
            {
                if (Settings.Instance.VoiceoversEnabled) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/get ready for the next attack in_VO_mono.wav");
                GameEnvironment.PreloadSoundEffect(SOUNDEFFECT.COUNTDOWN);
            }

            if (selectedEnemy != ENEMIES.ALIENS)
            {
                AddImageCentered(1136 / 2, 600, "UI/get-ready-for-the-next-attack-title-text.png", 2);
                AddImageCentered(1136 / 2, 540, "UI/get-ready-for-next-attack-(country__of__)-text.png", 2);
                AddImageLabelRightAligned(1136 / 2 + 92, 509, ((int)SelectedBattleground + 1).ToString(), 55);
                AddImageLabelCentered(1136 / 2 + 125, 509, "20", 55);

            }



            _countdown = 6;

            if (SelectedEnemy == ENEMIES.ALIENS)
            {
                GameEnvironment.PlayMusic(MUSIC.BATTLE_COUNTDOWNALIEN);
            }
            else if (_launchMode != LAUNCH_MODE.STEERING_TEST)
            {
                GameEnvironment.PlayMusic(MUSIC.BATTLE_COUNTDOWN);
            }

            if (_launchMode != LAUNCH_MODE.DEFAULT)
            {
                _enemySpeed = 0;
                _wave = 3;
                StartGame();
            }
            else if (calloutCountryName && !Settings.Instance.VoiceoversEnabled)
            {
                ScheduleOnce(CalloutCountryName, 0.5f);
                Schedule(CountDownUpdate, 1f);
                AdMobManager.ShowBannerBottom();
            }
            else if (Settings.Instance.VoiceoversEnabled)
            {
                if (SelectedEnemy == ENEMIES.ALIENS)
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/get ready for battle of existence VO_mono.wav");
                }
                else
                {
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/get ready for the next attack in_VO_mono.wav");
                    ScheduleOnce(CalloutCountryNameVo, 3.55f);
                }
                Schedule(CountDownUpdate, 1f);
                AdMobManager.ShowBannerBottom();
            }
        }

        private void CalloutCountryName(float dt)
        {

            switch (SelectedBattleground)
            {
                case BATTLEGROUNDS.AFGHANISTAN:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bush countries Afganistan.wav");
                    break;
                case BATTLEGROUNDS.DENMARK:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hitler countries Denmark.wav");
                    break;
                case BATTLEGROUNDS.ENGLAND:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hitler countries England.wav");
                    break;
                case BATTLEGROUNDS.ESTONIA:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Putin countries Estonia.wav");
                    break;
                case BATTLEGROUNDS.FINLAND:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Putin countries Finland.wav");
                    break;
                case BATTLEGROUNDS.FRANCE:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hitler countries France.wav");
                    break;
                case BATTLEGROUNDS.GEORGIA:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Putin countries Georgia.wav");
                    break;
                case BATTLEGROUNDS.GREAT_BRITAIN:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim countries Great Britain.wav");
                    break;
                case BATTLEGROUNDS.IRAQ:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bush countries Irak.wav");
                    break;
                case BATTLEGROUNDS.ISRAEL:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim countries Israel.wav");
                    break;
                case BATTLEGROUNDS.JAPAN:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim countries Japan.wav");
                    break;
                case BATTLEGROUNDS.LIBYA:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bush countries Libya.wav");
                    break;
                case BATTLEGROUNDS.NORWAY:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hitler countries Norway.wav");
                    break;
                case BATTLEGROUNDS.POLAND:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hitler countries Poland.wav");
                    break;
                case BATTLEGROUNDS.RUSSIA:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bush countries Russian.wav");
                    break;
                case BATTLEGROUNDS.SOUTH_KOREA:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim countries South Korea.wav");
                    break;
                case BATTLEGROUNDS.SYRIA:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Putin countries Syria.wav");
                    break;
                case BATTLEGROUNDS.UKRAINE:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Putin countries Ukraine.wav");
                    break;
                case BATTLEGROUNDS.UNITED_STATES:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Kim countries United States.wav");
                    break;
                case BATTLEGROUNDS.VIETNAM:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bush countries Vietman.wav");
                    break;
            }

        }


        private void CalloutCountryNameVo(float dt)
        {
            switch (SelectedBattleground)
            {
                case BATTLEGROUNDS.AFGHANISTAN:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Afghanistan VO_mono.wav");
                    break;
                case BATTLEGROUNDS.DENMARK:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Denmark VO_mono.wav");
                    break;
                case BATTLEGROUNDS.ENGLAND:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/England VO_mono.wav");
                    break;
                case BATTLEGROUNDS.ESTONIA:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Estonia VO_mono.wav");
                    break;
                case BATTLEGROUNDS.FINLAND:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Finland VO_mono.wav");
                    break;
                case BATTLEGROUNDS.FRANCE:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/France VO_mono.wav");
                    break;
                case BATTLEGROUNDS.GEORGIA:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Georgia VO_mono.wav");
                    break;
                case BATTLEGROUNDS.GREAT_BRITAIN:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Great Britain VO_mono.wav");
                    break;
                case BATTLEGROUNDS.IRAQ:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Irak VO_mono.wav");
                    break;
                case BATTLEGROUNDS.ISRAEL:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Israel VO_mono.wav");
                    break;
                case BATTLEGROUNDS.JAPAN:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Japan VO_mono.wav");
                    break;
                case BATTLEGROUNDS.LIBYA:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Libya VO_mono.wav");
                    break;
                case BATTLEGROUNDS.NORWAY:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Norway VO_mono.wav");
                    break;
                case BATTLEGROUNDS.POLAND:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Poland VO_mono.wav");
                    break;
                case BATTLEGROUNDS.RUSSIA:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Russia VO_mono.wav");
                    break;
                case BATTLEGROUNDS.SOUTH_KOREA:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/South Korea VO_mono.wav");
                    break;
                case BATTLEGROUNDS.SYRIA:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Syria VO_mono.wav");
                    break;
                case BATTLEGROUNDS.UKRAINE:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Ukraine VO_mono.wav");
                    break;
                case BATTLEGROUNDS.UNITED_STATES:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/USA VO_mono.wav");
                    break;
                case BATTLEGROUNDS.VIETNAM:
                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Vietnam VO_mono.wav");
                    break;
            }
        }

        private void CountDownUpdate(float dt)
        {


            _countdown--;
            switch (_countdown)
            {
                case 5:
                    _countdownNumber = AddImage(450, 205, "UI/get-ready-for-next-attack-countdown-(5).png", 2);
                    if (SelectedEnemy == ENEMIES.ALIENS)
                    {
                        GameEnvironment.PlaySoundEffect(SOUNDEFFECT.COUNTDOWNALIEN);
                    }
                    else
                    {
                        GameEnvironment.PlaySoundEffect(SOUNDEFFECT.COUNTDOWN);
                    }
                    break;
                case 4:
                    RemoveChild(_countdownNumber);
                    _countdownNumber = AddImage(450, 205, "UI/get-ready-for-next-attack-countdown-(4).png", 2);
                    if (SelectedEnemy == ENEMIES.ALIENS)
                    {
                        GameEnvironment.PlaySoundEffect(SOUNDEFFECT.COUNTDOWNALIEN);
                    }
                    else
                    {
                        GameEnvironment.PlaySoundEffect(SOUNDEFFECT.COUNTDOWN);
                    }
                    break;
                case 3:
                    RemoveChild(_countdownNumber);
                    _countdownNumber = AddImage(450, 205, "UI/get-ready-for-next-attack-countdown-(3).png", 2);
                    if (SelectedEnemy == ENEMIES.ALIENS)
                    {
                        GameEnvironment.PlaySoundEffect(SOUNDEFFECT.COUNTDOWNALIEN);
                    }
                    else
                    {
                        GameEnvironment.PlaySoundEffect(SOUNDEFFECT.COUNTDOWN);
                    }
                    break;
                case 2:
                    RemoveChild(_countdownNumber);
                    _countdownNumber = AddImage(450, 205, "UI/get-ready-for-next-attack-countdown-(2).png", 2);
                    if (SelectedEnemy == ENEMIES.ALIENS)
                    {
                        GameEnvironment.PlaySoundEffect(SOUNDEFFECT.COUNTDOWNALIEN);
                    }
                    else
                    {
                        GameEnvironment.PlaySoundEffect(SOUNDEFFECT.COUNTDOWN);
                    }
                    break;
                case 1:
                    RemoveChild(_countdownNumber);
                    _countdownNumber = AddImage(450, 205, "UI/get-ready-for-next-attack-countdown-(1).png", 2);
                    if (SelectedEnemy == ENEMIES.ALIENS)
                    {
                        GameEnvironment.PlaySoundEffect(SOUNDEFFECT.COUNTDOWNALIEN);
                    }
                    else
                    {
                        GameEnvironment.PlaySoundEffect(SOUNDEFFECT.COUNTDOWN);
                    }
                    break;
                case 0:
                    UnscheduleAll();
                    AdMobManager.HideBanner();
                    if (SelectedEnemy == ENEMIES.ALIENS)
                    {
                        GameEnvironment.PlayMusic(MUSIC.BATTLE_ALIEN1);
                    }
                    else
                    {
                        GameEnvironment.PlayMusic(MUSIC.BATTLE_WAVE_1);
                    }
                    StartGame();
                    break;
            }
        }


        CCSpriteButton _btnBack;
        CCSpriteButton _btnSettings;

        CCSpriteButton _btnMovement;
        CCSpriteButton _btnFire;

        private void StartGame()
        {
            RemoveAllChildren();

            SetBackground(BattlegroundImageName);

            if (_launchMode == LAUNCH_MODE.STEERING_TEST)
            {
                AddImage(0, 0, "UI/Curtain-background-just-curtain.png", 100);
            }

            if (SelectedEnemy == ENEMIES.ALIENS)
            {
                _timeLabel = AddImage(840, 580, "UI/Battle-screen-score-text.png", 999);
                _multiplierLabelLabel = AddImage(896, 540, "UI/multiplier-text.png", 999);
                _multiplierLabelLabel.Opacity = 0;

            }
            else
            {
                _timeLabel = AddImage(910, 580, "UI/Battle-screen-time-text.png", 999);
            }
            //if (!Settings.Instance.Vibration) timeLabel.Visible = false;

            _reloading = AddImage(820, 5, "UI/Battle-screen-reloading-text.png", 999);
            _reloading.Visible = false;

            //player = this.AddImage(1136 / 2 - 100, 50, PlayerCannon, 100);

            _player = new CCSprite(SsRecoil.Frames.Find(item => item.TextureFilename == SsRecoilKeyPrefix + "00.png"));
            _player.BlendFunc = GameEnvironment.BlendFuncDefault;
            _player.AnchorPoint = new CCPoint(0, 0);
            _player.PositionX = 1136 / 2 - 100;
            _player.PositionY = 50;
            _player.ZOrder = 100;

            AddChild(_player);



            for (var i = 0; i < (LivesLeft > -1 ? LivesLeft : Weapon.GetLives(SelectedWeapon) - 1); i++)
            {
                var life = AddImage(i * 80 + 20, 10, PlayerLivesLeft, 102);
                _lives.Add(life);
            }

            for (var i = 0; i < _magazineSize; i++)
            {
                CCSprite ammo;
                if (SelectedWeapon == WEAPONS.HYBRID)
                {
                    ammo = AddImage(1080 - i * 16, 10, "Player/laser-ammo.png", 102);
                }
                else
                {
                    ammo = AddImage(1080 - i * 16, 10, "Player/ammo.png", 102);
                }
                _ammos.Add(ammo);
            }




            for (var j = 2; j >= 0; j--)
            {
                for (var i = 0; i < 4; i++)
                {
                    var enemy = new Enemy(this, 1136 / 2 - 50 - (i * 100), 570 - (j * 65) + 290);
                    enemy.Sprite.ZOrder = 10 - (j * 3);
                    _enemies.Add(enemy);
                    enemy = new Enemy(this, 1136 / 2 + 50 + (i * 100), 570 - (j * 65) + 290);
                    _enemies.Add(enemy);
                    enemy.Sprite.ZOrder = 10 - (j * 3);
                }
            }
            _goingDown = 240;
            _enemyCurrentSpeed = 0; //enemySpeed;
            _firstGoingDown = true;
            _bombDensity = 100;

            _bulletsFired = 0;
            _bulletsMissed = 0;
            /*if(Settings.Instance.Vibration)*/

            _time = AddImageLabel(1040, 580, "0", 50);

            if (_launchMode == LAUNCH_MODE.STEERING_TEST)
            {
                foreach (var timeSprite in _time)
                {
                    timeSprite.Visible = false;
                }

                _timeLabel.Visible = false;
            }


            _lastDisplayedTime = 0;
            _elapsedTime = 0;
            _wavePass = 1136;

            Settings.Instance.ShowSteeringTip = true;

            if (SelectedEnemy == ENEMIES.ALIENS && Settings.Instance.NotificationsEnabled && Settings.Instance.AlienGameTipGamePlayShow)
            {
                ScheduleOnce(ShowAlienTip, 1);
            }
            else if (Settings.Instance.NotificationsEnabled && Settings.Instance.GameTipGamePlayShow && Settings.Instance.ControlType == CONTROL_TYPE.GYROSCOPE && !Settings.Instance.ShowSteeringTip && _launchMode == LAUNCH_MODE.DEFAULT)
            {
                ScheduleOnce(ShowTiltInstruction, 1);
            }

            else if (Settings.Instance.NotificationsEnabled && Settings.Instance.ShowSteeringTip && _launchMode == LAUNCH_MODE.DEFAULT)
            {
                ScheduleOnce(ShowSteeringTip, 1);
            }
            else
            {
                if (_launchMode != LAUNCH_MODE.STEERING_TEST)
                {
                    _btnBack = AddButton(2, 570, "UI/pause-button-untapped.png", "UI/pause-button-tapped.png", 100, BUTTON_TYPE.Back);
                    _btnBack.OnClick += BtnBack_OnClick;
                    _btnBack.ButtonType = BUTTON_TYPE.Back;

                    _btnSettings = AddButton(70, 570, "UI/settings-button-untapped.png", "UI/settings-button-tapped.png", 100, BUTTON_TYPE.Back);
                    _btnSettings.OnClick += btnSettings_OnClick;
                }

                Schedule(UpdateAll);

                SetUpSteering(true);

                /*if (!Settings.Instance.Vibration)
                {
                    btnBack.Visible = false;
                    btnSettings.Visible = false;
                }*/

            }

            /*
            
            CCLabel go = this.AddLabelCentered(1136 / 2, 315, "V I C T O R Y", "Fonts/AktivGroteskBold", 16);
            go.Scale = 2;
            go.ZOrder = 100;
            CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy - killed .wav");
            */
            //this.ScheduleOnce(Victory, 40);

        }


        private void OnSwitchIsOn(object pObject)
        {
            BtnBack_OnClick(null, null);
        }

        CCSpriteTwoStateButton _gameTipCheckMark;
        CCSprite _gameTipBackground;
        CCSprite _gameTipExplanation;
        CCSprite _gameTipArrow;
        CCSprite _gameTipTarget;
        CCSpriteButton _okIGotIt;

        private void ShowTiltInstruction(float dt)
        {
            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.NOTIFICATION_POP_UP);
            _gameTipBackground = AddImageCentered(1136 / 2, 630 / 2, "UI/game-tip-notification-background-with-text.png", 1002);
            _gameTipArrow = AddImage(50, 345, "UI/game-tip-notification-arrow2.png", 1003);
            _gameTipTarget = AddImage(50, 177, "UI/game-tip-notification-tapping-symbol.png", 1003);
            _gameTipExplanation = AddImage(100, 50, "UI/game-tip-notification-do-not-show-text.png.png", 1003);

            _gameTipCheckMark = AddTwoStateButton(45, 40, "UI/check-button-untapped.png", "UI/check-button-tapped.png", "UI/check-button-tapped.png", "UI/check-button-untapped.png", 1005);
            _gameTipCheckMark.OnClick += gameTipCheckMark_OnClick;
            _gameTipCheckMark.ButtonType = BUTTON_TYPE.CheckMark;

            _okIGotIt = AddButton(660, 20, "UI/OK-I-got-it-button-untapped.png", "UI/OK-I-got-it-button-tapped.png", 1005);
            _okIGotIt.OnClick += okIGotIt_OnClick;
        }

        private void ShowTouchInstruction(float dt)
        {
            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.NOTIFICATION_POP_UP);
            _gameTipBackground = AddImageCentered(1136 / 2, 630 / 2, "UI/touch-steering-instructions-notification-background.png", 1002);
            _gameTipExplanation = AddImage(100, 30, "UI/game-tip-notification-do-not-show-text.png.png", 1003);

            _gameTipCheckMark = AddTwoStateButton(45, 20, "UI/check-button-untapped.png", "UI/check-button-tapped.png", "UI/check-button-tapped.png", "UI/check-button-untapped.png", 1005);
            _gameTipCheckMark.OnClick += gameTipCheckMark_OnClick;
            _gameTipCheckMark.ButtonType = BUTTON_TYPE.CheckMark;

            _okIGotIt = AddButton(660, 10, "UI/OK-I-got-it-button-untapped.png", "UI/OK-I-got-it-button-tapped.png", 1005);
            _okIGotIt.OnClick += okIGotIt_OnClickTouch;
        }

        private void ShowSteeringTip(float dt)
        {
            Settings.Instance.ShowSteeringTip = false;

            if (Settings.Instance.NotificationsEnabled && Settings.Instance.GameTipGamePlayShow)
            {
                if (Settings.Instance.ControlType == CONTROL_TYPE.GYROSCOPE)
                {
                    ScheduleOnce(ShowTiltInstruction, 1);
                }
                else if (Settings.Instance.ControlType == CONTROL_TYPE.MANUAL)
                {
                    ScheduleOnce(ShowTouchInstruction, 1);
                }
            }
            else
            {
                CreateBtnBack();
            }
        }

        private void CreateBtnBack()
        {
            Schedule(UpdateAll);
            _btnBack = AddButton(2, 570, "UI/pause-button-untapped.png", "UI/pause-button-tapped.png", 100, BUTTON_TYPE.Back);
            _btnBack.OnClick += BtnBack_OnClick;
            _btnBack.ButtonType = BUTTON_TYPE.Back;

            _btnSettings = AddButton(70, 570, "UI/settings-button-untapped.png", "UI/settings-button-tapped.png", 100, BUTTON_TYPE.Back);
            _btnSettings.OnClick += btnSettings_OnClick;

            SetUpSteering(_launchMode == LAUNCH_MODE.DEFAULT);
        }

        private void gameTipCheckMark_OnClick(object sender, EventArgs e)
        {
            _gameTipCheckMark.ChangeState();
            _gameTipCheckMark.SetStateImages();
        }

        private void okIGotIt_OnClick(object sender, EventArgs e)
        {
            Settings.Instance.GameTipGamePlayShow = _gameTipCheckMark.State == 1 ? false : true;

            RemoveChild(_gameTipBackground);
            RemoveChild(_gameTipExplanation);
            RemoveChild(_gameTipArrow);
            RemoveChild(_gameTipTarget);
            RemoveChild(_gameTipCheckMark);
            RemoveChild(_okIGotIt);
            OnTouchBegan += GamePlayLayer_OnTouchBegan;
            Schedule(UpdateAll);
            _btnBack = AddButton(2, 570, "UI/pause-button-untapped.png", "UI/pause-button-tapped.png", 100, BUTTON_TYPE.Back);
            _btnBack.OnClick += BtnBack_OnClick;
            _btnBack.ButtonType = BUTTON_TYPE.Back;

            _btnSettings = AddButton(70, 570, "UI/settings-button-untapped.png", "UI/settings-button-tapped.png", 100, BUTTON_TYPE.Back);
            _btnSettings.OnClick += btnSettings_OnClick;

            /*if (!Settings.Instance.Vibration)
            {
                btnBack.Visible = false;
                btnSettings.Visible = false;
            }*/

        }

        private void okIGotIt_OnClickTouch(object sender, EventArgs e)
        {
            Settings.Instance.GameTipGamePlayShow = _gameTipCheckMark.State == 1 ? false : true;

            RemoveChild(_gameTipBackground);
            RemoveChild(_gameTipExplanation);
            RemoveChild(_gameTipArrow);
            RemoveChild(_gameTipTarget);
            RemoveChild(_gameTipCheckMark);
            RemoveChild(_okIGotIt);

            Settings.Instance.ShowSteeringTip = false;

            SetUpSteering(_launchMode == LAUNCH_MODE.DEFAULT);

            CreateBtnBack();

            Schedule(UpdateAll);
        }

        private void ShowAlienTip(float dt)
        {
            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.NOTIFICATION_POP_UP);
            _gameTipBackground = AddImageCentered(1136 / 2, 630 / 2, "UI/moon-level-notification-with-all-text.png", 1002);
            _gameTipExplanation = AddImage(100, 50, "UI/game-tip-notification-do-not-show-text.png.png", 1003);

            _gameTipCheckMark = AddTwoStateButton(45, 40, "UI/check-button-untapped.png", "UI/check-button-tapped.png", "UI/check-button-tapped.png", "UI/check-button-untapped.png", 1005);
            _gameTipCheckMark.OnClick += gameTipCheckMark_OnClick;
            _gameTipCheckMark.ButtonType = BUTTON_TYPE.CheckMark;

            _okIGotIt = AddButton(660, 20, "UI/OK-I-got-it-button-untapped.png", "UI/OK-I-got-it-button-tapped.png", 1005);
            _okIGotIt.OnClick += alienOkIGotIt_OnClick;
        }

        private void alienOkIGotIt_OnClick(object sender, EventArgs e)
        {
            Settings.Instance.AlienGameTipGamePlayShow = _gameTipCheckMark.State == 1 ? false : true;
            RemoveChild(_gameTipBackground);
            RemoveChild(_gameTipExplanation);
            RemoveChild(_gameTipCheckMark);
            RemoveChild(_okIGotIt);
            OnTouchBegan += GamePlayLayer_OnTouchBegan;
            Schedule(UpdateAll);
            _btnBack = AddButton(2, 570, "UI/pause-button-untapped.png", "UI/pause-button-tapped.png", 100, BUTTON_TYPE.Back);
            _btnBack.OnClick += BtnBack_OnClick;
            _btnBack.ButtonType = BUTTON_TYPE.Back;

            _btnSettings = AddButton(70, 570, "UI/settings-button-untapped.png", "UI/settings-button-tapped.png", 100, BUTTON_TYPE.Back);
            _btnSettings.OnClick += btnSettings_OnClick;

            /*if (!Settings.Instance.Vibration)
            {
                btnBack.Visible = false;
                btnSettings.Visible = false;
            }*/

        }

        private void ClearAll()
        {
            RemoveAllChildren();
            //cache.RemoveAllTextures();
            //cache.UnloadContent();
            /*cache.Dispose();
            bullets = null;
            enemies = null;
            bombs = null;
            ammos = null;
            lives = null;
            gunSmokes = null;*/
        }

        private void btnSettings_OnClick(object sender, EventArgs e)
        {
            //this.UnscheduleAll();
            //this.OnTouchBegan -= GamePlayLayer_OnTouchBegan;
            //this.TransitionToLayerCartoonStyle(new SettingsScreenLayer(), true);

            Console.WriteLine("Settings Button Clicked");

            //------------- Prabhjot --------------//
            if (_isGameOver)
            {
                //btnSettings = this.AddButton(70, 570, "UI/settings-button-tapped.png", "UI/settings-button-tapped.png", 100, BUTTON_TYPE.Back);
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
                return;
            }

            Settings.isFromGameScreen = false;
            var newScene = new CCScene(GameView);
            newScene.AddLayer(new SettingsScreenLayer(this, GameConstants.NavigationParam.GameScreen));
            Director.PushScene(newScene);

        }

        public CCLayerColorExt Continue()
        {
            BattlegroundImageName = Battleground.GetBattlegroundImageName(SelectedBattleground, Settings.Instance.BattlegroundStyle);
            SetBackground(BattlegroundImageName);

            //ako se promjenio instrumental/beatbox
            if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) SoundCannonShoot = "Sounds/Standard cannon (canon cal 3-3).wav";
            else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) SoundCannonShoot = "Sounds/cannon shot standard cannon (23).wav";

            if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) SoundCannonShoot = "Sounds/Black bazooka (canon cal 3-3).wav";
            else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) SoundCannonShoot = "Sounds/cannon shot black bazooka (23).wav";

            if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) SoundCannonShoot = "Sounds/Hybrid Canon Shoot Combo.wav";
            else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) SoundCannonShoot = "Sounds/85 - Hybrid Laser 2.wav";

            if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) SoundCannonShoot = "Sounds/Compact sprayer (canon cal 3-3).wav";
            else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) SoundCannonShoot = "Sounds/cannon shot compact sprayer (23).wav";

            CCAudioEngine.SharedEngine.PreloadEffect(SoundCannonShoot);
            SetUpSteering(true);

            //Schedule(UpdateAll);
            //this.OnTouchBegan += GamePlayLayer_OnTouchBegan;

            if (_waveTransfer)
            {
                if (SelectedEnemy == ENEMIES.ALIENS)
                {
                    GameEnvironment.PlayMusic(MUSIC.NEXTWAVEALIEN);
                    ScheduleOnce(NextWave, 3);
                }
                else
                {
                    switch (_wave)
                    {
                        case 1:
                            GameEnvironment.PlayMusic(MUSIC.NEXTWAVE);
                            ScheduleOnce(NextWave, 3);
                            break;
                        case 2:
                            GameEnvironment.PlayMusic(MUSIC.NEXTWAVE);
                            ScheduleOnce(NextWave, 3);
                            break;
                        case 3:
                            ScheduleOnce(Victory, 1);
                            break;
                    }
                }
            }
            else
            {
                if (SelectedEnemy == ENEMIES.ALIENS)
                {
                    switch (_wave)
                    {
                        case 1: GameEnvironment.PlayMusic(MUSIC.BATTLE_ALIEN1); break;
                        case 2: GameEnvironment.PlayMusic(MUSIC.BATTLE_ALIEN2); break;
                        case 3: GameEnvironment.PlayMusic(MUSIC.BATTLE_ALIEN3); break;
                        case 4: GameEnvironment.PlayMusic(MUSIC.BATTLE_ALIEN4); break;
                        case 5: GameEnvironment.PlayMusic(MUSIC.BATTLE_ALIEN5); break;
                        case 6: GameEnvironment.PlayMusic(MUSIC.BATTLE_ALIEN6); break;
                        case 7: GameEnvironment.PlayMusic(MUSIC.BATTLE_ALIEN7); break;
                        case 8: GameEnvironment.PlayMusic(MUSIC.BATTLE_ALIEN8); break;
                        case 9: GameEnvironment.PlayMusic(MUSIC.BATTLE_ALIEN9); break;
                        default:
                            switch (_wave % 3)
                            {
                                case 0: GameEnvironment.PlayMusic(MUSIC.BATTLE_ALIEN9); break;
                                case 1: GameEnvironment.PlayMusic(MUSIC.BATTLE_ALIEN3); break;
                                case 2: GameEnvironment.PlayMusic(MUSIC.BATTLE_ALIEN6); break;
                            }
                            break;

                    }
                }
                else if (_wave == 1)
                {
                    GameEnvironment.PlayMusic(MUSIC.BATTLE_WAVE_1);
                }
                else if (_wave == 2)
                {
                    GameEnvironment.PlayMusic(MUSIC.BATTLE_WAVE_2);
                }
                else
                {
                    GameEnvironment.PlayMusic(MUSIC.BATTLE_WAVE_3);
                }
            }
            return this;
        }

        CCSprite _gamePauseBackground;
        CCSpriteButton _btnJust;
        CCSpriteButton _btnSurrender;
        CCSpriteButton _btnContinue;
        CCSprite _gamePauseFriendlyLabel;
        CCSpriteTwoStateButton _gamePauseFriendlyCheckMark;

        public void BtnBack_OnClick(object sender, EventArgs e)
        {
            //------------- Prabhjot --------------//
            if (_isGameOver)
            {
                //btnBack = this.AddButton(2, 570, "UI/pause-button-tapped.png", "UI/pause-button-untapped.png", 100, BUTTON_TYPE.Back);
                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MENU_TAP_CANNOT_TAP);
                return;
            }

            Settings.isFromGameScreen = false;
            UnscheduleAll();
            OnTouchBegan -= GamePlayLayer_OnTouchBegan;

            if (Settings.Instance.GamePauseFriendly)
            {
                _gamePauseBackground = AddImageCentered(1136 / 2, 630 / 2, "UI/game-paused-friendly-notification-background-with-text.png", 2002);
            }
            else
            {
                _gamePauseBackground = AddImageCentered(1136 / 2, 630 / 2, "UI/game-paused-rude-notification-background-with-text.png", 2002);
            }
            _btnJust = AddButton(176, 320, "UI/game-paused-just-paused-button-untapped.png", "UI/game-paused-just-paused-button-tapped.png", 2003);
            _btnJust.OnClick += btnJust_OnClick;
            _btnSurrender = AddButton(176, 203, "UI/game-paused-surrender-button-untapped.png", "UI/game-paused-surrender-button-tapped.png", 2003);
            _btnSurrender.OnClick += btnSurrender_OnClick;
            _btnContinue = AddButton(176, 85, "UI/game-paused-lets-continue-button-untapped.png", "UI/game-paused-lets-continue-button-tapped.png", 2003);
            _btnContinue.OnClick += btnContinue_OnClick;


            _gamePauseFriendlyLabel = AddImage(120, 25, "UI/game-paused-friendly-do-not-insult-me-text.png", 2003);

            _gamePauseFriendlyCheckMark = AddTwoStateButton(45, 20, "UI/check-button-untapped.png", "UI/check-button-tapped.png", "UI/check-button-tapped.png", "UI/check-button-untapped.png", 2005);
            _gamePauseFriendlyCheckMark.OnClick += gamePauseFriendlyCheckMark_OnClick;
            _gamePauseFriendlyCheckMark.ButtonType = BUTTON_TYPE.CheckMark;
            _gamePauseFriendlyCheckMark.State = Settings.Instance.GamePauseFriendly ? 1 : 2;
            _gamePauseFriendlyCheckMark.SetStateImages();

            _btnBack.Visible = false;
            _btnSettings.Visible = false;


            /*
            clearAll();

            if (Test)
            {
                AdMobManager.HideBanner();
                this.TransitionToLayerCartoonStyle(new WeaponUpgradeScreenLayer((int)SelectedEnemyForPickerScreens, (int)SelectedWeapon, CaliberSizeSelected, FireSpeedSelected, MagazineSizeSelected, LivesSelected));
            }
            else
            {
                AdMobManager.HideBanner();
                this.TransitionToLayerCartoonStyle(new MainScreenLayer());
            }   
            */
        }

        private void btnJust_OnClick(object sender, EventArgs e)
        {
            //this.UnscheduleAll();
            //this.OnTouchBegan -= GamePlayLayer_OnTouchBegan;
            //this.TransitionToLayerCartoonStyle(new SettingsScreenLayer(), true);

            var newScene = new CCScene(GameView);
            newScene.AddLayer(new PauseScreenLayer(this));
            Director.PushScene(newScene);

        }



        private void btnSurrender_OnClick(object sender, EventArgs e)
        {
            //elapsedTime += 200;

            //Victory(0);

            //score = 24500;
            //wave = 13;
            GameOver(0);
        }




        private void btnContinue_OnClick(object sender, EventArgs e)
        {
            Settings.isFromGameScreen = true;
            RemoveChild(_gamePauseBackground);
            _gamePauseBackground = null;
            RemoveChild(_btnJust);
            _btnJust = null;
            RemoveChild(_btnSurrender);
            _btnSurrender = null;
            RemoveChild(_btnContinue);
            _btnContinue = null;
            RemoveChild(_gamePauseFriendlyLabel);
            _gamePauseFriendlyLabel = null;
            RemoveChild(_gamePauseFriendlyCheckMark);
            _gamePauseFriendlyCheckMark = null;

            _btnBack.Visible = true;
            _btnSettings.Visible = true;

            Schedule(UpdateAll);

            SetUpSteering(_launchMode == LAUNCH_MODE.DEFAULT);

            if (_waveTransfer)
            {
                if (SelectedEnemy == ENEMIES.ALIENS)
                {
                    ScheduleOnce(NextWave, 3);
                }
                else
                {
                    switch (_wave)
                    {
                        case 1:
                            ScheduleOnce(NextWave, 3);
                            break;
                        case 2:
                            ScheduleOnce(NextWave, 3);
                            break;
                        case 3:
                            ScheduleOnce(Victory, 1);
                            break;
                    }
                }
            }
        }


        private void gamePauseFriendlyCheckMark_OnClick(object sender, EventArgs e)
        {
            _gamePauseFriendlyCheckMark.ChangeState();
            _gamePauseFriendlyCheckMark.SetStateImages();
            Settings.Instance.GamePauseFriendly = _gamePauseFriendlyCheckMark.State == 1;
        }

        //Touch response for whole screen
        private void GamePlayLayer_OnTouchBegan(object sender, EventArgs e)
        {
            FireBtnPressed();
        }

        //Touch response for bottom area on screen
        void GamePlayLayer_OnTouchesBegan(List<CCTouch> touches, CCEvent touchEvent)
        {
            var touchPoint = touches[0].Location;
            if (touchPoint.Y < 200)
            {
                FireBtnPressed();
            }
        }

        void FireBtnPressed()
        {
            if (_ammos.Count > 0 && _playerExplosion == null && _gunCoolness <= 0)
            {
                //GameDelegate.Vibrate(100);
                var gunSmoke = new GunSmoke(this, Convert.ToInt32(_player.PositionX + _player.ContentSize.Width / 2) + 5, Convert.ToInt32(_player.PositionY + _player.ContentSize.Height + _smokeOffsetY));
                _gunSmokes.Add(gunSmoke);
                CCSprite bulletSprite;
                if (SelectedWeapon == WEAPONS.HYBRID)
                {
                    bulletSprite = AddImage(Convert.ToInt32(_player.PositionX + _player.ContentSize.Width / 2), Convert.ToInt32(_player.PositionY + _player.ContentSize.Height + _smokeOffsetY), "Player/green-lazer-bullet.png");
                }
                else
                {
                    bulletSprite = AddImage(Convert.ToInt32(_player.PositionX + _player.ContentSize.Width / 2), Convert.ToInt32(_player.PositionY + _player.ContentSize.Height + _smokeOffsetY), "Player/bullet.png");
                    gunSmoke.Sprite.Scale = _bulletScale;
                }

                bulletSprite.ZOrder = 8;
                bulletSprite.Scale = _bulletScale;
                bulletSprite.PositionX -= bulletSprite.ContentSize.Width * _bulletScale / 2;
                if (SelectedWeapon == WEAPONS.HYBRID)
                {
                    bulletSprite.PositionY -= 30;
                }
                //bullet.PositionY -= bullet.ContentSize.Height*bulletScale;
                var bullet = new Bullet();
                bullet.Sprite = bulletSprite;
                bullet.Power = _bulletPower;
                _bullets.Add(bullet);
                RemoveChild(_ammos[_ammos.Count - 1]);
                _ammos.RemoveAt(_ammos.Count - 1);
                _bulletsFired++;
                _gunCoolness = _gunCooloff;
                CCAudioEngine.SharedEngine.PlayEffect(SoundCannonShoot);
                if (_ammos.Count == 0)
                {
                    _reloading.Visible = true;
                    _reload = _reloadTime;
                }
            }
            else if (_ammos.Count == 0)
            {
                if (SelectedWeapon == WEAPONS.HYBRID)
                {
                    GameEnvironment.PlaySoundEffect(SOUNDEFFECT.EMPTY_CANON_HYBRID);
                }
                else
                {
                    GameEnvironment.PlaySoundEffect(SOUNDEFFECT.EMPTY_CANON);
                }
            }
        }

        private void GamePlayLayer_TouchResponse(List<CCTouch> touches, CCEvent touchEvent)
        {
            var fireButtonBoundingBox = _btnFire.BoundingBoxTransformedToWorld;

            foreach (var touch in touches)
            {
                if (RectangleWithin(fireButtonBoundingBox, touch.Location))
                {
                    FireBtnPressed();
                }
            }
        }

        void GameOver(float dt)
        {
            UnscheduleAll();
            Player.Instance.AddKills(SelectedEnemy, Kills);

            //CCLabel go = this.AddLabelCentered(1136 / 2, 315, "G A M E   O V E R", "Fonts/AktivGroteskBold", 16);
            //go.Scale = 2;
            //go.ZOrder = 100;
            ClearAll();
            Enabled = false;

            SetGameDuration();

            if (_launchMode == LAUNCH_MODE.WEAPON_TEST)
            {
                AdMobManager.HideBanner();
                TransitionToLayerCartoonStyle(new WeaponPickerLayer((int)SelectedEnemyForPickerScreens, (int)SelectedWeapon));
            }
            else if (_launchMode == LAUNCH_MODE.WEAPONS_UPGRADE_TEST)
            {
                AdMobManager.HideBanner();
                TransitionToLayerCartoonStyle(new WeaponUpgradeScreenLayer((int)SelectedEnemyForPickerScreens, (int)SelectedWeapon, CaliberSizeSelected, FireSpeedSelected, MagazineSizeSelected, LivesSelected));
            }
            else
            {
                Settings.isFromGameScreen = false;
                TransitionToLayerCartoonStyle(new LossScreenLayer(SelectedEnemy, SelectedWeapon, SelectedBattleground, _score, _wave));
            }
        }

        void Victory(float dt)
        {
            UnscheduleAll();
            Player.Instance.AddKills(SelectedEnemy, Kills);

            if (_bulletsFired == 0)
            {
                _bulletsFired = 1;
            }
            if (Math.Abs(_elapsedTime) < AppConstants.TOLERANCE)
            {
                _elapsedTime = 1;
            }
            ClearAll();
            SetGameDuration();

            if (_launchMode == LAUNCH_MODE.WEAPON_TEST)
            {
                AdMobManager.HideBanner();
                TransitionToLayerCartoonStyle(new WeaponPickerLayer((int)SelectedEnemyForPickerScreens, (int)SelectedWeapon));
            }
            else if (_launchMode == LAUNCH_MODE.WEAPONS_UPGRADE_TEST)
            {
                AdMobManager.HideBanner();
                TransitionToLayerCartoonStyle(new WeaponUpgradeScreenLayer((int)SelectedEnemyForPickerScreens, (int)SelectedWeapon, CaliberSizeSelected, FireSpeedSelected, MagazineSizeSelected, LivesSelected));
            }
            else if (_launchMode == LAUNCH_MODE.STEERING_TEST)
            {
                AdMobManager.HideBanner();
                StartGame();
            }
            if (_launchMode == LAUNCH_MODE.DEFAULT)
            {
                Settings.isFromGameScreen = false;
                TransitionToLayerCartoonStyle(new VictoryScreenLayer(SelectedEnemy, SelectedWeapon, SelectedBattleground, Convert.ToDecimal(_elapsedTime), Convert.ToDecimal((_bulletsFired - _bulletsMissed) * 100) / Convert.ToDecimal(_bulletsFired), _lives.Count, WinsInSuccession + 1));
            }
        }

        private void SetGameDuration()
        {
            Settings.Instance.SetTodaySessionDuration((int)_elapsedTime);
        }

        readonly CCLabel _label = null;

        CCSprite _nextWaveSprite;
        CCSprite[] _nextWaveNumberSprites;

        void NextWave(float dt)
        {
            RemoveChild(_nextWaveSprite);
            _nextWaveSprite = null;
            if (_nextWaveNumberSprites != null)
            {
                foreach (var waveDigit in _nextWaveNumberSprites)
                {
                    RemoveChild(waveDigit);
                }
                _nextWaveNumberSprites = null;
            }

            _wave++;
            if (_timeLabel.Visible)
            {
                _timeLabel.Opacity = byte.MaxValue;
                foreach (var timeDigit in _time)
                {
                    timeDigit.Opacity = byte.MaxValue;
                }
            }
            if (_multiplierLabel != null)
            {
                _multiplierLabel.Opacity = byte.MaxValue;
            }
            _bounces = 0;
            _flyingSaucerWait = 0;
            if (SelectedEnemy == ENEMIES.ALIENS)
            {
                _bombDensity -= 10;
                if (_wave == 6)
                {
                    _goingDownSpeed -= 1.5f;
                    _enemySpeed -= 1.5f;
                    _bombDensity += 40;
                }
                else if (_wave == 9)
                {
                    _goingDownSpeed -= 1.0f;
                    _enemySpeed -= 1.0f;
                    _bombDensity += 30;
                }
                else
                {
                    _enemySpeed += 0.5f;
                }
                _enemyCurrentSpeed = 0; //enemySpeed;
                _goingDownSpeed += 0.5f;
                if (_goingDownSpeed > 4) _goingDownSpeed = 4;
                if (_enemySpeed > 4) _enemySpeed = 4f;
                if (_bombDensity < 20) _bombDensity = 20;
            }
            else
            {
                _bombDensity -= 20;
                _enemySpeed += 0.7f;
                _enemyCurrentSpeed = 0; //enemySpeed;
                _goingDownSpeed += 0.7f;
            }
            _goingDownCurrentSpeed = _goingDownSpeed;
            _firstGoingDown = true;
            for (var j = _wave > 8 ? 4 : (_wave > 5 ? 3 : 2); j >= 0; j--)
            {
                for (var i = 0; i < 4; i++)
                {
                    var enemy = new Enemy(this, 1136 / 2 - 50 - (i * 100), 570 - (j * 65) + 290);
                    enemy.Sprite.ZOrder = 10 - (j * 3);
                    _enemies.Add(enemy);
                    enemy = new Enemy(this, 1136 / 2 + 50 + (i * 100), 570 - (j * 65) + 290);
                    _enemies.Add(enemy);
                    enemy.Sprite.ZOrder = 10 - (j * 3);
                }
            }
            if (_wave > 7)
            {
                _goingDown = 240;
            }
            else if (_wave > 5)
            {
                _goingDown = 240 + 32;
            }
            else if (_wave > 2)
            {
                _goingDown = 240 + 2 * 32;
            }
            else
            {
                _goingDown = 240 + _wave * 32;
            }
            _waveTransfer = false;
            _wavePass = 1136;
            if (SelectedEnemy == ENEMIES.ALIENS)
            {
                switch (_wave)
                {
                    case 1: GameEnvironment.PlayMusic(MUSIC.BATTLE_ALIEN1); break;
                    case 2: GameEnvironment.PlayMusic(MUSIC.BATTLE_ALIEN2); break;
                    case 3: GameEnvironment.PlayMusic(MUSIC.BATTLE_ALIEN3); break;
                    case 4: GameEnvironment.PlayMusic(MUSIC.BATTLE_ALIEN4); break;
                    case 5: GameEnvironment.PlayMusic(MUSIC.BATTLE_ALIEN5); break;
                    case 6: GameEnvironment.PlayMusic(MUSIC.BATTLE_ALIEN6); break;
                    case 7: GameEnvironment.PlayMusic(MUSIC.BATTLE_ALIEN7); break;
                    case 8: GameEnvironment.PlayMusic(MUSIC.BATTLE_ALIEN8); break;
                    case 9: GameEnvironment.PlayMusic(MUSIC.BATTLE_ALIEN9); break;
                    default:
                        switch (_wave % 3)
                        {
                            case 0: GameEnvironment.PlayMusic(MUSIC.BATTLE_ALIEN9); break;
                            case 1: GameEnvironment.PlayMusic(MUSIC.BATTLE_ALIEN3); break;
                            case 2: GameEnvironment.PlayMusic(MUSIC.BATTLE_ALIEN6); break;
                        }
                        break;

                }
            }
            else if (_wave == 2)
            {
                GameEnvironment.PlayMusic(MUSIC.BATTLE_WAVE_2);
            }
            else
            {
                GameEnvironment.PlayMusic(MUSIC.BATTLE_WAVE_3);
            }

        }

        bool InRectangle(CCRect rect, List<CCPoint> points, float offsetX, float offsetY, int reduceRectX = 0, int reduceRectY = 0)
        {
            var r = new CCRect(rect.LowerLeft.X + reduceRectX, rect.LowerLeft.Y + reduceRectY, rect.Size.Width - reduceRectX * 2, rect.Size.Height - reduceRectY * 2);
            foreach (var point in points)
            {
                if (r.ContainsPoint(new CCPoint(point.X + offsetX, offsetY - point.Y))) return true;
            }
            return false;
        }

        float InRectangleTopY(CCRect rect, List<CCPoint> points, float offsetX, float offsetY)
        {
            float topY = -1;
            foreach (var point in points)
            {
                if (rect.ContainsPoint(new CCPoint(point.X + offsetX, offsetY - point.Y)) && offsetY - point.Y > topY) topY = offsetY - point.Y;
            }
            return topY;
        }

        void PlayerExplode(bool loseAllLives = false)
        {
            _playerExplosion = new CCSprite(SsCannonExplosion1.Frames.Find(item => item.TextureFilename == "General_cannon_explosion_00.png"));
            _playerExplosion.PositionX = _player.PositionX + _player.ContentSize.Width / 2;
            _playerExplosion.PositionY = 0; //player.PositionY;
            _playerExplosion.AnchorPoint = new CCPoint(0.5f, 0);
            _playerExploding = 0;
            AddChild(_playerExplosion, 101);

            if (Settings.Instance.Vibration)
            {
                VibrationManager.Vibrate();
            }

            if (_lives.Count > 0 && !loseAllLives)
            {
                if (VoicePlayerHit != "")
                {
                    CCAudioEngine.SharedEngine.PlayEffect(VoicePlayerHit);
                    switch (_lives.Count)
                    {
                        case 0:
                            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.GUN_HIT_1);
                            break;
                        case 1:
                            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.GUN_HIT_2);
                            break;
                        default:
                            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.GUN_HIT_3);
                            break;
                    }
                }
            }
            else
            {

                //---------- Prabhjot ----------//

                //btnBack.Enabled = false;
                // btnSettings.Enabled = false;

                _btnBack = AddButton(2, 570, "UI/pause-button-tapped.png", "UI/pause-button-tapped.png", 100, BUTTON_TYPE.Back);
                _btnSettings = AddButton(70, 570, "UI/settings-button-tapped.png", "UI/settings-button-tapped.png", 100, BUTTON_TYPE.Back);


                _isGameOver = true;
                _gameOver = true;
                _gameOverLabel = AddImageCentered(1136 / 2, 630 / 2, "UI/Battle-screen-game-over...-text.png", 1010);
                _gameOverLabel.Scale = 0.8f;

                //CCLabel go = this.AddLabelCentered(1136 / 2, 315, "G A M E   O V E R", "Fonts/AktivGroteskBold", 16);
                //go.Scale = 2;
                //go.ZOrder = 100;

                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.GUN_HIT_GAME_OVER);
                if (Settings.Instance.VoiceoversEnabled)
                {
                    //isGameOver = false;
                    ScheduleOnce(CalloutGameOver, 0.2f);
                }
                else
                {
                    _isGameOver = true;
                    if (VoiceGameOver != "") CCAudioEngine.SharedEngine.PlayEffect(VoiceGameOver);
                }
            }
        }

        private void CalloutGameOver(float dt)
        {
            CCAudioEngine.SharedEngine.PlayEffect("Sounds/Game Over VO_mono.wav");
            ScheduleOnce(CalloutVoiceGameOver, 0.8f);
        }

        private void CalloutVoiceGameOver(float dt)
        {
            if (VoiceGameOver != "") CCAudioEngine.SharedEngine.PlayEffect(VoiceGameOver);
        }

        private void AnimateButtons(float dt)
        {
            var fireButtonX = 918;
            var fireButtonY = 2;

            var steerinButtonX = 3;
            var steeringButtonY = 2;

            if (!Settings.Instance.RightHanded)
            {
                fireButtonX = 3;
                steerinButtonX = 715;
            }


            RemoveChild(_fadeShootButton);
            RemoveChild(_fadeControlButton);

            _fadeShootButton = AddImage(fireButtonX, fireButtonY, $"UI/Controls/Fire button/{_fadeLevel.ToString("D3")}-transparent-fire-button-untapped.png", 102);
            _fadeControlButton = AddImage(steerinButtonX, steeringButtonY, $"UI/Controls/Steering arrow/{_fadeLevel.ToString("D3")}-transparent-movement-arrow-untapped.png", 102);

            _fadeLevel += 5;

            if (_fadeLevel >= 80)
            {
                RemoveChild(_fadeShootButton);
                RemoveChild(_fadeControlButton);
                Unschedule(AnimateButtons);

                _btnFire.Visible = true;
                _btnMovement.Visible = true;
            }
        }

        int GetAngleForMaxSpeedBySensivityLvl()
        {
            var angleSensivityStep = 5;

            var sensitivity = 9 - Settings.Instance.SensitivityLevel;

            var maxSpeedAngle = angleSensivityStep * sensitivity;

            return maxSpeedAngle;
        }

        void UpdateAll(float dt)
        {
            if (_label != null) RemoveChild(_label);

            if (!_waveTransfer)
            {
                _elapsedTime += dt;
            }
            //if (Settings.Instance.Vibration)
            //{
            if (SelectedEnemy == ENEMIES.ALIENS)
            {
                if (_lastDisplayedScore != _score)
                {
                    _lastDisplayedScore = _score;

                    foreach (var spr in _time)
                    {
                        RemoveChild(spr);
                    }
                    _time = AddImageLabelRightAligned(1120, 580, _lastDisplayedScore.ToString(), 50);
                    _timeLabel.PositionX = _time[0].PositionX - _timeLabel.ContentSize.Width / 2 - 60;


                }

                if (_scoreMultiplier == 1 && _multiplierLabel != null)
                {
                    _multiplierLabel.Opacity -= 5;
                    if (_multiplierLabel.Opacity < 20)
                    {
                        RemoveChild(_multiplierLabel);
                        _multiplierLabel = null;
                    }
                }
                if (_scoreMultiplier > 1 && _multiplierLabelLabel.Opacity < 255)
                {
                    _multiplierLabelLabel.Opacity += 5;
                }
                if (_scoreMultiplier == 1 && _multiplierLabelLabel.Opacity > 0)
                {
                    _multiplierLabelLabel.Opacity -= 5;
                }

            }
            else
            {
                if (_lastDisplayedTime < Convert.ToInt32(_elapsedTime))
                {
                    _lastDisplayedTime = Convert.ToInt32(_elapsedTime);

                    foreach (var spr in _time)
                    {
                        RemoveChild(spr);
                    }
                    if (_launchMode != LAUNCH_MODE.STEERING_TEST)
                        _time = AddImageLabel(1040, 580, _lastDisplayedTime.ToString(), 50);
                }
            }
            //}

            for (var i = 0; i < _multipliers.Count;)
            {
                var multiplier = _multipliers[i];
                if (multiplier.Opacity > 240)
                {
                    multiplier.PositionX += (1096 - multiplier.PositionX) / (255 - multiplier.Opacity);
                    multiplier.PositionY += (570 - multiplier.PositionY) / (255 - multiplier.Opacity);
                    multiplier.Scale = multiplier.ScaleX - 0.033f;
                    multiplier.Opacity += 1;
                    if (multiplier.Opacity == 255)
                    {
                        if (_multiplierLabel != null)
                        {
                            RemoveChild(_multiplierLabel);
                        }
                        _multiplierLabel = multiplier;
                        _multipliers.Remove(multiplier);
                    }
                    else
                    {
                        i++;
                    }
                    //980, 550
                }
                else
                {
                    multiplier.PositionY += 2;
                    multiplier.Opacity += 1;
                    if (multiplier.Opacity > 240)
                    {
                        GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MULTIPLIER_INDICATOR);
                        GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MULTIPLIER_INDICATOR);
                    }
                    i++;
                }
            }

            if (_gunCoolness > 0) _gunCoolness -= dt;
            if (_shitWait > 0) _shitWait -= dt;

            if (Settings.Instance.ControlType == CONTROL_TYPE.GYROSCOPE)
            {
                var yaw = 0f;
                var tilt = 0f;
                var pitch = 0f;

                //---------- Prabhjot Singh ------//
                GameDelegate.GetGyro(ref yaw, ref tilt, ref pitch);

                pitch = pitch >= 90 ? 180 - pitch : pitch;

                var maxAngleBySensivity = GetAngleForMaxSpeedBySensivityLvl();

                var maxSpeed = 1;

                if (Math.Abs(pitch) > maxAngleBySensivity)
                {
                    ControlMovement = maxSpeed * pitch >= 0 ? 1 : -1;
                }
                else
                {
                    ControlMovement = (float)Math.Round(maxSpeed * pitch / maxAngleBySensivity, 2);
                }

                TiltAngle = -pitch;
            }

            //float move = Math.Abs((float)Math.Sin(Math.PI / 180 * tilt)) > Math.Abs((float)Math.Sin(Math.PI / 180 * pitch)) ? (float)Math.Sin(Math.PI / 180 * tilt) : (float)Math.Sin(Math.PI / 180 * pitch);




            //label = this.AddLabelCentered(850, 620, (playerExplosion==null?"null":"*") + playerExploding.ToString() +" || "+ yaw.ToString("0.00") + ", " + tilt.ToString("0.00") + ", " + pitch.ToString("0.00") + ", move: " + move.ToString("0.00"), "Fonts/AktivGroteskBold", 12);
            //label = this.AddLabelCentered(850, 620, pitch.ToString("0.00") , "Fonts/AktivGroteskBold", 12);
            //label.Color = CCColor3B.Black;



            if (_fireworkFrame > 0 && SelectedBattleground == BATTLEGROUNDS.FINLAND)
            {
                _fireworkFrame += dt * 27;

                if (Convert.ToInt32(_fireworkFrame) != _fireworkFrameLast)
                {
                    _fireworkFrameLast = Convert.ToInt32(_fireworkFrame);

                    if (_fireworkFrameLast == 1)
                    {
                        CCAudioEngine.SharedEngine.PlayEffect("Sounds/Firework Sound Effect mono.wav");
                        _firework = new CCSprite(_ssFirework[0].Frames.Find(item => item.TextureFilename == "Firework_animation_image_001.png"));
                        _firework.AnchorPoint = new CCPoint(0.5f, 0.5f);
                        _firework.Position = new CCPoint(568, 320);
                        _firework.ZOrder = 0;
                        _firework.Scale = 4;
                        _fireworkFrame = 1;
                        AddChild(_firework);
                    }
                    else if (_fireworkFrameLast <= 84)
                    {
                        _firework.TextureRectInPixels = _ssFirework[0].Frames.Find(item => item.TextureFilename == "Firework_animation_image_" + _fireworkFrameLast.ToString().PadLeft(3, '0') + ".png").TextureRectInPixels;
                        _firework.BlendFunc = GameEnvironment.BlendFuncDefault;
                    }
                    else if (_fireworkFrameLast == 85)
                    {
                        RemoveChild(_firework);
                        _firework = new CCSprite(_ssFirework[1].Frames.Find(item => item.TextureFilename == "Firework_animation_image_085.png"));
                        _firework.AnchorPoint = new CCPoint(0.5f, 0.5f);
                        _firework.Position = new CCPoint(568, 320);
                        _firework.ZOrder = 0;
                        _firework.Scale = 4;
                        AddChild(_firework);

                    }
                    else if (_fireworkFrame <= 124)
                    {
                        _firework.TextureRectInPixels = _ssFirework[1].Frames.Find(item => item.TextureFilename == "Firework_animation_image_" + _fireworkFrameLast.ToString().PadLeft(3, '0') + ".png").TextureRectInPixels;
                        _firework.BlendFunc = GameEnvironment.BlendFuncDefault;
                    }
                    if (_fireworkFrameLast >= 124)
                    {
                        RemoveChild(_firework);
                        _fireworkFrame = 0;
                    }
                }
            }

            if (_playerExplosion == null)
            {
                /*
                if (SelectedEnemy == ENEMIES.ALIENS)
                {
                    if (Math.Abs(move) < 0.07)
                    {
                        if (cannonMovingFX != SOUNDEFFECT.CANNON_STILL)
                        {
                            if (cannonMovingFXId != null) CCAudioEngine.SharedEngine.StopEffect(cannonMovingFXId.Value);
                            cannonMovingFXId = GameEnvironment.PlaySoundEffect(SOUNDEFFECT.CANNON_STILL);
                            cannonMovingFX = SOUNDEFFECT.CANNON_STILL;
                        }
                    }
                    else if (Math.Abs(move) < 0.2)
                    {
                        if (cannonMovingFX != SOUNDEFFECT.CANNON_SLOW)
                        {
                            if (cannonMovingFXId != null) CCAudioEngine.SharedEngine.StopEffect(cannonMovingFXId.Value);
                            cannonMovingFXId = GameEnvironment.PlaySoundEffect(SOUNDEFFECT.CANNON_SLOW);
                            cannonMovingFX = SOUNDEFFECT.CANNON_SLOW;
                        }
                    }
                    else
                    {
                        if (cannonMovingFX != SOUNDEFFECT.CANNON_FAST)
                        {
                            if (cannonMovingFXId != null) CCAudioEngine.SharedEngine.StopEffect(cannonMovingFXId.Value);
                            cannonMovingFXId = GameEnvironment.PlaySoundEffect(SOUNDEFFECT.CANNON_FAST);
                            cannonMovingFX = SOUNDEFFECT.CANNON_FAST;
                        }
                    }
                }*/

                if (Settings.Instance.ControlType == CONTROL_TYPE.GYROSCOPE)
                {
                    _player.PositionX -= ControlMovement * _playerSpeed;
                }
                else
                {
                    if (_isCannonMoving)
                    {
                        _movingTime += 1;
                    }
                    else
                    {
                        _movingTime = 0;
                    }

                    if (_movingTime < 40)
                    {
                        ControlMovement = _speedTo * _movingTime / 40f;
                        _player.PositionX -= ControlMovement * _playerSpeed;
                    }
                    else
                    {
                        ControlMovement = _speedTo;
                        _player.PositionX -= _speedTo * _playerSpeed;
                    }

                    if (Math.Abs(ControlMovement) < AppConstants.TOLERANCE)
                    {
                        _movingTime = 0;
                    }
                }

                if (_player.PositionX < 10) _player.PositionX = 10;
                if (_player.PositionX > 1000) _player.PositionX = 1000;

                //player.PositionY = 50 - (gunCoolness == gunCooloff?8: ( gunCoolness / gunCooloff * 15));

                _player.TextureRectInPixels = SsRecoil.Frames.Find(item => item.TextureFilename == SsRecoilKeyPrefix + (12 - (12 * _gunCoolness / _gunCooloff)).ToString("0#") + ".png").TextureRectInPixels;


            }
            else
            {
                if (_cannonMovingFxId != null)
                {
                    CCAudioEngine.SharedEngine.StopEffect(_cannonMovingFxId.Value);
                    _cannonMovingFxId = null;
                    //_cannonMovingFx = null;
                }
            }

            if (_reload > 0)
            {
                var timeForSound = _reload > 0.8;
                _reload = _reload - dt;
                if (_reload <= 0.8 && timeForSound)
                {
                    if (SelectedWeapon == WEAPONS.HYBRID)
                    {
                        GameEnvironment.PlaySoundEffect(SOUNDEFFECT.CALIBRE_1_HYBRID);
                    }
                    else
                    {
                        GameEnvironment.PlaySoundEffect(SOUNDEFFECT.CALIBRE_1);
                    }
                }
                if (_reload <= 0)
                {
                    for (var i = 0; i < _magazineSize; i++)
                    {
                        CCSprite ammo;
                        if (SelectedWeapon == WEAPONS.HYBRID)
                        {
                            ammo = AddImage(1080 - i * 16, 10, "Player/laser-ammo.png", 102);
                        }
                        else
                        {
                            ammo = AddImage(1080 - i * 16, 10, "Player/ammo.png", 102);
                        }
                        _ammos.Add(ammo);
                        _reloading.Visible = false;
                    }
                }
            }


            for (var i = 0; i < _gunSmokes.Count;)
            {
                var gunSmoke = _gunSmokes[i];
                if (SelectedWeapon == WEAPONS.HYBRID)
                {
                    var sheet = 0;
                    if (Convert.ToInt32(gunSmoke.Smoke + 6) > 11) sheet = 1;
                    if (Convert.ToInt32(gunSmoke.Smoke + 6) > 18) sheet = 2;

                    if (gunSmoke.Sprite.Texture != SsHybridLaser[sheet].Frames.Find(item => item.TextureFilename == "pipe-flames-and-lens-flare-image_" + Convert.ToInt32(gunSmoke.Smoke + 6).ToString().PadLeft(2, '0') + ".png").Texture)
                    {
                        var newGunSmoke = new CCSprite(SsHybridLaser[sheet].Frames.Find(item => item.TextureFilename == "pipe-flames-and-lens-flare-image_" + Convert.ToInt32(gunSmoke.Smoke + 6).ToString().PadLeft(2, '0') + ".png"));
                        newGunSmoke.AnchorPoint = new CCPoint(0.5f, 0);
                        newGunSmoke.PositionX = gunSmoke.Sprite.PositionX;
                        newGunSmoke.PositionY = gunSmoke.Sprite.PositionY;
                        newGunSmoke.Opacity = gunSmoke.Sprite.Opacity;
                        AddChild(newGunSmoke, gunSmoke.Sprite.ZOrder);
                        RemoveChild(gunSmoke.Sprite);
                        gunSmoke.Sprite = newGunSmoke;
                    }

                    gunSmoke.Sprite.TextureRectInPixels = SsHybridLaser[sheet].Frames.Find(item => item.TextureFilename == "pipe-flames-and-lens-flare-image_" + Convert.ToInt32(gunSmoke.Smoke + 6).ToString().PadLeft(2, '0') + ".png").TextureRectInPixels;

                    gunSmoke.Sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
                    gunSmoke.Smoke += 1f;
                    if (Convert.ToInt32(gunSmoke.Smoke + 6) == 15) gunSmoke.Smoke += 1f;  //fali image

                    if (Convert.ToInt32(gunSmoke.Smoke + 6) > 24)
                    {
                        gunSmoke.Destroy();
                        _gunSmokes.Remove(gunSmoke);
                    }
                    else
                    {
                        i++;
                    }
                }
                else
                {
                    gunSmoke.Sprite.TextureRectInPixels = SsCannonFlame.Frames.Find(item => item.TextureFilename == "General_cannon_flame" + Convert.ToInt32(gunSmoke.Smoke).ToString().PadLeft(2, '0') + ".png").TextureRectInPixels;

                    gunSmoke.Sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
                    gunSmoke.Smoke += 1f;
                    if (gunSmoke.Smoke > 14)
                    {
                        gunSmoke.Sprite.Opacity = Convert.ToByte(280 - Convert.ToInt32(gunSmoke.Smoke * 3));
                    }
                    if (gunSmoke.Smoke > 71)
                    {
                        gunSmoke.Destroy();
                        _gunSmokes.Remove(gunSmoke);
                    }
                    else
                    {
                        i++;
                    }
                }
            }


            for (var i = 0; i < _explos.Count;)
            {
                var explo = _explos[i];
                explo.Sprite.TextureRectInPixels = SsPreExplosion.Frames.Find(item => item.TextureFilename == "Pre-explosion_image_" + Convert.ToInt32(explo.Explo).ToString().PadLeft(2, '0') + ".png").TextureRectInPixels;
                explo.Sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
                explo.Sprite.PositionY += 1;
                explo.Explo += 1f;
                if (explo.Explo > 8)
                {
                    explo.Sprite.Opacity = Convert.ToByte(280 - Convert.ToInt32(explo.Explo * 7));
                }
                if (Convert.ToInt32(explo.Explo) > 23)
                {
                    explo.Destroy();
                    _explos.Remove(explo);
                }
                else
                {
                    i++;
                }
            }

            for (var i = 0; i < _bullets.Count;)
            {

                var bullet = _bullets[i].Sprite;

                bullet.PositionY += 10;

                if (_bullets[i].Power > 0)
                {
                    CCRect rec;
                    if (SelectedWeapon == WEAPONS.HYBRID)
                    {
                        rec = new CCRect(bullet.PositionX + bullet.ContentSize.Width / 2 - 4, bullet.PositionY + 25, 8, 40);
                    }
                    else
                    {
                        rec = bullet.BoundingBox;
                    }



                    if (_flyingSaucer != null && _flyingSaucerExplosion == null && rec.IntersectsRect(new CCRect(_flyingSaucer.PositionX - 50, _flyingSaucer.PositionY - 10, 100, 25)))
                    {
                        _bullets[i].Power = 0;
                        _flyingSaucerExplosion = new CCSprite(SsEnemyExplosion.Frames.Find(item => item.TextureFilename == "General_enemy_explosion00.png"));
                        _flyingSaucerExplosion.AnchorPoint = new CCPoint(0.5f, 0.5f);
                        _flyingSaucerExplosion.Position = new CCPoint(_flyingSaucer.PositionX, _flyingSaucer.PositionY);
                        _flyingSaucerExplosion.BlendFunc = GameEnvironment.BlendFuncDefault;
                        _flyingSaucerExplosionFrame = 0;
                        AddChild(_flyingSaucerExplosion, 25);

                        var explo = new Explosion(this, Convert.ToInt32(bullet.PositionX + bullet.ContentSize.Width / 2), Convert.ToInt32(bullet.PositionY + bullet.ContentSize.Height / 2));
                        _explos.Add(explo);

                        CCAudioEngine.SharedEngine.StopEffect(_flyingSaucerFlyingFxId.Value);
                        GameEnvironment.PlaySoundEffect(SOUNDEFFECT.FLYINGSAUCER_EXPLOSION);
                        _flyingSaucerWait = 10000000;

                        var life = AddImage(_lives.Count * 80 + 20, 10, PlayerLivesLeft, _player.ZOrder - 1);
                        _lives.Add(life);
                    }

                    for (var j = 0; j < _enemies.Count; j++)
                    {
                        var enemy = _enemies[j];

                        if (!enemy.Killed && InRectangle(rec, EnemyCollisionPoints, enemy.Sprite.PositionX - enemy.Sprite.ContentSize.Width / 2, enemy.Sprite.PositionY))
                        {
                            var eh = enemy.Health;
                            enemy.Health -= _bullets[i].Power;
                            _bullets[i].Power -= eh;

                            var explo = new Explosion(this, Convert.ToInt32(bullet.PositionX + bullet.ContentSize.Width / 2), Convert.ToInt32(bullet.PositionY + bullet.ContentSize.Height / 2));
                            _explos.Add(explo);

                            switch (_random.Next(3))
                            {
                                case 0:
                                    GameEnvironment.PlaySoundEffect(SOUNDEFFECT.ENEMY_HURT_1);
                                    break;
                                case 1:
                                    GameEnvironment.PlaySoundEffect(SOUNDEFFECT.ENEMY_HURT_2);
                                    break;
                                case 2:
                                    GameEnvironment.PlaySoundEffect(SOUNDEFFECT.ENEMY_HURT_3);
                                    break;
                            }
                            if (enemy.Health <= 0)
                            {
                                if (Settings.Instance.SwearingEnabled)
                                {
                                    if (VoiceEnemyHit != "" && _shitWait <= 0)
                                    {
                                        _shitWait = 1 + _random.Next(100) / 100f;
                                        if (SelectedEnemy == ENEMIES.HITLER && _random.Next(4) == 0)
                                        {
                                            CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hitler 3 Scheisse.wav");
                                        }
                                        else if (!String.IsNullOrEmpty(VoiceEnemyHit))
                                        {
                                            CCAudioEngine.SharedEngine.PlayEffect(VoiceEnemyHit);
                                        }
                                    }
                                }

                                if (enemy.LaserFxId1 != null) CCAudioEngine.SharedEngine.StopEffect(enemy.LaserFxId1.Value);
                                if (enemy.LaserFxId2 != null) CCAudioEngine.SharedEngine.StopEffect(enemy.LaserFxId2.Value);
                                if (enemy.LaserFxId3 != null) CCAudioEngine.SharedEngine.StopEffect(enemy.LaserFxId3.Value);

                                RemoveChild(enemy.LensFlare);
                                enemy.LensFlare = null;

                                enemy.keepGrimace = 0;
                                enemy.Killed = true;

                                if (SelectedEnemy == ENEMIES.ALIENS)
                                {
                                    _score += 5 * _scoreMultiplier;
                                    _killsWithoutMiss++;
                                    if (_killsWithoutMiss >= 5 && _scoreMultiplier < 8)
                                    {
                                        _scoreMultiplier = _scoreMultiplier * 2;
                                        _killsWithoutMiss = 0;
                                        var multiplier = AddImageCentered(Convert.ToInt32(enemy.Sprite.PositionX), Convert.ToInt32(enemy.Sprite.PositionY - enemy.Sprite.ContentSize.Height / 2), "UI/" + _scoreMultiplier.ToString() + "X-text-for-explosion.png", 100);
                                        multiplier.Opacity = 200;
                                        _multipliers.Add(multiplier);
                                    }
                                }
                                Kills++;

                                if (enemy.AttachedBomb != null)
                                {
                                    enemy.BombOut();
                                    enemy.AttachedBomb.Released = true;
                                    enemy.AttachedBomb.SpeedX = _enemyCurrentSpeed;
                                    enemy.AttachedBomb = null;
                                }
                                if (enemy.Spit != null)
                                {
                                    RemoveChild(enemy.Spit);
                                    enemy.Spit = null;
                                }
                                if (_goingDown <= 32) enemy.SpeedX = _enemyCurrentSpeed;
                                enemy.Explosion = new CCSprite(SsEnemyExplosion.Frames.Find(item => item.TextureFilename == "General_enemy_explosion00.png"));
                                enemy.Explosion.Position = new CCPoint(enemy.Sprite.PositionX, enemy.Sprite.PositionY - enemy.Sprite.ContentSize.Height / 2);
                                enemy.Explosion.AnchorPoint = new CCPoint(0.5f, 0.5f);
                                enemy.Explosion.BlendFunc = GameEnvironment.BlendFuncDefault;
                                AddChild(enemy.Explosion, 25);
                            }
                            else
                            {
                                if (VoiceEnemyWound1 != null)
                                {
                                    var r = _random.Next(VoiceEnemyWound3 == null ? 2 : 3);
                                    switch (r)
                                    {
                                        case 2:
                                            CCAudioEngine.SharedEngine.PlayEffect(VoiceEnemyWound3);
                                            break;
                                        case 1:
                                            CCAudioEngine.SharedEngine.PlayEffect(VoiceEnemyWound2);
                                            break;
                                        default:
                                            CCAudioEngine.SharedEngine.PlayEffect(VoiceEnemyWound1);
                                            break;
                                    }
                                }
                                if (_random.Next(2) == 0)
                                {
                                    enemy.State = ENEMYSTATE.DAMAGE1;
                                    if (enemy.OpenMouth != null)
                                    {
                                        RemoveChild(enemy.OpenMouth);
                                        enemy.OpenMouth = new CCSprite(GameEnvironment.ImageDirectory + EnemyMouthOpenDamaged1, new CCRect(0, 0, EnemyMouthClipWidth, EnemyMouthClipHeight));
                                        enemy.OpenMouth.Position = new CCPoint(enemy.Sprite.PositionX, enemy.Sprite.PositionY);
                                        enemy.OpenMouth.AnchorPoint = new CCPoint(0.5f, 1);
                                        enemy.OpenMouth.BlendFunc = GameEnvironment.BlendFuncDefault;
                                        AddChild(enemy.OpenMouth, enemy.Sprite.ZOrder + 2);

                                        enemy.Sprite.Texture = new CCTexture2D(GameEnvironment.ImageDirectory + EnemyMouthOpenDamaged1);
                                        enemy.Sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
                                    }
                                    else
                                    {
                                        enemy.Sprite.Texture = new CCTexture2D(GameEnvironment.ImageDirectory + EnemyMouthClosedDamaged1);
                                        enemy.Sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
                                    }
                                }
                                else
                                {
                                    enemy.State = ENEMYSTATE.DAMAGE2;
                                    if (enemy.OpenMouth != null)
                                    {
                                        RemoveChild(enemy.OpenMouth);
                                        enemy.OpenMouth = new CCSprite(GameEnvironment.ImageDirectory + EnemyMouthOpenDamaged2, new CCRect(0, 0, EnemyMouthClipWidth, EnemyMouthClipHeight));
                                        enemy.OpenMouth.Position = new CCPoint(enemy.Sprite.PositionX, enemy.Sprite.PositionY);
                                        enemy.OpenMouth.AnchorPoint = new CCPoint(0.5f, 1);
                                        enemy.OpenMouth.BlendFunc = GameEnvironment.BlendFuncDefault;
                                        AddChild(enemy.OpenMouth, enemy.Sprite.ZOrder + 2);

                                        enemy.Sprite.Texture = new CCTexture2D(GameEnvironment.ImageDirectory + EnemyMouthOpenDamaged2);
                                        enemy.Sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
                                    }
                                    else
                                    {
                                        enemy.Sprite.Texture = new CCTexture2D(GameEnvironment.ImageDirectory + EnemyMouthClosedDamaged2);
                                        enemy.Sprite.BlendFunc = GameEnvironment.BlendFuncDefault;

                                    }
                                }
                            }
                            if (_bullets[i].Power <= 0)
                            {
                                break;
                            }
                        }
                    }
                }
                else
                {
                    bullet.Opacity -= 50;
                    if (bullet.Opacity < 50) bullet.Opacity = 0;
                }

                if (bullet.Opacity == 0 || bullet.PositionY > 650)
                {
                    if (Math.Abs(_bullets[i].Power - _bulletPower) < AppConstants.TOLERANCE)
                    {
                        _bulletsMissed++;
                        _killsWithoutMiss = 0;
                        if (_scoreMultiplier > 1)
                        {
                            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MULTIPLIER_LOST);
                            _scoreMultiplier = 1;
                        }
                        if (VoiceMiss != null)
                        {
                            if (VoiceMissAlternate != null && _random.Next(3) == 0)
                            {
                                CCAudioEngine.SharedEngine.PlayEffect(VoiceMissAlternate);
                            }
                            else
                            {
                                CCAudioEngine.SharedEngine.PlayEffect(VoiceMiss);
                            }
                        }
                    }
                    RemoveChild(bullet);
                    _bullets.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }



            for (var i = 0; i < _bombs.Count;)
            {
                var bombRemoved = false;
                var bomb = _bombs[i];

                if (bomb.Sprite.ScaleX < 1) bomb.Sprite.Scale = bomb.Sprite.ScaleX + 0.025f;
                bomb.Sprite.PositionY -= bomb.SpeedY;
                /*if (bomb.SpeedY < 12)
                {
                    bomb.SpeedY += 0.06f;
                }
                else if (bomb.SpeedY < 17)
                {
                    bomb.SpeedY += 0.04f;
                }
                else */
                if (bomb.SpeedY < 24)
                {
                    bomb.SpeedY += 0.03f;
                }
                else
                {
                    bomb.SpeedY = 24;
                }
                if (bomb.RotationSpeed < 0.3) bomb.RotationSpeed += 0.002f;

                if (bomb.Released)
                {

                    bomb.Sprite.PositionX += bomb.SpeedX;
                    if (bomb.SpeedX > 0.1)
                    {
                        bomb.SpeedX -= 0.02f;
                    }
                    else if (bomb.SpeedX < -0.1)
                    {
                        bomb.SpeedX += 0.02f;
                    }
                    else
                    {
                        bomb.SpeedX = 0;
                    }
                }


                bomb.Rotation += bomb.RotationSpeed;
                //bomb.Sprite.Rotation = bomb.Rotation;

                if (bomb.RotationSpeed > 0 && SelectedEnemy != ENEMIES.ALIENS)
                {
                    if (Convert.ToInt32(bomb.Rotation) > 16) bomb.Rotation = 0;
                    bomb.Sprite.TextureRectInPixels = SsBomb.Frames.Find(item => item.TextureFilename == "bomb-animation-image-" + Convert.ToInt32(bomb.Rotation).ToString() + ".png").TextureRectInPixels;
                }
                else
                {
                    if (Convert.ToInt32(bomb.Rotation) > 14) bomb.Rotation = 0;
                    bomb.Sprite.TextureRectInPixels = SsBomb.Frames.Find(item => item.TextureFilename == "slime-ball-image_" + Convert.ToInt32(bomb.Rotation).ToString() + ".png").TextureRectInPixels;
                }


                if (!bomb.Collided && InRectangle(bomb.Sprite.BoundingBox, PlayerCollisionPoints, _player.PositionX, _player.PositionY + _player.ContentSize.Height, SelectedEnemy == ENEMIES.ALIENS ? 7 : 0, SelectedEnemy == ENEMIES.ALIENS ? 7 : 0))
                {
                    //bomb.SpeedY = -random.Next(2, Convert.ToInt32(Math.Abs(bomb.SpeedY) * 100)) / 100f;
                    //bomb.SpeedX = random.Next(Convert.ToInt32(Math.Abs(bomb.SpeedY) * 100)) / 100f;
                    //if (bomb.Sprite.PositionX < player.PositionX + player.ContentSize.Width / 2) bomb.SpeedX = -bomb.SpeedX;
                    //bomb.SpeedX += move;
                    //bomb.RotationSpeed = random.Next(50) / 5;
                    bomb.Collided = true;


                    if (_playerExplosion == null)
                    {
                        //bomb.Destroy();
                        //bombs.Remove(bomb);
                        //bombRemoved = true;
                        PlayerExplode();

                        var explo = new Explosion(this, Convert.ToInt32(bomb.Sprite.PositionX), Convert.ToInt32(bomb.Sprite.PositionY));
                        _explos.Add(explo);



                    }
                }

                if (bomb.Collided)
                {
                    if (bomb.Sprite.Opacity > 50)
                    {
                        bomb.Sprite.Opacity -= 50;
                    }
                    else
                    {
                        bomb.Sprite.Opacity = 0;
                    }
                }


                if (bomb.Sprite != null && bomb.Sprite.PositionY < 0 && bomb.Released)
                {
                    bomb.Destroy();
                    _bombs.Remove(bomb);

                }
                else if (!bombRemoved)
                {
                    i++;
                }
            }


            if (_playerExplosion != null)
            {
                if (_playerExploding > 72)
                {
                    _scoreMultiplier = 1;
                    _playerExplosion.Visible = false;
                    if (_playerExploding > 150 && _bombs.Count == 0 && _lives.Count > 0)
                    {
                        RemoveChild(_lives[_lives.Count - 1]);
                        _lives.RemoveAt(_lives.Count - 1);
                        RemoveChild(_playerExplosion);
                        _playerExplosion = null;
                        _player.Visible = true;
                    }
                }
                else
                {
                    if (Convert.ToInt32(_playerExploding) < 54)
                    {
                        _playerExplosion.TextureRectInPixels = SsCannonExplosion1.Frames.Find(item => item.TextureFilename == "General_cannon_explosion_" + Convert.ToInt32(_playerExploding).ToString().PadLeft(2, '0') + ".png").TextureRectInPixels;
                    }
                    else
                    {
                        if (_playerExplosion.Texture != SsCannonExplosion2.Frames.Find(item => item.TextureFilename == "General_cannon_explosion_54.png").Texture)
                        {
                            var newPlayerExplosion = new CCSprite(SsCannonExplosion2.Frames.Find(item => item.TextureFilename == "General_cannon_explosion_54.png"));
                            newPlayerExplosion.AnchorPoint = new CCPoint(0.5f, 0);
                            newPlayerExplosion.PositionX = _playerExplosion.PositionX;
                            newPlayerExplosion.PositionY = _playerExplosion.PositionY;
                            AddChild(newPlayerExplosion, _playerExplosion.ZOrder);
                            RemoveChild(_playerExplosion);
                            _playerExplosion = newPlayerExplosion;
                        }
                        _playerExplosion.TextureRectInPixels = SsCannonExplosion2.Frames.Find(item => item.TextureFilename == "General_cannon_explosion_" + Convert.ToInt32(_playerExploding).ToString().PadLeft(2, '0') + ".png").TextureRectInPixels;
                    }
                    _playerExplosion.BlendFunc = GameEnvironment.BlendFuncDefault;
                    if (_playerExploding > 40)
                    {
                        _playerExplosion.Opacity = Convert.ToByte(256 - (_playerExploding - 40) * 7);
                        _player.Visible = false;
                    }
                    /*else if (playerExploding < 30)
                    {
                        playerExplosion.Opacity = Convert.ToByte(120 + playerExploding * 4);
                    }
                    else
                    {
                        playerExplosion.Opacity = byte.MaxValue;
                    }*/
                }
                _playerExploding += 1f;
                if (_playerExploding > 30 && _gameOver && _gameOverExplosion == null)
                {
                    _gameOverExplosion = new CCSprite(SsGameOverExplosion.Frames.Find(item => item.TextureFilename == "Game-over-explosion-image-00.png"));
                    _gameOverExplosion.PositionX = 0; // player.PositionX + player.ContentSize.Width / 2;
                    _gameOverExplosion.PositionY = 0; //player.PositionY;
                    _gameOverExplosion.AnchorPoint = new CCPoint(0, 0);
                    _gameOverExplosion.Scale = 4;
                    _gameOverExploding = 0;
                    AddChild(_gameOverExplosion, 998);

                }
            }
            if (_gameOverExplosion != null)
            {
                if (Convert.ToInt32(_gameOverExploding) <= 56)
                {
                    _gameOverExplosion.TextureRectInPixels = SsGameOverExplosion.Frames.Find(item => item.TextureFilename == "Game-over-explosion-image-" + Convert.ToInt32(_gameOverExploding).ToString().PadLeft(2, '0') + ".png").TextureRectInPixels;
                    _gameOverExplosion.BlendFunc = GameEnvironment.BlendFuncDefault;
                    _gameOverExplosion.Scale = 4;
                    //playerExplosion.Scale = 4;
                    //if (gameOverExploding < 30)
                    //{
                    //    gameOverExplosion.Opacity = Convert.ToByte(120 + gameOverExploding * 4);
                    //}
                    //else
                    //{
                    //    gameOverExplosion.Opacity = byte.MaxValue;
                    //}
                    _gameOverLabel.AnchorPoint = new CCPoint(0.5f, 0.5f);
                    _gameOverLabel.ScaleX *= 1.001f;
                    _gameOverLabel.ScaleY *= 1.001f;
                }
                else
                {
                    ScheduleOnce(GameOver, 1.6f);
                    _gameOverExplosion = null;

                }
                _gameOverExploding += 0.39f;

            }

            for (var i = 0; i < _sparks.Count;)
            {
                var laserSpark = _sparks[i];

                laserSpark.Frame++;
                if (laserSpark.Frame > 40)
                {
                    laserSpark.Destroy();
                    _sparks.Remove(laserSpark);
                }
                else
                {
                    laserSpark.Sprite.TextureRectInPixels = SsLaserSparks.Frames.Find(item => item.TextureFilename == "Alien-laser-hitting-animation-without-laser-image_" + Convert.ToInt32(laserSpark.Frame).ToString().PadLeft(2, '0') + ".png").TextureRectInPixels;
                    i++;
                }
            }

            var bounce = false;

            //bool inFsRect = false;
            var fsRect = new CCRect(0, 550, 1136, 230);

            for (var i = 0; i < _enemies.Count; i++)
            {
                var enemy = _enemies[i];


                if (!enemy.Killed)
                {
                    fsRect.IntersectsRect(enemy.Sprite.BoundingBox);
                    // if (fsRect.IntersectsRect(enemy.Sprite.BoundingBox))
                    //inFsRect = true;

                    if (enemy.Sprite.PositionX - enemy.floatX > _wavePass && Math.Abs(enemy.waveAY) < AppConstants.TOLERANCE)
                    {
                        enemy.waveAY = Math.Abs(_enemySpeed) < AppConstants.TOLERANCE ? 2f / 180f : _enemySpeed / 180f;
                    }

                    if (Math.Abs(enemy.floatX + enemy.floatVX) < 12 && Math.Abs(enemy.floatY + enemy.floatVY) < 2)
                    {
                        enemy.floatX += enemy.floatVX;
                        enemy.Sprite.PositionX += enemy.floatVX;
                        enemy.floatY += enemy.floatVY;
                        //enemy.Sprite.PositionY += enemy.floatVY;
                    }
                    else
                    {
                        if (_random.Next(20) == 0)
                        {
                            enemy.floatVX = (_random.Next(100) - 50f) / 600f * (Math.Abs(_enemySpeed) < AppConstants.TOLERANCE ? 2f : _enemySpeed);
                            enemy.floatVY = (_random.Next(100) - 50f) / 1200f * (Math.Abs(_enemySpeed) < AppConstants.TOLERANCE ? 2f : _enemySpeed);
                        }
                    }
                    if (enemy.floatX > 8 && enemy.floatVX > 0)
                    {
                        enemy.floatVX = enemy.floatVX * 0.95f;
                    }
                    if (enemy.floatX < -8 && enemy.floatVX < 0)
                    {
                        enemy.floatVX = enemy.floatVX * 0.95f;
                    }
                    if (Math.Abs(enemy.waveVY) < 0.35)
                    {
                        enemy.waveVY += enemy.waveAY;
                    }
                    else
                    {
                        enemy.waveAY = -enemy.waveAY;
                        enemy.waveVY += enemy.waveAY;
                    }


                    if (_random.Next(90) == 0)
                    {
                        enemy.floatVX = (_random.Next(100) - 50f) / 600f * (Math.Abs(_enemySpeed) < AppConstants.TOLERANCE ? 2f : _enemySpeed);
                        enemy.floatVY = (_random.Next(100) - 50f) / 1200f * (Math.Abs(_enemySpeed) < AppConstants.TOLERANCE ? 2f : _enemySpeed);
                    }
                    if (_random.Next(400) == 0)
                    {
                        enemy.floatVX = (_random.Next(100) - 50f) / 240f * (Math.Abs(_enemySpeed) < AppConstants.TOLERANCE ? 2f : _enemySpeed);
                        enemy.floatVY = (_random.Next(100) - 50f) / 800f * (Math.Abs(_enemySpeed) < AppConstants.TOLERANCE ? 2f : _enemySpeed);
                    }

                    if (enemy.Spit != null)
                    {
                        enemy.Spitting += 0.5f;
                        if (Convert.ToInt32(enemy.Spitting) < 27)
                        {
                            if (SelectedEnemy == ENEMIES.ALIENS)
                            {
                                enemy.Spit.TextureRectInPixels = SsDrooling.Frames.Find(item => item.TextureFilename == "Alien_spitting" + Convert.ToInt32(enemy.Spitting).ToString().PadLeft(2, '0') + ".png").TextureRectInPixels;
                                enemy.Spit.Scale = 0.4f;
                            }
                            else
                            {
                                enemy.Spit.TextureRectInPixels = SsDrooling.Frames.Find(item => item.TextureFilename == "drooling_image_" + Convert.ToInt32(enemy.Spitting).ToString().PadLeft(2, '0') + ".png").TextureRectInPixels;
                            }
                            enemy.Spit.BlendFunc = GameEnvironment.BlendFuncDefault;
                            enemy.Spit.ZOrder = 997;
                        }
                        else
                        {
                            RemoveChild(enemy.Spit);
                            enemy.Spit = null;
                        }
                    }
                    if (enemy.AttachedBomb != null && !enemy.AttachedBomb.Spitted && enemy.AttachedBomb.Sprite.PositionY < enemy.Sprite.PositionY - 3 - enemy.Sprite.ContentSize.Height / 2)
                    {
                        if (SelectedEnemy == ENEMIES.ALIENS)
                        {
                            var r = _random.Next(3);
                            switch (r)
                            {
                                case 0:
                                    GameEnvironment.PlaySoundEffect(SOUNDEFFECT.ALIEN_SPIT);
                                    break;
                                case 1:
                                    GameEnvironment.PlaySoundEffect(SOUNDEFFECT.ALIEN_SPIT2);
                                    break;
                                default:
                                    GameEnvironment.PlaySoundEffect(SOUNDEFFECT.ALIEN_SPIT3);
                                    break;
                            }
                        }
                        else
                        {
                            var r = _random.Next(4);
                            switch (r)
                            {
                                case 0:
                                    GameEnvironment.PlaySoundEffect(SOUNDEFFECT.ENEMY_SPIT4);
                                    break;
                                case 1:
                                    GameEnvironment.PlaySoundEffect(SOUNDEFFECT.ENEMY_SPIT3);
                                    break;
                                case 2:
                                    GameEnvironment.PlaySoundEffect(SOUNDEFFECT.ENEMY_SPIT2);
                                    break;
                                default:
                                    GameEnvironment.PlaySoundEffect(SOUNDEFFECT.ENEMY_SPIT);
                                    break;
                            }
                        }
                        enemy.AttachedBomb.Spitted = true;
                    }
                    if (enemy.AttachedBomb != null && enemy.Spit == null && enemy.AttachedBomb.Sprite.PositionY < enemy.Sprite.PositionY - 24 - enemy.Sprite.ContentSize.Height / 2)
                    {

                        if (enemy.Spit == null)
                        {
                            if (SelectedEnemy == ENEMIES.ALIENS)
                            {
                                enemy.Spit = new CCSprite(SsDrooling.Frames.Find(item => item.TextureFilename == "Alien_spitting01.png"));
                                enemy.Spitting = 1;
                                enemy.Spit.Scale = 0.4f;
                            }
                            else
                            {
                                enemy.Spit = new CCSprite(SsDrooling.Frames.Find(item => item.TextureFilename == "drooling_image_00.png"));
                                enemy.Spitting = 0;
                            }
                            enemy.Spit.ZOrder = enemy.Sprite.ZOrder + 1;
                            enemy.Spit.AnchorPoint = new CCPoint(0.5f, 1f);
                            enemy.Spit.PositionX = enemy.Sprite.PositionX;
                            enemy.Spit.PositionY = enemy.Sprite.PositionY - EnemyMouthClipHeight;
                            enemy.Spit.Opacity = 200;
                            AddChild(enemy.Spit, enemy.Sprite.ZOrder + 1);
                        }
                    }
                    if (enemy.AttachedBomb != null && enemy.AttachedBomb.Sprite.PositionY < enemy.Sprite.PositionY - 52 - enemy.Sprite.ContentSize.Height / 2)
                    {
                        enemy.BombOut();
                        var r = _random.Next(3);
                        switch (r)
                        {
                            case 0:
                                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.BOMB_FALL1);
                                break;
                            case 1:
                                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.BOMB_FALL2);
                                break;
                            default:
                                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.BOMB_FALL3);
                                break;
                        }
                        enemy.AttachedBomb.Released = true;
                        enemy.AttachedBomb.SpeedY += enemy.waveVY;
                        if (_goingDown <= 0) enemy.AttachedBomb.SpeedX = _enemyCurrentSpeed;
                        enemy.AttachedBomb = null;
                    }

                    enemy.Sprite.PositionY -= _goingDownCurrentSpeed;
                    if (enemy.AttachedBomb != null) enemy.AttachedBomb.Sprite.PositionY -= _goingDownCurrentSpeed;
                    enemy.Sprite.PositionY += enemy.waveVY;
                    if (enemy.AttachedBomb != null) enemy.AttachedBomb.Sprite.PositionY += enemy.waveVY;
                    if (_goingDown <= 32)
                    {
                        enemy.Sprite.PositionX += _enemyCurrentSpeed;
                        if (enemy.AttachedBomb != null) enemy.AttachedBomb.Sprite.PositionX = enemy.Sprite.PositionX + (SelectedEnemy == ENEMIES.PUTIN ? 2 : 0);
                    }
                    if (!bounce && Math.Abs(_enemyAcceleration) < AppConstants.TOLERANCE && enemy.Sprite.PositionX < 100 && _enemyCurrentSpeed < 0)
                    {
                        bounce = true;
                    }
                    if (!bounce && Math.Abs(_enemyAcceleration) < AppConstants.TOLERANCE && enemy.Sprite.PositionX > 1136 - 100 && _enemyCurrentSpeed > 0)
                    {
                        bounce = true;
                    }

                    if (enemy.OpenMouth != null)
                    {
                        enemy.OpenMouth.PositionX = enemy.Sprite.PositionX;
                        enemy.OpenMouth.PositionY = enemy.Sprite.PositionY;
                    }
                    if (enemy.Spit != null)
                    {
                        if (enemy.Spitting < 20)
                        {
                            enemy.Spit.PositionX = enemy.Sprite.PositionX;
                        }
                        if (enemy.Spitting < 23)
                        {
                            enemy.Spit.PositionX += _enemyCurrentSpeed / 1.5f;
                        }
                        else
                        {
                            enemy.Spit.PositionX += _enemyCurrentSpeed / 2;
                        }
                        enemy.Spit.PositionY = enemy.Sprite.PositionY - EnemyMouthClipHeight;
                    }

                    if (Math.Abs(_updateTillNextBomb) < AppConstants.TOLERANCE && _random.Next(_enemies.Count + 32) == 0 && enemy.AttachedBomb == null && _playerExplosion == null && enemy.Spit == null && !enemy.Killed && _launchMode == LAUNCH_MODE.DEFAULT && !_firstGoingDown && (SelectedEnemy != ENEMIES.ALIENS || enemy.State == ENEMYSTATE.NORMAL))
                    {
                        var bomb = new Bomb(this, enemy.Sprite.PositionX + (SelectedEnemy == ENEMIES.PUTIN ? 2 : 0), enemy.Sprite.PositionY - 21);
                        _bombs.Add(bomb);
                        enemy.AttachedBomb = bomb;
                        enemy.OpenForBomb();
                        bomb.Sprite.ZOrder = enemy.Sprite.ZOrder + 1;
                        _updateTillNextBomb = _random.Next(_bombDensity);
                    }

                    if (enemy.LensFlare != null)
                    {
                        var sheet = 0;
                        if (Convert.ToInt32(enemy.LensFlareFrame) > 41) sheet = 1;

                        if (enemy.LensFlare.Texture != SsAlienLensFlare[sheet].Frames.Find(item => item.TextureFilename == "alien-laser-lens-flair-image_" + Convert.ToInt32(enemy.LensFlareFrame).ToString().PadLeft(2, '0') + ".png").Texture)
                        {
                            var newLensFlare = new CCSprite(SsAlienLensFlare[sheet].Frames.Find(item => item.TextureFilename == "alien-laser-lens-flair-image_" + Convert.ToInt32(enemy.LensFlareFrame).ToString().PadLeft(2, '0') + ".png"));
                            newLensFlare.AnchorPoint = new CCPoint(0.3445f, 0.6563f);
                            newLensFlare.PositionX = enemy.Sprite.PositionX;
                            newLensFlare.PositionY = enemy.Sprite.PositionY - 28;

                            AddChild(newLensFlare, enemy.LensFlare.ZOrder);
                            RemoveChild(enemy.LensFlare);
                            enemy.LensFlare = newLensFlare;
                        }

                        enemy.LensFlare.TextureRectInPixels = SsAlienLensFlare[sheet].Frames.Find(item => item.TextureFilename == "alien-laser-lens-flair-image_" + Convert.ToInt32(enemy.LensFlareFrame).ToString().PadLeft(2, '0') + ".png").TextureRectInPixels;

                        enemy.LensFlare.PositionX = enemy.Sprite.PositionX;
                        enemy.LensFlare.PositionY = enemy.Sprite.PositionY - 28;

                        enemy.LensFlare.BlendFunc = GameEnvironment.BlendFuncDefault;
                        enemy.LensFlareFrame += 0.41f;
                        if (Convert.ToInt32(enemy.LensFlareFrame) > 73)
                        {
                            RemoveChild(enemy.LensFlare);
                            enemy.LensFlare = null;
                        }
                    }

                    if (SelectedEnemy == ENEMIES.ALIENS)
                    {
                        var hasEnemyBelow = false;
                        var r = new CCRect(enemy.Sprite.BoundingBox.LowerLeft.X, enemy.Sprite.BoundingBox.LowerLeft.Y - 1300, enemy.Sprite.ContentSize.Width, 1300);

                        foreach (var x in _enemies)
                        {
                            if (x != enemy && r.IntersectsRect(x.Sprite.BoundingBox))
                            {
                                hasEnemyBelow = true;
                                break;
                            }
                        }
                        if (_playerExplosion != null && _playerExploding > 40 && (enemy.State == ENEMYSTATE.GRIMACE1 || enemy.State == ENEMYSTATE.GRIMACE2))
                        {
                            if (enemy.LaserFxId1 != null) CCAudioEngine.SharedEngine.StopEffect(enemy.LaserFxId1.Value);
                            if (enemy.LaserFxId2 != null) CCAudioEngine.SharedEngine.StopEffect(enemy.LaserFxId2.Value);
                            if (enemy.LaserFxId3 != null) CCAudioEngine.SharedEngine.StopEffect(enemy.LaserFxId3.Value);

                            if (enemy.LensFlare != null) RemoveChild(enemy.LensFlare);
                            enemy.LensFlare = null;
                            enemy.State = ENEMYSTATE.NORMAL;
                            enemy.Sprite.Texture = new CCTexture2D(GameEnvironment.ImageDirectory + EnemyMouthClosed);
                            enemy.Sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
                            if (enemy.LaserTop != null) enemy.LaserTop.Visible = false;
                            enemy.keepGrimace = 1.5f + _random.Next(5);
                        }
                        if (enemy.OpenMouth == null && _random.Next(800) == 0 && enemy.State == ENEMYSTATE.NORMAL && enemy.keepGrimace <= 0 && !_firstGoingDown && !hasEnemyBelow && _playerExplosion == null)
                        {
                            if (_random.Next(2) == 0)
                            {
                                enemy.State = ENEMYSTATE.GRIMACE1;
                                enemy.Sprite.Texture = new CCTexture2D(GameEnvironment.ImageDirectory + EnemyGrimace1);
                                enemy.keepGrimace = 3f;
                            }
                            else
                            {
                                enemy.State = ENEMYSTATE.GRIMACE2;
                                enemy.Sprite.Texture = new CCTexture2D(GameEnvironment.ImageDirectory + EnemyGrimace2);
                                enemy.keepGrimace = 3f;
                            }
                            enemy.Sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
                            enemy.LaserFxId1 = GameEnvironment.PlaySoundEffect(SOUNDEFFECT.ALIEN_LASER);
                            //enemy.LaserFxId2 = GameEnvironment.PlaySoundEffect(SOUNDEFFECT.ALIEN_LASER);
                            //enemy.LaserFxId3 = GameEnvironment.PlaySoundEffect(SOUNDEFFECT.ALIEN_LASER);

                            enemy.LensFlare = new CCSprite(SsAlienLensFlare[0].Frames.Find(item => item.TextureFilename == "alien-laser-lens-flair-image_00.png"));
                            enemy.LensFlare.AnchorPoint = new CCPoint(0.3445f, 0.6563f);
                            enemy.LensFlare.PositionX = enemy.Sprite.PositionX;
                            enemy.LensFlare.PositionY = enemy.Sprite.PositionY - 28;
                            AddChild(enemy.LensFlare, 24);
                            enemy.LensFlareFrame = 0;
                        }

                    }
                    else
                    {

                        if (enemy.OpenMouth == null && _random.Next(200) == 0 && enemy.State == ENEMYSTATE.NORMAL && enemy.keepGrimace <= 0)
                        {
                            if (_random.Next(2) == 0)
                            {
                                enemy.State = ENEMYSTATE.GRIMACE1;
                                enemy.Sprite.Texture = new CCTexture2D(GameEnvironment.ImageDirectory + EnemyGrimace1);
                            }
                            else
                            {
                                enemy.State = ENEMYSTATE.GRIMACE2;
                                enemy.Sprite.Texture = new CCTexture2D(GameEnvironment.ImageDirectory + EnemyGrimace2);
                            }
                            enemy.Sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
                            enemy.keepGrimace = 0.5f + _random.Next(5);
                        }
                    }
                    /*
                    if (enemy.LaserLeftSpark != null)
                    {
                        enemy.LaserLeftSparkFrame++;
                        if (enemy.LaserLeftSparkFrame > 40)
                        {
                            this.RemoveChild(enemy.LaserLeftSpark);
                            enemy.LaserLeftSpark = null;
                        }
                        else
                        {
                            enemy.LaserLeftSpark.TextureRectInPixels = ssLaserSparks.Frames.Find(item => item.TextureFilename == "Alien-laser-hitting-animation-without-laser-image_" + Convert.ToInt32(enemy.LaserLeftSparkFrame).ToString().PadLeft(2, '0') + ".png").TextureRectInPixels;  
                        }
                    }

                    if (enemy.LaserRightSpark != null)
                    {
                        enemy.LaserRightSparkFrame++;
                        if (enemy.LaserRightSparkFrame > 40)
                        {
                            this.RemoveChild(enemy.LaserRightSpark);
                            enemy.LaserRightSpark = null;
                        }
                        else
                        {
                            enemy.LaserRightSpark.TextureRectInPixels = ssLaserSparks.Frames.Find(item => item.TextureFilename == "Alien-laser-hitting-animation-without-laser-image_" + Convert.ToInt32(enemy.LaserRightSparkFrame).ToString().PadLeft(2, '0') + ".png").TextureRectInPixels;
                        }
                    }*/

                    if (enemy.LaserLeftSparkCooloff > 0) enemy.LaserLeftSparkCooloff--;
                    if (enemy.LaserRightSparkCooloff > 0) enemy.LaserRightSparkCooloff--;

                    var laserRemoved = false;
                    for (var j = 0; j < enemy.Lasers.Count;)
                    {
                        var laser = enemy.Lasers[j];
                        laser.y += laser.Sprite.ContentSize.Height;
                        if (laser.Left)
                        {
                            laser.Sprite.PositionX = enemy.Sprite.PositionX - 8.5f;
                        }
                        else
                        {
                            laser.Sprite.PositionX = enemy.Sprite.PositionX + 8.5f;
                        }
                        laser.Sprite.PositionY = enemy.Sprite.PositionY - laser.y - laser.Sprite.ContentSize.Height - 35;

                        if (laser.y > 1300 || laser.LaserHit)
                        {
                            laser.Destroy();
                            enemy.Lasers.RemoveAt(j);
                            laserRemoved = true;
                        }
                        else
                        {
                            if (_playerExplosion == null || _playerExploding < 25)
                            {
                                var r = new CCRect(laser.Sprite.PositionX - 5, laser.Sprite.PositionY, 10, laser.Sprite.ContentSize.Height);
                                var y = InRectangleTopY(r, PlayerCollisionPoints, _player.PositionX, _player.PositionY + _player.ContentSize.Height);
                                if (Math.Abs(y - (-1)) > AppConstants.TOLERANCE)
                                {
                                    laser.LaserHit = true;
                                    laser.Sprite.ScaleY = 1 - ((y - laser.Sprite.PositionY) / laser.Sprite.ContentSize.Height);
                                    laser.Sprite.PositionY = y;
                                    if (_playerExplosion == null)
                                    {
                                        PlayerExplode();
                                    }


                                    if (laser.Left && enemy.LaserLeftSparkCooloff <= 0)
                                    {
                                        _sparks.Add(new LaserSpark(this, laser.Sprite.PositionX, y));
                                        enemy.LaserLeftSparkCooloff = 8;
                                    }
                                    if (!laser.Left && enemy.LaserRightSparkCooloff <= 0)
                                    {
                                        _sparks.Add(new LaserSpark(this, laser.Sprite.PositionX, y));
                                        enemy.LaserRightSparkCooloff = 8;
                                    }

                                    /*
                                    if (laser.Left)
                                    {
                                        
                                        if (enemy.LaserLeftSpark == null)
                                        {
                                            enemy.LaserLeftSpark = new CCSprite(ssLaserSparks.Frames.Find(item => item.TextureFilename == "Alien-laser-hitting-animation-without-laser-image_00.png"));
                                            enemy.LaserLeftSpark.AnchorPoint = new CCPoint(0.5f, 0.3f);
                                            enemy.LaserLeftSpark.BlendFunc = GameEnvironment.BlendFuncDefault;
                                            enemy.LaserLeftSparkFrame = 0;
                                            this.AddChild(enemy.LaserLeftSpark, 100);
                                        }
                                        enemy.LaserLeftSpark.Position = new CCPoint(laser.Sprite.PositionX, y);
                                    }
                                    else if (!laser.Left)
                                    {
                                        if (enemy.LaserRightSpark == null)
                                        {
                                            enemy.LaserRightSpark = new CCSprite(ssLaserSparks.Frames.Find(item => item.TextureFilename == "Alien-laser-hitting-animation-without-laser-image_00.png"));
                                            enemy.LaserRightSpark.AnchorPoint = new CCPoint(0.5f, 0.3f);
                                            enemy.LaserRightSpark.BlendFunc = GameEnvironment.BlendFuncDefault;
                                            enemy.LaserRightSparkFrame = 0;
                                            this.AddChild(enemy.LaserRightSpark, 100);
                                        }
                                        enemy.LaserRightSpark.Position = new CCPoint(laser.Sprite.PositionX, y);
                                    }
                                    */
                                }
                            }
                        }

                        if (!laserRemoved)
                        {
                            j++;
                        }
                        laserRemoved = false;
                    }

                    if (enemy.keepGrimace > 0)
                    {
                        enemy.keepGrimace -= dt;
                        if ((enemy.State == ENEMYSTATE.GRIMACE1 || enemy.State == ENEMYSTATE.GRIMACE2) && enemy.OpenMouth == null && enemy.keepGrimace <= 0)
                        {
                            enemy.State = ENEMYSTATE.NORMAL;
                            enemy.Sprite.Texture = new CCTexture2D(GameEnvironment.ImageDirectory + EnemyMouthClosed);
                            enemy.Sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
                            if (enemy.LaserTop != null) enemy.LaserTop.Visible = false;
                            enemy.keepGrimace = 0.5f + _random.Next(5);
                        }
                        else
                        {
                            if (SelectedEnemy == ENEMIES.ALIENS && (enemy.State == ENEMYSTATE.GRIMACE1 || enemy.State == ENEMYSTATE.GRIMACE2) && enemy.keepGrimace < 2f)
                            {
                                if (enemy.LaserTop == null)
                                {
                                    enemy.LaserTop = new CCSprite(GameEnvironment.ImageDirectory + "Enemies/Laser-image_02_top.png");
                                    enemy.LaserTop.Position = new CCPoint(enemy.Sprite.PositionX, enemy.Sprite.PositionY);
                                    enemy.LaserTop.AnchorPoint = new CCPoint(0.5f, 0.0f);
                                    enemy.LaserTop.BlendFunc = GameEnvironment.BlendFuncDefault;
                                    AddChild(enemy.LaserTop, 11);
                                }
                                else if (enemy.LaserTop.Visible == false)
                                {
                                    enemy.LaserTop.Visible = true;
                                }
                                enemy.LaserTop.PositionX = enemy.Sprite.PositionX;
                                enemy.LaserTop.PositionY = enemy.Sprite.PositionY - 35;
                                var laser = new Laser(this, true);
                                laser.Sprite.PositionX = enemy.Sprite.PositionX - 8.5f;
                                laser.Sprite.PositionY = enemy.Sprite.PositionY - laser.y - laser.Sprite.ContentSize.Height - 35;
                                enemy.Lasers.Add(laser);
                                laser = new Laser(this, false);
                                laser.Sprite.PositionX = enemy.Sprite.PositionX + 8.5f;
                                laser.Sprite.PositionY = enemy.Sprite.PositionY - laser.y - laser.Sprite.ContentSize.Height - 35;
                                enemy.Lasers.Add(laser);
                            }
                        }

                    }
                }
                else
                {
                    if (enemy.LaserTop != null)
                    {
                        RemoveChild(enemy.LaserTop);
                        enemy.LaserTop = null;
                    }
                    var laserRemoved = false;
                    for (var j = 0; j < enemy.Lasers.Count;)
                    {
                        var laser = enemy.Lasers[j];
                        laser.y += laser.Sprite.ContentSize.Height;
                        if (laser.Left)
                        {
                            laser.Sprite.PositionX = enemy.Sprite.PositionX - 8.5f;
                        }
                        else
                        {
                            laser.Sprite.PositionX = enemy.Sprite.PositionX + 8.5f;
                        }
                        laser.Sprite.PositionY = enemy.Sprite.PositionY - laser.y - laser.Sprite.ContentSize.Height - 35;

                        if (laser.y > 1300 || laser.LaserHit)
                        {
                            laser.Destroy();
                            enemy.Lasers.RemoveAt(j);
                            laserRemoved = true;
                        }
                        else
                        {
                            if (_playerExplosion == null || _playerExploding < 25)
                            {
                                var r = new CCRect(laser.Sprite.PositionX - 5, laser.Sprite.PositionY, 10, laser.Sprite.ContentSize.Height);
                                var y = InRectangleTopY(r, PlayerCollisionPoints, _player.PositionX, _player.PositionY + _player.ContentSize.Height);
                                if (Math.Abs(y - (-1)) > AppConstants.TOLERANCE)
                                {
                                    laser.LaserHit = true;
                                    laser.Sprite.ScaleY = 1 - ((y - laser.Sprite.PositionY) / laser.Sprite.ContentSize.Height);
                                    laser.Sprite.PositionY = y;
                                    if (_playerExplosion == null)
                                    {
                                        PlayerExplode();
                                    }

                                    if (laser.Left && enemy.LaserLeftSparkCooloff <= 0)
                                    {
                                        _sparks.Add(new LaserSpark(this, laser.Sprite.PositionX, y));
                                        enemy.LaserLeftSparkCooloff = 8;
                                    }
                                    if (!laser.Left && enemy.LaserRightSparkCooloff <= 0)
                                    {
                                        _sparks.Add(new LaserSpark(this, laser.Sprite.PositionX, y));
                                        enemy.LaserRightSparkCooloff = 8;
                                    }

                                    /*
                                    if (laser.Left)
                                    {
                                        if (enemy.LaserLeftSpark == null)
                                        {
                                            enemy.LaserLeftSpark = new CCSprite(ssLaserSparks.Frames.Find(item => item.TextureFilename == "Alien-laser-hitting-animation-without-laser-image_00.png"));
                                            enemy.LaserLeftSpark.AnchorPoint = new CCPoint(0.5f, 0.3f);
                                            enemy.LaserLeftSpark.BlendFunc = GameEnvironment.BlendFuncDefault;
                                            enemy.LaserLeftSparkFrame = 0;
                                            this.AddChild(enemy.LaserLeftSpark, 100);
                                        }
                                        enemy.LaserLeftSpark.Position = new CCPoint(laser.Sprite.PositionX, y);
                                    }
                                    else if (!laser.Left)
                                    {
                                        if (enemy.LaserRightSpark == null)
                                        {
                                            enemy.LaserRightSpark = new CCSprite(ssLaserSparks.Frames.Find(item => item.TextureFilename == "Alien-laser-hitting-animation-without-laser-image_00.png"));
                                            enemy.LaserRightSpark.AnchorPoint = new CCPoint(0.5f, 0.3f);
                                            enemy.LaserRightSpark.BlendFunc = GameEnvironment.BlendFuncDefault;
                                            enemy.LaserRightSparkFrame = 0;
                                            this.AddChild(enemy.LaserRightSpark, 100);
                                        }
                                        enemy.LaserRightSpark.Position = new CCPoint(laser.Sprite.PositionX, y);
                                    }
                                    */
                                }

                            }
                        }

                        if (!laserRemoved)
                        {
                            j++;
                        }
                        laserRemoved = false;
                    }


                    enemy.Sprite.PositionX += enemy.SpeedX;
                    enemy.Explosion.PositionX += enemy.SpeedX;
                    if (enemy.Exploding < 29)
                    {
                        enemy.Explosion.TextureRectInPixels = SsEnemyExplosion.Frames.Find(item => item.TextureFilename == "General_enemy_explosion" + Convert.ToInt32(enemy.Exploding).ToString().PadLeft(2, '0') + ".png").TextureRectInPixels;
                        enemy.Explosion.BlendFunc = GameEnvironment.BlendFuncDefault;
                        enemy.Exploding += 0.5f;
                        if (enemy.Exploding > 8)
                        {
                            enemy.Sprite.Visible = false;
                            enemy.Explosion.Opacity = Convert.ToByte(280 - Convert.ToInt32(enemy.Exploding * 7));
                        }
                    }
                    else
                    {
                        enemy.Destroy();
                        _enemies.Remove(enemy);
                        i--;

                    }
                }

                if (_playerExplosion == null && !enemy.Killed && enemy.Sprite != null && InRectangle(enemy.Sprite.BoundingBox, PlayerCollisionPoints, _player.PositionX, _player.PositionY + _player.ContentSize.Height))
                {
                    PlayerExplode(true);
                }
                if (_playerExplosion == null && enemy.Sprite != null && enemy.Sprite.PositionY < 80)
                {
                    PlayerExplode(true);
                }
            }
            if (_goingDown > 0)
            {
                if (_goingDownCurrentSpeed < _goingDownSpeed) _goingDownCurrentSpeed += _goingDownSpeed / 30f;
            }
            _goingDown -= _goingDownCurrentSpeed;
            if (_goingDown <= 0 && _goingDownCurrentSpeed > 0)
            {
                _goingDownCurrentSpeed -= _goingDownSpeed / 20f;
                if (_goingDownCurrentSpeed <= 0)
                {
                    _goingDownCurrentSpeed = 0;
                    if (_firstGoingDown)
                    {
                        _enemyAcceleration = _enemySpeed / 30f;
                        _firstGoingDown = false;
                        if (VoiceGameOver != "" && SelectedEnemy == ENEMIES.TRUMP) CCAudioEngine.SharedEngine.PlayEffect(VoiceGameOver);
                    }
                }
            }


            if (_flyingSaucer != null)
            {
                _flyingSaucerFrame += 0.5f;
                if (Convert.ToInt32(_flyingSaucerFrame) > 59) _flyingSaucerFrame = 0;
                _flyingSaucer.TextureRectInPixels = SsFlyingSaucer.Frames.Find(item => item.TextureFilename == "Flying-saucer-image_" + Convert.ToInt32(_flyingSaucerFrame).ToString().PadLeft(2, '0') + ".png").TextureRectInPixels;
                _flyingSaucer.BlendFunc = GameEnvironment.BlendFuncDefault;
                _flyingSaucer.PositionX += _flyingSaucerSpeed;
                if ((_flyingSaucer.PositionX > 1136 && _flyingSaucerSpeed > 0) || (_flyingSaucer.PositionX < -126 && _flyingSaucerSpeed < 0))
                {
                    CCAudioEngine.SharedEngine.StopEffect(_flyingSaucerFlyingFxId.Value);
                    RemoveChild(_flyingSaucer);
                    _flyingSaucerWait = 60;
                    _flyingSaucer = null;
                }
            }
            if (/*!inFsRect &&*/ _flyingSaucerWait <= 0 && _flyingSaucerIncoming <= 0 && _flyingSaucer == null && _random.Next(300 + (_lives.Count * 200)) == 1 && _playerExplosion == null && _flyingSaucerExplosion == null && SelectedEnemy == ENEMIES.ALIENS && _lives.Count < 4 && _enemies.Count >= 16 && _wave > 2)
            {
                _flyingSaucerIncoming = 2;
                _flyingSaucerFlyingFxId = GameEnvironment.PlaySoundEffect(SOUNDEFFECT.FLYINGSAUCER_INCOMING);
            }
            else if (_flyingSaucerWait > 0)
            {
                _flyingSaucerWait -= dt;
            }

            if (_flyingSaucerIncoming > 0 && _playerExplosion == null)
            {
                _flyingSaucerIncoming -= dt;
                if (_flyingSaucerIncoming <= 0)
                {
                    CCAudioEngine.SharedEngine.StopEffect(_flyingSaucerFlyingFxId.Value);
                    _flyingSaucerFlyingFxId = GameEnvironment.PlaySoundEffect(SOUNDEFFECT.FLYINGSAUCER_FLYING);
                    _flyingSaucerFrame = 0;
                    _flyingSaucer = new CCSprite(SsFlyingSaucer.Frames.Find(item => item.TextureFilename == "Flying-saucer-image_00.png"));
                    if (_random.Next(2) == 0)
                    {
                        _flyingSaucer.Position = new CCPoint(1210, 560);
                        _flyingSaucerSpeed = -5;
                    }
                    else
                    {
                        _flyingSaucer.Position = new CCPoint(-200, 560);
                        _flyingSaucerSpeed = 5;
                    }
                    _flyingSaucer.BlendFunc = GameEnvironment.BlendFuncDefault;
                    AddChild(_flyingSaucer);
                }
            }


            if (_flyingSaucerExplosion != null)
            {
                _flyingSaucerExplosionFrame += 0.5f;

                _flyingSaucerExplosion.PositionX += _flyingSaucerSpeed;

                if (_flyingSaucerExplosionFrame > 8)
                {
                    _flyingSaucerExplosion.Opacity = Convert.ToByte(280 - Convert.ToInt32(_flyingSaucerExplosionFrame * 7));
                }

                if (_flyingSaucer != null) { _flyingSaucer.Opacity -= 10; }

                if (Convert.ToInt32(_flyingSaucerExplosionFrame) > 8 && _flyingSaucer != null)
                {
                    RemoveChild(_flyingSaucer);
                    _flyingSaucer = null;
                }

                if (Convert.ToInt32(_flyingSaucerExplosionFrame) > 29)
                {
                    RemoveChild(_flyingSaucerExplosion);
                    _flyingSaucerExplosion = null;
                }
                else
                {
                    _flyingSaucerExplosion.TextureRectInPixels = SsEnemyExplosion.Frames.Find(item => item.TextureFilename == "General_enemy_explosion" + Convert.ToInt32(_flyingSaucerExplosionFrame).ToString().PadLeft(2, '0') + ".png").TextureRectInPixels;
                    _flyingSaucerExplosion.BlendFunc = GameEnvironment.BlendFuncDefault;
                }
            }

            if (bounce)
            {
                _enemyAcceleration = -_enemyCurrentSpeed / 30f;
                _bounces++;
                if (_bounces > 4)
                {
                    _goingDown = 32;
                    _bounces = 0;
                }
            }
            _enemyCurrentSpeed += _enemyAcceleration;
            if (_enemyCurrentSpeed < -_enemySpeed)
            {
                _enemyAcceleration = 0;
                _enemyCurrentSpeed = -_enemySpeed;
            }
            if (_enemyCurrentSpeed > _enemySpeed)
            {
                _enemyAcceleration = 0;
                _enemyCurrentSpeed = _enemySpeed;
            }

            if (_updateTillNextBomb > 0) _updateTillNextBomb--;


            if (_enemies.Count == 0 && _bombs.Count == 0 && _playerExplosion == null && !_waveTransfer)
            {
                _waveTransfer = true;
                if (SelectedEnemy == ENEMIES.ALIENS)
                {
                    GameEnvironment.PlayMusic(MUSIC.NEXTWAVEALIEN);
                    if (Settings.Instance.VoiceoversEnabled)
                    {
                        CCAudioEngine.SharedEngine.PlayEffect("Sounds/get ready for next wave VO_mono.wav");
                    }
                    _nextWaveSprite = AddImageCentered(1136 / 2 - 50, 630 / 2, "UI/get-ready-for-next-wave-alien-text.png", 100);
                    _nextWaveNumberSprites = AddImageLabel(Convert.ToInt32(_nextWaveSprite.PositionX + _nextWaveSprite.ContentSize.Width / 2), Convert.ToInt32(_nextWaveSprite.PositionY - _nextWaveSprite.ContentSize.Height / 2), (_wave + 1).ToString(), 99);
                    ScheduleOnce(NextWave, 3);
                }
                else
                {
                    switch (_wave)
                    {
                        case 1:
                            GameEnvironment.PlayMusic(MUSIC.NEXTWAVE);
                            _nextWaveSprite = AddImageCentered(1136 / 2, 630 / 2, "UI/get-ready-for-next-wave-text.png", 100);
                            if (Settings.Instance.VoiceoversEnabled)
                            {
                                CCAudioEngine.SharedEngine.PlayEffect("Sounds/get ready for next wave VO_mono.wav");
                            }


                            if (SelectedBattleground == BATTLEGROUNDS.FINLAND)
                            {
                                _fireworkFrame = 1f;
                                ScheduleOnce(NextWave, 4.5f);
                            }
                            else
                            {
                                ScheduleOnce(NextWave, 3);
                            }
                            break;
                        case 2:

                            GameEnvironment.PlayMusic(MUSIC.NEXTWAVE);
                            _nextWaveSprite = AddImageCentered(1136 / 2, 630 / 2, "UI/get-ready-for-final-wave-text.png", 100);
                            if (Settings.Instance.VoiceoversEnabled)
                            {
                                CCAudioEngine.SharedEngine.PlayEffect("Sounds/get ready for final wave VO_mono.wav");
                            }
                            if (SelectedBattleground == BATTLEGROUNDS.FINLAND)
                            {
                                _fireworkFrame = 1f;
                                ScheduleOnce(NextWave, 4.5f);
                            }
                            else
                            {
                                ScheduleOnce(NextWave, 3);
                            }
                            break;
                        case 3:
                            if (_launchMode == LAUNCH_MODE.DEFAULT)
                            {
                                if (Settings.Instance.VoiceoversEnabled)
                                {
                                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Victory VO_mono.wav");
                                }
                                AddImageCentered(1136 / 2, 630 / 2, "UI/Battle-screen-victory!!!-text.png", 100);
                            }
                            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.TEXTAPPEARS);
                            //this.UnscheduleAll();
                            if (SelectedBattleground == BATTLEGROUNDS.FINLAND)
                            {
                                _fireworkFrame = 1f;
                                ScheduleOnce(Victory, 4.5f);
                            }
                            if (SelectedBattleground == BATTLEGROUNDS.WHITE_HOUSE)
                            {
                                ScheduleOnce(Victory, 0.5f);
                            }
                            else
                            {
                                ScheduleOnce(Victory, 1);
                            }
                            break;
                    }
                }
            }

            if (_wavePass > 0)
            {
                _wavePass -= Math.Abs(_enemySpeed) < AppConstants.TOLERANCE ? 4 : _enemySpeed * 3;
            }


            if (_nextWaveSprite != null)
            {
                if (_nextWaveSprite.Opacity < 10)
                {
                    _nextWaveSprite.Opacity = 255;
                }
                else if (_nextWaveSprite.Opacity > 240)
                {
                    _nextWaveSprite.Opacity -= 1;
                }
                else if (_nextWaveSprite.Opacity > 225)
                {
                    _nextWaveSprite.Opacity -= 2;
                }
                else if (_nextWaveSprite.Opacity > 200)
                {
                    _nextWaveSprite.Opacity -= 3;
                }
                else
                {
                    _nextWaveSprite.Opacity -= 5;
                }
                if (_timeLabel.Visible)
                {
                    _timeLabel.Opacity = _nextWaveSprite.Opacity;
                    foreach (var timeDigit in _time)
                    {
                        timeDigit.Opacity = _nextWaveSprite.Opacity;
                    }
                }
                if (_nextWaveNumberSprites != null)
                {
                    foreach (var waveDigit in _nextWaveNumberSprites)
                    {
                        waveDigit.Opacity = _nextWaveSprite.Opacity;
                    }
                }
                if (_multiplierLabel != null)
                {
                    _multiplierLabel.Opacity = _nextWaveSprite.Opacity;
                }
                if (_multiplierLabelLabel != null && _scoreMultiplier > 1)
                {
                    _multiplierLabelLabel.Opacity = _nextWaveSprite.Opacity;
                }
            }
        }

        void MoveCannon(float touchXPosition)
        {
            var movementButtonBoundingBox = _btnMovement.BoundingBoxTransformedToWorld;

            //int sensitivity = Settings.Instance.SensitivityLevel;

            var forward = touchXPosition >= movementButtonBoundingBox.Center.X;

            //float centerX = movementButtonBoundingBox.Center.X;
            var maxSensitivityLavel = 8;

            float btnSensitivity = GetSensitivityLvlOnPressedBtn(touchXPosition);

            if (Math.Round(btnSensitivity / 10) <= Settings.Instance.SensitivityLevel)
            {
                _speedTo = 1;
            }
            else if (Math.Round(btnSensitivity / 10) > 8)
            {
                _speedTo = 0;
            }
            else
            {
                _speedTo = (float)Math.Round((maxSensitivityLavel + 1 - btnSensitivity / 10f) / (maxSensitivityLavel - Settings.Instance.SensitivityLevel + 1), 2);
            }

            if (forward)
            {
                _speedTo *= -1;
            }
        }

        void OnTouchesBegan(List<CCTouch> touches, CCEvent touchEvent)
        {


            var movementButtonBoundingBox = _btnMovement.BoundingBoxTransformedToWorld;
            var fireButtonBoundingBox = _btnFire.BoundingBoxTransformedToWorld;

            foreach (var touch in touches)
            {
                if (RectangleWithin(movementButtonBoundingBox, touch.Location))
                {
                    _isCannonMoving = true;

                    //--------- Prabhjot ----------//
                    //int steerinButtonX = 3;
                    //int steeringButtonY = 2;
                    //btnMovement = AddButton(steerinButtonX, steeringButtonY, "UI/Controls/Steering arrow/080-transparent-movement-arrow-tapped.png", "UI/Controls/Steering arrow/040-transparent-movement-arrow-untapped.png", 200, BUTTON_TYPE.Silent);

                    MoveCannon(touch.Location.X);
                }
                else if (RectangleWithin(fireButtonBoundingBox, touch.Location))
                {
                    _isCannonShooting = true;
                }
                else if (_isCannonMoving && RectangleNear(movementButtonBoundingBox, touch.Location, 0, 60))
                {
                    _isCannonMoving = true;
                    MoveCannon(touch.Location.X);
                }
                else if (_isCannonMoving && RectangleNear(new CCRect(movementButtonBoundingBox.MinX, movementButtonBoundingBox.MinY - 60, movementButtonBoundingBox.MaxX - movementButtonBoundingBox.MinX, movementButtonBoundingBox.MaxY - movementButtonBoundingBox.MinY + 60), touch.Location, 65, 65))
                {
                    _isCannonMoving = false;
                    _speedTo = 0;
                    EndTouchOnBtn(_btnMovement);
                }
                else if (_isCannonShooting && RectangleNear(fireButtonBoundingBox, touch.Location, 50, 50))
                {
                    _isCannonShooting = false;
                    EndTouchOnBtn(_btnFire);
                }
            }
        }

        int GetSensitivityLvlOnPressedBtn(float touchPosition)
        {
            var movementButtonBoundingBox = _btnMovement.BoundingBoxTransformedToWorld;
            //var halfOfBtn = movementButtonBoundingBox.MaxX - movementButtonBoundingBox.Center.X;
            int sensBtnLvl;

            if (touchPosition < movementButtonBoundingBox.Center.X)
            {
                if (Settings.Instance.RightHanded)
                {
                    //btn mov al left side, click at left side
                    sensBtnLvl = GetPrestMovingBtnSensitivity(touchPosition - (int)movementButtonBoundingBox.MinX);
                }
                else
                {
                    //btn mov at right side, click ar left side
                    sensBtnLvl = GetPrestMovingBtnSensitivity(touchPosition - movementButtonBoundingBox.MinX);
                }
            }
            else
            {
                if (Settings.Instance.RightHanded)
                {
                    //btn mov al left side, click at right side
                    sensBtnLvl = 201 - GetPrestMovingBtnSensitivity(touchPosition);
                }
                else
                {
                    //btn mov at right side, click ar right side
                    sensBtnLvl = 101 - GetPrestMovingBtnSensitivity(touchPosition - (int)movementButtonBoundingBox.Center.X);
                }
            }

            return sensBtnLvl;
        }

        int GetPrestMovingBtnSensitivity(float touchPositionOnBtn)
        {
            var movementButtonBoundingBox = _btnMovement.BoundingBoxTransformedToWorld;
            var halfOfBtn = movementButtonBoundingBox.MaxX - movementButtonBoundingBox.Center.X;
            var btnSensStep = halfOfBtn / 100;

            return (int)Math.Ceiling(touchPositionOnBtn / btnSensStep);

        }


        void OnTouchesEnded(List<CCTouch> touches, CCEvent touchEvent)
        {

            if (_btnMovement.BoundingBoxTransformedToWorld.ContainsPoint(touches[0].Location))
            {
                _isCannonMoving = false;
                _speedTo = 0;
            }

            if (_btnFire.BoundingBoxTransformedToWorld.ContainsPoint(touches[0].Location))
            {
                _isCannonShooting = false;
            }
        }

        bool RectangleWithin(CCRect rectangle, CCPoint point)
        {
            return point.X >= rectangle.MinX && point.X <= rectangle.MaxX && point.Y <= rectangle.MaxY && point.Y >= rectangle.MinY;
        }

        bool RectangleNear(CCRect rectangle, CCPoint point, int marginX, int marginY)
        {
            return point.X >= (rectangle.MinX - marginX) && point.X <= (rectangle.MaxX + marginX) && point.Y <= (rectangle.MaxY + marginY) && point.Y >= (rectangle.MinY + marginY);
        }

        public void SetUpSteering(bool animatedControls = false)
        {
            RemoveChild(_btnFire);
            RemoveChild(_btnMovement);
            OnTouchBegan -= GamePlayLayer_OnTouchBegan;

            //var touchListener = new CCEventListenerTouchAllAtOnce();
            if (_touchListener == null)
                return;

            _touchListener.OnTouchesBegan -= OnTouchesBegan;
            _touchListener.OnTouchesEnded -= OnTouchesEnded;
            _touchListener.OnTouchesMoved -= OnTouchesBegan;
            _touchListener.OnTouchesBegan -= GamePlayLayer_OnTouchesBegan;
            _touchListener.OnTouchesBegan -= GamePlayLayer_TouchResponse;

            _speedTo = 0;

            if (Settings.Instance.ControlType == CONTROL_TYPE.MANUAL)
            {
                var fireButtonX = 918;
                var fireButtonY = 2;

                var steerinButtonX = 3;
                var steeringButtonY = 2;

                if (!Settings.Instance.RightHanded)
                {
                    fireButtonX = 3;
                    steerinButtonX = 715;
                }

                _btnMovement = AddButton(steerinButtonX, steeringButtonY,
                    "UI/Controls/Steering arrow/080-transparent-movement-arrow-untapped.png",
                    "UI/Controls/Steering arrow/040-transparent-movement-arrow-tapped.png", 200,
                    BUTTON_TYPE.Silent);

                _touchListener.OnTouchesBegan += OnTouchesBegan;
                _touchListener.OnTouchesBegan += GamePlayLayer_TouchResponse;
                _touchListener.OnTouchesEnded += OnTouchesEnded;
                _touchListener.OnTouchesMoved += OnTouchesBegan;

                _btnFire = AddButton(fireButtonX, fireButtonY,
                    "UI/Controls/Fire button/080-transparent-fire-button-untapped.png",
                    "UI/Controls/Fire button/040-transparent-fire-button-tapped.png", 200, BUTTON_TYPE.Silent);

                _btnFire.Visible = false;
                _btnMovement.Visible = false;

                if (animatedControls)
                {
                    _fadeLevel = 0;
                    Schedule(AnimateButtons, 0.16f);
                }
                else
                {
                    _btnFire.Visible = true;
                    _btnMovement.Visible = true;
                }
            }
            else
            {
                if (_launchMode == LAUNCH_MODE.STEERING_TEST)
                {
                    _touchListener.OnTouchesBegan += GamePlayLayer_OnTouchesBegan;
                }
                else
                {
                    OnTouchBegan += GamePlayLayer_OnTouchBegan;
                }
            }

            AddEventListener(_touchListener, this);
        }
    }
}
