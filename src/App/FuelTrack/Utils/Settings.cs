// -----------------------------------------------------------------------
//  <copyright file="Settings.cs" company="Jorge Quirino">
//  Copyright (c) Jorge Quirino 2020-2021. All rights reserved.
//  </copyright>
//  <author>Jorge Quirino (jhquirino@outlook.com)</author>
// -----------------------------------------------------------------------
using System;
using FuelTrack.Models;
using Xamarin.Essentials;

namespace FuelTrack.Utils
{
    /// <summary>
    /// Util to get/set app settings.
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// Theme option.
        /// </summary>
        public static Theme ThemeOption
        {
            get => (Theme)Preferences.Get(nameof(ThemeOption), HasDefaultThemeOption ? (int)Theme.Default : (int)Theme.Light);
            set => Preferences.Set(nameof(ThemeOption), (int)value);
        }

        /// <summary>
        /// Fuel unit.
        /// </summary>
        public static FuelUnit FuelUnit
        {
            get => (FuelUnit)Preferences.Get(nameof(FuelUnit), (int)FuelUnit.Liters);
            set => Preferences.Set(nameof(FuelUnit), (int)value);
        }

        /// <summary>
        /// Distance unit.
        /// </summary>
        public static DistanceUnit DistanceUnit
        {
            get => (DistanceUnit)Preferences.Get(nameof(DistanceUnit), (int)DistanceUnit.Kilometers);
            set => Preferences.Set(nameof(DistanceUnit), (int)value);
        }

        /// <summary>
        /// Evaluates whether the device supports system default theme option.
        /// </summary>
        public static bool HasDefaultThemeOption
        {
            get
            {
                var minDefaultVersion = new Version(13, 0);
                if (DeviceInfo.Platform == DevicePlatform.UWP)
                    minDefaultVersion = new Version(10, 0, 17763, 1);
                else if (DeviceInfo.Platform == DevicePlatform.Android)
                    minDefaultVersion = new Version(10, 0);

                return DeviceInfo.Version >= minDefaultVersion;
            }
        }
    }
}
