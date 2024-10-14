using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using NSwag.Generation.Processors.Security;
using NSwag;

namespace YMS.Web.IoC
{
    public static class SwaggerServices
    {
        public static IServiceCollection AddSwaggerService(this IServiceCollection services)
        {

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            })
       .AddApiExplorer(options =>
       {
           // Add the versioned API explorer, which also adds IApiVersionDescriptionProvider service
           // note: the specified format code will format the version as "'v'major[.minor][-status]"
           options.GroupNameFormat = "'v'VVV";

           // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
           // can also be used to control the format of the API version in route templates
           options.SubstituteApiVersionInUrl = true;
       });
            var versions = new[]
            {
                // Here you can control the minor version of each supported major version
                new Version(1, 0)
            };

            foreach (var version in versions)
            {
                services.AddOpenApiDocument(options =>
                {
                    options.Title = "YMS API";
                    options.Description = "Service info yard management system";

                    options.DocumentName = "YMSAPI_v" + version.Major;
                    options.ApiGroupNames = new string[] { "v" + version.Major };
                    options.Version = version.Major + "." + version.Minor;

                    //options.GenerateEnumMappingDescription = true;

                    options.AddSecurity("Bearer",
                       Enumerable.Empty<string>(),
                       new OpenApiSecurityScheme
                       {
                           Scheme = JwtBearerDefaults.AuthenticationScheme,
                           Type = OpenApiSecuritySchemeType.Http,
                           In = OpenApiSecurityApiKeyLocation.Header,
                           Name = "Authorization",
                           BearerFormat = "JWT",
                           Description = "Put **_ONLY_** your JWT Bearer token on textbox below!"
                       });
                    options.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("Bearer"));

                    // Patch document for Azure API Management
                    //  options.AllowReferencesWithProperties = true;
                    options.PostProcess = document =>
                    {
                        var prefix = "/api/v" + version.Major;
                        foreach (var pair in document.Paths.ToArray())
                        {
                            document.Paths.Remove(pair.Key);
                            document.Paths[pair.Key.Substring(prefix.Length)] = pair.Value;
                        }
                    };
                });
            }

            return services;
        }
    }
}
