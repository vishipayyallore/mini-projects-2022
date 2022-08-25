namespace eShop.Infrastructure.Event.Product
{
    public class ProductCreated
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
    }

}
