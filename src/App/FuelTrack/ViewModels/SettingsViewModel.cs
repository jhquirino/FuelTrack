// -----------------------------------------------------------------------
//  <copyright file="SettingsViewModel.cs" company="Jorge Quirino">
//  Copyright (c) Jorge Quirino 2020-2021. All rights reserved.
//  </copyright>
//  <author>Jorge Quirino (jhquirino@outlook.com)</author>
// -----------------------------------------------------------------------
using System.Collections.ObjectModel;
using System.Linq;
using FuelTrack.Models;
using FuelTrack.Styles;
using FuelTrack.Utils;
using TinyMvvm;
using Xamarin.Forms;
using static FuelTrack.Models.Constants;
using static FuelTrack.Resources.Strings;

namespace FuelTrack.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private ObservableCollection<PickerItem<Theme>> themes;

        private PickerItem<Theme> selectedTheme;

        private ObservableCollection<PickerItem<DistanceUnit>> distanceUnits;

        private PickerItem<DistanceUnit> selectedDistanceUnit;

        private ObservableCollection<PickerItem<FuelUnit>> fuelUnits;

        private PickerItem<FuelUnit> selectedFuelUnit;

        public ObservableCollection<PickerItem<Theme>> Themes
            => themes ??= new ObservableCollection<PickerItem<Theme>>();

        public PickerItem<Theme> SelectedTheme
        {
            get => selectedTheme;
            set => Set(ref selectedTheme, value);
        }

        public ObservableCollection<PickerItem<DistanceUnit>> DistanceUnits
            => distanceUnits ??= new ObservableCollection<PickerItem<DistanceUnit>>
            {
                new PickerItem<DistanceUnit>(DistanceUnit.Kilometers, OptionUnitDistanceKilometers),
                new PickerItem<DistanceUnit>(DistanceUnit.Miles, OptionUnitDistanceMiles)
            };

        public PickerItem<DistanceUnit> SelectedDistanceUnit
        {
            get => selectedDistanceUnit;
            set => Set(ref selectedDistanceUnit, value);
        }

        public ObservableCollection<PickerItem<FuelUnit>> FuelUnits
            => fuelUnits ??= new ObservableCollection<PickerItem<FuelUnit>>
            {
                new PickerItem<FuelUnit>(FuelUnit.Liters, OptionUnitFuelLiters),
                new PickerItem<FuelUnit>(FuelUnit.Gallons, OptionUnitFuelGallons),
                new PickerItem<FuelUnit>(FuelUnit.KilowattHours, OptionUnitFuelKilowattHours)
            };

        public PickerItem<FuelUnit> SelectedFuelUnit
        {
            get => selectedFuelUnit;
            set => Set(ref selectedFuelUnit, value);
        }

        public SettingsViewModel()
        {
            PropertyChanged += OnPropertyChanged;
            if (!DesignMode.IsDesignModeEnabled && Settings.HasDefaultThemeOption)
            {
                Themes.Add(new PickerItem<Theme>(Theme.Default, OptionThemeDefault));
            }
            Themes.Add(new PickerItem<Theme>(Theme.Light, OptionThemeLight));
            Themes.Add(new PickerItem<Theme>(Theme.Dark, OptionThemeDark));

            SelectedTheme = Themes.FirstOrDefault(item => item.Id == Settings.ThemeOption);
            SelectedDistanceUnit = DistanceUnits.FirstOrDefault(item => item.Id == Settings.DistanceUnit);
            SelectedFuelUnit = FuelUnits.FirstOrDefault(item => item.Id == Settings.FuelUnit);
        }

        private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case nameof(SelectedTheme):
                    if (SelectedTheme == null) return;
                    Settings.ThemeOption = SelectedTheme.Id;
                    ThemeHelper.ChangeTheme(Settings.ThemeOption, true);
                    break;
                case nameof(SelectedDistanceUnit):
                    if (SelectedDistanceUnit == null) return;
                    Settings.DistanceUnit = SelectedDistanceUnit.Id;
                    MessagingCenter.Send(this, MESSAGE_CHANGE_UNIT, SelectedDistanceUnit.Id);
                    break;
                case nameof(SelectedFuelUnit):
                    if (SelectedFuelUnit == null) return;
                    Settings.FuelUnit = SelectedFuelUnit.Id;
                    MessagingCenter.Send(this, MESSAGE_CHANGE_UNIT, SelectedFuelUnit.Id);
                    break;
            }
        }
    }
}
