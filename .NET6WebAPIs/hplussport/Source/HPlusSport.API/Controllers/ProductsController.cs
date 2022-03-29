using Microsoft.AspNetCore.Mvc;

namespace HPlusSport.API.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {

            return Ok(Task.CompletedTask);
        }

    }

}