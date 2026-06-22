using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Velora.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class M6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPaid",
                schema: "velora",
                table: "ScheduledPayments");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "velora",
                table: "ScheduledPayments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                schema: "velora",
                table: "ScheduledPayments");

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                schema: "velora",
                table: "ScheduledPayments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
