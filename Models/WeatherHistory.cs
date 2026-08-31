using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WeatherApp.Models
{
    public class WeatherHistory
    {
        [Key]
        public int WeatherHistoryId { get; set; }

        [Required]
        public string City { get; set; }

        public double Temperature { get; set; }

        public double FeelsLike { get; set; }

        public int Humidity { get; set; }

        public double WindSpeed { get; set; }

        public int Pressure { get; set; }

        public string WeatherCondition { get; set; }

        public int Visibility { get; set; }

        public DateTime RecordedAt { get; set; }

        [ForeignKey("SavedLocation")]
        public int? LocationId { get; set; }

        public virtual SavedLocation SavedLocation { get; set; }
    }
}
