using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem() {Text = "Admin", Value="admin"},
                new SelectListItem() {Text = "Customer", Value="customer"},
            };

            ViewBag.RoleList = roleList;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequestDto registrationRequestDto)
        {
            var result = await _authService.RegisterAsync(registrationRequestDto);

            if (result is not null && result.IsSuccessful)
            {
                TempData["success"] = "Registration is Successfuly";
                return RedirectToAction(nameof(Login));
            }
            
            TempData["error"] = result?.Error?.Errors.First().ToString();

            var roleList = new List<SelectListItem>()
            {
                new SelectListItem() {Text = "Admin", Value="admin"},
                new SelectListItem() {Text = "Customer", Value="customer"},
            };

            ViewBag.RoleList = roleList;
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
