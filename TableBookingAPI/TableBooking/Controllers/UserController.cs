using Microsoft.AspNetCore.Mvc;
using TableBooking.Api.Services;
using TableBooking.DTOs;

namespace TableBooking.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO userRegisterDTO)
        {
            return await _userService.Register(userRegisterDTO);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLoginDTO)
        {
            return await _userService.Login(userLoginDTO);
        }
    }
}
