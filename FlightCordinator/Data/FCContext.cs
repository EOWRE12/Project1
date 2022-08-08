using FlightCordinator.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightCordinator.Data
{
    public class FCContext : DbContext
    {
        public FCContext(DbContextOptions<FCContext> options) : base(options) { }

        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //TODO
        }
    }
}
