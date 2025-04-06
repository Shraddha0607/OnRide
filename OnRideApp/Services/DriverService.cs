namespace OnRideApp.Services;

public class DriverService : IDriverService
{
    private readonly RideDbContext rideDbContext;
    private readonly ILogger logger;

    public DriverService(RideDbContext rideDbContext,
            ILogger<DriverService> logger)
    {
        this.rideDbContext = rideDbContext;
        this.logger = logger;
    }

    public async Task<Driver> AddDriverAsync(DriverRequest driverRequest)
    {
        var existingRecord = await rideDbContext.CabDrivers
            .AsNoTracking()
            .Include(x => x.Cab)
            .Include(x => x.Driver)
            .Select(x => new
            {
                x.Cab.Number,
                x.Driver.PanNumber,
                x.Driver.MobNumber
            })
            .FirstOrDefaultAsync(x => x.Number == driverRequest.Cab.CabNumber
                || x.PanNumber == driverRequest.PanNumber
                || x.MobNumber == driverRequest.MobNumber);

        if (existingRecord != null)
        {
            if (existingRecord.MobNumber == driverRequest.MobNumber)
            {
                throw new CustomException("Mobile number already exist!");
            }
            if (String.Equals(existingRecord.PanNumber, driverRequest.PanNumber, StringComparison.OrdinalIgnoreCase))
            {
                throw new CustomException("Pan number already exist!");
            }
            throw new CustomException("Cab number already exist!");
        }

        var cabSpecification = await rideDbContext.CabSpecifications
            .AsNoTracking()
            .AnyAsync(x => x.Id == driverRequest.Cab.CabSpecificationId);

        if (!cabSpecification)
        {
            throw new CustomException("Cab Specification not found");
        }

        var transaction = await rideDbContext.Database.BeginTransactionAsync();
        var transactionSavepoint = "AddDriverData";

        try
        {
            Cab cab = DriverRequestTransform.CabRequestToCab(driverRequest.Cab);
            Driver driver = DriverRequestTransform.DriverRequestToDriver(driverRequest);

            CabDriver cabDriver = new CabDriver()
            {
                Cab = cab,
                Driver = driver
            };

            await transaction.CreateSavepointAsync(transactionSavepoint);
            await rideDbContext.Cabs.AddAsync(cab);
            await rideDbContext.Drivers.AddAsync(driver);
            await rideDbContext.CabDrivers.AddAsync(cabDriver);
            await rideDbContext.SaveChangesAsync();

            await transaction.CommitAsync();
            return driver;
        }
        catch (Exception ex)
        {
            await transaction.RollbackToSavepointAsync(transactionSavepoint);
            logger.LogError("{} Error  : {}", DateTime.Now, ex.Message);
            logger.LogError(ex.StackTrace);
            return default;
        }
    }
}