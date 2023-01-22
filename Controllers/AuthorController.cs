using Bookstore.Data.DataObjects;
using Bookstore.Models.AuthorWM;
using Bookstore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
	public class AuthorController : Controller
	{
		private IAuthorService _authorSevice;

		public AuthorController (IAuthorService authorService)
		{
			_authorSevice = authorService;
		}

		public IActionResult Index()
		{
			return View();
		}

        [Authorize(Policy = "AdminOnly")]
        public IActionResult Delete( int id)
		{
			if (id != 0)
			{
				_authorSevice.Delete(id);
			}

			return RedirectToAction("CatalogAuthor");
		}

		public IActionResult CatalogAuthor()
		{

			
			var model = new AuthorCatalogWM(_authorSevice.GetAll());
			return View(model);
		}

        [Authorize(Policy = "AdminOnly")]
        public IActionResult Edit(int id)
		{
			if (id == 0)
			{
                return View(new AuthorEditWM());
            }
			else
			{
                return View(new AuthorEditWM(_authorSevice.GetById(id)));
            }

		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(AuthorEditWM model)
		{
			if (ModelState.IsValid)
			{
				_authorSevice.UpDate(model.NewAuthor);
				return RedirectToAction("CatalogAuthor");
			}
			return View(model);

		}

		public IActionResult InfoAuthor( int id)
		{
			return View(new AuthorInfoWM(_authorSevice.GetById(id)));
		}


	}
}
