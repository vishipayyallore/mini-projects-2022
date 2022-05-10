namespace eRestaurant.Web.Common
{

    public static class Constants
    {
        public static string ProductAPIBase { get; set; } = string.Empty;

        public static string ShoppingCartAPIBase { get; set; } = string.Empty;

        public static string CouponAPIBase { get; set; } = string.Empty;

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }

    }

}
