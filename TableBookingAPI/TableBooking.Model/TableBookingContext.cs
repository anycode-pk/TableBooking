namespace TableBooking.Model;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

public class TableBookingContext : IdentityDbContext<AppUser>
{
    public TableBookingContext() { }
    public TableBookingContext(DbContextOptions<TableBookingContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=TableBookingDB;Username=TableBookingUser;Password=postgres");
        }
    }

    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Table> Tables { get; set; }
}