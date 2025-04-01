using OnRideApp.Models.DomainModel;
using OnRideApp.Models.Dtos;

namespace OnRideApp.Services
{
    public interface IDriverService
    {
        Task<Driver> AddDriverAsync(DriverRequest driverRequest);
    }
}
