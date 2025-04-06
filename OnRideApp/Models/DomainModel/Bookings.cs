using System.ComponentModel.DataAnnotations.Schema;

namespace OnRideApp.Models.DomainModel;

public class Bookings
{
    [Key]
    public int TripBookingId { get; set; }

    [ForeignKey(nameof(TripBookingId))]
    public TripBooking TripBooking { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int DriverId { get; set; }
    public Driver Driver { get; set; }
    public int CabId { get; set; }
    public Cab Cab { get; set; }
}