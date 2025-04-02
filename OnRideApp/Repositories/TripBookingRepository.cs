using Microsoft.EntityFrameworkCore;
using OnRideApp.Data;
using OnRideApp.Models.DomainModel;

namespace OnRideApp.Repositories
{
    public class TripBookingRepository : ITripBookingRepository
    {
        private readonly RideDbContext rideDbContext;

        public TripBookingRepository(RideDbContext rideDbContext)
        {
            this.rideDbContext = rideDbContext;
        }

        public async Task<TripBooking> AddAsync(TripBooking tripBooking)
        {
            await rideDbContext.AddAsync(tripBooking);
            await rideDbContext.SaveChangesAsync();
            return tripBooking;
        }

        public async Task<TripBooking> GetByIdAsync(int id)
        {
            Console.WriteLine("repo");
            return await rideDbContext.TripBookings.Include(x =>x.Review).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
