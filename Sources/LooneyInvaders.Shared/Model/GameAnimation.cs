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
            if (GameEnvironment.GetTotalRamSizeMb() < 500) return false;

            if (PreloadNextSpriteSheetEnemies()) return true;
            if (PreloadNextSpriteSheetWeapons()) return true;
            return false;
        }

        public void FreeAllSpriteSheets(bool onlyRotations = false)
        {
            Console.WriteLine("Freeing all sprite sheets");

            var ssAll = new List<CCSpriteSheet>();
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

            foreach (var ss in ssAll)
            {
                var texture = ss.Frames[0].Texture;

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
            if (GameEnvironment.GetTotalRamSizeMb() < 500) return false;

            if (_ssAdolfTalk.Count < 2)
            {
                Console.WriteLine("PRELOAD: Hitler talk " + (_ssAdolfTalk.Count + 1) + "/2");

                var ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/Adolf-" + _ssAdolfTalk.Count + ".plist");
                _ssAdolfTalk.Add(ss);
                return true;
            }

            if (_ssBushTalk.Count < 2)
            {
                Console.WriteLine("PRELOAD: Bush talk " + (_ssBushTalk.Count + 1) + "/2");

                var ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/Bush-" + _ssBushTalk.Count + ".plist");
                _ssBushTalk.Add(ss);
                return true;
            }

            if (_ssKimTalk.Count < 3)
            {
                Console.WriteLine("PRELOAD: Kim talk " + (_ssKimTalk.Count + 1) + "/3");

                var ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/Kim-" + _ssKimTalk.Count + ".plist");
                _ssKimTalk.Add(ss);
                return true;
            }

            if (_ssPutinTalk.Count < 2)
            {
                Console.WriteLine("PRELOAD: Putin talk " + (_ssPutinTalk.Count + 1) + "/2");

                var ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/Putin-" + _ssPutinTalk.Count + ".plist");
                _ssPutinTalk.Add(ss);
                return true;
            }

            if (_ssAlienTalk.Count < 6)
            {
                Console.WriteLine("PRELOAD: Alien talk " + (_ssAlienTalk.Count + 1) + "/6");

                var ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/Alien-" + _ssAlienTalk.Count + ".plist");
                _ssAlienTalk.Add(ss);
                return true;
            }

            return false;
        }

        public CCSpriteFrame GetEnemyTalkFrame(Enemies enemy, int frameIndex)
        {
            var imageNamePrefix = "";

            if (enemy == Enemies.Bush) imageNamePrefix = "Bush-Safe-C_";
            else if (enemy == Enemies.Hitler) imageNamePrefix = "Hitler-Strength-E";
            else if (enemy == Enemies.Putin) imageNamePrefix = "Putin-Strength-D";
            else if (enemy == Enemies.Kim) imageNamePrefix = "Kim-Strength-D";
            else if (enemy == Enemies.Aliens) imageNamePrefix = "Alien-C-5_";

            var imageName = imageNamePrefix + frameIndex.ToString("00000") + ".png";

            CCSpriteFrame frame = null;

            if (enemy == Enemies.Hitler)
            {
                var ssIndex = (frameIndex - 1) / 77;
                frame = _ssAdolfTalk[ssIndex][imageName];
            }
            else if (enemy == Enemies.Bush)
            {
                var ssIndex = (frameIndex - 1) / 70;
                frame = _ssBushTalk[ssIndex][imageName];
            }
            else if (enemy == Enemies.Kim)
            {
                var ssIndex = (frameIndex - 1) / 63;
                frame = _ssKimTalk[ssIndex][imageName];
            }
            else if (enemy == Enemies.Putin)
            {
                var ssIndex = (frameIndex - 1) / 70;
                frame = _ssPutinTalk[ssIndex][imageName];
            }
            else if (enemy == Enemies.Aliens)
            {
                var ssIndex = (frameIndex - 1) / 70;
                frame = _ssAlienTalk[ssIndex][imageName];
            }

            return frame;
        }

        public bool PreloadNextSpriteSheetWeapons()
        {
            if (GameEnvironment.GetTotalRamSizeMb() < 500) return false;

            if (_ssStandardBow.Count < 2)
            {
                Console.WriteLine("PRELOAD: Standard bow " + (_ssStandardBow.Count + 1) + "/2");

                var ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/StandardBow-" + _ssStandardBow.Count + ".plist");
                _ssStandardBow.Add(ss);
                return true;
            }

            if (_ssCompactBow.Count < 2)
            {
                Console.WriteLine("PRELOAD: Compact bow " + (_ssCompactBow.Count + 1) + "/2");

                var ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/CompactBow-" + _ssCompactBow.Count + ".plist");
                _ssCompactBow.Add(ss);
                return true;
            }

            if (_ssBazookaBow.Count < 2)
            {
                Console.WriteLine("PRELOAD: Bazooka bow " + (_ssBazookaBow.Count + 1) + "/2");

                var ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/BazookaBow-" + _ssBazookaBow.Count + ".plist");
                _ssBazookaBow.Add(ss);
                return true;
            }

            if (_ssHybridBow.Count < 2)
            {
                Console.WriteLine("PRELOAD: Hybrid bow " + (_ssHybridBow.Count + 1) + "/2");

                var ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/HybridBow-" + _ssHybridBow.Count + ".plist");
                _ssHybridBow.Add(ss);
                return true;
            }

            return false;
        }

        public CCSpriteFrame GetWeaponBowFrame(Weapons weapon, int frameIndex)
        {
            var imageNamePrefix = "";

            if (weapon == Weapons.Standard) imageNamePrefix = "standard_gun_bow_";
            else if (weapon == Weapons.Compact) imageNamePrefix = "compact-sprayer_bow_";
            else if (weapon == Weapons.Bazooka) imageNamePrefix = "black_bazooka_bow_";
            else if (weapon == Weapons.Hybrid) imageNamePrefix = "hybrid_defender_bow_";

            var imageName = imageNamePrefix + frameIndex.ToString("00") + ".png";

            CCSpriteFrame frame = null;

            if (weapon == Weapons.Standard)
            {
                var ssIndex = (frameIndex - 1) / 35;
                frame = _ssStandardBow[ssIndex][imageName];
            }
            else if (weapon == Weapons.Compact)
            {
                var ssIndex = (frameIndex - 1) / 35;
                frame = _ssCompactBow[ssIndex][imageName];
            }
            else if (weapon == Weapons.Bazooka)
            {
                var ssIndex = (frameIndex - 1) / 35;
                frame = _ssBazookaBow[ssIndex][imageName];
            }
            else if (weapon == Weapons.Hybrid)
            {
                var ssIndex = (frameIndex - 1) / 35;
                frame = _ssHybridBow[ssIndex][imageName];
            }

            return frame;
        }

        public bool PreloadNextSpriteSheetRotate(Weapons? weapon, Enemies? enemy)
        {
            //if (GameEnvironment.GetTotalRAMSizeMB() < 500) return false;

            if (weapon == Weapons.Standard && _ssStandardRotate.Count < 2)
            {
                Console.WriteLine("PRELOAD: Standard rotate " + (_ssStandardRotate.Count + 1) + "/2");

                var ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/StandardCannonRotate-" + _ssStandardRotate.Count + ".plist");
                _ssStandardRotate.Add(ss);
                return true;
            }

            if (weapon == Weapons.Compact && _ssCompactRotate.Count < 2)
            {
                Console.WriteLine("PRELOAD: Compact rotate " + (_ssCompactRotate.Count + 1) + "/2");

                var ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/CompactSprayerRotate-" + _ssCompactRotate.Count + ".plist");
                _ssCompactRotate.Add(ss);
                return true;
            }

            if (weapon == Weapons.Bazooka && _ssBazookaRotate.Count < 2)
            {
                Console.WriteLine("PRELOAD: Bazooka rotate " + (_ssBazookaRotate.Count + 1) + "/2");

                var ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/BlackBazookaRotate-" + _ssBazookaRotate.Count + ".plist");
                _ssBazookaRotate.Add(ss);
                return true;
            }

            if (enemy == Enemies.Hitler && _ssHitlerRotate.Count < 1)
            {
                Console.WriteLine("PRELOAD: Hitler rotate " + (_ssHitlerRotate.Count + 1) + "/1");

                var ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/HitlerRotate.plist");
                _ssHitlerRotate.Add(ss);
                return true;
            }

            if (enemy == Enemies.Kim && _ssKimRotate.Count < 1)
            {
                Console.WriteLine("PRELOAD: Kim rotate " + (_ssKimRotate.Count + 1) + "/1");

                var ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/KimRotate.plist");
                _ssKimRotate.Add(ss);
                return true;
            }

            if (enemy == Enemies.Putin && _ssPutinRotate.Count < 1)
            {
                Console.WriteLine("PRELOAD: Putin rotate " + (_ssPutinRotate.Count + 1) + "/1");

                var ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/PutinRotate.plist");
                _ssPutinRotate.Add(ss);
                return true;
            }

            if (enemy == Enemies.Bush && _ssBushRotate.Count < 1)
            {
                Console.WriteLine("PRELOAD: Bush rotate " + (_ssBushRotate.Count + 1) + "/1");

                var ss = new CCSpriteSheet(GameEnvironment.ImageDirectory + "Animations/BushRotate.plist");
                _ssBushRotate.Add(ss);
                return true;
            }

            return false;
        }

        public CCSpriteFrame GetRotateFrame(Weapons? weapon, Enemies? enemy, int frameIndex)
        {
            var imageNamePrefix = "";

            if (weapon == Weapons.Standard) imageNamePrefix = "standard_gun_rotation_image_";
            else if (weapon == Weapons.Compact) imageNamePrefix = "compact_sprayer_rotation_image_";
            else if (weapon == Weapons.Bazooka) imageNamePrefix = "Black_bazooka_rotation_image_";
            else if (enemy == Enemies.Hitler) imageNamePrefix = "Hitler_rotation_image_";
            else if (enemy == Enemies.Kim) imageNamePrefix = "kim_rotation_image_";
            else if (enemy == Enemies.Putin) imageNamePrefix = "putin_rotation_image_";
            else if (enemy == Enemies.Bush) imageNamePrefix = "Hitler_rotation_image_";

            var imageName = imageNamePrefix + frameIndex.ToString("00") + ".png";

            CCSpriteFrame frame = null;

            if (weapon == Weapons.Standard)
            {
                var ssIndex = frameIndex / 28;
                frame = _ssStandardRotate[ssIndex][imageName];
            }
            else if (weapon == Weapons.Compact)
            {
                var ssIndex = frameIndex / 28;
                frame = _ssCompactRotate[ssIndex][imageName];
            }
            else if (weapon == Weapons.Bazooka)
            {
                var ssIndex = frameIndex / 28;
                frame = _ssBazookaRotate[ssIndex][imageName];
            }
            else if (enemy == Enemies.Hitler)
            {
                frame = _ssHitlerRotate[0][imageName];
            }
            else if (enemy == Enemies.Kim)
            {
                frame = _ssKimRotate[0][imageName];
            }
            else if (enemy == Enemies.Putin)
            {
                frame = _ssPutinRotate[0][imageName];
            }
            else if (enemy == Enemies.Bush)
            {
                frame = _ssBushRotate[0][imageName];
            }

            return frame;
        }
    }
}
