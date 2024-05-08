using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommunityCommuting_DAL.Migrations
{
    /// <inheritdoc />
    public partial class Changed_Datatype_AadharCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "adharcard",
                table: "RideProvides",
                type: "bigint",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 12);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "adharcard",
                table: "RideProvides",
                type: "int",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldMaxLength: 12);
        }
    }
}
