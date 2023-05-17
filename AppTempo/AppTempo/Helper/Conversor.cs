using System;
using System.Collections.Generic;
using System.Text;

namespace AppTempo.Helper
{
    public static class Conversor
    {
        public static string convertTimestampToDate(long timestamp)
        {
            DateTime dateTime = DateTimeOffset.FromUnixTimeSeconds(timestamp).DateTime;
            return dateTime.ToString("hh:mm tt");
        }
    }
}
