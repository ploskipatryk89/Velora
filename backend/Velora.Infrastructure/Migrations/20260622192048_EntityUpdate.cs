using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Velora.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EntityUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfMonth",
                schema: "velora",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "PaymentDay",
                schema: "velora",
                table: "Payment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "DayOfMonth",
                schema: "velora",
                table: "Payment",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "PaymentDay",
                schema: "velora",
                table: "Payment",
                type: "tinyint",
                nullable: true);
        }
    }
}
