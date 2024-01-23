using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Services.AuthAPI.Models.Dtos;
using Restaurant.Services.AuthAPI.Services.Abstract;

namespace Restaurant.Services.AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IUserService _userService) : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> HealthCheck()
        {
            return Ok("Everything Okey");
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto registrationRequestDto)
        {
            var response = await _userService.RegisterUserAsync(registrationRequestDto);
            
            return Ok(response);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var response = await _userService.LoginUserAsync(loginRequestDto);

            return Ok(response);
        }

        [HttpPost("[action]/{userid}")]
        public async Task<IActionResult> AssignRoleToUser([FromBody] List<string> roles, [FromRoute] int userid)
        {
            var response = await _userService.AssignRoleToUserAsync(userid, roles);

            return Ok(response);
        }
    }
}
