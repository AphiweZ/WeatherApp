using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WeatherApp.Models
{
    public class SavedLocation
    {
        [Key]
        public int LocationId { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual Users User { get; set; }
    }
}
