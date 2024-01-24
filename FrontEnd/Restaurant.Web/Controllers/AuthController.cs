using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurant.Web.Models.Dtos.Auths;
using Restaurant.Web.Services.Abstract;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace Restaurant.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ITokenProvider _tokenProvider;

        public AuthController(IAuthService authService, ITokenProvider tokenProvider)
        {
            _authService = authService;
            _tokenProvider = tokenProvider;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDto loginRequestDto = new LoginRequestDto();

            return View(loginRequestDto);
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginRequestDto loginRequestDto)
        {
            var result = await _authService.LoginAsync(loginRequestDto);

            if (result is not null && result.IsSuccessful)
            {
                _tokenProvider.SetToken(result?.Data?.AccessToken ?? "");
                SignInUser(result.Data);

                TempData["success"] = "Login is Successfuly";
                return RedirectToAction("Index", "Home");
            }

            TempData["error"] = result?.Error?.Errors.First().ToString();
            ModelState.AddModelError("CustomError", result.Error.Errors.First());

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
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            _tokenProvider.ClearToken();

            return RedirectToAction("Index", "Home");
        }


        private async Task SignInUser(LoginResponseDto loginResponseDto)
        {
            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.ReadJwtToken(loginResponseDto.AccessToken);

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, jwt.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value));
            identity.AddClaim(new Claim(ClaimTypes.Email, jwt.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value));
            identity.AddClaim(new Claim(ClaimTypes.Name, jwt.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value));
            identity.AddClaim(new Claim("name", jwt.Claims.FirstOrDefault(x => x.Type == "name").Value));
            identity.AddClaim(new Claim("surname", jwt.Claims.FirstOrDefault(x => x.Type == "surname").Value));
            identity.AddClaim(new Claim("phonenumber", jwt.Claims.FirstOrDefault(x => x.Type == "phonenumber").Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Jti, jwt.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Aud, jwt.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud).Value));
            identity.AddClaim(new Claim(ClaimTypes.Role, jwt.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value));

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
    }
}
