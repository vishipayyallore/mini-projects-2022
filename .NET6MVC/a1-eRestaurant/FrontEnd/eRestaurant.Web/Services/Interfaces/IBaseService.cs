using eRestaurant.Web.Models;

namespace eRestaurant.Web.Services.Interfaces
{

    public interface IBaseService
    {
        ResponseDto ResponseModel { get; set; }

        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }

}
