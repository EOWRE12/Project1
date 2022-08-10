namespace FlightCordinator.Models
{
    public class Flight
    {
        public Flight() { }
        public int FlightId { get; set; }
        public int NumPassengers => Passengers?.Count ?? 0;
        public int DepartureAirportId { get; set; }
        public int ArrivalAirportId { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }

        //Navigation Properties
        public virtual ICollection<Passenger>? Passengers { get; set; }
        public virtual ICollection<Ticket>? Tickets { get; set; }

    }
}
