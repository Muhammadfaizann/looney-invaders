using System;
using System.Collections.Generic;
using System.Text;
using CocosSharp;
using Microsoft.Xna.Framework;

namespace LooneyInvaders.Model
{
    public class GameAnimation
    {
        private string LoadedAnimation = "";

        private List<CCSpriteSheet> ssAdolfTalk = new List<CCSpriteSheet>();
        private List<CCSpriteSheet> ssBushTalk = new List<CCSpriteSheet>();
        private List<CCSpriteSheet> ssKimTalk = new List<CCSpriteSheet>();
        private List<CCSpriteSheet> ssPutinTalk = new List<CCSpriteSheet>();
        private List<CCSpriteSheet> ssAlienTalk = new List<CCSpriteSheet>();

        private List<CCSpriteSheet> ssStandardBow = new List<CCSpriteSheet>();
        private List<CCSpriteSheet> ssCompactBow = new List<CCSpriteSheet>();
        private List<CCSpriteSheet> ssBazookaBow = new List<CCSpriteSheet>();
        private List<CCSpriteSheet> ssHybridBow = new List<CCSpriteSheet>();

        private List<CCSpriteSheet> ssStandardRotate = new List<CCSpriteSheet>();
        private List<CCSpriteSheet> ssCompactRotate = new List<CCSpriteSheet>();
        private List<CCSpriteSheet> ssBazookaRotate = new List<CCSpriteSheet>();
        private List<CCSpriteSheet> ssHitlerRotate = new List<CCSpriteSheet>();
        private List<CCSpriteSheet> ssKimRotate = new List<CCSpriteSheet>();
        private List<CCSpriteSheet> ssPutinRotate = new List<CCSpriteSheet>();
        private List<CCSpriteSheet> ssBushRotate = new List<CCSpriteSheet>();

        private GameAnimation()
        { }

        private static GameAnimation _instance = null;

        public static GameAnimation Instance
        {
            get
            {
                if (_instance == null) _instance = new GameAnimation();
                return _instance;
            }
        }

        public bool PreloadNextSpriteSheet()
        {
            // for phones with less than 500 MB RAM, we don't preload
            if (GameEnvironment.GetTotalRAMSizeMB() < 500) return false;

            if (PreloadNextSpriteSheetEnemies() == true) return true;
            if (PreloadNextSpriteSheetWeapons() == true) return true;
            return false;
        }

        public void FreeAllSpriteSheets(bool onlyRotations = false)
        {
            Console.WriteLine("Freeing all sprite sheets");

            List<CCSpriteSheet> ssAll = new List<CCSpriteSheet>();
            if(onlyRotations == false) ssAll.AddRange(ssAdolfTalk);
            if (onlyRotations == false) ssAll.AddRange(ssBushTalk);
            if (onlyRotations == false) ssAll.AddRange(ssKimTalk);
            if (onlyRotations == false) ssAll.AddRange(ssPutinTalk);
            if (onlyRotations == false) ssAll.AddRange(ssAlienTalk);
            if (onlyRotations == false) ssAll.AddRange(ssStandardBow);
            if (onlyRotations == false) ssAll.AddRange(ssCompactBow);
            if (onlyRotations == false) ssAll.AddRange(ssBazookaBow);
            if (onlyRotations == false) ssAll.AddRange(ssHybridBow);
            ssAll.AddRange(ssStandardRotate);
            ssAll.AddRange(ssCompactRotate);
            ssAll.AddRange(ssBazookaRotate);
            ssAll.AddRange(ssHitlerRotate);
            ssAll.AddRange(ssKimRotate);
            ssAll.AddRange(ssPutinRotate);
            ssAll.AddRange(ssBushRotate);

            foreach (CCSpriteSheet ss in ssAll)
            {
                CCTexture2D texture = ss.Frames[0].Texture;
                
                if (texture.XNATexture.IsDisposed == false) texture.XNATexture.Dispose();
                if (texture.IsDisposed == false) texture.Dispose();
                                
                CCTextureCache.SharedTextureCache.RemoveTexture(texture);
                CCSpriteFrameCache.SharedSpriteFrameCache.RemoveSpriteFrames(texture);
            }

            ssAll.Clear();
            if (onlyRotations == false) ssAdolfTalk.Clear();
            if (onlyRotations == false) ssBushTalk.Clear();
            if (onlyRotations == false) ssKimTalk.Clear();
            if (onlyRotations == false) ssPutinTalk.Clear();
            if (onlyRotations == false) ssAlienTalk.Clear();
            if (onlyRotations == false) ssStandardBow.Clear();
            if (onlyRotations == false) ssCompactBow.Clear();
            if (onlyRotations == false) ssBazookaBow.Clear();
            if (onlyRotations == false) ssHybridBow.Clear();
            ssStandardRotate.Clear();
            ssCompactRotate.Clear();
            ssBazookaRotate.Clear();
            ssHitlerRotate.Clear();
            ssKimRotate.Clear();
            ssPutinRotate.Clear();
            ssBushRotate.Clear();

            CCSpriteSheetCache.Instance.RemoveAll();
            CCSpriteFrameCache.SharedSpriteFrameCache.RemoveUnusedSpriteFrames();
            CCSpriteFrameCache.SharedSpriteFrameCache.RemoveSpriteFrames();
            CCTextureCache.SharedTextureCache.RemoveUnusedTextures();
            CCTextureCache.SharedTextureCache.RemoveAllTextures();
            CCTextureCache.SharedTextureCache.UnloadContent();
           
            /* 
            GC.Collect();
            GC.Collect(1);
            GC.Collect(2);
            GC.Collect(GC.MaxGeneration);
            GC.WaitForPendingFinalizers();
            */
        }

