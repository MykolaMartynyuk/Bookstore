using Bookstore.Data.DataObjects;

namespace Bookstore.Services
{
    public interface IBookService
	{
		public List<Book> GetAll();
		public Book GetById(int id);
		public void Delete(int id);
		public Book UpDate(Book? book);
	}
}
