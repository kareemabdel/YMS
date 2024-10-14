using Microsoft.AspNetCore.Localization;
using System.Globalization;
using YMS.Core.Configurations;
using YMS.Core.Services.AuthenticationService;
using YMS.Core.Services.UserServices;
using YMS.Migrations.Repositories.Users;
using YMS.Migrations.UnitOfWorks;

namespace YMS.Web.IoC
{
    public static class ApiServices
    {
        public static async Task<IServiceCollection> AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            var hosts = configuration.GetSection("Cors:AllowedOrigins").Get<List<string>>();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(corsBuilder =>
                    corsBuilder.WithOrigins(hosts.ToArray())
                               .AllowAnyMethod()
                               .AllowAnyHeader()
                               .AllowCredentials());// Add this line
            });

            services.AddAuthServices(configuration);

            // Add services to the container.
           services.AddScoped<IUnitOfWork, UnitOfWork>();
           services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
           services.AddScoped<IUserRepository, UserRepository>();
           services.AddScoped<AppConfigurations>();
           services.AddScoped<ITokenService, TokenService>();
           services.AddScoped<IRefreshTokenService, RefreshTokenService>();
           services.AddScoped<IUserService, UserService>();

            services.AddHttpContextAccessor();
           // services.AddApplicationInsightsTelemetry();

            services.AddSwaggerService();

            return services;
        }
    }
}
