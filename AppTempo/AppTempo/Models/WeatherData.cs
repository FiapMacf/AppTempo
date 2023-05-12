﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTempo.Models
{
    public class WeatherData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public Coord Coord { get; set; }
        public Weather[] Weather { get; set; }
        public string Base { get; set; }
        public Main Main { get; set; }
        public int Visibility { get; set; }
        public Wind Wind { get; set; }
        public Rain Rain { get; set; }
        public Clouds Clouds { get; set; }
        public long Dt { get; set; }
        public Sys Sys { get; set; }
        public int Timezone { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }
}
