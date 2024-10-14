

using Asp.Versioning.ApiExplorer;

namespace YMS.Web.IoC
{
    public static class SwaggerPipeline
    {
        public static IApplicationBuilder UseSwaggerPipeline(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwaggerUi();

            app.UseOpenApi(options =>
            {
                options.PostProcess = (document, request) =>
                {
                    // Patch server URL for Swagger UI
                    var prefix = "/api/v" + document.Info.Version.Split('.')[0];
                    document.Servers.First().Url += prefix;
                };
            });

            return app;
        }

    }
}
