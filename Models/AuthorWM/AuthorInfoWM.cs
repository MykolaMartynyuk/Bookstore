using Bookstore.Data.DataObjects;

namespace Bookstore.Models.AuthorWM
{
    public class AuthorInfoWM
    {
        private readonly Author _author;
        public AuthorInfoWM(Author author)
        {
            _author = author;
        }
    }
}
