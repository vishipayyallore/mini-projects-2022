using eRestaurant.Services.ProductAPI.Dtos;

namespace eRestaurant.Services.ProductAPI.Repositories
{

    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProducts();

        Task<ProductDto> GetProductById(int productId);

        Task<ProductDto> CreateUpdateProduct(ProductDto productDto);

        Task<bool> DeleteProduct(int productId);
    }

}
