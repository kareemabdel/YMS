using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMS.Migrations.Repositories.Users
{
    public interface IRefreshTokenRepository : IRepository<Entities.RefreshToken>
    {
        Task<Entities.RefreshToken> GetRefreshToken(string refreshToken);
    }
}
