namespace OnRideApp.Services;

public class TrackingService : ITrackingService
{
    private readonly RideDbContext rideDbContext;
    private readonly ILogger logger;

    public TrackingService(RideDbContext rideDbContext,
            ILogger<TrackingService> logger)
    {
        this.rideDbContext = rideDbContext;
        this.logger = logger;
    }

    public async Task<string> AddLocationAsync(int cabId, double latitude, double longitude)
    {
        var transaction = await rideDbContext.Database.BeginTransactionAsync();
        var transactionSavePoint = "UpdateCabLocation";
        try
        {
            Cab? cab = await rideDbContext.Cabs
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == cabId);

            if (cab == null)
            {
                throw new CustomException("Invalid Cab Id");
            }

            var location = await rideDbContext.Locations
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Latitude == latitude && x.Longitude == longitude);

            if (location == null)
            {
                throw new CustomException("Location not found!");
            }

            cab.CabLocationId = location.Id;

            await transaction.CreateSavepointAsync(transactionSavePoint);
            rideDbContext.Update(cab);
            await rideDbContext.SaveChangesAsync();
            await transaction.CommitAsync();
            return "Location updated successfully.";
        }
        catch (Exception ex)
        {
            await transaction.RollbackToSavepointAsync(transactionSavePoint);
            logger.LogError("{} Error  : {}", DateTime.Now, ex.Message);
            logger.LogError(ex.StackTrace);
        }
        return null;
    }

    public async Task<Location> trackCabAsync(int tripId)
    {
        var trip = await rideDbContext.Bookings
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.TripBookingId == tripId);

        if (trip == null)
        {
            throw new CustomException("Trip Id is valid!");
        }

        var cab = await rideDbContext.Cabs
            .AsNoTracking()
            .Include(x => x.Location)
            .FirstOrDefaultAsync(x => x.Id == trip.CabId);

        if (cab == null)
        {
            throw new CustomException("Location not found1");
        }
        return cab.Location;
    }
}