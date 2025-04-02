using OnRideApp.Models.DomainModel;
using OnRideApp.Models.Dtos.Request;

namespace OnRideApp.Services
{
    public interface ITripBookingService
    {
        Task<TripBooking> AddTripBookingAsync(TripBookingRequest tripBookingRequest);
    }
}
