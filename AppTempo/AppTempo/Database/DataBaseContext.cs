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
            // CreateTable<Contato>();
        }
    }
}
