namespace OnRideApp.Models.Dtos.Request;

public class CustomerRequest
{
    [Required]
    [StringLength(50, ErrorMessage = "Name length should be less than 50")]
    public string Name { get; set; }

    [Range(1, 110, ErrorMessage = "Age must be between 1 to 110")]
    public int Age { get; set; }

    [EmailAddress]
    public string EmailId { get; set; }

    [StringLength(100, ErrorMessage = "Address length should be 100")]
    public string Address { get; set; }

    public Gender Gender { get; set; }
}