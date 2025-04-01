using OnRideApp.Models.DomainModel;
using OnRideApp.Models.Dtos;
using OnRideApp.Repositories;
using OnRideApp.Transformer;

namespace OnRideApp.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository driverRepository;

        public DriverService(IDriverRepository driverRepository)
        {
            this.driverRepository = driverRepository;
        }

        public DriverRequestTransform DriverMapper { get; }

        public async Task<Driver> AddDriverAsync(DriverRequest driverRequest)
        {
            Cab cab = DriverRequestTransform.CabRequestToCab(driverRequest.Cab);
            Driver driver = DriverRequestTransform.DriverRequestToDriver(driverRequest);
            driver.Cab = cab;
            
            var createdDriver = await driverRepository.AddAsync(driver);
            return createdDriver;
        }
    }
}
