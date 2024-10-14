using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS.Migrations.Entities;

namespace YMS.Migrations.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Seed data for Countries
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Code = "SA", NameAr = "المملكة العربية السعودية", NameEn = "SAUDI ARABIA" }
            ); 
            
            modelBuilder.Entity<Currency>().HasData(
                new Currency { Id = 1, Code = "SAR", NameAr = "ريال سعودي", NameEn = "Saudi Riyal", ExchangeRate = 3.75 }
            );

            // Seed data for Cities
            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Code = "JEDDA", Name = "JEDDAH PLANT", CountryId = 1 },
                new City { Id = 2, Code = "JUBAI", Name = "JUBAIL PLANT", CountryId = 1 }
            );

            var branchId1 = Guid.NewGuid();
            var branchId2 = Guid.NewGuid();

            modelBuilder.Entity<Branch>().HasData(
                new Branch { Id = branchId1, Code = "JEDDAH", Name = "JEDDAH", CityId = 1 },
                new Branch { Id = branchId2, Code = "DAMMAM", Name = "DAMMAM", CityId = 2 }
            );

            modelBuilder.Entity<Service>().HasData(
                new Service { Id = 1, Name = "Clean Unit"},
                new Service { Id = 2, Name = "Cleaning" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = Guid.NewGuid(), Name = "test", Username = "test", Password = "123456", BranchId = branchId1 }
            );
        }
    }
}
