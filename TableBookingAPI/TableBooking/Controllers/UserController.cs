using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
        private readonly IConfiguration configuration;

        public UserController(
            UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager,
            IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO userRegisterDTO)
        {
            var userExists = await userManager.FindByNameAsync(userRegisterDTO.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new ResultDTO { Status = "Error", Message = "User already exists!" });

            var user = new AppUser()
            {
                Email = userRegisterDTO.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = userRegisterDTO.Username
            };
            var result = await userManager.CreateAsync(user, userRegisterDTO.Password);
            if (!result.Succeeded)
                return new BadRequestObjectResult("Invalid password lenght");

            return Ok(new ResultDTO { Status = "Success", Message = "User created successfully!" });

            //IdentityResult result;
            //AppUser newUser = new()
            //{
            //    Email = userRegisterDTO.Email,
            //    UserName = userRegisterDTO.Email,
            //    SecurityStamp = Guid.NewGuid().ToString(),
            //};
            //result = await userManager.CreateAsync(newUser, userRegisterDTO.Password);
            //if (!result.Succeeded)
            //    return Conflict(new UserRegisterResultDTO
            //    {
            //        Succeeded = result.Succeeded,
            //        Errors = result.Errors.Select(e => e.Description)
            //    });
            //await SeedRoles();
            //result = await userManager.CreateAsync(newUser, UserRoles.User);
            //return CreatedAtAction(nameof(Register), new UserRegisterResultDTO { Succeeded = true });
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLoginDTO)
        {
            var user = await userManager.FindByNameAsync(userLoginDTO.Username);
            if (!(user != null || await userManager.CheckPasswordAsync(user, userLoginDTO.Password)))
            {
                return Unauthorized();
            }

            //    var userRoles = await userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            //foreach (var userRole in userRoles)
            //{
            //    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            //}

            var token = GetToken(authClaims);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });


            //var user = await userManager.FindByEmailAsync(userLoginDTO.Email);

            //if (user != null && await userManager.CheckPasswordAsync(user, userLoginDTO.Password))
            //{
            //    //var userClaims = await claimsService.GetUserClaimsAsync(user);
            //    await HttpContext.SignInAsync(new ClaimsPrincipal(
            //        new ClaimsIdentity(
            //            new Claim[]
            //            {
            //                new Claim(ClaimTypes.Email, Guid.NewGuid().ToString()) // Globally Unique Identifier
            //            })
            //    ));

            //   // var token = jwtTokenService.GetJwtToken(userClaims);

            //    return Ok(new UserLoginResultDTO
            //    {
            //        Succeeded = true,
            //        Token = new TokenDTO
            //        {
            //           // Token = new JwtSecurityTokenHandler().WriteToken(token),
            //        }
            //    });
            //}

            //return Unauthorized(); // 401
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
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
