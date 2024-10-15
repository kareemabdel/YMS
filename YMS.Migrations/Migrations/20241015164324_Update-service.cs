using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YMS.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Updateservice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_PackageServicesTariff_PackageServicesTariffId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_ServicesTariff_ServicesTariffId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_PackageServicesTariffId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ServicesTariffId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PackageServicesTariffId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ServicesTariffId",
                table: "Customers");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "ServicesTariff",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "PackageServicesTariff",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ServicesTariff_CustomerId",
                table: "ServicesTariff",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PackageServicesTariff_CustomerId",
                table: "PackageServicesTariff",
                column: "CustomerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PackageServicesTariff_Customers_CustomerId",
                table: "PackageServicesTariff",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesTariff_Customers_CustomerId",
                table: "ServicesTariff",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageServicesTariff_Customers_CustomerId",
                table: "PackageServicesTariff");

            migrationBuilder.DropForeignKey(
                name: "FK_ServicesTariff_Customers_CustomerId",
                table: "ServicesTariff");

            migrationBuilder.DropIndex(
                name: "IX_ServicesTariff_CustomerId",
                table: "ServicesTariff");

            migrationBuilder.DropIndex(
                name: "IX_PackageServicesTariff_CustomerId",
                table: "PackageServicesTariff");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "ServicesTariff");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "PackageServicesTariff");

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

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PackageServicesTariffId",
                table: "Customers",
                column: "PackageServicesTariffId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ServicesTariffId",
                table: "Customers",
                column: "ServicesTariffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_PackageServicesTariff_PackageServicesTariffId",
                table: "Customers",
                column: "PackageServicesTariffId",
                principalTable: "PackageServicesTariff",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_ServicesTariff_ServicesTariffId",
                table: "Customers",
                column: "ServicesTariffId",
                principalTable: "ServicesTariff",
                principalColumn: "Id");
        }
    }
}
