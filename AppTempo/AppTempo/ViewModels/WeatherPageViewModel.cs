using AppTempo.Models;
using AppTempo.Services;
using AppTempo.Utils;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppTempo.ViewModels
{
    public class WeatherPageViewModel : BindableBase
    {
        public ObservableCollection<City> Cities { get; set; }
        public ObservableCollection<WeatherSchedule> WeatherSchedule { get; set; }
        public ObservableCollection<WeatherSchedule> WeatherScheduleIcon { get; set; }
        public City City { get; set; }        
        public WeatherData Weather { get; set; }
        
        CultureInfo cultureBR = new CultureInfo("pt-BR");
        public WeatherPageViewModel()
        {

            DateTime date = DateTime.Now;
            City = new City
            {
                Id = 1,
                Name = "Naples",
                Temparute = "22°",
                Time = "11:25",
                Icon = MaterialDesignIcons.WeatherPouring,
                IconColor = Color.FromHex("#773ad8"),
                Day = date.Day.ToString(),
                DayWeek = cultureBR.DateTimeFormat.GetAbbreviatedDayName(date.DayOfWeek),
            };

            Cities = new ObservableCollection<City>
            {
                new City
                {
                    Id = 1,
                    Name = "Naples",
                    Temparute = "22°",
                    Time = "11:25",
                    Icon = MaterialDesignIcons.WeatherPouring,
                    IconColor = Color.FromHex("#773ad8")
                },
                new City
                {
                    Id = 2,
                    Name = "Lodon",
                    Temparute = "24°",
                    Time = "10:25",
                    Icon = MaterialDesignIcons.WeatherPartlyCloudy,
                    IconColor = Color.FromHex("#773ad8")
                },
                new City
                {
                    Id = 1,
                    Name = "Paris",
                    Temparute = "27°",
                    Time = "11:25",
                    Icon = MaterialDesignIcons.WeatherSunny,
                    IconColor = Color.FromHex("#fed262")
                },
                new City
                {
                    Id = 1,
                    Name = "Brussels",
                    Temparute = "21°",
                    Time = "11:25",
                    Icon = MaterialDesignIcons.WeatherPouring,
                    IconColor = Color.FromHex("#773ad8")
                }
            };

            WeatherSchedule = new ObservableCollection<WeatherSchedule>
            {
                new WeatherSchedule
                {
                    Time = "9:00",
                    Icon = MaterialDesignIcons.WeatherPouring,
                    Temparature = "18°"
                },
                new WeatherSchedule
                {
                    Time = "10:00",
                    Icon = MaterialDesignIcons.WeatherPouring,
                    Temparature = "19°"
                },
                new WeatherSchedule
                {
                    Time = "11:00",
                    Icon = MaterialDesignIcons.WeatherPouring,
                    IsCurrentTime = true,
                    Temparature = "19°"
                },
                new WeatherSchedule
                {
                    Time = "12:00",
                    Icon = MaterialDesignIcons.WeatherCloudy,
                    Temparature = "18°"
                },
                new WeatherSchedule
                {
                    Time = "13:00",
                    Icon = MaterialDesignIcons.WeatherPartlyCloudy,
                    Temparature = "18°"
                },
                new WeatherSchedule
                {
                    Time = "14:00",
                    Icon = MaterialDesignIcons.WeatherSunny,
                    Temparature = "18°"
                },
                new WeatherSchedule
                {
                    Time = "15:00",
                    Icon = MaterialDesignIcons.WeatherSunny,
                    Temparature = "18°"
                },
                new WeatherSchedule
                {
                    Time = "16:00",
                    Icon = MaterialDesignIcons.WeatherPartlyCloudy,
                    Temparature = "18°"
                }
            };

            WeatherScheduleIcon = new ObservableCollection<WeatherSchedule>
            {
                new WeatherSchedule
                {
                    Icon = "woman_raining",
                    IconColor = Color.FromHex("#773ad8"),
                    Hours = 4
                },
                new WeatherSchedule
                {
                    Icon = "walking_dog",
                    IconColor = Color.FromHex("#fed262"),
                    Hours = 4
                }
            };


            Task.Run(async () => await LoadWeatherDataAsync()).Wait();
        }

        private async Task LoadWeatherDataAsync()
        {
            WeatherService weatherService = new WeatherService();
            GeolocationService geolocationService = new GeolocationService();

            Tuple<double, double> location = await geolocationService.GetLocation();

            double latitude = location.Item1; // latitude value from the tuple
            double longitude = location.Item2; // longitude value from the tuple

            Weather = await weatherService.GetWeatherAsync(latitude, longitude);
            // Handle the weather data as needed
        }
    }
}
