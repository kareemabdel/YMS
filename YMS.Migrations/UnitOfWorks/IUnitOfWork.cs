using Microsoft.EntityFrameworkCore;
using System;
using YMS.Migrations.Entities;
using YMS.Migrations.Repositories;
using YMS.Migrations.Repositories.Customers;
using YMS.Migrations.Repositories.Users;

namespace YMS.Migrations.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UsersRepo { get; }

        IRefreshTokenRepository RefreshTokensRepo { get; }
        IRepository<Country> CountriesRepo { get; }
        IRepository<City> CitiesRepo { get; }
        IRepository<Branch> BranchesRepo { get; }
        IRepository<Currency> CurrenciesRepo { get; }
        ICustomerRepository CustomersRepo { get; }
        IRepository<EmptyStorageTariff> EmptyStorageTariffsRepo { get; }
        IRepository<EmptyStorageTariffData> EmptyStorageTariffDataListRepo { get; }
        IRepository<FullStorageTariff> FullStorageTariffsRepo { get; }
        IRepository<FullStorageTariffData> FullStorageTariffDataListRepo { get; }

        IRepository<ServicesTariff> ServicesTariffsRepo { get; }
        IRepository<ServiceTariffData> ServicesTariffDataListRepo { get; }

        IRepository<PackageServicesTariff> PackageServicesTariffsRepo { get; }
        IRepository<PackageServiceTariffData> PackageServiceTariffDataListRepo { get; }

        DbContext contextForTransaction { get; }

        Task<bool> Save();
    }
}
