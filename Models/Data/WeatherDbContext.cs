using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WeatherApp.Models.Data
{
    public class WeatherDbContext : DbContext
    {
        public WeatherDbContext() : base("WeatherConnection")
        {

        }

        public DbSet<Users> User { get; set; }

        public DbSet<SavedLocation> SavedLocations { get; set; }

        public DbSet<WeatherHistory> WeatherHistories { get; set; }
    }
}
