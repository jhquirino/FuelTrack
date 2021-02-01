// -----------------------------------------------------------------------
//  <copyright file="CarEditViewModel.cs" company="Jorge Quirino">
//  Copyright (c) Jorge Quirino 2020-2021. All rights reserved.
//  </copyright>
//  <author>Jorge Quirino (jhquirino@outlook.com)</author>
// -----------------------------------------------------------------------
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using FuelTrack.Domain;
using FuelTrack.Models;
using FuelTrack.UseCases.Messages;
using MediatR;
using TinyMvvm;
using Xamarin.Forms;
using static FuelTrack.Models.Constants;
using static FuelTrack.Resources.Strings;

namespace FuelTrack.ViewModels
{
    public class CarEditViewModel : ViewModelBase
    {
        private readonly IMediator mediator;

        private ICommand saveCommand;

        private string title = TitleCar;
        private ObservableCollection<PickerItem<FuelType>> fuelTypes;
        private PickerItem<FuelType> selectedFuelType;
        public string alias;
        public string vendor;
        public string model;
        public ushort year;
        public string plate;
        public string note;

        public ICommand SaveCommand => saveCommand ??= new Command(async () => await OnSave());

        public string Title
        {
            get => title;
            set => Set(ref title, value);
        }

        public ObservableCollection<PickerItem<FuelType>> FuelTypes
            => fuelTypes ??= new ObservableCollection<PickerItem<FuelType>>
            {
                new PickerItem<FuelType>(FuelType.Unknown, OptionFuelTypeUnknown),
                new PickerItem<FuelType>(FuelType.Gasoline, OptionFuelTypeGasoline),
                new PickerItem<FuelType>(FuelType.Diesel, OptionFuelTypeDiesel),
                new PickerItem<FuelType>(FuelType.Petroleum, OptionFuelTypePetroleum),
                new PickerItem<FuelType>(FuelType.NaturalGas, OptionFuelTypeNaturalGas),
                new PickerItem<FuelType>(FuelType.Ethanol, OptionFuelTypeEthanol),
                new PickerItem<FuelType>(FuelType.BioDiesel, OptionFuelTypeBioDiesel),
                new PickerItem<FuelType>(FuelType.Hydrogen, OptionFuelTypeHydrogen),
                new PickerItem<FuelType>(FuelType.Electricity, OptionFuelTypeElectricity),
                new PickerItem<FuelType>(FuelType.Other, OptionFuelTypeOther)
            };

        public PickerItem<FuelType> SelectedFuelType
        {
            get => selectedFuelType;
            set => Set(ref selectedFuelType, value);
        }

        public string Id { get; private set; }

        public string Alias
        {
            get => alias;
            set => Set(ref alias, value);
        }

        public string Vendor
        {
            get => vendor;
            set => Set(ref vendor, value);
        }

        public string Model
        {
            get => model;
            set => Set(ref model, value);
        }

        public ushort Year
        {
            get => year;
            set => Set(ref year, value);
        }

        public string Plate
        {
            get => plate;
            set => Set(ref plate, value);
        }

        public string Note
        {
            get => note;
            set => Set(ref note, value);
        }

        public CarEditViewModel(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public override async Task Initialize()
        {
            await base.Initialize();
            var carId = NavigationParameter as string;
            if (string.IsNullOrWhiteSpace(carId))
            {
                // Add car
                Id = null;
                Title = TitleCarAdd;
                SelectedFuelType = FuelTypes.FirstOrDefault(item => item.Id == FuelType.Gasoline);
            }
            else
            {
                // Edit car
                Id = carId;
                Title = TitleCarEdit;
                // TODO Read car and fill information
            }
        }

        protected async Task OnSave()
        {
            // TODO Validate data
            if (string.IsNullOrEmpty(Id))
            {
                var request = new AddCarRequest(Alias)
                {
                    Vendor = Vendor,
                    Model = Model,
                    Year = Year,
                    Plate = Plate,
                    FuelType = SelectedFuelType.Id,
                    Note = Note
                };
                //var response = await mediator.Send(request).ConfigureAwait(false);
                var response = await mediator.Send(request);
                MessagingCenter.Send((object)this, MESSAGE_ADD_CAR, response);
            }
            else
            {
                await Task.Delay(500);
            }
            //await Navigation.BackAsync().ConfigureAwait(false);
            await Navigation.BackAsync();
        }
    }
}
