namespace OnRideApp.Models.Dtos
{
    public class TripBookingRequest
    {
        public string PickUp { get; set; }
        public string Destination { get; set; }
        public double TripDistancePrKm { get; set; }
        public string CustomerEmailId { get; set; }
    }
}
