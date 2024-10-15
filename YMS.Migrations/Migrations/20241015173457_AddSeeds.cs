using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YMS.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Basises",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Per Size" },
                    { 2, "Per Unit" }
                });

            migrationBuilder.InsertData(
                table: "FullStorageDataTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "FullStorageDataType1" },
                    { 2, "FullStorageDataType2" }
                });

            migrationBuilder.InsertData(
                table: "PackageTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Box" },
                    { 2, "Bags" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Basises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Basises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FullStorageDataTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FullStorageDataTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PackageTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PackageTypes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
