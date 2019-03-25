using System;
using System.Collections.Generic;
using System.Text;
using CocosSharp;
using LooneyInvaders.Classes;

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

        public static long GetTotalRAMSizeMB()
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
                PlayMusic(newMusic, false);
            }
        }

        public static string MusicPlaying = "";



        public static void PlayMusic( MUSIC music, bool fromStart = false)
        {
            CCLayerColorExt layer = null;
            if (music == MUSIC.MAIN_MENU)
            {
                if (MusicPlaying == "Sounds/Victory.mp3" || MusicPlaying == "Sounds/07 - Looney Invaders Victory FINAL_part1_intro_segment.mp3" || MusicPlaying == "Sounds/07 - Looney Invaders Victory FINAL_part1_intro_segment.mp3") return;

                    if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) PlayMusic("Sounds/Main Menu Loopable2.mp3", false);
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox)
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
            else if (music == MUSIC.SPLASH_SCREEN)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) PlayMusicOnce("Sounds/Splash Intro instrumental.mp3");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) PlayMusicOnce("Sounds/01 - Splash Intro FINAL.mp3");
            }
            else if (music == MUSIC.GAMEOVER)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental)
                {
                    PlayMusicOnce("Sounds/Game Over_part1.mp3");
                    System.Threading.Tasks.Task.Run(() => PlayWithDelayConditionally("Sounds/Game Over_part1.mp3", "Sounds/Game over Loop_part2.mp3", DateTime.Now.AddMilliseconds(10500)));
                }
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox)
                {
                    PlayMusicOnce("Sounds/09 - GameOver FINAL_part1_intro_segment.mp3");
                    System.Threading.Tasks.Task.Run(() => PlayWithDelayConditionally("Sounds/09 - GameOver FINAL_part1_intro_segment.mp3", "Sounds/09 - GameOver FINAL_part2_loop_segment.mp3", DateTime.Now.AddMilliseconds(7000)));
                    //PlayWithDelayConditionallyDelegate p = PlayWithDelayConditionally;
                    //IAsyncResult res = p.BeginInvoke("Sounds/09 - GameOver FINAL_part1_intro_segment.mp3", "Sounds/09 - GameOver FINAL_part2_loop_segment.mp3", 7000, null, null);
                }
            }
            else if (music == MUSIC.GAMEOVERALIEN)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental)
                {
                    PlayMusicOnce("Sounds/Space end screen part1.mp3");
                    System.Threading.Tasks.Task.Run(() => PlayWithDelayConditionally("Sounds/Space end screen part1.mp3", "Sounds/Leaderboard space part2.mp3", DateTime.Now.AddMilliseconds(5000)));
                }
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox)
                {
                    PlayMusicOnce("Sounds/17 - GameOver - Space Version-part1-intro-segment.mp3");
                    System.Threading.Tasks.Task.Run(() => PlayWithDelayConditionally("Sounds/17 - GameOver - Space Version-part1-intro-segment.mp3", "Sounds/17 - GameOver - Space Version-part2-loop-segment.mp3", DateTime.Now.AddMilliseconds(17800)));
                    //PlayWithDelayConditionallyDelegate p = PlayWithDelayConditionally;
                    //IAsyncResult res = p.BeginInvoke("Sounds/17 - GameOver - Space Version-part1-intro-segment.mp3", "Sounds/17 - GameOver - Space Version-part2-loop-segment.mp3", 17800, null, null);
                }
            }
            else if (music == MUSIC.VICTORY)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental)
                {
                    PlayMusicOnce("Sounds/Victory_part1.mp3");
                    System.Threading.Tasks.Task.Run(() => PlayWithDelayConditionally("Sounds/Victory_part1.mp3", "Sounds/Victory loop_part2.mp3", DateTime.Now.AddMilliseconds(14000)));
                }
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox)
                {
                    PlayMusicOnce("Sounds/07 - Looney Invaders Victory FINAL_part1_intro_segment.mp3");
                    System.Threading.Tasks.Task.Run(() => PlayWithDelayConditionally("Sounds/07 - Looney Invaders Victory FINAL_part1_intro_segment.mp3", "Sounds/07 - Looney Invaders Victory FINAL_part2_loop_segment.mp3", DateTime.Now.AddMilliseconds(3000)));
                    //PlayWithDelayConditionallyDelegate p = PlayWithDelayConditionally;
                    //IAsyncResult res = p.BeginInvoke("Sounds/07 - Looney Invaders Victory FINAL_part1_intro_segment.mp3", "Sounds/07 - Looney Invaders Victory FINAL_part2_loop_segment.mp3", 3000, null, null);
                }
            }
            else if (music == MUSIC.BATTLE_WAVE_1)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) PlayMusic("Sounds/Battle (MAJOR EDIT) wave 1 tune.mp3", false);
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) PlayMusic("Sounds/04 - Looney Invaders Battle Theme (Wave 1) FINAL.mp3", false);
            }
            else if (music == MUSIC.BATTLE_WAVE_2)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) PlayMusic("Sounds/War (Battle II) wave 2 tune.mp3", true);
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) PlayMusic("Sounds/05 - Looney Invaders Battle Theme (Wave 2) FINAL.mp3", true);
            }
            else if (music == MUSIC.BATTLE_WAVE_3)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) PlayMusic("Sounds/Invasion (Battle III)  wave 3 tune.mp3", true);
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) PlayMusic("Sounds/06 - Looney Invaders Battle Theme (Wave 3) FINAL.mp3", true);
            }



            else if (music == MUSIC.BATTLE_ALIEN1)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) PlayMusic("Sounds/Final Battle Theme speed -1 (111%).mp3", true);
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) PlayMusic("Sounds/12 - Looney Invaders Battle Theme Prelude (Wave Final Attack 1-115%).mp3", true);
            }
            else if (music == MUSIC.BATTLE_ALIEN2)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) PlayMusic("Sounds/Final Battle Theme.mp3", true);
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) PlayMusic("Sounds/12 - Looney Invaders Battle Theme Prelude (Wave Final Attack 1).mp3", true);
            }
            else if (music == MUSIC.BATTLE_ALIEN3)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) PlayMusic("Sounds/Final Battle Theme speed 2 (86%).mp3", true);
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) PlayMusic("Sounds/12 - Looney Invaders Battle Theme Prelude (Wave Final Attack 1-85%).mp3", true);
            }
            else if (music == MUSIC.BATTLE_ALIEN4)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) PlayMusic("Sounds/Final Battle II.mp3", true);
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) PlayMusic("Sounds/13 - Looney Invaders Battle Theme Prelude (Wave Final Attack 2-115%).mp3", true);
            }
            else if (music == MUSIC.BATTLE_ALIEN5)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) PlayMusic("Sounds/Final Battle II speed 2 (86%).mp3", true);
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) PlayMusic("Sounds/13 - Looney Invaders Battle Theme Prelude (Wave Final Attack 2).mp3", true);
            }
            else if (music == MUSIC.BATTLE_ALIEN6)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) PlayMusic("Sounds/Final Battle II speed 3 (77%).mp3", true);
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) PlayMusic("Sounds/13 - Looney Invaders Battle Theme Prelude (Wave Final Attack 2-85%).mp3", true);
            }
            else if (music == MUSIC.BATTLE_ALIEN7)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) PlayMusic("Sounds/Alien Battle theme 3 loop.mp3", true);
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) PlayMusic("Sounds/14 - Looney Invaders Battle Theme Prelude (Wave Final Attack 3-115%).mp3", true);
            }
            else if (music == MUSIC.BATTLE_ALIEN8)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) PlayMusic("Sounds/Alien Battle theme 3 speed 2.mp3", true);
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) PlayMusic("Sounds/14 - Looney Invaders Battle Theme Prelude (Wave Final Attack 3).mp3", true);
            }
            else if (music == MUSIC.BATTLE_ALIEN9)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) PlayMusic("Sounds/Alien Battle theme 3 speed 3.mp3", true);
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) PlayMusic("Sounds/14 - Looney Invaders Battle Theme Prelude (Wave Final Attack 3-85%).mp3", true);
            }
            else if (music == MUSIC.BATTLE_COUNTDOWN)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental)
                {
                    PlayMusicOnce("Sounds/Battle Countdown Slower (prelude).mp3");
                    System.Threading.Tasks.Task.Run(() => PlayWithDelayConditionally("Sounds/Battle Countdown Slower (prelude).mp3", "Sounds/Battle (MAJOR EDIT) wave 1 tune.mp3", DateTime.Now.AddMilliseconds(6000)));
                    //PlayWithDelayConditionallyDelegate p = PlayWithDelayConditionally;
                    //IAsyncResult res = p.BeginInvoke("Sounds/Battle Countdown Slower (prelude).mp3", "Sounds/Battle (MAJOR EDIT) wave 1 tune.mp3", 6000, null, null);
                }
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox)
                {
                    PlayMusicOnce("Sounds/11 - Looney_Invaders_Battle_Theme_Prelude1.mp3");
                    System.Threading.Tasks.Task.Run(() => PlayWithDelayConditionally("Sounds/11 - Looney_Invaders_Battle_Theme_Prelude1.mp3", "Sounds/04 - Looney Invaders Battle Theme (Wave 1) FINAL.mp3", DateTime.Now.AddMilliseconds(6000)));
                    //PlayWithDelayConditionallyDelegate p = PlayWithDelayConditionally;
                    //IAsyncResult res = p.BeginInvoke("Sounds/11 - Looney_Invaders_Battle_Theme_Prelude1.mp3", "Sounds/04 - Looney Invaders Battle Theme (Wave 1) FINAL.mp3", 6000, null, null);
                }
            }
            else if (music == MUSIC.BATTLE_COUNTDOWNALIEN)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental)
                {
                    PlayMusicOnce("Sounds/GET READY FOR ALIEN BATTLE.mp3");
                    System.Threading.Tasks.Task.Run(() => PlayWithDelayConditionally("Sounds/GET READY FOR ALIEN BATTLE.mp3", "Sounds/Sounds/Final Battle Theme speed -1 (111%).mp3", DateTime.Now.AddMilliseconds(6000)));
                    //PlayWithDelayConditionallyDelegate p = PlayWithDelayConditionally;
                    //IAsyncResult res = p.BeginInvoke("Sounds/GET READY FOR ALIEN BATTLE.mp3", "Sounds/Sounds/Final Battle Theme speed -1 (111%).mp3", 6000, null, null);

                }
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox)
                {
                    PlayMusicOnce("Sounds/15 - Looney Invaders Battle Theme Space Prelude.mp3");
                    System.Threading.Tasks.Task.Run(() => PlayWithDelayConditionally("Sounds/11 - Looney_Invaders_Battle_Theme_Prelude1.mp3", "Sounds/04 - Looney Invaders Battle Theme (Wave 1) FINAL.mp3", DateTime.Now.AddMilliseconds(6000)));
                    //PlayWithDelayConditionallyDelegate p = PlayWithDelayConditionally;
                    //IAsyncResult res = p.BeginInvoke("Sounds/11 - Looney_Invaders_Battle_Theme_Prelude1.mp3", "Sounds/04 - Looney Invaders Battle Theme (Wave 1) FINAL.mp3", 6000, null, null);
                }
            }
            else if (music == MUSIC.NEXTWAVE)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) PlayMusicOnce("Sounds/Battle Countdown (interlude).mp3");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) PlayMusicOnce("Sounds/44 - Get Ready For The Next Attack.mp3");
            }
            else if (music == MUSIC.NEXTWAVEALIEN)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) PlayMusicOnce("Sounds/Alien Interlude.mp3");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) PlayMusicOnce("Sounds/111 - Get Ready For The Next Attack Space.mp3");
            }
        }

        public static void PlayMusic(string newMusic, bool fromStart = false)
        {
            if (newMusic == "") return;

            if (newMusic != MusicPlaying || fromStart == true || !CCAudioEngine.SharedEngine.BackgroundMusicPlaying)
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
            CCAudioEngine.SharedEngine.PlayBackgroundMusic(MusicPlaying,false);
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
        
        public static int? PlaySoundEffect(SOUNDEFFECT soundEffect)
        {
            if (soundEffect == SOUNDEFFECT.MENU_TAP)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/general button (Menu Selection change 1).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/General button (61).wav");
            }
            else if (soundEffect == SOUNDEFFECT.MENU_TAP_BACK)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Back button (Menu Selection deselect (backwards) 2).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Back button (39).wav");
            }
            else if (soundEffect == SOUNDEFFECT.MENU_TAP_FORWARD)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Forward button (Menu Selection Select 2).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Forward button (38).wav");
            }
            else if (soundEffect == SOUNDEFFECT.MENU_TAP_VOLUME_CHANGE)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Volume Change.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Sound volume tester (06).wav");
            }
            else if (soundEffect == SOUNDEFFECT.MENU_TAP_MINUS)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Minus Sound 1.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/- button (37).wav");
            }
            else if (soundEffect == SOUNDEFFECT.MENU_TAP_PLUS)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Plus Sound 1.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/+ button (36).wav");
            }
            else if (soundEffect == SOUNDEFFECT.MENU_TAP_CANNOT_TAP)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Cannot tap 1.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Negative&Error (54).wav");
            }
            else if (soundEffect == SOUNDEFFECT.MENU_TAP_CHECKMARK)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Check Sound 1.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Checked (1).wav");
            }
            else if (soundEffect == SOUNDEFFECT.CLICK_LINK)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Click link effect (enemy or map change forward).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Click link effect (07).wav");
            }
            else if (soundEffect == SOUNDEFFECT.ON)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/on button (Menu Selection deselect (backwards) 1).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/On button (41).wav");
            }
            else if (soundEffect == SOUNDEFFECT.OFF)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/off button (Menu Selection Select 1).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Off button (42).wav");
            }
            else if (soundEffect == SOUNDEFFECT.MENU_TAP_CREDITPURCHASE)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/purchase 3.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Credit purchase (43).wav");
            }
            else if (soundEffect == SOUNDEFFECT.ENEMY_HURT_1)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy - hurt 1.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy hit Sound When hurt (15).wav");
            }
            else if (soundEffect == SOUNDEFFECT.ENEMY_HURT_2)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy - hurt 1.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy hit Sound When hurt (15).wav");
            }
            else if (soundEffect == SOUNDEFFECT.ENEMY_HURT_3)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy - hurt 1.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy hit Sound When hurt (15).wav");
            }
            else if (soundEffect == SOUNDEFFECT.ENEMY_KILLED)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy - killed .wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy hit Sound When killed (21).wav");
            }
            else if (soundEffect == SOUNDEFFECT.ENEMY_SPIT)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Combines enemy attack 1.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy drooling & bomb whistle (18 43)_1.wav");
            }
            else if (soundEffect == SOUNDEFFECT.ENEMY_SPIT2)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Combines enemy attack 2.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy drooling & bomb whistle (18 43)_1.wav");
            }
            else if (soundEffect == SOUNDEFFECT.ENEMY_SPIT3)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Combines enemy attack 3.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy drooling & bomb whistle (18 43)_2.wav");
            }
            else if (soundEffect == SOUNDEFFECT.ENEMY_SPIT4)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Combines enemy attack 4.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Enemy drooling & bomb whistle (18 43)_3.wav");
            }
            else if (soundEffect == SOUNDEFFECT.GUN_HIT_1)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Gun - Hit 1.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Cannon explosion(49).wav");
            }
            else if (soundEffect == SOUNDEFFECT.GUN_HIT_2)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Gun - Hit 2.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Cannon explosion(49).wav");
            }
            else if (soundEffect == SOUNDEFFECT.GUN_HIT_3)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Gun - Hit 3.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Cannon explosion(49).wav");
            }
            else if (soundEffect == SOUNDEFFECT.GUN_HIT_GAME_OVER)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Game Over Explosion(instrumental).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/game over explosion.wav");
            }
            else if (soundEffect == SOUNDEFFECT.CALIBRE_1)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Reloading (Calibre 2).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Reloading (14 ).wav");
            }
            else if (soundEffect == SOUNDEFFECT.CALIBRE_1_HYBRID)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hybrid Canon Reload.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/98 - Hybrid Reloading 1.wav");
            }
            //else if (soundEffect == SOUNDEFFECT.BOMB_FALL1)
            //{
            //    if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) { }// return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bomb fall 1 .wav");
            //    else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Falling bomb (27__Bomb_Whistle_tuned).wav");
            //}
            //else if (soundEffect == SOUNDEFFECT.BOMB_FALL2)
            //{
            //    if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) { }// return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bomb fall 2.wav");
            //    else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Falling bomb (27__Bomb_Whistle_tuned).wav");
            //}
            //else if (soundEffect == SOUNDEFFECT.BOMB_FALL3)
            //{
            //    if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) { }// return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Bomb fall 3 .wav");
            //    else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Falling bomb (27__Bomb_Whistle_tuned).wav");
            //}
            else if (soundEffect == SOUNDEFFECT.EMPTY_CANON)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Empty Canon.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Cannot Shoot (10).wav");
            }
            else if (soundEffect == SOUNDEFFECT.EMPTY_CANON_HYBRID)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Hybrid Canon No Ammo.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/62__Harsh_Click.wav");
            }
            else if (soundEffect == SOUNDEFFECT.COUNTDOWN)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Countdown (March) 4.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/number countdown (53).wav");
            }
            else if (soundEffect == SOUNDEFFECT.COUNTDOWNALIEN)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Slime 1.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Space countdown (84)_mono .wav");
            }
            else if (soundEffect == SOUNDEFFECT.REWARD_NOTIFICATION)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Reward Notification 2.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Reward Pop-up (43).wav");
            }
            else if (soundEffect == SOUNDEFFECT.NOTIFICATION_POP_UP)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/General pop-up (Number pop 2).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/General Pop-up (35).wav");
            }
            else if (soundEffect == SOUNDEFFECT.REWIND)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Rewind (Numbers Rolling 1).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Rewind (47).wav");
            }
            else if (soundEffect == SOUNDEFFECT.SHOWSCORE)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Score & number poppin out (Number pop 3).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Score & numbers poppin out (40).wav");
            }
            else if (soundEffect == SOUNDEFFECT.SWIPE)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Swipe effect (Screen Transition 2).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Swipe effect (07).wav");
            }
            else if (soundEffect == SOUNDEFFECT.TEXTAPPEARS)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/text appears (enemy or map change Backwards).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/text apears (23).wav");
            }
            else if (soundEffect == SOUNDEFFECT.TRANSITION_LOOP1)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop1 (Number pop 1).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop1 (61).wav");
            }
            else if (soundEffect == SOUNDEFFECT.TRANSITION_LOOP2)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop2 (Number pop 1).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop2 (61).wav");
            }
            else if (soundEffect == SOUNDEFFECT.TRANSITION_LOOP3)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop3 (Number pop 1).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop3 (61).wav");
            }
            else if (soundEffect == SOUNDEFFECT.TRANSITION_LOOP4)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop4 (Number pop 1).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop4 (61).wav");
            }
            else if (soundEffect == SOUNDEFFECT.TRANSITION_LOOP5)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop5 (Number pop 1).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop5 (61).wav");
            }
            else if (soundEffect == SOUNDEFFECT.TRANSITION_LOOP6)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop6 (Number pop 1).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Transition_loop6 (61).wav");
            }
            else if (soundEffect == SOUNDEFFECT.ALIEN_LASER)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental)  return CCAudioEngine.SharedEngine.PlayEffect("Sounds/NEW LAZER 2.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Alien lazer compo (6 & 10).wav");
            }
            else if (soundEffect == SOUNDEFFECT.ALIEN_SPIT)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Slime 1.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Alien Spitting & slime oozing 1 (83 & 71).wav");
            }
            else if (soundEffect == SOUNDEFFECT.ALIEN_SPIT2)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Slime 2.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Alien Spitting & slime oozing 2 (83 & 72).wav");
            }
            else if (soundEffect == SOUNDEFFECT.ALIEN_SPIT3)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Slime 3.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Alien Spitting & slime oozing 3 (83 & 72).wav");
            }
            else if (soundEffect == SOUNDEFFECT.MULTIPLIER_INDICATOR)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Multiplier level 4.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/multiplier indicator (87).wav");
            }
            else if (soundEffect == SOUNDEFFECT.MULTIPLIER_LOST)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Combo Loss2.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/109 - Score Multiplier Lost_with_echo.wav");
            }
            else if (soundEffect == SOUNDEFFECT.FLYINGSAUCER_INCOMING)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Mothership incoming 2.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/106 - UFO Alarm Sound.wav");
            }
            else if (soundEffect == SOUNDEFFECT.FLYINGSAUCER_FLYING)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Mothership Flying.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/107 - UFO Flying2_mono.wav");
            }
            else if (soundEffect == SOUNDEFFECT.FLYINGSAUCER_EXPLOSION)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Mothership Destroy.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/110A - UFO Explode_mono.wav");
            }
            else if (soundEffect == SOUNDEFFECT.CANNON_STILL)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Canon Still.wav", true);
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/108K - Hybrid Cannon Moving_slow.wav", true);
            }
            else if (soundEffect == SOUNDEFFECT.CANNON_SLOW)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Canon slow movement.wav", true);
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/108K - Hybrid Cannon Moving_medium.wav", true);
            }
            else if (soundEffect == SOUNDEFFECT.CANNON_FAST)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/Canon moving.wav", true);
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) return CCAudioEngine.SharedEngine.PlayEffect("Sounds/108K - Hybrid Cannon Moving_fast.wav", true);
            }
            return null;
        }

        public static void PreloadSoundEffect(SOUNDEFFECT soundEffect)
        {
            if (soundEffect == SOUNDEFFECT.MENU_TAP)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/general button (Menu Selection change 1).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/General button (61).wav");
            }
            else if (soundEffect == SOUNDEFFECT.MENU_TAP_BACK)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Back button (Menu Selection deselect (backwards) 2).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Back button (39).wav");
            }
            else if (soundEffect == SOUNDEFFECT.MENU_TAP_FORWARD)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Forward button (Menu Selection Select 2).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Forward button (38).wav");
            }
            else if (soundEffect == SOUNDEFFECT.MENU_TAP_VOLUME_CHANGE)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Volume Change.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Sound volume tester (06).wav");
            }
            else if (soundEffect == SOUNDEFFECT.MENU_TAP_MINUS)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Minus Sound 1.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/- button (37).wav");
            }
            else if (soundEffect == SOUNDEFFECT.MENU_TAP_PLUS)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Plus Sound 1.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/+ button (36).wav");
            }
            else if (soundEffect == SOUNDEFFECT.MENU_TAP_CANNOT_TAP)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Negative Pop up .wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Negative&Error (54).wav");
            }
            else if (soundEffect == SOUNDEFFECT.MENU_TAP_CHECKMARK)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Check Sound 1.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Checked (1).wav");
            }
            else if (soundEffect == SOUNDEFFECT.CLICK_LINK)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Click link effect (enemy or map change forward).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Click link effect (07).wav");
            }
            else if (soundEffect == SOUNDEFFECT.ON)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/on button (Menu Selection deselect (backwards) 1).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/On button (41).wav");
            }
            else if (soundEffect == SOUNDEFFECT.OFF)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/off button (Menu Selection Select 1).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Off button (42).wav");
            }
            else if (soundEffect == SOUNDEFFECT.MENU_TAP_CREDITPURCHASE)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/purchase 3.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Credit purchase (43).wav");
            }
            else if (soundEffect == SOUNDEFFECT.ENEMY_HURT_1)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy - hurt 1.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy hit Sound When hurt (15).wav");
            }
            else if (soundEffect == SOUNDEFFECT.ENEMY_HURT_2)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy - hurt 1.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy hit Sound When hurt (15).wav");
            }
            else if (soundEffect == SOUNDEFFECT.ENEMY_HURT_3)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy - hurt 1.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy hit Sound When hurt (15).wav");
            }
            else if (soundEffect == SOUNDEFFECT.ENEMY_KILLED)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy - killed .wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy hit Sound When killed (21).wav");
            }
            else if (soundEffect == SOUNDEFFECT.ENEMY_SPIT)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Combines enemy attack 1.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy drooling & bomb whistle (18 43)_1.wav");
            }
            else if (soundEffect == SOUNDEFFECT.ENEMY_SPIT2)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Combines enemy attack 2.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy drooling & bomb whistle (18 43)_1.wav");
            }
            else if (soundEffect == SOUNDEFFECT.ENEMY_SPIT3)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Combines enemy attack 3.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy drooling & bomb whistle (18 43)_2.wav");
            }
            else if (soundEffect == SOUNDEFFECT.ENEMY_SPIT4)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Combines enemy attack 4.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Enemy drooling & bomb whistle (18 43)_3.wav");
            }
            else if (soundEffect == SOUNDEFFECT.GUN_HIT_1)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Gun - Hit 1.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Cannon explosion(49).wav");
            }
            else if (soundEffect == SOUNDEFFECT.GUN_HIT_2)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Gun - Hit 2.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Cannon explosion(49).wav");
            }
            else if (soundEffect == SOUNDEFFECT.GUN_HIT_3)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Gun - Hit 3.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Cannon explosion(49).wav");
            }
            else if (soundEffect == SOUNDEFFECT.GUN_HIT_GAME_OVER)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Game Over Explosion(instrumental).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/game over explosion.wav");
            }
            else if (soundEffect == SOUNDEFFECT.CALIBRE_1)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Reloading (Calibre 2).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Reloading (14 ).wav");
            }
            else if (soundEffect == SOUNDEFFECT.CALIBRE_1_HYBRID)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Hybrid Canon Reload.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/98 - Hybrid Reloading 1.wav");
            }
            //else if (soundEffect == SOUNDEFFECT.BOMB_FALL1)
            //{
            //    if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) { }// CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Bomb fall 1 .wav");
            //    else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Falling bomb (27__Bomb_Whistle_tuned).wav");
            //}
            //else if (soundEffect == SOUNDEFFECT.BOMB_FALL2)
            //{
            //    if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) { }// CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Bomb fall 2.wav");
            //    else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Falling bomb (27__Bomb_Whistle_tuned).wav");
            //}
            //else if (soundEffect == SOUNDEFFECT.BOMB_FALL3)
            //{
            //    if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) { }// CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Bomb fall 3 .wav");
            //    else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Falling bomb (27__Bomb_Whistle_tuned).wav");
            //}
            else if (soundEffect == SOUNDEFFECT.EMPTY_CANON)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Empty Canon.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Cannot Shoot (10).wav");
            }
            else if (soundEffect == SOUNDEFFECT.EMPTY_CANON_HYBRID)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Hybrid Canon No Ammo.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/62__Harsh_Click.wav");
            }
            else if (soundEffect == SOUNDEFFECT.COUNTDOWN)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Countdown (March) 4.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/number countdown (53).wav");
            }
            else if (soundEffect == SOUNDEFFECT.COUNTDOWNALIEN)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Slime 1.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Space countdown (84)_mono .wav");
            }
            else if (soundEffect == SOUNDEFFECT.REWARD_NOTIFICATION)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Reward Notification 2.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Reward Pop-up (43).wav");
            }
            else if (soundEffect == SOUNDEFFECT.NOTIFICATION_POP_UP)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/General pop-up (Number pop 2).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/General Pop-up (35).wav");
            }
            else if (soundEffect == SOUNDEFFECT.REWIND)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Rewind (Numbers Rolling 1).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Rewind (47).wav");
            }
            else if (soundEffect == SOUNDEFFECT.SHOWSCORE)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Score & number poppin out (Number pop 3).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Score & numbers poppin out (40).wav");
            }
            else if (soundEffect == SOUNDEFFECT.SWIPE)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Swipe effect (Screen Transition 2).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Swipe effect (07).wav");
            }
            else if (soundEffect == SOUNDEFFECT.TEXTAPPEARS)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/text appears (enemy or map change Backwards).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/text apears (23).wav");
            }
            else if (soundEffect == SOUNDEFFECT.TRANSITION_LOOP1)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop1 (Number pop 1).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop1 (61).wav");
            }
            else if (soundEffect == SOUNDEFFECT.TRANSITION_LOOP2)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop2 (Number pop 1).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop2 (61).wav");
            }
            else if (soundEffect == SOUNDEFFECT.TRANSITION_LOOP3)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop3 (Number pop 1).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop3 (61).wav");
            }
            else if (soundEffect == SOUNDEFFECT.TRANSITION_LOOP4)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop4 (Number pop 1).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop4 (61).wav");
            }
            else if (soundEffect == SOUNDEFFECT.TRANSITION_LOOP5)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop5 (Number pop 1).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop5 (61).wav");
            }
            else if (soundEffect == SOUNDEFFECT.TRANSITION_LOOP6)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop6 (Number pop 1).wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Transition_loop6 (61).wav");
            }
            else if (soundEffect == SOUNDEFFECT.ALIEN_LASER)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental)  CCAudioEngine.SharedEngine.PreloadEffect("Sounds/NEW LAZER 2.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Alien lazer compo (6 & 10).wav");
            }
            else if (soundEffect == SOUNDEFFECT.ALIEN_SPIT)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Slime 1.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Alien Spitting & slime oozing 1 (83 & 71).wav");
            }
            else if (soundEffect == SOUNDEFFECT.ALIEN_SPIT2)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Slime 2.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Alien Spitting & slime oozing 2 (83 & 72).wav");
            }
            else if (soundEffect == SOUNDEFFECT.ALIEN_SPIT3)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Slime 3.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Alien Spitting & slime oozing 3 (83 & 72).wav");
            }
            else if (soundEffect == SOUNDEFFECT.MULTIPLIER_INDICATOR)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Multiplier level 4.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/multiplier indicator (87).wav");
            }
            else if (soundEffect == SOUNDEFFECT.MULTIPLIER_LOST)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Combo Loss2.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/109 - Score Multiplier Lost_with_echo.wav");
            }
            else if (soundEffect == SOUNDEFFECT.FLYINGSAUCER_INCOMING)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Mothership incoming 2.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/106 - UFO Alarm Sound.wav");
            }
            else if (soundEffect == SOUNDEFFECT.FLYINGSAUCER_FLYING)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Mothership Flying.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/107 - UFO Flying2_mono.wav");
            }
            else if (soundEffect == SOUNDEFFECT.FLYINGSAUCER_EXPLOSION)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Mothership Destroy.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/110A - UFO Explode_mono.wav");
            }
            else if (soundEffect == SOUNDEFFECT.CANNON_STILL)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Canon Still.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/108K - Hybrid Cannon Moving_slow.wav");
            }
            else if (soundEffect == SOUNDEFFECT.CANNON_SLOW)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Canon slow movement.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/108K - Hybrid Cannon Moving_medium.wav");
            }
            else if (soundEffect == SOUNDEFFECT.CANNON_FAST)
            {
                if (Settings.Instance.MusicStyle == MUSIC_STYLE.Instrumental) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/Canon moving.wav");
                else if (Settings.Instance.MusicStyle == MUSIC_STYLE.Beatbox) CCAudioEngine.SharedEngine.PreloadEffect("Sounds/108K - Hybrid Cannon Moving_fast.wav");
            }
        }

    }
}
