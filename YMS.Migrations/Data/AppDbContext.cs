﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS.Migrations.Entities;
using YMS.Migrations.Entities.Lookups;

namespace YMS.Migrations.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<EmptyStorageTariff> EmptyStorageTariffs { get; set; }
        public DbSet<EmptyStorageTariffData> EmptyStorageTariffDataList { get; set; }
        public DbSet<FullStorageTariff> FullStorageTariffs { get; set; }
        public DbSet<FullStorageTariffData> FullStorageTariffDataList { get; set; }
        public DbSet<PackageType> PackageTypes { get; set; }
        public DbSet<Basis> Basises { get; set; }
        public DbSet<FullStorageDataType> FullStorageDataTypes { get; set; }
        public DbSet<Vessel> Vessels { get; set; }
        public DbSet<Transporter> Transporters { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<ContainerType> ContainerTypes { get; set; }
        public DbSet<Container> Containers { get; set; }
        public DbSet<ContainerTransaction> ContainerTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd(); // Set Id as identity
                entity.HasIndex(e => e.Username).IsUnique();
                // Adding check constraint
                entity.HasCheckConstraint("CK_Phone1", "(Phone1 IS NULL OR Phone1 LIKE '[0-9]%')");
                entity.HasCheckConstraint("CK_Phone2", "(Phone2 IS NULL OR Phone2 LIKE '[0-9]%')");
                entity.HasCheckConstraint("CHK_Mobile", "(Mobile LIKE '+[0-9]%' AND LEN(Mobile) >= 10 AND LEN(Mobile) <= 15)");
                entity.HasCheckConstraint("CHK_Email", "(Email IS NULL OR Email LIKE '%_@__%.__%')");
            });

            modelBuilder.Entity<Customer>()
            .HasOne(c => c.Branch)
            .WithMany()
            .HasForeignKey(c => c.BranchId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete when Branch is deleted

            modelBuilder.Entity<Customer>()
            .HasOne(c => c.City)
            .WithMany()
            .HasForeignKey(c => c.CityId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes

              modelBuilder.Entity<Customer>()
             .HasOne(c => c.EmptyStorageTariff)
             .WithOne(t => t.Customer)
             .HasForeignKey<EmptyStorageTariff>(t => t.CustomerId);

              modelBuilder.Entity<Customer>()
             .HasOne(c => c.FullStorageTariff)
             .WithOne(t => t.Customer)
             .HasForeignKey<FullStorageTariff>(t => t.CustomerId);

              modelBuilder.Entity<Customer>()
             .HasOne(c => c.ServicesTariff)
             .WithOne(t => t.Customer)
             .HasForeignKey<ServicesTariff>(t => t.CustomerId);

              modelBuilder.Entity<Customer>()
             .HasOne(c => c.PackageServicesTariff)
             .WithOne(t => t.Customer)
             .HasForeignKey<PackageServicesTariff>(t => t.CustomerId);

            modelBuilder.Entity<EmptyStorageTariff>().Property(x => x.Active).HasDefaultValue(true);
            modelBuilder.Entity<FullStorageTariff>().Property(x => x.Active).HasDefaultValue(true);
            modelBuilder.Entity<ServicesTariff>().Property(x => x.Active).HasDefaultValue(true);
            modelBuilder.Entity<PackageServicesTariff>().Property(x => x.Active).HasDefaultValue(true);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }

    }
}
