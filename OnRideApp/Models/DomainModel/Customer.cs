using OnRideApp.Models.MyEnums;

namespace OnRideApp.Models.DomainModel
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }

        public ICollection<TripBooking> CustomerTripBookingList { get; set; }
    }
}
