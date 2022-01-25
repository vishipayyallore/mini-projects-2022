﻿using BooksStore.Web.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Web.Data
{

    public class BookStoreDbContext : DbContext
    {

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
        }

        public DbSet<Book>? Books { get; set; }
    }

}
