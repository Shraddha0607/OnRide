using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnRideApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CabSpecifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CabType = table.Column<int>(type: "int", nullable: false),
                    FarePrKm = table.Column<double>(type: "float", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabSpecifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouponCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    percentageDiscount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    PanNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerBookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerBookings_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DriverBookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DriverBookings_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CabLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CabLocations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripBookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PickUp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TripDistanceInKm = table.Column<double>(type: "float", nullable: false),
                    TotalFare = table.Column<double>(type: "float", nullable: false),
                    TripStatus = table.Column<int>(type: "int", nullable: false),
                    BookedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerBookingId = table.Column<int>(type: "int", nullable: true),
                    DriverBookingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripBookings_CustomerBookings_CustomerBookingId",
                        column: x => x.CustomerBookingId,
                        principalTable: "CustomerBookings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TripBookings_DriverBookings_DriverBookingId",
                        column: x => x.DriverBookingId,
                        principalTable: "DriverBookings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cabs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    CabLocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cabs_CabLocations_CabLocationId",
                        column: x => x.CabLocationId,
                        principalTable: "CabLocations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BookingReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripBookingId = table.Column<int>(type: "int", nullable: false),
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingReviews_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingReviews_TripBookings_TripBookingId",
                        column: x => x.TripBookingId,
                        principalTable: "TripBookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CabDrivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    CabId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabDrivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CabDrivers_Cabs_CabId",
                        column: x => x.CabId,
                        principalTable: "Cabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CabDrivers_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CabInSpecification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CabId = table.Column<int>(type: "int", nullable: false),
                    CabSpecificationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabInSpecification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CabInSpecification_CabSpecifications_CabSpecificationId",
                        column: x => x.CabSpecificationId,
                        principalTable: "CabSpecifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CabInSpecification_Cabs_CabId",
                        column: x => x.CabId,
                        principalTable: "Cabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingReviews_ReviewId",
                table: "BookingReviews",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingReviews_TripBookingId",
                table: "BookingReviews",
                column: "TripBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_CabDrivers_CabId",
                table: "CabDrivers",
                column: "CabId");

            migrationBuilder.CreateIndex(
                name: "IX_CabDrivers_DriverId",
                table: "CabDrivers",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_CabInSpecification_CabId",
                table: "CabInSpecification",
                column: "CabId");

            migrationBuilder.CreateIndex(
                name: "IX_CabInSpecification_CabSpecificationId",
                table: "CabInSpecification",
                column: "CabSpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_CabLocations_LocationId",
                table: "CabLocations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Cabs_CabLocationId",
                table: "Cabs",
                column: "CabLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBookings_CustomerId",
                table: "CustomerBookings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverBookings_DriverId",
                table: "DriverBookings",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_TripBookings_CustomerBookingId",
                table: "TripBookings",
                column: "CustomerBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_TripBookings_DriverBookingId",
                table: "TripBookings",
                column: "DriverBookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingReviews");

            migrationBuilder.DropTable(
                name: "CabDrivers");

            migrationBuilder.DropTable(
                name: "CabInSpecification");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "TripBookings");

            migrationBuilder.DropTable(
                name: "CabSpecifications");

            migrationBuilder.DropTable(
                name: "Cabs");

            migrationBuilder.DropTable(
                name: "CustomerBookings");

            migrationBuilder.DropTable(
                name: "DriverBookings");

            migrationBuilder.DropTable(
                name: "CabLocations");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}