        public bool PreloadNextSpriteSheetEnemies()
        {
            if (GameEnvironment.GetTotalRAMSizeMB() < 500) return false;

            if (ssAdolfTalk.Count < 2)
            {
                Console.WriteLine("PRELOAD: Hitler talk " + (ssAdolfTalk.Count + 1).ToString() + "/2");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/Adolf-" + ssAdolfTalk.Count.ToString() + ".plist");
                ssAdolfTalk.Add(ss);
                return true;
            }

            if (ssBushTalk.Count < 2)
            {
                Console.WriteLine("PRELOAD: Bush talk " + (ssBushTalk.Count + 1).ToString() + "/2");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/Bush-" + ssBushTalk.Count.ToString() + ".plist");
                ssBushTalk.Add(ss);
                return true;
            }

            if (ssKimTalk.Count < 3)
            {
                Console.WriteLine("PRELOAD: Kim talk " + (ssKimTalk.Count + 1).ToString() + "/3");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/Kim-" + ssKimTalk.Count.ToString() + ".plist");
                ssKimTalk.Add(ss);
                return true;
            }

            if (ssPutinTalk.Count < 2)
            {
                Console.WriteLine("PRELOAD: Putin talk " + (ssPutinTalk.Count + 1).ToString() + "/2");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/Putin-" + ssPutinTalk.Count.ToString() + ".plist");
                ssPutinTalk.Add(ss);
                return true;
            }

            if (ssAlienTalk.Count < 6)
            {
                Console.WriteLine("PRELOAD: Alien talk " + (ssAlienTalk.Count + 1).ToString() + "/6");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/Alien-" + ssAlienTalk.Count.ToString() + ".plist");
                ssAlienTalk.Add(ss);
                return true;
            }

            return false;
        }

        public CCSpriteFrame GetEnemyTalkFrame(ENEMIES enemy, int frameIndex)
        {
            string imageNamePrefix = "";

            if (enemy == ENEMIES.BUSH) imageNamePrefix = "Bush-Safe-C_";
            else if (enemy == ENEMIES.HITLER) imageNamePrefix = "Hitler-Strength-E";
            else if (enemy == ENEMIES.PUTIN) imageNamePrefix = "Putin-Strength-D";
            else if (enemy == ENEMIES.KIM) imageNamePrefix = "Kim-Strength-D";
            else if (enemy == ENEMIES.ALIENS) imageNamePrefix = "Alien-C-5_";

            string imageName = imageNamePrefix + frameIndex.ToString("00000") + ".png";

            CCSpriteFrame frame = null;

            if (enemy == ENEMIES.HITLER)
            {                
                int ssIndex = (frameIndex - 1) / 77;
                frame = ssAdolfTalk[ssIndex][imageName];                
            }
            else if (enemy == ENEMIES.BUSH)
            {
                int ssIndex = (frameIndex - 1) / 70;
                frame = ssBushTalk[ssIndex][imageName];
            }
            else if (enemy == ENEMIES.KIM)
            {
                int ssIndex = (frameIndex - 1) / 63;
                frame = ssKimTalk[ssIndex][imageName];                
            }
            else if (enemy == ENEMIES.PUTIN)
            {
                int ssIndex = (frameIndex - 1) / 70;
                frame = ssPutinTalk[ssIndex][imageName];                
            }
            else if (enemy == ENEMIES.ALIENS)
            {
                int ssIndex = (frameIndex - 1) / 70;
                frame = ssAlienTalk[ssIndex][imageName];
            }

            return frame;
        }

