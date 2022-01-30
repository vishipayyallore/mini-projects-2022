using BooksStore.Core.Entities;

namespace BooksStore.Web.ViewModels
{
    public class BookPurchaseVM : Book
    {
        public string Nonce { get; set; } = string.Empty;
    }

}
