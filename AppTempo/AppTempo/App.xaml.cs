using AppTempo.Database;
using AppTempo.ViewModels;
using AppTempo.Views;
using Prism;
using Prism.Ioc;
using System;
using System.IO;
using Xamarin.Forms;

namespace AppTempo
{

    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/WeatherPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<WeatherPage, WeatherPageViewModel>();
        }
    }
}
