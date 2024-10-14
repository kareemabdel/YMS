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

        //private IRepository _CustomersRepo;
        //public IRefreshTokenRepository CustomersRepo
        //{
        //    get
        //    {
        //        return this._CustomersRepo = this._CustomersRepo ?? new RefreshTokenRepository(context);
        //    }
        //}

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
