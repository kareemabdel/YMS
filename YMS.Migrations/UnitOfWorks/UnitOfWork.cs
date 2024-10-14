using Microsoft.EntityFrameworkCore;
using System;
using YMS.Migrations.Data;
using YMS.Migrations.Entities;
using YMS.Migrations.Repositories;
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


        private IRefreshTokenRepository _RefreshTokensRepo;
        public IRefreshTokenRepository RefreshTokensRepo
        {
            get
            {
                return this._RefreshTokensRepo = this._RefreshTokensRepo ?? new RefreshTokenRepository(context);
            }
        }

        private IRepository<Customer> _CustomersRepo;
        public IRepository<Customer> CustomersRepo
        {
            get
            {
                return this._CustomersRepo = this._CustomersRepo ?? new Repository<Customer>(context);
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

        private IRepository<EmptyStorageTariff> _EmptyStorageTariffsRepo;
        public IRepository<EmptyStorageTariff> EmptyStorageTariffsRepo
        {
            get
            {
                return this._EmptyStorageTariffsRepo = this._EmptyStorageTariffsRepo ?? new Repository<EmptyStorageTariff>(context);
            }
        }

        private IRepository<EmptyStorageTariffData> _EmptyStorageTariffDataListRepo;
        public IRepository<EmptyStorageTariffData> EmptyStorageTariffDataListRepo
        {
            get
            {
                return this._EmptyStorageTariffDataListRepo = this._EmptyStorageTariffDataListRepo ?? new Repository<EmptyStorageTariffData>(context);
            }
        }

        private IRepository<FullStorageTariff> _FullStorageTariffsRepo;
        public IRepository<FullStorageTariff> FullStorageTariffsRepo
        {
            get
            {
                return this._FullStorageTariffsRepo = this._FullStorageTariffsRepo ?? new Repository<FullStorageTariff>(context);
            }
        }

        private IRepository<FullStorageTariffData> _FullStorageTariffDataListRepo;
        public IRepository<FullStorageTariffData> FullStorageTariffDataListRepo
        {
            get
            {
                return this._FullStorageTariffDataListRepo = this._FullStorageTariffDataListRepo ?? new Repository<FullStorageTariffData>(context);
            }
        }

        private IRepository<ServicesTariff> _ServicesTariffsRepo;
        public IRepository<ServicesTariff> ServicesTariffsRepo
        {
            get
            {
                return this._ServicesTariffsRepo = this._ServicesTariffsRepo ?? new Repository<ServicesTariff>(context);
            }
        }

        private IRepository<ServiceTariffData> _ServicesTariffDataListRepo;
        public IRepository<ServiceTariffData> ServicesTariffDataListRepo
        {
            get
            {
                return this._ServicesTariffDataListRepo = this._ServicesTariffDataListRepo ?? new Repository<ServiceTariffData>(context);
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
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
