using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using FlightCordinator.DTO;

namespace FlightCordinator.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        //navigation props
        public virtual ICollection<Ticket> Tickets { get; set; }

        public Passenger() { }

        public Passenger(PassengerDTO dto)
        {
            this.Email = dto.Email;
            this.FirstName = dto.FirstName;
            this.LastName = dto.LastName;
            this.Tickets = new List<Ticket>(); 
        }

        public Passenger(PassengerDTO dto, int id)
        {
            this.Id = id;
            this.Email = dto.Email;
            this.FirstName = dto.FirstName;
            this.LastName = dto.LastName;
            this.Tickets = new List<Ticket>();
        }
    }   
}
