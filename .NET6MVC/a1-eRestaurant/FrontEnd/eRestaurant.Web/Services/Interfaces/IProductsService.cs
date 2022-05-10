using eRestaurant.Web.Models;

namespace eRestaurant.Web.Services.Interfaces
{

    public interface IProductsService : IBaseService
    {
        Task<T> GetAllProductsAsync<T>(string token);

        Task<T> GetProductByIdAsync<T>(int id, string token);

        Task<T> CreateProductAsync<T>(ProductDto productDto, string token);

        Task<T> UpdateProductAsync<T>(ProductDto productDto, string token);

        Task<T> DeleteProductAsync<T>(int id, string token);
    }

}
