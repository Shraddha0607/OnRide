using Microsoft.EntityFrameworkCore;
using OnRideApp.Models.DomainModel;
using OnRideApp.Models.MyEnums;

namespace OnRideApp.Data;

public class RideDbContext : DbContext
{
    public RideDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<BookingReview> BookingReviews { get; set; }
    public DbSet<Cab> Cabs { get; set; }
    public DbSet<CabDriver> CabDrivers { get; set; }
    public DbSet<CabInSpecification> CabInSpecification { get; set; }
    public DbSet<CabLocation> CabLocations { get; set; }
    public DbSet<CabSpecification> CabSpecifications { get; set; }
    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerBooking> CustomerBookings { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<DriverBooking> DriverBookings { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<TripBooking> TripBookings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Seed data for CabSpecifications
        modelBuilder.Entity<CabSpecification>().HasData(
            new CabSpecification { Id = 1, CabType = CabType.MINI, FarePrKm = 7.5, Model = "Hyundai i10", NumberOfSeats = 4 },
            new CabSpecification { Id = 2, CabType = CabType.MINI, FarePrKm = 8.0, Model = "Maruti Alto", NumberOfSeats = 4 },
            new CabSpecification { Id = 3, CabType = CabType.SEDAN, FarePrKm = 12.0, Model = "Honda Civic", NumberOfSeats = 5 },
            new CabSpecification { Id = 4, CabType = CabType.SEDAN, FarePrKm = 10.5, Model = "Toyota Camry", NumberOfSeats = 5 },
            new CabSpecification { Id = 5, CabType = CabType.SEDAN, FarePrKm = 13.0, Model = "BMW 3 Series", NumberOfSeats = 5 },
            new CabSpecification { Id = 6, CabType = CabType.SUV, FarePrKm = 15.0, Model = "Toyota Fortuner", NumberOfSeats = 7 },
            new CabSpecification { Id = 7, CabType = CabType.SUV, FarePrKm = 16.5, Model = "Ford Endeavour", NumberOfSeats = 7 },
            new CabSpecification { Id = 8, CabType = CabType.SUV, FarePrKm = 14.0, Model = "Nissan X-Trail", NumberOfSeats = 5 },
            new CabSpecification { Id = 9, CabType = CabType.COMPACT_SUV, FarePrKm = 11.0, Model = "Honda HR-V", NumberOfSeats = 5 },
            new CabSpecification { Id = 10, CabType = CabType.COMPACT_SUV, FarePrKm = 10.5, Model = "Hyundai Creta", NumberOfSeats = 5 },
            new CabSpecification { Id = 11, CabType = CabType.COMPACT_SUV, FarePrKm = 12.5, Model = "Kia Seltos", NumberOfSeats = 5 },
            new CabSpecification { Id = 12, CabType = CabType.SEDAN, FarePrKm = 9.5, Model = "Skoda Octavia", NumberOfSeats = 5 },
            new CabSpecification { Id = 13, CabType = CabType.MINI, FarePrKm = 7.0, Model = "Tata Nano", NumberOfSeats = 4 },
            new CabSpecification { Id = 14, CabType = CabType.SUV, FarePrKm = 18.0, Model = "Land Rover Discovery", NumberOfSeats = 7 },
            new CabSpecification { Id = 15, CabType = CabType.COMPACT_SUV, FarePrKm = 11.5, Model = "Mahindra XUV300", NumberOfSeats = 5 }
        );

    }


}
