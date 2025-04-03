namespace OnRideApp.Models.DomainModel;

public class BookingReview
{
    public int Id { get; set; }
    public TripBooking TripBooking { get; set; }
    public Review Review { get; set; }
}
