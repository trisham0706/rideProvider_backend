using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommunityCommuting_DAL.Migrations
{
    /// <inheritdoc />
    public partial class CC_DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RideProvides",
                columns: table => new
                {
                    rpId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    adharcard = table.Column<int>(type: "int", maxLength: 12, nullable: false),
                    emailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<int>(type: "int", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    dlNo = table.Column<string>(type: "nchar(16)", fixedLength: true, maxLength: 16, nullable: false),
                    validUpto = table.Column<DateOnly>(type: "date", nullable: false),
                    status = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RideProvides", x => x.rpId);
                });

            migrationBuilder.CreateTable(
                name: "RideInfos",
                columns: table => new
                {
                    vehicleNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    rpId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    carType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    carName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fuelType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    noOfSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RideInfos", x => x.vehicleNo);
                    table.ForeignKey(
                        name: "FK_RideInfos_RideProvides_rpId",
                        column: x => x.rpId,
                        principalTable: "RideProvides",
                        principalColumn: "rpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Smiles",
                columns: table => new
                {
                    smileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rpId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    occupancy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smiles", x => x.smileId);
                    table.ForeignKey(
                        name: "FK_Smiles_RideInfos_rpId",
                        column: x => x.rpId,
                        principalTable: "RideInfos",
                        principalColumn: "vehicleNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RideInfos_rpId",
                table: "RideInfos",
                column: "rpId");

            migrationBuilder.CreateIndex(
                name: "IX_Smiles_rpId",
                table: "Smiles",
                column: "rpId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Smiles");

            migrationBuilder.DropTable(
                name: "RideInfos");

            migrationBuilder.DropTable(
                name: "RideProvides");
        }
    }
}
