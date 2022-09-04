using HPlusSport.API.DataStore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HPlusSport.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShopContext _shopContext;

        public ProductsController(ShopContext context)
        {
            _shopContext = context ?? throw new ArgumentNullException(nameof(context));

            _shopContext.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _shopContext.Products.ToArrayAsync());
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
