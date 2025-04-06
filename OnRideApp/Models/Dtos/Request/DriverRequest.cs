namespace OnRideApp.Models.Dtos.Request;

public class DriverRequest
{
    [StringLength(50, ErrorMessage = "Driver name must be upto 50 characters.")]
    public string Name { get; set; }

    [Range(18, 60, ErrorMessage = "Age must be between 18 to 60.")]
    public int Age { get; set; }

    [RegularExpression(RegexPatterns.PanNumber, ErrorMessage = "Invalid PAN Number format!")]
    public string PanNumber { get; set; }

    [Phone]
    public string MobNumber { get; set; }

    public CabRequest Cab { get; set; }
}