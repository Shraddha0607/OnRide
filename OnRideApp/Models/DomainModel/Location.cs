namespace OnRideApp.Models.DomainModel
{
    public class Location
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ICollection<Cab> Cabs { get; set; }
    }
}
