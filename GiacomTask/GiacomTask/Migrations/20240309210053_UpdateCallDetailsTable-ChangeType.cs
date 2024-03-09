using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiacomTask.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCallDetailsTableChangeType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CallerID",
                table: "CallDetails",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CallerID",
                table: "CallDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
