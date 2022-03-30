using HPlusSport.API.Common;
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
        public async Task<IActionResult> GetProducts([FromQuery] QueryParameters queryParameters)
        {
            _logger.LogInformation($"Request received at {nameof(GetProducts)}");

            var products = await _shopDbContext.Products
                                    .Skip(queryParameters.Size * (queryParameters.Page - 1))
                                    .Take(queryParameters.Size)
                                    .ToListAsync();

            return Ok(products);
        }

        [HttpGet("{productId:Guid}")]
        public async Task<IActionResult> GetProductById(Guid productId)
        {
            var product = await _shopDbContext.Products.FindAsync(productId);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

    }

}