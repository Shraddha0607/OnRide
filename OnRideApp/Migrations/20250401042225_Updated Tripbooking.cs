using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnRideApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTripbooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "TripBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TripBookings_DriverId",
                table: "TripBookings",
                column: "DriverId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TripBookings_Drivers_DriverId",
                table: "TripBookings",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripBookings_Drivers_DriverId",
                table: "TripBookings");

            migrationBuilder.DropIndex(
                name: "IX_TripBookings_DriverId",
                table: "TripBookings");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "TripBookings");
        }
    }
}
