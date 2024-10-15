using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YMS.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class updateseedingdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: new Guid("fb517db9-2aab-4ae7-b094-b2d1685d8ffc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d280a4e3-a1c9-4ba4-a2c8-132bf5b0f1b0"));

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: new Guid("188c5ac3-b1a4-4906-8c2a-35db604c366b"));

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "Address", "CityId", "Code", "CreatedById", "CreatedDate", "DeletedDate", "Fax", "IsDeleted", "Mobile", "Name", "Notes", "Phone1", "Phone2", "UpdatedDate", "Zip" },
                values: new object[,]
                {
                    { new Guid("0a534cad-cce7-422b-b79b-b38f3ea1a918"), null, 1, "JEDDAH", null, new DateTimeOffset(new DateTime(2024, 10, 15, 10, 23, 51, 633, DateTimeKind.Unspecified).AddTicks(2540), new TimeSpan(0, 3, 0, 0, 0)), null, null, false, null, "JEDDAH", null, null, null, null, null },
                    { new Guid("1dffb2d6-88ac-4ecd-901e-f9e3cd44633c"), null, 2, "DAMMAM", null, new DateTimeOffset(new DateTime(2024, 10, 15, 10, 23, 51, 633, DateTimeKind.Unspecified).AddTicks(2545), new TimeSpan(0, 3, 0, 0, 0)), null, null, false, null, "DAMMAM", null, null, null, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 10, 15, 10, 23, 51, 633, DateTimeKind.Unspecified).AddTicks(2496), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 10, 15, 10, 23, 51, 633, DateTimeKind.Unspecified).AddTicks(2504), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 10, 15, 10, 23, 51, 633, DateTimeKind.Unspecified).AddTicks(2193), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "BranchId", "CreatedById", "CreatedDate", "DeletedDate", "Department", "Email", "Inactive", "IsDeleted", "Mobile", "Name", "Notes", "Password", "Phone1", "Phone2", "UpdatedDate", "Username" },
                values: new object[] { new Guid("3b362655-5ade-4978-826e-0ec0edbfc31b"), null, new Guid("0a534cad-cce7-422b-b79b-b38f3ea1a918"), null, new DateTimeOffset(new DateTime(2024, 10, 15, 10, 23, 51, 633, DateTimeKind.Unspecified).AddTicks(2585), new TimeSpan(0, 3, 0, 0, 0)), null, 0, null, false, false, null, "test", null, "123456", null, null, null, "test" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: new Guid("1dffb2d6-88ac-4ecd-901e-f9e3cd44633c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3b362655-5ade-4978-826e-0ec0edbfc31b"));

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: new Guid("0a534cad-cce7-422b-b79b-b38f3ea1a918"));

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "Address", "CityId", "Code", "CreatedById", "CreatedDate", "DeletedDate", "Fax", "IsDeleted", "Mobile", "Name", "Notes", "Phone1", "Phone2", "UpdatedDate", "Zip" },
                values: new object[,]
                {
                    { new Guid("188c5ac3-b1a4-4906-8c2a-35db604c366b"), null, 1, "JEDDAH", null, new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 45, 513, DateTimeKind.Unspecified).AddTicks(967), new TimeSpan(0, 3, 0, 0, 0)), null, null, false, null, "JEDDAH", null, null, null, null, null },
                    { new Guid("fb517db9-2aab-4ae7-b094-b2d1685d8ffc"), null, 2, "DAMMAM", null, new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 45, 513, DateTimeKind.Unspecified).AddTicks(975), new TimeSpan(0, 3, 0, 0, 0)), null, null, false, null, "DAMMAM", null, null, null, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 45, 513, DateTimeKind.Unspecified).AddTicks(881), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 45, 513, DateTimeKind.Unspecified).AddTicks(896), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 45, 513, DateTimeKind.Unspecified).AddTicks(568), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "BranchId", "CreatedById", "CreatedDate", "DeletedDate", "Department", "Email", "Inactive", "IsDeleted", "Mobile", "Name", "Notes", "Password", "Phone1", "Phone2", "UpdatedDate", "Username" },
                values: new object[] { new Guid("d280a4e3-a1c9-4ba4-a2c8-132bf5b0f1b0"), null, new Guid("188c5ac3-b1a4-4906-8c2a-35db604c366b"), null, new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 45, 513, DateTimeKind.Unspecified).AddTicks(1036), new TimeSpan(0, 3, 0, 0, 0)), null, 0, null, false, false, null, "test", null, "123456", null, null, null, "test" });
        }
    }
}
