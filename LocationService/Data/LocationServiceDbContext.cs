using LocationService.Models;
using Microsoft.EntityFrameworkCore;

namespace LocationService.Data
{
    public class LocationServiceDbContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }

        public LocationServiceDbContext(DbContextOptions options) 
            : base(options)
        {

        }
    }
}
