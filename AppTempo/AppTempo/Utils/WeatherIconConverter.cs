using System;
using System.Collections.Generic;
using System.Text;

namespace AppTempo.Utils
{
    static class WeatherIconConverter
    {
        public static string GetXamarinIconFromWeatherIcon(string weatherIcon)
        {
            switch (weatherIcon)
            {
                case "01d.png":
                case "01n.png":
                    return MaterialDesignIcons.WeatherSunny;
                case "02d.png":
                case "02n.png":
                    return MaterialDesignIcons.WeatherPartlyCloudy;
                case "03d.png":
                case "03n.png":
                    return MaterialDesignIcons.WeatherCloudy;
                case "04d.png":
                case "04n.png":
                    return MaterialDesignIcons.WeatherCloudy;
                case "09d.png":
                case "09n.png":
                    return MaterialDesignIcons.WeatherPouring;
                case "10d.png":
                case "10n.png":
                    return MaterialDesignIcons.WeatherRainy;
                case "11d.png":
                case "11n.png":
                    return MaterialDesignIcons.WeatherLightningRainy;
                case "13d.png":
                case "13n.png":
                    return MaterialDesignIcons.WeatherSnowy;
                case "50d.png":
                case "50n.png":
                    return MaterialDesignIcons.WeatherFog;
                default:
                    return string.Empty;
            }
        }
    }
}
