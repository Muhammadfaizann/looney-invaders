using System;
using System.Collections.Generic;
using CocosSharp;

namespace LooneyInvaders.Model
{
    public class GameAnimation
    {
        //private string LoadedAnimation = "";

        private readonly List<CCSpriteSheet> _ssAdolfTalk = new List<CCSpriteSheet>();
        private readonly List<CCSpriteSheet> _ssBushTalk = new List<CCSpriteSheet>();
        private readonly List<CCSpriteSheet> _ssKimTalk = new List<CCSpriteSheet>();
        private readonly List<CCSpriteSheet> _ssPutinTalk = new List<CCSpriteSheet>();
        private readonly List<CCSpriteSheet> _ssAlienTalk = new List<CCSpriteSheet>();

        private readonly List<CCSpriteSheet> _ssStandardBow = new List<CCSpriteSheet>();
        private readonly List<CCSpriteSheet> _ssCompactBow = new List<CCSpriteSheet>();
        private readonly List<CCSpriteSheet> _ssBazookaBow = new List<CCSpriteSheet>();
        private readonly List<CCSpriteSheet> _ssHybridBow = new List<CCSpriteSheet>();

        private readonly List<CCSpriteSheet> _ssStandardRotate = new List<CCSpriteSheet>();
        private readonly List<CCSpriteSheet> _ssCompactRotate = new List<CCSpriteSheet>();
        private readonly List<CCSpriteSheet> _ssBazookaRotate = new List<CCSpriteSheet>();
        private readonly List<CCSpriteSheet> _ssHitlerRotate = new List<CCSpriteSheet>();
        private readonly List<CCSpriteSheet> _ssKimRotate = new List<CCSpriteSheet>();
        private readonly List<CCSpriteSheet> _ssPutinRotate = new List<CCSpriteSheet>();
        private readonly List<CCSpriteSheet> _ssBushRotate = new List<CCSpriteSheet>();

        private GameAnimation()
        { }

        private static GameAnimation _instance;

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

            if (PreloadNextSpriteSheetEnemies()) return true;
            if (PreloadNextSpriteSheetWeapons()) return true;
            return false;
        }

