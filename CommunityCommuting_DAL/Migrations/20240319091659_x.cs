using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommunityCommuting_DAL.Migrations
{
    /// <inheritdoc />
    public partial class x : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "dlNo",
                table: "RideProvides",
                type: "nchar(20)",
                fixedLength: true,
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(16)",
                oldFixedLength: true,
                oldMaxLength: 16);

            migrationBuilder.CreateTable(
                name: "Fees",
                columns: table => new
                {
                    feeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    carType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    carName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fuelType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    averageInKm = table.Column<int>(type: "int", nullable: false),
                    wearTearCost = table.Column<int>(type: "int", nullable: false),
                    drivercharges = table.Column<int>(type: "int", nullable: false),
                    carPoolCommision = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fees", x => x.feeId);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    tripId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    creatorUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rideId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rideDate = table.Column<DateOnly>(type: "date", nullable: false),
                    rideTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    rideStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    noOfSeat = table.Column<int>(type: "int", nullable: false),
                    seatsFilled = table.Column<int>(type: "int", nullable: false),
                    fromLoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    toLoc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.tripId);
                });

            migrationBuilder.CreateTable(
                name: "billMasters",
                columns: table => new
                {
                    billId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    rideId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    month = table.Column<int>(type: "int", nullable: false),
                    noOfKm = table.Column<int>(type: "int", nullable: false),
                    totalbill = table.Column<int>(type: "int", nullable: false),
                    noOfOccupants = table.Column<int>(type: "int", nullable: false),
                    feeId = table.Column<int>(type: "int", nullable: false),
                    costPerOccupant = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_billMasters", x => x.billId);
                    table.ForeignKey(
                        name: "FK_billMasters_Fees_feeId",
                        column: x => x.feeId,
                        principalTable: "Fees",
                        principalColumn: "feeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    bookingId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    tripId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    numberOfSeat = table.Column<int>(type: "int", nullable: false),
                    seekerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.bookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Trips_tripId",
                        column: x => x.tripId,
                        principalTable: "Trips",
                        principalColumn: "tripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_billMasters_feeId",
                table: "billMasters",
                column: "feeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_tripId",
                table: "Bookings",
                column: "tripId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "billMasters");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Fees");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.AlterColumn<string>(
                name: "dlNo",
                table: "RideProvides",
                type: "nchar(16)",
                fixedLength: true,
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(20)",
                oldFixedLength: true,
                oldMaxLength: 20);
        }
    }
}
