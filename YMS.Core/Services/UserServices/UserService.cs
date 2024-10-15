using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS.Core.Models.Users;
using YMS.Migrations.Entities;
using YMS.Migrations.UnitOfWorks;

namespace YMS.Core.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserCredentialsDTO> GetUserByUsername(string username)
        {
            try
            {
                var user = await _unitOfWork.UsersRepo.GetUserByUsername(username);

                if (user == null)
                {
                    return null;
                }

                return _mapper.Map<UserCredentialsDTO>(user);

                //return new UserCredentialsDTO { Username = user.Username, Password = user.Password, BranchId = user.BranchId };
            }
            catch (Exception ex) 
            {
                return null;
            }
        }
    }
}
