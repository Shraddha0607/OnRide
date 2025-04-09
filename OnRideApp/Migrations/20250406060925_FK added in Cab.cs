using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnRideApp.Migrations
{
    /// <inheritdoc />
    public partial class FKaddedinCab : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cabs_CabLocations_CabLocationId",
                table: "Cabs");

            migrationBuilder.DropTable(
                name: "CabLocations");

            migrationBuilder.AddColumn<int>(
                name: "CabId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Latitude", "Longitude" },
                values: new object[] { 1, 0.0, 0.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CabId",
                table: "Bookings",
                column: "CabId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Cabs_CabId",
                table: "Bookings",
                column: "CabId",
                principalTable: "Cabs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cabs_Locations_CabLocationId",
                table: "Cabs",
                column: "CabLocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Cabs_CabId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Cabs_Locations_CabLocationId",
                table: "Cabs");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_CabId",
                table: "Bookings");

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "CabId",
                table: "Bookings");

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

            migrationBuilder.CreateIndex(
                name: "IX_CabLocations_LocationId",
                table: "CabLocations",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cabs_CabLocations_CabLocationId",
                table: "Cabs",
                column: "CabLocationId",
                principalTable: "CabLocations",
                principalColumn: "Id");
        }
    }
}