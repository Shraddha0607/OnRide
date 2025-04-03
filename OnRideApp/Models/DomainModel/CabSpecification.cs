using OnRideApp.Models.MyEnums;
namespace OnRideApp.Models.DomainModel;

public class CabSpecification
{
    public int Id { get; set; }
    public CabType CabType { get; set; }
    public double FarePrKm { get; set; }
    public string Model { get; set; }
    public int NumberOfSeats { get; set; }
}
