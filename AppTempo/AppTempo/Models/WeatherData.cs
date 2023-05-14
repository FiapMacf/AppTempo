using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTempo.Models
{
    public class WeatherData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Ignore]
        public Coord Coord { get; set; }
        [Ignore]
        public List<Weather> Weather { get; set; }
        public string Base { get; set; }
        [Ignore]
        public Main Main { get; set; }
        public int Visibility { get; set; }
        [Ignore]
        public Wind Wind { get; set; }
        [Ignore]
        public Rain Rain { get; set; }
        [Ignore]
        public Clouds Clouds { get; set; }
        public long Dt { get; set; }
        [Ignore]
        public Sys Sys { get; set; }
        public int Timezone { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
        public DateTime dateTime { get; set; }
        [Ignore]
        public City City { get; set; }

    }
}
