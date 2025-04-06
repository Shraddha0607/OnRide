namespace OnRideApp.Transformer;

public class TripBookingTransformer
{
    public static TripBooking TripRequestToTripBooking(TripBookingRequest request)
    {
        return new TripBooking
        {
            BookingId = Guid.NewGuid(),
            PickUp = request.PickUp,
            Destination = request.Destination,
            TripDistanceInKm = request.TripDistanceInKm,
            TripStatus = Models.MyEnums.TripStatus.IN_TRANSIT,
            BookedAt = request.BookedAt
        };
    }

    public static TripBookingResponse TripBookingToTripBookingResponse(TripBooking tripBooking)
    {
        return new TripBookingResponse
        {
            Id = tripBooking.Id,
            BookingId = tripBooking.BookingId.ToString(),
            PickUp = tripBooking.PickUp,
            Destination = tripBooking.Destination,
            TripDistanceInKm = tripBooking.TripDistanceInKm,
            TotalFare = tripBooking.TotalFare,
            TripStatus = tripBooking.TripStatus,
            BookedAt = tripBooking.BookedAt
        };
    }
}