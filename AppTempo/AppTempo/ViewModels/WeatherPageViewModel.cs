using AppTempo.Database;
using AppTempo.Helper;
using AppTempo.Models;
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
        public ObservableCollection<City> Cities { get; set; }
        public ObservableCollection<WeatherData> WeatherData { get; set; }
        public City City { get; set; }        
        public WeatherData Weather { get; set; }
        private Repository _repository { get; set; }

        CultureInfo cultureBR = new CultureInfo("pt-BR");
        public WeatherPageViewModel()
        {
            _repository = new Repository();

            WeatherData = new ObservableCollection<WeatherData>(_repository.ListWeatherData());
            Weather = WeatherData.Last();
            Task.Run(async () => await LoadWeatherDataAsync()).Wait();

        }

        private async Task LoadWeatherDataAsync()
        {
            DateTime date = DateTime.Now;
            WeatherService weatherService = new WeatherService();
            GeolocationService geolocationService = new GeolocationService();

            Position location = await geolocationService.GetLocation();

            double latitude = -22.9236;//location.Item1; // latitude value from the tuple
            double longitude = -45.4598; //location.Item2; // longitude value from the tuple

            var adress = await geolocationService.GetCity(new Position(latitude, longitude));
            Weather = await weatherService.GetWeatherAsync(latitude, longitude);
            var CityAdress = new City
            {
                Name = adress,
                Time = date.TimeOfDay.ToString(),
                Icon = MaterialDesignIcons.WeatherPouring,
                IconColor = Color.FromHex("#773ad8"),
                Day = date.Day.ToString(),
                DayWeek = cultureBR.DateTimeFormat.GetAbbreviatedDayName(date.DayOfWeek),

            };
            if (Weather.Sys != null)
            {
                Weather.Sys.SunriseDate = Conversor.convertTimestampToDate(Weather.Sys.Sunrise);
                Weather.Sys.SunsetDate = Conversor.convertTimestampToDate(Weather.Sys.Sunset);
            }
            if (Weather.Main != null)
            {
                Weather.Main.Temp = Math.Round(Weather.Main.Temp, 0);
                Weather.Main.TempMin = Math.Round(Weather.Main.TempMin, 0);
                Weather.Main.TempMax = Math.Round(Weather.Main.TempMax, 0);
            }
            if (Weather.Weather.Any())
            {
                Weather.Weather.ForEach(x => x.Description = x.Description.First().ToString().ToUpper() + x.Description?.Substring(1).ToLower());
            }
           
            Weather.City = CityAdress;
            _repository.InsertWeatherData(Weather);
        }
    }
}
