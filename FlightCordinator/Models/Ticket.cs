using FlightCordinator.DTO;

namespace FlightCordinator.Models
{
    public class Ticket
    {
        //primary key
        public int TicketId { get; set; }
        //forgien keys 
        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; }
        public int FlightId { get; set; }
        public string PassengerName => Passenger.FirstName + " " + Passenger.LastName;
        public int ArrivalAirportId { get; set; }
        public int DepartureAirportId { get; set; }
    }
}
