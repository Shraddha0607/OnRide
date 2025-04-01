using OnRideApp.Data;
using OnRideApp.Models.DomainModel;

namespace OnRideApp.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        private readonly RideDbContext rideDbContext;

        public DriverRepository(RideDbContext rideDbContext)
        {
            this.rideDbContext = rideDbContext;
        }

        public async Task<Driver> AddAsync(Driver driver)
        {
            await rideDbContext.AddAsync(driver);
            await rideDbContext.SaveChangesAsync();
            return driver;
        }
    }
}
