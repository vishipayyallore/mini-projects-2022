﻿namespace HPlusSport.API.Models
{

    public class User
    {
        public Guid Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public virtual List<Order>? Orders { get; set; }
    }

}
