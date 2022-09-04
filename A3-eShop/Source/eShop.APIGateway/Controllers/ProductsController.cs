using eShop.Infrastructure.Command.Product;
using Microsoft.AspNetCore.Mvc;

namespace eShop.APIGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(string productId)
        {
            await Task.CompletedTask;
            return Accepted("Product Created");
        }

        [HttpPost]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Add([FromForm] CreateProduct product)
        {

            await Task.CompletedTask;
            return Accepted("Product Created");
        }

    }
}
