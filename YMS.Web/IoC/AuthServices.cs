using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using YMS.Core.Enums;

namespace YMS.Web.IoC
{
    public static class AuthServices
    {
        public static IServiceCollection AddAuthServices(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtIssuer = Environment.GetEnvironmentVariable(EnvironmentVariablesEnum.JWT_ISSUER.ToString()) ?? configuration["Jwt:Issuer"];
            var jwtAudience = Environment.GetEnvironmentVariable(EnvironmentVariablesEnum.JWT_AUDIENCE.ToString()) ?? configuration["Jwt:Audience"];
            var jwtSigningKey = Environment.GetEnvironmentVariable(EnvironmentVariablesEnum.JWT_KEY.ToString()) ?? configuration["Jwt:Key"];
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.FromMinutes(0),
                    ValidIssuer = jwtIssuer,
                    ValidAudience = jwtAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSigningKey))
                };
            });

            return services;
        }
    }
}
