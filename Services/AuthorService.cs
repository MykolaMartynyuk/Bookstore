using Bookstore.Data;
using Bookstore.Data.DataObjects;

namespace Bookstore.Services
{
    public class AuthorService : IAuthorService
	{
		public List<Author> GetAll()
		{
			using(var context = new ApplicationDbContext())
			{
				return context.Authors.ToList();
			}
			
		}

		public Author GetById(int id)
		{
			using(var context = new ApplicationDbContext())
			{
				return context.Authors.FirstOrDefault(x => x.Id == id);
			}
		}

		public Author UpDate(Author? authorToUpDate)
		{
			using(var context = new ApplicationDbContext())
			{

				context.Authors.Update(authorToUpDate);
				
				context.SaveChanges();
				return authorToUpDate;
			}
		}
		
		public void Delete(int id)
		{
			using(var context = new ApplicationDbContext())
			{
				context.Authors.Remove(GetById(id));
				context.SaveChanges();
			}
		}

		//public void Create(Author authorToCreate)
		//{
		//	using(var context = new ApplicationDbContext())
		//	{
		//		context.Add(authorToCreate);
		//		context.SaveChanges();
		//	}
		//}
	}
}
