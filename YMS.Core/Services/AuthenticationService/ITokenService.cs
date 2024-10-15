using Microsoft.AspNetCore.Mvc;
using YMS.Core.Models;
using YMS.Core.Models.AuthenticationModels;
using YMS.Core.Models.Authentications;


namespace YMS.Core.Services.AuthenticationService
{
    public interface ITokenService
    {
        Task<ApiResponse<LoginResponseDTO>> Authenticate([FromBody] LoginDTO login);

        Task<ApiResponse<LoginResponseDTO>> GenerateToken(TokenRequestDTO request);

        Task<ApiResponse<bool>> Logout(TokenRequestDTO DTO);
    }
}
