﻿using AppTempo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppTempo.Services
{
    public class WeatherService
    {
        private const string BaseUrlweather = "https://api.openweathermap.org/data/2.5/weather";
        private const string BaseUrlforecast = "https://api.openweathermap.org/data/2.5/forecast";
        
        private const string ApiKey = "45420be0a60479b93d265e8ad3e7e908";

        private readonly HttpClient httpClient;

        public WeatherService()
        {
            httpClient = new HttpClient();
        }

        public async Task<WeatherData> GetWeatherAsync(double latitude, double longitude)
        {
            string url = $"{BaseUrlweather}?lat={latitude}&lon={longitude}&units=metric&appid={ApiKey}&lang=pt_br";

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseContent = await response.Content.ReadAsStringAsync();
                WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(responseContent);

                return weatherData;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
