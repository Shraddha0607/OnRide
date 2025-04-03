namespace OnRideApp.Models.DomainModel;

public class CabDriver
{
    public int Id { get; set; }
    public Driver Driver { get; set; }
    public Cab Cab { get; set; }
}
