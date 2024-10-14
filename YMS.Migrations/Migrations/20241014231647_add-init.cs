using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YMS.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class addinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Basises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExchangeRate = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FullStorageDataTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullStorageDataTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackageServicesTariff",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StorageFreeDays = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageServicesTariff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackageTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServicesTariff",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesTariff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackageServiceTariffData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageServicesTariffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageTypeId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    BasisId = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageServiceTariffData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageServiceTariffData_Basises_BasisId",
                        column: x => x.BasisId,
                        principalTable: "Basises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageServiceTariffData_PackageServicesTariff_PackageServicesTariffId",
                        column: x => x.PackageServicesTariffId,
                        principalTable: "PackageServicesTariff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageServiceTariffData_PackageTypes_PackageTypeId",
                        column: x => x.PackageTypeId,
                        principalTable: "PackageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageServiceTariffData_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTariffData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServicesTariffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount20 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount40 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Full = table.Column<bool>(type: "bit", nullable: false),
                    Empty = table.Column<bool>(type: "bit", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    BasisId = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTariffData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceTariffData_Basises_BasisId",
                        column: x => x.BasisId,
                        principalTable: "Basises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceTariffData_ServicesTariff_ServicesTariffId",
                        column: x => x.ServicesTariffId,
                        principalTable: "ServicesTariff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceTariffData_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasVat = table.Column<bool>(type: "bit", nullable: false),
                    PrintedDataAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrintedDataEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServicesTariffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageServicesTariffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_PackageServicesTariff_PackageServicesTariffId",
                        column: x => x.PackageServicesTariffId,
                        principalTable: "PackageServicesTariff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_ServicesTariff_ServicesTariffId",
                        column: x => x.ServicesTariffId,
                        principalTable: "ServicesTariff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Department = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.CheckConstraint("CHK_Email", "(Email IS NULL OR Email LIKE '%_@__%.__%')");
                    table.CheckConstraint("CHK_Mobile", "(Mobile LIKE '+[0-9]%' AND LEN(Mobile) >= 10 AND LEN(Mobile) <= 15)");
                    table.CheckConstraint("CK_Phone1", "(Phone1 IS NULL OR Phone1 LIKE '[0-9]%')");
                    table.CheckConstraint("CK_Phone2", "(Phone2 IS NULL OR Phone2 LIKE '[0-9]%')");
                    table.ForeignKey(
                        name: "FK_Users_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmptyStorageTariffs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeTeus = table.Column<int>(type: "int", nullable: true),
                    TeuRateDay = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    On20 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Off20 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Off40 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    On40 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DailyCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmptyStorageTariffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmptyStorageTariffs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FullStorageTariffs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeTeus = table.Column<int>(type: "int", nullable: true),
                    TeuRateDay = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    On20 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Off20 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Off40 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    On40 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DailyCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullStorageTariffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FullStorageTariffs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmptyStorageTariffDataList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmptyStorageTariffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DaysNum = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmptyStorageTariffDataList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmptyStorageTariffDataList_EmptyStorageTariffs_EmptyStorageTariffId",
                        column: x => x.EmptyStorageTariffId,
                        principalTable: "EmptyStorageTariffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FullStorageTariffDataList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FulllStorageDataTypeId = table.Column<int>(type: "int", nullable: false),
                    FullStorageTariffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DaysNum = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullStorageTariffDataList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FullStorageTariffDataList_FullStorageDataTypes_FulllStorageDataTypeId",
                        column: x => x.FulllStorageDataTypeId,
                        principalTable: "FullStorageDataTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FullStorageTariffDataList_FullStorageTariffs_FullStorageTariffId",
                        column: x => x.FullStorageTariffId,
                        principalTable: "FullStorageTariffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "CreatedById", "CreatedDate", "DeletedDate", "IsDeleted", "NameAr", "NameEn", "Remarks", "UpdatedDate" },
                values: new object[] { 1, "SA", null, new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 45, 513, DateTimeKind.Unspecified).AddTicks(568), new TimeSpan(0, 3, 0, 0, 0)), null, false, "المملكة العربية السعودية", "SAUDI ARABIA", null, null });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Code", "ExchangeRate", "NameAr", "NameEn", "Remarks" },
                values: new object[] { 1, "SAR", 3.75, "ريال سعودي", "Saudi Riyal", null });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Clean Unit" },
                    { 2, "Cleaning" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Code", "CountryId", "CreatedById", "CreatedDate", "DeletedDate", "IsDeleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "JEDDA", 1, null, new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 45, 513, DateTimeKind.Unspecified).AddTicks(881), new TimeSpan(0, 3, 0, 0, 0)), null, false, "JEDDAH PLANT", null },
                    { 2, "JUBAI", 1, null, new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 45, 513, DateTimeKind.Unspecified).AddTicks(896), new TimeSpan(0, 3, 0, 0, 0)), null, false, "JUBAIL PLANT", null }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "Address", "CityId", "Code", "CreatedById", "CreatedDate", "DeletedDate", "Fax", "IsDeleted", "Mobile", "Name", "Notes", "Phone1", "Phone2", "UpdatedDate", "Zip" },
                values: new object[,]
                {
                    { new Guid("188c5ac3-b1a4-4906-8c2a-35db604c366b"), null, 1, "JEDDAH", null, new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 45, 513, DateTimeKind.Unspecified).AddTicks(967), new TimeSpan(0, 3, 0, 0, 0)), null, null, false, null, "JEDDAH", null, null, null, null, null },
                    { new Guid("fb517db9-2aab-4ae7-b094-b2d1685d8ffc"), null, 2, "DAMMAM", null, new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 45, 513, DateTimeKind.Unspecified).AddTicks(975), new TimeSpan(0, 3, 0, 0, 0)), null, null, false, null, "DAMMAM", null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "BranchId", "CreatedById", "CreatedDate", "DeletedDate", "Department", "Email", "Inactive", "IsDeleted", "Mobile", "Name", "Notes", "Password", "Phone1", "Phone2", "UpdatedDate", "Username" },
                values: new object[] { new Guid("d280a4e3-a1c9-4ba4-a2c8-132bf5b0f1b0"), null, new Guid("188c5ac3-b1a4-4906-8c2a-35db604c366b"), null, new DateTimeOffset(new DateTime(2024, 10, 15, 2, 16, 45, 513, DateTimeKind.Unspecified).AddTicks(1036), new TimeSpan(0, 3, 0, 0, 0)), null, 0, null, false, false, null, "test", null, "123456", null, null, null, "test" });

            migrationBuilder.CreateIndex(
                name: "IX_Branches_CityId",
                table: "Branches",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BranchId",
                table: "Customers",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CityId",
                table: "Customers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CurrencyId",
                table: "Customers",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PackageServicesTariffId",
                table: "Customers",
                column: "PackageServicesTariffId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ServicesTariffId",
                table: "Customers",
                column: "ServicesTariffId");

            migrationBuilder.CreateIndex(
                name: "IX_EmptyStorageTariffDataList_EmptyStorageTariffId",
                table: "EmptyStorageTariffDataList",
                column: "EmptyStorageTariffId");

            migrationBuilder.CreateIndex(
                name: "IX_EmptyStorageTariffs_CustomerId",
                table: "EmptyStorageTariffs",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FullStorageTariffDataList_FulllStorageDataTypeId",
                table: "FullStorageTariffDataList",
                column: "FulllStorageDataTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FullStorageTariffDataList_FullStorageTariffId",
                table: "FullStorageTariffDataList",
                column: "FullStorageTariffId");

            migrationBuilder.CreateIndex(
                name: "IX_FullStorageTariffs_CustomerId",
                table: "FullStorageTariffs",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PackageServiceTariffData_BasisId",
                table: "PackageServiceTariffData",
                column: "BasisId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageServiceTariffData_PackageServicesTariffId",
                table: "PackageServiceTariffData",
                column: "PackageServicesTariffId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageServiceTariffData_PackageTypeId",
                table: "PackageServiceTariffData",
                column: "PackageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageServiceTariffData_ServiceId",
                table: "PackageServiceTariffData",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTariffData_BasisId",
                table: "ServiceTariffData",
                column: "BasisId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTariffData_ServiceId",
                table: "ServiceTariffData",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTariffData_ServicesTariffId",
                table: "ServiceTariffData",
                column: "ServicesTariffId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BranchId",
                table: "Users",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmptyStorageTariffDataList");

            migrationBuilder.DropTable(
                name: "FullStorageTariffDataList");

            migrationBuilder.DropTable(
                name: "PackageServiceTariffData");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "ServiceTariffData");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "EmptyStorageTariffs");

            migrationBuilder.DropTable(
                name: "FullStorageDataTypes");

            migrationBuilder.DropTable(
                name: "FullStorageTariffs");

            migrationBuilder.DropTable(
                name: "PackageTypes");

            migrationBuilder.DropTable(
                name: "Basises");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "PackageServicesTariff");

            migrationBuilder.DropTable(
                name: "ServicesTariff");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
