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
        public DbSet<Ticket> Tickets { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Ticket>()
                .HasKey(t => t.Id);

            //builder.Entity<Ticket>()
            //    .HasOne(t => t.Passenger)
            //    .WithMany(p => p.Tickets)
            //    .HasForeignKey(t => t.PassengerId);

            //builder.Entity<Ticket>()
            //    .HasOne(t => t.Flight)
            //    .WithMany(f => f.Passengers)
            //    .HasForeignKey(t => t.PassengerId);
        }
    }
}

