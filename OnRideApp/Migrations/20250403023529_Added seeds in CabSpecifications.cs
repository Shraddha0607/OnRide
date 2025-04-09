using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnRideApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedseedsinCabSpecifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CabSpecifications",
                columns: new[] { "Id", "CabType", "FarePrKm", "Model", "NumberOfSeats" },
                values: new object[,]
                {
                    { 1, 0, 7.5, "Hyundai i10", 4 },
                    { 2, 0, 8.0, "Maruti Alto", 4 },
                    { 3, 1, 12.0, "Honda Civic", 5 },
                    { 4, 1, 10.5, "Toyota Camry", 5 },
                    { 5, 1, 13.0, "BMW 3 Series", 5 },
                    { 6, 2, 15.0, "Toyota Fortuner", 7 },
                    { 7, 2, 16.5, "Ford Endeavour", 7 },
                    { 8, 2, 14.0, "Nissan X-Trail", 5 },
                    { 9, 3, 11.0, "Honda HR-V", 5 },
                    { 10, 3, 10.5, "Hyundai Creta", 5 },
                    { 11, 3, 12.5, "Kia Seltos", 5 },
                    { 12, 1, 9.5, "Skoda Octavia", 5 },
                    { 13, 0, 7.0, "Tata Nano", 4 },
                    { 14, 2, 18.0, "Land Rover Discovery", 7 },
                    { 15, 3, 11.5, "Mahindra XUV300", 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CabSpecifications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CabSpecifications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CabSpecifications",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CabSpecifications",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CabSpecifications",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CabSpecifications",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CabSpecifications",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CabSpecifications",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CabSpecifications",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CabSpecifications",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CabSpecifications",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CabSpecifications",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CabSpecifications",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CabSpecifications",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CabSpecifications",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}