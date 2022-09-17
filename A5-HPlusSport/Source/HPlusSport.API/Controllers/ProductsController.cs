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

            products = FilterProductsByPrice(queryParameters, products);

            products = FilterProductsBySku(queryParameters, products);

            products = FilterProductsByName(queryParameters, products);

            products = SortProductsByField(queryParameters, products);

            products = FilterProductsByPageSize(queryParameters, products);

            return Ok(await products.ToArrayAsync());
        }

        private static IQueryable<Product> FilterProductsByPageSize(SearchQueryParameters queryParameters, IQueryable<Product> products)
        {
            products = products
                        .Skip(queryParameters.Size * (queryParameters.Page - 1))
                        .Take(queryParameters.Size);

            return products;
        }

        private static IQueryable<Product> SortProductsByField(SearchQueryParameters queryParameters, IQueryable<Product> products)
        {
            if (!string.IsNullOrEmpty(queryParameters.SortBy))
            {
                if (typeof(Product).GetProperty(queryParameters.SortBy) != null)
                {
                    products = products.OrderByCustom(queryParameters.SortBy, queryParameters.SortOrder);
                }
            }

            return products;
        }

        private static IQueryable<Product> FilterProductsByName(SearchQueryParameters queryParameters, IQueryable<Product> products)
        {
            if (!string.IsNullOrEmpty(queryParameters.Name))
            {
                products = products.Where(p => p.Name.ToLower().Contains(queryParameters.Name.ToLower()));
            }

            return products;
        }

        private static IQueryable<Product> FilterProductsBySku(SearchQueryParameters queryParameters, IQueryable<Product> products)
        {
            if (!string.IsNullOrEmpty(queryParameters.Sku))
            {
                products = products.Where(p => p.Sku == queryParameters.Sku);
            }

            return products;
        }

        private static IQueryable<Product> FilterProductsByPrice(SearchQueryParameters queryParameters, IQueryable<Product> products)
        {
            if (queryParameters.MinPrice != null)
            {
                products = products.Where(p => p.Price >= queryParameters.MinPrice.Value);
            }

            if (queryParameters.MaxPrice != null)
            {
                products = products.Where(p => p.Price <= queryParameters.MaxPrice.Value);
            }

            return products;
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
