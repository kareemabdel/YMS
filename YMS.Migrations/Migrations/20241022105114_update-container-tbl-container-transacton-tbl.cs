using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YMS.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class updatecontainertblcontainertransactontbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Containers_Customers_CustomerId",
                table: "Containers");

            migrationBuilder.DropForeignKey(
                name: "FK_Containers_Vessels_VesselId",
                table: "Containers");

            migrationBuilder.DropForeignKey(
                name: "FK_ContainerTransactions_Blocks_BlockId",
                table: "ContainerTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_ContainerTransactions_Lines_LineId",
                table: "ContainerTransactions");

            migrationBuilder.DropIndex(
                name: "IX_ContainerTransactions_LineId",
                table: "ContainerTransactions");

            migrationBuilder.DropColumn(
                name: "IsRORO",
                table: "ContainerTransactions");

            migrationBuilder.DropColumn(
                name: "TruckNo",
                table: "ContainerTransactions");

            migrationBuilder.RenameColumn(
                name: "Tier",
                table: "ContainerTransactions",
                newName: "ActualTier");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "ContainerTransactions",
                newName: "GateInBlockId");

            migrationBuilder.RenameColumn(
                name: "Rows",
                table: "ContainerTransactions",
                newName: "ActualRows");

            migrationBuilder.RenameColumn(
                name: "LineId",
                table: "ContainerTransactions",
                newName: "ActualBlockId");

            migrationBuilder.RenameColumn(
                name: "Bay",
                table: "ContainerTransactions",
                newName: "ActualBay");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "ContainerTransactions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "BlockId",
                table: "ContainerTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AllocationStatus",
                table: "ContainerTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<short>(
                name: "GateInBay",
                table: "ContainerTransactions",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "GateInRows",
                table: "ContainerTransactions",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "GateInTier",
                table: "ContainerTransactions",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AlterColumn<string>(
                name: "Weight",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Voyage",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "VesselId",
                table: "Containers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "TempRqd",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ShippingStatus",
                table: "Containers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Ref",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "OOG",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LoadPosition",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ISO",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "IMOClass",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ETA",
                table: "Containers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "DMG",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Containers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "BillNumber",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BayCell",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ContainerCondition",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EIR",
                table: "Containers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EIRRemarks",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRORO",
                table: "Containers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SealNumber",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TruckNo",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_Customers_CustomerId",
                table: "Containers",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_Vessels_VesselId",
                table: "Containers",
                column: "VesselId",
                principalTable: "Vessels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContainerTransactions_Blocks_BlockId",
                table: "ContainerTransactions",
                column: "BlockId",
                principalTable: "Blocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Containers_Customers_CustomerId",
                table: "Containers");

            migrationBuilder.DropForeignKey(
                name: "FK_Containers_Vessels_VesselId",
                table: "Containers");

            migrationBuilder.DropForeignKey(
                name: "FK_ContainerTransactions_Blocks_BlockId",
                table: "ContainerTransactions");

            migrationBuilder.DropColumn(
                name: "AllocationStatus",
                table: "ContainerTransactions");

            migrationBuilder.DropColumn(
                name: "GateInBay",
                table: "ContainerTransactions");

            migrationBuilder.DropColumn(
                name: "GateInRows",
                table: "ContainerTransactions");

            migrationBuilder.DropColumn(
                name: "GateInTier",
                table: "ContainerTransactions");

            migrationBuilder.DropColumn(
                name: "ContainerCondition",
                table: "Containers");

            migrationBuilder.DropColumn(
                name: "EIR",
                table: "Containers");

            migrationBuilder.DropColumn(
                name: "EIRRemarks",
                table: "Containers");

            migrationBuilder.DropColumn(
                name: "IsRORO",
                table: "Containers");

            migrationBuilder.DropColumn(
                name: "SealNumber",
                table: "Containers");

            migrationBuilder.DropColumn(
                name: "TruckNo",
                table: "Containers");

            migrationBuilder.RenameColumn(
                name: "GateInBlockId",
                table: "ContainerTransactions",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "ActualTier",
                table: "ContainerTransactions",
                newName: "Tier");

            migrationBuilder.RenameColumn(
                name: "ActualRows",
                table: "ContainerTransactions",
                newName: "Rows");

            migrationBuilder.RenameColumn(
                name: "ActualBlockId",
                table: "ContainerTransactions",
                newName: "LineId");

            migrationBuilder.RenameColumn(
                name: "ActualBay",
                table: "ContainerTransactions",
                newName: "Bay");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "ContainerTransactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BlockId",
                table: "ContainerTransactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsRORO",
                table: "ContainerTransactions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TruckNo",
                table: "ContainerTransactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Weight",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Voyage",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VesselId",
                table: "Containers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TempRqd",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShippingStatus",
                table: "Containers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ref",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OOG",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LoadPosition",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ISO",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IMOClass",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ETA",
                table: "Containers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DMG",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Containers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BillNumber",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BayCell",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContainerTransactions_LineId",
                table: "ContainerTransactions",
                column: "LineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_Customers_CustomerId",
                table: "Containers",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_Vessels_VesselId",
                table: "Containers",
                column: "VesselId",
                principalTable: "Vessels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContainerTransactions_Blocks_BlockId",
                table: "ContainerTransactions",
                column: "BlockId",
                principalTable: "Blocks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContainerTransactions_Lines_LineId",
                table: "ContainerTransactions",
                column: "LineId",
                principalTable: "Lines",
                principalColumn: "Id");
        }
    }
}
