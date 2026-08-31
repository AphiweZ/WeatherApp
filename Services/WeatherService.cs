using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherService
    {
        private readonly string apiKey;
        private readonly string baseUrl;

        public WeatherService()
        {
            apiKey =
                ConfigurationManager.AppSettings[
                    "OpenWeatherApiKey"];

            baseUrl =
                ConfigurationManager.AppSettings[
                    "OpenWeatherBaseUrl"];

            if (string.IsNullOrEmpty(baseUrl))
            {
                baseUrl =
                    "https://api.openweathermap.org";
            }
        }

        public async Task<CurrentWeather>
            GetCurrentWeatherAsync(string city)
        {
            string url =
                $"{baseUrl}/data/2.5/weather" +
                $"?q={Uri.EscapeDataString(city)}" +
                $"&units=metric" +
                $"&appid={apiKey}";

            using (HttpClient client =
                   new HttpClient())
            {
                var response =
                    await client.GetAsync(url);

                var json =
                    await response.Content
                    .ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(
                        "City weather could not be found.");
                }

                return JsonConvert
                    .DeserializeObject<CurrentWeather>(
                        json);
            }
        }


        public async Task<ForecastResponse>
            GetForecastAsync(string city)
        {
            string url =
                $"{baseUrl}/data/2.5/forecast" +
                $"?q={Uri.EscapeDataString(city)}" +
                $"&units=metric" +
                $"&appid={apiKey}";

            using (HttpClient client =
                   new HttpClient())
            {
                var response =
                    await client.GetAsync(url);

                var json =
                    await response.Content
                    .ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(
                        "Forecast could not be retrieved.");
                }

                return JsonConvert
                    .DeserializeObject<ForecastResponse>(
                        json);
            }
        }


        public async Task<AirQualityResponse>
            GetAirQualityAsync(
                double latitude,
                double longitude)
        {
            string url =
                $"{baseUrl}/data/2.5/air_pollution" +
                $"?lat={latitude}" +
                $"&lon={longitude}" +
                $"&appid={apiKey}";

            using (HttpClient client =
                   new HttpClient())
            {
                var response =
                    await client.GetAsync(url);

                var json =
                    await response.Content
                    .ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(
                        "Air quality could not be retrieved.");
                }

                return JsonConvert
                    .DeserializeObject<AirQualityResponse>(
                        json);
            }
        }
    }
}
