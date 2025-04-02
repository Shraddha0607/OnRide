using OnRideApp.Data;
using OnRideApp.Models.DomainModel;
using OnRideApp.Models.Dtos.Request;
using OnRideApp.Repositories;

namespace OnRideApp.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository reviewRepository;
        private readonly ITripBookingRepository tripBookingRepository;
        public ReviewService(IReviewRepository reviewRepository,
            ITripBookingRepository tripBookingRepository)
        {
            this.reviewRepository = reviewRepository;
            this.tripBookingRepository = tripBookingRepository;
        }

        public async Task<string> SubmitReview(int tripId, ReviewRequest reviewRequest)
        {
            Console.WriteLine("PRint");
            try
            {
                var tripBooking = await tripBookingRepository.GetByIdAsync(tripId);

                Review review = new Review
                {
                    Rating = reviewRequest.rating,
                    Comment = reviewRequest.comment,
                    TripBooking = tripBooking
                };

                if (tripBooking.Review != null)
                {
                    await reviewRepository.DeleteAsync(tripBooking.Review);
                }
                await reviewRepository.AddAsync(review);
                tripBooking.Review = review;
                tripBookingRepository.AddAsync(tripBooking);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e);
                
            }

            return "Thank you for feedback";

        }
    }
}
