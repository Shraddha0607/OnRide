using OnRideApp.Data;
using OnRideApp.Models.DomainModel;
using OnRideApp.Models.Dtos.Request;
using OnRideApp.Transformer;

namespace OnRideApp.Services;

public class DriverService : IDriverService
{
    private readonly RideDbContext rideDbContext;

    public DriverService(RideDbContext rideDbContext)
    {
        this.rideDbContext = rideDbContext;
    }

    public async Task<Driver> AddDriverAsync(DriverRequest driverRequest)
    {
        var transaction = await rideDbContext.Database.BeginTransactionAsync();
        var transactionSavepoint = "AddDriverData";
        try
        {
            CabSpecification? cabSpecification = await rideDbContext.CabSpecifications.FindAsync(driverRequest.Cab.CabSpecificationId);
            if (cabSpecification == null)
            {
                throw new Exception("Cab Specification not found");
            }

            Cab cab = DriverRequestTransform.CabRequestToCab(driverRequest.Cab);
            Driver driver = DriverRequestTransform.DriverRequestToDriver(driverRequest);

            CabInSpecification cabInSpecification = new CabInSpecification()
            {
                Cab = cab,
                CabSpecification = cabSpecification
            };

            CabDriver cabDriver = new CabDriver()
            {
                Cab = cab,
                Driver = driver
            };

            await transaction.CreateSavepointAsync(transactionSavepoint);
            await rideDbContext.Cabs.AddAsync(cab);
            await rideDbContext.Drivers.AddAsync(driver);
            await rideDbContext.CabDrivers.AddAsync(cabDriver);
            await rideDbContext.CabInSpecification.AddAsync(cabInSpecification);
            await rideDbContext.SaveChangesAsync();

            // if succedde then commt
            await transaction.CommitAsync();
            return driver;
        }
        catch (Exception ex)
        {
            await transaction.RollbackToSavepointAsync(transactionSavepoint);
            Console.WriteLine(ex);
        }

        return default;

    }


}
