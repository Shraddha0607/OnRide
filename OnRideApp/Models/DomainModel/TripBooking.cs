namespace OnRideApp.Models.DomainModel;

public class TripBooking
{
    public int Id { get; set; }
    public Guid BookingId { get; set; }
    public string PickUp { get; set; }
    public string Destination { get; set; }
    public double TripDistanceInKm { get; set; }
    public double TotalFare { get; set; }
    public TripStatus TripStatus { get; set; }
    public DateTime BookedAt { get; set; }
    public int CabId { get; set; }
    public int DriverId { get; set; }
    public int CustomerId { get; set; }
    public Cab Cab { get; set; }
    public Driver Driver { get; set; }
    public Customer Customer { get; set; }
}