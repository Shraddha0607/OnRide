namespace OnRideApp.Models.DomainModel;

public class CustomerBooking
{
    public int Id { get; set; }
    public Customer Customer { get; set; }
    public ICollection<TripBooking> TripBookings { get; set; }
}
