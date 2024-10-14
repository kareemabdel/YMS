using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS.Migrations.Entities;

namespace YMS.Core.Services.AuthenticationService
{
    public interface IRefreshTokenService
    {
        Task<bool> SaveRefreshToken(RefreshToken refreshToken);
        Task<RefreshToken> GetStoredRefreshToken(string refreshToken);

        Task<bool> RemoveRefreshToken(string refreshToken);
    }
}
