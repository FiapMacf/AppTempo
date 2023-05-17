using System;
using System.Collections.Generic;
using System.Text;

namespace AppTempo.Models.ForecastModels
{
    public class MainWeatherData
    {
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int Pressure { get; set; }
        public int SeaLevel { get; set; }
        public int GroundLevel { get; set; }
        public int Humidity { get; set; }
        public double TempKf { get; set; }
    }
}
