using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Web.Models.Dtos.Cart;
using Restaurant.Web.Services.Abstract;
using System.Security.Claims;

namespace Restaurant.Web.Controllers
{
    public class CartController(ICartService _cartService) : Controller
    {

        [Authorize]
        public async Task<IActionResult> CartIndex()
        {
            var cart = await LoadCartDtoBasedOnLoggedInUser();

            return View(cart);
        }

        private async Task<CartDto> LoadCartDtoBasedOnLoggedInUser()
        {
            var userId = User.Claims.Where(u => u.Type == ClaimTypes.NameIdentifier).FirstOrDefault()?.Value ?? "0";

            var response = await _cartService.GetCartByUserIdAsync(int.Parse(userId));

            if (response is not null && response.IsSuccessful)
                return response.Data;

            return new();
        }
    }
}
