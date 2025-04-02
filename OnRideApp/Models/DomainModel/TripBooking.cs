using System.ComponentModel.DataAnnotations;
using OnRideApp.Models.MyEnums;

namespace OnRideApp.Models.DomainModel
{
    public class TripBooking
    {
        public int Id { get; set; }
        public Guid BookingId { get; set; }
        public string PickUp { get; set; }
        public string Destination { get; set; }
        public double TripDistanceInKm { get; set; }
        public double TotalFare { get; set; }
        public TripStatus TripStatus { get; set; }
        public DateTime BookedAt  { get; set; }

        public int DriverId { get; set; }  // foreign key reference to driver
        public Driver Driver { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Review Review { get; set; }
    }
}
