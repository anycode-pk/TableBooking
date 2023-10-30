using Microsoft.AspNetCore.Identity;

namespace TableBooking.Model.Models
{
    public class AppRole : IdentityRole<Guid>
    {
        public AppRole()
        {
        }
        public AppRole(string roleName)
        {
            Name = roleName;
        }
    }
}