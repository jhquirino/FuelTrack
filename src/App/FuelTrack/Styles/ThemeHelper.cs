// -----------------------------------------------------------------------
//  <copyright file="ThemeHelper.cs" company="Jorge Quirino">
//  Copyright (c) Jorge Quirino 2020-2021. All rights reserved.
//  </copyright>
//  <author>Jorge Quirino (jhquirino@outlook.com)</author>
// -----------------------------------------------------------------------
using FuelTrack.Interfaces;
using FuelTrack.Models;
using FuelTrack.Utils;
using Xamarin.Essentials;
using Xamarin.Forms;
using static FuelTrack.Models.Constants;

namespace FuelTrack.Styles
{
    public static class ThemeHelper
    {
        public static Theme CurrentTheme = Settings.ThemeOption;

        public static void ChangeTheme(Theme theme, bool forceTheme = false)
        {
            // don't change to the same theme
            if (theme == CurrentTheme && !forceTheme)
                return;

            if (theme == Theme.Default)
                theme = AppInfo.RequestedTheme == AppTheme.Dark ? Theme.Dark : Theme.Light;

            if (theme == Theme.Dark)
            {
                App.Current.Resources = new DarkTheme();
            }
            else
            {
                App.Current.Resources = new LightTheme();
            }

            var barColor = (Color)App.Current.Resources[RESOURCE_BAR_COLOR];
            var environment = DependencyService.Get<IEnvironment>();
            environment?.SetStatusBarColor(ColorConverters.FromHex(barColor.ToHex()), false);
        }
    }
}
