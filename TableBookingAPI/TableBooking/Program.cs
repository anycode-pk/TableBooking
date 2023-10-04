using System.Configuration;
using System.Reflection;
using System.Text;
using Google;
using Google.Api;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using TableBooking.EF;
using TableBooking.Model;
using TableBooking.Repository;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("cors", corsPolicyBuilder =>
{
    corsPolicyBuilder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Host.UseSerilog((builderContext, loggerConfiguration) =>
{
    loggerConfiguration.ReadFrom.Configuration(builderContext.Configuration);
});

builder.Services.AddDbContext<DataContext>(o =>
{
    var connectionString = builder.Configuration.GetConnectionString("WebApiDatabase");
    o.UseNpgsql(connectionString);
});

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<DbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.User.RequireUniqueEmail = true;
});

builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("cors");
app.UseHttpsRedirection();
app.UseSerilogRequestLogging();
app.UseAuthorization();
app.MapControllers();
app.Run();