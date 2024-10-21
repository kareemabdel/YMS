using Microsoft.EntityFrameworkCore;
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
        public DbSet<PackageType> PackageTypes { get; set; }
        public DbSet<Basis> Basises { get; set; }
        public DbSet<StorageType> StorageTypes { get; set; }
        public DbSet<Vessel> Vessels { get; set; }
        public DbSet<Transporter> Transporters { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<ContainerType> ContainerTypes { get; set; }
        public DbSet<Container> Containers { get; set; }
        public DbSet<ContainerTransaction> ContainerTransactions { get; set; }
        public DbSet<Tariff> Tariffs { get; set; }
        public DbSet<TariffService> TariffServices { get; set; }
        public DbSet<TariffData> TariffData { get; set; }
        public DbSet<Line> Lines { get; set; }

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

            modelBuilder.Entity<ContainerTransaction>().HasOne(g => g.Container).WithMany(p => p.ContainerTransactions).HasForeignKey(p => p.ContainerId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ContainerTransaction>().HasOne(g => g.Customer).WithMany(p => p.ContainerTransactions).HasForeignKey(p => p.CustomerId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Tariff>().Property(x => x.Active).HasDefaultValue(true);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}
