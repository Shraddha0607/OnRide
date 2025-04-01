using Microsoft.EntityFrameworkCore;
using OnRideApp.Models.DomainModel;

namespace OnRideApp.Data
{
    public class RideDbContext : DbContext
    {
        public RideDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Cab> Cabs { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<TripBooking> TripBookings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Coupon> Coupons { get; set; }

    }
}
