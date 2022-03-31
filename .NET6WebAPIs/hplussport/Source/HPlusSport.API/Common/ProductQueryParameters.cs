namespace HPlusSport.API.Common
{

    public class ProductQueryParameters : QueryParameters
    {
        public string Sku { get; set; } = string.Empty;

        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }
    }

}
