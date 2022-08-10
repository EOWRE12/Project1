namespace FlightCordinator.Models
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public int? TicketId { get; set; }
        public Ticket? Ticket { get; set; }

        //Navigation Properties
        //public virtual ICollection<Flight> Flights { get; set; } 
        //public virtual ICollection<Airport> Airports { get; set; }
    }
}
