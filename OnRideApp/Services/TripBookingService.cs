using Microsoft.EntityFrameworkCore;
using OnRideApp.Data;
using OnRideApp.Models.DomainModel;
using OnRideApp.Models.Dtos.Request;
using OnRideApp.Transformer;

namespace OnRideApp.Services;

public class TripBookingService : ITripBookingService
{
    private readonly RideDbContext rideDbContext;

    public TripBookingService(RideDbContext rideDbContext)
    {
        this.rideDbContext = rideDbContext;
    }


    public async Task<TripBooking> AddTripBookingAsync(TripBookingRequest tripBookingRequest)
    {
        Customer customer = await rideDbContext.Customers.FirstAsync(x => x.EmailId == tripBookingRequest.CustomerEmailId);
        if (customer == null)
        {
            throw new Exception("Customer Id is not valid!");
        }

        try
        {

            TripBooking tripBooking = TripBookingTransformer.TripRequestToTripBooking(tripBookingRequest);

            var availableCab = await rideDbContext.CabInSpecification
                       .Include(x => x.Cab)
                       .Include(x => x.CabSpecification)
                       .Where(x => x.Id == tripBookingRequest.CabSpecificationId)
                       .Where(x => x.Cab.IsAvailable)
                       .FirstAsync();

            if (availableCab == null)
            {
            }

            Cab? cab = availableCab.Cab;

            tripBooking.TotalFare = tripBookingRequest.TripDistanceInKm * availableCab.CabSpecification.FarePrKm;

            await rideDbContext.TripBookings.AddAsync(tripBooking);
            await rideDbContext.SaveChangesAsync();

            CustomerBooking customerBooking = new CustomerBooking
            {
                TripBookings = new List<TripBooking>(),
                Customer = customer
            };
            customerBooking.TripBookings.Add(tripBooking);

            var cabDriver = await rideDbContext.CabDrivers
                                .Include(x => x.Driver)
                                .FirstAsync(x => x.Cab == cab);

            DriverBooking driverBooking = new DriverBooking
            {
                DriverTripBookingList = new List<TripBooking>(),
                Driver = cabDriver.Driver
            };
            driverBooking.DriverTripBookingList.Add(tripBooking);

            await rideDbContext.DriverBookings.AddAsync(driverBooking);
            await rideDbContext.CustomerBookings.AddAsync(customerBooking);
            await rideDbContext.SaveChangesAsync();

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        return null;

    }
}
