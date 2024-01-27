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

        public IActionResult ProductUpdate(int productId)
        {
            UpdateProductDto updateProductDto = new UpdateProductDto()
            {
                Id = productId,
            };

            return View(updateProductDto);
        }

        [HttpPost]
        public async Task<IActionResult> ProductUpdate(UpdateProductDto model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _productService.UpdateProductAsync(model);

            if (result is not null || result.IsSuccessful)
                return RedirectToAction(nameof(ProductIndex));


            TempData["error"] = result?.Error?.Errors.First().ToString();

            return View(model);

        }

        public async Task<IActionResult> ProductDelete(int productId)
        {
			var result = await _productService.DeleteProductByIdAsync(productId);

			if (!result.IsSuccessful)
				TempData["error"] = result?.Error?.Errors.First().ToString();
			else
				TempData["success"] = "Successfuly deleted.";

			return RedirectToAction(nameof(ProductIndex));
		}
	}
}
