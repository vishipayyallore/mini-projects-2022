namespace HPlusSport.API.QueryHelper
{

    public class SearchQueryParameters : PagingQueryParameters
    {
        public string Sku { get; set; } = string.Empty;

        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }

        public string Name { get; set; } = string.Empty;
    }

}
