using AppTempo.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTempo.Database
{
    public class DataBaseContext : SQLite.SQLiteConnection
    {
        public DataBaseContext(string connectionString) : base(connectionString)
        {
            CreateTable<WeatherData>();
            CreateTable<Weather>();
            CreateTable<Clouds>();
            CreateTable<Coord>();
            CreateTable<Main>();
            CreateTable<Rain>();
            CreateTable<Sys>();
            CreateTable<Wind>();
            CreateTable<City>();

        }
    }
}
