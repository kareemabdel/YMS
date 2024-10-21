using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using YMS.Core.Configurations;
using YMS.Core.Models;
using YMS.Core.Models.AuthenticationModels;
using YMS.Core.Models.Authentications;
using YMS.Core.Services.UserServices;
using YMS.Migrations.Entities;

namespace YMS.Core.Services.AuthenticationService
{
    public class TokenService : ITokenService
    {
        private readonly IUserService _userService;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly AppConfigurations _configurations;
        ILogger<TokenService> _logger;
        public TokenService(IUserService userService, AppConfigurations configurations,
            IRefreshTokenService refreshTokenService, ILogger<TokenService> logger)
        {
            _userService = userService;
            _configurations = configurations;
            _refreshTokenService = refreshTokenService;
            _logger = logger;
        }

        public async Task<ApiResponse<LoginResponseDTO>> Authenticate([FromBody] LoginDTO DTO)
        {
            var apiResponse = new ApiResponse<LoginResponseDTO>();
            try
            {
                var user = await _userService.GetUserByUsername(DTO.Username);

                if (user == null || DTO.Password != user.Password)
                {
                    _logger.LogError("Invalid username or password");
                    apiResponse.StatusCode = HttpStatusCode.BadRequest;
                    apiResponse.Errors = "Invalid username or password";
                    return apiResponse;
                }

                // Create claims for the JWT token
                var claims = new List<Claim>
                {
                new Claim(JwtRegisteredClaimNames.Sub, DTO.Username),
                new Claim("BranchId", @$"{user.BranchId}")
                };

                var accessToken = GenerateAccessToken(claims);
                var refreshToken = GenerateRefreshToken();

                // Save or update the refresh token in the database
                await _refreshTokenService.SaveRefreshToken(new RefreshToken
                {
                    Token = refreshToken,
                    Username = DTO.Username,
                    ExpirationDate = DateTime.Now.AddDays(Convert.ToInt32(_configurations.JwtKeyRefreshTokenExpirationDays))
                });

                apiResponse.StatusCode = HttpStatusCode.OK;
                apiResponse.Data = new LoginResponseDTO { AccessToken = accessToken, RefreshToken = refreshToken };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in Authenticate: {ex.Message}", ex);
                apiResponse.StatusCode = HttpStatusCode.BadRequest;
                apiResponse.Errors = ex.Message;
            }

            return apiResponse;
        }

        public async Task<ApiResponse<LoginResponseDTO>> GenerateToken(TokenRequestDTO request)
        {
            var apiResponse = new ApiResponse<LoginResponseDTO>();
            try
            {
                // Validate the refresh token (retrieve the stored refresh token from the database)
                var storedRefreshToken = await _refreshTokenService.GetStoredRefreshToken(request.RefreshToken);

                if (storedRefreshToken == null || storedRefreshToken.ExpirationDate < DateTime.Now)
                {
                    _logger.LogError("Invalid or expired refresh token");
                    apiResponse.StatusCode = HttpStatusCode.NotFound;
                    apiResponse.Errors = "Invalid or expired refresh token.";
                    return apiResponse;
                }

                var user = await _userService.GetUserByUsername(storedRefreshToken.Username);

                var claims = new[]
                   {
                new Claim(JwtRegisteredClaimNames.Sub, storedRefreshToken.Username),
                new Claim("BranchId", @$"{user.BranchId}")
                };

                var newAccessToken = GenerateAccessToken(claims);
                var newRefreshToken = GenerateRefreshToken();

                // Update the stored refresh token
                storedRefreshToken.Token = newRefreshToken;
                storedRefreshToken.ExpirationDate = DateTime.Now.AddDays(Convert.ToInt32(_configurations.JwtKeyRefreshTokenExpirationDays));
                await _refreshTokenService.SaveRefreshToken(storedRefreshToken);

                apiResponse.StatusCode = HttpStatusCode.OK;
                apiResponse.Data = new LoginResponseDTO { AccessToken = newAccessToken, RefreshToken = newRefreshToken };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GenerateToken: {ex.Message}", ex);

                apiResponse.StatusCode = HttpStatusCode.BadRequest;
                apiResponse.Errors = ex.Message;
            }

            return apiResponse;
        }

        public async Task<ApiResponse<bool>> Logout(TokenRequestDTO DTO)
        {
            var apiResponse = new ApiResponse<bool>();

            try
            {
                var isDeleted = await _refreshTokenService.RemoveRefreshToken(DTO.RefreshToken);

                if (!isDeleted)
                {
                    _logger.LogError("RefreshToken is invalid or something went wrong during process.");
                    apiResponse.StatusCode = HttpStatusCode.BadRequest;
                    apiResponse.Errors = "RefreshToken is invalid or something went wrong during process";
                    return apiResponse;
                }

                apiResponse.StatusCode = HttpStatusCode.OK;
                apiResponse.Data = true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in Logout: {ex.Message}", ex);

                apiResponse.StatusCode = HttpStatusCode.BadRequest;
                apiResponse.Errors = ex.Message;
            }

            return apiResponse;
        }

        #region Private methoeds
        private string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configurations.JwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configurations.JwtIssuer,
                audience: _configurations.JwtAudience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configurations.JwtAccessTokenExpirationMinutes)),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
        #endregion
    }
}
