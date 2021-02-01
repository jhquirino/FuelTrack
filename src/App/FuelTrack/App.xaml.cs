// -----------------------------------------------------------------------
//  <copyright file="App.xaml.cs" company="Jorge Quirino">
//  Copyright (c) Jorge Quirino 2020-2021. All rights reserved.
//  </copyright>
//  <author>Jorge Quirino (jhquirino@outlook.com)</author>
// -----------------------------------------------------------------------
using System.Reflection;
using Autofac;
using FuelTrack.Data;
using FuelTrack.Styles;
using FuelTrack.UseCases.Messages;
using FuelTrack.Utils;
using MediatR;
using MediatR.Pipeline;
using TinyMvvm;
using TinyMvvm.Autofac;
using TinyMvvm.IoC;
using TinyNavigationHelper;
using TinyNavigationHelper.Forms;
using Xamarin.Forms;

namespace FuelTrack
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            App.Current.RequestedThemeChanged += OnRequestedThemeChanged;

            /*
             * Setup DI/IoC
             */
            var builder = new ContainerBuilder();

            // MVVM (views, viewmodels, navigation)
            var currentAssembly = Assembly.GetExecutingAssembly();
            var navigationHelper = new FormsNavigationHelper();
            navigationHelper.RegisterViewsInAssembly(currentAssembly);
            builder.RegisterInstance<INavigationHelper>(navigationHelper);
            builder.RegisterAssemblyTypes(currentAssembly)
                   .Where(x => x.IsSubclassOf(typeof(Page)));
            builder.RegisterAssemblyTypes(currentAssembly)
                   .Where(x => x.IsSubclassOf(typeof(ViewModelBase)));

            // Mediator
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();
            var mediatrOpenTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(IRequestExceptionHandler<,,>),
                typeof(IRequestExceptionAction<,>),
                typeof(INotificationHandler<>),
            };
            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                builder
                    .RegisterAssemblyTypes(typeof(GetCarsRequest).GetTypeInfo().Assembly)
                    .AsClosedTypesOf(mediatrOpenType)
                    .AsImplementedInterfaces();
            }
            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            // Data stores
            builder.RegisterType<Mock.MockCarStore>().As<ICarStore>().SingleInstance();
            builder.RegisterType<Mock.MockFuelUpStore>().As<IFuelUpStore>().SingleInstance();

            var container = builder.Build();
            Resolver.SetResolver(new AutofacResolver(container));

            MainPage = new NavigationPage(new Views.HomeView());
        }

        protected override void OnStart()
        {
            base.OnStart();
            ThemeHelper.ChangeTheme(Settings.ThemeOption, true);
        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }

        protected override void OnResume()
        {
            base.OnResume();
            ThemeHelper.ChangeTheme(Settings.ThemeOption, true);
        }

        private void OnRequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            ThemeHelper.ChangeTheme(Settings.ThemeOption, true);
        }
    }
}
