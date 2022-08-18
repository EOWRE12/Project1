using FlightCordinator.DTO;

namespace FlightCordinator.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
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
            this.DepartureAirport = dto.DepartureAirport;
            this.ArrivalAirport = dto.ArrivalAirport;
            this.FlightNumber = dto.FlightNumber;
            this.Departure = dto.Departure;
            this.Arrival = dto.Arrival;
            this.Passengers = new List<Ticket>();
        }
        public Flight(FlightDTO dto, int id)
        {
            this.Id = id;
            this.Capacity = dto.Capacity;
            this.DepartureAirport = dto.DepartureAirport;
            this.ArrivalAirport = dto.ArrivalAirport;
            this.FlightNumber = dto.FlightNumber;
            this.Departure = dto.Departure;
            this.Arrival = dto.Arrival;
            this.Passengers = new List<Ticket>();
        }
    }
}
