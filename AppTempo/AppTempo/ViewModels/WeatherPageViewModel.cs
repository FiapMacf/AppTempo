using AppTempo.Database;
using AppTempo.Helper;
using AppTempo.Models;
using AppTempo.Models.ForecastModels;
using AppTempo.Services;
using AppTempo.Utils;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace AppTempo.ViewModels
{
    public class WeatherPageViewModel : BindableBase
    {
        public ObservableCollection<WeatherData> WeatherData { get; set; }
        public City City { get; set; }        
        public WeatherData Weather { get; set; }
        private Repository _repository { get; set; }

      
        public WeatherPageViewModel()
        {
            _repository = new Repository();

            WeatherData = new ObservableCollection<WeatherData>(_repository.ListWeatherData());

            if(WeatherData.Any())
                Weather = WeatherData.Last();

            Task.Run(async () => await LoadWeatherDataAsync()).Wait();

        }

        private async Task LoadWeatherDataAsync()
        {
            
            WeatherService weatherService = new WeatherService();
            GeolocationService geolocationService = new GeolocationService();

            

            Position location = await geolocationService.GetLocation();

            //todo utilizar
            ForecastData forecastData = await weatherService.GetWeatherListAsync(location);

            Weather = await weatherService.GetWeatherAsync(location);
            Weather = await TransformarWeather.mapearDadosWeatherAsync(Weather);
            _repository.InsertWeatherData(Weather);
        }
    }
}
