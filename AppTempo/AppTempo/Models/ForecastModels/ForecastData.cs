using System;
using System.Collections.Generic;
using System.Text;

namespace AppTempo.Models.ForecastModels
{
    public class ForecastData
    {
        public string Cod { get; set; }
        public int Message { get; set; }
        public int Cnt { get; set; }
        public IEnumerable<WeatherForecast> List { get; set; }
        public City City { get; set; }
    }
}
