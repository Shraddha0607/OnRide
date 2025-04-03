namespace OnRideApp.Models.DomainModel;

public class CabInSpecification
{
    public int Id { get; set; }
    public Cab Cab { get; set; }
    public CabSpecification CabSpecification { get; set; }
}