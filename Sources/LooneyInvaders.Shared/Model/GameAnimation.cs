using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CocosSharp;
using LooneyInvaders.Extensions;

namespace LooneyInvaders.Model
{
    public class GameAnimation
    {
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
        private readonly List<CCSpriteSheet> _ssMiloRotate = new List<CCSpriteSheet>();
        private readonly List<CCSpriteSheet> _ssKimRotate = new List<CCSpriteSheet>();
        private readonly List<CCSpriteSheet> _ssPutinRotate = new List<CCSpriteSheet>();
        private readonly List<CCSpriteSheet> _ssBushRotate = new List<CCSpriteSheet>();

        private readonly bool _allowFreeingEnemies;
        private readonly bool _allowFreeingWeapons;

        private GameAnimation()
        {
            _allowFreeingEnemies = Shared.GameDelegate.UseAnimationClearing;
            _allowFreeingWeapons = Shared.GameDelegate.UseAnimationClearing;
        }   

        private static object toGetInstance = new object();
        private static GameAnimation _instance;
        public static GameAnimation Instance
        {
            get
            {
                lock (toGetInstance)
                {
                    if (_instance == null)
                        _instance = new GameAnimation();
                    return _instance;
                }
            }
        }

        public async Task<bool> PreloadNextSpriteSheetAsync()
        {
            // for phones with less than 500 MB RAM, we don't preload
            if (GameEnvironment.GetTotalRamSizeMb() < 500) return false;

            if (await PreloadNextSpriteSheetEnemiesAsync()) return true;
            if (await PreloadNextSpriteSheetWeaponsAsync()) return true;
            return false;
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

            try
            {
                var ssAll = new List<CCSpriteSheet>();
                if (!onlyRotations && _allowFreeingEnemies) ssAll.AddRange(_ssAdolfTalk);
                if (!onlyRotations && _allowFreeingEnemies) ssAll.AddRange(_ssBushTalk);
                if (!onlyRotations && _allowFreeingEnemies) ssAll.AddRange(_ssKimTalk);
                if (!onlyRotations && _allowFreeingEnemies) ssAll.AddRange(_ssPutinTalk);
                if (!onlyRotations && _allowFreeingEnemies) ssAll.AddRange(_ssAlienTalk);
                if (!onlyRotations && _allowFreeingWeapons) ssAll.AddRange(_ssStandardBow);
                if (!onlyRotations && _allowFreeingWeapons) ssAll.AddRange(_ssCompactBow);
                if (!onlyRotations && _allowFreeingWeapons) ssAll.AddRange(_ssBazookaBow);
                if (!onlyRotations && _allowFreeingWeapons) ssAll.AddRange(_ssHybridBow);
                ssAll.AddRange(_ssStandardRotate);
                ssAll.AddRange(_ssCompactRotate);
                ssAll.AddRange(_ssBazookaRotate);
                ssAll.AddRange(_ssMiloRotate);
                ssAll.AddRange(_ssKimRotate);
                ssAll.AddRange(_ssPutinRotate);
                ssAll.AddRange(_ssBushRotate);

                foreach (var ss in ssAll)
                {
                    if (ss.Frames == null)
                        continue;

                    var texture = ss.Frames[0]?.Texture;
                    if (texture == null)
                        continue;
                    if (!texture.XNATexture.IsDisposed)
                        texture.XNATexture.Dispose();
                    if (!texture.IsDisposed)
                        texture.Dispose();

                    CCTextureCache.SharedTextureCache.RemoveTexture(texture);
                    CCSpriteFrameCache.SharedSpriteFrameCache.RemoveSpriteFrames(texture);
                }

                ssAll.Clear();
                if (!onlyRotations) _ssAdolfTalk.Clear();
                if (!onlyRotations) _ssBushTalk.Clear();
                if (!onlyRotations) _ssKimTalk.Clear();
                if (!onlyRotations) _ssPutinTalk.Clear();
                if (!onlyRotations) _ssAlienTalk.Clear();
                if (!onlyRotations) _ssStandardBow.Clear();
                if (!onlyRotations) _ssCompactBow.Clear();
                if (!onlyRotations) _ssBazookaBow.Clear();
                if (!onlyRotations) _ssHybridBow.Clear();
                _ssStandardRotate.Clear();
                _ssCompactRotate.Clear();
                _ssBazookaRotate.Clear();
                _ssMiloRotate.Clear();
                _ssKimRotate.Clear();
                _ssPutinRotate.Clear();
                _ssBushRotate.Clear();

                CCSpriteSheetCache.Instance.RemoveAll();
                CCSpriteFrameCache.SharedSpriteFrameCache.RemoveUnusedSpriteFrames();
                CCSpriteFrameCache.SharedSpriteFrameCache.RemoveSpriteFrames();
                CCTextureCache.SharedTextureCache.RemoveUnusedTextures();
                CCTextureCache.SharedTextureCache.RemoveAllTextures();
                CCTextureCache.SharedTextureCache.UnloadContent();

                //GC.Collect(1);
                //GC.Collect(2);
                /* 
                GC.Collect();
                GC.Collect(1);
                GC.Collect(2);
                GC.Collect(GC.MaxGeneration);
                GC.WaitForPendingFinalizers();
                */
            }
            catch (Exception ex)
            {
                var mess = ex.Message;
            }
        }

