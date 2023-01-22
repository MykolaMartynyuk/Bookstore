using Bookstore.Data.DataObjects;
using Bookstore.Models.OrderWM;
using Bookstore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace Bookstore.Controllers
{
    public class OrderController : Controller
    {
        IOrderService _orderService;
        HttpContext _httpContext;
        public OrderController( IOrderService orderService)
        {
            _orderService = orderService;

        }

        [Authorize]
        public IActionResult Cart()
        {
            
            var cart = new ShoppingCart();
            cart = HttpContext.Session.GetObjectFromJsno<ShoppingCart>("cart");
            return View(new CartWM(cart));
        }

        [Authorize]
        [HttpPost]
        public IActionResult CheckOut(CheckoutWM model)
        {
            var test1 = model.NewOrder;
            var cart = new ShoppingCart();
            cart = HttpContext.Session.GetObjectFromJsno<ShoppingCart>("cart");
            if (ModelState.IsValid)
            {
                model.NewOrder.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _orderService.SaveOrder(model.NewOrder, cart);
                HttpContext.Session.SetObjectAsJson("cart", string.Empty);
                return RedirectToAction("Confirmed");
            }
            return View(new CheckoutWM(cart));
        }

        [Authorize]
        public IActionResult CheckOut()
        {
            var cart = new ShoppingCart();
            cart = HttpContext.Session.GetObjectFromJsno<ShoppingCart>("cart");
            return View(new CheckoutWM(cart));
        }



        [Authorize]
        public IActionResult Confirmed()
        {
            return View();
        }

        [Authorize]
        public IActionResult Remove(int id)
        {
            var cart = HttpContext.Session.GetObjectFromJsno<ShoppingCart>("cart");
            if(cart != null)
            {
				cart.Remove(cart.First(x => x.Id == id));
			}

            HttpContext.Session.SetObjectAsJson("cart", cart);

            return RedirectToAction("Cart");
        }

    }
}
