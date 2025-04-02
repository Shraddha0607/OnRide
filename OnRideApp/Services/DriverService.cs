using OnRideApp.Models.DomainModel;
using OnRideApp.Models.Dtos.Request;
using OnRideApp.Repositories;
using OnRideApp.Transformer;

namespace OnRideApp.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository driverRepository;
        private readonly ICabRepository cabRepository;

        public DriverService(IDriverRepository driverRepository,
                            ICabRepository cabRepository)
        {
            this.driverRepository = driverRepository;
            this.cabRepository = cabRepository;
        }

        public async Task<Driver> AddDriverAsync(DriverRequest driverRequest)
        {
            Cab cab = DriverRequestTransform.CabRequestToCab(driverRequest.Cab);

            // we do need to save this first
            //Cab savedCab = await cabRepository.AddAsync(cab);
            Driver driver = DriverRequestTransform.DriverRequestToDriver(driverRequest);
            driver.Cab = cab;
            
            var createdDriver = await driverRepository.AddAsync(driver);
            return driver;
        }
    }
}
