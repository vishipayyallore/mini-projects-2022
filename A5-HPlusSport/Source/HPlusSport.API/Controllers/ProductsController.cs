using HPlusSport.API.DataStore;
using HPlusSport.API.Extensions;
using HPlusSport.API.Models;
using HPlusSport.API.QueryHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

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

            _shopContext.Database.EnsureCreated();
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
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
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await FindById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Product>> PostProduct([FromBody] Product product)
        {
            _shopContext.Products.Add(product);

            await _shopContext.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> PutProduct([FromRoute] int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            try
            {
                _shopContext.Entry(product).State = EntityState.Modified;

                await _shopContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                _shopContext.Entry(product).State = EntityState.Detached;
                var searchedProduct = await FindById(id);
                if (searchedProduct == null)
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await FindById(id);
            if (product == null)
            {
                return NotFound();
            }

            _shopContext.Products.Remove(product);

            await _shopContext.SaveChangesAsync();

            return product;
        }

        private async Task<Product?> FindById(int id)
        {
            return await _shopContext.Products.FindAsync(id);
        }

    }

}
