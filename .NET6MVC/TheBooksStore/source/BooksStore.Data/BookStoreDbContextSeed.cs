using BooksStore.Core.Entities;

namespace BooksStore.Data
{

    public class BookStoreDbContextSeed
    {

        public static void SeedDatabase(BookStoreDbContext bookStoreDbContext)
        {
            bookStoreDbContext.Database.EnsureCreated();

#pragma warning disable CS8604 // Possible null reference argument.
            if (!bookStoreDbContext.Books.Any())
#pragma warning restore CS8604 // Possible null reference argument.
            {
                bookStoreDbContext.Books.AddRangeAsync(GetPreconfiguredBooks());

                bookStoreDbContext.SaveChanges();
            }
        }

        private static IEnumerable<Book> GetPreconfiguredBooks()
        {
            return new List<Book>()
            {
                new Book()
                {
                    Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                    Title="Book 1",
                    Description="Short Description.",
                    Author= "Author 1",
                    PictureUrl = "/images/books/Book1.jpg",
                    Price = 19.90m
                },
                new Book()
                {
                    Id= new Guid("117366b8-3541-4ac5-8732-860d698e26a2"),
                    Title="Book 2",
                    Description="Short Description.",
                    Author= "Author 2",
                    PictureUrl = "/images/books/Book2.jpg",
                    Price = 29.90m
                },
                new Book()
                {
                    Id= new Guid("66ff5116-bcaa-4061-85b2-6f58fbb6db25"),
                    Title="Book 3",
                    Description="Short Description.",
                    Author= "Author 3",
                    PictureUrl = "/images/books/Book3.jpg",
                    Price = 32.49m
                },
                new Book()
                {
                    Id =  new Guid("cd5089dd-9754-4ed2-b44c-488f533243ef"),
                    Title="Book 4",
                    Description="Short Description.",
                    Author= "Author 4",
                    PictureUrl = "/images/books/Book4.jpg",
                    Price = 17.89m
                },
                new Book()
                {
                    Id =  new Guid("d81e0829-55fa-4c37-b62f-f578c692af78"),
                    Title="Book 5",
                    Description="Short Description.",
                    Author= "Author 5",
                    PictureUrl = "/images/books/Book5.jpg",
                    Price = 32.00m
                }
            };
        }

    }

}
