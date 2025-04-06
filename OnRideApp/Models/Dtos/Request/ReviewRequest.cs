namespace OnRideApp.Models.Dtos.Request;

public class ReviewRequest
{
    [Range(1, 5, ErrorMessage = "Rating must be between 1 to 5")]
    public int rating { get; set; }

    [StringLength(500, ErrorMessage = "Comment must be upto 500 characters!")]
    public string comment { get; set; }
}