﻿using System.ComponentModel.DataAnnotations;

namespace BooksStore.Web.Core.Entities
{

    public class Book
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Thumbnail { get; set; } = string.Empty;

        public decimal Price { get; set; } = 0.0m;
    }

}
