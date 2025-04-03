﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnRideApp.Data;

#nullable disable

namespace OnRideApp.Migrations
{
    [DbContext(typeof(RideDbContext))]
    [Migration("20250403023529_Added seeds in CabSpecifications")]
    partial class AddedseedsinCabSpecifications
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnRideApp.Models.DomainModel.BookingReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ReviewId")
                        .HasColumnType("int");

                    b.Property<int>("TripBookingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReviewId");

                    b.HasIndex("TripBookingId");

                    b.ToTable("BookingReviews");
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.Cab", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CabLocationId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CabLocationId");

                    b.ToTable("Cabs");
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.CabDriver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CabId")
                        .HasColumnType("int");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CabId");

                    b.HasIndex("DriverId");

                    b.ToTable("CabDrivers");
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.CabInSpecification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CabId")
                        .HasColumnType("int");

                    b.Property<int>("CabSpecificationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CabId");

                    b.HasIndex("CabSpecificationId");

                    b.ToTable("CabInSpecification");
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.CabLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("CabLocations");
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.CabSpecification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CabType")
                        .HasColumnType("int");

                    b.Property<double>("FarePrKm")
                        .HasColumnType("float");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CabSpecifications");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CabType = 0,
                            FarePrKm = 7.5,
                            Model = "Hyundai i10",
                            NumberOfSeats = 4
                        },
                        new
                        {
                            Id = 2,
                            CabType = 0,
                            FarePrKm = 8.0,
                            Model = "Maruti Alto",
                            NumberOfSeats = 4
                        },
                        new
                        {
                            Id = 3,
                            CabType = 1,
                            FarePrKm = 12.0,
                            Model = "Honda Civic",
                            NumberOfSeats = 5
                        },
                        new
                        {
                            Id = 4,
                            CabType = 1,
                            FarePrKm = 10.5,
                            Model = "Toyota Camry",
                            NumberOfSeats = 5
                        },
                        new
                        {
                            Id = 5,
                            CabType = 1,
                            FarePrKm = 13.0,
                            Model = "BMW 3 Series",
                            NumberOfSeats = 5
                        },
                        new
                        {
                            Id = 6,
                            CabType = 2,
                            FarePrKm = 15.0,
                            Model = "Toyota Fortuner",
                            NumberOfSeats = 7
                        },
                        new
                        {
                            Id = 7,
                            CabType = 2,
                            FarePrKm = 16.5,
                            Model = "Ford Endeavour",
                            NumberOfSeats = 7
                        },
                        new
                        {
                            Id = 8,
                            CabType = 2,
                            FarePrKm = 14.0,
                            Model = "Nissan X-Trail",
                            NumberOfSeats = 5
                        },
                        new
                        {
                            Id = 9,
                            CabType = 3,
                            FarePrKm = 11.0,
                            Model = "Honda HR-V",
                            NumberOfSeats = 5
                        },
                        new
                        {
                            Id = 10,
                            CabType = 3,
                            FarePrKm = 10.5,
                            Model = "Hyundai Creta",
                            NumberOfSeats = 5
                        },
                        new
                        {
                            Id = 11,
                            CabType = 3,
                            FarePrKm = 12.5,
                            Model = "Kia Seltos",
                            NumberOfSeats = 5
                        },
                        new
                        {
                            Id = 12,
                            CabType = 1,
                            FarePrKm = 9.5,
                            Model = "Skoda Octavia",
                            NumberOfSeats = 5
                        },
                        new
                        {
                            Id = 13,
                            CabType = 0,
                            FarePrKm = 7.0,
                            Model = "Tata Nano",
                            NumberOfSeats = 4
                        },
                        new
                        {
                            Id = 14,
                            CabType = 2,
                            FarePrKm = 18.0,
                            Model = "Land Rover Discovery",
                            NumberOfSeats = 7
                        },
                        new
                        {
                            Id = 15,
                            CabType = 3,
                            FarePrKm = 11.5,
                            Model = "Mahindra XUV300",
                            NumberOfSeats = 5
                        });
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.Coupon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CouponCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("percentageDiscount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Coupons");
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.CustomerBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerBookings");
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("MobNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PanNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.DriverBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.ToTable("DriverBookings");
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.TripBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BookedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("BookingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("CustomerBookingId")
                        .HasColumnType("int");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DriverBookingId")
                        .HasColumnType("int");

                    b.Property<string>("PickUp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalFare")
                        .HasColumnType("float");

                    b.Property<double>("TripDistanceInKm")
                        .HasColumnType("float");

                    b.Property<int>("TripStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerBookingId");

                    b.HasIndex("DriverBookingId");

                    b.ToTable("TripBookings");
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.BookingReview", b =>
                {
                    b.HasOne("OnRideApp.Models.DomainModel.Review", "Review")
                        .WithMany()
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnRideApp.Models.DomainModel.TripBooking", "TripBooking")
                        .WithMany()
                        .HasForeignKey("TripBookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Review");

                    b.Navigation("TripBooking");
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.Cab", b =>
                {
                    b.HasOne("OnRideApp.Models.DomainModel.CabLocation", null)
                        .WithMany("Cabs")
                        .HasForeignKey("CabLocationId");
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.CabDriver", b =>
                {
                    b.HasOne("OnRideApp.Models.DomainModel.Cab", "Cab")
                        .WithMany()
                        .HasForeignKey("CabId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnRideApp.Models.DomainModel.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cab");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.CabInSpecification", b =>
                {
                    b.HasOne("OnRideApp.Models.DomainModel.Cab", "Cab")
                        .WithMany()
                        .HasForeignKey("CabId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnRideApp.Models.DomainModel.CabSpecification", "CabSpecification")
                        .WithMany()
                        .HasForeignKey("CabSpecificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cab");

                    b.Navigation("CabSpecification");
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.CabLocation", b =>
                {
                    b.HasOne("OnRideApp.Models.DomainModel.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.CustomerBooking", b =>
                {
                    b.HasOne("OnRideApp.Models.DomainModel.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.DriverBooking", b =>
                {
                    b.HasOne("OnRideApp.Models.DomainModel.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.TripBooking", b =>
                {
                    b.HasOne("OnRideApp.Models.DomainModel.CustomerBooking", null)
                        .WithMany("TripBookings")
                        .HasForeignKey("CustomerBookingId");

                    b.HasOne("OnRideApp.Models.DomainModel.DriverBooking", null)
                        .WithMany("DriverTripBookingList")
                        .HasForeignKey("DriverBookingId");
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.CabLocation", b =>
                {
                    b.Navigation("Cabs");
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.CustomerBooking", b =>
                {
                    b.Navigation("TripBookings");
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.DriverBooking", b =>
                {
                    b.Navigation("DriverTripBookingList");
                });
#pragma warning restore 612, 618
        }
    }
}
