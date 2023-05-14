using System;
using System.Collections.Generic;
using System.Text;

namespace AppTempo.Helper
{
    public static class Conversor
    {
        public static string convertTimestampToDate(long timestamp)
        {
            System.DateTime dat_Time = new System.DateTime(1965, 1, 1, 0, 0, 0, 0);
            dat_Time = dat_Time.AddSeconds(timestamp);
            return dat_Time.ToString("hh: mm tt");
        }
    }
}