        public bool PreloadNextSpriteSheetWeapons()
        {
            if (GameEnvironment.GetTotalRAMSizeMB() < 500) return false;
            
            if (ssStandardBow.Count < 2)
            {
                Console.WriteLine("PRELOAD: Standard bow " + (ssStandardBow.Count + 1).ToString() + "/2");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/StandardBow-" + ssStandardBow.Count.ToString() + ".plist");
                ssStandardBow.Add(ss);
                return true;
            }

            if (ssCompactBow.Count < 2)
            {
                Console.WriteLine("PRELOAD: Compact bow " + (ssCompactBow.Count + 1).ToString() + "/2");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/CompactBow-" + ssCompactBow.Count.ToString() + ".plist");
                ssCompactBow.Add(ss);
                return true;
            }

            if (ssBazookaBow.Count < 2)
            {
                Console.WriteLine("PRELOAD: Bazooka bow " + (ssBazookaBow.Count + 1).ToString() + "/2");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/BazookaBow-" + ssBazookaBow.Count.ToString() + ".plist");
                ssBazookaBow.Add(ss);
                return true;
            }

            if (ssHybridBow.Count < 2)
            {
                Console.WriteLine("PRELOAD: Hybrid bow " + (ssHybridBow.Count + 1).ToString() + "/2");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/HybridBow-" + ssHybridBow.Count.ToString() + ".plist");
                ssHybridBow.Add(ss);
                return true;
            }

            return false;
        }

        public CCSpriteFrame GetWeaponBowFrame(WEAPONS weapon, int frameIndex)
        {
            string imageNamePrefix = "";

            if (weapon == WEAPONS.STANDARD) imageNamePrefix = "standard_gun_bow_";
            else if (weapon == WEAPONS.COMPACT) imageNamePrefix = "compact-sprayer_bow_";
            else if (weapon == WEAPONS.BAZOOKA) imageNamePrefix = "black_bazooka_bow_";
            else if (weapon == WEAPONS.HYBRID) imageNamePrefix = "hybrid_defender_bow_";

            string imageName = imageNamePrefix + frameIndex.ToString("00") + ".png";

            CCSpriteFrame frame = null;

            if (weapon == WEAPONS.STANDARD)
            {                
                int ssIndex = (frameIndex - 1) / 35;
                frame = ssStandardBow[ssIndex][imageName];
            }
            else if (weapon == WEAPONS.COMPACT)
            {
                int ssIndex = (frameIndex - 1) / 35;
                frame = ssCompactBow[ssIndex][imageName];
            }
            else if (weapon == WEAPONS.BAZOOKA)
            {
                int ssIndex = (frameIndex - 1) / 35;
                frame = ssBazookaBow[ssIndex][imageName];
            }
            else if (weapon == WEAPONS.HYBRID)
            {
                int ssIndex = (frameIndex - 1) / 35;
                frame = ssHybridBow[ssIndex][imageName];
            }

            return frame;
        }

