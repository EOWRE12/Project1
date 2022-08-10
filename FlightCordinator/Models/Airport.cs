namespace FlightCordinator.Models
{
    public class Airport
    {
        public Airport()
        {
            Flights = new HashSet<Flight>();
            Tickets = new HashSet<Ticket>();
        }
        public int AirportId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        //Navigations Properties 
        public virtual ICollection<Ticket>? Tickets { get; set; }
        public virtual ICollection<Flight>? Flights { get; set; }
    }
}
