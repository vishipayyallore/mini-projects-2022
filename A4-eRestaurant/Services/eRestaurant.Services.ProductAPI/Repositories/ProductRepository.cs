using AutoMapper;
using eRestaurant.Services.ProductAPI.DbContexts;
using eRestaurant.Services.ProductAPI.Dtos;
using eRestaurant.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace eRestaurant.Services.ProductAPI.Repositories
{

    public class ProductRepository : IProductRepository
    {

        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _applicationDbContext = db ?? throw new ArgumentNullException(nameof(db));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);

            if (product.ProductId > 0)
            {
                _applicationDbContext?.Products?.Update(product);
            }
            else
            {
                _applicationDbContext?.Products?.Add(product);
            }

            await _applicationDbContext.SaveChangesAsync();

            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _applicationDbContext.Products
                                            .FirstOrDefaultAsync(u => u.ProductId == productId);

                if (product == null)
                {
                    return false;
                }

                _applicationDbContext.Products.Remove(product);

                await _applicationDbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product product = await _applicationDbContext.Products
                                        .Where(x => x.ProductId == productId)
                                        .FirstOrDefaultAsync();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> productList = await _applicationDbContext.Products.ToListAsync();

            return _mapper.Map<List<ProductDto>>(productList);

        }

    }

}
