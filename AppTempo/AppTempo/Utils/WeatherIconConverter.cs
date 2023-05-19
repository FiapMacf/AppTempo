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
                case "01d":
                case "01n":
                    return MaterialDesignIcons.WeatherSunny;
                case "02d":
                case "02n":
                    return MaterialDesignIcons.WeatherPartlyCloudy;
                case "03d":
                case "03n":
                    return MaterialDesignIcons.WeatherCloudy;
                case "04d":
                case "04n":
                    return MaterialDesignIcons.WeatherCloudy;
                case "09d":
                case "09n":
                    return MaterialDesignIcons.WeatherPouring;
                case "10d":
                case "10n":
                    return MaterialDesignIcons.WeatherRainy;
                case "11d":
                case "11n":
                    return MaterialDesignIcons.WeatherLightningRainy;
                case "13d":
                case "13n":
                    return MaterialDesignIcons.WeatherSnowy;
                case "50d":
                case "50n":
                    return MaterialDesignIcons.WeatherFog;
                default:
                    return string.Empty;
            }
        }
        public static string GetXamarinIconFromWeatherImage(string weatherIcon)
        {
            switch (weatherIcon)
            {
                case "01d":
                case "01n":  
                case "02d":
                case "02n":
                case "03d":
                case "03n":
                case "04d":
                case "04n":
                    return "walking_dog";
                case "09d":
                case "09n":
                case "10d":
                case "10n":
                case "11d":
                case "11n":
                case "13d":
                case "13n":
                case "50d":
                case "50n":
                    return "woman_raining";
                default:
                    return "walking_dog";
            }
        }
    }
}
