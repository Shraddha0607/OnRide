namespace OnRideApp.Models.Dtos.Request;

public class TripBookingRequest
{
    [RegularExpression(RegexPatterns.AlphanumericWithSpace, ErrorMessage = "Special characters not allowed!")]
    [StringLength(100, ErrorMessage = "Pickup address must to be upto 100 characters.")]
    public string PickUp { get; set; }

    [RegularExpression(RegexPatterns.AlphanumericWithSpace, ErrorMessage = "Special characters not allowed!")]
    [StringLength(100, ErrorMessage = "Destination address must to be upto 100 characters.")]
    public string Destination { get; set; }

    [Range(0.5, double.MaxValue, ErrorMessage = "Trip distance must be positive value.")]
    public double TripDistanceInKm { get; set; }

    public DateTime BookedAt { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Customer Id must be a positive number.")]
    public int CustomerId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "CabSpecificationId must be a positive number.")]
    public int CabSpecificationId { get; set; }
}