        public bool PreloadNextSpriteSheetEnemies(bool allowPreloadEnemies = true)
        {
            if (GameEnvironment.GetTotalRamSizeMb() < 500 || !allowPreloadEnemies) return false;

            int _ssAdolfTalkCount = (_ssAdolfTalk?.Count).GetValueOrDefault(),
                _ssBushTalkCount = (_ssBushTalk?.Count).GetValueOrDefault(),
                _ssKimTalkCount = (_ssKimTalk?.Count).GetValueOrDefault(),
                _ssPutinTalkCount = (_ssPutinTalk?.Count).GetValueOrDefault(),
                _ssAlienTalkCount = (_ssAlienTalk?.Count).GetValueOrDefault();

            if (_ssAdolfTalkCount < 2)
            {
                Console.WriteLine("PRELOAD: Hitler talk {0}/2", _ssAdolfTalkCount + 1);
                var imagename = $"{GameEnvironment.ImageDirectory}Animations/Adolf-{_ssAdolfTalkCount}.plist";
                var ss = new CCSpriteSheet(imagename);
                _ssAdolfTalk.Add(ss);
                return true;
            }

            if (_ssBushTalkCount < 2)
            {
                Console.WriteLine("PRELOAD: Bush talk {0}/2", _ssBushTalkCount + 1);
                var imagename = $"{GameEnvironment.ImageDirectory}Animations/Bush-{_ssBushTalkCount}.plist";
                var ss = new CCSpriteSheet(imagename);
                _ssBushTalk.Add(ss);
                return true;
            }

            if (_ssKimTalkCount < 3)
            {
                Console.WriteLine("PRELOAD: Kim talk {0}/3", _ssKimTalkCount + 1);
                var imagename = $"{GameEnvironment.ImageDirectory}Animations/Kim-{_ssKimTalkCount}.plist";
                var ss = new CCSpriteSheet(imagename);
                _ssKimTalk.Add(ss);
                return true;
            }

            if (_ssPutinTalkCount < 2)
            {
                Console.WriteLine("PRELOAD: Putin talk {0}/2", _ssPutinTalkCount + 1);
                var imagename = $"{GameEnvironment.ImageDirectory}Animations/Putin-{_ssPutinTalkCount}.plist";
                var ss = new CCSpriteSheet(imagename);
                _ssPutinTalk.Add(ss);
                return true;
            }

            if (_ssAlienTalkCount < 6)
            {
                Console.WriteLine("PRELOAD: Alien talk {0}/6", _ssAlienTalkCount + 1);
                var imagename = $"{GameEnvironment.ImageDirectory}Animations/Alien-{_ssAlienTalkCount}.plist";
                var ss = new CCSpriteSheet(imagename);
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

            var imageName = $"{imageNamePrefix}{frameIndex.ToString("00000")}.png";
            CCSpriteFrame frame = null;
            switch (enemy)
            {
                case Enemies.Hitler:
                    frame = GetFrameFromList(_ssAdolfTalk, (frameIndex - 1) / 77, imageName);
                    break;
                case Enemies.Bush:
                    frame = GetFrameFromList(_ssBushTalk, (frameIndex - 1) / 70, imageName);
                    break;
                case Enemies.Kim:
                    frame = GetFrameFromList(_ssKimTalk, (frameIndex - 1) / 63, imageName);
                    break;
                case Enemies.Putin:
                    frame = GetFrameFromList(_ssPutinTalk, (frameIndex - 1) / 70, imageName);
                    break;
                case Enemies.Aliens:
                    frame = GetFrameFromList(_ssAlienTalk, (frameIndex - 1) / 70, imageName);
                    break;
            }

            return frame;
        }

        private CCSpriteFrame GetFrameFromList(List<CCSpriteSheet> list, int index, string imageName)
        {
            if (list == null || index < 0 || index >= list.Count)
            { return null; }

            try
            {
                var frame = list[index][imageName];
                return frame;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"|Exception|{nameof(GetFrameFromList)}|index={index}|imageName={imageName}: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> PreloadNextSpriteSheetWeaponsAsync(bool allowPreloadWeapons = true)
        {
            if (GameEnvironment.GetTotalRamSizeMb() < 500 || !allowPreloadWeapons) return false;

            try
            {
                int _ssStandardBowCount = (_ssStandardBow?.Count).GetValueOrDefault(),
                    _ssBazookaBowCount = (_ssBazookaBow?.Count).GetValueOrDefault(),
                    _ssCompactBowCount = (_ssCompactBow?.Count).GetValueOrDefault(),
                    _ssHybridBowCount = (_ssHybridBow?.Count).GetValueOrDefault();

            if (_ssStandardBowCount < 2)
            {
                Console.WriteLine("PRELOAD: Standard bow {0}/2", _ssStandardBowCount + 1);
                var filename = $"{GameEnvironment.ImageDirectory}Animations/StandardBow-{_ssStandardBowCount}.plist";
                var ss = this.CCSpriteSheetFactoryMethodAsync(filename);
                _ssStandardBow.Add(await ss);
                return true;
            }

            if (_ssBazookaBowCount < 2)
            {
                Console.WriteLine("PRELOAD: Bazooka bow {0}/2", _ssBazookaBowCount + 1);
                var filename = $"{GameEnvironment.ImageDirectory}Animations/BazookaBow-{_ssBazookaBowCount}.plist";
                var ss = this.CCSpriteSheetFactoryMethodAsync(filename);
                _ssBazookaBow.Add(await ss);
                return true;
            }

            if (_ssCompactBowCount < 2)
            {
                Console.WriteLine("PRELOAD: Compact bow {0}/2", _ssCompactBowCount + 1);
                var filename = $"{GameEnvironment.ImageDirectory}Animations/CompactBow-{_ssCompactBowCount}.plist";
                var ss = this.CCSpriteSheetFactoryMethodAsync(filename);
                _ssCompactBow.Add(await ss);
                return true;
            }

            if (_ssHybridBowCount < 2)
            {
                Console.WriteLine("PRELOAD: Hybrid bow {0}/2", _ssHybridBowCount + 1);
                var filename = $"{GameEnvironment.ImageDirectory}Animations/HybridBow-{_ssHybridBowCount}.plist";
                var ss = this.CCSpriteSheetFactoryMethodAsync(filename);
                _ssHybridBow.Add(await ss);
                return true;
            }
            }
            catch (Exception ex) 
            {
                var mess = ex.Message;
            }
            return false;
        }

        public async Task<bool> PreloadNextSpriteSheetEnemiesAsync(bool allowPreloadEnemies = true)
        {
            if (GameEnvironment.GetTotalRamSizeMb() < 500 || !allowPreloadEnemies) return false;

            int _ssAdolfTalkCount = (_ssAdolfTalk?.Count).GetValueOrDefault(),
                _ssBushTalkCount = (_ssBushTalk?.Count).GetValueOrDefault(),
                _ssKimTalkCount = (_ssKimTalk?.Count).GetValueOrDefault(),
                _ssPutinTalkCount = (_ssPutinTalk?.Count).GetValueOrDefault(),
                _ssAlienTalkCount = (_ssAlienTalk?.Count).GetValueOrDefault();

            if (_ssAdolfTalkCount < 2)
            {
                Console.WriteLine("PRELOAD: Hitler talk {0}/2", _ssAdolfTalkCount + 1);
                var imagename = $"{GameEnvironment.ImageDirectory}Animations/Adolf-{_ssAdolfTalkCount}.plist";
                var ss = Instance.CCSpriteSheetFactoryMethodAsync(imagename);
                _ssAdolfTalk.Add(await ss);
                return true;
            }

            if (_ssBushTalkCount < 2)
            {
                Console.WriteLine("PRELOAD: Bush talk {0}/2", _ssBushTalkCount + 1);
                var imagename = $"{GameEnvironment.ImageDirectory}Animations/Bush-{_ssBushTalkCount}.plist";
                var ss = this.CCSpriteSheetFactoryMethodAsync(imagename);
                _ssBushTalk.Add(await ss);
                return true;
            }

            if (_ssKimTalkCount < 3)
            {
                Console.WriteLine("PRELOAD: Kim talk {0}/3", _ssKimTalkCount + 1);
                var imagename = $"{GameEnvironment.ImageDirectory}Animations/Kim-{_ssKimTalkCount}.plist";
                var ss = this.CCSpriteSheetFactoryMethodAsync(imagename);
                _ssKimTalk.Add(await ss);
                return true;
            }

            if (_ssPutinTalkCount < 2)
            {
                Console.WriteLine("PRELOAD: Putin talk {0}/2", _ssPutinTalkCount + 1);
                var imagename = $"{GameEnvironment.ImageDirectory}Animations/Putin-{_ssPutinTalkCount}.plist";
                var ss = this.CCSpriteSheetFactoryMethodAsync(imagename);
                _ssPutinTalk.Add(await ss);
                return true;
            }

            if (_ssAlienTalkCount < 6)
            {
                Console.WriteLine("PRELOAD: Alien talk {0}/6", _ssAlienTalkCount + 1);
                var imagename = $"{GameEnvironment.ImageDirectory}Animations/Alien-{_ssAlienTalkCount}.plist";
                var ss = this.CCSpriteSheetFactoryMethodAsync(imagename);
                _ssAlienTalk.Add(await ss);
                return true;
            }

            return false;
        }

        public bool PreloadNextSpriteSheetWeapons(bool allowPreloadWeapons = true)
        {
            if (GameEnvironment.GetTotalRamSizeMb() < 500 || !allowPreloadWeapons) return false;
            try
            {
                int _ssStandardBowCount = (_ssStandardBow?.Count).GetValueOrDefault(),
                    _ssBazookaBowCount = (_ssBazookaBow?.Count).GetValueOrDefault(),
                    _ssCompactBowCount = (_ssCompactBow?.Count).GetValueOrDefault(),
                    _ssHybridBowCount = (_ssHybridBow?.Count).GetValueOrDefault();

                if (_ssStandardBowCount < 2)
                {
                    Console.WriteLine("PRELOAD: Standard bow {0}/2", _ssStandardBowCount + 1);
                    var filename = $"{GameEnvironment.ImageDirectory}Animations/StandardBow-{_ssStandardBowCount}.plist";
                    var ss = new CCSpriteSheet(filename);
                    _ssStandardBow.Add(ss);
                    return true;
                }

                if (_ssBazookaBowCount < 2)
                {
                    Console.WriteLine("PRELOAD: Bazooka bow {0}/2", _ssBazookaBowCount + 1);
                    var filename = $"{GameEnvironment.ImageDirectory}Animations/BazookaBow-{_ssBazookaBowCount}.plist";
                    var ss = new CCSpriteSheet(filename);
                    _ssBazookaBow.Add(ss);
                    return true;
                }

                if (_ssCompactBowCount < 2)
                {
                    Console.WriteLine("PRELOAD: Compact bow {0}/2", _ssCompactBowCount + 1);
                    var filename = $"{GameEnvironment.ImageDirectory}Animations/CompactBow-{_ssCompactBowCount}.plist";
                    var ss = new CCSpriteSheet(filename);
                    _ssCompactBow.Add(ss);
                    return true;
                }

                if (_ssHybridBowCount < 2)
                {
                    Console.WriteLine("PRELOAD: Hybrid bow {0}/2", _ssHybridBowCount + 1);
                    var filename = $"{GameEnvironment.ImageDirectory}Animations/HybridBow-{_ssHybridBowCount}.plist";
                    var ss = new CCSpriteSheet(filename);
                    _ssHybridBow.Add(ss);
                    return true;
                }
            }
            catch (Exception ex)
            {
                var mess = ex.Message;  
            }
            return false;
        }

        public CCSpriteFrame GetWeaponBowFrame(Weapons weapon, int frameIndex)
        {
            var imageNamePrefix = "";
            switch (weapon)
            {
                case Weapons.Standard:
                    imageNamePrefix = "standard_gun_bow_";
                    break;
                case Weapons.Compact:
                    imageNamePrefix = "compact-sprayer_bow_";
                    break;
                case Weapons.Bazooka:
                    imageNamePrefix = "black_bazooka_bow_";
                    break;
                case Weapons.Hybrid:
                    imageNamePrefix = "hybrid_defender_bow_";
                    break;
            }

            var imageName = $"{imageNamePrefix}{frameIndex.ToString("00")}.png";

            CCSpriteFrame frame = null;
            switch (weapon)
            {
                case Weapons.Standard:
                    frame = GetFrameFromList(_ssStandardBow, (frameIndex - 1) / 35, imageName);
                    break;
                case Weapons.Compact:
                    frame = GetFrameFromList(_ssCompactBow, (frameIndex - 1) / 35, imageName);
                    break;
                case Weapons.Bazooka:
                    frame = GetFrameFromList(_ssBazookaBow, (frameIndex - 1) / 35, imageName);
                    break;
                case Weapons.Hybrid:
                    frame = GetFrameFromList(_ssHybridBow, (frameIndex - 1) / 35, imageName);
                    break;
            }

            return frame;
        }

        public bool PreloadNextSpriteSheetRotate(Weapons? weapon, Enemies? enemy)
        {
            //if (GameEnvironment.GetTotalRAMSizeMB() < 500) return false;
            int _ssStandardRotateCount = (_ssStandardRotate?.Count).GetValueOrDefault(),
                _ssCompactRotateCount = (_ssCompactRotate?.Count).GetValueOrDefault(),
                _ssBazookaRotateCount = (_ssBazookaRotate?.Count).GetValueOrDefault(),
                _ssMiloRotateCount = (_ssMiloRotate?.Count).GetValueOrDefault(),
                _ssKimRotateCount = (_ssKimRotate?.Count).GetValueOrDefault(),
                _ssPutinRotateCount = (_ssPutinRotate?.Count).GetValueOrDefault(),
                _ssBushRotateCount = (_ssBushRotate?.Count).GetValueOrDefault();

            if (weapon == Weapons.Standard && _ssStandardRotateCount < 2)
            {
                Console.WriteLine("PRELOAD: Standard rotate {0}/2", _ssStandardRotateCount + 1);
                var filename = $"{GameEnvironment.ImageDirectory}Animations/StandardCannonRotate-{_ssStandardRotateCount}.plist";
                var ss = new CCSpriteSheet(filename);
                _ssStandardRotate.Add(ss);
                return true;
            }

            if (weapon == Weapons.Compact && _ssCompactRotateCount < 2)
            {
                Console.WriteLine("PRELOAD: Compact rotate {0}/2", _ssCompactRotateCount + 1);
                var filename = $"{GameEnvironment.ImageDirectory}Animations/CompactSprayerRotate-{_ssCompactRotateCount}.plist";
                var ss = new CCSpriteSheet(filename);
                _ssCompactRotate.Add(ss);
                return true;
            }

            if (weapon == Weapons.Bazooka && _ssBazookaRotateCount < 2)
            {
                Console.WriteLine("PRELOAD: Bazooka rotate {0}/2", _ssBazookaRotateCount + 1);
                var filename = $"{GameEnvironment.ImageDirectory}Animations/BlackBazookaRotate-{_ssBazookaRotateCount}.plist";
                var ss = new CCSpriteSheet(filename);
                _ssBazookaRotate.Add(ss);
                return true;
            }

            if (enemy == Enemies.Hitler && _ssMiloRotateCount < 1)
            {
                Console.WriteLine("PRELOAD: Milo rotate {0}/1", _ssMiloRotateCount + 1);
                var filename = $"{GameEnvironment.ImageDirectory}Animations/MiloRotate-0.plist";
                var ss = new CCSpriteSheet(filename);
                _ssMiloRotate.Add(ss);
                return true;
            }

            if (enemy == Enemies.Kim && _ssKimRotateCount < 1)
            {
                Console.WriteLine("PRELOAD: Kim rotate {0}/1", _ssKimRotateCount + 1);
                var filename = $"{GameEnvironment.ImageDirectory}Animations/KimRotate.plist";
                var ss = new CCSpriteSheet(filename);
                _ssKimRotate.Add(ss);
                return true;
            }

            if (enemy == Enemies.Putin && _ssPutinRotateCount < 1)
            {
                Console.WriteLine("PRELOAD: Putin rotate {0}/1", _ssPutinRotateCount + 1);
                var filename = $"{GameEnvironment.ImageDirectory}Animations/PutinRotate.plist";
                var ss = new CCSpriteSheet(filename);
                _ssPutinRotate.Add(ss);
                return true;
            }

            if (enemy == Enemies.Bush && _ssBushRotateCount < 1)
            {
                Console.WriteLine("PRELOAD: Bush rotate {0}/1", _ssBushRotateCount + 1);
                var filename = $"{GameEnvironment.ImageDirectory}Animations/BushRotate.plist";
                var ss = new CCSpriteSheet(filename);
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
            else if (enemy == Enemies.Hitler) imageNamePrefix = "Milosevic_rotation_image_";
            else if (enemy == Enemies.Kim) imageNamePrefix = "kim_rotation_image_";
            else if (enemy == Enemies.Putin) imageNamePrefix = "putin_rotation_image_";
            else if (enemy == Enemies.Bush) imageNamePrefix = "Hitler_rotation_image_";

            var imageName = $"{imageNamePrefix}{frameIndex.ToString("00")}.png";

            CCSpriteFrame frame = null;

            if (weapon == Weapons.Standard)
            {
                frame = GetFrameFromList(_ssStandardRotate, frameIndex / 28, imageName);
            }
            else if (weapon == Weapons.Compact)
            {
                frame = GetFrameFromList(_ssCompactRotate, frameIndex / 28, imageName);
            }
            else if (weapon == Weapons.Bazooka)
            {
                frame = GetFrameFromList(_ssBazookaRotate, frameIndex / 28, imageName);
            }
            else if (enemy == Enemies.Hitler)
            {
                frame = GetFrameFromList(_ssMiloRotate, 0, imageName);
            }
            else if (enemy == Enemies.Kim)
            {
                frame = GetFrameFromList(_ssKimRotate, 0, imageName);
            }
            else if (enemy == Enemies.Putin)
            {
                frame = GetFrameFromList(_ssPutinRotate, 0, imageName);
            }
            else if (enemy == Enemies.Bush)
            {
                frame = GetFrameFromList(_ssBushRotate, 0, imageName);
            }

            return frame;
        }
    }
}
