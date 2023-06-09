﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppTempo.Models.ForecastModels
{
    public class WeatherForecast
    {
        public long Dt { get; set; }
        public string Data { get; set; }
        public MainWeatherData Main { get; set; }
        public List<Weather> Weather { get; set; }
        public Clouds Clouds { get; set; }
        public Wind Wind { get; set; }
        public int Visibility { get; set; }
        public double Pop { get; set; }
        public Rain Rain { get; set; }
        public Models.Sys Sys { get; set; }
        public string DtTxt { get; set; }
    }
}
