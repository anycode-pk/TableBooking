using System.Configuration;
using Google;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using TableBooking.EF;
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

builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>(); // 3 cykle poczytaj

var app = builder.Build();

// Configure the HTTP request pipeline.
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