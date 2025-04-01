using OnRideApp.Models.DomainModel;

namespace OnRideApp.Models.Dtos
{
    public class DriverRequest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string PanNumber { get; set; }
        public string MobNumber { get; set; }
        public CabRequest Cab { get; set; }
    }
}
