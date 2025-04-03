using OnRideApp.Data;
using OnRideApp.Models.DomainModel;
using OnRideApp.Models.Dtos.Request;

namespace OnRideApp.Services
{
    public class ReviewService : IReviewService
    {
        private readonly RideDbContext rideDbContext;
        public ReviewService(RideDbContext rideDbContext)
        {
            this.rideDbContext = rideDbContext;
        }

        public async Task<string> SubmitReview(int tripId, ReviewRequest reviewRequest)
        {
            var transaction = await rideDbContext.Database.BeginTransactionAsync();
            try
            {
                var tripBooking = await rideDbContext.TripBookings.FindAsync(tripId);
                if (tripBooking == null)
                {
                    throw new Exception("Invalid Trip Id!");
                }

                Review review = new Review
                {
                    Rating = reviewRequest.rating,
                    Comment = reviewRequest.comment
                };

                BookingReview bookingReview = new BookingReview
                {
                    TripBooking = tripBooking,
                    Review = review
                };

                await transaction.CreateSavepointAsync("transactionSavepoint");
                await rideDbContext.Reviews.AddAsync(review);
                await rideDbContext.BookingReviews.AddAsync(bookingReview);
                await rideDbContext.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception e)
            {
                await transaction.RollbackToSavepointAsync("transactionSavepoint");
                Console.WriteLine(e);
            }

            return "Thank you for feedback";

        }
    }
}
