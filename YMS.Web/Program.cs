using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using YMS.Core.Configurations;
using YMS.Core.Enums;
using YMS.Core.Services.AuthenticationService;
using YMS.Core.Services.UserServices;
using YMS.Migrations.Data;
using YMS.Migrations.Repositories.Users;
using YMS.Migrations.UnitOfWorks;
using YMS.Web.Filters;
using YMS.Web.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers(options =>
{
    options.Filters.Add<UnifyResponseFilter>();
});
await builder.Services.AddApiServices(builder.Configuration);


//builder.Services.AddAuthorization();


var app = builder.Build();
var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
// Configure the HTTP request pipeline.
app.UseSwaggerPipeline(provider);
app.UseCors();

app.UseHttpsRedirection();

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapGet("/", async context =>
    {
        context.Response.Redirect("/swagger");
    });
});


app.Run();
