using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace LooneyInvaders.Model
{
    public class Weapon
    {
        public static void ResetAllSettings()
        {
            SetCaliberSize(WEAPONS.STANDARD, 2);
            SetCaliberSize(WEAPONS.COMPACT, 1);
            SetCaliberSize(WEAPONS.BAZOOKA, 3);
            SetCaliberSize(WEAPONS.HYBRID, 3);
            SetFirespeed(WEAPONS.STANDARD, 2);
            SetFirespeed(WEAPONS.COMPACT, 3);
            SetFirespeed(WEAPONS.BAZOOKA, 1);
            SetFirespeed(WEAPONS.HYBRID, 3);
            SetMagazineSize(WEAPONS.STANDARD, 1);
            SetMagazineSize(WEAPONS.COMPACT, 2);
            SetMagazineSize(WEAPONS.BAZOOKA, 2);
            SetMagazineSize(WEAPONS.HYBRID, 3);
            SetLives(WEAPONS.STANDARD, 3);
            SetLives(WEAPONS.COMPACT, 3);
            SetLives(WEAPONS.BAZOOKA, 3);
            SetLives(WEAPONS.HYBRID, 4);
        }

        public static int GetCaliberSize(WEAPONS weapon)
        {
            if (weapon == WEAPONS.STANDARD) return CrossSettings.Current.GetValueOrDefault("CaliberSizeStandard", 2);
            else if (weapon == WEAPONS.COMPACT) return CrossSettings.Current.GetValueOrDefault("CaliberSizeCompact", 1);
            else if (weapon == WEAPONS.BAZOOKA) return CrossSettings.Current.GetValueOrDefault("CaliberSizeBazooka", 3);
            else if (weapon == WEAPONS.HYBRID) return CrossSettings.Current.GetValueOrDefault("CaliberSizeHybrid", 3);

            return 0;
        }

        public static void SetCaliberSize(WEAPONS weapon, int value)
        {
            if (weapon == WEAPONS.STANDARD) CrossSettings.Current.AddOrUpdateValue("CaliberSizeStandard", value);
            else if (weapon == WEAPONS.COMPACT) CrossSettings.Current.AddOrUpdateValue("CaliberSizeCompact", value);
            else if (weapon == WEAPONS.BAZOOKA) CrossSettings.Current.AddOrUpdateValue("CaliberSizeBazooka", value);
            else if (weapon == WEAPONS.HYBRID) CrossSettings.Current.AddOrUpdateValue("CaliberSizeHybrid", value);
        }

        public static int GetFirespeed(WEAPONS weapon)
        {
            if (weapon == WEAPONS.STANDARD) return CrossSettings.Current.GetValueOrDefault("FirespeedStandard", 2);
            else if (weapon == WEAPONS.COMPACT) return CrossSettings.Current.GetValueOrDefault("FirespeedCompact", 3);
            else if (weapon == WEAPONS.BAZOOKA) return CrossSettings.Current.GetValueOrDefault("FirespeedBazooka", 1);
            else if (weapon == WEAPONS.HYBRID) return CrossSettings.Current.GetValueOrDefault("FirespeedHybrid", 3);

            return 0;
        }

        public static void SetFirespeed(WEAPONS weapon, int value)
        {
            if (weapon == WEAPONS.STANDARD) CrossSettings.Current.AddOrUpdateValue("FirespeedStandard", value);
            else if (weapon == WEAPONS.COMPACT) CrossSettings.Current.AddOrUpdateValue("FirespeedCompact", value);
            else if (weapon == WEAPONS.BAZOOKA) CrossSettings.Current.AddOrUpdateValue("FirespeedBazooka", value);
            else if (weapon == WEAPONS.HYBRID) CrossSettings.Current.AddOrUpdateValue("FirespeedHybrid", value);
        }

        public static int GetMagazineSize(WEAPONS weapon)
        {
            if (weapon == WEAPONS.STANDARD) return CrossSettings.Current.GetValueOrDefault("MagazineSizeStandard", 1);
            else if (weapon == WEAPONS.COMPACT) return CrossSettings.Current.GetValueOrDefault("MagazineSizeCompact", 2);
            else if (weapon == WEAPONS.BAZOOKA) return CrossSettings.Current.GetValueOrDefault("MagazineSizeBazooka", 2);
            else if (weapon == WEAPONS.HYBRID) return CrossSettings.Current.GetValueOrDefault("MagazineSizeHybrid", 3);

            return 0;
        }

        public static void SetMagazineSize(WEAPONS weapon, int value)
        {
            if (weapon == WEAPONS.STANDARD) CrossSettings.Current.AddOrUpdateValue("MagazineSizeStandard", value);
            else if (weapon == WEAPONS.COMPACT) CrossSettings.Current.AddOrUpdateValue("MagazineSizeCompact", value);
            else if (weapon == WEAPONS.BAZOOKA) CrossSettings.Current.AddOrUpdateValue("MagazineSizeBazooka", value);
            else if (weapon == WEAPONS.HYBRID) CrossSettings.Current.AddOrUpdateValue("MagazineSizeHybrid", value);
        }

        public static int GetLives(WEAPONS weapon)
        {
            if (weapon == WEAPONS.STANDARD) return CrossSettings.Current.GetValueOrDefault("LivesStandard", 3);
            else if (weapon == WEAPONS.COMPACT) return CrossSettings.Current.GetValueOrDefault("LivesCompact", 3);
            else if (weapon == WEAPONS.BAZOOKA) return CrossSettings.Current.GetValueOrDefault("LivesBazooka", 3);
            else if (weapon == WEAPONS.HYBRID) return CrossSettings.Current.GetValueOrDefault("LivesHybrid", 4);

            return 0;
        }

        public static void SetLives(WEAPONS weapon, int value)
        {
            if (weapon == WEAPONS.STANDARD) CrossSettings.Current.AddOrUpdateValue("LivesStandard", value);
            else if (weapon == WEAPONS.COMPACT) CrossSettings.Current.AddOrUpdateValue("LivesCompact", value);
            else if (weapon == WEAPONS.BAZOOKA) CrossSettings.Current.AddOrUpdateValue("LivesBazooka", value);
            else if (weapon == WEAPONS.HYBRID) CrossSettings.Current.AddOrUpdateValue("LivesHybrid", value);
        }
    }
}