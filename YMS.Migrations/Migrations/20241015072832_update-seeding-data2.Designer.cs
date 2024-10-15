﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YMS.Migrations.Data;

#nullable disable

namespace YMS.Migrations.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241015072832_update-seeding-data2")]
    partial class updateseedingdata2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("YMS.Migrations.Entities.Basis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Basises");
                });

            modelBuilder.Entity("YMS.Migrations.Entities.Branch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Zip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Branches");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0a534cad-cce7-422b-b79b-b38f3ea1a918"),
                            CityId = 1,
                            Code = "JEDDAH",
                            IsDeleted = false,
                            Name = "JEDDAH"
                        },
                        new
                        {
                            Id = new Guid("1dffb2d6-88ac-4ecd-901e-f9e3cd44633c"),
                            CityId = 2,
                            Code = "DAMMAM",
                            IsDeleted = false,
                            Name = "DAMMAM"
                        });
                });

            modelBuilder.Entity("YMS.Migrations.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<Guid?>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "JEDDA",
                            CountryId = 1,
                            IsDeleted = false,
                            Name = "JEDDAH PLANT"
                        },
                        new
                        {
                            Id = 2,
                            Code = "JUBAI",
                            CountryId = 1,
                            IsDeleted = false,
                            Name = "JUBAIL PLANT"
                        });
                });

            modelBuilder.Entity("YMS.Migrations.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NameAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "SA",
                            IsDeleted = false,
                            NameAr = "المملكة العربية السعودية",
                            NameEn = "SAUDI ARABIA"
                        });
                });

            modelBuilder.Entity("YMS.Migrations.Entities.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("ExchangeRate")
                        .HasColumnType("float");

                    b.Property<string>("NameAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Currencies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "SAR",
                            ExchangeRate = 3.75,
                            NameAr = "ريال سعودي",
                            NameEn = "Saudi Riyal"
                        });
                });

            modelBuilder.Entity("YMS.Migrations.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BranchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPerson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPersonDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasVat")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PackageServicesTariffId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.Property<string>("Phone1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrintedDataAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrintedDataEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ServicesTariffId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TaxNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("ValidTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("CityId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("PackageServicesTariffId");

                    b.HasIndex("ServicesTariffId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("YMS.Migrations.Entities.EmptyStorageTariff", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DailyCount")
                        .HasColumnType("int");

                    b.Property<int?>("FreeTeus")
                        .HasColumnType("int");

                    b.Property<decimal?>("Off20")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Off40")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("On20")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("On40")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TeuRateDay")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("EmptyStorageTariffs");
                });

            modelBuilder.Entity("YMS.Migrations.Entities.EmptyStorageTariffData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("DaysNum")
                        .HasColumnType("int");

                    b.Property<Guid>("EmptyStorageTariffId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EmptyStorageTariffId");

                    b.ToTable("EmptyStorageTariffDataList");
                });

            modelBuilder.Entity("YMS.Migrations.Entities.FullStorageDataType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FullStorageDataTypes");
                });

            modelBuilder.Entity("YMS.Migrations.Entities.FullStorageTariff", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DailyCount")
                        .HasColumnType("int");

                    b.Property<int?>("FreeTeus")
                        .HasColumnType("int");

                    b.Property<decimal?>("Off20")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Off40")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("On20")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("On40")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TeuRateDay")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("FullStorageTariffs");
                });

            modelBuilder.Entity("YMS.Migrations.Entities.FullStorageTariffData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("DaysNum")
                        .HasColumnType("int");

                    b.Property<Guid>("FullStorageTariffId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FulllStorageDataTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FullStorageTariffId");

                    b.HasIndex("FulllStorageDataTypeId");

                    b.ToTable("FullStorageTariffDataList");
                });

            modelBuilder.Entity("YMS.Migrations.Entities.PackageServiceTariffData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("BasisId")
                        .HasColumnType("int");

                    b.Property<Guid>("PackageServicesTariffId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PackageTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BasisId");

                    b.HasIndex("PackageServicesTariffId");

                    b.HasIndex("PackageTypeId");

                    b.HasIndex("ServiceId");

                    b.ToTable("PackageServiceTariffData");
                });

            modelBuilder.Entity("YMS.Migrations.Entities.PackageServicesTariff", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StorageFreeDays")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PackageServicesTariff");
                });

            modelBuilder.Entity("YMS.Migrations.Entities.PackageType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PackageTypes");
                });

            modelBuilder.Entity("YMS.Migrations.Entities.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("YMS.Migrations.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Clean Unit"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Cleaning"
                        });
                });

            modelBuilder.Entity("YMS.Migrations.Entities.ServiceTariffData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Amount20")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Amount40")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("BasisId")
                        .HasColumnType("int");

                    b.Property<bool>("Empty")
                        .HasColumnType("bit");

                    b.Property<bool>("Full")
                        .HasColumnType("bit");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<Guid>("ServicesTariffId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BasisId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("ServicesTariffId");

                    b.ToTable("ServiceTariffData");
                });

            modelBuilder.Entity("YMS.Migrations.Entities.ServicesTariff", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ServicesTariff");
                });

            modelBuilder.Entity("YMS.Migrations.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("BranchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Department")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Inactive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users", t =>
                        {
                            t.HasCheckConstraint("CHK_Email", "(Email IS NULL OR Email LIKE '%_@__%.__%')");

                            t.HasCheckConstraint("CHK_Mobile", "(Mobile LIKE '+[0-9]%' AND LEN(Mobile) >= 10 AND LEN(Mobile) <= 15)");

                            t.HasCheckConstraint("CK_Phone1", "(Phone1 IS NULL OR Phone1 LIKE '[0-9]%')");

                            t.HasCheckConstraint("CK_Phone2", "(Phone2 IS NULL OR Phone2 LIKE '[0-9]%')");
                        });

                    b.HasData(
                        new
                        {
                            Id = new Guid("3b362655-5ade-4978-826e-0ec0edbfc31b"),
                            BranchId = new Guid("0a534cad-cce7-422b-b79b-b38f3ea1a918"),
                            Department = 0,
                            Inactive = false,
                            IsDeleted = false,
                            Name = "test",
                            Password = "123456",
                            Username = "test"
                        });
                });

            modelBuilder.Entity("YMS.Migrations.Entities.Branch", b =>
                {
                    b.HasOne("YMS.Migrations.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("YMS.Migrations.Entities.City", b =>
                {
                    b.HasOne("YMS.Migrations.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("YMS.Migrations.Entities.Customer", b =>
                {
                    b.HasOne("YMS.Migrations.Entities.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YMS.Migrations.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("YMS.Migrations.Entities.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YMS.Migrations.Entities.PackageServicesTariff", "PackageServicesTariff")
                        .WithMany()
                        .HasForeignKey("PackageServicesTariffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YMS.Migrations.Entities.ServicesTariff", "ServicesTariff")
                        .WithMany()
                        .HasForeignKey("ServicesTariffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("City");

                    b.Navigation("Currency");

                    b.Navigation("PackageServicesTariff");

                    b.Navigation("ServicesTariff");
                });

            modelBuilder.Entity("YMS.Migrations.Entities.EmptyStorageTariff", b =>
                {
                    b.HasOne("YMS.Migrations.Entities.Customer", "Customer")
                        .WithOne("EmptyStorageTariff")
                        .HasForeignKey("YMS.Migrations.Entities.EmptyStorageTariff", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("YMS.Migrations.Entities.EmptyStorageTariffData", b =>
                {
                    b.HasOne("YMS.Migrations.Entities.EmptyStorageTariff", "EmptyStorageTariff")
                        .WithMany()
                        .HasForeignKey("EmptyStorageTariffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmptyStorageTariff");
                });

            modelBuilder.Entity("YMS.Migrations.Entities.FullStorageTariff", b =>
                {
                    b.HasOne("YMS.Migrations.Entities.Customer", "Customer")
                        .WithOne("FullStorageTariff")
                        .HasForeignKey("YMS.Migrations.Entities.FullStorageTariff", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("YMS.Migrations.Entities.FullStorageTariffData", b =>
                {
                    b.HasOne("YMS.Migrations.Entities.FullStorageTariff", "FullStorageTariff")
                        .WithMany("FullStorageTariffDataList")
                        .HasForeignKey("FullStorageTariffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YMS.Migrations.Entities.FullStorageDataType", "FulllStorageDataType")
                        .WithMany()
                        .HasForeignKey("FulllStorageDataTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FullStorageTariff");

                    b.Navigation("FulllStorageDataType");
                });

            modelBuilder.Entity("YMS.Migrations.Entities.PackageServiceTariffData", b =>
                {
                    b.HasOne("YMS.Migrations.Entities.Basis", "Basis")
                        .WithMany()
                        .HasForeignKey("BasisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YMS.Migrations.Entities.PackageServicesTariff", "PackageServicesTariff")
                        .WithMany("PackageServiceTariffDataList")
                        .HasForeignKey("PackageServicesTariffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YMS.Migrations.Entities.PackageType", "PackageType")
                        .WithMany()
                        .HasForeignKey("PackageTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YMS.Migrations.Entities.Service", "Services")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basis");

                    b.Navigation("PackageServicesTariff");

                    b.Navigation("PackageType");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("YMS.Migrations.Entities.ServiceTariffData", b =>
                {
                    b.HasOne("YMS.Migrations.Entities.Basis", "Basis")
                        .WithMany()
                        .HasForeignKey("BasisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YMS.Migrations.Entities.Service", "Services")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YMS.Migrations.Entities.ServicesTariff", "ServicesTariff")
                        .WithMany("ServiceTariffDataList")
                        .HasForeignKey("ServicesTariffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basis");

                    b.Navigation("Services");

                    b.Navigation("ServicesTariff");
                });

            modelBuilder.Entity("YMS.Migrations.Entities.User", b =>
                {
                    b.HasOne("YMS.Migrations.Entities.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId");

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("YMS.Migrations.Entities.Customer", b =>
                {
                    b.Navigation("EmptyStorageTariff")
                        .IsRequired();

                    b.Navigation("FullStorageTariff")
                        .IsRequired();
                });

            modelBuilder.Entity("YMS.Migrations.Entities.FullStorageTariff", b =>
                {
                    b.Navigation("FullStorageTariffDataList");
                });

            modelBuilder.Entity("YMS.Migrations.Entities.PackageServicesTariff", b =>
                {
                    b.Navigation("PackageServiceTariffDataList");
                });

            modelBuilder.Entity("YMS.Migrations.Entities.ServicesTariff", b =>
                {
                    b.Navigation("ServiceTariffDataList");
                });
#pragma warning restore 612, 618
        }
    }
}
