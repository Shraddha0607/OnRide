using OnRideApp.Models.MyEnums;

namespace OnRideApp.Models.Dtos
{
    public class CabRequest
    {
        public string CabNumber { get; set; }
        public string CarModel { get; set; }
        public Boolean IsAvailable { get; set; }
        public int NumberOfSeats { get; set; }
        public CarTypeEnum CarType { get; set; }
        public double FarePrKm { get; set; }
    }
}
