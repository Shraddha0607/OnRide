namespace OnRideApp.Models.Dtos.Response;

public class DriverReviewResponse
{
    public ICollection<Review> Reviews { get; set; }
    public double AverageRating { get; set; }
}