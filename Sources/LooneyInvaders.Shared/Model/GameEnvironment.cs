using System;
using CocosSharp;

namespace LooneyInvaders.Model
{
    public class GameEnvironment
    {
        public static readonly string ImageDirectory;

        static GameEnvironment()
        {
            ImageDirectory = "Images/Hd/";
        }

        public static CCBlendFunc BlendFuncDefault
        {
            get
            {
#if __IOS__
                return CCBlendFunc.AlphaBlend;
#endif
#if __ANDROID__
                return CCBlendFunc.NonPremultiplied;
#endif
            }
        }

        public static long GetTotalRamSizeMb()
        {
#if __ANDROID__

            var activityManager =
                Android.App.Application.Context
                    .GetSystemService(Android.Content.Context.ActivityService) as Android.App.ActivityManager;
            var memoryInfo = new Android.App.ActivityManager.MemoryInfo();
            activityManager?.GetMemoryInfo(memoryInfo);
            return memoryInfo.TotalMem / 1000000;
#endif
#if __IOS__
            return 1000;
#endif
        }

        //delegate void PlayWithDelayConditionallyDelegate(string conditionMusic, string newMusic, int delayms);
        //public static void PlayWithDelayConditionally(string conditionMusic, string newMusic, int delayms)
        //{
        //    DateTime startTime = DateTime.Now.AddMilliseconds(delayms);
        //    while (MusicPlaying == conditionMusic && DateTime.Now < startTime && !Shared.GameDelegate.gameView.Paused && CCAudioEngine.SharedEngine.BackgroundMusicPlaying)
        //    {
        //        System.Threading.Tasks.Task.Delay(10).Wait();
        //    }
        //    //System.Threading.Tasks.Task.Delay(delayms).Wait();
        //    if (MusicPlaying==conditionMusic)
        //    {
        //        PlayMusic(newMusic, false);
        //    }
        //}

        public static void PlayWithDelayConditionally(string conditionMusic, string newMusic, DateTime startTime)
        {
            while (MusicPlaying == conditionMusic && (DateTime.Now < startTime || Shared.GameDelegate.GameView.Paused ||
                                                      CCAudioEngine.SharedEngine.BackgroundMusicPlaying))
            {
                System.Threading.Tasks.Task.Delay(10).Wait();
            }

            if (MusicPlaying == conditionMusic)
            {
                PlayMusic(newMusic);
            }
        }

        public static string MusicPlaying = "";

