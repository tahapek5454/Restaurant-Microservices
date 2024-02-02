using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Web.Models;
using Restaurant.Web.Models.Dtos.Cart;
using Restaurant.Web.Models.Dtos.Product;
using Restaurant.Web.Services.Abstract;
using System.Diagnostics;
using System.Security.Claims;

namespace Restaurant.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;

        public HomeController(IProductService productService, ICartService cartService)
        {
            _productService = productService;
            _cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _productService.GetAllProductsAsync();

            if (result is null || !result.IsSuccessful)
            {
                TempData["error"] = result?.Error?.Errors.First().ToString();
                return RedirectToAction("Index", "Home");
            }

            return View(result.Data);
        }

        [Authorize]
        public async Task<IActionResult> ProductDetails(int productid)
        {
            var result = await _productService.GetProductByIdAsync(productid);

            if (result is null || !result.IsSuccessful)
            {
                TempData["error"] = result?.Error?.Errors.First().ToString();
                return RedirectToAction("Index", "Home");
            }

            return View(result.Data);
        }

        [Authorize]
        [HttpPost]
        [ActionName("ProductDetails")]
        public async Task<IActionResult> ProductDetails(ProductDto productDto)
        {
            CartDto cartDto = new CartDto()
            {
                CartHeader = new CartHeaderDto()
                {
                    UserId = int.Parse(User.Claims.Where(u => u.Type == ClaimTypes.NameIdentifier).FirstOrDefault()?.Value ?? "0"),                  
                }
            };

            CartDetailDto cartDetailDto = new CartDetailDto()
            {
                Count = productDto.Count,
                ProductId = productDto.Id
            };

            cartDto.CartDetails.Add(cartDetailDto);


            var result = await _cartService.UpsertCartAsync(cartDto);

            if (result is null || !result.IsSuccessful)
            {
                TempData["error"] = result?.Error?.Errors.First().ToString();

            }
            else
            {
                TempData["success"] = "Added to Cart Successfuly";
            }



            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
