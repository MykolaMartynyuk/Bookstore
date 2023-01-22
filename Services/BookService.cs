using Bookstore.Data;
using Bookstore.Data.DataObjects;

namespace Bookstore.Services
{
    public class BookService : IBookService
	{
		
		public List<Book> GetAll()
		{
			using(var contex = new ApplicationDbContext())
			{
				return contex.Books.ToList();
				
			}
		}

		public Book GetById(int id)
		{
			using (var context = new ApplicationDbContext())
			{
				return context.Books.Find(id);
			}
		}

		public void Delete(int id)
		{
			using (var context = new ApplicationDbContext())
			{
				context.Books.Remove(GetById(id));
				context.SaveChanges();
			}
		}

		public Book UpDate(Book? book) 
		{
			using(var context = new ApplicationDbContext())
			{
				context.Books.Update(book);
				context.SaveChanges();
				return book;
			}
		}
	}
}
