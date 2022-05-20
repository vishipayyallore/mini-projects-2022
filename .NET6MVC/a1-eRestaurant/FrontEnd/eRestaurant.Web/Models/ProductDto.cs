using System.ComponentModel.DataAnnotations;

namespace eRestaurant.Web.Models
{

    public class ProductDto
    {

        public ProductDto()
        {
            Count = 1;
        }

        public int ProductId { get; set; }

        public string Name { get; set; } = string.Empty;

        public double Price { get; set; }

        public string Description { get; set; } = string.Empty;

        public string CategoryName { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        [Range(1, 10)]
        public int Count { get; set; }
    }

}
