using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Velora.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentHierarchyAndConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_BankAccounts_BankAccountId",
                schema: "velora",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Users_UserId",
                schema: "velora",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledPayments_Payment_PaymentId",
                schema: "velora",
                table: "ScheduledPayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payment",
                schema: "velora",
                table: "Payment");

            migrationBuilder.RenameTable(
                name: "Payment",
                schema: "velora",
                newName: "Payments",
                newSchema: "velora");

            migrationBuilder.RenameColumn(
                name: "Discriminator",
                schema: "velora",
                table: "Payments",
                newName: "PaymentType");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_UserId",
                schema: "velora",
                table: "Payments",
                newName: "IX_Payments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_BankAccountId",
                schema: "velora",
                table: "Payments",
                newName: "IX_Payments_BankAccountId");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "velora",
                table: "ScheduledPayments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "velora",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentName",
                schema: "velora",
                table: "Payments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentAccountNumber",
                schema: "velora",
                table: "Payments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "InterestRate",
                schema: "velora",
                table: "Payments",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Frequency",
                schema: "velora",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "velora",
                table: "Payments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BankAccountId1",
                schema: "velora",
                table: "Payments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                schema: "velora",
                table: "Payments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                schema: "velora",
                table: "Payments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BankAccountId1",
                schema: "velora",
                table: "Payments",
                column: "BankAccountId1");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId1",
                schema: "velora",
                table: "Payments",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_BankAccounts_BankAccountId",
                schema: "velora",
                table: "Payments",
                column: "BankAccountId",
                principalSchema: "velora",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_BankAccounts_BankAccountId1",
                schema: "velora",
                table: "Payments",
                column: "BankAccountId1",
                principalSchema: "velora",
                principalTable: "BankAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_UserId",
                schema: "velora",
                table: "Payments",
                column: "UserId",
                principalSchema: "velora",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_UserId1",
                schema: "velora",
                table: "Payments",
                column: "UserId1",
                principalSchema: "velora",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledPayments_Payments_PaymentId",
                schema: "velora",
                table: "ScheduledPayments",
                column: "PaymentId",
                principalSchema: "velora",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_BankAccounts_BankAccountId",
                schema: "velora",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_BankAccounts_BankAccountId1",
                schema: "velora",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Users_UserId",
                schema: "velora",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Users_UserId1",
                schema: "velora",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledPayments_Payments_PaymentId",
                schema: "velora",
                table: "ScheduledPayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                schema: "velora",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_BankAccountId1",
                schema: "velora",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_UserId1",
                schema: "velora",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "BankAccountId1",
                schema: "velora",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "UserId1",
                schema: "velora",
                table: "Payments");

            migrationBuilder.RenameTable(
                name: "Payments",
                schema: "velora",
                newName: "Payment",
                newSchema: "velora");

            migrationBuilder.RenameColumn(
                name: "PaymentType",
                schema: "velora",
                table: "Payment",
                newName: "Discriminator");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_UserId",
                schema: "velora",
                table: "Payment",
                newName: "IX_Payment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_BankAccountId",
                schema: "velora",
                table: "Payment",
                newName: "IX_Payment_BankAccountId");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                schema: "velora",
                table: "ScheduledPayments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                schema: "velora",
                table: "Payment",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentName",
                schema: "velora",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentAccountNumber",
                schema: "velora",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "InterestRate",
                schema: "velora",
                table: "Payment",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldPrecision: 5,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Frequency",
                schema: "velora",
                table: "Payment",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "velora",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payment",
                schema: "velora",
                table: "Payment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_BankAccounts_BankAccountId",
                schema: "velora",
                table: "Payment",
                column: "BankAccountId",
                principalSchema: "velora",
                principalTable: "BankAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Users_UserId",
                schema: "velora",
                table: "Payment",
                column: "UserId",
                principalSchema: "velora",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledPayments_Payment_PaymentId",
                schema: "velora",
                table: "ScheduledPayments",
                column: "PaymentId",
                principalSchema: "velora",
                principalTable: "Payment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
