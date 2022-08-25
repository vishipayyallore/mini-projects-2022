using eShop.Infrastructure.Command.Product;
using eShop.Infrastructure.Event.Product;

namespace eShop.ProductsAPI.Services
{
    public class ProductsService : IProductsService
    {
        public Task<ProductCreated> AddProduct(CreateProduct createProduct)
        {
            throw new NotImplementedException();
        }
    }
}