        public static void PlayMusic(Music music, bool fromStart = false)
        {
            if (music == Music.MainMenu)
            {
                if (MusicPlaying == "Sounds/Victory.mp3" ||
                    MusicPlaying == "Sounds/07 - Looney Invaders Victory FINAL_part1_intro_segment.mp3" ||
                    MusicPlaying == "Sounds/07 - Looney Invaders Victory FINAL_part1_intro_segment.mp3")
                    return;

                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental)
                {
                    PlayMusic("Sounds/Main Menu Loopable2.mp3");
                }
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                {
                    if (MusicPlaying != "Sounds/02 - Main Menu FINAL_part1_intro_segment.mp3" &&
                        MusicPlaying != "Sounds/02 - Main Menu FINAL_part2_loop_segment.mp3")
                    {
                        PlayMusicOnce("Sounds/02 - Main Menu FINAL_part1_intro_segment.mp3");
                        System.Threading.Tasks.Task.Run(() =>
                            PlayWithDelayConditionally("Sounds/02 - Main Menu FINAL_part1_intro_segment.mp3",
                                "Sounds/02 - Main Menu FINAL_part2_loop_segment.mp3",
                                DateTime.Now.AddMilliseconds(54885)));
                        //PlayWithDelayConditionallyDelegate p = PlayWithDelayConditionally;
                        //IAsyncResult res = p.BeginInvoke("Sounds/02 - Main Menu FINAL_part1_intro_segment.mp3", "Sounds/02 - Main Menu FINAL_part2_loop_segment.mp3", 54885, null, null);
                    }
                }
            }
            else if (music == Music.SplashScreen)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental)
                    PlayMusicOnce("Sounds/Splash Intro instrumental.mp3");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                    PlayMusicOnce("Sounds/01 - Splash Intro FINAL.mp3");
            }
            else if (music == Music.GameOver)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental)
                {
                    PlayMusicOnce("Sounds/Game Over_part1.mp3");
                    System.Threading.Tasks.Task.Run(() => PlayWithDelayConditionally("Sounds/Game Over_part1.mp3",
                        "Sounds/Game over Loop_part2.mp3", DateTime.Now.AddMilliseconds(10500)));
                }
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                {
                    PlayMusicOnce("Sounds/09 - GameOver FINAL_part1_intro_segment.mp3");
                    System.Threading.Tasks.Task.Run(() =>
                        PlayWithDelayConditionally("Sounds/09 - GameOver FINAL_part1_intro_segment.mp3",
                            "Sounds/09 - GameOver FINAL_part2_loop_segment.mp3", DateTime.Now.AddMilliseconds(7000)));
                    //PlayWithDelayConditionallyDelegate p = PlayWithDelayConditionally;
                    //IAsyncResult res = p.BeginInvoke("Sounds/09 - GameOver FINAL_part1_intro_segment.mp3", "Sounds/09 - GameOver FINAL_part2_loop_segment.mp3", 7000, null, null);
                }
            }
            else if (music == Music.GameOverAlien)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental)
                {
                    PlayMusicOnce("Sounds/Space end screen part1.mp3");
                    System.Threading.Tasks.Task.Run(() =>
                        PlayWithDelayConditionally("Sounds/Space end screen part1.mp3",
                            "Sounds/Leaderboard space part2.mp3", DateTime.Now.AddMilliseconds(5000)));
                }
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                {
                    PlayMusicOnce("Sounds/17 - GameOver - Space Version-part1-intro-segment.mp3");
                    System.Threading.Tasks.Task.Run(() =>
                        PlayWithDelayConditionally("Sounds/17 - GameOver - Space Version-part1-intro-segment.mp3",
                            "Sounds/17 - GameOver - Space Version-part2-loop-segment.mp3",
                            DateTime.Now.AddMilliseconds(17800)));
                    //PlayWithDelayConditionallyDelegate p = PlayWithDelayConditionally;
                    //IAsyncResult res = p.BeginInvoke("Sounds/17 - GameOver - Space Version-part1-intro-segment.mp3", "Sounds/17 - GameOver - Space Version-part2-loop-segment.mp3", 17800, null, null);
                }
            }
            else if (music == Music.Victory)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental)
                {
                    PlayMusicOnce("Sounds/Victory_part1.mp3");
                    System.Threading.Tasks.Task.Run(() => PlayWithDelayConditionally("Sounds/Victory_part1.mp3",
                        "Sounds/Victory loop_part2.mp3", DateTime.Now.AddMilliseconds(14000)));
                }
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                {
                    PlayMusicOnce("Sounds/07 - Looney Invaders Victory FINAL_part1_intro_segment.mp3");
                    System.Threading.Tasks.Task.Run(() =>
                        PlayWithDelayConditionally("Sounds/07 - Looney Invaders Victory FINAL_part1_intro_segment.mp3",
                            "Sounds/07 - Looney Invaders Victory FINAL_part2_loop_segment.mp3",
                            DateTime.Now.AddMilliseconds(3000)));
                    //PlayWithDelayConditionallyDelegate p = PlayWithDelayConditionally;
                    //IAsyncResult res = p.BeginInvoke("Sounds/07 - Looney Invaders Victory FINAL_part1_intro_segment.mp3", "Sounds/07 - Looney Invaders Victory FINAL_part2_loop_segment.mp3", 3000, null, null);
                }
            }
            else if (music == Music.BattleWave1)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental)
                    PlayMusic("Sounds/Battle (MAJOR EDIT) wave 1 tune.mp3");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                    PlayMusic("Sounds/04 - Looney Invaders Battle Theme (Wave 1) FINAL.mp3");
            }
            else if (music == Music.BattleWave2)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental)
                    PlayMusic("Sounds/War (Battle II) wave 2 tune.mp3", true);
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                    PlayMusic("Sounds/05 - Looney Invaders Battle Theme (Wave 2) FINAL.mp3", true);
            }
            else if (music == Music.BattleWave3)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental)
                    PlayMusic("Sounds/Invasion (Battle III)  wave 3 tune.mp3", true);
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                    PlayMusic("Sounds/06 - Looney Invaders Battle Theme (Wave 3) FINAL.mp3", true);
            }

            else if (music == Music.BattleAlien1)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental)
                    PlayMusic("Sounds/Final Battle Theme speed -1 (111%).mp3", true);
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                    PlayMusic("Sounds/12 - Looney Invaders Battle Theme Prelude (Wave Final Attack 1-115%).mp3", true);
            }
            else if (music == Music.BattleAlien2)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental)
                    PlayMusic("Sounds/Final Battle Theme.mp3", true);
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                    PlayMusic("Sounds/12 - Looney Invaders Battle Theme Prelude (Wave Final Attack 1).mp3", true);
            }
            else if (music == Music.BattleAlien3)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental)
                    PlayMusic("Sounds/Final Battle Theme speed 2 (86%).mp3", true);
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                    PlayMusic("Sounds/12 - Looney Invaders Battle Theme Prelude (Wave Final Attack 1-85%).mp3", true);
            }
            else if (music == Music.BattleAlien4)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental)
                    PlayMusic("Sounds/Final Battle II.mp3", true);
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                    PlayMusic("Sounds/13 - Looney Invaders Battle Theme Prelude (Wave Final Attack 2-115%).mp3", true);
            }
            else if (music == Music.BattleAlien5)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental)
                    PlayMusic("Sounds/Final Battle II speed 2 (86%).mp3", true);
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                    PlayMusic("Sounds/13 - Looney Invaders Battle Theme Prelude (Wave Final Attack 2).mp3", true);
            }
            else if (music == Music.BattleAlien6)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental)
                    PlayMusic("Sounds/Final Battle II speed 3 (77%).mp3", true);
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                    PlayMusic("Sounds/13 - Looney Invaders Battle Theme Prelude (Wave Final Attack 2-85%).mp3", true);
            }
            else if (music == Music.BattleAlien7)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental)
                    PlayMusic("Sounds/Alien Battle theme 3 loop.mp3", true);
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                    PlayMusic("Sounds/14 - Looney Invaders Battle Theme Prelude (Wave Final Attack 3-115%).mp3", true);
            }
            else if (music == Music.BattleAlien8)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental)
                    PlayMusic("Sounds/Alien Battle theme 3 speed 2.mp3", true);
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                    PlayMusic("Sounds/14 - Looney Invaders Battle Theme Prelude (Wave Final Attack 3).mp3", true);
            }
            else if (music == Music.BattleAlien9)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental)
                    PlayMusic("Sounds/Alien Battle theme 3 speed 3.mp3", true);
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                    PlayMusic("Sounds/14 - Looney Invaders Battle Theme Prelude (Wave Final Attack 3-85%).mp3", true);
            }
            else if (music == Music.BattleCountdown)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental)
                {
                    PlayMusicOnce("Sounds/Battle Countdown Slower (prelude).mp3");
                    System.Threading.Tasks.Task.Run(() =>
                        PlayWithDelayConditionally("Sounds/Battle Countdown Slower (prelude).mp3",
                            "Sounds/Battle (MAJOR EDIT) wave 1 tune.mp3", DateTime.Now.AddMilliseconds(6000)));
                    //PlayWithDelayConditionallyDelegate p = PlayWithDelayConditionally;
                    //IAsyncResult res = p.BeginInvoke("Sounds/Battle Countdown Slower (prelude).mp3", "Sounds/Battle (MAJOR EDIT) wave 1 tune.mp3", 6000, null, null);
                }
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                {
                    PlayMusicOnce("Sounds/11 - Looney_Invaders_Battle_Theme_Prelude1.mp3");
                    System.Threading.Tasks.Task.Run(() =>
                        PlayWithDelayConditionally("Sounds/11 - Looney_Invaders_Battle_Theme_Prelude1.mp3",
                            "Sounds/04 - Looney Invaders Battle Theme (Wave 1) FINAL.mp3",
                            DateTime.Now.AddMilliseconds(6000)));
                    //PlayWithDelayConditionallyDelegate p = PlayWithDelayConditionally;
                    //IAsyncResult res = p.BeginInvoke("Sounds/11 - Looney_Invaders_Battle_Theme_Prelude1.mp3", "Sounds/04 - Looney Invaders Battle Theme (Wave 1) FINAL.mp3", 6000, null, null);
                }
            }
            else if (music == Music.BattleCountdownAlien)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental)
                {
                    PlayMusicOnce("Sounds/GET READY FOR ALIEN BATTLE.mp3");
                    System.Threading.Tasks.Task.Run(() =>
                        PlayWithDelayConditionally("Sounds/GET READY FOR ALIEN BATTLE.mp3",
                            "Sounds/Sounds/Final Battle Theme speed -1 (111%).mp3",
                            DateTime.Now.AddMilliseconds(6000)));
                    //PlayWithDelayConditionallyDelegate p = PlayWithDelayConditionally;
                    //IAsyncResult res = p.BeginInvoke("Sounds/GET READY FOR ALIEN BATTLE.mp3", "Sounds/Sounds/Final Battle Theme speed -1 (111%).mp3", 6000, null, null);

                }
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                {
                    PlayMusicOnce("Sounds/15 - Looney Invaders Battle Theme Space Prelude.mp3");
                    System.Threading.Tasks.Task.Run(() =>
                        PlayWithDelayConditionally("Sounds/11 - Looney_Invaders_Battle_Theme_Prelude1.mp3",
                            "Sounds/04 - Looney Invaders Battle Theme (Wave 1) FINAL.mp3",
                            DateTime.Now.AddMilliseconds(6000)));
                    //PlayWithDelayConditionallyDelegate p = PlayWithDelayConditionally;
                    //IAsyncResult res = p.BeginInvoke("Sounds/11 - Looney_Invaders_Battle_Theme_Prelude1.mp3", "Sounds/04 - Looney Invaders Battle Theme (Wave 1) FINAL.mp3", 6000, null, null);
                }
            }
            else if (music == Music.NextWave)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental)
                    PlayMusicOnce("Sounds/Battle Countdown (interlude).mp3");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                    PlayMusicOnce("Sounds/44 - Get Ready For The Next Attack.mp3");
            }
            else if (music == Music.NextWaveAlien)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental)
                    PlayMusicOnce("Sounds/Alien Interlude.mp3");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                    PlayMusicOnce("Sounds/111 - Get Ready For The Next Attack Space.mp3");
            }
        }

        public static void PlayMusic(string newMusic, bool fromStart = false)
        {
            if (newMusic == "") return;

            if (newMusic != MusicPlaying || fromStart || !CCAudioEngine.SharedEngine.BackgroundMusicPlaying)
            {
                CCAudioEngine.SharedEngine.StopBackgroundMusic();
                MusicPlaying = newMusic;
                //CCAudioEngine.SharedEngine.PlayBackgroundMusic(MusicPlaying, true);
                Shared.GameDelegate.Layer?.ScheduleOnce((_) => PlayBackgroundMusic(true), 0f);
            }
        }

        public static void PlayBackgroundMusic(bool looped = false)
        {
            CCAudioEngine.SharedEngine.PlayBackgroundMusic(MusicPlaying, looped);
        }

        public static void StopMusic()
        {
            CCAudioEngine.SharedEngine.StopBackgroundMusic();
            MusicPlaying = "";
        }

        public static void PlayMusicOnce(string newMusic)
        {
            CCAudioEngine.SharedEngine.StopBackgroundMusic();
            MusicPlaying = newMusic;
            CCAudioEngine.SharedEngine.PlayBackgroundMusic(MusicPlaying);
        }

        public static void OpenWebPage(string url)
        {   //ToDo: everyone - change that to Xamarin.Essentials
#if __IOS__
            UIKit.UIApplication.SharedApplication.OpenUrl(new Foundation.NSUrl(url));
#endif
#if __ANDROID__
            var uri = Android.Net.Uri.Parse(url);
            var intent = new Android.Content.Intent(Android.Content.Intent.ActionView, uri);
            intent.SetFlags(Android.Content.ActivityFlags.NewTask);
            Android.App.Application.Context.StartActivity(intent);
#endif
        }

        public static int? PlaySoundEffect(SoundEffect soundEffect)
        {
            try
            {
                switch (soundEffect)
                {
                    case SoundEffect.MenuTap when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/general button (Menu Selection change 1).wav");
                    case SoundEffect.MenuTap when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/General button (61).wav");
                    case SoundEffect.MenuTapBack when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect(
                            "Sounds/Back button (Menu Selection deselect (backwards) 2).wav");
                    case SoundEffect.MenuTapBack when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Back button (39).wav");
                    case SoundEffect.MenuTapForward when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Forward button (Menu Selection Select 2).wav");
                    case SoundEffect.MenuTapForward when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Forward button (38).wav");
                    case SoundEffect.MenuTapVolumeChange when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Volume Change.wav");
                    case SoundEffect.MenuTapVolumeChange when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Sound volume tester (06).wav");
                    case SoundEffect.MenuTapMinus when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Minus Sound 1.wav");
                    case SoundEffect.MenuTapMinus when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/- button (37).wav");
                    case SoundEffect.MenuTapPlus when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Plus Sound 1.wav");
                    case SoundEffect.MenuTapPlus when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/+ button (36).wav");
                    case SoundEffect.MenuTapCannotTap when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Cannot tap 1.wav");
                    case SoundEffect.MenuTapCannotTap when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Negative&Error (54).wav");
                    case SoundEffect.MenuTapCheckMark when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Check Sound 1.wav");
                    case SoundEffect.MenuTapCheckMark when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Checked (1).wav");
                    case SoundEffect.ClickLink when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect(
                            "Sounds/Click link effect (enemy or map change forward).wav");
                    case SoundEffect.ClickLink when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Click link effect (07).wav");
                    case SoundEffect.On when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect(
                            "Sounds/on button (Menu Selection deselect (backwards) 1).wav");
                    case SoundEffect.On when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/On button (41).wav");
                    case SoundEffect.Off when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/off button (Menu Selection Select 1).wav");
                    case SoundEffect.Off when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Off button (42).wav");
                    case SoundEffect.MenuTapCreditPurchase when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/purchase 3.wav");
                    case SoundEffect.MenuTapCreditPurchase when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Credit purchase (43).wav");
                    case SoundEffect.EnemyHurt1 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy - hurt 1.wav");
                    case SoundEffect.EnemyHurt1 when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy hit Sound When hurt (15).wav");
                    case SoundEffect.EnemyHurt2 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy - hurt 1.wav");
                    case SoundEffect.EnemyHurt2 when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy hit Sound When hurt (15).wav");
                    case SoundEffect.EnemyHurt3 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy - hurt 1.wav");
                    case SoundEffect.EnemyHurt3 when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy hit Sound When hurt (15).wav");
                    case SoundEffect.EnemyKilled when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy - killed .wav");
                    case SoundEffect.EnemyKilled when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy hit Sound When killed (21).wav");
                    case SoundEffect.EnemySpit when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Combines enemy attack 1.wav");
                    case SoundEffect.EnemySpit when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy drooling & bomb whistle (18 43)_1.wav");
                    case SoundEffect.EnemySpit2 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Combines enemy attack 2.wav");
                    case SoundEffect.EnemySpit2 when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy drooling & bomb whistle (18 43)_1.wav");
                    case SoundEffect.EnemySpit3 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Combines enemy attack 3.wav");
                    case SoundEffect.EnemySpit3 when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy drooling & bomb whistle (18 43)_2.wav");
                    case SoundEffect.EnemySpit4 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Combines enemy attack 4.wav");
                    case SoundEffect.EnemySpit4 when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy drooling & bomb whistle (18 43)_3.wav");
                    case SoundEffect.GunHit1 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Gun - Hit 1.wav");
                    case SoundEffect.GunHit1 when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Cannon explosion(49).wav");
                    case SoundEffect.GunHit2 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Gun - Hit 2.wav");
                    case SoundEffect.GunHit2 when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Cannon explosion(49).wav");
                    case SoundEffect.GunHit3 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Gun - Hit 3.wav");
                    case SoundEffect.GunHit3 when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Cannon explosion(49).wav");
                    case SoundEffect.GunHitGameOver when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Game Over Explosion(instrumental).wav");
                    case SoundEffect.GunHitGameOver when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/game over explosion.wav");
                    case SoundEffect.Calibre1 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Reloading (Calibre 2).wav");
                    case SoundEffect.Calibre1 when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Reloading (14 ).wav");
                    case SoundEffect.Calibre1Hybrid when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hybrid Canon Reload.wav");
                    //else if (soundEffect == SOUNDEFFECT.BOMB_FALL1)
                    //{
                    //    if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) { }// return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bomb fall 1 .wav");
                    //    else if (Settings.Instance.MusicStyle == MUSIC_STYLE.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Falling bomb (27__Bomb_Whistle_tuned).wav");
                    //}
                    //else if (soundEffect == SOUNDEFFECT.BOMB_FALL2)
                    //{
                    //    if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) { }// return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bomb fall 2.wav");
                    //    else if (Settings.Instance.MusicStyle == MUSIC_STYLE.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Falling bomb (27__Bomb_Whistle_tuned).wav");
                    //}
                    //else if (soundEffect == SOUNDEFFECT.BOMB_FALL3)
                    //{
                    //    if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) { }// return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bomb fall 3 .wav");
                    //    else if (Settings.Instance.MusicStyle == MUSIC_STYLE.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Falling bomb (27__Bomb_Whistle_tuned).wav");
                    //}
                    case SoundEffect.Calibre1Hybrid when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/98 - Hybrid Reloading 1.wav");
                    case SoundEffect.EmptyCanon when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Empty Canon.wav");
                    case SoundEffect.EmptyCanon when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Cannot Shoot (10).wav");
                    case SoundEffect.EmptyCanonHybrid when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hybrid Canon No Ammo.wav");
                    case SoundEffect.EmptyCanonHybrid when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/62__Harsh_Click.wav");
                    case SoundEffect.Countdown when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Countdown (March) 4.wav");
                    case SoundEffect.Countdown when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/number countdown (53).wav");
                    case SoundEffect.CountdownAlien when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Slime 1.wav");
                    case SoundEffect.CountdownAlien when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Space countdown (84)_mono .wav");
                    case SoundEffect.RewardNotification when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Reward Notification 2.wav");
                    case SoundEffect.RewardNotification when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Reward Pop-up (43).wav");
                    case SoundEffect.NotificationPopUp when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/General pop-up (Number pop 2).wav");
                    case SoundEffect.NotificationPopUp when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/General Pop-up (35).wav");
                    case SoundEffect.Rewind when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Rewind (Numbers Rolling 1).wav");
                    case SoundEffect.Rewind when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Rewind (47).wav");
                    case SoundEffect.ShowScore when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Score & number poppin out (Number pop 3).wav");
                    case SoundEffect.ShowScore when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Score & numbers poppin out (40).wav");
                    case SoundEffect.Swipe when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Swipe effect (Screen Transition 2).wav");
                    case SoundEffect.Swipe when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Swipe effect (07).wav");
                    case SoundEffect.TextAppears when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect(
                            "Sounds/text appears (enemy or map change Backwards).wav");
                    case SoundEffect.TextAppears when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/text apears (23).wav");
                    case SoundEffect.TransitionLoop1 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop1 (Number pop 1).wav");
                    case SoundEffect.TransitionLoop1 when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop1 (61).wav");
                    case SoundEffect.TransitionLoop2 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop2 (Number pop 1).wav");
                    case SoundEffect.TransitionLoop2 when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop2 (61).wav");
                    case SoundEffect.TransitionLoop3 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop3 (Number pop 1).wav");
                    case SoundEffect.TransitionLoop3 when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop3 (61).wav");
                    case SoundEffect.TransitionLoop4 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop4 (Number pop 1).wav");
                    case SoundEffect.TransitionLoop4 when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop4 (61).wav");
                    case SoundEffect.TransitionLoop5 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop5 (Number pop 1).wav");
                    case SoundEffect.TransitionLoop5 when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop5 (61).wav");
                    case SoundEffect.TransitionLoop6 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop6 (Number pop 1).wav");
                    case SoundEffect.TransitionLoop6 when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop6 (61).wav");
                    case SoundEffect.AlienLaser when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/NEW LAZER 2.wav");
                    case SoundEffect.AlienLaser when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Alien lazer compo (6 & 10).wav");
                    case SoundEffect.AlienSpit when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Slime 1.wav");
                    case SoundEffect.AlienSpit when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect(
                            "Sounds/Alien Spitting & slime oozing 1 (83 & 71).wav");
                    case SoundEffect.AlienSpit2 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Slime 2.wav");
                    case SoundEffect.AlienSpit2 when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect(
                            "Sounds/Alien Spitting & slime oozing 2 (83 & 72).wav");
                    case SoundEffect.AlienSpit3 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Slime 3.wav");
                    case SoundEffect.AlienSpit3 when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect(
                            "Sounds/Alien Spitting & slime oozing 3 (83 & 72).wav");
                    case SoundEffect.MultiplierIndicator when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Multiplier level 4.wav");
                    case SoundEffect.MultiplierIndicator when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/multiplier indicator (87).wav");
                    case SoundEffect.MultiplierLost when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Combo Loss2.wav");
                    case SoundEffect.MultiplierLost:
                        {
                            if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                                CCAudioEngine.SharedEngine.PreloadEffect("Sounds/109 - Score Multiplier Lost_with_echo.wav");
                            break;
                        }
                    case SoundEffect.FlyingSaucerIncoming when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Mothership incoming 2.wav");
                    case SoundEffect.FlyingSaucerIncoming when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/106 - UFO Alarm Sound.wav");
                    case SoundEffect.FlyingSaucerFlying when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Mothership Flying.wav");
                    case SoundEffect.FlyingSaucerFlying when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/107 - UFO Flying2_mono.wav");
                    case SoundEffect.FlyingSaucerExplosion when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Mothership Destroy.wav");
                    case SoundEffect.FlyingSaucerExplosion when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/110A - UFO Explode_mono.wav");
                    case SoundEffect.CannonStill when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Canon Still.wav", true);
                    case SoundEffect.CannonStill when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/108K - Hybrid Cannon Moving_slow.wav", true);
                    case SoundEffect.CannonSlow when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Canon slow movement.wav", true);
                    case SoundEffect.CannonSlow when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/108K - Hybrid Cannon Moving_medium.wav", true);
                    case SoundEffect.CannonFast when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Canon moving.wav", true);
                    case SoundEffect.CannonFast when Settings.Instance.MusicStyle == MusicStyle.BeatBox:
                        return CCAudioEngine.SharedEngine.PlayEffect("Sounds/108K - Hybrid Cannon Moving_fast.wav", true);
                }
            }
            catch (Exception ex)
            {
                var mess = ex.Message;
            }
            return null;
        }

        public static void PreloadSoundEffect(SoundEffect soundEffect)
        {
            switch (soundEffect)
            {
                case SoundEffect.MenuTap when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/general button (Menu Selection change 1).wav");
                    break;
                case SoundEffect.MenuTap:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/General button (61).wav");
                        break;
                    }
                case SoundEffect.MenuTapBack when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect(
                        "Sounds/Back button (Menu Selection deselect (backwards) 2).wav");
                    break;
                case SoundEffect.MenuTapBack:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Back button (39).wav");
                        break;
                    }
                case SoundEffect.MenuTapForward when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Forward button (Menu Selection Select 2).wav");
                    break;
                case SoundEffect.MenuTapForward:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Forward button (38).wav");
                        break;
                    }
                case SoundEffect.MenuTapVolumeChange when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Volume Change.wav");
                    break;
                case SoundEffect.MenuTapVolumeChange:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Sound volume tester (06).wav");
                        break;
                    }
                case SoundEffect.MenuTapMinus when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Minus Sound 1.wav");
                    break;
                case SoundEffect.MenuTapMinus:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/- button (37).wav");
                        break;
                    }
                case SoundEffect.MenuTapPlus when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Plus Sound 1.wav");
                    break;
                case SoundEffect.MenuTapPlus:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/+ button (36).wav");
                        break;
                    }
                case SoundEffect.MenuTapCannotTap when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Negative Pop up .wav");
                    break;
                case SoundEffect.MenuTapCannotTap:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Negative&Error (54).wav");
                        break;
                    }
                case SoundEffect.MenuTapCheckMark when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Check Sound 1.wav");
                    break;
                case SoundEffect.MenuTapCheckMark:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Checked (1).wav");
                        break;
                    }
                case SoundEffect.ClickLink when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect(
                        "Sounds/Click link effect (enemy or map change forward).wav");
                    break;
                case SoundEffect.ClickLink:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Click link effect (07).wav");
                        break;
                    }
                case SoundEffect.On when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect(
                        "Sounds/on button (Menu Selection deselect (backwards) 1).wav");
                    break;
                case SoundEffect.On:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/On button (41).wav");
                        break;
                    }
                case SoundEffect.Off when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/off button (Menu Selection Select 1).wav");
                    break;
                case SoundEffect.Off:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Off button (42).wav");
                        break;
                    }
                case SoundEffect.MenuTapCreditPurchase when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/purchase 3.wav");
                    break;
                case SoundEffect.MenuTapCreditPurchase:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Credit purchase (43).wav");
                        break;
                    }
                case SoundEffect.EnemyHurt1 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy - hurt 1.wav");
                    break;
                case SoundEffect.EnemyHurt1:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy hit Sound When hurt (15).wav");
                        break;
                    }
                case SoundEffect.EnemyHurt2 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy - hurt 1.wav");
                    break;
                case SoundEffect.EnemyHurt2:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy hit Sound When hurt (15).wav");
                        break;
                    }
                case SoundEffect.EnemyHurt3 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy - hurt 1.wav");
                    break;
                case SoundEffect.EnemyHurt3:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy hit Sound When hurt (15).wav");
                        break;
                    }
                case SoundEffect.EnemyKilled when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy - killed .wav");
                    break;
                case SoundEffect.EnemyKilled:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy hit Sound When killed (21).wav");
                        break;
                    }
                case SoundEffect.EnemySpit when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Combines enemy attack 1.wav");
                    break;
                case SoundEffect.EnemySpit:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy drooling & bomb whistle (18 43)_1.wav");
                        break;
                    }
                case SoundEffect.EnemySpit2 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Combines enemy attack 2.wav");
                    break;
                case SoundEffect.EnemySpit2:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy drooling & bomb whistle (18 43)_1.wav");
                        break;
                    }
                case SoundEffect.EnemySpit3 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Combines enemy attack 3.wav");
                    break;
                case SoundEffect.EnemySpit3:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy drooling & bomb whistle (18 43)_2.wav");
                        break;
                    }
                case SoundEffect.EnemySpit4 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Combines enemy attack 4.wav");
                    break;
                case SoundEffect.EnemySpit4:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy drooling & bomb whistle (18 43)_3.wav");
                        break;
                    }
                case SoundEffect.GunHit1 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Gun - Hit 1.wav");
                    break;
                case SoundEffect.GunHit1:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Cannon explosion(49).wav");
                        break;
                    }
                case SoundEffect.GunHit2 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Gun - Hit 2.wav");
                    break;
                case SoundEffect.GunHit2:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Cannon explosion(49).wav");
                        break;
                    }
                case SoundEffect.GunHit3 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Gun - Hit 3.wav");
                    break;
                case SoundEffect.GunHit3:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Cannon explosion(49).wav");
                        break;
                    }
                case SoundEffect.GunHitGameOver when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Game Over Explosion(instrumental).wav");
                    break;
                case SoundEffect.GunHitGameOver:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/game over explosion.wav");
                        break;
                    }
                case SoundEffect.Calibre1 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Reloading (Calibre 2).wav");
                    break;
                case SoundEffect.Calibre1:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Reloading (14 ).wav");
                        break;
                    }
                case SoundEffect.Calibre1Hybrid when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Hybrid Canon Reload.wav");
                    break;
                //else if (soundEffect == SOUNDEFFECT.BOMB_FALL1)
                //{
                //    if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) { }// CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Bomb fall 1 .wav");
                //    else if (Settings.Instance.MusicStyle == MUSIC_STYLE.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Falling bomb (27__Bomb_Whistle_tuned).wav");
                //}
                //else if (soundEffect == SOUNDEFFECT.BOMB_FALL2)
                //{
                //    if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) { }// CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Bomb fall 2.wav");
                //    else if (Settings.Instance.MusicStyle == MUSIC_STYLE.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Falling bomb (27__Bomb_Whistle_tuned).wav");
                //}
                //else if (soundEffect == SOUNDEFFECT.BOMB_FALL3)
                //{
                //    if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) { }// CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Bomb fall 3 .wav");
                //    else if (Settings.Instance.MusicStyle == MUSIC_STYLE.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Falling bomb (27__Bomb_Whistle_tuned).wav");
                //}
                case SoundEffect.Calibre1Hybrid:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/98 - Hybrid Reloading 1.wav");
                        break;
                    }
                case SoundEffect.EmptyCanon when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Empty Canon.wav");
                    break;
                case SoundEffect.EmptyCanon:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Cannot Shoot (10).wav");
                        break;
                    }
                case SoundEffect.EmptyCanonHybrid when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Hybrid Canon No Ammo.wav");
                    break;
                case SoundEffect.EmptyCanonHybrid:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/62__Harsh_Click.wav");
                        break;
                    }
                case SoundEffect.Countdown when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Countdown (March) 4.wav");
                    break;
                case SoundEffect.Countdown:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/number countdown (53).wav");
                        break;
                    }
                case SoundEffect.CountdownAlien when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Slime 1.wav");
                    break;
                case SoundEffect.CountdownAlien:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Space countdown (84)_mono .wav");
                        break;
                    }
                case SoundEffect.RewardNotification when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Reward Notification 2.wav");
                    break;
                case SoundEffect.RewardNotification:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Reward Pop-up (43).wav");
                        break;
                    }
                case SoundEffect.NotificationPopUp when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/General pop-up (Number pop 2).wav");
                    break;
                case SoundEffect.NotificationPopUp:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/General Pop-up (35).wav");
                        break;
                    }
                case SoundEffect.Rewind when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Rewind (Numbers Rolling 1).wav");
                    break;
                case SoundEffect.Rewind:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Rewind (47).wav");
                        break;
                    }
                case SoundEffect.ShowScore when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Score & number poppin out (Number pop 3).wav");
                    break;
                case SoundEffect.ShowScore:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Score & numbers poppin out (40).wav");
                        break;
                    }
                case SoundEffect.Swipe when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Swipe effect (Screen Transition 2).wav");
                    break;
                case SoundEffect.Swipe:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Swipe effect (07).wav");
                        break;
                    }
                case SoundEffect.TextAppears when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/text appears (enemy or map change Backwards).wav");
                    break;
                case SoundEffect.TextAppears:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/text apears (23).wav");
                        break;
                    }
                case SoundEffect.TransitionLoop1 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop1 (Number pop 1).wav");
                    break;
                case SoundEffect.TransitionLoop1:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop1 (61).wav");
                        break;
                    }
                case SoundEffect.TransitionLoop2 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop2 (Number pop 1).wav");
                    break;
                case SoundEffect.TransitionLoop2:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop2 (61).wav");
                        break;
                    }
                case SoundEffect.TransitionLoop3 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop3 (Number pop 1).wav");
                    break;
                case SoundEffect.TransitionLoop3:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop3 (61).wav");
                        break;
                    }
                case SoundEffect.TransitionLoop4 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop4 (Number pop 1).wav");
                    break;
                case SoundEffect.TransitionLoop4:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop4 (61).wav");
                        break;
                    }
                case SoundEffect.TransitionLoop5 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop5 (Number pop 1).wav");
                    break;
                case SoundEffect.TransitionLoop5:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop5 (61).wav");
                        break;
                    }
                case SoundEffect.TransitionLoop6 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop6 (Number pop 1).wav");
                    break;
                case SoundEffect.TransitionLoop6:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop6 (61).wav");
                        break;
                    }
                case SoundEffect.AlienLaser when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/NEW LAZER 2.wav");
                    break;
                case SoundEffect.AlienLaser:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Alien lazer compo (6 & 10).wav");
                        break;
                    }
                case SoundEffect.AlienSpit when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Slime 1.wav");
                    break;
                case SoundEffect.AlienSpit:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect(
                                "Sounds/Alien Spitting & slime oozing 1 (83 & 71).wav");
                        break;
                    }
                case SoundEffect.AlienSpit2 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Slime 2.wav");
                    break;
                case SoundEffect.AlienSpit2:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect(
                                "Sounds/Alien Spitting & slime oozing 2 (83 & 72).wav");
                        break;
                    }
                case SoundEffect.AlienSpit3 when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Slime 3.wav");
                    break;
                case SoundEffect.AlienSpit3:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect(
                                "Sounds/Alien Spitting & slime oozing 3 (83 & 72).wav");
                        break;
                    }
                case SoundEffect.MultiplierIndicator when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Multiplier level 4.wav");
                    break;
                case SoundEffect.MultiplierIndicator:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/multiplier indicator (87).wav");
                        break;
                    }
                case SoundEffect.MultiplierLost when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Combo Loss2.wav");
                    break;
                case SoundEffect.MultiplierLost:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/109 - Score Multiplier Lost_with_echo.wav");
                        break;
                    }
                case SoundEffect.FlyingSaucerIncoming when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Mothership incoming 2.wav");
                    break;
                case SoundEffect.FlyingSaucerIncoming:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/106 - UFO Alarm Sound.wav");
                        break;
                    }
                case SoundEffect.FlyingSaucerFlying when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Mothership Flying.wav");
                    break;
                case SoundEffect.FlyingSaucerFlying:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/107 - UFO Flying2_mono.wav");
                        break;
                    }
                case SoundEffect.FlyingSaucerExplosion when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Mothership Destroy.wav");
                    break;
                case SoundEffect.FlyingSaucerExplosion:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/110A - UFO Explode_mono.wav");
                        break;
                    }
                case SoundEffect.CannonStill when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Canon Still.wav");
                    break;
                case SoundEffect.CannonStill:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/108K - Hybrid Cannon Moving_slow.wav");
                        break;
                    }
                case SoundEffect.CannonSlow when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Canon slow movement.wav");
                    break;
                case SoundEffect.CannonSlow:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/108K - Hybrid Cannon Moving_medium.wav");
                        break;
                    }
                case SoundEffect.CannonFast when Settings.Instance.MusicStyle == MusicStyle.Instrumental:
                    CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Canon moving.wav");
                    break;
                case SoundEffect.CannonFast:
                    {
                        if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                            CCAudioEngine.SharedEngine.PreloadEffect("Sounds/108K - Hybrid Cannon Moving_fast.wav");
                        break;
                    }
            }
        }

    }
}