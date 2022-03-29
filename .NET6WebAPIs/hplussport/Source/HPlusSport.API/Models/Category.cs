﻿namespace HPlusSport.API.Models
{

    public class Category
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public virtual List<Product>? Products { get; set; }
    }

}
