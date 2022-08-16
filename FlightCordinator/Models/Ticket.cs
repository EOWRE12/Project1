using FlightCordinator.DTO;
using System.ComponentModel.DataAnnotations;

namespace FlightCordinator.Models
{
    public class Ticket
    {
        //primary key
        public int Id { get; set; }
        [Required]        
        public int PassengerId { get; set; }
        public virtual Passenger Passenger { get; set; }
        public int FlightId { get; set; }
        public virtual Flight Flight { get; set; }
    }
}
