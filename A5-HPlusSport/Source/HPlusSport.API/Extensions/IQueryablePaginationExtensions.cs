using HPlusSport.API.Models;
using HPlusSport.API.QueryHelper;

namespace HPlusSport.API.Extensions
{
    public static class IQueryablePaginationExtensions
    {

        public static IQueryable<Product> FilterProductsByPageSize(this IQueryable<Product> products, SearchQueryParameters queryParameters)
        {
            products = products
                        .Skip(queryParameters.Size * (queryParameters.Page - 1))
                        .Take(queryParameters.Size);

            return products;
        }

    }
}
