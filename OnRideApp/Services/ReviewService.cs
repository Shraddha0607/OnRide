namespace OnRideApp.Services;

public class ReviewService : IReviewService
{
    private readonly RideDbContext rideDbContext;
    private readonly ILogger logger;

    public ReviewService(RideDbContext rideDbContext,
            ILogger<ReviewService> logger)
    {
        this.rideDbContext = rideDbContext;
        this.logger = logger;
    }

    public async Task<string> SubmitReview(int tripId, ReviewRequest reviewRequest)
    {
        var transaction = await rideDbContext.Database.BeginTransactionAsync();
        var transactionSavepoint = "SubmitReview";
        try
        {
            var isValidTripId = await rideDbContext.TripBookings
                .AsNoTracking()
                .AnyAsync(x => x.Id == tripId);

            if (!isValidTripId)
            {
                throw new CustomException("Invalid Trip Id!");
            }

            Review review = new Review
            {
                Rating = reviewRequest.rating,
                Comment = reviewRequest.comment,
                TripBookingId = tripId
            };

            await transaction.CreateSavepointAsync(transactionSavepoint);
            await rideDbContext.Reviews.AddAsync(review);
            await rideDbContext.SaveChangesAsync();
            await transaction.CommitAsync();

            return "Thank you for feedback";
        }
        catch (Exception ex)
        {
            await transaction.RollbackToSavepointAsync(transactionSavepoint);
            logger.LogError("{} Error  :  {}", DateTime.Now, ex.Message);
            logger.LogError(ex.StackTrace);
            return null;
        }

    }
}