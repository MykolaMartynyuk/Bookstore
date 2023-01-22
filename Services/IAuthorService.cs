using Bookstore.Data.DataObjects;

namespace Bookstore.Services
{
    public interface IAuthorService
	{
		public List<Author> GetAll();

		public Author GetById(int id);

		public Author UpDate(Author author);

		public void Delete(int id);
	}
}
