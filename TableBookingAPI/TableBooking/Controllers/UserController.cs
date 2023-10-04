using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using IdentityServer4.Services;
using ISynergy.Framework.AspNetCore.Abstractions.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TableBooking.Constants;
using TableBooking.DTOs;
using TableBooking.Model;

namespace TableBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly IClaimsService claimsService;
        private readonly IJwtTokenService jwtTokenService;

        public UserController(
            UserManager<AppUser> userManager, 
            RoleManager<AppRole> roleManager,
            IClaimsService claimsService,
            IJwtTokenService jwtTokenService)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.claimsService = claimsService;
            this.jwtTokenService = jwtTokenService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO userRegisterDTO)
        {
            IdentityResult result;
            AppUser newUser = new()
            {
                Email = userRegisterDTO.Email,
                UserName = userRegisterDTO.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            result = await userManager.CreateAsync(newUser, userRegisterDTO.Password);
            if (!result.Succeeded)
                return Conflict(new UserRegisterResultDTO
                {
                    Succeeded = result.Succeeded,
                    Errors = result.Errors.Select(e => e.Description)
                });
            await SeedRoles();
            result = await userManager.CreateAsync(newUser, UserRoles.User);
            return CreatedAtAction(nameof(Register), new UserRegisterResultDTO { Succeeded = true });
             
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLoginDTO)
        {
            var user = await userManager.FindByEmailAsync(userLoginDTO.Email);
            
            if (user != null && await userManager.CheckPasswordAsync(user, userLoginDTO.Password))
            {
                //var userClaims = await claimsService.GetUserClaimsAsync(user);
                await HttpContext.SignInAsync(new ClaimsPrincipal(
                    new ClaimsIdentity(
                        new Claim[]
                        {
                            new Claim(ClaimTypes.Email, Guid.NewGuid().ToString()) // Globally Unique Identifier
                        })
                ));
               
                var token = jwtTokenService.GetJwtToken(userClaims);

                return Ok(new UserLoginResultDTO
                {
                    Succeeded = true,
                    Token = new TokenDTO
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                    }
                });
            }

            return Unauthorized();
        }
        private async Task SeedRoles()
        {
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new AppRole(UserRoles.Admin));

            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new AppRole(UserRoles.User));
        }
    }
}
