using System;
using System.Collections.Generic;
using System.Text;

namespace AppTempo.Models
{
    public class Weather
    {
        public int IdWeather { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
