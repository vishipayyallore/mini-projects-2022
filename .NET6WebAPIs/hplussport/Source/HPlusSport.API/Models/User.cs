namespace HPlusSport.API.Models
{

    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Email { get; set; } = string.Empty;

        public virtual List<Order>? Orders { get; set; }
    }

}
