using Microsoft.AspNetCore.Mvc;
using Restaurant.Web.Models.Dtos.Auths;
using Restaurant.Web.Services.Abstract;

namespace Restaurant.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDto loginRequestDto = new LoginRequestDto();

            return View(loginRequestDto);
        }

        [HttpGet]
        public IActionResult Register()
        {
            RegistrationRequestDto registrationRequestDto = new RegistrationRequestDto();

            return View(registrationRequestDto);
        }

        [HttpGet]
        public IActionResult AssignRoleToUser()
        {
           

            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {


            return View();
        }
    }
}