        public void FreeAllSpriteSheets(bool onlyRotations = false)
        {
            Console.WriteLine("Freeing all sprite sheets");

            List<CCSpriteSheet> ssAll = new List<CCSpriteSheet>();
            if (onlyRotations == false) ssAll.AddRange(_ssAdolfTalk);
            if (onlyRotations == false) ssAll.AddRange(_ssBushTalk);
            if (onlyRotations == false) ssAll.AddRange(_ssKimTalk);
            if (onlyRotations == false) ssAll.AddRange(_ssPutinTalk);
            if (onlyRotations == false) ssAll.AddRange(_ssAlienTalk);
            if (onlyRotations == false) ssAll.AddRange(_ssStandardBow);
            if (onlyRotations == false) ssAll.AddRange(_ssCompactBow);
            if (onlyRotations == false) ssAll.AddRange(_ssBazookaBow);
            if (onlyRotations == false) ssAll.AddRange(_ssHybridBow);
            ssAll.AddRange(_ssStandardRotate);
            ssAll.AddRange(_ssCompactRotate);
            ssAll.AddRange(_ssBazookaRotate);
            ssAll.AddRange(_ssHitlerRotate);
            ssAll.AddRange(_ssKimRotate);
            ssAll.AddRange(_ssPutinRotate);
            ssAll.AddRange(_ssBushRotate);

            foreach (CCSpriteSheet ss in ssAll)
            {
                CCTexture2D texture = ss.Frames[0].Texture;

                if (texture.XNATexture.IsDisposed == false) texture.XNATexture.Dispose();
                if (texture.IsDisposed == false) texture.Dispose();

                CCTextureCache.SharedTextureCache.RemoveTexture(texture);
                CCSpriteFrameCache.SharedSpriteFrameCache.RemoveSpriteFrames(texture);
            }

            ssAll.Clear();
            if (onlyRotations == false) _ssAdolfTalk.Clear();
            if (onlyRotations == false) _ssBushTalk.Clear();
            if (onlyRotations == false) _ssKimTalk.Clear();
            if (onlyRotations == false) _ssPutinTalk.Clear();
            if (onlyRotations == false) _ssAlienTalk.Clear();
            if (onlyRotations == false) _ssStandardBow.Clear();
            if (onlyRotations == false) _ssCompactBow.Clear();
            if (onlyRotations == false) _ssBazookaBow.Clear();
            if (onlyRotations == false) _ssHybridBow.Clear();
            _ssStandardRotate.Clear();
            _ssCompactRotate.Clear();
            _ssBazookaRotate.Clear();
            _ssHitlerRotate.Clear();
            _ssKimRotate.Clear();
            _ssPutinRotate.Clear();
            _ssBushRotate.Clear();

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

            if (_ssAdolfTalk.Count < 2)
            {
                Console.WriteLine("PRELOAD: Hitler talk " + (_ssAdolfTalk.Count + 1).ToString() + "/2");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/Adolf-" + _ssAdolfTalk.Count.ToString() + ".plist");
                _ssAdolfTalk.Add(ss);
                return true;
            }

            if (_ssBushTalk.Count < 2)
            {
                Console.WriteLine("PRELOAD: Bush talk " + (_ssBushTalk.Count + 1).ToString() + "/2");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/Bush-" + _ssBushTalk.Count.ToString() + ".plist");
                _ssBushTalk.Add(ss);
                return true;
            }

            if (_ssKimTalk.Count < 3)
            {
                Console.WriteLine("PRELOAD: Kim talk " + (_ssKimTalk.Count + 1).ToString() + "/3");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/Kim-" + _ssKimTalk.Count.ToString() + ".plist");
                _ssKimTalk.Add(ss);
                return true;
            }

            if (_ssPutinTalk.Count < 2)
            {
                Console.WriteLine("PRELOAD: Putin talk " + (_ssPutinTalk.Count + 1).ToString() + "/2");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/Putin-" + _ssPutinTalk.Count.ToString() + ".plist");
                _ssPutinTalk.Add(ss);
                return true;
            }

            if (_ssAlienTalk.Count < 6)
            {
                Console.WriteLine("PRELOAD: Alien talk " + (_ssAlienTalk.Count + 1).ToString() + "/6");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/Alien-" + _ssAlienTalk.Count.ToString() + ".plist");
                _ssAlienTalk.Add(ss);
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
                frame = _ssAdolfTalk[ssIndex][imageName];
            }
            else if (enemy == ENEMIES.BUSH)
            {
                int ssIndex = (frameIndex - 1) / 70;
                frame = _ssBushTalk[ssIndex][imageName];
            }
            else if (enemy == ENEMIES.KIM)
            {
                int ssIndex = (frameIndex - 1) / 63;
                frame = _ssKimTalk[ssIndex][imageName];
            }
            else if (enemy == ENEMIES.PUTIN)
            {
                int ssIndex = (frameIndex - 1) / 70;
                frame = _ssPutinTalk[ssIndex][imageName];
            }
            else if (enemy == ENEMIES.ALIENS)
            {
                int ssIndex = (frameIndex - 1) / 70;
                frame = _ssAlienTalk[ssIndex][imageName];
            }

            return frame;
        }

        public bool PreloadNextSpriteSheetWeapons()
        {
            if (GameEnvironment.GetTotalRAMSizeMB() < 500) return false;

            if (_ssStandardBow.Count < 2)
            {
                Console.WriteLine("PRELOAD: Standard bow " + (_ssStandardBow.Count + 1).ToString() + "/2");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/StandardBow-" + _ssStandardBow.Count.ToString() + ".plist");
                _ssStandardBow.Add(ss);
                return true;
            }

            if (_ssCompactBow.Count < 2)
            {
                Console.WriteLine("PRELOAD: Compact bow " + (_ssCompactBow.Count + 1).ToString() + "/2");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/CompactBow-" + _ssCompactBow.Count.ToString() + ".plist");
                _ssCompactBow.Add(ss);
                return true;
            }

            if (_ssBazookaBow.Count < 2)
            {
                Console.WriteLine("PRELOAD: Bazooka bow " + (_ssBazookaBow.Count + 1).ToString() + "/2");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/BazookaBow-" + _ssBazookaBow.Count.ToString() + ".plist");
                _ssBazookaBow.Add(ss);
                return true;
            }

            if (_ssHybridBow.Count < 2)
            {
                Console.WriteLine("PRELOAD: Hybrid bow " + (_ssHybridBow.Count + 1).ToString() + "/2");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/HybridBow-" + _ssHybridBow.Count.ToString() + ".plist");
                _ssHybridBow.Add(ss);
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
                frame = _ssStandardBow[ssIndex][imageName];
            }
            else if (weapon == WEAPONS.COMPACT)
            {
                int ssIndex = (frameIndex - 1) / 35;
                frame = _ssCompactBow[ssIndex][imageName];
            }
            else if (weapon == WEAPONS.BAZOOKA)
            {
                int ssIndex = (frameIndex - 1) / 35;
                frame = _ssBazookaBow[ssIndex][imageName];
            }
            else if (weapon == WEAPONS.HYBRID)
            {
                int ssIndex = (frameIndex - 1) / 35;
                frame = _ssHybridBow[ssIndex][imageName];
            }

            return frame;
        }

