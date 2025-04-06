namespace OnRideApp.Services;

public interface ITrackingService
{
    Task<string> AddLocationAsync(int driverId, double latitude, double longitude);

    Task<Location> trackCabAsync(int tripId);
}