namespace OnRideApp.Services;

public interface IDriverService
{
    Task<Driver> AddDriverAsync(DriverRequest driverRequest);
}