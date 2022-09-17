using HPlusSport.API.Models;
using HPlusSport.API.QueryHelper;

namespace HPlusSport.API.Extensions
{

    public static class IQueryableSortExtensions
    {

        public static IQueryable<Product> SortProductsByField(this IQueryable<Product> products, SearchQueryParameters queryParameters)
        {
            if (!string.IsNullOrEmpty(queryParameters.SortBy))
            {
                if (typeof(Product).GetProperty(queryParameters.SortBy) != null)
                {
                    products = products.OrderByCustom(queryParameters.SortBy, queryParameters.SortOrder);
                }
            }

            return products;
        }

    }

}
