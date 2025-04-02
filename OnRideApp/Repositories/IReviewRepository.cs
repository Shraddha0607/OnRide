using OnRideApp.Models.DomainModel;

namespace OnRideApp.Repositories
{
    public interface IReviewRepository
    {
        Task<Review> AddAsync(Review review);
        Task<Review> DeleteAsync(Review review);
    }
}
