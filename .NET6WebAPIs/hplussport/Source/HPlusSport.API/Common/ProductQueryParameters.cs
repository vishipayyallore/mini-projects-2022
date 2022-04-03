namespace HPlusSport.API.Common
{

    /// <summary>
    /// 
    /// </summary>
    public class ProductQueryParameters : QueryParameters
    {
        /// <summary>
        /// 
        /// </summary>
        public string? Sku { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public decimal? MinPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? MaxPrice { get; set; }
    }

}
