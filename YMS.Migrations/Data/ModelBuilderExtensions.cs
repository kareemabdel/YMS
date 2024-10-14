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

            // Seed data for Cities
            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Code = "JEDDA", Name = "JEDDAH PLANT", CountryId = 1 },
                new City { Id = 2, Code = "JUBAI", Name = "JUBAIL PLANT", CountryId = 1 }
            );

            modelBuilder.Entity<Branch>().HasData(
                new Branch { Id = 1, Code = "JEDDAH", Name = "JEDDAH", CityId = 1 },
                new Branch { Id = 2, Code = "DAMMAM", Name = "DAMMAM", CityId = 2 }
            );
            
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "test", Username = "test", Password = "123456", BranchId = 1 }
            );
        }
    }
}
