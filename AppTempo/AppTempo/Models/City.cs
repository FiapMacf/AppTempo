using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppTempo.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Temparute { get; set; }
        public string Time { get; set; }
        public string Day { get; set; }
        public string DayWeek { get; set; }
        public string Icon { get; set; }
        public Color IconColor { get; set; }
    }
}
