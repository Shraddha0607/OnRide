namespace OnRideApp.Models.DomainModel;

public class Cab
{
    public int Id { get; set; }

    [Required]
    [StringLength(10, ErrorMessage = "You are allowed to add only 10 characters!")]
    public string Number { get; set; }

    public Boolean IsAvailable { get; set; }

    [DefaultValue(1)]
    public int? CabLocationId { get; set; }

    [ForeignKey(nameof(CabLocationId))]
    public Location? Location { get; set; }

    public int CabSpecificationId { get; set; }
    public CabSpecification CabSpecification { get; set; }
}