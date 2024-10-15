using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using YMS.Core.Configurations;
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
        public TokenService(IUserService userService, AppConfigurations configurations,
            IRefreshTokenService refreshTokenService)
        {
            _userService = userService;
            _configurations = configurations;
            _refreshTokenService = refreshTokenService;
        }

        public async Task<LoginResponseDTO> Authenticate([FromBody] LoginDTO model)
        {
            var response = new LoginResponseDTO();
            try
            {
                var user = await _userService.GetUserByUsername(model.Username);

                if (user == null || model.Password != user.Password)
                {
                    response.IsSuccess = false;
                    response.Msg = "Invalid username or password";
                    return response;
                }

                // Create claims for the JWT token
                var claims = new List<Claim>
                {
                new Claim(JwtRegisteredClaimNames.Sub, model.Username),
                };

                if (user.BranchId != null)
                {
                    claims.Add(new Claim("BranchId", @$"{user.BranchId}"));
                }

                var accessToken = GenerateAccessToken(claims);
                var refreshToken = GenerateRefreshToken();

                // Save or update the refresh token in the database
                await _refreshTokenService.SaveRefreshToken(new RefreshToken
                {
                    Token = refreshToken,
                    Username = model.Username,
                    ExpirationDate = DateTime.Now.AddDays(Convert.ToInt32(_configurations.JwtKeyRefreshTokenExpirationDays))
                });

              
              return new LoginResponseDTO { IsSuccess=true,Msg="Loged in successfuly", AccessToken = accessToken, RefreshToken = refreshToken };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LoginResponseDTO> GenerateToken(TokenRequestDTO request)
        {
            var response = new LoginResponseDTO();
            try
            {
                // Validate the refresh token (retrieve the stored refresh token from the database)
                var storedRefreshToken = await _refreshTokenService.GetStoredRefreshToken(request.RefreshToken);

                if (storedRefreshToken == null || storedRefreshToken.ExpirationDate < DateTime.Now)
                {
                    response.IsSuccess = false;
                    response.Msg = "Invalid or expired refresh token.";
                    return response;
                   
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


                return new LoginResponseDTO { IsSuccess = true, Msg = "Refresh token successfuly", AccessToken = newAccessToken, RefreshToken = newRefreshToken };

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Logout(TokenRequestDTO model)
        {
            var response = new bool();

            try
            {
                var isDeleted = await _refreshTokenService.RemoveRefreshToken(model.RefreshToken);

                if (!isDeleted)
                {
                    throw new Exception("RefreshToken is invalid or something went wrong during process.");  
                }

              return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
