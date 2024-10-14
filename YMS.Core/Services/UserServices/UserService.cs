﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS.Core.Models.Users;
using YMS.Migrations.UnitOfWorks;

namespace YMS.Core.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserCredentialsModel> GetUserByUsername(string username)
        {
            try
            {
                var user = await _unitOfWork.UsersRepo.GetUserByUsername(username);

                if (user == null)
                {
                    return null;
                }

                return new UserCredentialsModel { Username = user.Username, Password = user.Password, BranchId = user.BranchId };
            }
            catch (Exception ex) 
            {
                return null;
            }
        }
    }
}