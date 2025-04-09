using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnRideApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedBookingstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripBookings_CustomerBookings_CustomerBookingId",
                table: "TripBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_TripBookings_DriverBookings_DriverBookingId",
                table: "TripBookings");

            migrationBuilder.DropTable(
                name: "CustomerBookings");

            migrationBuilder.DropTable(
                name: "DriverBookings");

            migrationBuilder.DropIndex(
                name: "IX_TripBookings_CustomerBookingId",
                table: "TripBookings");

            migrationBuilder.DropIndex(
                name: "IX_TripBookings_DriverBookingId",
                table: "TripBookings");

            migrationBuilder.DropColumn(
                name: "CustomerBookingId",
                table: "TripBookings");

            migrationBuilder.DropColumn(
                name: "DriverBookingId",
                table: "TripBookings");

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    TripBookingId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.TripBookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_TripBookings_TripBookingId",
                        column: x => x.TripBookingId,
                        principalTable: "TripBookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CustomerId",
                table: "Bookings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_DriverId",
                table: "Bookings",
                column: "DriverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "CustomerBookingId",
                table: "TripBookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DriverBookingId",
                table: "TripBookings",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_TripBookings_CustomerBookingId",
                table: "TripBookings",
                column: "CustomerBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_TripBookings_DriverBookingId",
                table: "TripBookings",
                column: "DriverBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBookings_CustomerId",
                table: "CustomerBookings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverBookings_DriverId",
                table: "DriverBookings",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_TripBookings_CustomerBookings_CustomerBookingId",
                table: "TripBookings",
                column: "CustomerBookingId",
                principalTable: "CustomerBookings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TripBookings_DriverBookings_DriverBookingId",
                table: "TripBookings",
                column: "DriverBookingId",
                principalTable: "DriverBookings",
                principalColumn: "Id");
        }
    }
}