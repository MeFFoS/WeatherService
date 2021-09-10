using System.Net;
using System.Text;
using System.Web;

namespace WeatherService
{
    public static class OpenWeatherMap
    {
        static string apikey = "5fc66e5b9ee6679ef2a54f08286e6432";
        static string baseUrl = @"https://api.openweathermap.org/data/2.5/";

        static string Get(string url)
        {
            WebClient wc = new WebClient() { Encoding = Encoding.UTF8 };
            var r = wc.DownloadString(baseUrl + url);
            return r;
        }
        public static string GetWeather(string city)
        {
            var cityEncode = HttpUtility.HtmlEncode(city);
            string url = $@"weather?q={cityEncode}&units=metric&lang=ru&appid={apikey}";
            var result = Get(url);
            return result;
        }
        public static string GetWeatherForecast(string city)
        {
            var cityEncode = HttpUtility.HtmlEncode(city);
            string url = $@"forecast?q={cityEncode}&units=metric&lang=ru&appid={apikey}";
            var result = Get(url);
            return result;
        }
    }
}
