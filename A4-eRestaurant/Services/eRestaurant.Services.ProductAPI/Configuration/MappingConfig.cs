using AutoMapper;
using eRestaurant.Services.ProductAPI.Dtos;
using eRestaurant.Services.ProductAPI.Models;

namespace eRestaurant.Services.ProductAPI.Configuration
{

    public class MappingConfig
    {

        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                _ = config.CreateMap<ProductDto, Product>().ReverseMap();
            });

            return mappingConfig;
        }

    }

}
