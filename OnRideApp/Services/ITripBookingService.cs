namespace OnRideApp.Services;

public interface ITripBookingService
{
    Task<TripBooking> AddTripBookingAsync(TripBookingRequest tripBookingRequest);
}