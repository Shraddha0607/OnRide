namespace OnRideApp.Models.DomainModel
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string PanNumber { get; set; }
        public string MobNumber { get; set; }
        public double Rating { get; set; }
        public int CabId { get; set; }  // foreign key reference to Cab
        public Cab Cab { get; set; }
        public ICollection<TripBooking> DriverTripBookingList { get; set; }
    }
}
