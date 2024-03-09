using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiacomTask.Migrations
{
    /// <inheritdoc />
    public partial class InitCallDetailsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CallDetails",
                columns: table => new
                {
                    CallDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CallerID = table.Column<int>(type: "int", nullable: false),
                    Recipient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CallDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CallEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<long>(type: "bigint", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallDetails", x => x.CallDetailID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CallDetails");
        }
    }
}