        public bool PreloadNextSpriteSheetRotate(WEAPONS? weapon, ENEMIES? enemy)
        {
            //if (GameEnvironment.GetTotalRAMSizeMB() < 500) return false;

            if (weapon == WEAPONS.STANDARD && _ssStandardRotate.Count < 2)
            {
                Console.WriteLine("PRELOAD: Standard rotate " + (_ssStandardRotate.Count + 1).ToString() + "/2");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/StandardCannonRotate-" + _ssStandardRotate.Count.ToString() + ".plist");
                _ssStandardRotate.Add(ss);
                return true;
            }

            if (weapon == WEAPONS.COMPACT && _ssCompactRotate.Count < 2)
            {
                Console.WriteLine("PRELOAD: Compact rotate " + (_ssCompactRotate.Count + 1).ToString() + "/2");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/CompactSprayerRotate-" + _ssCompactRotate.Count.ToString() + ".plist");
                _ssCompactRotate.Add(ss);
                return true;
            }

            if (weapon == WEAPONS.BAZOOKA && _ssBazookaRotate.Count < 2)
            {
                Console.WriteLine("PRELOAD: Bazooka rotate " + (_ssBazookaRotate.Count + 1).ToString() + "/2");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/BlackBazookaRotate-" + _ssBazookaRotate.Count.ToString() + ".plist");
                _ssBazookaRotate.Add(ss);
                return true;
            }

            if (enemy == ENEMIES.HITLER && _ssHitlerRotate.Count < 1)
            {
                Console.WriteLine("PRELOAD: Hitler rotate " + (_ssHitlerRotate.Count + 1).ToString() + "/1");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/HitlerRotate.plist");
                _ssHitlerRotate.Add(ss);
                return true;
            }

            if (enemy == ENEMIES.KIM && _ssKimRotate.Count < 1)
            {
                Console.WriteLine("PRELOAD: Kim rotate " + (_ssKimRotate.Count + 1).ToString() + "/1");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/KimRotate.plist");
                _ssKimRotate.Add(ss);
                return true;
            }

            if (enemy == ENEMIES.PUTIN && _ssPutinRotate.Count < 1)
            {
                Console.WriteLine("PRELOAD: Putin rotate " + (_ssPutinRotate.Count + 1).ToString() + "/1");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/PutinRotate.plist");
                _ssPutinRotate.Add(ss);
                return true;
            }

            if (enemy == ENEMIES.BUSH && _ssBushRotate.Count < 1)
            {
                Console.WriteLine("PRELOAD: Bush rotate " + (_ssBushRotate.Count + 1).ToString() + "/1");

                CCSpriteSheet ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/BushRotate.plist");
                _ssBushRotate.Add(ss);
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
                frame = _ssStandardRotate[ssIndex][imageName];
            }
            else if (weapon == WEAPONS.COMPACT)
            {
                int ssIndex = frameIndex / 28;
                frame = _ssCompactRotate[ssIndex][imageName];
            }
            else if (weapon == WEAPONS.BAZOOKA)
            {
                int ssIndex = frameIndex / 28;
                frame = _ssBazookaRotate[ssIndex][imageName];
            }
            else if (enemy == ENEMIES.HITLER)
            {
                frame = _ssHitlerRotate[0][imageName];
            }
            else if (enemy == ENEMIES.KIM)
            {
                frame = _ssKimRotate[0][imageName];
            }
            else if (enemy == ENEMIES.PUTIN)
            {
                frame = _ssPutinRotate[0][imageName];
            }
            else if (enemy == ENEMIES.BUSH)
            {
                frame = _ssBushRotate[0][imageName];
            }

            return frame;
        }
    }
}
