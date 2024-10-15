using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using YMS.Core.Configurations;
using YMS.Core.Models.AuthenticationModels;
using YMS.Core.Models.Authentications;
using YMS.Core.Services.AuthenticationService;
using YMS.Core.Services.UserServices;
using YMS.Migrations.Entities;

namespace YMS.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthenticationController : BaseController
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly AppConfigurations _configurations;
        public AuthenticationController(ITokenService tokenService, IUserService userService, AppConfigurations configurations,
            IRefreshTokenService refreshTokenService)
        {
            _tokenService = tokenService;
            _userService = userService;
            _configurations = configurations;
            _refreshTokenService = refreshTokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            var response = await _tokenService.Authenticate(model);
            return GetAPIResponse(response);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenRequestDTO model)
        {
            var response = await _tokenService.GenerateToken(model);
            return GetAPIResponse(response);
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] TokenRequestDTO model)
        {
            var response = await _tokenService.Logout(model);
            return GetAPIResponse(response);
        }
    }
}
