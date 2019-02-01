using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;
using LooneyInvaders.Model;
using LooneyInvaders.Classes;
using LooneyInvaders.Shared;
using LooneyInvaders.PNS;
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

        public int kills = 0;
        public float controlMovement = 0;
        private float speedTo;
        private float movingTime;

        public float tiltAngle = 0;

        List<Bullet> bullets = new List<Bullet>();
        List<Enemy> enemies = new List<Enemy>();
        List<Bomb> bombs = new List<Bomb>();
        List<CCSprite> ammos = new List<CCSprite>();
        List<Explosion> explos = new List<Explosion>();
        List<CCSprite> lives = new List<CCSprite>();
        List<GunSmoke> gunSmokes = new List<GunSmoke>();
        List<CCSprite> multipliers = new List<CCSprite>();
        List<LaserSpark> sparks = new List<LaserSpark>();


        //bool Test = false;
        //bool IsTestFromWeaponPicker = false;
        LAUNCH_MODE launchMode;

        float enemySpeed = 2;
        float enemyCurrentSpeed;
        float enemyAcceleration = 0;
        int bounces = 0;
        float goingDown = 0;
        float goingDownSpeed = 1;
        float goingDownCurrentSpeed = 1;
        bool firstGoingDown = true;
        float reload = 0;
        float reloadTime = 1;
        CCSprite reloading;
        float playerSpeed = 30;
        float bulletScale = 1;
        float bulletPower;
        int magazineSize;
        float gunCooloff;
        float gunCoolness;
        int bombDensity = 80;
        float smokeOffsetY = -40;


        CCSprite player;
        CCSprite playerExplosion;
        CCSprite gameOverExplosion;
        CCSprite[] time;
        CCSprite timeLabel;
        CCSprite multiplierLabel;
        CCSprite multiplierLabelLabel;
        CCSprite gameOverLabel;
        int lastDisplayedTime = 0;
        int score = 0;
        int lastDisplayedScore = -1;
        int scoreMultiplier = 1;
        int lastDisplayedMultiplier = 0;
        int killsWithoutMiss = 0;
        int fadeLevel = 0;

        float elapsedTime = 0;
        float playerExploding = 0;
        float gameOverExploding = 0;
        float shitWait = 0;

        int bulletsFired = 0;
        int bulletsMissed = 0;

        private float wavePass;
        private bool waveTransfer = false;
        private bool gameOver = false;
        private float updateTillNextBomb = 0;
        private int wave = 1;

        private int? cannonMovingFXId;
        private SOUNDEFFECT? cannonMovingFX;

        Random random;

        CCTextureCache cache;

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
        public string battlegroundImageName;

        public List<CCPoint> PlayerCollisionPoints = new List<CCPoint>();
        public List<CCPoint> EnemyCollisionPoints = new List<CCPoint>();

        public CCSpriteSheet ssPreExplosion;
        public CCSpriteSheet ssDrooling;
        public CCSpriteSheet ssGameOverExplosion;
        public CCSpriteSheet ssCannonExplosion1;
        public CCSpriteSheet ssCannonExplosion2;
        public CCSpriteSheet ssCannonFlame;
        public CCSpriteSheet ssEnemyExplosion;
        public CCSpriteSheet ssBomb;
        public CCSpriteSheet ssRecoil;
        public CCSpriteSheet ssFlyingSaucer;
        public string ssRecoilKeyPrefix;
        public CCSpriteSheet[] ssHybridLaser;
        public CCSpriteSheet ssLaserSparks;
        public CCSpriteSheet[] ssAlienLensFlare;

        CCSpriteSheet[] _ssFirework;
        float _fireworkFrame = 0;
        int _fireworkFrameLast;

        CCSprite _firework;

        private int countdown;

        private CCSprite countdownNumber;
        private CCSprite fadeShootButton;
        private CCSprite fadeControlButton;

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

        private float flyingSaucerFrame;
        private float flyingSaucerWait;
        private float flyingSaucerSpeed;
        private CCSprite flyingSaucer;
        private CCSprite flyingSaucerExplosion;
        private float flyingSaucerExplosionFrame;
        private float flyingSaucerIncoming;
        private int? flyingSaucerFlyingFxId;

        private bool isCannonMoving;
        private bool isCannonShooting;

        private CCEventListenerTouchAllAtOnce touchListener;

        public GamePlayLayer(ENEMIES selectedEnemy, WEAPONS selectedWeapon, BATTLEGROUNDS selectedBattleground, bool calloutCountryName, int caliberSizeSelected = -1, int fireSpeedSelected = -1, int magazineSizeSelected = -1, int livesSelected = -1, ENEMIES selectedEnemyForPickerScreens = ENEMIES.ALIENS, LAUNCH_MODE launchMode = LAUNCH_MODE.DEFAULT/*bool isTestFromWeaponPicker=false*/, int livesLeft = -1, int winsInSuccession = 0)
        {
            Shared.GameDelegate.ClearOnBackButtonEvent();
            this.EnableMultiTouch = true;

            // ----------- Prabhjot ----------- //
            //this.ScheduleOnce(Victory, 1);
            Settings.isFromGameScreen = true;
/*
#if __IOS__
            NSObject _indexPathNotification;
            _indexPathNotification = NSNotificationCenter.DefaultCenter.AddObserver(new NSString("PlayToEnd"), (obj) => {

                BtnBack_OnClick(null, null);

            });

#endif
*/


            NotificationCenterManager.Instance.AddObserver(OnSwitchIsOn, @"GameInBackground");



            GameAnimation.Instance.FreeAllSpriteSheets(false);

            random = new Random();
            touchListener = new CCEventListenerTouchAllAtOnce();

            this.launchMode = launchMode;

            battlegroundImageName = Battleground.GetBattlegroundImageName(selectedBattleground, Settings.Instance.BattlegroundStyle);

            if (this.launchMode == LAUNCH_MODE.DEFAULT)
            {
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




            gunCooloff = 1f / (FireSpeedSelected == -1 ? Weapon.GetFirespeed(selectedWeapon) : FireSpeedSelected);
            magazineSize = (MagazineSizeSelected == -1 ? Weapon.GetMagazineSize(selectedWeapon) : MagazineSizeSelected) * 5;
            bulletPower = (CaliberSizeSelected == -1 ? Weapon.GetCaliberSize(selectedWeapon) : CaliberSizeSelected) * 0.5f;
            bulletScale = 0.7f + ((CaliberSizeSelected == -1 ? Weapon.GetCaliberSize(selectedWeapon) : CaliberSizeSelected) * 0.1f);


            switch (selectedWeapon)
            {
                case WEAPONS.STANDARD:
                    PlayerCannon = "Player/Standard_gun.png";
                    PlayerLivesLeft = "Player/Standard_gun_lives_left_indicator.png";
                    playerSpeed = 30;
                    reloadTime = 2f;
                    smokeOffsetY = -40;
                    if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) SoundCannonShoot = "Sounds/Standard cannon (canon cal 3-3).wav";
                    else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) SoundCannonShoot = "Sounds/cannon shot standard cannon (23).wav";

                    ssRecoil = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/GunRecoil.plist");
                    ssRecoilKeyPrefix = "standard_gun_recoil_image_";

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
                    playerSpeed = 45;
                    reloadTime = 3f;
                    smokeOffsetY = -60;
                    if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) SoundCannonShoot = "Sounds/Compact sprayer (canon cal 3-3).wav";
                    else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) SoundCannonShoot = "Sounds/cannon shot compact sprayer (23).wav";

                    ssRecoil = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/CompactSprayerRecoil.plist");
                    ssRecoilKeyPrefix = "Compact_sprayer_recoil_animation_image_";

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
                    playerSpeed = 20;
                    reloadTime = 1f;
                    smokeOffsetY = -15;
                    if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) SoundCannonShoot = "Sounds/Black bazooka (canon cal 3-3).wav";
                    else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) SoundCannonShoot = "Sounds/cannon shot black bazooka (23).wav";

                    ssRecoil = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/BlackBazookaRecoil.plist");
                    ssRecoilKeyPrefix = "Black _bazooka_recoil_animation_image_";

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
                    magazineSize = magazineSize / 2;
                    gunCooloff = gunCooloff * 2;
                    PlayerCannon = "Player/Hybrid_defender.png";
                    PlayerLivesLeft = "Player/Hybrid_defender_lives_left_indicator.png";
                    playerSpeed = 20;
                    reloadTime = 2f;
                    smokeOffsetY = -15;
                    if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) SoundCannonShoot = "Sounds/Hybrid Canon Shoot Combo.wav";
                    else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) SoundCannonShoot = "Sounds/85 - Hybrid Laser 2.wav";

                    ssRecoil = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/HybridDefenderRecoil.plist");
                    ssRecoilKeyPrefix = "Hybrid_defender_recoil_animation_image_";

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

                    ssHybridLaser = new CCSpriteSheet[3];
                    ssHybridLaser[0] = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/PipeAndLensFlare-0.plist");
                    ssHybridLaser[1] = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/PipeAndLensFlare-1.plist");
                    ssHybridLaser[2] = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/PipeAndLensFlare-2.plist");

                    ssAlienLensFlare = new CCSpriteSheet[2];
                    ssAlienLensFlare[0] = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/alien-laser-lens-flair-0.plist");
                    ssAlienLensFlare[1] = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/alien-laser-lens-flair-1.plist");



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



            cache = CCTextureCache.SharedTextureCache;

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


            ssPreExplosion = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/Pre-explosion.plist");
            if (SelectedEnemy == ENEMIES.ALIENS)
            {
                ssDrooling = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/AlienSpit.plist");
            }
            else
            {
                ssDrooling = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/drooling.plist");
            }
            ssGameOverExplosion = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/Game-over-explosion.plist");
            ssEnemyExplosion = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/General_enemy_explosion.plist");
            ssCannonFlame = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/General_cannon_flame-0.plist");
            ssCannonExplosion1 = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/General_cannon_explosion-0.plist");
            ssCannonExplosion2 = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/General_cannon_explosion-1.plist");
            if (selectedEnemy != ENEMIES.ALIENS)
            {
                ssBomb = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/BombRotation.plist");
            }
            else
            {
                ssBomb = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/SlimeBall.plist");
                ssFlyingSaucer = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/FlyingSaucer.plist");
                ssLaserSparks = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/AlienLaserHittingWithoutLaser.plist");
            }

            for (int i = 1; i < 6; i++)
            {
                cache.AddImage(GameEnvironment.ImageDirectory + "Animations/get-ready-for-next-attack-countdown-(" + i.ToString() + ").png");
            }

            for (int i = 0; i < 10; i++)
            {
                cache.AddImage(GameEnvironment.ImageDirectory + "UI/number_50_" + i.ToString() + ".png");
            }




            cache.AddImage("UI/Battle-screen-reloading-text.png");
            cache.AddImage("UI/Battle-screen-time-text.png");


            cache.AddImage(battlegroundImageName);
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
                    this.AddImage(0, 0, "UI/Get-ready-for-next-attack-russian-troops.jpg", 1);
                    break;
                case ENEMIES.BUSH:
                    this.AddImage(0, 0, "UI/Get-ready-for-next-attack-USA-troops.jpg", 1);
                    break;
                case ENEMIES.KIM:
                    this.AddImage(0, 0, "UI/Get-ready-for-next-attack-south-korean-troops.jpg", 1);
                    break;
                case ENEMIES.HITLER:
                    this.AddImage(0, 0, "UI/Get-ready-for-next-attack-german-troops.jpg", 1);
                    break;
                case ENEMIES.ALIENS:
                    if (Settings.Instance.BattlegroundStyle == BATTLEGROUND_STYLE.Cartonic)
                        this.AddImage(0, 0, "UI/get-ready-for-next-attack-moon-level-cartonic.jpg", 1);
                    else
                        this.AddImage(0, 0, "UI/get-ready-for-next-attack-moon-level-realistic.jpg", 1);

                    break;
            }
            switch (selectedBattleground)
            {
                case BATTLEGROUNDS.AFGHANISTAN:
                    this.AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-afghanistan-text.png", 2);
                    break;
                case BATTLEGROUNDS.DENMARK:
                    this.AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-denmark-text.png", 2);
                    break;
                case BATTLEGROUNDS.ENGLAND:
                    this.AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-england-text.png", 2);
                    break;
                case BATTLEGROUNDS.ESTONIA:
                    this.AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-estonia-text.png", 2);
                    break;
                case BATTLEGROUNDS.FINLAND:
                    this.AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-finland-text.png", 2);
                    break;
                case BATTLEGROUNDS.FRANCE:
                    this.AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-france-text.png", 2);
                    break;
                case BATTLEGROUNDS.GEORGIA:
                    this.AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-georgia-text.png", 2);
                    break;
                case BATTLEGROUNDS.GREAT_BRITAIN:
                    this.AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-great-britain-text.png", 2);
                    break;
                case BATTLEGROUNDS.IRAQ:
                    this.AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-iraq-text.png", 2);
                    break;
                case BATTLEGROUNDS.ISRAEL:
                    this.AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-israel-text.png", 2);
                    break;
                case BATTLEGROUNDS.JAPAN:
                    this.AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-japan-text.png", 2);
                    break;
                case BATTLEGROUNDS.LIBYA:
                    this.AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-libya-text.png", 2);
                    break;
                case BATTLEGROUNDS.NORWAY:
                    this.AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-norway-text.png", 2);
                    break;
                case BATTLEGROUNDS.POLAND:
                    this.AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-poland-text.png", 2);
                    break;
                case BATTLEGROUNDS.RUSSIA:
                    this.AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-russia-text.png", 2);
                    break;
                case BATTLEGROUNDS.SOUTH_KOREA:
                    this.AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-south-korea-text.png", 2);
                    break;
                case BATTLEGROUNDS.SYRIA:
                    this.AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-syria-text.png", 2);
                    break;
                case BATTLEGROUNDS.UKRAINE:
                    this.AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-ukraine-text.png", 2);
                    break;
                case BATTLEGROUNDS.UNITED_STATES:
                    this.AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-united-states-text.png", 2);
                    break;
                case BATTLEGROUNDS.VIETNAM:
                    this.AddImageCentered(1136 / 2, 150, "UI/Choose-the-battleground-in-vietnam-text.png", 2);
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
                this.AddImageCentered(1136 / 2, 600, "UI/get-ready-for-the-next-attack-title-text.png", 2);
                this.AddImageCentered(1136 / 2, 540, "UI/get-ready-for-next-attack-(country__of__)-text.png", 2);
                this.AddImageLabelRightAligned(1136 / 2 + 92, 509, ((int)SelectedBattleground + 1).ToString(), 55);
                this.AddImageLabelCentered(1136 / 2 + 125, 509, "20", 55);

            }



            countdown = 6;

            if (SelectedEnemy == ENEMIES.ALIENS)
            {
                GameEnvironment.PlayMusic(MUSIC.BATTLE_COUNTDOWNALIEN);
            }
            else if (this.launchMode != LAUNCH_MODE.STEERING_TEST)
            {
                GameEnvironment.PlayMusic(MUSIC.BATTLE_COUNTDOWN);
            }

            if (this.launchMode != LAUNCH_MODE.DEFAULT)
            {
                enemySpeed = 0;
                wave = 3;
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
                    ScheduleOnce(CalloutCountryNameVO, 3.55f);
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


        private void CalloutCountryNameVO(float dt)
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


            countdown--;
            switch (countdown)
            {
                case 5:
                    countdownNumber = this.AddImage(450, 205, "UI/get-ready-for-next-attack-countdown-(5).png", 2);
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
                    this.RemoveChild(countdownNumber);
                    countdownNumber = this.AddImage(450, 205, "UI/get-ready-for-next-attack-countdown-(4).png", 2);
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
                    this.RemoveChild(countdownNumber);
                    countdownNumber = this.AddImage(450, 205, "UI/get-ready-for-next-attack-countdown-(3).png", 2);
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
                    this.RemoveChild(countdownNumber);
                    countdownNumber = this.AddImage(450, 205, "UI/get-ready-for-next-attack-countdown-(2).png", 2);
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
                    this.RemoveChild(countdownNumber);
                    countdownNumber = this.AddImage(450, 205, "UI/get-ready-for-next-attack-countdown-(1).png", 2);
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
                    this.UnscheduleAll();
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


        CCSpriteButton btnBack;
        CCSpriteButton btnSettings;

        CCSpriteButton btnMovement;
        CCSpriteButton btnFire;

        private void StartGame()
        {
            this.RemoveAllChildren(true);

            this.SetBackground(battlegroundImageName);

            if (this.launchMode == LAUNCH_MODE.STEERING_TEST)
            {
                this.AddImage(0, 0, "UI/Curtain-background-just-curtain.png", 100);
            }

            if (SelectedEnemy == ENEMIES.ALIENS)
            {
                timeLabel = this.AddImage(840, 580, "UI/Battle-screen-score-text.png", 999);
                multiplierLabelLabel = this.AddImage(896, 540, "UI/multiplier-text.png", 999);
                multiplierLabelLabel.Opacity = 0;

            }
            else
            {
                timeLabel = this.AddImage(910, 580, "UI/Battle-screen-time-text.png", 999);
            }
            //if (!Settings.Instance.Vibration) timeLabel.Visible = false;

            reloading = this.AddImage(820, 5, "UI/Battle-screen-reloading-text.png", 999);
            reloading.Visible = false;

            //player = this.AddImage(1136 / 2 - 100, 50, PlayerCannon, 100);

            player = new CCSprite(ssRecoil.Frames.Find(item => item.TextureFilename == ssRecoilKeyPrefix + "00.png"));
            player.BlendFunc = GameEnvironment.BlendFuncDefault;
            player.AnchorPoint = new CCPoint(0, 0);
            player.PositionX = 1136 / 2 - 100;
            player.PositionY = 50;
            player.ZOrder = 100;

            this.AddChild(player);



            for (int i = 0; i < (LivesLeft > -1 ? LivesLeft : Weapon.GetLives(SelectedWeapon) - 1); i++)
            {
                CCSprite life = this.AddImage(i * 80 + 20, 10, PlayerLivesLeft, 102);
                lives.Add(life);
            }

            for (int i = 0; i < magazineSize; i++)
            {
                CCSprite ammo;
                if (SelectedWeapon == WEAPONS.HYBRID)
                {
                    ammo = this.AddImage(1080 - i * 16, 10, "Player/laser-ammo.png", 102);
                }
                else
                {
                    ammo = this.AddImage(1080 - i * 16, 10, "Player/ammo.png", 102);
                }
                ammos.Add(ammo);
            }




            for (int j = 2; j >= 0; j--)
            {
                for (int i = 0; i < 4; i++)
                {
                    Enemy enemy = new Enemy(this, 1136 / 2 - 50 - (i * 100), 570 - (j * 65) + 290);
                    enemy.Sprite.ZOrder = 10 - (j * 3);
                    enemies.Add(enemy);
                    enemy = new Enemy(this, 1136 / 2 + 50 + (i * 100), 570 - (j * 65) + 290);
                    enemies.Add(enemy);
                    enemy.Sprite.ZOrder = 10 - (j * 3);
                }
            }
            goingDown = 240;
            enemyCurrentSpeed = 0; //enemySpeed;
            firstGoingDown = true;
            bombDensity = 100;

            bulletsFired = 0;
            bulletsMissed = 0;
            /*if(Settings.Instance.Vibration)*/

            time = this.AddImageLabel(1040, 580, "0", 50);

            if (launchMode == LAUNCH_MODE.STEERING_TEST)
            {
                foreach (var timeSprite in time)
                {
                    timeSprite.Visible = false;
                }

                timeLabel.Visible = false;
            }


            lastDisplayedTime = 0;
            elapsedTime = 0;
            wavePass = 1136;

            Settings.Instance.ShowSteeringTip = true;

            if (SelectedEnemy == ENEMIES.ALIENS && Settings.Instance.NotificationsEnabled && Settings.Instance.AlienGameTipGamePlayShow)
            {
                this.ScheduleOnce(showAlienTip, 1);
            }
            else if (Settings.Instance.NotificationsEnabled && Settings.Instance.GameTipGamePlayShow && Settings.Instance.ControlType == CONTROL_TYPE.GYROSCOPE && !Settings.Instance.ShowSteeringTip && launchMode == LAUNCH_MODE.DEFAULT)
            {
                this.ScheduleOnce(showTiltInstruction, 1);
            }

            else if (Settings.Instance.NotificationsEnabled && Settings.Instance.ShowSteeringTip && launchMode == LAUNCH_MODE.DEFAULT)
            {
                this.ScheduleOnce(showSteeringTip, 1);
            }
            else
            {
                if (launchMode != LAUNCH_MODE.STEERING_TEST)
                {
                    btnBack = this.AddButton(2, 570, "UI/pause-button-untapped.png", "UI/pause-button-tapped.png", 100, BUTTON_TYPE.Back);
                    btnBack.OnClick += BtnBack_OnClick;
                    btnBack.ButtonType = BUTTON_TYPE.Back;

                    btnSettings = this.AddButton(70, 570, "UI/settings-button-untapped.png", "UI/settings-button-tapped.png", 100, BUTTON_TYPE.Back);
                    btnSettings.OnClick += btnSettings_OnClick;
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


        private void OnSwitchIsOn(object p_object)
        {
            BtnBack_OnClick(null, null);
        }

        CCSpriteTwoStateButton gameTipCheckMark;
        CCSprite gameTipBackground;
        CCSprite gameTipExplanation;
        CCSprite gameTipArrow;
        CCSprite gameTipTarget;
        CCSpriteButton okIGotIt;

        private void showTiltInstruction(float dt)
        {
            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.NOTIFICATION_POP_UP);
            gameTipBackground = this.AddImageCentered(1136 / 2, 630 / 2, "UI/game-tip-notification-background-with-text.png", 1002);
            gameTipArrow = this.AddImage(50, 345, "UI/game-tip-notification-arrow2.png", 1003);
            gameTipTarget = this.AddImage(50, 177, "UI/game-tip-notification-tapping-symbol.png", 1003);
            gameTipExplanation = this.AddImage(100, 50, "UI/game-tip-notification-do-not-show-text.png.png", 1003);

            gameTipCheckMark = this.AddTwoStateButton(45, 40, "UI/check-button-untapped.png", "UI/check-button-tapped.png", "UI/check-button-tapped.png", "UI/check-button-untapped.png", 1005);
            gameTipCheckMark.OnClick += gameTipCheckMark_OnClick;
            gameTipCheckMark.ButtonType = BUTTON_TYPE.CheckMark;

            okIGotIt = this.AddButton(660, 20, "UI/OK-I-got-it-button-untapped.png", "UI/OK-I-got-it-button-tapped.png", 1005);
            okIGotIt.OnClick += okIGotIt_OnClick;
        }

        private void showTouchInstruction(float dt)
        {
            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.NOTIFICATION_POP_UP);
            gameTipBackground = this.AddImageCentered(1136 / 2, 630 / 2, "UI/touch-steering-instructions-notification-background.png", 1002);
            gameTipExplanation = this.AddImage(100, 30, "UI/game-tip-notification-do-not-show-text.png.png", 1003);

            gameTipCheckMark = this.AddTwoStateButton(45, 20, "UI/check-button-untapped.png", "UI/check-button-tapped.png", "UI/check-button-tapped.png", "UI/check-button-untapped.png", 1005);
            gameTipCheckMark.OnClick += gameTipCheckMark_OnClick;
            gameTipCheckMark.ButtonType = BUTTON_TYPE.CheckMark;

            okIGotIt = this.AddButton(660, 10, "UI/OK-I-got-it-button-untapped.png", "UI/OK-I-got-it-button-tapped.png", 1005);
            okIGotIt.OnClick += okIGotIt_OnClickTouch;
        }

        private void showSteeringTip(float dt)
        {
            Settings.Instance.ShowSteeringTip = false;

            if (Settings.Instance.NotificationsEnabled && Settings.Instance.GameTipGamePlayShow)
            {
                if (Settings.Instance.ControlType == CONTROL_TYPE.GYROSCOPE)
                {
                    this.ScheduleOnce(showTiltInstruction, 1);
                }
                else if (Settings.Instance.ControlType == CONTROL_TYPE.MANUAL)
                {
                    this.ScheduleOnce(showTouchInstruction, 1);
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
            btnBack = this.AddButton(2, 570, "UI/pause-button-untapped.png", "UI/pause-button-tapped.png", 100, BUTTON_TYPE.Back);
            btnBack.OnClick += BtnBack_OnClick;
            btnBack.ButtonType = BUTTON_TYPE.Back;

            btnSettings = this.AddButton(70, 570, "UI/settings-button-untapped.png", "UI/settings-button-tapped.png", 100, BUTTON_TYPE.Back);
            btnSettings.OnClick += btnSettings_OnClick;

            SetUpSteering(launchMode == LAUNCH_MODE.DEFAULT);
        }

        private void gameTipCheckMark_OnClick(object sender, EventArgs e)
        {
            gameTipCheckMark.ChangeState();
            gameTipCheckMark.SetStateImages();
        }

        private void okIGotIt_OnClick(object sender, EventArgs e)
        {
            Settings.Instance.GameTipGamePlayShow = gameTipCheckMark.State == 1 ? false : true;

            this.RemoveChild(gameTipBackground, true);
            this.RemoveChild(gameTipExplanation, true);
            this.RemoveChild(gameTipArrow, true);
            this.RemoveChild(gameTipTarget, true);
            this.RemoveChild(gameTipCheckMark, true);
            this.RemoveChild(okIGotIt, true);
            this.OnTouchBegan += GamePlayLayer_OnTouchBegan;
            Schedule(UpdateAll);
            btnBack = this.AddButton(2, 570, "UI/pause-button-untapped.png", "UI/pause-button-tapped.png", 100, BUTTON_TYPE.Back);
            btnBack.OnClick += BtnBack_OnClick;
            btnBack.ButtonType = BUTTON_TYPE.Back;

            btnSettings = this.AddButton(70, 570, "UI/settings-button-untapped.png", "UI/settings-button-tapped.png", 100, BUTTON_TYPE.Back);
            btnSettings.OnClick += btnSettings_OnClick;

            /*if (!Settings.Instance.Vibration)
            {
                btnBack.Visible = false;
                btnSettings.Visible = false;
            }*/

        }

        private void okIGotIt_OnClickTouch(object sender, EventArgs e)
        {
            Settings.Instance.GameTipGamePlayShow = gameTipCheckMark.State == 1 ? false : true;

            this.RemoveChild(gameTipBackground, true);
            this.RemoveChild(gameTipExplanation, true);
            this.RemoveChild(gameTipArrow, true);
            this.RemoveChild(gameTipTarget, true);
            this.RemoveChild(gameTipCheckMark, true);
            this.RemoveChild(okIGotIt, true);

            Settings.Instance.ShowSteeringTip = false;

            SetUpSteering(launchMode == LAUNCH_MODE.DEFAULT);

            CreateBtnBack();

            Schedule(UpdateAll);
        }

        private void showAlienTip(float dt)
        {
            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.NOTIFICATION_POP_UP);
            gameTipBackground = this.AddImageCentered(1136 / 2, 630 / 2, "UI/moon-level-notification-with-all-text.png", 1002);
            gameTipExplanation = this.AddImage(100, 50, "UI/game-tip-notification-do-not-show-text.png.png", 1003);

            gameTipCheckMark = this.AddTwoStateButton(45, 40, "UI/check-button-untapped.png", "UI/check-button-tapped.png", "UI/check-button-tapped.png", "UI/check-button-untapped.png", 1005);
            gameTipCheckMark.OnClick += gameTipCheckMark_OnClick;
            gameTipCheckMark.ButtonType = BUTTON_TYPE.CheckMark;

            okIGotIt = this.AddButton(660, 20, "UI/OK-I-got-it-button-untapped.png", "UI/OK-I-got-it-button-tapped.png", 1005);
            okIGotIt.OnClick += alienOkIGotIt_OnClick;
        }

        private void alienOkIGotIt_OnClick(object sender, EventArgs e)
        {
            Settings.Instance.AlienGameTipGamePlayShow = gameTipCheckMark.State == 1 ? false : true;
            this.RemoveChild(gameTipBackground, true);
            this.RemoveChild(gameTipExplanation, true);
            this.RemoveChild(gameTipCheckMark, true);
            this.RemoveChild(okIGotIt, true);
            this.OnTouchBegan += GamePlayLayer_OnTouchBegan;
            Schedule(UpdateAll);
            btnBack = this.AddButton(2, 570, "UI/pause-button-untapped.png", "UI/pause-button-tapped.png", 100, BUTTON_TYPE.Back);
            btnBack.OnClick += BtnBack_OnClick;
            btnBack.ButtonType = BUTTON_TYPE.Back;

            btnSettings = this.AddButton(70, 570, "UI/settings-button-untapped.png", "UI/settings-button-tapped.png", 100, BUTTON_TYPE.Back);
            btnSettings.OnClick += btnSettings_OnClick;

            /*if (!Settings.Instance.Vibration)
            {
                btnBack.Visible = false;
                btnSettings.Visible = false;
            }*/

        }

        private void clearAll()
        {
            this.RemoveAllChildren(true);
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


            // -------- Prabhjot Singh ------- //
            Settings.isFromGameScreen = false;
            CCScene newScene = new CCScene(this.GameView);
            newScene.AddLayer(new SettingsScreenLayer(this, GameConstants.NavigationParam.GameScreen));
            Director.PushScene(newScene);

        }

        public CCLayerColorExt Continue()
        {
            battlegroundImageName = Battleground.GetBattlegroundImageName(SelectedBattleground, Settings.Instance.BattlegroundStyle);
            this.SetBackground(battlegroundImageName);

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

            if (waveTransfer == true)
            {
                if (SelectedEnemy == ENEMIES.ALIENS)
                {
                    GameEnvironment.PlayMusic(MUSIC.NEXTWAVEALIEN);
                    this.ScheduleOnce(NextWave, 3);
                }
                else
                {
                    switch (wave)
                    {
                        case 1:
                            GameEnvironment.PlayMusic(MUSIC.NEXTWAVE);
                            this.ScheduleOnce(NextWave, 3);
                            break;
                        case 2:
                            GameEnvironment.PlayMusic(MUSIC.NEXTWAVE);
                            this.ScheduleOnce(NextWave, 3);
                            break;
                        case 3:
                            this.ScheduleOnce(Victory, 1);
                            break;
                    }
                }
            }
            else
            {
                if (SelectedEnemy == ENEMIES.ALIENS)
                {
                    switch (wave)
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
                            switch (wave % 3)
                            {
                                case 0: GameEnvironment.PlayMusic(MUSIC.BATTLE_ALIEN9); break;
                                case 1: GameEnvironment.PlayMusic(MUSIC.BATTLE_ALIEN3); break;
                                case 2: GameEnvironment.PlayMusic(MUSIC.BATTLE_ALIEN6); break;
                            }
                            break;

                    }
                }
                else if (wave == 1)
                {
                    GameEnvironment.PlayMusic(MUSIC.BATTLE_WAVE_1);
                }
                else if (wave == 2)
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

        CCSprite gamePauseBackground;
        CCSpriteButton btnJust;
        CCSpriteButton btnSurrender;
        CCSpriteButton btnContinue;
        CCSprite gamePauseFriendlyLabel;
        CCSpriteTwoStateButton gamePauseFriendlyCheckMark;

        public void BtnBack_OnClick(object sender, EventArgs e)
        {
            Settings.isFromGameScreen = false;
            this.UnscheduleAll();
            this.OnTouchBegan -= GamePlayLayer_OnTouchBegan;

            if (Settings.Instance.GamePauseFriendly)
            {
                gamePauseBackground = this.AddImageCentered(1136 / 2, 630 / 2, "UI/game-paused-friendly-notification-background-with-text.png", 2002);
            }
            else
            {
                gamePauseBackground = this.AddImageCentered(1136 / 2, 630 / 2, "UI/game-paused-rude-notification-background-with-text.png", 2002);
            }
            btnJust = this.AddButton(176, 320, "UI/game-paused-just-paused-button-untapped.png", "UI/game-paused-just-paused-button-tapped.png", 2003);
            btnJust.OnClick += btnJust_OnClick;
            btnSurrender = this.AddButton(176, 203, "UI/game-paused-surrender-button-untapped.png", "UI/game-paused-surrender-button-tapped.png", 2003);
            btnSurrender.OnClick += btnSurrender_OnClick;
            btnContinue = this.AddButton(176, 85, "UI/game-paused-lets-continue-button-untapped.png", "UI/game-paused-lets-continue-button-tapped.png", 2003);
            btnContinue.OnClick += btnContinue_OnClick;


            gamePauseFriendlyLabel = this.AddImage(120, 25, "UI/game-paused-friendly-do-not-insult-me-text.png", 2003);

            gamePauseFriendlyCheckMark = this.AddTwoStateButton(45, 20, "UI/check-button-untapped.png", "UI/check-button-tapped.png", "UI/check-button-tapped.png", "UI/check-button-untapped.png", 2005);
            gamePauseFriendlyCheckMark.OnClick += gamePauseFriendlyCheckMark_OnClick;
            gamePauseFriendlyCheckMark.ButtonType = BUTTON_TYPE.CheckMark;
            gamePauseFriendlyCheckMark.State = Settings.Instance.GamePauseFriendly ? 1 : 2;
            gamePauseFriendlyCheckMark.SetStateImages();

            btnBack.Visible = false;
            btnSettings.Visible = false;


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

            CCScene newScene = new CCScene(this.GameView);
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
            this.RemoveChild(gamePauseBackground, true);
            gamePauseBackground = null;
            this.RemoveChild(btnJust, true);
            btnJust = null;
            this.RemoveChild(btnSurrender, true);
            btnSurrender = null;
            this.RemoveChild(btnContinue, true);
            btnContinue = null;
            this.RemoveChild(gamePauseFriendlyLabel, true);
            gamePauseFriendlyLabel = null;
            this.RemoveChild(gamePauseFriendlyCheckMark, true);
            gamePauseFriendlyCheckMark = null;

            btnBack.Visible = true;
            btnSettings.Visible = true;

            Schedule(UpdateAll);

            SetUpSteering(launchMode == LAUNCH_MODE.DEFAULT);

            if (waveTransfer == true)
            {
                if (SelectedEnemy == ENEMIES.ALIENS)
                {
                    this.ScheduleOnce(NextWave, 3);
                }
                else
                {
                    switch (wave)
                    {
                        case 1:
                            this.ScheduleOnce(NextWave, 3);
                            break;
                        case 2:
                            this.ScheduleOnce(NextWave, 3);
                            break;
                        case 3:
                            this.ScheduleOnce(Victory, 1);
                            break;
                    }
                }
            }
        }


        private void gamePauseFriendlyCheckMark_OnClick(object sender, EventArgs e)
        {
            gamePauseFriendlyCheckMark.ChangeState();
            gamePauseFriendlyCheckMark.SetStateImages();
            Settings.Instance.GamePauseFriendly = gamePauseFriendlyCheckMark.State == 1 ? true : false;
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
            if (ammos.Count > 0 && playerExplosion == null && gunCoolness <= 0)
            {
                //GameDelegate.Vibrate(100);
                GunSmoke gunSmoke = new GunSmoke(this, Convert.ToInt32(player.PositionX + player.ContentSize.Width / 2) + 5, Convert.ToInt32(player.PositionY + player.ContentSize.Height + smokeOffsetY));
                gunSmokes.Add(gunSmoke);
                CCSprite bulletSprite;
                if (SelectedWeapon == WEAPONS.HYBRID)
                {
                    bulletSprite = this.AddImage(Convert.ToInt32(player.PositionX + player.ContentSize.Width / 2), Convert.ToInt32(player.PositionY + player.ContentSize.Height + smokeOffsetY), "Player/green-lazer-bullet.png");
                }
                else
                {
                    bulletSprite = this.AddImage(Convert.ToInt32(player.PositionX + player.ContentSize.Width / 2), Convert.ToInt32(player.PositionY + player.ContentSize.Height + smokeOffsetY), "Player/bullet.png");
                    gunSmoke.Sprite.Scale = bulletScale;
                }

                bulletSprite.ZOrder = 8;
                bulletSprite.Scale = bulletScale;
                bulletSprite.PositionX -= bulletSprite.ContentSize.Width * bulletScale / 2;
                if (SelectedWeapon == WEAPONS.HYBRID)
                {
                    bulletSprite.PositionY -= 30;
                }
                //bullet.PositionY -= bullet.ContentSize.Height*bulletScale;
                Bullet bullet = new Bullet();
                bullet.Sprite = bulletSprite;
                bullet.Power = bulletPower;
                bullets.Add(bullet);
                this.RemoveChild(ammos[ammos.Count - 1], true);
                ammos.RemoveAt(ammos.Count - 1);
                bulletsFired++;
                gunCoolness = gunCooloff;
                CCAudioEngine.SharedEngine.PlayEffect(SoundCannonShoot);
                if (ammos.Count == 0)
                {
                    reloading.Visible = true;
                    reload = reloadTime;
                }
            }
            else if (ammos.Count == 0)
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
            var fireButtonBoundingBox = btnFire.BoundingBoxTransformedToWorld;

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
            this.UnscheduleAll();
            Player.Instance.AddKills(SelectedEnemy, kills);

            //CCLabel go = this.AddLabelCentered(1136 / 2, 315, "G A M E   O V E R", "Fonts/AktivGroteskBold", 16);
            //go.Scale = 2;
            //go.ZOrder = 100;
            clearAll();
            this.Enabled = false;

            SetGameDuration();

            if (launchMode == LAUNCH_MODE.WEAPON_TEST)
            {
                AdMobManager.HideBanner();
                this.TransitionToLayerCartoonStyle(new WeaponPickerLayer((int)SelectedEnemyForPickerScreens, (int)SelectedWeapon));
            }
            else if (launchMode == LAUNCH_MODE.WEAPONS_UPGRADE_TEST)
            {
                AdMobManager.HideBanner();
                this.TransitionToLayerCartoonStyle(new WeaponUpgradeScreenLayer((int)SelectedEnemyForPickerScreens, (int)SelectedWeapon, CaliberSizeSelected, FireSpeedSelected, MagazineSizeSelected, LivesSelected));
            }
            else
            {
                this.TransitionToLayerCartoonStyle(new LossScreenLayer(SelectedEnemy, SelectedWeapon, SelectedBattleground, score, wave));
            }
        }

        void Victory(float dt)
        {
            this.UnscheduleAll();
            Player.Instance.AddKills(SelectedEnemy, kills);

            if (bulletsFired == 0)
            {
                bulletsFired = 1;
            }
            if (elapsedTime == 0)
            {
                elapsedTime = 1;
            }
            clearAll();
            SetGameDuration();

            if (launchMode == LAUNCH_MODE.WEAPON_TEST)
            {
                AdMobManager.HideBanner();
                this.TransitionToLayerCartoonStyle(new WeaponPickerLayer((int)SelectedEnemyForPickerScreens, (int)SelectedWeapon));
            }
            else if (launchMode == LAUNCH_MODE.WEAPONS_UPGRADE_TEST)
            {
                AdMobManager.HideBanner();
                this.TransitionToLayerCartoonStyle(new WeaponUpgradeScreenLayer((int)SelectedEnemyForPickerScreens, (int)SelectedWeapon, CaliberSizeSelected, FireSpeedSelected, MagazineSizeSelected, LivesSelected));
            }
            else if (launchMode == LAUNCH_MODE.STEERING_TEST)
            {
                AdMobManager.HideBanner();
                StartGame();
            }
            if (launchMode == LAUNCH_MODE.DEFAULT)
            {
                this.TransitionToLayerCartoonStyle(new VictoryScreenLayer(SelectedEnemy, SelectedWeapon, SelectedBattleground, Convert.ToDecimal(elapsedTime), Convert.ToDecimal((bulletsFired - bulletsMissed) * 100) / Convert.ToDecimal(bulletsFired), lives.Count, WinsInSuccession + 1));
            }
        }

        private void SetGameDuration()
        {
            Settings.Instance.SetTodaySessionDuration((int)elapsedTime);
        }

        CCLabel label = null;

        CCSprite nextWaveSprite = null;
        CCSprite[] nextWaveNumberSprites = null;

        void NextWave(float dt)
        {
            this.RemoveChild(nextWaveSprite, true);
            this.nextWaveSprite = null;
            if (nextWaveNumberSprites != null)
            {
                foreach (CCSprite waveDigit in nextWaveNumberSprites)
                {
                    this.RemoveChild(waveDigit, true);
                }
                this.nextWaveNumberSprites = null;
            }

            this.wave++;
            if (timeLabel.Visible)
            {
                timeLabel.Opacity = byte.MaxValue;
                foreach (CCSprite timeDigit in time)
                {
                    timeDigit.Opacity = byte.MaxValue;
                }
            }
            if (multiplierLabel != null)
            {
                multiplierLabel.Opacity = byte.MaxValue;
            }
            bounces = 0;
            flyingSaucerWait = 0;
            if (SelectedEnemy == ENEMIES.ALIENS)
            {
                bombDensity -= 10;
                if (wave == 6)
                {
                    goingDownSpeed -= 1.5f;
                    enemySpeed -= 1.5f;
                    bombDensity += 40;
                }
                else if (wave == 9)
                {
                    goingDownSpeed -= 1.0f;
                    enemySpeed -= 1.0f;
                    bombDensity += 30;
                }
                else
                {
                    enemySpeed += 0.5f;
                }
                enemyCurrentSpeed = 0; //enemySpeed;
                goingDownSpeed += 0.5f;
                if (goingDownSpeed > 4) goingDownSpeed = 4;
                if (enemySpeed > 4) enemySpeed = 4f;
                if (bombDensity < 20) bombDensity = 20;
            }
            else
            {
                bombDensity -= 20;
                enemySpeed += 0.7f;
                enemyCurrentSpeed = 0; //enemySpeed;
                goingDownSpeed += 0.7f;
            }
            goingDownCurrentSpeed = goingDownSpeed;
            firstGoingDown = true;
            for (int j = wave > 8 ? 4 : (wave > 5 ? 3 : 2); j >= 0; j--)
            {
                for (int i = 0; i < 4; i++)
                {
                    Enemy enemy = new Enemy(this, 1136 / 2 - 50 - (i * 100), 570 - (j * 65) + 290);
                    enemy.Sprite.ZOrder = 10 - (j * 3);
                    enemies.Add(enemy);
                    enemy = new Enemy(this, 1136 / 2 + 50 + (i * 100), 570 - (j * 65) + 290);
                    enemies.Add(enemy);
                    enemy.Sprite.ZOrder = 10 - (j * 3);
                }
            }
            if (wave > 7)
            {
                goingDown = 240;
            }
            else if (wave > 5)
            {
                goingDown = 240 + 32;
            }
            else if (wave > 2)
            {
                goingDown = 240 + 2 * 32;
            }
            else
            {
                goingDown = 240 + wave * 32;
            }
            waveTransfer = false;
            wavePass = 1136;
            if (SelectedEnemy == ENEMIES.ALIENS)
            {
                switch (wave)
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
                        switch (wave % 3)
                        {
                            case 0: GameEnvironment.PlayMusic(MUSIC.BATTLE_ALIEN9); break;
                            case 1: GameEnvironment.PlayMusic(MUSIC.BATTLE_ALIEN3); break;
                            case 2: GameEnvironment.PlayMusic(MUSIC.BATTLE_ALIEN6); break;
                        }
                        break;

                }
            }
            else if (wave == 2)
            {
                GameEnvironment.PlayMusic(MUSIC.BATTLE_WAVE_2);
            }
            else
            {
                GameEnvironment.PlayMusic(MUSIC.BATTLE_WAVE_3);
            }

        }

        bool inRectangle(CCRect rect, List<CCPoint> points, float offsetX, float offsetY, int reduceRectX = 0, int reduceRectY = 0)
        {
            CCRect r = new CCRect(rect.LowerLeft.X + reduceRectX, rect.LowerLeft.Y + reduceRectY, rect.Size.Width - reduceRectX * 2, rect.Size.Height - reduceRectY * 2);
            foreach (CCPoint point in points)
            {
                if (r.ContainsPoint(new CCPoint(point.X + offsetX, offsetY - point.Y))) return true;
            }
            return false;
        }

        float inRectangleTopY(CCRect rect, List<CCPoint> points, float offsetX, float offsetY)
        {
            float topY = -1;
            foreach (CCPoint point in points)
            {
                if (rect.ContainsPoint(new CCPoint(point.X + offsetX, offsetY - point.Y)) && offsetY - point.Y > topY) topY = offsetY - point.Y;
            }
            return topY;
        }

        void playerExplode(bool loseAllLives = false)
        {
            playerExplosion = new CCSprite(ssCannonExplosion1.Frames.Find(item => item.TextureFilename == "General_cannon_explosion_00.png"));
            playerExplosion.PositionX = player.PositionX + player.ContentSize.Width / 2;
            playerExplosion.PositionY = 0; //player.PositionY;
            playerExplosion.AnchorPoint = new CCPoint(0.5f, 0);
            playerExploding = 0;
            this.AddChild(playerExplosion, 101);

            if (Settings.Instance.Vibration)
            {
                VibrationManager.Vibrate();
            }

            if (lives.Count > 0 && !loseAllLives)
            {
                if (VoicePlayerHit != "")
                {
                    CCAudioEngine.SharedEngine.PlayEffect(VoicePlayerHit);
                    switch (lives.Count)
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

                btnBack.Enabled = false;
                btnSettings.Enabled = false;

                gameOver = true;
                gameOverLabel = this.AddImageCentered(1136 / 2, 630 / 2, "UI/Battle-screen-game-over...-text.png", 1010);
                gameOverLabel.Scale = 0.8f;

                //CCLabel go = this.AddLabelCentered(1136 / 2, 315, "G A M E   O V E R", "Fonts/AktivGroteskBold", 16);
                //go.Scale = 2;
                //go.ZOrder = 100;

                GameEnvironment.PlaySoundEffect(SOUNDEFFECT.GUN_HIT_GAME_OVER);
                if (Settings.Instance.VoiceoversEnabled)
                {
                    this.ScheduleOnce(CalloutGameOver, 0.2f);
                }
                else
                {
                    if (VoiceGameOver != "") CCAudioEngine.SharedEngine.PlayEffect(VoiceGameOver);
                }
            }
        }

        private void CalloutGameOver(float dt)
        {
            CCAudioEngine.SharedEngine.PlayEffect("Sounds/Game Over VO_mono.wav");
            this.ScheduleOnce(CalloutVoiceGameOver, 0.8f);
        }

        private void CalloutVoiceGameOver(float dt)
        {
            if (VoiceGameOver != "") CCAudioEngine.SharedEngine.PlayEffect(VoiceGameOver);
        }

        private void AnimateButtons(float dt)
        {
            List<CCSpriteFrame> framesTarget = new List<CCSpriteFrame>();

            int fireButtonX = 918;
            int fireButtonY = 2;

            int steerinButtonX = 3;
            int steeringButtonY = 2;

            if (!Settings.Instance.RightHanded)
            {
                fireButtonX = 3;
                steerinButtonX = 715;
            }


            this.RemoveChild(fadeShootButton);
            this.RemoveChild(fadeControlButton);

            fadeShootButton = this.AddImage(fireButtonX, fireButtonY, $"UI/Controls/Fire button/{fadeLevel.ToString("D3")}-transparent-fire-button-untapped.png", 102);
            fadeControlButton = this.AddImage(steerinButtonX, steeringButtonY, $"UI/Controls/Steering arrow/{fadeLevel.ToString("D3")}-transparent-movement-arrow-untapped.png", 102);

            fadeLevel += 5;
            CCAnimation animationTarget = new CCAnimation(framesTarget, 0.10f);

            if (fadeLevel >= 80)
            {
                this.RemoveChild(fadeShootButton);
                this.RemoveChild(fadeControlButton);
                Unschedule(AnimateButtons);

                btnFire.Visible = true;
                btnMovement.Visible = true;
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
            if (label != null) this.RemoveChild(label, true);

            if (!waveTransfer)
            {
                elapsedTime += dt;
            }
            //if (Settings.Instance.Vibration)
            //{
            if (SelectedEnemy == ENEMIES.ALIENS)
            {
                if (lastDisplayedScore != score)
                {
                    lastDisplayedScore = score;

                    foreach (CCSprite spr in time)
                    {
                        this.RemoveChild(spr);
                    }
                    time = this.AddImageLabelRightAligned(1120, 580, lastDisplayedScore.ToString(), 50);
                    timeLabel.PositionX = time[0].PositionX - timeLabel.ContentSize.Width / 2 - 60;


                }

                if (scoreMultiplier == 1 && multiplierLabel != null)
                {
                    multiplierLabel.Opacity -= 5;
                    if (multiplierLabel.Opacity < 20)
                    {
                        this.RemoveChild(multiplierLabel);
                        multiplierLabel = null;
                    }
                }
                if (scoreMultiplier > 1 && multiplierLabelLabel.Opacity < 255)
                {
                    multiplierLabelLabel.Opacity += 5;
                }
                if (scoreMultiplier == 1 && multiplierLabelLabel.Opacity > 0)
                {
                    multiplierLabelLabel.Opacity -= 5;
                }

            }
            else
            {
                if (lastDisplayedTime < Convert.ToInt32(elapsedTime))
                {
                    lastDisplayedTime = Convert.ToInt32(elapsedTime);

                    foreach (CCSprite spr in time)
                    {
                        this.RemoveChild(spr);
                    }
                    if (launchMode != LAUNCH_MODE.STEERING_TEST)
                        time = this.AddImageLabel(1040, 580, lastDisplayedTime.ToString(), 50);
                }
            }
            //}

            for (int i = 0; i < multipliers.Count;)
            {
                CCSprite multiplier = multipliers[i];
                if (multiplier.Opacity > 240)
                {
                    multiplier.PositionX += (1096 - multiplier.PositionX) / (255 - multiplier.Opacity);
                    multiplier.PositionY += (570 - multiplier.PositionY) / (255 - multiplier.Opacity);
                    multiplier.Scale = multiplier.ScaleX - 0.033f;
                    multiplier.Opacity += 1;
                    if (multiplier.Opacity == 255)
                    {
                        if (multiplierLabel != null)
                        {
                            this.RemoveChild(multiplierLabel, true);
                        }
                        multiplierLabel = multiplier;
                        multipliers.Remove(multiplier);
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

            if (gunCoolness > 0) gunCoolness -= dt;
            if (shitWait > 0) shitWait -= dt;

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
                    controlMovement = maxSpeed * pitch >= 0 ? 1 : -1;
                }
                else
                {
                    controlMovement = (float)Math.Round(maxSpeed * pitch / maxAngleBySensivity, 2);
                }

                tiltAngle = -pitch;
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
                        _firework.Position = new CCPoint(1136 / 2, 640 / 2);
                        _firework.ZOrder = 0;
                        _firework.Scale = 4;
                        _fireworkFrame = 1;
                        this.AddChild(_firework);
                    }
                    else if (_fireworkFrameLast <= 84)
                    {
                        _firework.TextureRectInPixels = _ssFirework[0].Frames.Find(item => item.TextureFilename == "Firework_animation_image_" + _fireworkFrameLast.ToString().PadLeft(3, '0') + ".png").TextureRectInPixels;
                        _firework.BlendFunc = GameEnvironment.BlendFuncDefault;
                    }
                    else if (_fireworkFrameLast == 85)
                    {
                        this.RemoveChild(_firework, true);
                        _firework = new CCSprite(_ssFirework[1].Frames.Find(item => item.TextureFilename == "Firework_animation_image_085.png"));
                        _firework.AnchorPoint = new CCPoint(0.5f, 0.5f);
                        _firework.Position = new CCPoint(1136 / 2, 640 / 2);
                        _firework.ZOrder = 0;
                        _firework.Scale = 4;
                        this.AddChild(_firework);

                    }
                    else if (_fireworkFrame <= 124)
                    {
                        _firework.TextureRectInPixels = _ssFirework[1].Frames.Find(item => item.TextureFilename == "Firework_animation_image_" + _fireworkFrameLast.ToString().PadLeft(3, '0') + ".png").TextureRectInPixels;
                        _firework.BlendFunc = GameEnvironment.BlendFuncDefault;
                    }
                    if (_fireworkFrameLast >= 124)
                    {
                        this.RemoveChild(_firework, true);
                        _fireworkFrame = 0;
                    }
                }
            }

            if (playerExplosion == null)
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
                    player.PositionX -= controlMovement * playerSpeed;
                }
                else
                {
                    if (isCannonMoving)
                    {
                        movingTime += 1;
                    }
                    else
                    {
                        movingTime = 0;
                    }

                    if (movingTime < 40)
                    {
                        controlMovement = speedTo * movingTime / 40f;
                        player.PositionX -= controlMovement * playerSpeed;
                    }
                    else
                    {
                        controlMovement = speedTo;
                        player.PositionX -= speedTo * playerSpeed;
                    }

                    if (controlMovement == 0)
                    {
                        movingTime = 0;
                    }
                }

                if (player.PositionX < 10) player.PositionX = 10;
                if (player.PositionX > 1000) player.PositionX = 1000;

                //player.PositionY = 50 - (gunCoolness == gunCooloff?8: ( gunCoolness / gunCooloff * 15));

                player.TextureRectInPixels = ssRecoil.Frames.Find(item => item.TextureFilename == ssRecoilKeyPrefix + (12 - (12 * gunCoolness / gunCooloff)).ToString("0#") + ".png").TextureRectInPixels;


            }
            else
            {
                if (cannonMovingFXId != null)
                {
                    CCAudioEngine.SharedEngine.StopEffect(cannonMovingFXId.Value);
                    cannonMovingFXId = null;
                    cannonMovingFX = null;
                }
            }

            if (reload > 0)
            {
                bool timeForSound = reload > 0.8 ? true : false;
                reload = reload - dt;
                if (reload <= 0.8 && timeForSound)
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
                if (reload <= 0)
                {
                    for (int i = 0; i < magazineSize; i++)
                    {
                        CCSprite ammo;
                        if (SelectedWeapon == WEAPONS.HYBRID)
                        {
                            ammo = this.AddImage(1080 - i * 16, 10, "Player/laser-ammo.png", 102);
                        }
                        else
                        {
                            ammo = this.AddImage(1080 - i * 16, 10, "Player/ammo.png", 102);
                        }
                        ammos.Add(ammo);
                        reloading.Visible = false;
                    }
                }
            }


            for (int i = 0; i < gunSmokes.Count;)
            {
                GunSmoke gunSmoke = gunSmokes[i];
                if (SelectedWeapon == WEAPONS.HYBRID)
                {
                    int sheet = 0;
                    if (Convert.ToInt32(gunSmoke.Smoke + 6) > 11) sheet = 1;
                    if (Convert.ToInt32(gunSmoke.Smoke + 6) > 18) sheet = 2;

                    if (gunSmoke.Sprite.Texture != ssHybridLaser[sheet].Frames.Find(item => item.TextureFilename == "pipe-flames-and-lens-flare-image_" + Convert.ToInt32(gunSmoke.Smoke + 6).ToString().PadLeft(2, '0') + ".png").Texture)
                    {
                        CCSprite newGunSmoke = new CCSprite(ssHybridLaser[sheet].Frames.Find(item => item.TextureFilename == "pipe-flames-and-lens-flare-image_" + Convert.ToInt32(gunSmoke.Smoke + 6).ToString().PadLeft(2, '0') + ".png"));
                        newGunSmoke.AnchorPoint = new CCPoint(0.5f, 0);
                        newGunSmoke.PositionX = gunSmoke.Sprite.PositionX;
                        newGunSmoke.PositionY = gunSmoke.Sprite.PositionY;
                        newGunSmoke.Opacity = gunSmoke.Sprite.Opacity;
                        this.AddChild(newGunSmoke, gunSmoke.Sprite.ZOrder);
                        this.RemoveChild(gunSmoke.Sprite, true);
                        gunSmoke.Sprite = newGunSmoke;
                    }

                    gunSmoke.Sprite.TextureRectInPixels = ssHybridLaser[sheet].Frames.Find(item => item.TextureFilename == "pipe-flames-and-lens-flare-image_" + Convert.ToInt32(gunSmoke.Smoke + 6).ToString().PadLeft(2, '0') + ".png").TextureRectInPixels;

                    gunSmoke.Sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
                    gunSmoke.Smoke += 1f;
                    if (Convert.ToInt32(gunSmoke.Smoke + 6) == 15) gunSmoke.Smoke += 1f;  //fali image

                    if (Convert.ToInt32(gunSmoke.Smoke + 6) > 24)
                    {
                        gunSmoke.Destroy();
                        gunSmokes.Remove(gunSmoke);
                    }
                    else
                    {
                        i++;
                    }
                }
                else
                {
                    gunSmoke.Sprite.TextureRectInPixels = ssCannonFlame.Frames.Find(item => item.TextureFilename == "General_cannon_flame" + Convert.ToInt32(gunSmoke.Smoke).ToString().PadLeft(2, '0') + ".png").TextureRectInPixels;

                    gunSmoke.Sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
                    gunSmoke.Smoke += 1f;
                    if (gunSmoke.Smoke > 14)
                    {
                        gunSmoke.Sprite.Opacity = Convert.ToByte(280 - Convert.ToInt32(gunSmoke.Smoke * 3));
                    }
                    if (gunSmoke.Smoke > 71)
                    {
                        gunSmoke.Destroy();
                        gunSmokes.Remove(gunSmoke);
                    }
                    else
                    {
                        i++;
                    }
                }
            }


            for (int i = 0; i < explos.Count;)
            {
                Explosion explo = explos[i];
                explo.Sprite.TextureRectInPixels = ssPreExplosion.Frames.Find(item => item.TextureFilename == "Pre-explosion_image_" + Convert.ToInt32(explo.Explo).ToString().PadLeft(2, '0') + ".png").TextureRectInPixels;
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
                    explos.Remove(explo);
                }
                else
                {
                    i++;
                }
            }

            for (int i = 0; i < bullets.Count;)
            {

                CCSprite bullet = bullets[i].Sprite;

                bullet.PositionY += 10;

                if (bullets[i].Power > 0)
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



                    if (flyingSaucer != null && flyingSaucerExplosion == null && rec.IntersectsRect(new CCRect(flyingSaucer.PositionX - 50, flyingSaucer.PositionY - 10, 100, 25)))
                    {
                        bullets[i].Power = 0;
                        flyingSaucerExplosion = new CCSprite(ssEnemyExplosion.Frames.Find(item => item.TextureFilename == "General_enemy_explosion00.png"));
                        flyingSaucerExplosion.AnchorPoint = new CCPoint(0.5f, 0.5f);
                        flyingSaucerExplosion.Position = new CCPoint(flyingSaucer.PositionX, flyingSaucer.PositionY);
                        flyingSaucerExplosion.BlendFunc = GameEnvironment.BlendFuncDefault;
                        flyingSaucerExplosionFrame = 0;
                        this.AddChild(flyingSaucerExplosion, 25);

                        Explosion explo = new Explosion(this, Convert.ToInt32(bullet.PositionX + bullet.ContentSize.Width / 2), Convert.ToInt32(bullet.PositionY + bullet.ContentSize.Height / 2));
                        explos.Add(explo);

                        CCAudioEngine.SharedEngine.StopEffect(flyingSaucerFlyingFxId.Value);
                        GameEnvironment.PlaySoundEffect(SOUNDEFFECT.FLYINGSAUCER_EXPLOSION);
                        flyingSaucerWait = 10000000;

                        CCSprite life = this.AddImage(lives.Count * 80 + 20, 10, PlayerLivesLeft, player.ZOrder - 1);
                        lives.Add(life);
                    }

                    for (int j = 0; j < enemies.Count; j++)
                    {
                        Enemy enemy = enemies[j];

                        if (!enemy.Killed && inRectangle(rec, EnemyCollisionPoints, enemy.Sprite.PositionX - enemy.Sprite.ContentSize.Width / 2, enemy.Sprite.PositionY))
                        {
                            float eh = enemy.Health;
                            enemy.Health -= bullets[i].Power;
                            bullets[i].Power -= eh;

                            Explosion explo = new Explosion(this, Convert.ToInt32(bullet.PositionX + bullet.ContentSize.Width / 2), Convert.ToInt32(bullet.PositionY + bullet.ContentSize.Height / 2));
                            explos.Add(explo);

                            switch (random.Next(3))
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
                                    if (VoiceEnemyHit != "" && shitWait <= 0)
                                    {
                                        shitWait = 1 + random.Next(100) / 100f;
                                        if (SelectedEnemy == ENEMIES.HITLER && random.Next(4) == 0)
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

                                this.RemoveChild(enemy.LensFlare, true);
                                enemy.LensFlare = null;

                                enemy.keepGrimace = 0;
                                enemy.Killed = true;

                                if (SelectedEnemy == ENEMIES.ALIENS)
                                {
                                    score += 5 * scoreMultiplier;
                                    killsWithoutMiss++;
                                    if (killsWithoutMiss >= 5 && scoreMultiplier < 8)
                                    {
                                        scoreMultiplier = scoreMultiplier * 2;
                                        killsWithoutMiss = 0;
                                        CCSprite multiplier = this.AddImageCentered(Convert.ToInt32(enemy.Sprite.PositionX), Convert.ToInt32(enemy.Sprite.PositionY - enemy.Sprite.ContentSize.Height / 2), "UI/" + scoreMultiplier.ToString() + "X-text-for-explosion.png", 100);
                                        multiplier.Opacity = 200;
                                        multipliers.Add(multiplier);
                                    }
                                }
                                kills++;

                                if (enemy.AttachedBomb != null)
                                {
                                    enemy.BombOut();
                                    enemy.AttachedBomb.Released = true;
                                    enemy.AttachedBomb.SpeedX = enemyCurrentSpeed;
                                    enemy.AttachedBomb = null;
                                }
                                if (enemy.Spit != null)
                                {
                                    this.RemoveChild(enemy.Spit, true);
                                    enemy.Spit = null;
                                }
                                if (goingDown <= 32) enemy.SpeedX = enemyCurrentSpeed;
                                enemy.Explosion = new CCSprite(ssEnemyExplosion.Frames.Find(item => item.TextureFilename == "General_enemy_explosion00.png"));
                                enemy.Explosion.Position = new CCPoint(enemy.Sprite.PositionX, enemy.Sprite.PositionY - enemy.Sprite.ContentSize.Height / 2);
                                enemy.Explosion.AnchorPoint = new CCPoint(0.5f, 0.5f);
                                enemy.Explosion.BlendFunc = GameEnvironment.BlendFuncDefault;
                                this.AddChild(enemy.Explosion, 25);
                            }
                            else
                            {
                                if (VoiceEnemyWound1 != null)
                                {
                                    int r = random.Next(VoiceEnemyWound3 == null ? 2 : 3);
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
                                if (random.Next(2) == 0)
                                {
                                    enemy.State = ENEMYSTATE.DAMAGE1;
                                    if (enemy.OpenMouth != null)
                                    {
                                        this.RemoveChild(enemy.OpenMouth);
                                        enemy.OpenMouth = new CCSprite(GameEnvironment.ImageDirectory + EnemyMouthOpenDamaged1, new CCRect(0, 0, EnemyMouthClipWidth, EnemyMouthClipHeight));
                                        enemy.OpenMouth.Position = new CCPoint(enemy.Sprite.PositionX, enemy.Sprite.PositionY);
                                        enemy.OpenMouth.AnchorPoint = new CCPoint(0.5f, 1);
                                        enemy.OpenMouth.BlendFunc = GameEnvironment.BlendFuncDefault;
                                        this.AddChild(enemy.OpenMouth, enemy.Sprite.ZOrder + 2);

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
                                        this.RemoveChild(enemy.OpenMouth);
                                        enemy.OpenMouth = new CCSprite(GameEnvironment.ImageDirectory + EnemyMouthOpenDamaged2, new CCRect(0, 0, EnemyMouthClipWidth, EnemyMouthClipHeight));
                                        enemy.OpenMouth.Position = new CCPoint(enemy.Sprite.PositionX, enemy.Sprite.PositionY);
                                        enemy.OpenMouth.AnchorPoint = new CCPoint(0.5f, 1);
                                        enemy.OpenMouth.BlendFunc = GameEnvironment.BlendFuncDefault;
                                        this.AddChild(enemy.OpenMouth, enemy.Sprite.ZOrder + 2);

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
                            if (bullets[i].Power <= 0)
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
                    if (bullets[i].Power == bulletPower)
                    {
                        bulletsMissed++;
                        killsWithoutMiss = 0;
                        if (scoreMultiplier > 1)
                        {
                            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.MULTIPLIER_LOST);
                            scoreMultiplier = 1;
                        }
                        if (VoiceMiss != null)
                        {
                            if (VoiceMissAlternate != null && random.Next(3) == 0)
                            {
                                CCAudioEngine.SharedEngine.PlayEffect(VoiceMissAlternate);
                            }
                            else
                            {
                                CCAudioEngine.SharedEngine.PlayEffect(VoiceMiss);
                            }
                        }
                    }
                    this.RemoveChild(bullet, true);
                    bullets.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }



            for (int i = 0; i < bombs.Count;)
            {
                bool bombRemoved = false;
                Bomb bomb = bombs[i];

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
                    bomb.Sprite.TextureRectInPixels = ssBomb.Frames.Find(item => item.TextureFilename == "bomb-animation-image-" + Convert.ToInt32(bomb.Rotation).ToString() + ".png").TextureRectInPixels;
                }
                else
                {
                    if (Convert.ToInt32(bomb.Rotation) > 14) bomb.Rotation = 0;
                    bomb.Sprite.TextureRectInPixels = ssBomb.Frames.Find(item => item.TextureFilename == "slime-ball-image_" + Convert.ToInt32(bomb.Rotation).ToString() + ".png").TextureRectInPixels;
                }


                if (!bomb.Collided && inRectangle(bomb.Sprite.BoundingBox, PlayerCollisionPoints, player.PositionX, player.PositionY + player.ContentSize.Height, SelectedEnemy == ENEMIES.ALIENS ? 7 : 0, SelectedEnemy == ENEMIES.ALIENS ? 7 : 0))
                {
                    //bomb.SpeedY = -random.Next(2, Convert.ToInt32(Math.Abs(bomb.SpeedY) * 100)) / 100f;
                    //bomb.SpeedX = random.Next(Convert.ToInt32(Math.Abs(bomb.SpeedY) * 100)) / 100f;
                    //if (bomb.Sprite.PositionX < player.PositionX + player.ContentSize.Width / 2) bomb.SpeedX = -bomb.SpeedX;
                    //bomb.SpeedX += move;
                    //bomb.RotationSpeed = random.Next(50) / 5;
                    bomb.Collided = true;


                    if (playerExplosion == null)
                    {
                        //bomb.Destroy();
                        //bombs.Remove(bomb);
                        //bombRemoved = true;
                        playerExplode();

                        Explosion explo = new Explosion(this, Convert.ToInt32(bomb.Sprite.PositionX), Convert.ToInt32(bomb.Sprite.PositionY));
                        explos.Add(explo);



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
                    bombs.Remove(bomb);

                }
                else if (!bombRemoved)
                {
                    i++;
                }
            }


            if (playerExplosion != null)
            {
                if (playerExploding > 72)
                {
                    scoreMultiplier = 1;
                    playerExplosion.Visible = false;
                    if (playerExploding > 150 && bombs.Count == 0 && this.lives.Count > 0)
                    {
                        this.RemoveChild(lives[lives.Count - 1], true);
                        lives.RemoveAt(lives.Count - 1);
                        this.RemoveChild(playerExplosion, true);
                        playerExplosion = null;
                        player.Visible = true;
                    }
                }
                else
                {
                    if (Convert.ToInt32(playerExploding) < 54)
                    {
                        playerExplosion.TextureRectInPixels = ssCannonExplosion1.Frames.Find(item => item.TextureFilename == "General_cannon_explosion_" + Convert.ToInt32(playerExploding).ToString().PadLeft(2, '0') + ".png").TextureRectInPixels;
                    }
                    else
                    {
                        if (playerExplosion.Texture != ssCannonExplosion2.Frames.Find(item => item.TextureFilename == "General_cannon_explosion_54.png").Texture)
                        {
                            CCSprite newPlayerExplosion = new CCSprite(ssCannonExplosion2.Frames.Find(item => item.TextureFilename == "General_cannon_explosion_54.png"));
                            newPlayerExplosion.AnchorPoint = new CCPoint(0.5f, 0);
                            newPlayerExplosion.PositionX = playerExplosion.PositionX;
                            newPlayerExplosion.PositionY = playerExplosion.PositionY;
                            this.AddChild(newPlayerExplosion, playerExplosion.ZOrder);
                            this.RemoveChild(playerExplosion, true);
                            playerExplosion = newPlayerExplosion;
                        }
                        playerExplosion.TextureRectInPixels = ssCannonExplosion2.Frames.Find(item => item.TextureFilename == "General_cannon_explosion_" + Convert.ToInt32(playerExploding).ToString().PadLeft(2, '0') + ".png").TextureRectInPixels;
                    }
                    playerExplosion.BlendFunc = GameEnvironment.BlendFuncDefault;
                    if (playerExploding > 40)
                    {
                        playerExplosion.Opacity = Convert.ToByte(256 - (playerExploding - 40) * 7);
                        player.Visible = false;
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
                playerExploding += 1f;
                if (playerExploding > 30 && gameOver && gameOverExplosion == null)
                {
                    gameOverExplosion = new CCSprite(ssGameOverExplosion.Frames.Find(item => item.TextureFilename == "Game-over-explosion-image-00.png"));
                    gameOverExplosion.PositionX = 0; // player.PositionX + player.ContentSize.Width / 2;
                    gameOverExplosion.PositionY = 0; //player.PositionY;
                    gameOverExplosion.AnchorPoint = new CCPoint(0, 0);
                    gameOverExplosion.Scale = 4;
                    gameOverExploding = 0;
                    this.AddChild(gameOverExplosion, 998);

                }
            }
            if (gameOverExplosion != null)
            {
                if (Convert.ToInt32(gameOverExploding) <= 56)
                {
                    gameOverExplosion.TextureRectInPixels = ssGameOverExplosion.Frames.Find(item => item.TextureFilename == "Game-over-explosion-image-" + Convert.ToInt32(gameOverExploding).ToString().PadLeft(2, '0') + ".png").TextureRectInPixels;
                    gameOverExplosion.BlendFunc = GameEnvironment.BlendFuncDefault;
                    gameOverExplosion.Scale = 4;
                    //playerExplosion.Scale = 4;
                    //if (gameOverExploding < 30)
                    //{
                    //    gameOverExplosion.Opacity = Convert.ToByte(120 + gameOverExploding * 4);
                    //}
                    //else
                    //{
                    //    gameOverExplosion.Opacity = byte.MaxValue;
                    //}
                    gameOverLabel.AnchorPoint = new CCPoint(0.5f, 0.5f);
                    gameOverLabel.ScaleX *= 1.001f;
                    gameOverLabel.ScaleY *= 1.001f;
                }
                else
                {
                    this.ScheduleOnce(GameOver, 1.6f);
                    gameOverExplosion = null;

                }
                gameOverExploding += 0.39f;

            }

            for (int i = 0; i < sparks.Count;)
            {
                LaserSpark laserSpark = sparks[i];

                laserSpark.Frame++;
                if (laserSpark.Frame > 40)
                {
                    laserSpark.Destroy();
                    sparks.Remove(laserSpark);
                }
                else
                {
                    laserSpark.Sprite.TextureRectInPixels = ssLaserSparks.Frames.Find(item => item.TextureFilename == "Alien-laser-hitting-animation-without-laser-image_" + Convert.ToInt32(laserSpark.Frame).ToString().PadLeft(2, '0') + ".png").TextureRectInPixels;
                    i++;
                }
            }

            bool bounce = false;

            bool inFsRect = false;
            CCRect fsRect = new CCRect(0, 550, 1136, 230);

            for (int i = 0; i < enemies.Count; i++)
            {
                Enemy enemy = enemies[i];


                if (!enemy.Killed)
                {
                    if (fsRect.IntersectsRect(enemy.Sprite.BoundingBox)) inFsRect = true;

                    if (enemy.Sprite.PositionX - enemy.floatX > wavePass && enemy.waveAY == 0)
                    {
                        enemy.waveAY = enemySpeed == 0 ? 2f / 180f : enemySpeed / 180f;
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
                        if (random.Next(20) == 0)
                        {
                            enemy.floatVX = (random.Next(100) - 50f) / 600f * (enemySpeed == 0 ? 2f : enemySpeed);
                            enemy.floatVY = (random.Next(100) - 50f) / 1200f * (enemySpeed == 0 ? 2f : enemySpeed);
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


                    if (random.Next(90) == 0)
                    {
                        enemy.floatVX = (random.Next(100) - 50f) / 600f * (enemySpeed == 0 ? 2f : enemySpeed);
                        enemy.floatVY = (random.Next(100) - 50f) / 1200f * (enemySpeed == 0 ? 2f : enemySpeed);
                    }
                    if (random.Next(400) == 0)
                    {
                        enemy.floatVX = (random.Next(100) - 50f) / 240f * (enemySpeed == 0 ? 2f : enemySpeed);
                        enemy.floatVY = (random.Next(100) - 50f) / 800f * (enemySpeed == 0 ? 2f : enemySpeed);
                    }

                    if (enemy.Spit != null)
                    {
                        enemy.Spitting += 0.5f;
                        if (Convert.ToInt32(enemy.Spitting) < 27)
                        {
                            if (SelectedEnemy == ENEMIES.ALIENS)
                            {
                                enemy.Spit.TextureRectInPixels = ssDrooling.Frames.Find(item => item.TextureFilename == "Alien_spitting" + Convert.ToInt32(enemy.Spitting).ToString().PadLeft(2, '0') + ".png").TextureRectInPixels;
                                enemy.Spit.Scale = 0.4f;
                            }
                            else
                            {
                                enemy.Spit.TextureRectInPixels = ssDrooling.Frames.Find(item => item.TextureFilename == "drooling_image_" + Convert.ToInt32(enemy.Spitting).ToString().PadLeft(2, '0') + ".png").TextureRectInPixels;
                            }
                            enemy.Spit.BlendFunc = GameEnvironment.BlendFuncDefault;
                            enemy.Spit.ZOrder = 997;
                        }
                        else
                        {
                            this.RemoveChild(enemy.Spit, true);
                            enemy.Spit = null;
                        }
                    }
                    if (enemy.AttachedBomb != null && !enemy.AttachedBomb.Spitted && enemy.AttachedBomb.Sprite.PositionY < enemy.Sprite.PositionY - 3 - enemy.Sprite.ContentSize.Height / 2)
                    {
                        if (SelectedEnemy == ENEMIES.ALIENS)
                        {
                            int r = random.Next(3);
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
                            int r = random.Next(4);
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
                                enemy.Spit = new CCSprite(ssDrooling.Frames.Find(item => item.TextureFilename == "Alien_spitting01.png"));
                                enemy.Spitting = 1;
                                enemy.Spit.Scale = 0.4f;
                            }
                            else
                            {
                                enemy.Spit = new CCSprite(ssDrooling.Frames.Find(item => item.TextureFilename == "drooling_image_00.png"));
                                enemy.Spitting = 0;
                            }
                            enemy.Spit.ZOrder = enemy.Sprite.ZOrder + 1;
                            enemy.Spit.AnchorPoint = new CCPoint(0.5f, 1f);
                            enemy.Spit.PositionX = enemy.Sprite.PositionX;
                            enemy.Spit.PositionY = enemy.Sprite.PositionY - this.EnemyMouthClipHeight;
                            enemy.Spit.Opacity = 200;
                            this.AddChild(enemy.Spit, enemy.Sprite.ZOrder + 1);
                        }
                    }
                    if (enemy.AttachedBomb != null && enemy.AttachedBomb.Sprite.PositionY < enemy.Sprite.PositionY - 52 - enemy.Sprite.ContentSize.Height / 2)
                    {
                        enemy.BombOut();
                        int r = random.Next(3);
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
                        if (goingDown <= 0) enemy.AttachedBomb.SpeedX = enemyCurrentSpeed;
                        enemy.AttachedBomb = null;
                    }

                    enemy.Sprite.PositionY -= goingDownCurrentSpeed;
                    if (enemy.AttachedBomb != null) enemy.AttachedBomb.Sprite.PositionY -= goingDownCurrentSpeed;
                    enemy.Sprite.PositionY += enemy.waveVY;
                    if (enemy.AttachedBomb != null) enemy.AttachedBomb.Sprite.PositionY += enemy.waveVY;
                    if (goingDown <= 32)
                    {
                        enemy.Sprite.PositionX += enemyCurrentSpeed;
                        if (enemy.AttachedBomb != null) enemy.AttachedBomb.Sprite.PositionX = enemy.Sprite.PositionX + (SelectedEnemy == ENEMIES.PUTIN ? 2 : 0);
                    }
                    if (!bounce && enemyAcceleration == 0 && enemy.Sprite.PositionX < 100 && enemyCurrentSpeed < 0)
                    {
                        bounce = true;
                    }
                    if (!bounce && enemyAcceleration == 0 && enemy.Sprite.PositionX > 1136 - 100 && enemyCurrentSpeed > 0)
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
                            enemy.Spit.PositionX += enemyCurrentSpeed / 1.5f;
                        }
                        else
                        {
                            enemy.Spit.PositionX += enemyCurrentSpeed / 2;
                        }
                        enemy.Spit.PositionY = enemy.Sprite.PositionY - this.EnemyMouthClipHeight;
                    }

                    if (updateTillNextBomb == 0 && random.Next(enemies.Count + 32) == 0 && enemy.AttachedBomb == null && playerExplosion == null && enemy.Spit == null && !enemy.Killed && launchMode == LAUNCH_MODE.DEFAULT && !firstGoingDown && (SelectedEnemy != ENEMIES.ALIENS || enemy.State == ENEMYSTATE.NORMAL))
                    {
                        Bomb bomb = new Bomb(this, enemy.Sprite.PositionX + (SelectedEnemy == ENEMIES.PUTIN ? 2 : 0), enemy.Sprite.PositionY - 21);
                        bombs.Add(bomb);
                        enemy.AttachedBomb = bomb;
                        enemy.OpenForBomb();
                        bomb.Sprite.ZOrder = enemy.Sprite.ZOrder + 1;
                        updateTillNextBomb = random.Next(bombDensity);
                    }

                    if (enemy.LensFlare != null)
                    {
                        int sheet = 0;
                        if (Convert.ToInt32(enemy.LensFlareFrame) > 41) sheet = 1;

                        if (enemy.LensFlare.Texture != ssAlienLensFlare[sheet].Frames.Find(item => item.TextureFilename == "alien-laser-lens-flair-image_" + Convert.ToInt32(enemy.LensFlareFrame).ToString().PadLeft(2, '0') + ".png").Texture)
                        {
                            CCSprite newLensFlare = new CCSprite(ssAlienLensFlare[sheet].Frames.Find(item => item.TextureFilename == "alien-laser-lens-flair-image_" + Convert.ToInt32(enemy.LensFlareFrame).ToString().PadLeft(2, '0') + ".png"));
                            newLensFlare.AnchorPoint = new CCPoint(0.3445f, 0.6563f);
                            newLensFlare.PositionX = enemy.Sprite.PositionX;
                            newLensFlare.PositionY = enemy.Sprite.PositionY - 28;

                            this.AddChild(newLensFlare, enemy.LensFlare.ZOrder);
                            this.RemoveChild(enemy.LensFlare, true);
                            enemy.LensFlare = newLensFlare;
                        }

                        enemy.LensFlare.TextureRectInPixels = ssAlienLensFlare[sheet].Frames.Find(item => item.TextureFilename == "alien-laser-lens-flair-image_" + Convert.ToInt32(enemy.LensFlareFrame).ToString().PadLeft(2, '0') + ".png").TextureRectInPixels;

                        enemy.LensFlare.PositionX = enemy.Sprite.PositionX;
                        enemy.LensFlare.PositionY = enemy.Sprite.PositionY - 28;

                        enemy.LensFlare.BlendFunc = GameEnvironment.BlendFuncDefault;
                        enemy.LensFlareFrame += 0.41f;
                        if (Convert.ToInt32(enemy.LensFlareFrame) > 73)
                        {
                            this.RemoveChild(enemy.LensFlare, true);
                            enemy.LensFlare = null;
                        }
                    }

                    if (SelectedEnemy == ENEMIES.ALIENS)
                    {
                        bool hasEnemyBelow = false;
                        CCRect r = new CCRect(enemy.Sprite.BoundingBox.LowerLeft.X, enemy.Sprite.BoundingBox.LowerLeft.Y - 1300, enemy.Sprite.ContentSize.Width, 1300);

                        foreach (Enemy x in enemies)
                        {
                            if (x != enemy && r.IntersectsRect(x.Sprite.BoundingBox))
                            {
                                hasEnemyBelow = true;
                                break;
                            }
                        }
                        if (playerExplosion != null && playerExploding > 40 && (enemy.State == ENEMYSTATE.GRIMACE1 || enemy.State == ENEMYSTATE.GRIMACE2))
                        {
                            if (enemy.LaserFxId1 != null) CCAudioEngine.SharedEngine.StopEffect(enemy.LaserFxId1.Value);
                            if (enemy.LaserFxId2 != null) CCAudioEngine.SharedEngine.StopEffect(enemy.LaserFxId2.Value);
                            if (enemy.LaserFxId3 != null) CCAudioEngine.SharedEngine.StopEffect(enemy.LaserFxId3.Value);

                            if (enemy.LensFlare != null) this.RemoveChild(enemy.LensFlare, true);
                            enemy.LensFlare = null;
                            enemy.State = ENEMYSTATE.NORMAL;
                            enemy.Sprite.Texture = new CCTexture2D(GameEnvironment.ImageDirectory + EnemyMouthClosed);
                            enemy.Sprite.BlendFunc = GameEnvironment.BlendFuncDefault;
                            if (enemy.LaserTop != null) enemy.LaserTop.Visible = false;
                            enemy.keepGrimace = 1.5f + random.Next(10) / 2;
                        }
                        if (enemy.OpenMouth == null && random.Next(800) == 0 && enemy.State == ENEMYSTATE.NORMAL && enemy.keepGrimace <= 0 && !firstGoingDown && !hasEnemyBelow && playerExplosion == null)
                        {
                            if (random.Next(2) == 0)
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

                            enemy.LensFlare = new CCSprite(ssAlienLensFlare[0].Frames.Find(item => item.TextureFilename == "alien-laser-lens-flair-image_00.png"));
                            enemy.LensFlare.AnchorPoint = new CCPoint(0.3445f, 0.6563f);
                            enemy.LensFlare.PositionX = enemy.Sprite.PositionX;
                            enemy.LensFlare.PositionY = enemy.Sprite.PositionY - 28;
                            this.AddChild(enemy.LensFlare, 24);
                            enemy.LensFlareFrame = 0;
                        }

                    }
                    else
                    {

                        if (enemy.OpenMouth == null && random.Next(200) == 0 && enemy.State == ENEMYSTATE.NORMAL && enemy.keepGrimace <= 0)
                        {
                            if (random.Next(2) == 0)
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
                            enemy.keepGrimace = 0.5f + random.Next(10) / 2;
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

                    bool laserRemoved = false;
                    for (int j = 0; j < enemy.Lasers.Count;)
                    {
                        Laser laser = enemy.Lasers[j];
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
                            if (playerExplosion == null || playerExploding < 25)
                            {
                                CCRect r = new CCRect(laser.Sprite.PositionX - 5, laser.Sprite.PositionY, 10, laser.Sprite.ContentSize.Height);
                                float y = inRectangleTopY(r, PlayerCollisionPoints, player.PositionX, player.PositionY + player.ContentSize.Height);
                                if (y != -1)
                                {
                                    laser.LaserHit = true;
                                    laser.Sprite.ScaleY = 1 - ((y - laser.Sprite.PositionY) / laser.Sprite.ContentSize.Height);
                                    laser.Sprite.PositionY = y;
                                    if (playerExplosion == null)
                                    {
                                        playerExplode();
                                    }


                                    if (laser.Left && enemy.LaserLeftSparkCooloff <= 0)
                                    {
                                        sparks.Add(new LaserSpark(this, laser.Sprite.PositionX, y));
                                        enemy.LaserLeftSparkCooloff = 8;
                                    }
                                    if (!laser.Left && enemy.LaserRightSparkCooloff <= 0)
                                    {
                                        sparks.Add(new LaserSpark(this, laser.Sprite.PositionX, y));
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
                            enemy.keepGrimace = 0.5f + random.Next(10) / 2;
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
                                    this.AddChild(enemy.LaserTop, 11);
                                }
                                else if (enemy.LaserTop.Visible == false)
                                {
                                    enemy.LaserTop.Visible = true;
                                }
                                enemy.LaserTop.PositionX = enemy.Sprite.PositionX;
                                enemy.LaserTop.PositionY = enemy.Sprite.PositionY - 35;
                                Laser laser = new Laser(this, true);
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
                        this.RemoveChild(enemy.LaserTop);
                        enemy.LaserTop = null;
                    }
                    bool laserRemoved = false;
                    for (int j = 0; j < enemy.Lasers.Count;)
                    {
                        Laser laser = enemy.Lasers[j];
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
                            if (playerExplosion == null || playerExploding < 25)
                            {
                                CCRect r = new CCRect(laser.Sprite.PositionX - 5, laser.Sprite.PositionY, 10, laser.Sprite.ContentSize.Height);
                                float y = inRectangleTopY(r, PlayerCollisionPoints, player.PositionX, player.PositionY + player.ContentSize.Height);
                                if (y != -1)
                                {
                                    laser.LaserHit = true;
                                    laser.Sprite.ScaleY = 1 - ((y - laser.Sprite.PositionY) / laser.Sprite.ContentSize.Height);
                                    laser.Sprite.PositionY = y;
                                    if (playerExplosion == null)
                                    {
                                        playerExplode();
                                    }

                                    if (laser.Left && enemy.LaserLeftSparkCooloff <= 0)
                                    {
                                        sparks.Add(new LaserSpark(this, laser.Sprite.PositionX, y));
                                        enemy.LaserLeftSparkCooloff = 8;
                                    }
                                    if (!laser.Left && enemy.LaserRightSparkCooloff <= 0)
                                    {
                                        sparks.Add(new LaserSpark(this, laser.Sprite.PositionX, y));
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
                        enemy.Explosion.TextureRectInPixels = ssEnemyExplosion.Frames.Find(item => item.TextureFilename == "General_enemy_explosion" + Convert.ToInt32(enemy.Exploding).ToString().PadLeft(2, '0') + ".png").TextureRectInPixels;
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
                        enemies.Remove(enemy);
                        i--;

                    }
                }

                if (playerExplosion == null && !enemy.Killed && enemy.Sprite != null && inRectangle(enemy.Sprite.BoundingBox, PlayerCollisionPoints, player.PositionX, player.PositionY + player.ContentSize.Height))
                {
                    playerExplode(true);
                }
                if (playerExplosion == null && enemy.Sprite != null && enemy.Sprite.PositionY < 80)
                {
                    playerExplode(true);
                }
            }
            if (goingDown > 0)
            {
                if (goingDownCurrentSpeed < goingDownSpeed) goingDownCurrentSpeed += goingDownSpeed / 30f;
            }
            goingDown -= goingDownCurrentSpeed;
            if (goingDown <= 0 && goingDownCurrentSpeed > 0)
            {
                goingDownCurrentSpeed -= goingDownSpeed / 20f;
                if (goingDownCurrentSpeed <= 0)
                {
                    goingDownCurrentSpeed = 0;
                    if (firstGoingDown)
                    {
                        enemyAcceleration = enemySpeed / 30f;
                        firstGoingDown = false;
                        if (VoiceGameOver != "" && SelectedEnemy == ENEMIES.TRUMP) CCAudioEngine.SharedEngine.PlayEffect(VoiceGameOver);
                    }
                }
            }


            if (flyingSaucer != null)
            {
                flyingSaucerFrame += 0.5f;
                if (Convert.ToInt32(flyingSaucerFrame) > 59) flyingSaucerFrame = 0;
                flyingSaucer.TextureRectInPixels = ssFlyingSaucer.Frames.Find(item => item.TextureFilename == "Flying-saucer-image_" + Convert.ToInt32(flyingSaucerFrame).ToString().PadLeft(2, '0') + ".png").TextureRectInPixels;
                flyingSaucer.BlendFunc = GameEnvironment.BlendFuncDefault;
                flyingSaucer.PositionX += flyingSaucerSpeed;
                if ((flyingSaucer.PositionX > 1136 && flyingSaucerSpeed > 0) || (flyingSaucer.PositionX < -126 && flyingSaucerSpeed < 0))
                {
                    CCAudioEngine.SharedEngine.StopEffect(flyingSaucerFlyingFxId.Value);
                    this.RemoveChild(flyingSaucer, true);
                    flyingSaucerWait = 60;
                    flyingSaucer = null;
                }
            }
            if (/*!inFsRect &&*/ flyingSaucerWait <= 0 && flyingSaucerIncoming <= 0 && flyingSaucer == null && random.Next(300 + (lives.Count * 200)) == 1 && playerExplosion == null && flyingSaucerExplosion == null && SelectedEnemy == ENEMIES.ALIENS && lives.Count < 4 && enemies.Count >= 16 && wave > 2)
            {
                flyingSaucerIncoming = 2;
                flyingSaucerFlyingFxId = GameEnvironment.PlaySoundEffect(SOUNDEFFECT.FLYINGSAUCER_INCOMING);
            }
            else if (flyingSaucerWait > 0)
            {
                flyingSaucerWait -= dt;
            }

            if (flyingSaucerIncoming > 0 && playerExplosion == null)
            {
                flyingSaucerIncoming -= dt;
                if (flyingSaucerIncoming <= 0)
                {
                    CCAudioEngine.SharedEngine.StopEffect(flyingSaucerFlyingFxId.Value);
                    flyingSaucerFlyingFxId = GameEnvironment.PlaySoundEffect(SOUNDEFFECT.FLYINGSAUCER_FLYING);
                    flyingSaucerFrame = 0;
                    flyingSaucer = new CCSprite(ssFlyingSaucer.Frames.Find(item => item.TextureFilename == "Flying-saucer-image_00.png"));
                    if (random.Next(2) == 0)
                    {
                        flyingSaucer.Position = new CCPoint(1210, 560);
                        flyingSaucerSpeed = -5;
                    }
                    else
                    {
                        flyingSaucer.Position = new CCPoint(-200, 560);
                        flyingSaucerSpeed = 5;
                    }
                    flyingSaucer.BlendFunc = GameEnvironment.BlendFuncDefault;
                    this.AddChild(flyingSaucer);
                }
            }


            if (flyingSaucerExplosion != null)
            {
                flyingSaucerExplosionFrame += 0.5f;

                flyingSaucerExplosion.PositionX += flyingSaucerSpeed;

                if (flyingSaucerExplosionFrame > 8)
                {
                    flyingSaucerExplosion.Opacity = Convert.ToByte(280 - Convert.ToInt32(flyingSaucerExplosionFrame * 7));
                }

                if (flyingSaucer != null) { flyingSaucer.Opacity -= 10; }

                if (Convert.ToInt32(flyingSaucerExplosionFrame) > 8 && flyingSaucer != null)
                {
                    this.RemoveChild(flyingSaucer);
                    flyingSaucer = null;
                }

                if (Convert.ToInt32(flyingSaucerExplosionFrame) > 29)
                {
                    this.RemoveChild(flyingSaucerExplosion);
                    flyingSaucerExplosion = null;
                }
                else
                {
                    flyingSaucerExplosion.TextureRectInPixels = ssEnemyExplosion.Frames.Find(item => item.TextureFilename == "General_enemy_explosion" + Convert.ToInt32(flyingSaucerExplosionFrame).ToString().PadLeft(2, '0') + ".png").TextureRectInPixels;
                    flyingSaucerExplosion.BlendFunc = GameEnvironment.BlendFuncDefault;
                }
            }

            if (bounce)
            {
                enemyAcceleration = -enemyCurrentSpeed / 30f;
                bounces++;
                if (bounces > 4)
                {
                    goingDown = 32;
                    bounces = 0;
                }
            }
            enemyCurrentSpeed += enemyAcceleration;
            if (enemyCurrentSpeed < -enemySpeed)
            {
                enemyAcceleration = 0;
                enemyCurrentSpeed = -enemySpeed;
            }
            if (enemyCurrentSpeed > enemySpeed)
            {
                enemyAcceleration = 0;
                enemyCurrentSpeed = enemySpeed;
            }

            if (updateTillNextBomb > 0) updateTillNextBomb--;


            if (enemies.Count == 0 && bombs.Count == 0 && playerExplosion == null && !waveTransfer)
            {
                waveTransfer = true;
                if (SelectedEnemy == ENEMIES.ALIENS)
                {
                    GameEnvironment.PlayMusic(MUSIC.NEXTWAVEALIEN);
                    if (Settings.Instance.VoiceoversEnabled)
                    {
                        CCAudioEngine.SharedEngine.PlayEffect("Sounds/get ready for next wave VO_mono.wav");
                    }
                    this.nextWaveSprite = this.AddImageCentered(1136 / 2 - 50, 630 / 2, "UI/get-ready-for-next-wave-alien-text.png", 100);
                    this.nextWaveNumberSprites = this.AddImageLabel(Convert.ToInt32(this.nextWaveSprite.PositionX + this.nextWaveSprite.ContentSize.Width / 2), Convert.ToInt32(this.nextWaveSprite.PositionY - this.nextWaveSprite.ContentSize.Height / 2), (wave + 1).ToString(), 99);
                    this.ScheduleOnce(NextWave, 3);
                }
                else
                {
                    switch (wave)
                    {
                        case 1:
                            GameEnvironment.PlayMusic(MUSIC.NEXTWAVE);
                            this.nextWaveSprite = this.AddImageCentered(1136 / 2, 630 / 2, "UI/get-ready-for-next-wave-text.png", 100);
                            if (Settings.Instance.VoiceoversEnabled)
                            {
                                CCAudioEngine.SharedEngine.PlayEffect("Sounds/get ready for next wave VO_mono.wav");
                            }


                            if (SelectedBattleground == BATTLEGROUNDS.FINLAND)
                            {
                                _fireworkFrame = 1f;
                                this.ScheduleOnce(NextWave, 4.5f);
                            }
                            else
                            {
                                this.ScheduleOnce(NextWave, 3);
                            }
                            break;
                        case 2:

                            GameEnvironment.PlayMusic(MUSIC.NEXTWAVE);
                            this.nextWaveSprite = this.AddImageCentered(1136 / 2, 630 / 2, "UI/get-ready-for-final-wave-text.png", 100);
                            if (Settings.Instance.VoiceoversEnabled)
                            {
                                CCAudioEngine.SharedEngine.PlayEffect("Sounds/get ready for final wave VO_mono.wav");
                            }
                            if (SelectedBattleground == BATTLEGROUNDS.FINLAND)
                            {
                                _fireworkFrame = 1f;
                                this.ScheduleOnce(NextWave, 4.5f);
                            }
                            else
                            {
                                this.ScheduleOnce(NextWave, 3);
                            }
                            break;
                        case 3:
                            if (launchMode == LAUNCH_MODE.DEFAULT)
                            {
                                if (Settings.Instance.VoiceoversEnabled)
                                {
                                    CCAudioEngine.SharedEngine.PlayEffect("Sounds/Victory VO_mono.wav");
                                }
                                this.AddImageCentered(1136 / 2, 630 / 2, "UI/Battle-screen-victory!!!-text.png", 100);
                            }
                            GameEnvironment.PlaySoundEffect(SOUNDEFFECT.TEXTAPPEARS);
                            //this.UnscheduleAll();
                            if (SelectedBattleground == BATTLEGROUNDS.FINLAND)
                            {
                                _fireworkFrame = 1f;
                                this.ScheduleOnce(Victory, 4.5f);
                            }
                            if (SelectedBattleground == BATTLEGROUNDS.WHITE_HOUSE)
                            {
                                this.ScheduleOnce(Victory, 0.5f);
                            }
                            else
                            {
                                this.ScheduleOnce(Victory, 1);
                            }
                            break;
                    }
                }
            }

            if (wavePass > 0)
            {
                wavePass -= enemySpeed == 0 ? 4 : enemySpeed * 3;
            }


            if (nextWaveSprite != null)
            {
                if (nextWaveSprite.Opacity < 10)
                {
                    nextWaveSprite.Opacity = 255;
                }
                else if (nextWaveSprite.Opacity > 240)
                {
                    nextWaveSprite.Opacity -= 1;
                }
                else if (nextWaveSprite.Opacity > 225)
                {
                    nextWaveSprite.Opacity -= 2;
                }
                else if (nextWaveSprite.Opacity > 200)
                {
                    nextWaveSprite.Opacity -= 3;
                }
                else
                {
                    nextWaveSprite.Opacity -= 5;
                }
                if (timeLabel.Visible)
                {
                    timeLabel.Opacity = nextWaveSprite.Opacity;
                    foreach (CCSprite timeDigit in time)
                    {
                        timeDigit.Opacity = nextWaveSprite.Opacity;
                    }
                }
                if (nextWaveNumberSprites != null)
                {
                    foreach (CCSprite waveDigit in nextWaveNumberSprites)
                    {
                        waveDigit.Opacity = nextWaveSprite.Opacity;
                    }
                }
                if (multiplierLabel != null)
                {
                    multiplierLabel.Opacity = nextWaveSprite.Opacity;
                }
                if (multiplierLabelLabel != null && scoreMultiplier > 1)
                {
                    multiplierLabelLabel.Opacity = nextWaveSprite.Opacity;
                }
            }
        }

        void MoveCannon(float touchXPosition)
        {
            var movementButtonBoundingBox = btnMovement.BoundingBoxTransformedToWorld;

            int sensitivity = Settings.Instance.SensitivityLevel;

            bool forward = touchXPosition >= movementButtonBoundingBox.Center.X;

            float centerX = movementButtonBoundingBox.Center.X;
            int maxSensitivityLavel = 8;

            float btnSensitivity = GetSensitivityLvlOnPressedBtn(touchXPosition);

            if (Math.Round(btnSensitivity / 10) <= Settings.Instance.SensitivityLevel)
            {
                speedTo = 1;
            }
            else if (Math.Round(btnSensitivity / 10) > 8)
            {
                speedTo = 0;
            }
            else
            {
                speedTo = (float)Math.Round((maxSensitivityLavel + 1 - btnSensitivity / 10f) / (maxSensitivityLavel - Settings.Instance.SensitivityLevel + 1), 2);
            }

            if (forward)
            {
                speedTo *= -1;
            }
        }

        void OnTouchesBegan(List<CCTouch> touches, CCEvent touchEvent)
        {


            var movementButtonBoundingBox = btnMovement.BoundingBoxTransformedToWorld;
            var fireButtonBoundingBox = btnFire.BoundingBoxTransformedToWorld;

            foreach (var touch in touches)
            {
                if (RectangleWithin(movementButtonBoundingBox, touch.Location))
                {
                    isCannonMoving = true;

			//--------- Prabhjot ----------//
                    //int steerinButtonX = 3;
                    //int steeringButtonY = 2;
                    //btnMovement = AddButton(steerinButtonX, steeringButtonY, "UI/Controls/Steering arrow/080-transparent-movement-arrow-tapped.png", "UI/Controls/Steering arrow/040-transparent-movement-arrow-untapped.png", 200, BUTTON_TYPE.Silent);

                    MoveCannon(touch.Location.X);
                }
                else if (RectangleWithin(fireButtonBoundingBox, touch.Location))
                {
                    isCannonShooting = true;
                }
                else if (isCannonMoving && RectangleNear(movementButtonBoundingBox, touch.Location, 0, 60))
                {
                    isCannonMoving = true;
                    MoveCannon(touch.Location.X);
                }
                else if (isCannonMoving && RectangleNear(new CCRect(movementButtonBoundingBox.MinX, movementButtonBoundingBox.MinY - 60, movementButtonBoundingBox.MaxX - movementButtonBoundingBox.MinX, movementButtonBoundingBox.MaxY - movementButtonBoundingBox.MinY + 60), touch.Location, 65, 65))
                {
                    isCannonMoving = false;
                    speedTo = 0;
                    this.EndTouchOnBtn(btnMovement);
                }
                else if (isCannonShooting && RectangleNear(fireButtonBoundingBox, touch.Location, 50, 50))
                {
                    isCannonShooting = false;
                    this.EndTouchOnBtn(btnFire);
                }
            }
        }

        int GetSensitivityLvlOnPressedBtn(float touchPosition)
        {
            var movementButtonBoundingBox = btnMovement.BoundingBoxTransformedToWorld;
            var halfOfBtn = movementButtonBoundingBox.MaxX - movementButtonBoundingBox.Center.X;
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
            var movementButtonBoundingBox = btnMovement.BoundingBoxTransformedToWorld;
            var halfOfBtn = movementButtonBoundingBox.MaxX - movementButtonBoundingBox.Center.X;
            var btnSensStep = halfOfBtn / 100;

            return (int)Math.Ceiling(touchPositionOnBtn / btnSensStep);

        }


        void OnTouchesEnded(List<CCTouch> touches, CCEvent touchEvent)
        {

            if (btnMovement.BoundingBoxTransformedToWorld.ContainsPoint(touches[0].Location))
            {
                isCannonMoving = false;
                speedTo = 0;
            }

            if (btnFire.BoundingBoxTransformedToWorld.ContainsPoint(touches[0].Location))
            {
                isCannonShooting = false;
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
            RemoveChild(btnFire);
            RemoveChild(btnMovement);
            OnTouchBegan -= GamePlayLayer_OnTouchBegan;

            //var touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesBegan -= OnTouchesBegan;
            touchListener.OnTouchesEnded -= OnTouchesEnded;
            touchListener.OnTouchesMoved -= OnTouchesBegan;
            touchListener.OnTouchesBegan -= GamePlayLayer_OnTouchesBegan;
            touchListener.OnTouchesBegan -= GamePlayLayer_TouchResponse;

            speedTo = 0;

            if (Settings.Instance.ControlType == CONTROL_TYPE.MANUAL)
            {
                int fireButtonX = 918;
                int fireButtonY = 2;

                int steerinButtonX = 3;
                int steeringButtonY = 2;

                if (!Settings.Instance.RightHanded)
                {
                    fireButtonX = 3;
                    steerinButtonX = 715;
                }

                btnMovement = AddButton(steerinButtonX, steeringButtonY, "UI/Controls/Steering arrow/080-transparent-movement-arrow-untapped.png", "UI/Controls/Steering arrow/040-transparent-movement-arrow-tapped.png", 200, BUTTON_TYPE.Silent);

                touchListener.OnTouchesBegan += OnTouchesBegan;
                touchListener.OnTouchesBegan += GamePlayLayer_TouchResponse;
                touchListener.OnTouchesEnded += OnTouchesEnded;
                touchListener.OnTouchesMoved += OnTouchesBegan;

                btnFire = AddButton(fireButtonX, fireButtonY, "UI/Controls/Fire button/080-transparent-fire-button-untapped.png", "UI/Controls/Fire button/040-transparent-fire-button-tapped.png", 200, BUTTON_TYPE.Silent);

                btnFire.Visible = false;
                btnMovement.Visible = false;

                if (animatedControls)
                {
                    fadeLevel = 0;
                    Schedule(AnimateButtons, 0.16f);
                }
                else
                {
                    btnFire.Visible = true;
                    btnMovement.Visible = true;
                }
            }
            else
            {
                if (launchMode == LAUNCH_MODE.STEERING_TEST)
                {
                    touchListener.OnTouchesBegan += GamePlayLayer_OnTouchesBegan;
                }
                else
                {
                    this.OnTouchBegan += GamePlayLayer_OnTouchBegan;
                }
            }
            AddEventListener(touchListener, this);
        }
    }
}
