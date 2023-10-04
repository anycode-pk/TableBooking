using System.Configuration;
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

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("cors", corsPolicyBuilder =>
{
    corsPolicyBuilder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var connectionString = builder.Configuration["ConnectionStrings:WebApiDatabase"];
var npgsqlBuilder = new NpgsqlConnectionStringBuilder(connectionString);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(
        npgsqlBuilder.ConnectionString));

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
app.UseAuthorization();
app.MapControllers();
app.Run();