using System.ComponentModel.DataAnnotations;

namespace OnRideApp.Models.DomainModel;

public class Cab
{
    public int Id { get; set; }
    [Required]
    [StringLength(10, ErrorMessage = "You are allowed to add only 10 characters!")]
    public string Number { get; set; }
    public Boolean IsAvailable { get; set; }
    
}
