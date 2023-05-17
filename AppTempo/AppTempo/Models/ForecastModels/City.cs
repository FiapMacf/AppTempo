using System;
using System.Collections.Generic;
using System.Text;

namespace AppTempo.Models.ForecastModels
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Coordinates Coord { get; set; }
        public string Country { get; set; }
        public int Population { get; set; }
        public int Timezone { get; set; }
        public long Sunrise { get; set; }
        public long Sunset { get; set; }
    }
}
