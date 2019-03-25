using System;
using CocosSharp;

namespace LooneyInvaders.Model
{
    public class GameEnvironment
    {
        public static string ImageDirectory = "Images/Hd/";

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
            
            var activityManager = Android.App.Application.Context.GetSystemService(Android.App.Activity.ActivityService) as Android.App.ActivityManager;            
            var memoryInfo = new Android.App.ActivityManager.MemoryInfo();
            activityManager.GetMemoryInfo(memoryInfo);

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
            while (MusicPlaying == conditionMusic && (DateTime.Now < startTime || Shared.GameDelegate.GameView.Paused || CCAudioEngine.SharedEngine.BackgroundMusicPlaying))
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
                if (MusicPlaying == "Sounds/Victory.mp3" || MusicPlaying == "Sounds/07 - Looney Invaders Victory FINAL_part1_intro_segment.mp3" || MusicPlaying == "Sounds/07 - Looney Invaders Victory FINAL_part1_intro_segment.mp3")
                    return;

                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental)
                {
                    PlayMusic("Sounds/Main Menu Loopable2.mp3");
                }
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                {
                    if (MusicPlaying != "Sounds/02 - Main Menu FINAL_part1_intro_segment.mp3" && MusicPlaying != "Sounds/02 - Main Menu FINAL_part2_loop_segment.mp3")
                    {
                        PlayMusicOnce("Sounds/02 - Main Menu FINAL_part1_intro_segment.mp3");
                        System.Threading.Tasks.Task.Run(() => PlayWithDelayConditionally("Sounds/02 - Main Menu FINAL_part1_intro_segment.mp3", "Sounds/02 - Main Menu FINAL_part2_loop_segment.mp3", DateTime.Now.AddMilliseconds(54885)));
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
                    System.Threading.Tasks.Task.Run(() => PlayWithDelayConditionally("Sounds/Game Over_part1.mp3", "Sounds/Game over Loop_part2.mp3", DateTime.Now.AddMilliseconds(10500)));
                }
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                {
                    PlayMusicOnce("Sounds/09 - GameOver FINAL_part1_intro_segment.mp3");
                    System.Threading.Tasks.Task.Run(() => PlayWithDelayConditionally("Sounds/09 - GameOver FINAL_part1_intro_segment.mp3", "Sounds/09 - GameOver FINAL_part2_loop_segment.mp3", DateTime.Now.AddMilliseconds(7000)));
                    //PlayWithDelayConditionallyDelegate p = PlayWithDelayConditionally;
                    //IAsyncResult res = p.BeginInvoke("Sounds/09 - GameOver FINAL_part1_intro_segment.mp3", "Sounds/09 - GameOver FINAL_part2_loop_segment.mp3", 7000, null, null);
                }
            }
            else if (music == Music.GameOverAlien)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental)
                {
                    PlayMusicOnce("Sounds/Space end screen part1.mp3");
                    System.Threading.Tasks.Task.Run(() => PlayWithDelayConditionally("Sounds/Space end screen part1.mp3", "Sounds/Leaderboard space part2.mp3", DateTime.Now.AddMilliseconds(5000)));
                }
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                {
                    PlayMusicOnce("Sounds/17 - GameOver - Space Version-part1-intro-segment.mp3");
                    System.Threading.Tasks.Task.Run(() => PlayWithDelayConditionally("Sounds/17 - GameOver - Space Version-part1-intro-segment.mp3", "Sounds/17 - GameOver - Space Version-part2-loop-segment.mp3", DateTime.Now.AddMilliseconds(17800)));
                    //PlayWithDelayConditionallyDelegate p = PlayWithDelayConditionally;
                    //IAsyncResult res = p.BeginInvoke("Sounds/17 - GameOver - Space Version-part1-intro-segment.mp3", "Sounds/17 - GameOver - Space Version-part2-loop-segment.mp3", 17800, null, null);
                }
            }
            else if (music == Music.Victory)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental)
                {
                    PlayMusicOnce("Sounds/Victory_part1.mp3");
                    System.Threading.Tasks.Task.Run(() => PlayWithDelayConditionally("Sounds/Victory_part1.mp3", "Sounds/Victory loop_part2.mp3", DateTime.Now.AddMilliseconds(14000)));
                }
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                {
                    PlayMusicOnce("Sounds/07 - Looney Invaders Victory FINAL_part1_intro_segment.mp3");
                    System.Threading.Tasks.Task.Run(() => PlayWithDelayConditionally("Sounds/07 - Looney Invaders Victory FINAL_part1_intro_segment.mp3", "Sounds/07 - Looney Invaders Victory FINAL_part2_loop_segment.mp3", DateTime.Now.AddMilliseconds(3000)));
                    //PlayWithDelayConditionallyDelegate p = PlayWithDelayConditionally;
                    //IAsyncResult res = p.BeginInvoke("Sounds/07 - Looney Invaders Victory FINAL_part1_intro_segment.mp3", "Sounds/07 - Looney Invaders Victory FINAL_part2_loop_segment.mp3", 3000, null, null);
                }
            }
            else if (music == Music.BattleWave1)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) PlayMusic("Sounds/Battle (MAJOR EDIT) wave 1 tune.mp3");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) PlayMusic("Sounds/04 - Looney Invaders Battle Theme (Wave 1) FINAL.mp3");
            }
            else if (music == Music.BattleWave2)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) PlayMusic("Sounds/War (Battle II) wave 2 tune.mp3", true);
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) PlayMusic("Sounds/05 - Looney Invaders Battle Theme (Wave 2) FINAL.mp3", true);
            }
            else if (music == Music.BattleWave3)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) PlayMusic("Sounds/Invasion (Battle III)  wave 3 tune.mp3", true);
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) PlayMusic("Sounds/06 - Looney Invaders Battle Theme (Wave 3) FINAL.mp3", true);
            }



            else if (music == Music.BattleAlien1)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) PlayMusic("Sounds/Final Battle Theme speed -1 (111%).mp3", true);
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) PlayMusic("Sounds/12 - Looney Invaders Battle Theme Prelude (Wave Final Attack 1-115%).mp3", true);
            }
            else if (music == Music.BattleAlien2)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) PlayMusic("Sounds/Final Battle Theme.mp3", true);
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) PlayMusic("Sounds/12 - Looney Invaders Battle Theme Prelude (Wave Final Attack 1).mp3", true);
            }
            else if (music == Music.BattleAlien3)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) PlayMusic("Sounds/Final Battle Theme speed 2 (86%).mp3", true);
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) PlayMusic("Sounds/12 - Looney Invaders Battle Theme Prelude (Wave Final Attack 1-85%).mp3", true);
            }
            else if (music == Music.BattleAlien4)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) PlayMusic("Sounds/Final Battle II.mp3", true);
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) PlayMusic("Sounds/13 - Looney Invaders Battle Theme Prelude (Wave Final Attack 2-115%).mp3", true);
            }
            else if (music == Music.BattleAlien5)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) PlayMusic("Sounds/Final Battle II speed 2 (86%).mp3", true);
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) PlayMusic("Sounds/13 - Looney Invaders Battle Theme Prelude (Wave Final Attack 2).mp3", true);
            }
            else if (music == Music.BattleAlien6)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) PlayMusic("Sounds/Final Battle II speed 3 (77%).mp3", true);
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) PlayMusic("Sounds/13 - Looney Invaders Battle Theme Prelude (Wave Final Attack 2-85%).mp3", true);
            }
            else if (music == Music.BattleAlien7)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) PlayMusic("Sounds/Alien Battle theme 3 loop.mp3", true);
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) PlayMusic("Sounds/14 - Looney Invaders Battle Theme Prelude (Wave Final Attack 3-115%).mp3", true);
            }
            else if (music == Music.BattleAlien8)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) PlayMusic("Sounds/Alien Battle theme 3 speed 2.mp3", true);
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) PlayMusic("Sounds/14 - Looney Invaders Battle Theme Prelude (Wave Final Attack 3).mp3", true);
            }
            else if (music == Music.BattleAlien9)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) PlayMusic("Sounds/Alien Battle theme 3 speed 3.mp3", true);
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) PlayMusic("Sounds/14 - Looney Invaders Battle Theme Prelude (Wave Final Attack 3-85%).mp3", true);
            }
            else if (music == Music.BattleCountdown)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental)
                {
                    PlayMusicOnce("Sounds/Battle Countdown Slower (prelude).mp3");
                    System.Threading.Tasks.Task.Run(() => PlayWithDelayConditionally("Sounds/Battle Countdown Slower (prelude).mp3", "Sounds/Battle (MAJOR EDIT) wave 1 tune.mp3", DateTime.Now.AddMilliseconds(6000)));
                    //PlayWithDelayConditionallyDelegate p = PlayWithDelayConditionally;
                    //IAsyncResult res = p.BeginInvoke("Sounds/Battle Countdown Slower (prelude).mp3", "Sounds/Battle (MAJOR EDIT) wave 1 tune.mp3", 6000, null, null);
                }
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                {
                    PlayMusicOnce("Sounds/11 - Looney_Invaders_Battle_Theme_Prelude1.mp3");
                    System.Threading.Tasks.Task.Run(() => PlayWithDelayConditionally("Sounds/11 - Looney_Invaders_Battle_Theme_Prelude1.mp3", "Sounds/04 - Looney Invaders Battle Theme (Wave 1) FINAL.mp3", DateTime.Now.AddMilliseconds(6000)));
                    //PlayWithDelayConditionallyDelegate p = PlayWithDelayConditionally;
                    //IAsyncResult res = p.BeginInvoke("Sounds/11 - Looney_Invaders_Battle_Theme_Prelude1.mp3", "Sounds/04 - Looney Invaders Battle Theme (Wave 1) FINAL.mp3", 6000, null, null);
                }
            }
            else if (music == Music.BattleCountdownAlien)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental)
                {
                    PlayMusicOnce("Sounds/GET READY FOR ALIEN BATTLE.mp3");
                    System.Threading.Tasks.Task.Run(() => PlayWithDelayConditionally("Sounds/GET READY FOR ALIEN BATTLE.mp3", "Sounds/Sounds/Final Battle Theme speed -1 (111%).mp3", DateTime.Now.AddMilliseconds(6000)));
                    //PlayWithDelayConditionallyDelegate p = PlayWithDelayConditionally;
                    //IAsyncResult res = p.BeginInvoke("Sounds/GET READY FOR ALIEN BATTLE.mp3", "Sounds/Sounds/Final Battle Theme speed -1 (111%).mp3", 6000, null, null);

                }
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox)
                {
                    PlayMusicOnce("Sounds/15 - Looney Invaders Battle Theme Space Prelude.mp3");
                    System.Threading.Tasks.Task.Run(() => PlayWithDelayConditionally("Sounds/11 - Looney_Invaders_Battle_Theme_Prelude1.mp3", "Sounds/04 - Looney Invaders Battle Theme (Wave 1) FINAL.mp3", DateTime.Now.AddMilliseconds(6000)));
                    //PlayWithDelayConditionallyDelegate p = PlayWithDelayConditionally;
                    //IAsyncResult res = p.BeginInvoke("Sounds/11 - Looney_Invaders_Battle_Theme_Prelude1.mp3", "Sounds/04 - Looney Invaders Battle Theme (Wave 1) FINAL.mp3", 6000, null, null);
                }
            }
            else if (music == Music.NextWave)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) PlayMusicOnce("Sounds/Battle Countdown (interlude).mp3");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) PlayMusicOnce("Sounds/44 - Get Ready For The Next Attack.mp3");
            }
            else if (music == Music.NextWaveAlien)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) PlayMusicOnce("Sounds/Alien Interlude.mp3");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) PlayMusicOnce("Sounds/111 - Get Ready For The Next Attack Space.mp3");
            }
        }

        public static void PlayMusic(string newMusic, bool fromStart = false)
        {
            if (newMusic == "") return;

            if (newMusic != MusicPlaying || fromStart || !CCAudioEngine.SharedEngine.BackgroundMusicPlaying)
            {
                CCAudioEngine.SharedEngine.StopBackgroundMusic();
                MusicPlaying = newMusic;
                CCAudioEngine.SharedEngine.PlayBackgroundMusic(MusicPlaying, true);
            }
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
        {
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
            if (soundEffect == SoundEffect.MenuTap)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/general button (Menu Selection change 1).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/General button (61).wav");
            }
            else if (soundEffect == SoundEffect.MenuTapBack)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Back button (Menu Selection deselect (backwards) 2).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Back button (39).wav");
            }
            else if (soundEffect == SoundEffect.MenuTapForward)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Forward button (Menu Selection Select 2).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Forward button (38).wav");
            }
            else if (soundEffect == SoundEffect.MenuTapVolumeChange)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Volume Change.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Sound volume tester (06).wav");
            }
            else if (soundEffect == SoundEffect.MenuTapMinus)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Minus Sound 1.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/- button (37).wav");
            }
            else if (soundEffect == SoundEffect.MenuTapPlus)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Plus Sound 1.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/+ button (36).wav");
            }
            else if (soundEffect == SoundEffect.MenuTapCannotTap)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Cannot tap 1.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Negative&Error (54).wav");
            }
            else if (soundEffect == SoundEffect.MenuTapCheckMark)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Check Sound 1.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Checked (1).wav");
            }
            else if (soundEffect == SoundEffect.ClickLink)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Click link effect (enemy or map change forward).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Click link effect (07).wav");
            }
            else if (soundEffect == SoundEffect.On)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/on button (Menu Selection deselect (backwards) 1).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/On button (41).wav");
            }
            else if (soundEffect == SoundEffect.Off)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/off button (Menu Selection Select 1).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Off button (42).wav");
            }
            else if (soundEffect == SoundEffect.MenuTapCreditPurchase)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/purchase 3.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Credit purchase (43).wav");
            }
            else if (soundEffect == SoundEffect.EnemyHurt1)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy - hurt 1.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy hit Sound When hurt (15).wav");
            }
            else if (soundEffect == SoundEffect.EnemyHurt2)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy - hurt 1.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy hit Sound When hurt (15).wav");
            }
            else if (soundEffect == SoundEffect.EnemyHurt3)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy - hurt 1.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy hit Sound When hurt (15).wav");
            }
            else if (soundEffect == SoundEffect.EnemyKilled)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy - killed .wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy hit Sound When killed (21).wav");
            }
            else if (soundEffect == SoundEffect.EnemySpit)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Combines enemy attack 1.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy drooling & bomb whistle (18 43)_1.wav");
            }
            else if (soundEffect == SoundEffect.EnemySpit2)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Combines enemy attack 2.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy drooling & bomb whistle (18 43)_1.wav");
            }
            else if (soundEffect == SoundEffect.EnemySpit3)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Combines enemy attack 3.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy drooling & bomb whistle (18 43)_2.wav");
            }
            else if (soundEffect == SoundEffect.EnemySpit4)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Combines enemy attack 4.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy drooling & bomb whistle (18 43)_3.wav");
            }
            else if (soundEffect == SoundEffect.GunHit1)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Gun - Hit 1.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Cannon explosion(49).wav");
            }
            else if (soundEffect == SoundEffect.GunHit2)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Gun - Hit 2.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Cannon explosion(49).wav");
            }
            else if (soundEffect == SoundEffect.GunHit3)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Gun - Hit 3.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Cannon explosion(49).wav");
            }
            else if (soundEffect == SoundEffect.GunHitGameOver)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Game Over Explosion(instrumental).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/game over explosion.wav");
            }
            else if (soundEffect == SoundEffect.Calibre1)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Reloading (Calibre 2).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Reloading (14 ).wav");
            }
            else if (soundEffect == SoundEffect.Calibre1Hybrid)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hybrid Canon Reload.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/98 - Hybrid Reloading 1.wav");
            }
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
            else if (soundEffect == SoundEffect.EmptyCanon)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Empty Canon.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Cannot Shoot (10).wav");
            }
            else if (soundEffect == SoundEffect.EmptyCanonHybrid)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hybrid Canon No Ammo.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/62__Harsh_Click.wav");
            }
            else if (soundEffect == SoundEffect.Countdown)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Countdown (March) 4.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/number countdown (53).wav");
            }
            else if (soundEffect == SoundEffect.CountdownAlien)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Slime 1.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Space countdown (84)_mono .wav");
            }
            else if (soundEffect == SoundEffect.RewardNotification)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Reward Notification 2.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Reward Pop-up (43).wav");
            }
            else if (soundEffect == SoundEffect.NotificationPopUp)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/General pop-up (Number pop 2).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/General Pop-up (35).wav");
            }
            else if (soundEffect == SoundEffect.Rewind)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Rewind (Numbers Rolling 1).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Rewind (47).wav");
            }
            else if (soundEffect == SoundEffect.ShowScore)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Score & number poppin out (Number pop 3).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Score & numbers poppin out (40).wav");
            }
            else if (soundEffect == SoundEffect.Swipe)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Swipe effect (Screen Transition 2).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Swipe effect (07).wav");
            }
            else if (soundEffect == SoundEffect.TextAppears)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/text appears (enemy or map change Backwards).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/text apears (23).wav");
            }
            else if (soundEffect == SoundEffect.TransitionLoop1)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop1 (Number pop 1).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop1 (61).wav");
            }
            else if (soundEffect == SoundEffect.TransitionLoop2)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop2 (Number pop 1).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop2 (61).wav");
            }
            else if (soundEffect == SoundEffect.TransitionLoop3)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop3 (Number pop 1).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop3 (61).wav");
            }
            else if (soundEffect == SoundEffect.TransitionLoop4)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop4 (Number pop 1).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop4 (61).wav");
            }
            else if (soundEffect == SoundEffect.TransitionLoop5)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop5 (Number pop 1).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop5 (61).wav");
            }
            else if (soundEffect == SoundEffect.TransitionLoop6)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop6 (Number pop 1).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop6 (61).wav");
            }
            else if (soundEffect == SoundEffect.AlienLaser)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/NEW LAZER 2.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Alien lazer compo (6 & 10).wav");
            }
            else if (soundEffect == SoundEffect.AlienSpit)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Slime 1.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Alien Spitting & slime oozing 1 (83 & 71).wav");
            }
            else if (soundEffect == SoundEffect.AlienSpit2)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Slime 2.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Alien Spitting & slime oozing 2 (83 & 72).wav");
            }
            else if (soundEffect == SoundEffect.AlienSpit3)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Slime 3.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Alien Spitting & slime oozing 3 (83 & 72).wav");
            }
            else if (soundEffect == SoundEffect.MultiplierIndicator)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Multiplier level 4.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/multiplier indicator (87).wav");
            }
            else if (soundEffect == SoundEffect.MultiplierLost)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Combo Loss2.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/109 - Score Multiplier Lost_with_echo.wav");
            }
            else if (soundEffect == SoundEffect.FlyingSaucerIncoming)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Mothership incoming 2.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/106 - UFO Alarm Sound.wav");
            }
            else if (soundEffect == SoundEffect.FlyingSaucerFlying)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Mothership Flying.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/107 - UFO Flying2_mono.wav");
            }
            else if (soundEffect == SoundEffect.FlyingSaucerExplosion)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Mothership Destroy.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/110A - UFO Explode_mono.wav");
            }
            else if (soundEffect == SoundEffect.CannonStill)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Canon Still.wav", true);
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/108K - Hybrid Cannon Moving_slow.wav", true);
            }
            else if (soundEffect == SoundEffect.CannonSlow)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Canon slow movement.wav", true);
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/108K - Hybrid Cannon Moving_medium.wav", true);
            }
            else if (soundEffect == SoundEffect.CannonFast)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Canon moving.wav", true);
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/108K - Hybrid Cannon Moving_fast.wav", true);
            }
            return null;
        }

        public static void PreloadSoundEffect(SoundEffect soundEffect)
        {
            if (soundEffect == SoundEffect.MenuTap)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/general button (Menu Selection change 1).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/General button (61).wav");
            }
            else if (soundEffect == SoundEffect.MenuTapBack)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Back button (Menu Selection deselect (backwards) 2).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Back button (39).wav");
            }
            else if (soundEffect == SoundEffect.MenuTapForward)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Forward button (Menu Selection Select 2).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Forward button (38).wav");
            }
            else if (soundEffect == SoundEffect.MenuTapVolumeChange)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Volume Change.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Sound volume tester (06).wav");
            }
            else if (soundEffect == SoundEffect.MenuTapMinus)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Minus Sound 1.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/- button (37).wav");
            }
            else if (soundEffect == SoundEffect.MenuTapPlus)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Plus Sound 1.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/+ button (36).wav");
            }
            else if (soundEffect == SoundEffect.MenuTapCannotTap)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Negative Pop up .wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Negative&Error (54).wav");
            }
            else if (soundEffect == SoundEffect.MenuTapCheckMark)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Check Sound 1.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Checked (1).wav");
            }
            else if (soundEffect == SoundEffect.ClickLink)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Click link effect (enemy or map change forward).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Click link effect (07).wav");
            }
            else if (soundEffect == SoundEffect.On)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/on button (Menu Selection deselect (backwards) 1).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/On button (41).wav");
            }
            else if (soundEffect == SoundEffect.Off)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/off button (Menu Selection Select 1).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Off button (42).wav");
            }
            else if (soundEffect == SoundEffect.MenuTapCreditPurchase)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/purchase 3.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Credit purchase (43).wav");
            }
            else if (soundEffect == SoundEffect.EnemyHurt1)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy - hurt 1.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy hit Sound When hurt (15).wav");
            }
            else if (soundEffect == SoundEffect.EnemyHurt2)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy - hurt 1.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy hit Sound When hurt (15).wav");
            }
            else if (soundEffect == SoundEffect.EnemyHurt3)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy - hurt 1.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy hit Sound When hurt (15).wav");
            }
            else if (soundEffect == SoundEffect.EnemyKilled)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy - killed .wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy hit Sound When killed (21).wav");
            }
            else if (soundEffect == SoundEffect.EnemySpit)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Combines enemy attack 1.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy drooling & bomb whistle (18 43)_1.wav");
            }
            else if (soundEffect == SoundEffect.EnemySpit2)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Combines enemy attack 2.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy drooling & bomb whistle (18 43)_1.wav");
            }
            else if (soundEffect == SoundEffect.EnemySpit3)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Combines enemy attack 3.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy drooling & bomb whistle (18 43)_2.wav");
            }
            else if (soundEffect == SoundEffect.EnemySpit4)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Combines enemy attack 4.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy drooling & bomb whistle (18 43)_3.wav");
            }
            else if (soundEffect == SoundEffect.GunHit1)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Gun - Hit 1.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Cannon explosion(49).wav");
            }
            else if (soundEffect == SoundEffect.GunHit2)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Gun - Hit 2.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Cannon explosion(49).wav");
            }
            else if (soundEffect == SoundEffect.GunHit3)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Gun - Hit 3.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Cannon explosion(49).wav");
            }
            else if (soundEffect == SoundEffect.GunHitGameOver)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Game Over Explosion(instrumental).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/game over explosion.wav");
            }
            else if (soundEffect == SoundEffect.Calibre1)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Reloading (Calibre 2).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Reloading (14 ).wav");
            }
            else if (soundEffect == SoundEffect.Calibre1Hybrid)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Hybrid Canon Reload.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/98 - Hybrid Reloading 1.wav");
            }
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
            else if (soundEffect == SoundEffect.EmptyCanon)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Empty Canon.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Cannot Shoot (10).wav");
            }
            else if (soundEffect == SoundEffect.EmptyCanonHybrid)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Hybrid Canon No Ammo.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/62__Harsh_Click.wav");
            }
            else if (soundEffect == SoundEffect.Countdown)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Countdown (March) 4.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/number countdown (53).wav");
            }
            else if (soundEffect == SoundEffect.CountdownAlien)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Slime 1.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Space countdown (84)_mono .wav");
            }
            else if (soundEffect == SoundEffect.RewardNotification)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Reward Notification 2.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Reward Pop-up (43).wav");
            }
            else if (soundEffect == SoundEffect.NotificationPopUp)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/General pop-up (Number pop 2).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/General Pop-up (35).wav");
            }
            else if (soundEffect == SoundEffect.Rewind)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Rewind (Numbers Rolling 1).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Rewind (47).wav");
            }
            else if (soundEffect == SoundEffect.ShowScore)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Score & number poppin out (Number pop 3).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Score & numbers poppin out (40).wav");
            }
            else if (soundEffect == SoundEffect.Swipe)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Swipe effect (Screen Transition 2).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Swipe effect (07).wav");
            }
            else if (soundEffect == SoundEffect.TextAppears)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/text appears (enemy or map change Backwards).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/text apears (23).wav");
            }
            else if (soundEffect == SoundEffect.TransitionLoop1)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop1 (Number pop 1).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop1 (61).wav");
            }
            else if (soundEffect == SoundEffect.TransitionLoop2)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop2 (Number pop 1).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop2 (61).wav");
            }
            else if (soundEffect == SoundEffect.TransitionLoop3)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop3 (Number pop 1).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop3 (61).wav");
            }
            else if (soundEffect == SoundEffect.TransitionLoop4)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop4 (Number pop 1).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop4 (61).wav");
            }
            else if (soundEffect == SoundEffect.TransitionLoop5)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop5 (Number pop 1).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop5 (61).wav");
            }
            else if (soundEffect == SoundEffect.TransitionLoop6)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop6 (Number pop 1).wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop6 (61).wav");
            }
            else if (soundEffect == SoundEffect.AlienLaser)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/NEW LAZER 2.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Alien lazer compo (6 & 10).wav");
            }
            else if (soundEffect == SoundEffect.AlienSpit)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Slime 1.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Alien Spitting & slime oozing 1 (83 & 71).wav");
            }
            else if (soundEffect == SoundEffect.AlienSpit2)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Slime 2.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Alien Spitting & slime oozing 2 (83 & 72).wav");
            }
            else if (soundEffect == SoundEffect.AlienSpit3)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Slime 3.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Alien Spitting & slime oozing 3 (83 & 72).wav");
            }
            else if (soundEffect == SoundEffect.MultiplierIndicator)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Multiplier level 4.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/multiplier indicator (87).wav");
            }
            else if (soundEffect == SoundEffect.MultiplierLost)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Combo Loss2.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/109 - Score Multiplier Lost_with_echo.wav");
            }
            else if (soundEffect == SoundEffect.FlyingSaucerIncoming)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Mothership incoming 2.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/106 - UFO Alarm Sound.wav");
            }
            else if (soundEffect == SoundEffect.FlyingSaucerFlying)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Mothership Flying.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/107 - UFO Flying2_mono.wav");
            }
            else if (soundEffect == SoundEffect.FlyingSaucerExplosion)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Mothership Destroy.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/110A - UFO Explode_mono.wav");
            }
            else if (soundEffect == SoundEffect.CannonStill)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Canon Still.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/108K - Hybrid Cannon Moving_slow.wav");
            }
            else if (soundEffect == SoundEffect.CannonSlow)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Canon slow movement.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/108K - Hybrid Cannon Moving_medium.wav");
            }
            else if (soundEffect == SoundEffect.CannonFast)
            {
                if (Settings.Instance.MusicStyle == MusicStyle.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Canon moving.wav");
                else if (Settings.Instance.MusicStyle == MusicStyle.BeatBox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/108K - Hybrid Cannon Moving_fast.wav");
            }
        }

    }
}
