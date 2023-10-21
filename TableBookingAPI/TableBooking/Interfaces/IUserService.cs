using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TableBooking.DTOs;

namespace TableBooking.Api.Interfaces
{
    public interface IUserService
    {
        public Task<IActionResult> Register(UserRegisterDTO userRegisterDTO);
        public Task<IActionResult> Login(UserLoginDTO userLoginDTO);
        public JwtSecurityToken GetToken(List<Claim> authClaims);
        public Task SeedRoles();
    }
}
