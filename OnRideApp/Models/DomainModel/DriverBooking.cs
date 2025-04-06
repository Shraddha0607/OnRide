namespace OnRideApp.Models.DomainModel;

public class DriverBooking
{
    public int Id { get; set; }
    public Driver Driver { get; set; }
    public ICollection<TripBooking> DriverTripBookingList { get; set; }
}