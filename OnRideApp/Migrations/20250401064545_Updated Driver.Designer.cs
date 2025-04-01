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
    [Migration("20250401064545_Updated Driver")]
    partial class UpdatedDriver
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnRideApp.Models.DomainModel.Cab", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CabNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarType")
                        .HasColumnType("int");

                    b.Property<double>("FarePrKm")
                        .HasColumnType("float");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Cabs");
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

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("CabId")
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

                    b.HasIndex("CabId")
                        .IsUnique();

                    b.ToTable("Drivers");
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

            modelBuilder.Entity("OnRideApp.Models.DomainModel.TripBooking", b =>
                {
                    b.Property<Guid>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BookedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<string>("PickUp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalFare")
                        .HasColumnType("float");

                    b.Property<double>("TripDistancePrKm")
                        .HasColumnType("float");

                    b.Property<int>("TripStatus")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DriverId")
                        .IsUnique();

                    b.ToTable("TripBookings");
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.Cab", b =>
                {
                    b.HasOne("OnRideApp.Models.DomainModel.Location", null)
                        .WithMany("Cabs")
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.Driver", b =>
                {
                    b.HasOne("OnRideApp.Models.DomainModel.Cab", "Cab")
                        .WithOne("Driver")
                        .HasForeignKey("OnRideApp.Models.DomainModel.Driver", "CabId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cab");
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.TripBooking", b =>
                {
                    b.HasOne("OnRideApp.Models.DomainModel.Customer", "Customer")
                        .WithMany("CustomerTripBookingList")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnRideApp.Models.DomainModel.Driver", "Driver")
                        .WithOne("TripBooking")
                        .HasForeignKey("OnRideApp.Models.DomainModel.TripBooking", "DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.Cab", b =>
                {
                    b.Navigation("Driver")
                        .IsRequired();
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.Customer", b =>
                {
                    b.Navigation("CustomerTripBookingList");
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.Driver", b =>
                {
                    b.Navigation("TripBooking")
                        .IsRequired();
                });

            modelBuilder.Entity("OnRideApp.Models.DomainModel.Location", b =>
                {
                    b.Navigation("Cabs");
                });
#pragma warning restore 612, 618
        }
    }
}
