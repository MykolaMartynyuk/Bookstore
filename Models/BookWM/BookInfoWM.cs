using Bookstore.Data.DataObjects;

namespace Bookstore.Models.BookWM
{
    public class BookInfoWM
    {
        public BookInfoWM(Book book)
        {
            Book = book;
        }

        public Book Book { get; }
    }
}
