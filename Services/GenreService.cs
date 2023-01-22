using Bookstore.Data;
using Bookstore.Data.DataObjects;

namespace Bookstore.Services
{
    public class GenreService : IGenreService
	{

		public List<Genre> GetAll()
		{
			using (var context = new ApplicationDbContext())
			{
				return context.Genres.ToList();
			}
		}

		public Genre GetById(int id)
		{
			using (var context = new ApplicationDbContext())
			{
				return context.Genres.Find(id);
			}
		}
	}
}
