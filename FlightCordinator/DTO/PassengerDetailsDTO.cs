using FlightCordinator.Models;

namespace FlightCordinator.DTO
{
    public class PassengerDetailsDTO
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }

        public List<Flight> Flights;
        //public List<Ticket> Tickets;
    }
}
