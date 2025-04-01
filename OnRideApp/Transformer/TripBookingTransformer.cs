using OnRideApp.Models.DomainModel;
using OnRideApp.Models.Dtos;

namespace OnRideApp.Transformer
{
    public class TripBookingTransformer
    {
        public static TripBooking TripRequestToTripBooking(TripBookingRequest request)
        {
            return new TripBooking
            {
                PickUp = request.PickUp,
                Destination = request.Destination,
                TripDistancePrKm = request.TripDistancePrKm,
                TripStatus = Models.MyEnums.TripStatus.IN_TRANSIT
            };
        }
    }
}
