using AppTempo.Models;
using ImTools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AppTempo.Database
{
    public class Repository
    {
        private DataBaseContext _context { get; set; }
        public Repository()
        {
            string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "appTempo.db");
            _context  = new DataBaseContext(databasePath);
        }

        public int InsertWeatherData(WeatherData weatherData)
        {
            // Inserir novo WeatherData
            _context.Insert(weatherData);
            int id = weatherData.Id;

            // Definir IDs de Coord (se necessário)
            if (weatherData.Coord != null)
            {
                weatherData.Coord.IdWeather = id;
                _context.Insert(weatherData.Coord);
            }

            // Definir IDs de Weather (se necessário)
            if (weatherData.Weather != null)
            {
                foreach (var weather in weatherData.Weather)
                    weather.IdWeather = id;
                _context.InsertAll(weatherData.Weather);
            }

            // Definir IDs de Main (se necessário)
            if (weatherData.Main != null)
            {
                weatherData.Main.IdWeather = id;
                _context.Insert(weatherData.Main);
            }

            // Definir IDs de Rain (se necessário)
            if (weatherData.Rain != null)
            {
                weatherData.Rain.IdWeather = id;
                _context.Insert(weatherData.Rain);
            }

            // Definir IDs de Clouds (se necessário)
            if (weatherData.Clouds != null)
            {
                weatherData.Clouds.IdWeather = id;
                _context.Insert(weatherData.Clouds);
            }

            // Definir IDs de Sys (se necessário)
            if (weatherData.Sys != null)
            {
                weatherData.Sys.IdWeather = id;
                _context.Insert(weatherData.Sys);
            }


            // Definir IDs de City (se necessário)
            if (weatherData.City != null)
            {
                weatherData.City.IdWeather = id;
                _context.Insert(weatherData.City);
            }

            return id;
        }

        public List<WeatherData> ListWeatherData()
        {
            var weathers = _context.Table<WeatherData>().ToList();
            weathers.ForEach(x =>
                x = GetWeatherData(x)
            );
            return weathers;
        }

        public WeatherData GetWeatherData(WeatherData weatherData)
        {
            weatherData.Weather = _context.Table<Weather>().Where(p => p.IdWeather == weatherData.Id).ToList();
            weatherData.City = _context.Table<City>().FirstOrDefault(p => p.IdWeather == weatherData.Id);
            weatherData.Sys = _context.Table<Sys>().FirstOrDefault(p => p.IdWeather == weatherData.Id);
            weatherData.Clouds = _context.Table<Clouds>().FirstOrDefault(p => p.IdWeather == weatherData.Id);
            weatherData.Coord = _context.Table<Coord>().FirstOrDefault(p => p.IdWeather == weatherData.Id);
            weatherData.Main = _context.Table<Main>().FirstOrDefault(p => p.IdWeather == weatherData.Id);
            weatherData.Wind = _context.Table<Wind>().FirstOrDefault(p => p.IdWeather == weatherData.Id);
            weatherData.Rain = _context.Table<Rain>().FirstOrDefault(p => p.IdWeather == weatherData.Id);
            return weatherData;
        }


        public void DeleteWeatherData(int id)
        {
            var weather = _context.Get<WeatherData>(id);
            _context.Delete(weather);
        }

    }
}
