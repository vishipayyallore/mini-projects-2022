using HPlusSport.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HPlusSport.API.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly ILogger<ProductsController> _logger;
        private readonly ShopDbContext _shopDbContext;

        public ProductsController(ILogger<ProductsController> logger, ShopDbContext shopDbContext)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _shopDbContext = shopDbContext ?? throw new ArgumentNullException(nameof(shopDbContext));
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            _logger.LogInformation($"Request received at {nameof(GetProducts)}");

            return Ok(await _shopDbContext.Products.ToListAsync());
        }

    }

}