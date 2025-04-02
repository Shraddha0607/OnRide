using Microsoft.EntityFrameworkCore;
using OnRideApp.Data;
using OnRideApp.Models.DomainModel;

namespace OnRideApp.Repositories
{
    public class CabRepository : ICabRepository
    {
        private readonly RideDbContext rideDbContext;

        public CabRepository(RideDbContext rideDbContext)
        {
            this.rideDbContext = rideDbContext;
        }

        public Cab getRandomAvailableCab()
        {
            var cab = rideDbContext.Cabs.Include(x => x.Driver).AsSplitQuery().FirstOrDefault(x => x.IsAvailable == true);
            return cab;
        }
    }
}