        public bool PreloadNextSpriteSheetRotate(WEAPONS? weapon, ENEMIES? enemy)
        {
            //if (GameEnvironment.GetTotalRAMSizeMB() < 500) return false;

            if (weapon == WEAPONS.STANDARD && ssStandardRotate.Count < 2)
            {
                Console.WriteLine("PRELOAD: Standard rotate " + (ssStandardRotate.Count + 1).ToString() + "/2");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/StandardCannonRotate-" + ssStandardRotate.Count.ToString() + ".plist");
                ssStandardRotate.Add(ss);
                return true;
            }

            if (weapon == WEAPONS.COMPACT && ssCompactRotate.Count < 2)
            {
                Console.WriteLine("PRELOAD: Compact rotate " + (ssCompactRotate.Count + 1).ToString() + "/2");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/CompactSprayerRotate-" + ssCompactRotate.Count.ToString() + ".plist");
                ssCompactRotate.Add(ss);
                return true;
            }

            if (weapon == WEAPONS.BAZOOKA && ssBazookaRotate.Count < 2)
            {
                Console.WriteLine("PRELOAD: Bazooka rotate " + (ssBazookaRotate.Count + 1).ToString() + "/2");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/BlackBazookaRotate-" + ssBazookaRotate.Count.ToString() + ".plist");
                ssBazookaRotate.Add(ss);
                return true;
            }

            if (enemy == ENEMIES.HITLER && ssHitlerRotate.Count < 1)
            {
                Console.WriteLine("PRELOAD: Hitler rotate " + (ssHitlerRotate.Count + 1).ToString() + "/1");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/HitlerRotate.plist");
                ssHitlerRotate.Add(ss);
                return true;
            }

            if (enemy == ENEMIES.KIM && ssKimRotate.Count < 1)
            {
                Console.WriteLine("PRELOAD: Kim rotate " + (ssKimRotate.Count + 1).ToString() + "/1");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/KimRotate.plist");
                ssKimRotate.Add(ss);
                return true;
            }

            if (enemy == ENEMIES.PUTIN && ssPutinRotate.Count < 1)
            {
                Console.WriteLine("PRELOAD: Putin rotate " + (ssPutinRotate.Count + 1).ToString() + "/1");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/PutinRotate.plist");
                ssPutinRotate.Add(ss);
                return true;
            }

            if (enemy == ENEMIES.BUSH && ssBushRotate.Count < 1)
            {
                Console.WriteLine("PRELOAD: Bush rotate " + (ssBushRotate.Count + 1).ToString() + "/1");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/BushRotate.plist");
                ssBushRotate.Add(ss);
                return true;
            }

            return false;
        }

        public CCSpriteFrame GetRotateFrame(WEAPONS? weapon, ENEMIES? enemy, int frameIndex)
        {
            string imageNamePrefix = "";

            if (weapon == WEAPONS.STANDARD) imageNamePrefix = "standard_gun_rotation_image_";
            else if (weapon == WEAPONS.COMPACT) imageNamePrefix = "compact_sprayer_rotation_image_";
            else if (weapon == WEAPONS.BAZOOKA) imageNamePrefix = "Black_bazooka_rotation_image_";
            else if (enemy == ENEMIES.HITLER) imageNamePrefix = "Hitler_rotation_image_";
            else if (enemy == ENEMIES.KIM) imageNamePrefix = "kim_rotation_image_";
            else if (enemy == ENEMIES.PUTIN) imageNamePrefix = "putin_rotation_image_";
            else if (enemy == ENEMIES.BUSH) imageNamePrefix = "Hitler_rotation_image_";

            string imageName = imageNamePrefix + frameIndex.ToString("00") + ".png";

            CCSpriteFrame frame = null;

            if (weapon == WEAPONS.STANDARD)
            {
                int ssIndex = frameIndex / 28;
                frame = ssStandardRotate[ssIndex][imageName];
            }
            else if (weapon == WEAPONS.COMPACT)
            {
                int ssIndex = frameIndex / 28;
                frame = ssCompactRotate[ssIndex][imageName];
            }
            else if (weapon == WEAPONS.BAZOOKA)
            {
                int ssIndex = frameIndex / 28;
                frame = ssBazookaRotate[ssIndex][imageName];
            }
            else if (enemy == ENEMIES.HITLER)
            {                
                frame = ssHitlerRotate[0][imageName];
            }
            else if (enemy == ENEMIES.KIM)
            {
                frame = ssKimRotate[0][imageName];
            }
            else if (enemy == ENEMIES.PUTIN)
            {
                frame = ssPutinRotate[0][imageName];
            }
            else if (enemy == ENEMIES.BUSH)
            {
                frame = ssBushRotate[0][imageName];
            }

            return frame;
        }
    }
}
