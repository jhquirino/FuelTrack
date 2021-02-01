// -----------------------------------------------------------------------
//  <copyright file="FuelUpEditViewModel.cs" company="Jorge Quirino">
//  Copyright (c) Jorge Quirino 2020-2021. All rights reserved.
//  </copyright>
//  <author>Jorge Quirino (jhquirino@outlook.com)</author>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using FuelTrack.Models;
using FuelTrack.UseCases.Messages;
using FuelTrack.Utils;
using MediatR;
using TinyMvvm;
using Xamarin.Forms;
using static FuelTrack.Models.Constants;
using static FuelTrack.Resources.Strings;

namespace FuelTrack.ViewModels
{
    public class FuelUpEditViewModel : ViewModelBase
    {
        private readonly IMediator mediator;

        private ICommand saveCommand;

        private string title = TitleFuelUp;

        private DateTime date;

        private TimeSpan time;

        private decimal quantity;

        private decimal amount;

        private decimal distance;

        private string note;

        private bool isPartial;

        private string distanceUnitSymbol;

        private string fuelUnitSymbol;

        private string currencySymbol;

        public ICommand SaveCommand => saveCommand ??= new Command(async () => await OnSave());

        public string Title
        {
            get => title;
            set => Set(ref title, value);
        }

        public string Id { get; private set; }

        public string CarId { get; private set; }

        public DateTime Date
        {
            get => date;
            set => Set(ref date, value);
        }

        public TimeSpan Time
        {
            get => time;
            set => Set(ref time, value);
        }

        public decimal Quantity
        {
            get => quantity;
            set => Set(ref quantity, value);
        }

        public decimal Amount
        {
            get => amount;
            set => Set(ref amount, value);
        }

        public decimal Distance
        {
            get => distance;
            set => Set(ref distance, value);
        }

        public string Note
        {
            get => note;
            set => Set(ref note, value);
        }

        public bool IsPartial
        {
            get => isPartial;
            set => Set(ref isPartial, value);
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

        public FuelUpEditViewModel(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            DistanceUnitSymbol = Settings.DistanceUnit.ToSymbol();
            FuelUnitSymbol = Settings.FuelUnit.ToSymbol();
            CurrencySymbol = System.Globalization.NumberFormatInfo.CurrentInfo.CurrencySymbol;
            MessagingCenter.Subscribe<object, DistanceUnit>(this, MESSAGE_CHANGE_UNIT, OnDistanceUnitChanged);
            MessagingCenter.Subscribe<object, FuelUnit>(this, MESSAGE_CHANGE_UNIT, OnFuelUnitChanged);
        }

        public override async Task Initialize()
        {
            await base.Initialize();
            if (NavigationParameter == null)
            {
                await Navigation.BackAsync();
                return;
            }
            var keys = (KeyValuePair<string, string>)NavigationParameter;
            if (string.IsNullOrEmpty(keys.Key))
            {
                await Navigation.BackAsync();
                return;
            }
            CarId = keys.Key;
            if (string.IsNullOrEmpty(keys.Value))
            {
                // Add fuelup
                Id = null;
                Title = TitleFuelUpAdd;
                Date = DateTime.Today;
                Time = DateTime.Now.TimeOfDay;
            }
            else
            {
                // Edit fuelup
                Id = keys.Value;
                Title = TitleFuelUpEdit;
                // TODO Read fuelup and fill information
            }
        }

        protected async Task OnSave()
        {
            // TODO Validate data
            if (string.IsNullOrEmpty(Id))
            {
                var request = new AddFuelUpRequest(
                    CarId,
                    Date.Date.Add(Time),
                    Quantity,
                    Amount,
                    Distance
                )
                {
                    Note = Note,
                    IsPartial = IsPartial
                };
                var response = await mediator.Send(request);
                MessagingCenter.Send((object)this, MESSAGE_ADD_FUELUP, response);
            }
            else
            {
                await Task.Delay(500);
            }
            await Navigation.BackAsync();
        }

        protected void OnDistanceUnitChanged(object sender, DistanceUnit unit)
        {
            DistanceUnitSymbol = unit.ToSymbol();
        }

        protected void OnFuelUnitChanged(object sender, FuelUnit unit)
        {
            FuelUnitSymbol = unit.ToSymbol();
        }
    }
}
