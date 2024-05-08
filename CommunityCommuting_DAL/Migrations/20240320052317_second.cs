using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommunityCommuting_DAL.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "dlNo",
                table: "RideProvides",
                type: "nchar(18)",
                fixedLength: true,
                maxLength: 18,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(20)",
                oldFixedLength: true,
                oldMaxLength: 20);

            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "RideProvides",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "birthDate",
                table: "RideProvides",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "age",
                table: "RideProvides");

            migrationBuilder.DropColumn(
                name: "birthDate",
                table: "RideProvides");

            migrationBuilder.AlterColumn<string>(
                name: "dlNo",
                table: "RideProvides",
                type: "nchar(20)",
                fixedLength: true,
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(18)",
                oldFixedLength: true,
                oldMaxLength: 18);
        }
    }
}
