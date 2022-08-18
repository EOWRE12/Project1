using FlightCordinator.Models;

namespace FlightCordinator.DTO
{
    public class PassengerDetailsDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public List<Flight> Flights;
        //public List<Ticket> Tickets;
        public PassengerDetailsDTO()
        {
            this.Flights = new List<Flight>();
        }
        public PassengerDetailsDTO(int id, string fname, string lname, string email, List<Flight> flight)
        {
            this.Id = id;
            this.FirstName = fname;
            this.LastName = lname;
            this.Email = email;
            this.Flights = flight;
        }
    }
}
