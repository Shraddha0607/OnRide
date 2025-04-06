namespace OnRideApp.Models.Dtos.Request
{
    public class LocationRequest
    {
        [Range(1, 2000, ErrorMessage = "Value must be between 1 to 2000")]
        public int CabId { get; set; }

        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 to 90")]
        public double Latitude { get; set; }

        [Range(-180, 180, ErrorMessage = "Longitude must be between -180 to 180")]
        public double Longitude { get; set; }
    }
}