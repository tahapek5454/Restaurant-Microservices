using Microsoft.AspNetCore.Mvc;
using Restaurant.Web.Models.Dtos.Product;
using Restaurant.Web.Services.Abstract;
using Restaurant.Web.Services.Concrete;
using System.Reflection;

namespace Restaurant.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		public async Task<IActionResult> ProductIndex()
        {
			var result = await _productService.GetAllProductsAsync();

			if (result is null || !result.IsSuccessful)
			{
				TempData["error"] = result?.Error?.Errors.First().ToString();
				return RedirectToAction("Index", "Home");
			}

			return View(result.Data);
        }

        public IActionResult ProductCreate()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> ProductCreate(CreateProductDto model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _productService.CreateProductAsync(model);

            if (result is not null || result.IsSuccessful)
                return RedirectToAction(nameof(ProductIndex));


            TempData["error"] = result?.Error?.Errors.First().ToString();

            return View(model);

		}
	}
}
