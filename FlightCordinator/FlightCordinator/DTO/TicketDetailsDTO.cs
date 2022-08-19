using FlightCordinator.Models;

namespace FlightCordinator.DTO
{
    public class TicketDetailsDTO
    {
        public int id { get; set; }
        public int PassengerId { get; set; }
        public PassengerDTO Passenger { get; set; }
        public int FlightId { get; set; }
        public FlightDTO Flight { get; set; }
    }
}
