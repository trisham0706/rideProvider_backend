using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommunityCommuting_DAL.Migrations
{
    /// <inheritdoc />
    public partial class z : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "rideId",
                table: "Trips",
                newName: "vehicleId");

            migrationBuilder.AddColumn<int>(
                name: "month",
                table: "Smiles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "month",
                table: "Smiles");

            migrationBuilder.RenameColumn(
                name: "vehicleId",
                table: "Trips",
                newName: "rideId");
        }
    }
}
