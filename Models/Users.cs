using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeatherApp.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<SavedLocation> SavedLocations { get; set; }

        public Users()
        {
            SavedLocations = new HashSet<SavedLocation>();
        }
    }
}
 
