using animal.adoption.api.Extensions;
using animal.adoption.api.Infrastructure;
using animal.adoption.api.Infrastructure.Repository;
using animal.adoption.api.Models;
using animal.adoption.api.Services.Implementation;
using animal.adoption.api.Services.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NLog.Extensions.Logging;
using Microsoft.EntityFrameworkCore.SqlServer;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;



var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container...
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(x => x.AddProfile(new MappingEntity()));
builder.Services.ConfigureCors();
builder.Services.ConfigureJWTService();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureDataProtectionTokenProvider();


builder.Services.AddTransient<IJwtHandler, JwtHandler>();
builder.Services.AddTransient<IValidationCommon, ValidationCommon>();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient<IPetService, PetService>();

   

builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

builder.Services.AddDbContext<AnimalAdoptionDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<USER, USER_ROLE>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
})
.AddRoles<USER_ROLE>()
.AddEntityFrameworkStores<AnimalAdoptionDbContext>()
.AddDefaultTokenProviders();

//Logs
builder.Host.ConfigureLogging((hostingContext, logging) =>
{
    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
    logging.AddDebug();
    logging.AddNLog();
});



var app = builder.Build();
AppContext.SetSwitch("SqlServer.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureCustomExceptionMiddleware();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
//app.UseClientRateLimiting();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCookiePolicy();
app.MapControllers();
app.Run();
