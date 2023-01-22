using Bookstore.Data.DataObjects;

namespace Bookstore.Models.BookWM
{
    public class BookCatalogWM
    {
        public string path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\images"}";
        public BookCatalogWM(List<Book> books)
        {
            Books = books;
        }

        public List<Book> Books { get; }
    }
}
