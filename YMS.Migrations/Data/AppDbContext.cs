using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS.Migrations.Entities;

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

            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }

    }
}
