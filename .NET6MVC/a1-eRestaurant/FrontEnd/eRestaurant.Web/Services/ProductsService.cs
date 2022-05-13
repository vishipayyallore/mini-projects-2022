using eRestaurant.Web.Common;
using eRestaurant.Web.Models;
using eRestaurant.Web.Services.Interfaces;

namespace eRestaurant.Web.Services
{

    public class ProductService : BaseService, IProductsService
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string ApiEndPoint = "/api/v1/products";

        public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> CreateProductAsync<T>(ProductDto productDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = Constants.ApiType.POST,
                Data = productDto,
                Url = $"{Constants.ProductAPIBase}{ApiEndPoint}",
                AccessToken = token
            });
        }

        public async Task<T> DeleteProductAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = Constants.ApiType.DELETE,
                Url = $"{Constants.ProductAPIBase}{ApiEndPoint}/{id}",
                AccessToken = token
            });
        }

        public async Task<T> GetAllProductsAsync<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = Constants.ApiType.GET,
                Url = $"{Constants.ProductAPIBase}{ApiEndPoint}",
                AccessToken = token
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = Constants.ApiType.GET,
                Url = $"{Constants.ProductAPIBase}{ApiEndPoint}/{id}",
                AccessToken = token
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = Constants.ApiType.PUT,
                Data = productDto,
                Url = $"{Constants.ProductAPIBase}{ApiEndPoint}",
                AccessToken = token
            });
        }
    }

}
