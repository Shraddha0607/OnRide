namespace OnRideApp.Models.Dtos.Request
{
    public class TripBookingRequest
    {
        public string PickUp { get; set; }
        public string Destination { get; set; }
        public double TripDistanceInKm { get; set; }
        public string CustomerEmailId { get; set; }
    }
}
