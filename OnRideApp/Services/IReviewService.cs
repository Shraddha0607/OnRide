using OnRideApp.Models.DomainModel;
using OnRideApp.Models.Dtos.Request;

namespace OnRideApp.Services
{
    public interface IReviewService
    {
        Task<string> SubmitReview(int tripId, ReviewRequest reviewRequest);
    }
}
