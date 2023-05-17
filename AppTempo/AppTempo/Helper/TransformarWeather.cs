using AppTempo.Models;
using AppTempo.Services;
using AppTempo.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace AppTempo.Helper
{
    public static class TransformarWeather
    {
        
        public static async Task<WeatherData> mapearDadosWeatherAsync(WeatherData Weather)
        {
            DateTime date = DateTime.Now;
            CultureInfo cultureBR = new CultureInfo("pt-BR");
            GeolocationService geolocationService = new GeolocationService();

            Position location = await geolocationService.GetLocation();

            var adress = await geolocationService.GetCity(location);
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
                Weather.Main.TempMax = Math.Round(Weather.Main.TempMax, 0);
                Weather.Main.TempMin = Math.Round(Weather.Main.TempMin, 0);
                Weather.Main.Temp = Math.Round(Weather.Main.Temp, 0);
            }
            if (Weather.Weather.Any())
            {
                Weather.Weather.FirstOrDefault().Description = Weather.Weather.FirstOrDefault().Description[0].ToString().ToUpper() + Weather.Weather.FirstOrDefault().Description.Substring(1);
            }
            Weather.City = CityAdress;

            return Weather;
        }
    }
}
