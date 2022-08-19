using FlightCordinator.Models;

namespace FlightCordinator.DTO
{
    public class PassengerDetailsDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Job { get; set; }
        public int Age { get; set; }
        public List<Flight> Flights { get; set; }

    }
}
