using System;

namespace WeatherService.Models
{
    public class ApiHistory
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
    }
}
