namespace FlightCordinator.Models
{
    public class Airport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }    
        public string City { get; set; }
        public string State { get; set; }


        //Navigations Properties 
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
