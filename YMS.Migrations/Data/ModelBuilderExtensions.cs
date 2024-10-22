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
                new City { Id = 1, Code = "JEDDA", NameEn = "JEDDAH PLANT", CountryId = 1 },
                new City { Id = 2, Code = "JUBAI", NameEn = "JUBAIL PLANT", CountryId = 1 }
            );

            var branchId1 = new Guid("0a534cad-cce7-422b-b79b-b38f3ea1a918");
            var branchId2 = new Guid("1dffb2d6-88ac-4ecd-901e-f9e3cd44633c");

            modelBuilder.Entity<Branch>().HasData(
                new Branch { Id = branchId1, Code = "JEDDAH", NameEn = "JEDDAH", CityId = 1 },
                new Branch { Id = branchId2, Code = "DAMMAM", NameEn = "DAMMAM", CityId = 2 }
            );

            modelBuilder.Entity<Service>().HasData(
                new Service { Id = 1, NameEn = "Clean Unit"},
                new Service { Id = 2, NameEn = "Cleaning" }
            );

            modelBuilder.Entity<StorageType>().HasData(
                new StorageType { Id = 1, NameEn = "FullStorageDataType1" },
                new StorageType { Id = 2, NameEn = "FullStorageDataType2" }
            );

            modelBuilder.Entity<Basis>().HasData(
                new Basis { Id = 1, NameEn = "Per Size" },
                new Basis { Id = 2, NameEn = "Per Unit" }
            );

            modelBuilder.Entity<PackageType>().HasData(
                new PackageType { Id = 1, NameEn = "Box" },
                new PackageType { Id = 2, NameEn = "Bags" }
            );

            modelBuilder.Entity<Line>().HasData(
               new Line { Id = 1, NameEn = "AYE" },
               new Line { Id = 2, NameEn = "GMAC" }
           );

            modelBuilder.Entity<Transporter>().HasData(
              new Transporter { Id = 1,Code="NOFOOD01",NameEn = "NOFOOD",NameAr="النفوذ" },
             new Transporter { Id = 2, Code = "SHAFINA", NameEn = "ALSHAFINA", NameAr = "السفينة" }
          );
            modelBuilder.Entity<Vessel>().HasData(
             new Vessel { Id = 1, Code = "23729", NameEn = "ALAHMED", NameAr = "ALAHMED" },
            new Vessel { Id = 2, Code = "0018E", NameEn = "AS ALAXANDRIA"}
         );

            modelBuilder.Entity<Block>().HasData(
            new Block { Id = 1, Code = "C1", NameEn = "C1", NameAr = "C1" },
           new Block { Id = 2, Code = "C10", NameEn = "C10", NameAr = "C10" }
        );

            modelBuilder.Entity<User>().HasData(
                new User { Id = new Guid("3b362655-5ade-4978-826e-0ec0edbfc31b"), Name = "test", Username = "test", Password = "123456", BranchId = branchId1 }
            );
        }
    }
}
