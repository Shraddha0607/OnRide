using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnRideApp.Data;
using OnRideApp.Models.DomainModel;

namespace OnRideApp.Services;

public class TrackingService : ITrackingService
{
    private readonly RideDbContext rideDbContext;

    public TrackingService(RideDbContext rideDbContext)
    {
        this.rideDbContext = rideDbContext;
    }

    public async Task<string> AddLocationAsync(int cabId, double latitude, double longitude)
    {
        var transaction = await rideDbContext.Database.BeginTransactionAsync();
        var transactionSavePoint = "UpdateCabData";
        try
        {
            Cab? cab = await rideDbContext.Cabs.FindAsync(cabId);
            if (cab == null)
            {
                throw new Exception("Invalid Cab Id");
            }

            Location location = new Location
            {
                Latitude = latitude,
                Longitude = longitude
            };

            CabLocation cabLocation = new CabLocation
            {
                Cabs = new List<Cab>(),
                Location = location
            };
            cabLocation.Cabs.Add(cab);

            await transaction.CreateSavepointAsync("transactionSavePoint");
            await rideDbContext.Locations.AddAsync(location);
            await rideDbContext.CabLocations.AddAsync(cabLocation);
            await rideDbContext.SaveChangesAsync();
            await transaction.CommitAsync();
            return "Location updated successfully.";
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            Console.WriteLine(ex);
        }

        return null;


    }

    public async Task<Location> trackCabAsync(int tripId)
    {
        var trip = await rideDbContext.TripBookings.FindAsync(tripId);
        if (trip == null)
        {
            throw new Exception("Trip Id is valid!");
        }
        var tripDetails = await rideDbContext.DriverBookings
                            .Include(x => x.Driver)
                            .Where(x => x.DriverTripBookingList.Contains(trip))
                            .FirstAsync();

        var cabDriver = await rideDbContext.CabDrivers
                           .Include(x => x.Cab)
                           .Where(x => x.Driver.Id == tripDetails.Driver.Id)
                           .FirstAsync();

        var location = await rideDbContext.CabLocations
                            .Include(x => x.Location)
                            .Where(x => x.Cabs.Contains(cabDriver.Cab))
                            .FirstAsync();


        return location.Location;
    }
}
