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
            builder.Entity<Passenger>()
                .HasOne(t => t.Ticket)
                .WithOne(p => p.Passenger)
                .HasForeignKey<Ticket>(t => t.PassengerId);
            //Airport forigen key dependencies
            builder.Entity<Airport>().HasMany(airport => airport.Flights)
                .WithOne().HasForeignKey(f => f.DepartureAirportId).IsRequired();
            builder.Entity<Airport>().HasMany(airport => airport.Flights)
                .WithOne().HasForeignKey(f => f.ArrivalAirportId).IsRequired();
            
            builder.Entity<Airport>().HasMany(airport => airport.Tickets)
                .WithOne().HasForeignKey(t => t.DepartureAirportId).IsRequired();
            builder.Entity<Airport>().HasMany(airport => airport.Tickets)
                .WithOne().HasForeignKey(t => t.ArrivalAirportId).IsRequired();
        }
        public DbSet<FlightCordinator.Models.Ticket>? Ticket { get; set; }
    }
}

