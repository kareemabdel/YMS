using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS.Migrations.Data;

namespace YMS.Migrations.Repositories.Users
{
    public class UserRepository : Repository<Entities.User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Entities.User> GetUserByUsername(string username)
        {
            return await context.Users.SingleOrDefaultAsync(u => u.Username == username);
        }
    }
}
