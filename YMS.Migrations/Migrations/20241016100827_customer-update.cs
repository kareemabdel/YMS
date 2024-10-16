using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YMS.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class customerupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmptyStorageTariffId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FullStorageTariffId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PackageServicesTariffId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ServicesTariffId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmptyStorageTariffId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "FullStorageTariffId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PackageServicesTariffId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ServicesTariffId",
                table: "Customers");
        }
    }
}
