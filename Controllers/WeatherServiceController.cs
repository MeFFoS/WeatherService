using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WeatherService.Models;

namespace WeatherService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherServiceController : ControllerBase
    {
        ApplicationContext db;
        public WeatherServiceController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet("weather/{city}")]
        public string GetWeather(string city)
        {
            db.ApiHistories.Add(new ApiHistory { City = city, Type = "Текущая погода", Date = DateTime.Now });
            db.SaveChanges();

            var result = OpenWeatherMap.GetWeather(city);
            return result;
        }

        [HttpGet("weatherForecast/{city}")]
        public string GetWeatherForecast(string city)
        {
            db.ApiHistories.Add(new ApiHistory { City = city, Type = "Погода на 5 дней", Date = DateTime.Now });
            db.SaveChanges();

            var result = OpenWeatherMap.GetWeatherForecast(city);
            return result;
        }

        [HttpGet("apiHistory")]
        public IEnumerable<ApiHistory> GetApiHistory()
        {
            var result = db.ApiHistories.OrderByDescending(u => u.Date).Take(10).ToList();

            return result;
        }
    }
}
