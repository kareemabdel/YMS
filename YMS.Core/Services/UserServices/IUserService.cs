using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS.Core.Models.Users;

namespace YMS.Core.Services.UserServices
{
    public interface IUserService
    {
        Task<UserCredentialsDTO> GetUserByUsername(string username);
    }
}
