namespace HPlusSport.API.Models
{
    
    public class User
    {
        public int Guid { get; set; }
        
        public string Email { get; set; }
        
        public virtual List<Order> Orders { get; set; }
    }

}