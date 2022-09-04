using eShop.Infrastructure.Command.Product;
using eShop.Infrastructure.Event.Product;

namespace eShop.ProductsAPI.Services
{
    public interface IProductsService
    {

        Task<ProductCreated> AddProduct(CreateProduct createProduct);
    }
}
