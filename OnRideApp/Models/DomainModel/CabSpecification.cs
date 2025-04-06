namespace OnRideApp.Models.DomainModel;

public class CabSpecification
{
    public int Id { get; set; }
    public CabType CabType { get; set; }
    public double FarePrKm { get; set; }

    [StringLength(20, ErrorMessage = "Model length must be upto 20 charactes")]
    public string Model { get; set; }

    public int NumberOfSeats { get; set; }
}