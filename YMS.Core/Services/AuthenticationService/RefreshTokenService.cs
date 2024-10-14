using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS.Core.Models.RefreshTokens;
using YMS.Migrations.Entities;
using YMS.Migrations.UnitOfWorks;

namespace YMS.Core.Services.AuthenticationService
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RefreshTokenService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RefreshToken> GetStoredRefreshToken(string refreshToken)
        {
            return await _unitOfWork.RefreshTokensRepo.GetRefreshToken(refreshToken);
        }

        public async Task<bool> SaveRefreshToken(RefreshToken refreshToken)
        {
            if (refreshToken.Id == 0)
            {
                await _unitOfWork.RefreshTokensRepo.Insert(refreshToken);
            }
            else
            {
                await _unitOfWork.RefreshTokensRepo.Update(refreshToken);
            }

            return await _unitOfWork.Save();
        }
        
        public async Task<bool> RemoveRefreshToken(string refreshToken)
        {
            var tokenModel = await GetStoredRefreshToken(refreshToken);

            if(tokenModel != null)
            {
                await _unitOfWork.RefreshTokensRepo.Delete(tokenModel);
                return await _unitOfWork.Save();
            }

            return false;
        }
    }
}
