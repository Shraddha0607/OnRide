using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnRideApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedTripBookinginreview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingReviews");

            migrationBuilder.AddColumn<int>(
                name: "TripBookingId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TripBookingId",
                table: "Reviews",
                column: "TripBookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_TripBookings_TripBookingId",
                table: "Reviews",
                column: "TripBookingId",
                principalTable: "TripBookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_TripBookings_TripBookingId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_TripBookingId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "TripBookingId",
                table: "Reviews");

            migrationBuilder.CreateTable(
                name: "BookingReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewId = table.Column<int>(type: "int", nullable: false),
                    TripBookingId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_BookingReviews_ReviewId",
                table: "BookingReviews",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingReviews_TripBookingId",
                table: "BookingReviews",
                column: "TripBookingId");
        }
    }
}