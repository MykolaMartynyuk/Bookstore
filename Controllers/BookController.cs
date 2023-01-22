using Bookstore.Models.BookWM;
using Bookstore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Bookstore.Controllers
{
    public class BookController : Controller
    {
        private IAuthorService _authorSevice;
        private IBookService _bookService;
        private IGenreService _genreService;
        private IFileUploadService _fileUploadService;
        private HttpContext _httpContext;


        public BookController(IBookService bookService, IAuthorService authorService, IGenreService genreService, IFileUploadService fileUploadService)
        {
            _genreService = genreService;
            _authorSevice = authorService;
            _bookService = bookService;
            _fileUploadService = fileUploadService;
        }

        public IActionResult CatalogBook()
        {
            var model = new BookCatalogWM(_bookService.GetAll());
            return View(model);
        }

        [Authorize]
        public IActionResult AddToShoppingCart(int id)
        {
            var cart = new ShoppingCart();
			cart.Add(_bookService.GetById(id));
            HttpContext.Session.SetObjectAsJson("cart", cart);


            var test = cart;
			//_httpContext.Session.SetString("cart", JsonSerializer.Serialize(cart));
			return RedirectToAction("CatalogBook");
        }

		[Authorize(Policy = "AdminOnly")]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return View(new BookEditWM(_authorSevice.GetAll(), _genreService.GetAll()));
            }
            else
            {
                return View(new BookEditWM(_bookService.GetById(id), _authorSevice.GetAll(), _genreService.GetAll()));
            }

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BookEditWM model)
        {

            _fileUploadService.UploadFileAsync(model.FileToUpload);
			if (ModelState.IsValid)
            {
                model.NewBook.ImageURL = model.FileToUpload.FileName;
                _bookService.UpDate(model.NewBook);
                return RedirectToAction("CatalogBook");
            }
            return View(model);

        }

        public IActionResult InfoBook(int id)
        {
            return View(new BookInfoWM(_bookService.GetById(id)));
        }
		//private async void OnPost(IFormFile formFile)
		//{
		//	if (formFile != null)
		//	{
		//		IMG = await _fileUploadService.UploadFileAsync(formFile);
		//	}

		//}
	}
}
