// -----------------------------------------------------------------------
//  <copyright file="HomeViewModel.cs" company="Jorge Quirino">
//  Copyright (c) Jorge Quirino 2020-2021. All rights reserved.
//  </copyright>
//  <author>Jorge Quirino (jhquirino@outlook.com)</author>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using FuelTrack.Models;
using FuelTrack.UseCases.Messages;
using FuelTrack.Utils;
using MediatR;
using TinyMvvm;
using Xamarin.Forms;
using static FuelTrack.Models.Constants;

namespace FuelTrack.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly IMediator mediator;

        private ICommand addFuelUpCommand;

        private bool isLandscape;

        private string distanceUnitSymbol;

        private string fuelUnitSymbol;

        private string currencySymbol;

        private ObservableCollection<PickerItem<string>> cars;

        private PickerItem<string> selectedCar;

        public ICommand AddFuelUpCommand =>
            addFuelUpCommand ??= new Command(async () => await OnAddFuelUp());

        public bool IsLandscape
        {
            get => isLandscape;
            set => Set(ref isLandscape, value);
        }

        public string DistanceUnitSymbol
        {
            get => distanceUnitSymbol;
            set => Set(ref distanceUnitSymbol, value);
        }

        public string FuelUnitSymbol
        {
            get => fuelUnitSymbol;
            set => Set(ref fuelUnitSymbol, value);
        }

        public string CurrencySymbol
        {
            get => currencySymbol;
            set => Set(ref currencySymbol, value);
        }

        public ObservableCollection<PickerItem<string>> Cars =>
            cars ??= new ObservableCollection<PickerItem<string>>();

        public PickerItem<string> SelectedCar
        {
            get => selectedCar;
            set => Set(ref selectedCar, value);
        }

        public bool HasCars => Cars.Any();

        public HomeViewModel(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            DistanceUnitSymbol = Settings.DistanceUnit.ToSymbol();
            FuelUnitSymbol = Settings.FuelUnit.ToSymbol();
            CurrencySymbol = System.Globalization.NumberFormatInfo.CurrentInfo.CurrencySymbol;
            MessagingCenter.Subscribe<object, DistanceUnit>(this, MESSAGE_CHANGE_UNIT, OnDistanceUnitChanged);
            MessagingCenter.Subscribe<object, FuelUnit>(this, MESSAGE_CHANGE_UNIT, OnFuelUnitChanged);
            MessagingCenter.Subscribe<object, AddCarResponse>(this, MESSAGE_ADD_CAR, OnCarAdded);
            MessagingCenter.Subscribe<object, AddFuelUpResponse>(this, MESSAGE_ADD_FUELUP, OnFuelUpAdded);
            base.PropertyChanged += OnPropertyChanged;
        }

        private async void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedCar) &&
                !string.IsNullOrEmpty(SelectedCar?.Id))
            {
                var request = new GetFuelUpsByCarRequest(SelectedCar.Id);
                var fuelups = await mediator.Send(request);
                foreach (var fuelup in fuelups)
                {
                    System.Diagnostics.Debug.WriteLine($"CarId: {fuelup.CarId}, Id: {fuelup.Id}");
                }
            }
        }

        public async override Task Initialize()
        {
            IsBusy = true;
            await base.Initialize().ConfigureAwait(false);
            await GetCars().ConfigureAwait(false);
            IsBusy = false;
        }

        private async Task GetCars()
        {
            var cars = await mediator.Send(new GetCarsRequest());
            Cars.Clear();
            RaisePropertyChanged(nameof(HasCars));
            foreach (var car in cars)
            {
                Cars.Add(new PickerItem<string>(car.Id, car.Alias));
            }
            SelectedCar = Cars.FirstOrDefault();
            RaisePropertyChanged(nameof(HasCars));
        }

        protected async Task OnAddFuelUp()
        {
            if (!string.IsNullOrEmpty(SelectedCar?.Id))
            {
                var keys = new KeyValuePair<string, string>(SelectedCar.Id, null);
                await Navigation.NavigateToAsync("FuelUpEditView", keys);
            }
        }

        protected void OnDistanceUnitChanged(object sender, DistanceUnit unit)
        {
            DistanceUnitSymbol = unit.ToSymbol();
        }

        protected void OnFuelUnitChanged(object sender, FuelUnit unit)
        {
            FuelUnitSymbol = unit.ToSymbol();
        }

        protected void OnCarAdded(object sender, AddCarResponse response)
        {
            if (!response.Success) return;
            IsBusy = true;
            Cars.Add(new PickerItem<string>(response.Id, response.Alias));
            SelectedCar = Cars.FirstOrDefault(c => c.Id == response.Id);
            RaisePropertyChanged(nameof(HasCars));
            IsBusy = false;
        }

        protected void OnFuelUpAdded(object sender, AddFuelUpResponse response)
        {
            if (!response.Success) return;
            IsBusy = true;
            // TODO Handle fuelup added
            IsBusy = false;
        }
    }
}
