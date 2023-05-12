using AppTempo.Models;
using ImTools;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTempo.Database
{
    public class Repository
    {
        private DataBaseContext _context { get; set; }
        public Repository(DataBaseContext context)
        {
            _context = context;
        }

        public int InsertWeatherData(WeatherData weatherData)
        {
            // Inserir novo WeatherData
            int id = _context.Insert(weatherData);

            // Definir IDs de Coord (se necessário)
            if (weatherData.Coord != null)
            {
                weatherData.Coord.IdWeather = id;
                _context.Update(weatherData.Coord);
            }

            // Definir IDs de Weather (se necessário)
            if (weatherData.Weather != null)
            {
                foreach (var weather in weatherData.Weather)
                    weather.IdWeather = id;
                _context.UpdateAll(weatherData.Weather);
            }

            // Definir IDs de Main (se necessário)
            if (weatherData.Main != null)
            {
                weatherData.Main.IdWeather = id;
                _context.Update(weatherData.Main);
            }

            // Definir IDs de Rain (se necessário)
            if (weatherData.Rain != null)
            {
                weatherData.Rain.IdWeather = id;
                _context.Update(weatherData.Rain);
            }

            // Definir IDs de Clouds (se necessário)
            if (weatherData.Clouds != null)
            {
                weatherData.Clouds.IdWeather = id;
                _context.Update(weatherData.Clouds);
            }

            // Definir IDs de Sys (se necessário)
            if (weatherData.Sys != null)
            {
                weatherData.Sys.IdWeather = id;
                _context.Update(weatherData.Sys);
            }

            return id;

        }

        public void ListWeatherData()
        {
            _context.Table<WeatherData>().ToList();
        }

        public void DeleteWeatherData(int id)
        {
            var weather = _context.Get<WeatherData>(id);
            _context.Delete(weather);
        }

    }
}
