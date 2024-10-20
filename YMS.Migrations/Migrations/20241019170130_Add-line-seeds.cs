using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YMS.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Addlineseeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Lines",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "AYE" },
                    { 2, "GMAC" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lines",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
