using TableBooking.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TableBooking.EF;

using Microsoft.EntityFrameworkCore;

public class DataContext : IdentityDbContext<AppUser>
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Table> Tables { get; set; }
}