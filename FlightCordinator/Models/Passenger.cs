namespace FlightCordinator.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        //Navigation Properties
        public virtual ICollection<Flight> Flights { get; set; } 
        public virtual ICollection<Airport> Airports { get; set; }
    }
}
