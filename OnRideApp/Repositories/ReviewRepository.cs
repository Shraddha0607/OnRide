using OnRideApp.Data;
using OnRideApp.Models.DomainModel;

namespace OnRideApp.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly RideDbContext rideDbContext;
        public ReviewRepository(RideDbContext rideDbContext) {
            this.rideDbContext = rideDbContext;
        }
        public async Task<Review> AddAsync(Review review)
        {
            Console.WriteLine("review");
            await rideDbContext.Reviews.AddAsync(review);
            Console.WriteLine("2revi");
            await rideDbContext.SaveChangesAsync();
            return review;
        }

        public async Task<Review> DeleteAsync(Review review)
        {
            rideDbContext.Remove(review);
            await rideDbContext.SaveChangesAsync();
            return review;
        }
    }
}
