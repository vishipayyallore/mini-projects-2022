using eRestaurant.Web.Models;
using eRestaurant.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eRestaurant.Web.Controllers
{
    public class ProductsController : Controller
    {

        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
        }

        public async Task<IActionResult> ProductsIndex()
        {
            List<ProductDto> productDtos = new();

            var response = await _productsService.GetAllProductsAsync<ResponseDto>("");
            if (response != null && response.IsSuccess)
            {
                productDtos = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }

            return View(productDtos);
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate(ProductDto model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = string.Empty; // await HttpContext.GetTokenAsync("access_token");
                var response = await _productsService.CreateProductAsync<ResponseDto>(model, accessToken);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductsIndex));
                }
            }

            return View(model);
        }

        public async Task<IActionResult> ProductEdit(int productId)
        {
            var accessToken = string.Empty; // await HttpContext.GetTokenAsync("access_token");
            var response = await _productsService.GetProductByIdAsync<ResponseDto>(productId, accessToken);
            if (response != null && response.IsSuccess)
            {
                ProductDto model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));

                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductEdit(ProductDto model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = string.Empty; // await HttpContext.GetTokenAsync("access_token");
                var response = await _productsService.UpdateProductAsync<ResponseDto>(model, accessToken);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductsIndex));
                }
            }
            return View(model);
        }

    }

}
