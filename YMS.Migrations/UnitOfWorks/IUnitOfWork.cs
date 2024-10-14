using Microsoft.EntityFrameworkCore;
using System;
using YMS.Migrations.Entities;
using YMS.Migrations.Repositories;
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

        DbContext contextForTransaction { get; }

        Task<bool> Save();
    }
}
