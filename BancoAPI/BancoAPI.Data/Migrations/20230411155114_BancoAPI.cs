using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancoAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class BancoAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Transactions",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "Transactions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Transactions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                table: "Transactions",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Updated",
                table: "Transactions",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "Accounts",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                table: "Accounts",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Updated",
                table: "Accounts",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Transactions",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70);
        }
    }
}
