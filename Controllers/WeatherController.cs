using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WeatherApp.Models;
using WeatherApp.Models.Data;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        private readonly WeatherService weatherService;
        private readonly WeatherDbContext db;

        public WeatherController()
        {
            weatherService = new WeatherService();

            db = new WeatherDbContext();
        }
        // GET:
        // /Weather/Dashboard?city=Durban

        public async Task<ActionResult> Dashboard(string city)
        {
            try
            {
                // If no city is entered, use Durban
                if (string.IsNullOrWhiteSpace(city))
                {
                    city = "Durban";
                }

                var weather =
                    await weatherService
                    .GetCurrentWeatherAsync(city);

                ViewBag.Weather = weather;
                ViewBag.City = weather.Name;

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET:
        // /Weather/Current?city=Durban

        public async Task<ActionResult>
            Current(string city)
        {
            try
            {
                var weather =
                    await weatherService
                    .GetCurrentWeatherAsync(city);

                // Save weather to database

                var history =
                    new WeatherHistory
                    {
                        City = weather.Name,

                        Temperature =
                            weather.Main.Temp,

                        FeelsLike =
                            weather.Main.Feels_Like,

                        Humidity =
                            weather.Main.Humidity,

                        WindSpeed =
                            weather.Wind.Speed,

                        Pressure =
                            weather.Main.Pressure,

                        WeatherCondition =
                            weather.Weather[0].Description,

                        Visibility =
                            weather.Visibility,

                        RecordedAt =
                            DateTime.Now
                    };

                db.WeatherHistories.Add(history);

                await db.SaveChangesAsync();


                return Json(
                    new
                    {
                        success = true,
                        data = weather
                    },
                    JsonRequestBehavior
                        .AllowGet);
            }
            catch (Exception ex)
            {
                return Json(
                    new
                    {
                        success = false,
                        message = ex.Message
                    },
                    JsonRequestBehavior
                        .AllowGet);
            }
        }


        // GET:
        // /Weather/Forecast?city=Durban

        public async Task<ActionResult>
            Forecast(string city)
        {
            try
            {
                var forecast =
                    await weatherService
                    .GetForecastAsync(city);

                return Json(
                    new
                    {
                        success = true,
                        data = forecast
                    },
                    JsonRequestBehavior
                        .AllowGet);
            }
            catch (Exception ex)
            {
                return Json(
                    new
                    {
                        success = false,
                        message = ex.Message
                    },
                    JsonRequestBehavior
                        .AllowGet);
            }
        }


        // GET:
        // /Weather/AirQuality?lat=-29.8587&lon=31.0218

        public async Task<ActionResult>
            AirQuality(
                double lat,
                double lon)
        {
            try
            {
                var airQuality =
                    await weatherService
                    .GetAirQualityAsync(
                        lat,
                        lon);

                return Json(
                    new
                    {
                        success = true,
                        data = airQuality
                    },
                    JsonRequestBehavior
                        .AllowGet);
            }
            catch (Exception ex)
            {
                return Json(
                    new
                    {
                        success = false,
                        message = ex.Message
                    },
                    JsonRequestBehavior
                        .AllowGet);
            }
        }
    }
}