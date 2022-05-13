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

    }

}
