using Microsoft.AspNetCore.Mvc;
using Restaurant.Web.Models;
using Restaurant.Web.Services.Abstract;
using System.Diagnostics;

namespace Restaurant.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
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
