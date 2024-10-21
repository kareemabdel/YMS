using Microsoft.EntityFrameworkCore;
using System;
using YMS.Migrations.Entities;
using YMS.Migrations.Entities.Lookups;
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
        IContainerTransactionRepository ContainerTransactionRepo { get; }
        IRepository<Tariff> TariffsRepo { get; }
        IRepository<TariffData> TariffDataRepo { get; }
        IRepository<TariffService> TariffServicesRepo { get; }

        IRepository<PackageServicesTariff> PackageServicesTariffsRepo { get; }
        IRepository<PackageServiceTariffData> PackageServiceTariffDataListRepo { get; }
        ILookupRepository LookupsRepo { get; }

        DbContext contextForTransaction { get; }

        Task<bool> Save();
    }
}
