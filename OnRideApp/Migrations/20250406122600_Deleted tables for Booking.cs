using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnRideApp.Migrations
{
    /// <inheritdoc />
    public partial class DeletedtablesforBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "CabInSpecification");

            migrationBuilder.AddColumn<int>(
                name: "CabId",
                table: "TripBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "TripBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "TripBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CabSpecificationId",
                table: "Cabs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TripBookings_CabId",
                table: "TripBookings",
                column: "CabId");

            migrationBuilder.CreateIndex(
                name: "IX_TripBookings_CustomerId",
                table: "TripBookings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TripBookings_DriverId",
                table: "TripBookings",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Cabs_CabSpecificationId",
                table: "Cabs",
                column: "CabSpecificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cabs_CabSpecifications_CabSpecificationId",
                table: "Cabs",
                column: "CabSpecificationId",
                principalTable: "CabSpecifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TripBookings_Cabs_CabId",
                table: "TripBookings",
                column: "CabId",
                principalTable: "Cabs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TripBookings_Customers_CustomerId",
                table: "TripBookings",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Cabs_CabSpecifications_CabSpecificationId",
                table: "Cabs");

            migrationBuilder.DropForeignKey(
                name: "FK_TripBookings_Cabs_CabId",
                table: "TripBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_TripBookings_Customers_CustomerId",
                table: "TripBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_TripBookings_Drivers_DriverId",
                table: "TripBookings");

            migrationBuilder.DropIndex(
                name: "IX_TripBookings_CabId",
                table: "TripBookings");

            migrationBuilder.DropIndex(
                name: "IX_TripBookings_CustomerId",
                table: "TripBookings");

            migrationBuilder.DropIndex(
                name: "IX_TripBookings_DriverId",
                table: "TripBookings");

            migrationBuilder.DropIndex(
                name: "IX_Cabs_CabSpecificationId",
                table: "Cabs");

            migrationBuilder.DropColumn(
                name: "CabId",
                table: "TripBookings");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "TripBookings");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "TripBookings");

            migrationBuilder.DropColumn(
                name: "CabSpecificationId",
                table: "Cabs");

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    TripBookingId = table.Column<int>(type: "int", nullable: false),
                    CabId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.TripBookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Cabs_CabId",
                        column: x => x.CabId,
                        principalTable: "Cabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Bookings_CabId",
                table: "Bookings",
                column: "CabId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CustomerId",
                table: "Bookings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_DriverId",
                table: "Bookings",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_CabInSpecification_CabId",
                table: "CabInSpecification",
                column: "CabId");

            migrationBuilder.CreateIndex(
                name: "IX_CabInSpecification_CabSpecificationId",
                table: "CabInSpecification",
                column: "CabSpecificationId");
        }
    }
}