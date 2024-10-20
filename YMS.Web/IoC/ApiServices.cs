using Microsoft.AspNetCore.Localization;
using System.Globalization;
using YMS.Core.Configurations;
using YMS.Core.Mapping;
using YMS.Core.Services.AuthenticationService;
using YMS.Core.Services.UserServices;
using YMS.Migrations.Repositories.Customers;
using YMS.Migrations.Repositories.Users;
using YMS.Migrations.UnitOfWorks;
using YMS.Web.Filters;

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

            services.AddAutoMapper(typeof(MappingProfile));
            services.AddAuthServices(configuration);

            // Add services to the container.
            services.AddScoped<ValidateBranchIdFilter>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IContainerTransactionRepository, ContainerTransactionRepository>();
            services.AddScoped<AppConfigurations>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IRefreshTokenService, RefreshTokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IContainerTransactionService, ContainerTransactionService>();

            services.AddHttpContextAccessor();
            // services.AddApplicationInsightsTelemetry();

            services.AddSwaggerService();

            return services;
        }
    }
}
