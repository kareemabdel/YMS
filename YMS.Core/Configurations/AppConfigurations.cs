using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS.Core.Enums;

namespace YMS.Core.Configurations
{
    public class AppConfigurations
    {
        private readonly IConfiguration _config;

        public string JwtIssuer { get; init; }
        public string JwtAudience { get; init; }
        public string JwtKey { get; init; }
        public string JwtAccessTokenExpirationMinutes { get; init; }
        public string JwtKeyRefreshTokenExpirationDays { get; init; }

        public AppConfigurations(IConfiguration config)
        {
            _config = config;
            JwtIssuer = Environment.GetEnvironmentVariable(EnvironmentVariablesEnum.JWT_ISSUER.ToString()) ?? _config["Jwt:Issuer"];
            JwtAudience = Environment.GetEnvironmentVariable(EnvironmentVariablesEnum.JWT_AUDIENCE.ToString()) ?? _config["Jwt:Audience"];
            JwtKey = Environment.GetEnvironmentVariable(EnvironmentVariablesEnum.JWT_KEY.ToString()) ?? _config["Jwt:Key"];
            JwtAccessTokenExpirationMinutes = Environment.GetEnvironmentVariable(EnvironmentVariablesEnum.JWT_ACCESS_TOKEN_EXPIRATION_MINUTES.ToString()) ?? _config["Jwt:AccessTokenExpirationMinutes"];
            JwtKeyRefreshTokenExpirationDays = Environment.GetEnvironmentVariable(EnvironmentVariablesEnum.JWT_REFRESH_TOKEN_EXPIRATION_DAYS.ToString()) ?? _config["Jwt:RefreshTokenExpirationDays"];
        }
    }
}
