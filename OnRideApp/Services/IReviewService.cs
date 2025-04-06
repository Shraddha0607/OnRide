namespace OnRideApp.Services;

public interface IReviewService
{
    Task<string> SubmitReview(int tripId, ReviewRequest reviewRequest);
}