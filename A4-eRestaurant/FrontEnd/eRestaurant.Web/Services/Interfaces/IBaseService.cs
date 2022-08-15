using eRestaurant.Web.Models;

namespace eRestaurant.Web.Services.Interfaces
{

    public interface IBaseService
    {
        // TODO: Can we remove this property
        ResponseDto ResponseModel { get; set; }

        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }

}
