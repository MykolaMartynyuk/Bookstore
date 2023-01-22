using Bookstore.Data.DataObjects;

namespace Bookstore.Models.AuthorWM
{
    public class AuthorCatalogWM
    {
        private readonly List<Author> _authors;
        public AuthorCatalogWM(List<Author> authors)
        {
            _authors = authors;
        }

        public List<Author> Authors
        {
            get => _authors;
        }
    }
}
