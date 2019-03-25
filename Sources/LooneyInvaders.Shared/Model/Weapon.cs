using Plugin.Settings;

namespace LooneyInvaders.Model
{
    public class Weapon
    {
        public static void ResetAllSettings()
        {
            SetCaliberSize(Weapons.Standard, 2);
            SetCaliberSize(Weapons.Compact, 1);
            SetCaliberSize(Weapons.Bazooka, 3);
            SetCaliberSize(Weapons.Hybrid, 3);
            SetFirespeed(Weapons.Standard, 2);
            SetFirespeed(Weapons.Compact, 3);
            SetFirespeed(Weapons.Bazooka, 1);
            SetFirespeed(Weapons.Hybrid, 3);
            SetMagazineSize(Weapons.Standard, 1);
            SetMagazineSize(Weapons.Compact, 2);
            SetMagazineSize(Weapons.Bazooka, 2);
            SetMagazineSize(Weapons.Hybrid, 3);
            SetLives(Weapons.Standard, 3);
            SetLives(Weapons.Compact, 3);
            SetLives(Weapons.Bazooka, 3);
            SetLives(Weapons.Hybrid, 4);
        }

        public static int GetCaliberSize(Weapons weapon)
        {
            switch (weapon)
            {
                case Weapons.Standard:
                    return CrossSettings.Current.GetValueOrDefault("CaliberSizeStandard", 2);
                case Weapons.Compact:
                    return CrossSettings.Current.GetValueOrDefault("CaliberSizeCompact", 1);
                case Weapons.Bazooka:
                    return CrossSettings.Current.GetValueOrDefault("CaliberSizeBazooka", 3);
                case Weapons.Hybrid:
                    return CrossSettings.Current.GetValueOrDefault("CaliberSizeHybrid", 3);
                default:
                    return 0;
            }
        }

        public static void SetCaliberSize(Weapons weapon, int value)
        {
            switch (weapon)
            {
                case Weapons.Standard:
                    CrossSettings.Current.AddOrUpdateValue("CaliberSizeStandard", value);
                    break;
                case Weapons.Compact:
                    CrossSettings.Current.AddOrUpdateValue("CaliberSizeCompact", value);
                    break;
                case Weapons.Bazooka:
                    CrossSettings.Current.AddOrUpdateValue("CaliberSizeBazooka", value);
                    break;
                case Weapons.Hybrid:
                    CrossSettings.Current.AddOrUpdateValue("CaliberSizeHybrid", value);
                    break;
            }
        }

        public static int GetFirespeed(Weapons weapon)
        {
            switch (weapon)
            {
                case Weapons.Standard:
                    return CrossSettings.Current.GetValueOrDefault("FirespeedStandard", 2);
                case Weapons.Compact:
                    return CrossSettings.Current.GetValueOrDefault("FirespeedCompact", 3);
                case Weapons.Bazooka:
                    return CrossSettings.Current.GetValueOrDefault("FirespeedBazooka", 1);
                case Weapons.Hybrid:
                    return CrossSettings.Current.GetValueOrDefault("FirespeedHybrid", 3);
                default:
                    return 0;
            }
        }

        public static void SetFirespeed(Weapons weapon, int value)
        {
            switch (weapon)
            {
                case Weapons.Standard:
                    CrossSettings.Current.AddOrUpdateValue("FirespeedStandard", value);
                    break;
                case Weapons.Compact:
                    CrossSettings.Current.AddOrUpdateValue("FirespeedCompact", value);
                    break;
                case Weapons.Bazooka:
                    CrossSettings.Current.AddOrUpdateValue("FirespeedBazooka", value);
                    break;
                case Weapons.Hybrid:
                    CrossSettings.Current.AddOrUpdateValue("FirespeedHybrid", value);
                    break;
            }
        }

        public static int GetMagazineSize(Weapons weapon)
        {
            switch (weapon)
            {
                case Weapons.Standard:
                    return CrossSettings.Current.GetValueOrDefault("MagazineSizeStandard", 1);
                case Weapons.Compact:
                    return CrossSettings.Current.GetValueOrDefault("MagazineSizeCompact", 2);
                case Weapons.Bazooka:
                    return CrossSettings.Current.GetValueOrDefault("MagazineSizeBazooka", 2);
                case Weapons.Hybrid:
                    return CrossSettings.Current.GetValueOrDefault("MagazineSizeHybrid", 3);
                default:
                    return 0;
            }
        }

        public static void SetMagazineSize(Weapons weapon, int value)
        {
            switch (weapon)
            {
                case Weapons.Standard:
                    CrossSettings.Current.AddOrUpdateValue("MagazineSizeStandard", value);
                    break;
                case Weapons.Compact:
                    CrossSettings.Current.AddOrUpdateValue("MagazineSizeCompact", value);
                    break;
                case Weapons.Bazooka:
                    CrossSettings.Current.AddOrUpdateValue("MagazineSizeBazooka", value);
                    break;
                case Weapons.Hybrid:
                    CrossSettings.Current.AddOrUpdateValue("MagazineSizeHybrid", value);
                    break;
            }
        }

        public static int GetLives(Weapons weapon)
        {
            switch (weapon)
            {
                case Weapons.Standard:
                    return CrossSettings.Current.GetValueOrDefault("LivesStandard", 3);
                case Weapons.Compact:
                    return CrossSettings.Current.GetValueOrDefault("LivesCompact", 3);
                case Weapons.Bazooka:
                    return CrossSettings.Current.GetValueOrDefault("LivesBazooka", 3);
                case Weapons.Hybrid:
                    return CrossSettings.Current.GetValueOrDefault("LivesHybrid", 4);
                default:
                    return 0;
            }
        }

        public static void SetLives(Weapons weapon, int value)
        {
            switch (weapon)
            {
                case Weapons.Standard:
                    CrossSettings.Current.AddOrUpdateValue("LivesStandard", value);
                    break;
                case Weapons.Compact:
                    CrossSettings.Current.AddOrUpdateValue("LivesCompact", value);
                    break;
                case Weapons.Bazooka:
                    CrossSettings.Current.AddOrUpdateValue("LivesBazooka", value);
                    break;
                case Weapons.Hybrid:
                    CrossSettings.Current.AddOrUpdateValue("LivesHybrid", value);
                    break;
            }
        }
    }
}