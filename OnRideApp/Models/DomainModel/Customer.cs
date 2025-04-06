namespace OnRideApp.Models.DomainModel;

public class Customer
{
    public int Id { get; set; }

    [StringLength(50, ErrorMessage = "The name must be upto 100 charactes!")]
    public string Name { get; set; }

    [Range(1, 110, ErrorMessage = "Age must be between 1 and 110")]
    public int Age { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    public string EmailId { get; set; }

    [StringLength(200, ErrorMessage = "Address length must be upto 200.")]
    public string Address { get; set; }

    public Gender Gender { get; set; }
}