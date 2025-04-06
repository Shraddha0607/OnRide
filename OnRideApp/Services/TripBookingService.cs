namespace OnRideApp.Services;

public class TripBookingService : ITripBookingService
{
    private readonly RideDbContext rideDbContext;
    private readonly ILogger logger;

    public TripBookingService(RideDbContext rideDbContext,
            ILogger<TripBookingService> logger)
    {
        this.rideDbContext = rideDbContext;
        this.logger = logger;
    }

    public async Task<TripBooking> AddTripBookingAsync(TripBookingRequest tripBookingRequest)
    {
        var transaction = await rideDbContext.Database.BeginTransactionAsync();
        var transactionSavePoint = "AddNewTrip";

        var isValidCustomer = await rideDbContext.Customers
            .AsNoTracking()
            .AnyAsync(x => x.Id == tripBookingRequest.CustomerId);

        if (!isValidCustomer)
        {
            throw new Exception("Customer Id is not valid!");
        }

        var availableCab = await rideDbContext.CabDrivers
            .AsNoTracking()
            .Include(x => x.Cab)
            .Include(x => x.Driver)
            .Select(x => new
            {
                CabId = x.Cab.Id,
                IsAvailable = x.Cab.IsAvailable,
                CabSpecificationId = x.Cab.CabSpecificationId,
                FarePrKm = x.Cab.CabSpecification.FarePrKm,
                DriverId = x.Driver.Id
            })
            .FirstOrDefaultAsync(x => x.CabSpecificationId == tripBookingRequest.CabSpecificationId && x.IsAvailable);

        if (availableCab == null)
        {
            throw new CustomException("No cab available!");
        }

        try
        {
            TripBooking tripBooking = TripBookingTransformer.TripRequestToTripBooking(tripBookingRequest);

            tripBooking.TotalFare = tripBookingRequest.TripDistanceInKm * availableCab.FarePrKm;
            tripBooking.CabId = availableCab.CabId;
            tripBooking.DriverId = availableCab.DriverId;
            tripBooking.CustomerId = tripBookingRequest.CustomerId;

            await transaction.CreateSavepointAsync(transactionSavePoint);
            await rideDbContext.TripBookings.AddAsync(tripBooking);

            await rideDbContext.Cabs
                .Where(x => x.Id == availableCab.CabId)
                .ExecuteUpdateAsync(x => x.SetProperty(x => x.IsAvailable, false));

            await rideDbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await transaction.RollbackToSavepointAsync(transactionSavePoint);
            logger.LogError("{} Error  : {}", DateTime.Now, ex.Message);
            logger.LogError(ex.StackTrace);
        }
        return null;
    }
}