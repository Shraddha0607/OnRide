namespace OnRideApp.Models.Dtos.Request;

public class CabRequest
{
    [MaxLength(10, ErrorMessage = "Invalid cab number!")]
    public string CabNumber { get; set; }

    public bool IsAvailable { get; set; }
    public int CabSpecificationId { get; set; }
}