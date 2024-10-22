using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YMS.Migrations.Data;
using YMS.Migrations.Entities;
using YMS.Migrations.Entities.Lookups;

namespace YMS.Migrations.Repositories.Customers
{
    public class LookupRepository :  ILookupRepository
    {
        private readonly AppDbContext context;
        public LookupRepository(AppDbContext context)
        {
            this.context = context;
        }

        public List<Basis> GetBasises()
        {
            return context.Basises.Where(e=>!e.IsDeleted).ToList();
        }

        public List<City> GetCities(int countryId)
        {
            return context.Cities.Where(e => !e.IsDeleted && e.CountryId==countryId).ToList();
        }

        public List<ContainerType> GetContainerTypes()
        {
            return context.ContainerTypes.Where(e => !e.IsDeleted).ToList();
        }

        public List<Country> GetContries()
        {
            return context.Countries.Where(e => !e.IsDeleted).ToList();
        }

        public List<Currency> GetCurrencies()
        {
            return context.Currencies.Where(e => !e.IsDeleted).ToList();
        }

        public List<Line> GetLines()
        {
            return context.Lines.Where(e => !e.IsDeleted).ToList();
        }

        public List<Service> GetServices()
        {
            return context.Services.Where(e => !e.IsDeleted).ToList();
        }
    }
}
