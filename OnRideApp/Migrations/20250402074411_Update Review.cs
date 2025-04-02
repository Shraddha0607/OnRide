using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnRideApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reviews_TripBookingId",
                table: "Reviews");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TripBookingId",
                table: "Reviews",
                column: "TripBookingId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reviews_TripBookingId",
                table: "Reviews");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TripBookingId",
                table: "Reviews",
                column: "TripBookingId");
        }
    }
}
