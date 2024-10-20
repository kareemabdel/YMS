using Microsoft.EntityFrameworkCore;
using System;
using YMS.Migrations.Data;
using YMS.Migrations.Entities;
using YMS.Migrations.Entities.Lookups;
using YMS.Migrations.Repositories;
using YMS.Migrations.Repositories.Customers;
using YMS.Migrations.Repositories.Users;

namespace YMS.Migrations.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        public AppDbContext context { get; }
        DbContext IUnitOfWork.contextForTransaction
        {
            get
            {
                return this.context;
            }
        }

        public UnitOfWork(AppDbContext _context)
        {
            this.context = _context;
        }

        private IUserRepository _UsersRepo;
        public IUserRepository UsersRepo
        {
            get
            {
                return this._UsersRepo = this._UsersRepo ?? new UserRepository(context);
            }
        }

        private ICustomerRepository _CustomersRepo;
        public ICustomerRepository CustomersRepo
        {
            get
            {
                return this._CustomersRepo = this._CustomersRepo ?? new CustomerRepository(context);
            }
        }

        private IContainerTransactionRepository _ContainerTransactionRepo;
        public IContainerTransactionRepository ContainerTransactionRepo
        {
            get
            {
                return this._ContainerTransactionRepo = this._ContainerTransactionRepo ?? new ContainerTransactionRepository(context);
            }
        }

        private IRefreshTokenRepository _RefreshTokensRepo;
        public IRefreshTokenRepository RefreshTokensRepo
        {
            get
            {
                return this._RefreshTokensRepo = this._RefreshTokensRepo ?? new RefreshTokenRepository(context);
            }
        }

        private IRepository<Country> _CountriesRepo;
        public IRepository<Country> CountriesRepo
        {
            get
            {
                return this._CountriesRepo = this._CountriesRepo ?? new Repository<Country>(context);
            }
        }
        
        private IRepository<City> _CitiesRepo;
        public IRepository<City> CitiesRepo
        {
            get
            {
                return this._CitiesRepo = this._CitiesRepo ?? new Repository<City>(context);
            }
        }
        
        private IRepository<Branch> _BranchesRepo;
        public IRepository<Branch> BranchesRepo
        {
            get
            {
                return this._BranchesRepo = this._BranchesRepo ?? new Repository<Branch>(context);
            }
        }

        private IRepository<Currency> _CurrenciesRepo;
        public IRepository<Currency> CurrenciesRepo
        {
            get
            {
                return this._CurrenciesRepo = this._CurrenciesRepo ?? new Repository<Currency>(context);
            }
        }

        private IRepository<Tariff> _TariffsRepo;
        public IRepository<Tariff> TariffsRepo
        {
            get
            {
                return this._TariffsRepo = this._TariffsRepo ?? new Repository<Tariff>(context);
            }
        }

        private IRepository<TariffData> _TariffDataRepo;
        public IRepository<TariffData> TariffDataRepo
        {
            get
            {
                return this._TariffDataRepo = this._TariffDataRepo ?? new Repository<TariffData>(context);
            }
        }

        private IRepository<TariffService> _TariffServicesRepo;
        public IRepository<TariffService> TariffServicesRepo
        {
            get
            {
                return this._TariffServicesRepo = this._TariffServicesRepo ?? new Repository<TariffService>(context);
            }
        }

        private IRepository<PackageServicesTariff> _PackageServicesTariffsRepo;
        public IRepository<PackageServicesTariff> PackageServicesTariffsRepo
        {
            get
            {
                return this._PackageServicesTariffsRepo = this._PackageServicesTariffsRepo ?? new Repository<PackageServicesTariff>(context);
            }
        }

        private IRepository<PackageServiceTariffData> _PackageServiceTariffDataListRepo;
        public IRepository<PackageServiceTariffData> PackageServiceTariffDataListRepo
        {
            get
            {
                return this._PackageServiceTariffDataListRepo = this._PackageServiceTariffDataListRepo ?? new Repository<PackageServiceTariffData>(context);
            }
        }

        public async Task<bool> Save()
        {
            try
            {
                return await context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true; ; ; ;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
