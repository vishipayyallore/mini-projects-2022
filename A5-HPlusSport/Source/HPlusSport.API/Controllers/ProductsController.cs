using HPlusSport.API.DataStore;
using HPlusSport.API.Extensions;
using HPlusSport.API.Models;
using HPlusSport.API.QueryHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HPlusSport.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShopDbContext _shopContext;

        public ProductsController(ShopDbContext context)
        {
            _shopContext = context ?? throw new ArgumentNullException(nameof(context));

            _shopContext?.Database?.EnsureCreated();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] SearchQueryParameters queryParameters)
        {
            IQueryable<Product> products = _shopContext.Products;

            products = products.FilterProductsByPrice(queryParameters);

            products = products.FilterProductsBySku(queryParameters);

            products = products.FilterProductsByName(queryParameters);

            products = products.SortProductsByField(queryParameters);

            products = products.FilterProductsByPageSize(queryParameters);

            return Ok(await products.ToArrayAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _shopContext.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

    }

}
