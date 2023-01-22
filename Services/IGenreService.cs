using Bookstore.Data.DataObjects;

namespace Bookstore.Services
{
    public interface IGenreService
	{
		public List<Genre> GetAll();
		public Genre GetById(int id);
	}
}
