using System;
using System.Collections.Generic;
using System.Text;

namespace AppTempo.Models
{    public class Sys
    {
        public int IdWeather { get; set; }
        public int Type { get; set; }
        public int Id { get; set; }
        public string Country { get; set; }
        public long Sunrise { get; set; }
        public long Sunset { get; set; }
        public string SunriseDate { get; set; }
        public string SunsetDate { get; set; }

    }
}
