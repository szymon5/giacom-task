using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiacomTask.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCallDetailsTableChangeTypeDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CallEnd",
                table: "CallDetails");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "CallDate",
                table: "CallDetails",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<TimeOnly>(
                name: "EndTime",
                table: "CallDetails",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "CallDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CallDate",
                table: "CallDetails",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<DateTime>(
                name: "CallEnd",
                table: "CallDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
