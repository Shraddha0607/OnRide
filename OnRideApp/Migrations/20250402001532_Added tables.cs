using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnRideApp.Migrations
{
    /// <inheritdoc />
    public partial class Addedtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TripBookings_DriverId",
                table: "TripBookings");

            migrationBuilder.RenameColumn(
                name: "TripDistancePrKm",
                table: "TripBookings",
                newName: "TripDistanceInKm");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TripBookingBookingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_TripBookings_TripBookingBookingId",
                        column: x => x.TripBookingBookingId,
                        principalTable: "TripBookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TripBookings_DriverId",
                table: "TripBookings",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TripBookingBookingId",
                table: "Reviews",
                column: "TripBookingBookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_TripBookings_DriverId",
                table: "TripBookings");

            migrationBuilder.RenameColumn(
                name: "TripDistanceInKm",
                table: "TripBookings",
                newName: "TripDistancePrKm");

            migrationBuilder.CreateIndex(
                name: "IX_TripBookings_DriverId",
                table: "TripBookings",
                column: "DriverId",
                unique: true);
        }
    }
}
