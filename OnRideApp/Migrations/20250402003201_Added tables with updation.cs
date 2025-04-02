using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnRideApp.Migrations
{
    /// <inheritdoc />
    public partial class Addedtableswithupdation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_TripBookings_TripBookingBookingId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TripBookings",
                table: "TripBookings");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_TripBookingBookingId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "TripBookingBookingId",
                table: "Reviews");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TripBookings",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TripBookingId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TripBookings",
                table: "TripBookings",
                column: "Id");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_TripBookings",
                table: "TripBookings");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_TripBookingId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TripBookings");

            migrationBuilder.DropColumn(
                name: "TripBookingId",
                table: "Reviews");

            migrationBuilder.AddColumn<Guid>(
                name: "TripBookingBookingId",
                table: "Reviews",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TripBookings",
                table: "TripBookings",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TripBookingBookingId",
                table: "Reviews",
                column: "TripBookingBookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_TripBookings_TripBookingBookingId",
                table: "Reviews",
                column: "TripBookingBookingId",
                principalTable: "TripBookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
