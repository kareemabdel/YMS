using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using YMS.Core.Models.AuthenticationModels;
using YMS.Core.Models.Authentications;
using YMS.Core.Models;

namespace YMS.Core.Services.AuthenticationService
{
    public interface ITokenService
    {
        Task<LoginResponseDTO> Authenticate([FromBody] LoginDTO login);

        Task<LoginResponseDTO> GenerateToken(TokenRequestDTO request);

        Task<bool> Logout(TokenRequestDTO model);
    }
}
