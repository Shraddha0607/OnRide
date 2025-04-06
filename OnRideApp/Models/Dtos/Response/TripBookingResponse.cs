namespace OnRideApp.Models.Dtos.Response;

public class TripBookingResponse
{
    public int Id { get; set; }
    public String BookingId { get; set; }
    public string PickUp { get; set; }
    public string Destination { get; set; }
    public double TripDistanceInKm { get; set; }
    public double TotalFare { get; set; }
    public TripStatus TripStatus { get; set; }
    public DateTime BookedAt { get; set; }
    public string DriverName { get; set; }
    public double DriverRating { get; set; }
}