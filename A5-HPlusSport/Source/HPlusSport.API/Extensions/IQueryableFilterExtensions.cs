using HPlusSport.API.Models;
using HPlusSport.API.QueryHelper;

namespace HPlusSport.API.Extensions
{

    public static class IQueryableFilterExtensions
    {

        public static IQueryable<Product> FilterProductsByPrice(this IQueryable<Product> products, SearchQueryParameters queryParameters)
        {
            if (queryParameters.MinPrice != null)
            {
                products = products.Where(p => p.Price >= queryParameters.MinPrice.Value);
            }

            if (queryParameters.MaxPrice != null)
            {
                products = products.Where(p => p.Price <= queryParameters.MaxPrice.Value);
            }

            return products;
        }

        public static IQueryable<Product> FilterProductsBySku(this IQueryable<Product> products, SearchQueryParameters queryParameters)
        {
            if (!string.IsNullOrEmpty(queryParameters.Sku))
            {
                products = products.Where(p => p.Sku == queryParameters.Sku);
            }

            return products;
        }

        public static IQueryable<Product> FilterProductsByName(this IQueryable<Product> products, SearchQueryParameters queryParameters)
        {
            if (!string.IsNullOrEmpty(queryParameters.Name))
            {
                products = products.Where(p => p.Name.ToLower().Contains(queryParameters.Name.ToLower()));
            }

            return products;
        }

    }

}
