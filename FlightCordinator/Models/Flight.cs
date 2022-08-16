using FlightCordinator.DTO;

namespace FlightCordinator.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public int DepartureAirportId { get; set; }
        public int ArrivalAirportId { get; set; }
        public string FlightNumber { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }

        public int NumPassengers => Passengers?.Count ?? 0;
        //Navigation Properties
        public virtual ICollection<Ticket> Passengers { get; set; }

        public Flight() { }

        public Flight(FlightDTO dto)
        {
            this.Capacity = dto.Capacity;
            this.DepartureAirportId = dto.DepartureAirportId;
            this.ArrivalAirportId = dto.ArrivalAirportId;
            this.FlightNumber = dto.FlightNumber;
            this.Departure = dto.Departure;
            this.Arrival = dto.Arrival;
            this.Passengers = new List<Ticket>();
        }

    }
}
