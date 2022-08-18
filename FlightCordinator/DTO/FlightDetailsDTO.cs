using FlightCordinator.Models;

namespace FlightCordinator.DTO
{
    public class FlightDetailsDTO
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public int NumPassengers { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public string FlightNumber { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }

        public List<Passenger> Passengers { get; set; }
    }
}
