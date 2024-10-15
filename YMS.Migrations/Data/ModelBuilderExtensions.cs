using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

            var branchId1 = new Guid("0a534cad-cce7-422b-b79b-b38f3ea1a918");
            var branchId2 = new Guid("1dffb2d6-88ac-4ecd-901e-f9e3cd44633c");

            modelBuilder.Entity<Branch>().HasData(
                new Branch { Id = branchId1, Code = "JEDDAH", Name = "JEDDAH", CityId = 1 },
                new Branch { Id = branchId2, Code = "DAMMAM", Name = "DAMMAM", CityId = 2 }
            );

            modelBuilder.Entity<Service>().HasData(
                new Service { Id = 1, Name = "Clean Unit"},
                new Service { Id = 2, Name = "Cleaning" }
            );

            modelBuilder.Entity<FullStorageDataType>().HasData(
                new FullStorageDataType { Id = 1, Name = "FullStorageDataType1" },
                new FullStorageDataType { Id = 2, Name = "FullStorageDataType2" }
            );

            modelBuilder.Entity<Basis>().HasData(
                new Basis { Id = 1, Name = "Per Size" },
                new Basis { Id = 2, Name = "Per Unit" }
            );

            modelBuilder.Entity<PackageType>().HasData(
                new PackageType { Id = 1, Name = "Box" },
                new PackageType { Id = 2, Name = "Bags" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = new Guid("3b362655-5ade-4978-826e-0ec0edbfc31b"), Name = "test", Username = "test", Password = "123456", BranchId = branchId1 }
            );
        }
    }
}
