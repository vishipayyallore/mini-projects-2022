using BooksStore.Core.Entities;

namespace BooksStore.Core.ViewModels
{
    public class BookPurchaseVM : Book
    {
        public string Nonce { get; set; } = string.Empty;
    }

}
