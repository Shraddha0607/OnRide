namespace OnRideApp.Models.DomainModel;

public class CabLocation
{
    public int Id { get; set; }
    public Location Location { get; set; }
    public ICollection<Cab> Cabs { get; set; }
}