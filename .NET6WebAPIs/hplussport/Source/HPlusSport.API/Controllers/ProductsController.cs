using HPlusSport.API.Common;
using HPlusSport.API.Data;
using HPlusSport.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HPlusSport.API.Controllers
{

    /// <summary>
    /// Description: API for Products
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly ILogger<ProductsController> _logger;
        private readonly ShopDbContext _shopDbContext;

        /// <summary>
        /// Description: Constructor with dependency injection
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="shopDbContext"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ProductsController(ILogger<ProductsController> logger, ShopDbContext shopDbContext)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _shopDbContext = shopDbContext ?? throw new ArgumentNullException(nameof(shopDbContext));
        }

        /// <summary>
        /// Description: Retrieves all the Products
        /// </summary>
        /// <param name="queryParameters"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] ProductQueryParameters queryParameters)
        {
            _logger.LogInformation($"Request received at {nameof(GetProducts)}");

            if (_shopDbContext.Products is null)
            {
                return Ok(new List<Product>());
            }

            IQueryable<Product> products = _shopDbContext.Products;

            if (queryParameters.MinPrice != null)
            {
                products = products.Where(p => p.Price >= queryParameters.MinPrice.Value);
            }

            if (queryParameters.MaxPrice != null)
            {
                products = products.Where(p => p.Price <= queryParameters.MaxPrice.Value);
            }

            if (!string.IsNullOrEmpty(queryParameters.Sku))
            {
                products = products.Where(p => p.Sku == queryParameters.Sku);
            }

            products = products.Skip(queryParameters.Size * (queryParameters.Page - 1))
                               .Take(queryParameters.Size);

            return Ok(await products.ToListAsync());
        }

        /// <summary>
        /// Description: Retrieves a Product for the given Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("{productId:Guid}")]
        public async Task<IActionResult> GetProductById(Guid productId)
        {
            if (_shopDbContext.Products is null)
            {
                return NotFound();
            }

            var product = await _shopDbContext.Products.FindAsync(productId);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

    }

}