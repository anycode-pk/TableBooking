using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Npgsql;
using System.Text;
using TableBooking.Model;
using TableBooking.Repository;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TableBooking API",
        Version = "v1",
        Description = "Application created by .Net Group Koszalin University of Technology",
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer",
                        }
                    },
                    new string[] { }
                }
                });

    //var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

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
    var connectionString = builder.Configuration.GetConnectionString("TableBookingConnStr");
    o.UseNpgsql(connectionString);
});

builder.Services.AddIdentity<AppUser, AppRole>(x =>
{
    x.Password.RequireDigit = false;
    x.Password.RequiredLength = 2;
    x.Password.RequireUppercase = false;
    x.Password.RequireLowercase = false;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequiredUniqueChars = 0;
    x.Lockout.AllowedForNewUsers = true;
    x.Lockout.MaxFailedAccessAttempts = 5;
    x.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
    x.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<DataContext>()
.AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});

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

public partial class Program { }