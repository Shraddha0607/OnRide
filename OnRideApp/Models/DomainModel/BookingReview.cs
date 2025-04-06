namespace OnRideApp.Models.DomainModel;

public class BookingReview
{
    public int Id { get; set; }
    public int TripBookingId { get; set; }
    public int ReviewId { get; set; }
    public TripBooking TripBooking { get; set; }

    public Review Review { get; set; }
}