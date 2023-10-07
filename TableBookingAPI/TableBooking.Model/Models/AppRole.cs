using Microsoft.AspNetCore.Identity;
using System.Drawing;

namespace TableBooking.Model
{
    public class AppRole : IdentityRole
    {
        public AppRole(string roleName)
        {
            Name = roleName;
        }
    }
}
