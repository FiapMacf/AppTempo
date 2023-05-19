using AppTempo.Models;
using AppTempo.Models.ForecastModels;
using AppTempo.Services;
using AppTempo.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Maps;

namespace AppTempo.Helper
{
    public static class TransformarWeather
    {
        
        public static async Task<WeatherData> mapearDadosWeatherAsync(WeatherData Weather)
        {
            DateTime date = DateTime.Now;
            CultureInfo cultureBR = new CultureInfo("pt-BR");
            var CityAdress = new AppTempo.Models.City
            {
                Name = Weather.Sys.Country,
                Time = date.TimeOfDay.ToString(),
                Icon = MaterialDesignIcons.WeatherPouring,
                IconColor = Color.FromHex("#773ad8"),
                Day = date.Day.ToString(),
                DayWeek = cultureBR.DateTimeFormat.GetAbbreviatedDayName(date.DayOfWeek),

            };
            if (Weather.Sys != null)
            {
                Weather.Sys.SunriseDate = Conversor.convertTimestampToDateHour(Weather.Sys.Sunrise);
                Weather.Sys.SunsetDate = Conversor.convertTimestampToDateHour(Weather.Sys.Sunset);
            }
            if (Weather.Main != null)
            {
                Weather.Main.Icon = WeatherIconConverter.GetXamarinIconFromWeatherIcon(Weather.Weather.FirstOrDefault().Icon);
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

        public static async Task<ForecastData> mapearDadosWeatherForecastAsync(ForecastData forecast)
        {
            DateTime date = DateTime.Now;
            CultureInfo cultureBR = new CultureInfo("pt-BR");
            forecast.List.ForEach(weatherForecast =>
            {
                weatherForecast.Data = Conversor.convertTimestampToDateDate(weatherForecast.Dt);

                if (weatherForecast.Sys != null)
                {

                    weatherForecast.Sys.SunriseDate = Conversor.convertTimestampToDateHour(weatherForecast.Sys.Sunrise);
                    weatherForecast.Sys.SunsetDate = Conversor.convertTimestampToDateHour(weatherForecast.Sys.Sunset);
                }
                if (weatherForecast.Main != null)
                {
                    weatherForecast.Main.Icon = WeatherIconConverter.GetXamarinIconFromWeatherIcon(weatherForecast.Weather.FirstOrDefault().Icon);
                    weatherForecast.Main.TempMax = Math.Round(weatherForecast.Main.TempMax, 0);
                    weatherForecast.Main.TempMin = Math.Round(weatherForecast.Main.TempMin, 0);
                    weatherForecast.Main.Temp = Math.Round(weatherForecast.Main.Temp, 0);
                    weatherForecast.Main.Description = weatherForecast.Weather.FirstOrDefault().Description[0].ToString().ToUpper() + weatherForecast.Weather.FirstOrDefault().Description.Substring(1);
                }
                if (weatherForecast.Weather.Any())
                {
                    weatherForecast.Weather.FirstOrDefault().Description = weatherForecast.Weather.FirstOrDefault().Description[0].ToString().ToUpper() + weatherForecast.Weather.FirstOrDefault().Description.Substring(1);
                }
            }
            );

            return forecast;
        }
    }
}
