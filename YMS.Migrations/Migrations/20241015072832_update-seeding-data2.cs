using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YMS.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class updateseedingdata2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Users",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Customers",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Countries",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Cities",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Branches",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: new Guid("0a534cad-cce7-422b-b79b-b38f3ea1a918"),
                column: "CreatedDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: new Guid("1dffb2d6-88ac-4ecd-901e-f9e3cd44633c"),
                column: "CreatedDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3b362655-5ade-4978-826e-0ec0edbfc31b"),
                column: "CreatedDate",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Users",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Customers",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Countries",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Cities",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Branches",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: new Guid("0a534cad-cce7-422b-b79b-b38f3ea1a918"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 10, 15, 10, 23, 51, 633, DateTimeKind.Unspecified).AddTicks(2540), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: new Guid("1dffb2d6-88ac-4ecd-901e-f9e3cd44633c"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 10, 15, 10, 23, 51, 633, DateTimeKind.Unspecified).AddTicks(2545), new TimeSpan(0, 3, 0, 0, 0)));

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3b362655-5ade-4978-826e-0ec0edbfc31b"),
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 10, 15, 10, 23, 51, 633, DateTimeKind.Unspecified).AddTicks(2585), new TimeSpan(0, 3, 0, 0, 0)));
        }
    }
}
