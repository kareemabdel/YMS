using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YMS.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Addlinetbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LineId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LineId1",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Lines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lines", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LineId1",
                table: "Customers",
                column: "LineId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Lines_LineId1",
                table: "Customers",
                column: "LineId1",
                principalTable: "Lines",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Lines_LineId1",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "Lines");

            migrationBuilder.DropIndex(
                name: "IX_Customers_LineId1",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LineId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LineId1",
                table: "Customers");
        }
    }
}
