// -----------------------------------------------------------------------
//  <copyright file="HomeView.xaml.cs" company="Jorge Quirino">
//  Copyright (c) Jorge Quirino 2020-2021. All rights reserved.
//  </copyright>
//  <author>Jorge Quirino (jhquirino@outlook.com)</author>
// -----------------------------------------------------------------------
using Xamarin.Essentials;

namespace FuelTrack.Views
{
    public partial class HomeView
    {
        public HomeView()
        {
            InitializeComponent();
            DeviceDisplay.MainDisplayInfoChanged += OnMainDisplayInfoChanged;
        }

        protected void OnMainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
        {
            if (BindingContext is ViewModels.HomeViewModel viewModel)
            {
                viewModel.IsLandscape = e.DisplayInfo.Orientation == DisplayOrientation.Landscape;
            }
        }
    }
}
