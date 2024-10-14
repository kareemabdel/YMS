using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS.Migrations.Data;
using YMS.Migrations.Entities;

namespace YMS.Migrations.Repositories.Users
{
    public class RefreshTokenRepository : Repository<Entities.RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<RefreshToken> GetRefreshToken(string refreshToken)
        {
            return await context.RefreshTokens.SingleOrDefaultAsync(u => u.Token == refreshToken);
        }
    }
}
