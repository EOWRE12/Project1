namespace FlightCordinator.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public int NumPassengers { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }

        //Navigation Properties
        public virtual ICollection<Passenger> Passengers { get; set; }

        public virtual ICollection<Airport> Airports { get; set; }

    }
}
