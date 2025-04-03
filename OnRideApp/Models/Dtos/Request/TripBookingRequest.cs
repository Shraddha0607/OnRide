using System.ComponentModel.DataAnnotations;

namespace OnRideApp.Models.Dtos.Request;

public class TripBookingRequest
{
    public string PickUp { get; set; }
    public string Destination { get; set; }
    public double TripDistanceInKm { get; set; }
    public DateTime BookedAt { get; set; }
    [EmailAddress]
    public string CustomerEmailId { get; set; }
    public int CabSpecificationId { get; set; }
}
