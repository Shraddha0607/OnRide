using OnRideApp.Models.MyEnums;

namespace OnRideApp.Models.DomainModel
{
    public class Cab
    {
        public int Id { get; set; }
        public string CabNumber { get; set; }
        public string CarModel { get; set; }
        public Boolean IsAvailable { get; set; }
        public int NumberOfSeats { get; set; }
        public CarTypeEnum CarType { get; set; }
        public double FarePrKm { get; set; }
        public Driver Driver { get; set; }
    }
}
