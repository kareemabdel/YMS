using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YMS.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class SeedsDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "NameAr", "NameEn", "Remarks" },
                values: new object[] { 1, "SA", "المملكة العربية السعودية", "SAUDI ARABIA", null });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Code", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, "JEDDA", 1, "JEDDAH PLANT" },
                    { 2, "JUBAI", 1, "JUBAIL PLANT" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "Address", "CityId", "Code", "Fax", "Mobile", "Name", "Notes", "Phone1", "Phone2", "Zip" },
                values: new object[,]
                {
                    { 1, null, 1, "JEDDAH", null, null, "JEDDAH", null, null, null, null },
                    { 2, null, 2, "DAMMAM", null, null, "DAMMAM", null, null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
