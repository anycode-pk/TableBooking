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

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to postgres with connection string from app settings
        options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
    }
    
    // public async Task<Restaurant> DeleteRestaurant(int restaurantId)
    // {
    //     var result = await Configuration.
    //         .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
    //     if (result != null)
    //     {
    //         appDbContext.Employees.Remove(result);
    //         await appDbContext.SaveChangesAsync();
    //         return result;
    //     }
    //
    //     return null;
    // }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Table> Tables { get; set; }
}