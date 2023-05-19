using System;
using System.Collections.Generic;
using System.Text;

namespace AppTempo.Helper
{
    public static class Conversor
    {
        public static string convertTimestampToDateHour(long timestamp)
        {
            DateTime dateTime = convertTimestampToDate(timestamp);
            return dateTime.ToString("hh:mm tt");
        }

        public static string convertTimestampToDateDate(long timestamp)
        {
            DateTime dateTime = convertTimestampToDate(timestamp);
            return dateTime.ToString("dd/MM/yy - HH:mm");
        }
        private static DateTime convertTimestampToDate(long timestamp)
        {
            return DateTimeOffset.FromUnixTimeSeconds(timestamp).ToOffset(TimeSpan.FromHours(-3)).DateTime;
            
        }

    }
}
