namespace OnRideApp.Models.DomainModel;

public class CabDriver
{
    [Range(1, int.MaxValue, ErrorMessage = "Id must be greater than 0!")]
    public int Id { get; set; }

    public Driver Driver { get; set; }
    public Cab Cab { get; set; }
}