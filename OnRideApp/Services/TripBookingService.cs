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

        try
        {
            TripBooking tripBooking = TripBookingTransformer.TripRequestToTripBooking(tripBookingRequest);

            var availableCab = await rideDbContext.CabInSpecification
                .AsNoTracking()
                .Include(x => x.Cab)
                .Include(x => x.CabSpecification)
                .Select(x => new
                {
                    CabId = x.Cab.Id,
                    IsAvailable = x.Cab.IsAvailable,
                    CabSpecificationId = x.CabSpecification.Id,
                    FarePrKm = x.CabSpecification.FarePrKm
                })
                .FirstOrDefaultAsync(x => x.CabSpecificationId == tripBookingRequest.CabSpecificationId && x.IsAvailable);

            if (availableCab == null)
            {
                throw new CustomException("No cab available!");
            }

            tripBooking.TotalFare = tripBookingRequest.TripDistanceInKm * availableCab.FarePrKm;

            await transaction.CreateSavepointAsync(transactionSavePoint);
            await rideDbContext.TripBookings.AddAsync(tripBooking);
            await rideDbContext.SaveChangesAsync();

            var driverId = await rideDbContext.CabDrivers
                .AsNoTracking()
                .Include(x => x.Driver)
                .Include(x => x.Cab)
                .Select(x => new
                {
                    DriverId = x.Driver.Id,
                    CabId = x.Cab.Id
                })
                .FirstOrDefaultAsync(x => x.CabId == availableCab.CabId);

            if (driverId == null)
            {
                throw new CustomException("Driver not found!");
            }

            Bookings bookings = new Bookings
            {
                TripBookingId = tripBooking.Id,
                CustomerId = tripBookingRequest.CustomerId,
                DriverId = driverId.DriverId,
                CabId = availableCab.CabId
            };

            await rideDbContext.Bookings.AddAsync(bookings);
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