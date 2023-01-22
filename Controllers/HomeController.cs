using Bookstore.Data.DataObjects;
using Bookstore.Models;
using Bookstore.Models.BookWM;
using Bookstore.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bookstore.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly IBookService _bookService;
		private readonly UserManager<CustomUser> _userManager;

        public HomeController(ILogger<HomeController> logger, IBookService bookService, UserManager<CustomUser> userManager)
		{
			_logger = logger;
			_bookService = bookService;
			_userManager = userManager;
		}

		//public IActionResult Index()
		//{
		//	return View();
		//}

        public async Task<IActionResult> Index()
        {
			if (HttpContext.User.Identity.IsAuthenticated)
			{
				//string userId = _userManager.GetUserId(User);
				CustomUser user = await _userManager.GetUserAsync(HttpContext.User);
			}
            var model = new BookCatalogWM(_bookService.GetAll());
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}