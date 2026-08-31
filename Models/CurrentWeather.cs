using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApp.Models
{
    public class CurrentWeather
    {
        public MainWeather Main { get; set; }

        public Wind Wind { get; set; }

        public List<WeatherDescription> Weather { get; set; }

        public SysInfo Sys { get; set; }

        public Coordinates Coord { get; set; }

        public string Name { get; set; }

        public int Visibility { get; set; }
    }

    public class MainWeather
    {
        public double Temp { get; set; }

        public double Feels_Like { get; set; }

        public double Temp_Min { get; set; }

        public double Temp_Max { get; set; }

        public int Pressure { get; set; }

        public int Humidity { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }

        public double Deg { get; set; }
    }

    public class WeatherDescription
    {
        public string Main { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }
    }

    public class SysInfo
    {
        public long Sunrise { get; set; }

        public long Sunset { get; set; }

        public string Country { get; set; }
    }

    public class Coordinates
    {
        public double Lat { get; set; }

        public double Lon { get; set; }
    }


    // FORECAST

    public class ForecastResponse
    {
        public List<ForecastItem> List { get; set; }

        public CityInfo City { get; set; }
    }

    public class ForecastItem
    {
        public long Dt { get; set; }

        public MainWeather Main { get; set; }

        public List<WeatherDescription> Weather { get; set; }

        public Wind Wind { get; set; }

        public string Dt_Txt { get; set; }

        public double Pop { get; set; }
    }

    public class CityInfo
    {
        public string Name { get; set; }

        public Coordinates Coord { get; set; }

        public string Country { get; set; }
    }


    // AIR QUALITY

    public class AirQualityResponse
    {
        public List<AirQualityItem> List { get; set; }
    }

    public class AirQualityItem
    {
        public AirMain Main { get; set; }

        public AirComponents Components { get; set; }
    }

    public class AirMain
    {
        public int Aqi { get; set; }
    }

    public class AirComponents
    {
        public double Co { get; set; }

        public double No { get; set; }

        public double No2 { get; set; }

        public double O3 { get; set; }

        public double So2 { get; set; }

        public double Pm2_5 { get; set; }

        public double Pm10 { get; set; }

        public double Nh3 { get; set; }
    }
}
